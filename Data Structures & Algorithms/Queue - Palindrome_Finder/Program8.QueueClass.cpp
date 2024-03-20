// Program8.QueueClass.cpp : This file contains the 'main' function. Program execution begins and ends there.
// Created by Ian Allen

#include <iostream>
#include "Queue.h"
#include "Stack.h"

using namespace std;

bool isPalindrome(const string word);

int main()
{
	{
		const unsigned int numElements = 5;
		Queue<int> queue0;

		try
		{
			queue0.dequeue();
		}
		catch (exception& e)
		{
			cerr << "Caught: " << e.what() << endl;
			cerr << "Type: " << typeid(e).name() << endl;
		}

		Queue<int> queue1(queue0);
		for (int i = 0; i < numElements; i++)
		{
			queue1.enqueue(i);
		}

		cout << boolalpha << "Queue1: " << queue1 << " is empty? " << queue1.isEmpty()
			<< "right # of elements? " << (queue1.getNumNodes() == numElements) << endl;
		queue1 = queue1;
		cout << "queue1: " << queue1 << endl;

		{//test the copy constructor and == operator
			Queue<int> queue2(queue1);
			cout << "queue2: " << queue2 << ", is queue1 == queue2? " << (queue1 == queue2) << endl;
		}

		{//test the queue destructor and = operator
			Queue<int> queue3;
			queue3.enqueue(10); queue3.enqueue(11);
			cout << "queue3: " << queue3 << ", is queue1 == queue3? " << (queue1 == queue3) << endl;
			queue3 = queue1;
			cout << "queue3: " << queue3 << ", is queue1 == queue3? " << (queue1 == queue3) << endl;

		}

		//test the queue destructor. Final confirmation that queue1 is whole
		cout << "queue1: " << queue1 << endl;

		{//verify the dequeue order
			for (unsigned int i = 0; i < numElements; i++)
			{
				int temp = queue1.dequeue();
				if (temp != i)
				{
					cout << "Dequeue Error!" << endl;
				}
			}

		}

		//queue1 should now be empty
		cout << "queue1: " << queue1 << " is empty? " << queue1.isEmpty() << ", right # of elements? "
			<< (queue1.getNumNodes() == 0) << endl;
		//verify queue works with the string class
		Queue<string> queue4;
		queue4.enqueue("This"); queue4.enqueue(" is"); queue4.enqueue(" a"); queue4.enqueue(" test.");
		cout << "queue4: " << queue4 << endl << endl;
	}

	// run Palindrone method
	bool answer = isPalindrome("madam");
	cout << "Is madam a Palindrome?: " << answer << endl;
	bool answer2 = isPalindrome("wrong");
	cout << "Is wrong a Palindrome?: " << answer2 << endl;

	system("pause");
	return(0);
}

bool isPalindrome(const string word) {
	Stack<char> stack;
	Queue<char> queue;
	unsigned int i = 0;
	bool retVal = true;
	for (i = 0; i < word.size(); i++) // Load the word into a stack and a queue 
	{
		stack.push(word[i]);
		queue.enqueue(word[i]);
	}
	i = 0;
	while (i++ < word.size() && retVal)  // pop/dequeue one letter at a time, if different not a palindrome!
	{ 
		if (stack.pop() != queue.dequeue())
		{ 
			retVal = false; 
		} 
	}
	return(retVal);
}