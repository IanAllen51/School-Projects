#pragma once
#include <string>
#include <vector>
#include <tuple>
#include <iostream>
using namespace std;

class SuffixNode
{
private:
	int nodeID;
	int stringDepth;
	bool isLeaf;
	string parentEdge;
	SuffixNode* ParentPointer;
	vector<SuffixNode*> children;
	
	//ADDED PROJ3
	vector<tuple<int, int>> leafLabels;
	string colorLabel;

public:
	SuffixNode(int id, SuffixNode* parent, bool leaf, string edge, int alphabet) {
		this->nodeID = id;
		this->ParentPointer = parent; //u
		this->isLeaf = leaf;
		this->parentEdge = edge;
		if (this->parentEdge.length() == 0) {
			this->stringDepth = 0;
		}
		else {
			this->stringDepth = parent->stringDepth + edge.length();
		}
		this->children.resize(alphabet, nullptr);
		this->colorLabel = "";

	}

	int getNodeID() {
		return this->nodeID;
	}

	int getStringDepth() {
		return this->stringDepth;
	}

	string getParentEdge() {
		return this->parentEdge;
	}

	void setParentEdge(string edge) {
		this->parentEdge = edge;
	}


	SuffixNode* getParentPointer() {
		return this->ParentPointer;
	}

	void setParentPointer(SuffixNode* parent) {
		this->ParentPointer = parent;
	}

	//will be altered at creation in tree.
	bool isLeafNode() {
		return this->isLeaf;
	}

	vector<SuffixNode*> getChildren() {
		return this->children;
	}

	void setChildNode(SuffixNode* newNode, int index) {
		this->children[index] = newNode;
	}

	void setLeafLabel(int stringNum, int stringIndex) {
		this->leafLabels.push_back(make_tuple(stringNum, stringIndex));
	}
	
	vector<tuple<int, int>> getLeafLabel() {
		return this->leafLabels;
	}

	void printLeafLabels() {
		for (int i = 0; i < this->leafLabels.size(); i++) {
			cout << "(" << get<0>(this->leafLabels[i]) << "," << get<1>(this->leafLabels[i]) << "), ";
		}
	}

	string getColorLabel() {
		return this->colorLabel;
	}

	void setColorLabel(string newColor) {
		this->colorLabel = newColor;
	}

};

