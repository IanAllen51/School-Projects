#pragma once
#include "SuffixNode.h"
#include <iostream>
#include <map>
#include <fstream>
#include <ctime>
#include <algorithm>
#include <iomanip>
#include <thread>



class GenSuffixTree
{
private:
	SuffixNode* root;
	int leafCount = 0;
	int internalCount = 0;
	int leafID = 0;
	int internalID;
	string fastaString;
	map<char, int> language;
	int totalDepth = 0;
	int deepestInternal = 0;
	
	//ADDED FOR PROJ3
	vector<string> S;
	map<int, string> colors = { {0,"GREEN"}, {1,"YELLOW"}, {2,"BLUE"}, {3,"ORANGE"}, {4,"PURPLE"}, {5,"WHITE"}, {6,"BLACK"}, {7,"GREY"}, {8,"PINK"}, {9,"NAVY"}, {10,"RED"} };
	map<string,int> colorsIND = { {"GREEN",0}, {"YELLOW",1}, {"BLUE",2}, {"ORANGE",3}, {"PURPLE",4}, {"WHITE",5}, {"BLACK",6}, {"GREY",7}, {"PINK",8}, {"NAVY",9}, {"RED",10} };
	vector<tuple<int, SuffixNode*>> minMixedSi;
	vector<tuple<int, SuffixNode*>> maxMixedSi;
	vector<SuffixNode*> nodeCollection;


public:

	//ADDED STRUCT FOR PROJ#
	struct DP_cell {
		int Sscore; // Substitution (S) score
		int Dscore; // Deletion (D) score
		int Iscore; // Insertion (I) score
		int Mscore; // Max of S,D,and I scores. Used to shorten the search
		int matchCount;
	};


	//naive constructor() takes an fasta and alphabent as input
	GenSuffixTree(vector<string> fastaFiles) {
		//build fastaString
		fastaBuilder(fastaFiles);
		//build languague
		buildAlphabet("DNA_alphabet.txt"); 
		this->internalID = getSLength(); //length of all sequences concat
		this->root = new SuffixNode(-1, root, false, "", this->language.size());
		this->root->setParentPointer(this->root);
		buildSiMinMaxVec();

	}


	//initialize min/max Mixed node for all fasta sequences 
	void buildSiMinMaxVec() {
		for (int i = 0; i < 10; i++) {
			this->minMixedSi.push_back(make_tuple(-1, nullptr));
			this->maxMixedSi.push_back(make_tuple(-1, nullptr));
		}
	}

	//General naive construction of GST. Displays execution time within each sequence
	void buildNaiveGST() {
		vector<string> sStrings = this->S;
		cout << "TREE CONSTRUCTION:" << endl;
		clock_t totalStart = clock();
		for (int j = 0; j < sStrings.size(); j++) {
			clock_t start = clock();
			for (int i = 0; i < sStrings[j].length(); i++) { //this->getFasta().length()
				findPath(this->getRoot(), sStrings[j], j, i);
			}
			clock_t end = clock();
			double executionTime = double(end - start);
			cout << "\t S"<< j+1 << ": " << executionTime << " ticks (~" << executionTime/1000 << " seconds)" << endl;
		}
		clock_t totalEnd = clock();
		double totalExTime = double(totalEnd - totalStart);
		cout << endl << "Total_Time: " << totalExTime << " ticks" << endl << endl;
	}
	
