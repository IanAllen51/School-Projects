//Stack.h by Ian Allen
#pragma once
#include "Node.h"
#include <ostream>
#define NDEBUG
#include <cassert>
#include <exception>

using namespace std;

template <class P> //Replace P for ints that would return payload
class Stack
{
private:
	Node<P>* top;		// Pointer to the top element;  ////Replace Node with Node<int>
	int numNodes;	// Number of elements in the stack;

public:

	//stack constructor
	Stack()
	{
		top = nullptr;
		numNodes = 0;
	}

	// push method for stack class
	void push(P newPayload)
	{
		//exception
		if (new Node<P>(newPayload, top) == nullptr)
		{
			throw runtime_error("Illegal Push");
		}

		top = new Node<P>(newPayload, top);
		numNodes++;
	}

	// pop method for stack class
	P pop() ////change int to P
	{
		assert(top != nullptr);

		//exception
		if (top == nullptr)
		{
			throw runtime_error("Illegal Pop");
		}

		P tempVal = top->getPayload();
		Node<P>* tempPtr = top->getNext();
		delete top;
		top = tempPtr;
		numNodes--;
		return tempVal;
	}

	// method to act as .back
	P readTop() const
	{
		assert(top != nullptr);

		//exception
		if (top == nullptr)
		{
			throw runtime_error("Illegal Read");
		}

		return top->getPayload();
	}

	// method to display node count
	unsigned int getNumNodes() const
	{
		return numNodes;
	}

	//clear stack method using pop
	void clearStack()
	{
		while (top != nullptr)
		{
			pop();
		}
	}

	//Reverse Display
	void displayNodeReverse(ostream& outStream, Node<P>* start) const
	{
		if (start->getNext() != nullptr)
		{
			displayNodeReverse(outStream, start->getNext());
		}
		outStream << *start << " "; // << endl;
	}

	//Overload << with recursion
	friend ostream& operator <<(ostream& outStream, const Stack& stack)
	{
		if (stack.top != nullptr)
		{
			stack.displayNodeReverse(outStream, stack.top);
		}
		return(outStream);

	}

	//Copy constructor
	Stack(const Stack& other)
	{
		top = nullptr;
		numNodes = 0;
		copyNodes(other.top);
	}

	//Copy helper method
	void copyNodes(const Node<P>* current)
	{
		if (current != nullptr)
		{
			copyNodes(current->getNext());
			push(current->getPayload());
		}
	}

	//copy =operator overload
	const Stack& operator =(const Stack& from)
	{
		if (this != &from)
		{
			this->clearStack();
			this->copyNodes(from.top);

		}
		return (*this);
	}

	//==operator overload
	bool operator==(const Stack& rhs) const
	{

		bool retval = true;						//Start with return value equal to true	
		if (numNodes == rhs.numNodes) {			//compare the number of nodes in both the left and right stack
			Node<P>* currentLHS = top;		//create pointer for current left hand stack position
			Node<P>* currentRHS = rhs.top;	//create pointer for current right hand stack position

			while (currentLHS != nullptr) {		//if both this and rhs have similar numNodes, both will reach null at same time
				if (currentLHS->getPayload() != currentRHS->getPayload()) {		//compare payload of each pointer
					retval = false;												//if not equal, return a false bool
				}
				currentLHS = currentLHS->getNext();			//move left pointer down the stack
				currentRHS = currentRHS->getNext();			//move right pointer down the stack

			}
		}
		else (retval = false);	//if numNodes are not equal set return value to false
		return (retval);		//return bool value
	}


	// stack destructor with clear to dealocate any remaining memory
	~Stack()
	{
		clearStack();
	}
};

