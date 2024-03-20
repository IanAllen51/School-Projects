#pragma once
#include "BinNode.h"
#include "Queue.h"
using namespace std;


enum class TraverseType { INORDER, PREORDER, POSTORDER, BREADTHORDER};


template <class P>
class BTree
{
private:
	BinNode<P>* head;
	TraverseType traverseOrder;

public:
	
	BTree()
	{
		head = nullptr;
	}

	//copy constructor
	BTree(const BTree& other)
	{
		head = copyHelper(other.getHead(), head);	
	}

	BinNode<P>* getHead() const
	{
		return(head);
	}

	void setHead(BinNode<P>* node)
	{
		head = node;
	}

	friend ostream& operator <<(ostream& outStream, const BTree& bT)
	{

		switch (bT.getTraverseOrder()) { 
		case TraverseType::INORDER:
			bT.inOrderTraversal(outStream, bT.getHead());
			break;
		case TraverseType::PREORDER:
			bT.preOrder(outStream,bT.getHead());
			break;
		case TraverseType::POSTORDER:
			bT.postOrder(outStream, bT.getHead());
			break;
		case TraverseType::BREADTHORDER:
			bT.breadthOrderTraversal(outStream);  
			break;
		default:
			bT.breadthOrderTraversal(outStream);
			break;
		}
		return(outStream);
	}


	const BTree& operator =(const BTree& from)
	{
		if (this != &from) 
		{
			this->clearTree(head);
			head = copyHelper(from.getHead(), head); //from.gethead()
		}
		return(*this);
	}
	
	
	//destructor
	~BTree()
	{
		if (head != nullptr)
		{
			clearTree(head);
		}
	}

	//secondary methods

	//copy method
	
	BinNode<P>* copyHelper(const BinNode<P>* fromNode, BinNode<P>* toNode) //void was BinNode<P>*
	{
		if (fromNode != nullptr) 
		{
			toNode = new BinNode<P>(fromNode->getPayload());
			toNode->setLeft(copyHelper(fromNode->getLeft(), toNode->getLeft()));
			toNode->setRight(copyHelper(fromNode->getRight(), toNode->getRight()));
		}
		return toNode;
	}
	

	//clear method
	void clearTree(BinNode<P>* current)
	{
		if (current != nullptr)
		{
			clearTree(current->getLeft());
			clearTree(current->getRight());
			delete current;
		}
	}

	void inOrderTraversal(ostream& outStream, BinNode<P>* current) const
	{
		if (current != nullptr)
		{
			inOrderTraversal(outStream, current->getLeft());
			outStream << current->getPayload();
			inOrderTraversal(outStream, current->getRight());
		}
	}

	void breadthOrderTraversal(ostream& outStream) const
	{
		Queue<BinNode<P>> queue;
		if (head != nullptr)
		{
			queue.enqueue(*head);
		}
		while (!queue.isEmpty())
		{
			BinNode<P> tempPtr = queue.dequeue(); 
			if (tempPtr.getLeft() != nullptr)
			{
				queue.enqueue(*tempPtr.getLeft());
			}
			if (tempPtr.getRight() != nullptr)
			{
				queue.enqueue(*tempPtr.getRight());
			}
			outStream << tempPtr.getPayload();
		}
	}

	//preorder print method
	void preOrder(ostream& outStream, BinNode<P>* current) const
	{
		if (current != nullptr)
		{
			outStream << current->getPayload();
			preOrder(outStream, current->getLeft());
			preOrder(outStream, current->getRight());
		}
	}

	//postorder print method
	void postOrder(ostream& outStream, BinNode<P>* current) const
	{
		if (current != nullptr)
		{
			postOrder(outStream, current->getLeft());
			postOrder(outStream, current->getRight());
			outStream << current->getPayload();
		}
	}


	//TraverseMethod
	void setTraverseOrder(TraverseType order)
	{
		traverseOrder = order;
	}

	//get Traverse method
	TraverseType getTraverseOrder() const
	{
		return traverseOrder;
	}
};