	//Function for performing Task2
	int computeSimilarity() {
		string alpha;
		SuffixNode* lcaNode;
		int i_1, i_2, j_1, j_2, a, b, c;
		int match = 1;
		int mismatch = -2;
		int h = -5;
		int g = -1;
		int alignScore;
		a = 0;
		c = 0;
		i_1 = 0;
		j_1 = 0;
		//build tree
		buildNaiveGST();
		//color internal nodes given leaf node color
		colorNodes(this->root);
		lcaNode = returnLCA_Node();
		//build alpha string from LCA Node
		alpha = buildAlphaTraceBack(lcaNode);
		b = lcaNode->getStringDepth();

		//establish i and j starting index in their respective strings
		for (int i = 0; i < lcaNode->getChildren().size(); i++) {
			if (lcaNode->getChildren()[i] != nullptr) {
				if (get<0>(lcaNode->getChildren()[i]->getLeafLabel()[0]) == 0) {
					i_1 = get<1>(lcaNode->getChildren()[i]->getLeafLabel()[0]);
				}
				else {
					j_1 = get<1>(lcaNode->getChildren()[i]->getLeafLabel()[0]);
				}
			}
		}
		//establish end points of LCA for i and j
		i_2 = i_1 + lcaNode->getStringDepth();
		j_2 = j_1 + lcaNode->getStringDepth();
		
		//perform global alignment on the left(A) and right(C) portions of the given strings
		buildAMatrix(a, i_1, j_1, g, h, mismatch, match);
		buildCMatrix(c, i_2, j_2, g, h, mismatch, match);
		alignScore = a + b + c;

		return alignScore;
	}

	void buildAMatrix(int& a, int i1, int j1, int g, int h, int mismatch, int match) {
		//check if string starts at 0. if so, return 0 as there will be no comparisons on an empty string
		if (i1 == 0 || j1 == 0) {
			a = 0;
		}
		else {
			//establish i and j string s from 0 to index -1
			string iRev = this->S[0].substr(0, i1 - 1);
			string jRev = this->S[1].substr(0, j1 - 1);
			string temp = "";

			//reverse i and j
			for (int i = iRev.length() - 1; i >= 0; i--) {
				temp += iRev[i];
			}
			iRev = temp;
			temp = "";
			for (int i = jRev.length() - 1; i >= 0; i--) {
				temp += jRev[i];
			}
			jRev = temp;

			cout << "Beging first matrix" << endl;

			//fill in the "matrix" with the Needleman-Wunsch alg.
			a = fillNW(iRev, jRev, g, h, mismatch, match);
			//
			cout << "End first matrix" << endl;
		}
	}

	void buildCMatrix(int& c, int i2, int j2, int g, int h , int mismatch, int match) {
		//return 0 if a string ends on the last position of the sequence
		if (i2 == this->S[0].length() || j2 == this->S[1].length())
		{
			c = 0;
		}
		else {
			string iEnd = this->S[0].substr(i2 + 1);
			string jEnd = this->S[1].substr(j2 + 1);

			cout << "Begin second matrix" << endl;

			c = fillNW(iEnd, jEnd, g, h, mismatch, match);
			//
			cout << "end second matrix" << endl;
		}
	}

	//Method for executing TASK 1
	void fingerprintGST() {
		buildNaiveGST();
		colorNodes(this->root);
		buildFingerPrint();
	}

	SuffixNode* returnLCA_Node() {
		SuffixNode* lca;
		lca = get<1>(this->maxMixedSi[0]);
		return lca;
	}

	//helper method to clear SuffixNode* from tree after use
	void deleteTreeNodes(SuffixNode* start) {

		for (int i = 0; i < nodeCollection.size(); i++)
		{
			if (nodeCollection[i]->isLeafNode() == true) {
				leafCount--;
			}
			else {
				internalCount--;
			}

			delete nodeCollection[i];
		}

	}

	//delete all nodes in tree
	void clearGST() {
		deleteTreeNodes(this->root);
	}

	//recursive function to color all internal nodes. Red if mixed, Si color if not
	void colorNodes(SuffixNode* root) {
		vector<string> child;

		for (int i = 0; i < root->getChildren().size(); i++) {
			if (root->getChildren()[i] != nullptr) {
				colorNodes(root->getChildren()[i]);
				child.push_back(root->getChildren()[i]->getColorLabel());
			}
		}
		if (!child.empty()) {
			//sort child check if 0 and last are ==, true-> set root color label == to child[0], else set == 10
			sort(child.begin(), child.end());
			if (child.front() != child.back()) {
				root->setColorLabel(colors[10]);

				//update min max for si
				siMinMaxBuilder(root);
			}
			else {
				root->setColorLabel(child.front());
			}
		}
	}

