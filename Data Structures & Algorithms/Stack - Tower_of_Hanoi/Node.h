//Node.h by Ian Allen
#pragma once
#include <ostream>
using namespace std;

template <class P>    //template keyword. P for payload
class Node
{
private:
	P payload;
	Node* next;

public:
	//Node constructor
	Node(P newPayload, Node* newNext)
	{
		next = newNext;
		payload = newPayload;
	}

	// Accessor to get payload
	P getPayload() const
	{
		return payload;
	}

	// Accessor to get next node
	Node* getNext() const
	{
		return next;
	}

	// Mutator to set payload
	void setPayload(P newPayload)
	{
		payload = newPayload;
	}

	// Mutator to set next node
	void setNext(Node* newNext)
	{
		next = newNext;
	}

	//Overload Test (Tested and Executed)
	friend ostream& operator <<(ostream& outStream, const Node& n1)
	{
		outStream << n1.payload; //endl
		return (outStream);
	}
	
	// Node destructor
	~Node()
	{

	}
	
	//original .h contents
	/* 
	//Constructor - note no default
	Node(int newPayload, Node* newNext);
	
	//Accessors
	int getPayload() const;
	Node* getNext() const;

	//Mutators
	void setPayload(int newPayload);
	void setNext(Node* next);

	//Destructor
	~Node();

	//Overload
	friend ostream& operator << (ostream& outStream, const Node& n1); // method to display node as a method
	*/
};

