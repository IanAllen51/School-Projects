// Created by Ian Allen
// CS 132

#pragma once
#include <ostream>
#include <cassert>
#include "BinKeyedNode.h"
using namespace std;

template <class K, class P>
class BSTree
{
private:
	BinKeyedNode<K,P>* head;
	int count = 0;

	//copy helper
	BinKeyedNode<K, P>* copyBSTree(const BinKeyedNode<K, P>* fromHead)
	{
		BinKeyedNode<K, P>* newHead(nullptr);

		if (fromHead != nullptr)
		{
			newHead = new BinKeyedNode<K, P>(fromHead->getKey(), copyBSTree(fromHead->getLeft()),
				copyBSTree(fromHead->getRight()));
		}
		return(newHead);
	}

	
	//clear method
	void clearBSTree(BinKeyedNode<K, P>* root)
	{
		if (root != nullptr)
		{
			clearBSTree(root->getLeft());
			clearBSTree(root->getRight());
			delete root;
		}
	}

	//in order print method
	void printInOrder(ostream& outStream, const BinKeyedNode<K, P>* root) const
	{
		if (root != nullptr)
		{
			printInOrder(outStream, root->getLeft());
			outStream << *root << " ";
			printInOrder(outStream, root->getRight());
		}
	}
	


public:
	
	//constructor
	BSTree()
	{
		head = nullptr;
	}

	//copy constructor
	BSTree(const BSTree& fromTree)
	{
		head = copyBSTree(fromTree.getHead());
	}

	//get head method
	BinKeyedNode<K, P>* getHead() const
	{
		return(head);
	}

	//=overload
	BSTree& operator =(const BSTree& fromTree)
	{
		if (this != &fromTree)
		{
			clearBSTree(head);
			head = copyBSTree(fromTree.getHead());
		}
	}


	//<<overload
	friend ostream& operator <<(ostream& outStream, const BSTree<K, P>& tree)
	{
		tree.printInOrder(outStream, tree.getHead());
		return(outStream);
	}

	//insert method
	void insert(const K& newKey, const P& newPayload)
	{
		head = insertNode(head, newKey, newPayload);
	}

	//insertNode helper
	BinKeyedNode<K, P>* insertNode(BinKeyedNode<K, P>* nodePtr, const K& newKey, const P& newPayload)
	{
		if (nodePtr == nullptr)		//empty
		{
			nodePtr = new BinKeyedNode<K, P>(newKey, newPayload);
		}
		else if (newKey < nodePtr->getKey())	//less
		{
			nodePtr->setLeft(insertNode(nodePtr->getLeft(), newKey, newPayload));
		}
		else	//greater or equal
		{
			nodePtr->setRight(insertNode(nodePtr->getRight(), newKey, newPayload));
		}
		return(nodePtr);
	}


	//find method
	bool find(const K& searchKey, P& returnPayload)
	{
		count = 0;
		return(findNode(head, searchKey, returnPayload));
	}

	//find helper
	bool findNode(BinKeyedNode<K, P>* nodePtr, const K& searchKey, P& returnPayload)
	{
		bool returnVal(false);
		if (nodePtr != nullptr) // tree not empty
		{
			if (searchKey == nodePtr->getKey())
			{
				returnVal = true;
				returnPayload = nodePtr->getPayload();
			}
			else if (searchKey < nodePtr->getKey())
			{
				returnVal = findNode(nodePtr->getLeft(), searchKey, returnPayload);
			}
			else
			{
				returnVal = findNode(nodePtr->getRight(), searchKey, returnPayload);
			}
			count++;
		}
		return(returnVal);
	}

	int getCount() const
	{
		return(count);
	}


	~BSTree()
	{
		clearBSTree(head);
	}
};