	//helper function to update min/max vectors with alpha string and position of mixed node*
	void siMinMaxBuilder(SuffixNode* current) {
		int alpha = current->getStringDepth();
		string childColor;
		int si;
		for (int i = 0; i < current->getChildren().size(); i++) {
			if (current->getChildren()[i] != nullptr) {
				childColor = current->getChildren()[i]->getColorLabel();
				si = colorsIND[childColor];
				if (si != 10) {
					//set min-----
					//check if tuple is empty
					if (get<0>(minMixedSi[si]) == -1) {
						minMixedSi[si] = make_tuple(alpha, current);
					}
					else {
						if (alpha < get<0>(minMixedSi[si])) {
							minMixedSi[si] = make_tuple(alpha, current);
						}
					}
					//set max
					if (get<0>(maxMixedSi[si]) == -1) {
						maxMixedSi[si] = make_tuple(alpha, current);
					}
					else {
						if (alpha > get<0>(maxMixedSi[si])) {
							maxMixedSi[si] = make_tuple(alpha, current);
						}
					}
				}
			}
		}
	}

	//build alpha string for Task1. traceback from lowest node to root.
	string buildAlphaTraceBack(SuffixNode* node) {
		SuffixNode* current = node;
		string alpha = "";
		while (current != root) {
			alpha = current->getParentEdge() + alpha;
			current = current->getParentPointer();
		}
		return alpha;
	}

	//helper method to build finerprint strings for each sequence
	void buildFingerPrint() {
		string alpha;
		string c;
		SuffixNode* mixedNode;
		string temp;
		vector<double> fp;

		//build out text 
		ofstream myFile;
		myFile.open("proj3_FingerPrints.txt");

		myFile << "   STRING|" << "LENGTH" << "|" << "FINGERPRINT" << setw(16) << endl;
		cout << "   STRING|" << "LENGTH" << "|" << "FINGERPRINT" << setw(16) << endl;
		myFile << setfill('-') << setw(45) << "-" << endl;
		cout << setfill('-') << setw(45) << "-" << endl;


		clock_t startFingerpring = clock();
		for (int i = 0; i < minMixedSi.size(); i++) {
			//set mixedNode = to the SuffixNode* (smallest mixed node for Si)
			mixedNode = get<1>(minMixedSi[i]);
			if (mixedNode != nullptr) {
				clock_t startFP = clock();
				//generate alpha string from mixed node to root
				alpha = buildAlphaTraceBack(mixedNode);
				for (int j = 0; j < mixedNode->getChildren().size(); j++) {
					if (mixedNode->getChildren()[j] != nullptr) {
						//get the parentEdge string for the child with Si color label
						if (mixedNode->getChildren()[j]->getColorLabel() == colors[i]) {
							c = mixedNode->getChildren()[j]->getParentEdge();

							if (mixedNode->getChildren()[j]->isLeafNode() == true) {
								if (c.length() == 1) {
									c = "";
								}
								else {
									c = c[0];
								}
							}
						}

					}
				}
				alpha = alpha + c;
				clock_t endFP = clock();
				double totalFP = double(endFP - startFP);
				fp.push_back(totalFP);

				temp = alpha;

				//Build output strings
				switch (i) {
				case 0:
					cout << "COVID" << setfill(' ') << setw(3);
					myFile << "COVID" << setfill(' ') << setw(3);
					break;
				case 5:
					cout << "SARS" << setfill(' ') << setw(4);
					myFile << "SARS" << setfill(' ') << setw(4);
					break;
				case 7:
					cout << "MERS" << setfill(' ') << setw(4);
					myFile << "MERS" << setfill(' ') << setw(4);
					break;
				case 9:
					cout << setfill(' ') << setw(7);
					myFile << setfill(' ') << setw(7);
					break;
				default:
					cout << setfill(' ') << setw(8);
					myFile << setfill(' ') << setw(8);
				}

				if (alpha.length() > 99) {
					cout << "S" << i + 1 << "|" << alpha.length() << setfill(' ') << setw(4) << "|";
					myFile << "S" << i + 1 << "|" << alpha.length() << setfill(' ') << setw(4) << "|";
				}
				else if (alpha.length() > 9) {
					cout << "S" << i + 1 << "|" << alpha.length() << setfill(' ') << setw(5) << "|";
					myFile << "S" << i + 1 << "|" << alpha.length() << setfill(' ') << setw(5) << "|";
				}
				else {
					cout << "S" << i + 1 << "|" << alpha.length() << setfill(' ') << setw(6) << "|";
					myFile << "S" << i + 1 << "|" << alpha.length() << setfill(' ') << setw(6) << "|";
				}

				while (temp.length() > 0) {
					if (temp.length() > 20) {
						cout << temp.substr(0, 20) << endl;
						myFile << temp.substr(0, 20) << endl;
						temp = temp.substr(20);
						cout << setfill(' ') << setw(10) << "|" << setfill(' ') << setw(7) << "|";
						myFile << setfill(' ') << setw(10) << "|" << setfill(' ') << setw(7) << "|";
					}
					else {
						cout << temp << endl;
						myFile << temp << endl;
						temp = "";
					}
				}
			}

		}
		clock_t endFingerprinting = clock();
		double totalFingerprint = double(endFingerprinting - startFingerpring);

		cout << endl << endl;
		myFile << endl << endl;
		
		//Display fingerprint info to txt file and consol.
		cout << "FINGER PRINT CREATION:" << endl;
		myFile << "FINGER PRINT CREATION:" << endl;

		for (int i = 0; i < fp.size(); i++) {
			cout << "\t S" << i + 1 << ": " << fp[i] << " ticks (~" << fp[i] / 1000 << " seconds)" << endl;
			myFile << "\t S" << i + 1 << ": " << fp[i] << " ticks (~" << fp[i] / 1000 << " seconds)" << endl;
		}
		cout << "TOTAL FINGERPRINTING TIME: " << totalFingerprint << " ticks (~" << totalFingerprint / 1000 << " seconds)" << endl << endl;
		myFile << "TOTAL FINGERPRINTING TIME: " << totalFingerprint << " ticks (~" << totalFingerprint / 1000 << " seconds)" << endl << endl;
	}


