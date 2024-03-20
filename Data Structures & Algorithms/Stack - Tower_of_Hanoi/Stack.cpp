//Stack.cpp by Ian Allen
#include "Stack.h"
#include <ostream>
#define NDEBUG
#include <cassert>
#include <exception>

/*
using namespace std;

//stack constructor
Stack::Stack()
{
	top = nullptr;
	numNodes = 0;
}

// push method for stack class
void Stack::push(int newPayload)
{
	//exception
	if (new Node(newPayload, top) == nullptr)
	{
		throw runtime_error("Illegal Push");
	}

	top = new Node(newPayload, top);
	numNodes++;
}

// pop method for stack class
int Stack::pop()
{
	assert(top != nullptr);

	//exception
	if (top == nullptr)
	{
		throw runtime_error("Illegal Pop");
	}

	int tempVal = top->getPayload();
	Node* tempPtr = top->getNext();
	delete top;
	top = tempPtr;
	numNodes--;
	return tempVal;
}

// method to act as .back
int Stack::readTop() const
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
unsigned int Stack::getNumNodes() const
{
	return numNodes;
}

//clear stack method using pop
void Stack::clearStack()
{
	while (top != nullptr)
	{
		pop();
	}
}

//Reverse Display
void Stack::displayNodeReverse(ostream& outStream, Node* start) const
{
	if (start->getNext() != nullptr)
	{
		displayNodeReverse(outStream, start->getNext());
	}
	outStream << *start << " "; // << endl;
}

//Overload 2 with recursion
ostream& operator <<(ostream& outStream, const Stack& stack)
{
	if (stack.top != nullptr)
	{
		stack.displayNodeReverse(outStream, stack.top);
	}
	return(outStream);

}

//Copy constructor
Stack::Stack(const Stack& other)
{
	top = nullptr;
	numNodes = 0;
	copyNodes(other.top);
}

//Copy helper method
void Stack::copyNodes(const Node* current)
{
	if (current != nullptr)
	{
		copyNodes(current->getNext());
		push(current->getPayload());
	}
}

//copy =operator overload
const Stack& Stack:: operator =(const Stack& from)
{
	if (this != &from)
	{
		this->clearStack();
		this->copyNodes(from.top);

	}
	return (*this);
}

//==operator overload
bool Stack::operator==(const Stack& rhs) const
{
	
	bool retval = true;						//Start with return value equal to true	
	if (numNodes == rhs.numNodes) {			//compare the number of nodes in both the left and right stack
		Node* currentLHS = top;				//create pointer for current left hand stack position
		Node* currentRHS = rhs.top;			//create pointer for current right hand stack position

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
Stack::~Stack()
{
	clearStack();
}

*/
