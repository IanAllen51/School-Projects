#pragma once
#include "Node.h"
#include <ostream>
#define NDEBUG
#include <cassert>
#include <exception>

using namespace std;

template <class P>
class Queue
{
private:
	Node<P>* front;
	Node<P>* rear;
	int numNodes;

public:

	//Queue constructor
	Queue()
	{
		front = nullptr;
		rear = nullptr;
		numNodes = 0;
	}

	//is empty method
	bool isEmpty()
	{
		return(front == nullptr);
	}


	//front method (readTop in Stack)
	P getFront() const
	{
		assert(front != nullptr);

		//exception
		if (front == nullptr)
		{
			throw runtime_error("Illegal Read");
		}

		return front->getPayload();
	}



	// method to display node count
	unsigned int getNumNodes() const
	{
		return numNodes;
	}


	//enqueue method (push) path1
	void enqueue(const P& newElement) // change Queue& to P&
	{
		Node<P>* newNode;
		newNode = new Node<P>(newElement, nullptr);

		if (front == nullptr)
		{
			front = newNode;
			rear = newNode;
		}
		else
		{
			rear->setNext(newNode); //get to set (rear->getNext() = newNode;
			rear = rear->getNext();
		}
		numNodes++;

	}


	//dequeue method (pop)
	P dequeue()
	{
		assert(front != nullptr);

		//exception
		if (front == nullptr)
		{
			throw runtime_error("Illegal Pop");
		}

		P tempVal = front->getPayload();
		Node<P>* tempPtr = front->getNext();
		delete front;
		front = tempPtr;
		numNodes--;

		if (front == nullptr)
		{
			rear = nullptr;
		}
		return tempVal;
	}

	//clear Queue method using pop
	void clearQueue()
	{
		while (front != nullptr)
		{
			dequeue();
		}
	}

	//Copy constructor
	Queue(const Queue& other) //<P>
	{
		front = nullptr;
		rear = nullptr;
		numNodes = 0;
		copyNodes(other);
	}


	//copy helper method (nonrecursive)
	void copyNodes(const Queue& fromQueue)
	{
		assert(front == nullptr);
		if (fromQueue.front != nullptr)
		{
			Node<P>* fromPtr = fromQueue.front;
			Node<P>* toPtr = this->front = new Node<P>(fromPtr->getPayload(), nullptr); //copy first node
			numNodes = 1;
			while (fromPtr->getNext() != nullptr)
			{
				fromPtr = fromPtr->getNext();
				toPtr->setNext(new Node<P>(fromPtr->getPayload(), nullptr));
				numNodes++;
				toPtr = toPtr->getNext();
			}
		}
	}




	//copy =operator overload
	const Queue& operator =(const Queue& from)
	{
		if (this != &from)
		{
			this->clearQueue();
			this->copyNodes(from); //front

		}
		return (*this);
	}

	//==operator overload
	bool operator==(const Queue& rhs) const
	{

		bool retval = true;						//Start with return value equal to true	
		if (numNodes == rhs.numNodes) {			//compare the number of nodes in both the left and right stack
			Node<P>* currentLHS = front;		//create pointer for current left hand stack position
			Node<P>* currentRHS = rhs.front;	//create pointer for current right hand stack position

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

	//Overload << with recursion
	friend ostream& operator <<(ostream& outStream, const Queue& queue)
	{

		if (queue.front != nullptr)
		{
			queue.printQueue(outStream, queue.front);
		}

		return(outStream);

	}


	//display queue method.
	void printQueue(ostream& outStream, Node<P>* current) const
	{
		current = front;
		while (current != nullptr)
		{
			outStream << current->getPayload() << " ";
			current = current->getNext();
		}
	}

	//Destructor
	~Queue()
	{
		clearQueue();
	}

};


