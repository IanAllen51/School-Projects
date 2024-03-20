#pragma once
#include <ostream>
using namespace std;

template<class P>
class Node
{
private:
	P payload;
	Node* next;

public:
	Node(const P& newPayload, Node* newNext)
	{
		payload = newPayload;
		next = newNext;
	}

	P getPayload() const
	{
		return(payload);
	}

	Node* getNext() const
	{
		return(next);
	}

	void setPayload(const P& newPayload)
	{
		payload = newPayload;
	}

	void setNext(Node* newNext)
	{
		next = newNext;
	}

	friend ostream& operator <<(ostream& outStream, const Node& node)
	{
		outStream << node.payload;
		return(outStream);
	}

	~Node()
	{

	}

};

