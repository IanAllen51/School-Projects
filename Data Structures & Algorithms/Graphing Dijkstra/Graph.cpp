#include "Graph.h"
#include <vector>
#include <queue>
#include <map>

#define INF 0x3f3f3f3f
using namespace std;


Graph::Graph(int vert)
{
    this->Vertex = vert;
    adjacenyList = new list<intPair>[vert];
}

void Graph::addEdge(int fromVert, int toVert, int weight)
{
    adjacenyList[fromVert].push_back(make_pair(toVert, weight));
    adjacenyList[toVert].push_back(make_pair(fromVert, weight));
}

void Graph::shortestPath(int source, int destination) 
{
   
    priority_queue< intPair, vector <intPair>, greater<intPair> > pq;
    vector<int> distance(Vertex, INF);
    
    //create map to store pathway in vectors
    map<int, vector<int>>path;

    //initialize map to source
    for (int i = 0; i < 18; i++)
    {
        path[i] = { source };
    }
    for (int i = 20; i < Vertex; i++)
    {
        path[i] = { source };
    }


    pq.push(make_pair(0, source));
    distance[source] = 0;
  

    while (!pq.empty())
    {
       
        int minWt = pq.top().second;
        pq.pop();

        
        list< pair<int, int> >::iterator i;
        for (i = adjacenyList[minWt].begin(); i != adjacenyList[minWt].end(); ++i)
        {
            int v = (*i).first;
            int weight = (*i).second;

            //  If there is shorted path to v through u. 
            if (distance[v] > distance[minWt] + weight)
            {
                // Updating distance of v 
                distance[v] = distance[minWt] + weight;
                pq.push(make_pair(distance[v], v));

                vector<int> P;
                for (int i = 0; i < path[minWt].size(); i++)
                {
                    P.push_back(path[minWt][i]);
                }
                
                P.push_back(v);
                path[v] = P;
              
            }
        }
    } 
  
    cout << "The shortest distance from " << source << " to " << destination << " is: " << distance[destination] << endl;
    
    cout << "The shortest path from " << source << " to " << destination << " is: ";
    for (int i = 0; i < path[destination].size(); i++)
    {
        cout << path[destination][i] << " ";
    }
    cout << endl << endl;
    

    // Print shortest distances stored in dist[] 
    printf("Vertex   Distance from Source\n");
    for (int i = 0; i < 18; i++) 
    {
        printf("%d \t\t %d\n", i, distance[i]);
    }
    for (int i = 20; i < Vertex; i++) 
    {
        printf("%d \t\t %d\n", i, distance[i]);
    }
    
    cout << endl << endl;
   
}
