// HanoiTemplate.cpp : This file contains the 'main' function. Program execution begins and ends there.
//Created by Ian Allen
//
//CS132 Program #6
//Program will use templates to run the previous program #5 with an equality operator overload included.


#include <iostream>
#include <iomanip>
#include <cassert>
#include "Peg.h"

using namespace std;

//functions needed for Hanoi
int hanoi(int n, Peg& start, Peg& end, Peg& temp);
void moveDisk(Peg& from, Peg& to);

//Constant Number of Disks
const int NUM_DISK(7);

int main()
{

	//Test//
	{
		Stack<int> stack1, stack2;
		stack1.push(1); stack1.push(2); stack1.push(3); stack1.push(4);
		stack2.push(10); stack2.push(11); stack2.push(12); stack2.push(13);
		cout << boolalpha << "Before copy, stack1 == stack2? " << (stack1 == stack2) << endl;
		stack1 = stack2;
		cout << "After copy, is stack1 == stack2? " << (stack1 == stack2) << endl;
		Stack<string> stack3;
		stack3.push("This "); stack3.push(" is"); stack3.push(" a"); stack3.push(" test.");
		cout << "stack3: " << stack3 << endl << endl << endl;

	}

	// Initialize variables
	Peg peg1("Peg1", NUM_DISK), peg2("Peg2", 0), peg3("Peg3", 0);

	//variables to run and display hanoi() results
	int n = NUM_DISK;
	int total(0);

	//Greeting
	cout << "Welcom to Ian's Tower of Hanoi simulator." << endl << endl;

	// display three pegs
	cout << "Starting condition of the three pegs: " << endl << endl;

	cout << peg1;
	cout << endl;
	cout << peg2;
	cout << endl;
	cout << peg3;
	cout << endl << endl;


	////run hanoi function and display step by step
	cout << "Step By Step Moves:" << endl << endl;
	total = hanoi(n, peg1, peg3, peg2);
	cout << endl;

	////display the three pegs after recursion
	cout << "Ending condition of the three pegs: " << endl << endl;

	cout << peg1;
	cout << endl;
	cout << peg2;
	cout << endl;
	cout << peg3;
	cout << endl << endl;

	////display count of moves during hanoi()
	cout << "A stack of " << NUM_DISK << " disks can be moved in " << total << " moves." << endl << endl;

	//closing statement
	cout << "Thank you for using Ian's Tower of Hanoi simulator!" << endl;

	system("pause");
	return 0;
}



//hanoi function requiring n number of disks and three Peg variables
int hanoi(int n, Peg& start, Peg& end, Peg& temp) {
	int counter = 0;
	if (n > 0) {
		counter = hanoi(n - 1, start, temp, end);
		cout << setw(16) << right << "Move disk " << start.topDisk() << " from " << start.getName() << " to " << end.getName() << "." << endl;	//implement static cast to return alpha
		moveDisk(start, end);
		counter++;
		counter += hanoi(n - 1, temp, end, start);
	}

	return counter;
}

//Move Disk function. "from" peg to "to" peg
void moveDisk(Peg& from, Peg& to) {
	assert(from.pegSize() > 0);
	if (from.pegSize() > 0 && to.pegSize() > 0) {
		assert(from.topDisk() < to.topDisk());
	}

	int disk = from.topDisk();
	to.addDisk(disk);
	from.removeDisk();
}