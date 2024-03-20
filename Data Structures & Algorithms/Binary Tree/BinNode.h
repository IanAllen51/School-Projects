#pragma once
#include <iostream>
using namespace std;

template <class P>
class BinNode
{
private:
	P payload;
	BinNode* left;
	BinNode* right;

public:
	
	BinNode()
	{
		this->payload = NULL;
		this->left = nullptr;
		this->right = nullptr;
	}

	BinNode(P data)				
	{
		this->payload = data;
		this->left = nullptr;
		this->right = nullptr;
	}

	BinNode(P data, BinNode* l, BinNode* r)
	{
		this->payload = data;
		this->left = l;
		this->right = r;
	}

	P getPayload() const			
	{
		return (this->payload);
	}

	void setPayload(P data)		
	{
		this->payload = data;
	}

	BinNode* getLeft() const
	{
		return(this->left);
	}

	void setLeft(BinNode* l)
	{
		this->left = l;
	}

	BinNode* getRight() const
	{
		return(this->right);
	}

	void setRight(BinNode* r)
	{
		this->right = r;
	}

	friend ostream& operator << (ostream& outStream, const BinNode* bN)
	{
		outStream << bN->payload;
		return(outStream);
	}

	~BinNode()
	{

	}
};

