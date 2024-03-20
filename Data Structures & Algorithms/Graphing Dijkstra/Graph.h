#pragma once
#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#include <iostream>
#include <list>

using namespace std;


typedef pair<int, int> intPair;

class Graph
{
private:

	int Vertex; //#of verts
	list< pair<int, int>> *adjacenyList; //list of integers vertex and weight

public:
	Graph(int vert); //constructor
	void addEdge(int fromVert, int toVert, int weight);
	void shortestPath(int source, int destination);
	
};