	//Needleman-Wunsch alg.
	int fillNW(string s1, string s2, int gap, int h, int mismatch, int match) {
		int gapCell = max(s1.size(), s2.size()) * 2 * gap; // negative value for i and j == 0 cells. *ran into issues with using negative infinity as value.
		int matchScore = 0;
		int maxScore = 0;
		vector<DP_cell> currentLine;
		vector<DP_cell> oldLine;

		for (int j = 0; j < s2.size(); j++) {
			/*if (j % 10 == 0) {
				cout << "PING ";
			}*/
			currentLine.clear();
			currentLine.resize(s1.length());

			for (int i = 0; i < s1.size(); i++) {
				if (i == 0 && j == 0) {

					currentLine[i].Dscore = 0;
					currentLine[i].Iscore = 0;
					currentLine[i].Sscore = 0;
					currentLine[i].Mscore = max({ currentLine[i].Dscore, currentLine[i].Iscore, currentLine[i].Sscore });
					currentLine[i].matchCount = 0;
				}
				else if (i == 0) {

					currentLine[i].Dscore = gapCell;
					currentLine[i].Sscore = gapCell;
					currentLine[i].Iscore = j * gap + h;
					currentLine[i].Mscore = max({ currentLine[i].Sscore, currentLine[i].Dscore, currentLine[i].Iscore });
					currentLine[i].matchCount = 0;
				}
				else if (j == 0) {

					currentLine[i].Dscore = i * gap + h;
					currentLine[i].Sscore = gapCell;
					currentLine[i].Iscore = gapCell;
					currentLine[i].Mscore = max({ currentLine[i].Sscore, currentLine[i].Dscore, currentLine[i].Iscore });
					currentLine[i].matchCount = 0;

				}
				else {
					TNW(currentLine, oldLine, s1, s2, i, j, match, mismatch, gap, h, maxScore, matchScore); //recursive call seen below
				}
			}
			oldLine = currentLine;
		}
		return matchScore;
	}

