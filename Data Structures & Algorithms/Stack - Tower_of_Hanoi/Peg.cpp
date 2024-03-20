//Peg.cpp by Ian Allen
#include "Peg.h"
#include <ostream>
#include <iomanip>
#include <cassert>
using namespace std;

//Upon initialization user must set name and disk value for each peg
Peg::Peg(string newName, int numDisks)  
{
	setName(newName);
	loadDisks(numDisks);
}

//Destructor
Peg::~Peg()
{
	
}

//calling method to display Peg name
string Peg::getName() const
{
	return pegName;
}

//method to use string to rename a Peg
void Peg::setName(string newName)
{
	pegName = newName;
}

//loading method to replace the need for the load function in original code
void Peg::loadDisks(int numDisks)
{
	assert(numDisks >= 0);
	for (int i = numDisks; i > 0; i--) {
		addDisk(i + ('A' - 1));		 //diskNum.push(i + ('A' - 1));
	}
}

//size method
int Peg::pegSize() const
{
	return diskNum.getNumNodes();
}

//back() method
char Peg::topDisk() const
{
	assert(diskNum.getNumNodes() > 0);
	return diskNum.readTop();
}

//push_back() method
void Peg::addDisk(char disk)
{
	diskNum.push(disk);
}

//removeDisk() method
void Peg::removeDisk()
{
	assert(diskNum.getNumNodes() > 0);
	diskNum.pop();
}

//Overload Test (tested and executed)
ostream& operator <<(ostream& outStream, const Peg& peg)
{
	outStream << setw(10) << right << peg.getName() << " has " << peg.pegSize() << " disks: " << peg.diskNum;
	return(outStream);
}

