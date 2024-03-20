// Program11.MergeSort.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <ctime>

using namespace std;

//global constant
const int NUM_INTS(250000);

//global function declaration
void displayArray(string name, int array[], int numElements);
static void mergeSort(int array[], int numElements, int startPosition);
static void merge(int array[], int numElements, int startPosition);


int main()
{
    //initialize variables
	int array[NUM_INTS];
	srand(static_cast<unsigned int> (time(0)));

	cout << "Sorting int array of " << NUM_INTS << " elements." << endl;

	// load random numbers into the array
	for (int i = 0; i < NUM_INTS; i++)
	{
		array[i] = rand();
	}

	displayArray("Before: ", array, NUM_INTS);

	//start timing here
	time_t startTime = clock();
	mergeSort(array, NUM_INTS, 0);
	time_t endTime = clock();
	//end timing here

	displayArray("After: ", array, NUM_INTS);

	//display the total time taken
	cout << "Sort took " << endTime - startTime << " ticks" << endl;

	system("pause");
	return 0;



}

//functions

void displayArray(string name, int array[], int numElements)
{
	cout << name;
	for (int i = 0; i < numElements; i++)
	{
		cout << array[i];
		if (i < numElements - 1)
		{
			cout << ", ";
		}
	}
	cout << endl;
}


void mergeSort(int array[], int numElements, int startPosition)
{
	if (1 < numElements)
	{
		int mid = numElements / 2;
		int hi = numElements - mid;

		mergeSort(array, mid, startPosition);
		mergeSort(array, hi, mid + startPosition);
		merge(array, numElements, startPosition);
	}
}


void merge(int array[], int numElements, int startPosition)
{
	// initialize variables
	int mid = numElements / 2;
	int hi = numElements - mid;
	int i, j, k;
	int* tempLeft = new int[mid];
	int* tempRight = new int[hi];

	//fill temp array
	for (i = 0; i < mid; i++)
	{
		tempLeft[i] = array[startPosition];
	}

	for (j = 0; j < hi; j++)
	{
		tempRight[j] = array[mid + j + startPosition];
	}

	i = 0;
	j = 0;
	k = startPosition;

	while (i < mid && j < hi)  
	{
		if (tempLeft[i] <= tempRight[j])
		{
			array[k] = tempLeft[i];
			i++;
			k++;
		}
		else
		{
			array[k] = tempRight[j];
			j++;
			k++;
		}
	}

	while (i < mid)
	{
		array[k] = tempLeft[i];
		i++;
		k++;
	}

	while (j < hi)
	{
		array[k] = tempRight[j];
		j++;
		k++;
	}

	delete[] tempLeft;
	delete[] tempRight;

}