	//Check both strings and compare matches/mismatches at each position i and j
	int checkS(string s1, string s2, int i, int j, int ma, int mi) {
		if (s1[i] == s2[j]) {
			return ma;
		}
		else {
			return mi;
		}
	}

	//Needleman-Wunsch recursive function.
	void TNW(vector<DP_cell> currentLine, vector<DP_cell> oldLine, string s1, string s2, int i, int j, int ma, int mi, int gap, int h, int& maxScore, int& matchScore) {

		//each score will be the max of the three values in previous cell. Direction based on score type

		currentLine[i].Sscore = max({ oldLine[i - 1].Sscore, oldLine[i - 1].Dscore, oldLine[i - 1].Iscore }) + checkS(s1, s2, i, j, ma, mi);
		currentLine[i].Iscore = max({ (oldLine[i].Sscore + h + gap),(oldLine[i].Dscore + h + gap), (oldLine[i].Iscore + gap) });
		currentLine[i].Dscore = max({ (currentLine[i - 1].Sscore + h + gap),(currentLine[i - 1].Dscore + gap),(currentLine[i - 1].Iscore + h + gap) });
		currentLine[i].Mscore = max({ (currentLine[i].Sscore),(currentLine[i].Dscore),(currentLine[i].Iscore) });

		if (currentLine[i].Mscore == currentLine[i].Sscore) {
			currentLine[i].matchCount = oldLine[i - 1].matchCount;
			if (checkS(s1, s2, i, j, ma, mi) == ma) {
				currentLine[i].matchCount++;
			}
		}
		else if (currentLine[i].Mscore == currentLine[i].Iscore) {
			currentLine[i].matchCount = oldLine[i].matchCount;
		}
		else if (currentLine[i].Mscore == currentLine[i].Dscore) {
			currentLine[i].matchCount = currentLine[i - 1].matchCount;
		}

		if (currentLine[i].Mscore > maxScore) {
			maxScore = currentLine[i].Mscore;
			matchScore = currentLine[i].matchCount;
		}

	}

	//string builder()
	void fastaBuilder(vector<string> fasta) {
		string temp;
		for (int i = 0; i < fasta.size(); i++) {
			temp = "";
			ifstream fastaFile(fasta[i]);//"s1.fas"
			string fastaLine;
			if (fastaFile.is_open()) {
				while (fastaFile) {
					getline(fastaFile, fastaLine);
					if (fastaLine[0] != '>') {
						//this->fastaString += fastaLine;
						temp += fastaLine;
					}

				}
			}
			else {
				cout << "Error opening FASTA file." << endl;
				exit(1);
			}
			//this->fastaString += '$';
			temp += '$';
			this->S.push_back(temp);
		}
			
	}

	void printS() {
		for (int i = 0; i < this->S.size(); i++) {
			cout << "String " << i << ": " << this->S[i] << endl;
		}
	}

	void buildAlphabet(string alphabet) {
		this->language['$'] = 0; //assign lowest value ($) to zero.
		char c;
		int langMapCounter = 1; //simple counter to assign value to char key in map<>


		ifstream line(alphabet); //"English_alphabet.txt"
		while (line.get(c)) { // need to account for white space -- ASCII 32, return -- ASCII 10, or possible $ -- ASCII 36
			if (int(c) != 32 && int(c) != 36 && int(c) != 10) {

				try {
					buildLangMap(this->language, c, langMapCounter);;
				}
				catch (const char* msg) {
					cerr << msg << endl;
				}
			}
		}
		line.close();
	}

	//alphabet helper function
	void buildLangMap(map<char, int>& lang, char c, int& counter) {
		if (int(c) < 65 || int(c) > 90) {
			throw "Invalid Language Character";
		}
		else {
			lang[c] = counter;
			counter++;
		}
	}

