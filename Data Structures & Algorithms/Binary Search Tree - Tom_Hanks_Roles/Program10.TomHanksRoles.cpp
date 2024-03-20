// Program10.TomHanksRoles.cpp : This file contains the 'main' function. Program execution begins and ends there.
// created by Ian Allen
// CS 132

#include <istream>
#include <ostream>
#include <iostream>
#include <fstream>
#include "BSTree.h"
#include "TomHanksRoles.h"
using namespace std;


int main()
{
	ifstream input;
	TomHanksRoles tomHanksRole;
	BSTree<string,TomHanksRoles> tree;
	input.open("TomHanksMovieRoles.txt");
	assert(!input.fail());

	do
	{

		input >> tomHanksRole;
		tree.insert(tomHanksRole.getTitle(), tomHanksRole);
	} while (!input.eof());

	cout << boolalpha << "Is Splash in Tree?: " << tree.find("Splash", tomHanksRole) <<  endl;
	cout << "How many counts to find answer?: " << tree.getCount() << endl;
	cout << "Is Toy Story 99 in Tree?: " << tree.find("Toy Story 99", tomHanksRole) << endl;
	cout << "How many reads to find answer?: " << tree.getCount() << endl << endl;

	cout << "In order list of Tom Hanks Movies:" << endl;
	cout << "----------------------------------------------" << endl;
	cout << tree;
  
	input.close();

	system("pause");
	return 0;
}

