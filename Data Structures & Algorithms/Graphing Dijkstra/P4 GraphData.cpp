// P4 GraphData.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
//Ian Allen
//CS 233
//Project 4: Graph Data
//
//Description: Program 4 will call for user to input nodes to be graphed using
//the addEdge method which will require a fromNode, a toNode, and the weight of the
//edge. The shortestPath method will call for the user to input a starting destination
//and a target destination. The method will use a priority queue to determine the
//smallest weight as it cycles between nodes, updating the shortest combined path. Using
//a map of int and vector of ints, as the priority queue cycles to empty, it will update
//a vector with the additional shortest path vertex; creating a vertex path representing
//the shortest distance. Both the distance and the pathway will be outputed. In addition,
//the total distance from the source to each vertex will be displayed for each call of the 
//shortest path.


#include <iostream>
#include "Graph.h"

int main()
{
    int V = 38;
    Graph graph(V);
   
    graph.addEdge(0, 1, 8);
    graph.addEdge(0, 2, 8);
    graph.addEdge(0, 7, 4);
    graph.addEdge(0, 14, 4);
    graph.addEdge(0, 20, 8);
    graph.addEdge(1, 5, 8);
    graph.addEdge(2, 3, 5);
    graph.addEdge(2, 6, 2);
    graph.addEdge(3, 17, 1);
    graph.addEdge(4, 5, 7);
    graph.addEdge(4, 7, 3);
    graph.addEdge(4, 8, 5);
    graph.addEdge(5, 6, 8);
    graph.addEdge(5, 8, 1);
    graph.addEdge(5, 25, 6);
    graph.addEdge(7, 11, 1);
    graph.addEdge(8, 11, 8);
    graph.addEdge(8, 12, 7);
    graph.addEdge(9, 10, 6);
    graph.addEdge(9, 12, 9);
    graph.addEdge(9, 13, 3);
    graph.addEdge(10, 13, 5);
    graph.addEdge(10, 17, 2);
    graph.addEdge(10, 30, 4);
    graph.addEdge(11, 12, 2);
    graph.addEdge(11, 14, 6);
    graph.addEdge(12, 13, 2);
    graph.addEdge(12, 15, 8);
    graph.addEdge(12, 16, 6);
    graph.addEdge(13, 17, 9);
    graph.addEdge(15, 35, 7);
    graph.addEdge(16, 17, 1);
    graph.addEdge(20, 21, 1);
    graph.addEdge(20, 24, 3);
    graph.addEdge(20, 27, 5);
    graph.addEdge(20, 34, 1);
    graph.addEdge(21, 24, 1);
    graph.addEdge(22, 23, 8);
    graph.addEdge(22, 25, 1);
    graph.addEdge(22, 26, 8);
    graph.addEdge(23, 26, 2);
    graph.addEdge(23, 37, 2);
    graph.addEdge(24, 27, 2);
    graph.addEdge(24, 28, 6);
    graph.addEdge(25, 26, 7);
    graph.addEdge(25, 28, 1);
    graph.addEdge(25, 29, 6);
    graph.addEdge(26, 29, 9);
    graph.addEdge(26, 30, 5);
    graph.addEdge(27, 28, 5);
    graph.addEdge(27, 34, 7);
    graph.addEdge(28, 31, 5);
    graph.addEdge(28, 32, 1);
    graph.addEdge(29, 30, 1);
    graph.addEdge(29, 33, 5);
    graph.addEdge(30, 37, 4);
    graph.addEdge(31, 32, 4);
    graph.addEdge(31, 34, 3);
    graph.addEdge(31, 35, 9);
    graph.addEdge(32, 33, 4);
    graph.addEdge(32, 36, 1);
    graph.addEdge(33, 36, 7);
    graph.addEdge(35, 36, 4);
    graph.addEdge(35, 37, 1);
  
    graph.shortestPath(1, 37);
    graph.shortestPath(14, 23);

    system("pause");
    return 0;

/*
//OUTPUT//------------------------------------------------------------------------------

The shortest distance from 1 to 37 is: 22
The shortest path from 1 to 37 is : 1 5 25 28 32 36 35 37

Vertex   Distance from Source
0                8
1                0
2                16
3                21
4                14
5                8
6                16
7                12
8                9
9                20
10               22
11               13
12               15
13               17
14               12
15               23
16               21
17               22
20               16
21               17
22               15
23               23
24               18
25               14
26               21
27               20
28               15
29               20
30               21
31               20
32               16
33               20
34               17
35               21
36               17
37               22


The shortest distance from 14 to 23 is: 25
The shortest path from 14 to 23 is : 14 11 12 13 10 30 37 23

Vertex   Distance from Source
0                4
1                12
2                12
3                16
4                10
5                15
6                14
7                7
8                14
9                13
10               15
11               6
12               8
13               10
14               0
15               16
16               14
17               15
20               12
21               13
22               22
23               25
24               14
25               21
26               24
27               16
28               20
29               20
30               19
31               16
32               20
33               24
34               13
35               23
36               21
37               23
*/

}





