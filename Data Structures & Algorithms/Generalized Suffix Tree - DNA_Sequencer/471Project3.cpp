// 471Project3.cpp : This file contains the 'main' function. Program execution begins and ends there.
//


/*
TASK1:
    1. create SuffixNode class utilizing the bones of project 2
    2. create GST class utilizing the bones of SuffixTree class
        -> use naiveSuffixTree to build
    3. update SuffixNode to include label vector of tuple (x,y)
        -> create getter/setter for label
    4. modify find to be able to compare leaf nodes and add tuple label if needed
    5. update fasta collector to take an array of fasta files and output an array of strings$
    6. get gst working with simple toy strings.
    7. create destructor class for GST to remove nodes when program finishes
    8. create colorLabeling function in GST
        ->need to modify SuffixNode to include new color label. ->getters and setters
    9. implement fingerprint function in GST
    10. implement display function to print of each string and related fingerprint info (see pdf for example)
*/


#include <iostream>
#include <iomanip>
#include "GenSuffixTree.h"
using namespace std;

int main()
{

    vector<string> fastaFiles;
 
    fastaFiles.push_back("Covid_Wuhan.fasta");
    fastaFiles.push_back("Covid_USA-CA4.fasta");
    fastaFiles.push_back("Covid_Australia.fasta");
    fastaFiles.push_back("Covid_India.fasta");
    fastaFiles.push_back("Covid_Brazil.fasta");
    fastaFiles.push_back("SARS_2003_GU553363.fasta");
    fastaFiles.push_back("SARS_2017_MK062179.fasta");
    fastaFiles.push_back("MERS_2012_KF600620.fasta");
    fastaFiles.push_back("MERS_2014_KY581694.fasta");
    fastaFiles.push_back("MERS_2014_USA_KP223131.fasta");
    
    //TASK 1
    GenSuffixTree *tree = new GenSuffixTree(fastaFiles);
    tree->fingerprintGST();
    tree->clearGST();

    vector<string> S = { fastaFiles[1], fastaFiles[2] };
 
    int compVal;

    
    
    //TASK 2
    vector<string> similarityS;
    clock_t similarityStart = clock();
    for (int i = 0; i < S.size(); i++) { //changed fastaFiles to S
        for (int j = i + 1; j < S.size(); j++) {
            similarityS.clear();
            similarityS.push_back(S[i]);//fastaFiles
            similarityS.push_back(S[j]);
            
            GenSuffixTree* simTree = new GenSuffixTree(similarityS);
            clock_t matrixStart = clock();
            compVal = simTree->computeSimilarity();
            clock_t matrixEnd = clock();

            double totalMatrix = double(matrixEnd - matrixStart);
            cout << "BuildTime:" << totalMatrix << endl;

            cout << "(" << i + 1 << "," << j + 1 << ") - " << compVal << " ";
            simTree->clearGST();
        }
        cout << endl;
    }
    clock_t similarityEnd = clock();
    double totalSimTime = double(similarityEnd - similarityStart);
    cout << "Total tree build: " << totalSimTime << " ticks" << endl;
    
    
    
}