	SuffixNode* findPath(SuffixNode* u, string fastaString, int stringNum, int index) {
		//initialize
		SuffixNode* v = u;
		string x = fastaString.substr(index);
		SuffixNode* current = NULL;
		string edge = "";
		SuffixNode* createdLeaf = NULL;

		//--REPEAT
		while (true) {
			//find child branch with x[0]
			//if no branch is found, insert new leaf
			if (v->getChildren()[this->language[x[0]]] == nullptr) { 
				//insert new leaf node
				createdLeaf = insertLeafNode(v, x, stringNum, index);

				return createdLeaf;
			}
			else {
				//select child of v starting with x[0]
				current = v->getChildren()[this->language[x[0]]];
				edge = current->getParentEdge();
				
				if (current->isLeafNode() == true && x == edge) {
					current->setLeafLabel(stringNum, index);
					if (current->getColorLabel() != this->colors[10]) {
						current->setColorLabel(this->colors[10]);
					}

					return current;
				}

				//compare characters of edge label against x[1..] until first mismatch OR edgelabel exhausted
				for (int i = 0; i < edge.length(); i++) { //edge.length()
					//if mismatch- break edge, create new internal node, create new leaf for s under that node, return
					if (x[i] != edge[i]) {
						//create internal node
						SuffixNode* temp = insertInternalNode(v, edge, i);
						//create leaf node from new internal node
						createdLeaf = insertLeafNode(temp, x.substr(i), stringNum, index);

						return createdLeaf;
					}
				}
				//edge lable has been exhausted, set v to next internal node, update x
				v = current;
				//x = fastaString.substr(index + edge.length());
				x = x.substr(edge.length());
			}
		}
	}

	//modifying to return leafnode
	SuffixNode* insertLeafNode(SuffixNode* startingNode, string x, int stringNum, int index) {
		SuffixNode* leafNode = new SuffixNode(this->getLeafID(), startingNode, true, x, this->language.size());
		startingNode->setChildNode(leafNode, this->language[x[0]]);
		
		leafNode->setLeafLabel(stringNum, index);
		leafNode->setColorLabel(colors[stringNum]);
		
		this->nodeCollection.push_back(leafNode);

		this->leafCount++;
		this->leafID++;
		return leafNode;
	}

	SuffixNode* insertInternalNode(SuffixNode* parent, string edge, int i) {
		SuffixNode* currentNode = parent->getChildren()[this->language[edge[0]]];
		SuffixNode* internalNode = new SuffixNode(getInternalID(), parent, false, edge.substr(0, i), this->language.size());
		this->internalCount++;
		this->internalID++;

		this->totalDepth += internalNode->getStringDepth();
		if (internalNode->getStringDepth() > this->deepestInternal)
		{
			setDeepestInternal(internalNode->getStringDepth());
		}

		currentNode->setParentPointer(internalNode);
		currentNode->setParentEdge(edge.substr(i));

		parent->setChildNode(internalNode, this->language[edge[0]]);
		internalNode->setChildNode(currentNode, this->language[edge.substr(i)[0]]);
		this->nodeCollection.push_back(internalNode);
		return internalNode;
	}

	SuffixNode* getRoot() {
		return this->root;
	}

	int getLeafCount() {
		return this->leafCount;
	}

	int getInternalCount() {
		return this->internalCount; //- getFasta().length()
	}

	int getLeafID() {
		return this->leafID;
	}

	int getInternalID() {
		return this->internalID;
	}

	int getTotalNode() {
		int total = 0;
		total += getLeafCount();
		total += getInternalCount();
		return total;
	}

	string getFasta() {
		return this->fastaString;
	}

	map<char, int> getLanguage() {
		return this->language;
	}

	int averageDepth() {
		if (getInternalCount() == 0)
		{
			return 0;
		}
		int avg = this->totalDepth / getInternalCount();
		return avg;
	}

	int getDeepestInternal() {
		return this->deepestInternal;
	}

	void setDeepestInternal(int depth) {
		this->deepestInternal = depth;
	}

	int getSLength() {
		int sLen = 0;
		for (int i = 0; i < this->S.size(); i++) {
			sLen += this->S[i].length();
		}
		return sLen;
	}





};

