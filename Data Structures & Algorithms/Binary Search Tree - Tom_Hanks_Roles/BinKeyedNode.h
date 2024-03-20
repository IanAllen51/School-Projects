// Created by Ian Allen
// CS 132

#pragma once
#include <ostream>
using namespace std;

template <class K, class P>
class BinKeyedNode
{
	//private attributes
private:
	K key;
	P payload;
	BinKeyedNode* left;
	BinKeyedNode* right;

public:
	BinKeyedNode(const K& newKey, const P& newPayload)
	{
		key = newKey;
		payload = newPayload;
		left = nullptr;
		right = nullptr;
	}

	P getPayload() const
	{
		return(payload);
	}

	BinKeyedNode* getLeft() const
	{
		return(left);
	}

	BinKeyedNode* getRight() const
	{
		return(right); 
	}

	K getKey() const
	{
		return(key);
	}

	void setPayload(const P& newPayload)
	{
		payload = newPayload;
	}

	void setLeft(BinKeyedNode* newLeft)
	{
		left = newLeft;
	}

	void setRight(BinKeyedNode* newRight)
	{
		right = newRight;
	}

	void setKey(const K& newKey)
	{
		key = newKey;
	}

	friend ostream& operator <<(ostream& outStream, const BinKeyedNode<K, P>& node)
	{
		outStream << node.getPayload();
		return(outStream); 
	}
};

