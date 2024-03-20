#pragma once
// peg.h, by Ian Allen
#include "Stack.h"
#include <string>
using namespace std;

class Peg
{
private:
	Stack<char> diskNum;
	string pegName;
	void loadDisks(int numDisks); // Private to check user from being stupid

public:

	Peg(string newName, int numDisks); // peg constructor
	~Peg(); // peg destructor
	string getName() const; // Accessor for name
	void setName(string newName); // Mutator for name
	int pegSize() const; // Accessor for peg size
	char topDisk() const; // Accessor acting as .back()
	void addDisk(char disk); // Mutator to push disk
	void removeDisk(); // Mutator to pop disk
	friend ostream& operator <<(ostream& outStream, const Peg& peg); // method to display peg as a method
};

