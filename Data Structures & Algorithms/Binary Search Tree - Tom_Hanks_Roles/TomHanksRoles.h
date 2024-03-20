//Created by Ian Allen
// CS 132

#pragma once
#include <istream>
#include <ostream>
#include <fstream>
#include <string>

using namespace std;

class TomHanksRoles
{
private:
	string title;
	int year;
	string role;

public:
	//constructor
	TomHanksRoles()
	{
		title;
		year;
		role;
	}

	TomHanksRoles(const string& newTitle, const int& newYear, const string& newRole)
	{
		title = newTitle;
		year = newYear;
		role = newRole;
	}

	string getTitle() const
	{
		return(title);
	}

	int getYear() const
	{
		return(year);
	}

	string getRole() const
	{
		return(role);
	}

	void setTitle(const string& newTitle)
	{
		title = newTitle;
	}

	void setYear(const int& newYear)
	{
		year = newYear;
	}

	void setRole(const string& newRole)
	{
		role = newRole;
	}

	//insertion operator
	friend istream& operator >>(istream& in, TomHanksRoles& tomHanksRole)
	{
		string inputLine;
		const char tab(9);

		getline(in, inputLine, tab);
		if (!in.eof())
		{
			tomHanksRole.setTitle(inputLine);
			getline(in, inputLine, tab);
			tomHanksRole.setYear(stoi(inputLine));
			getline(in, inputLine);
			tomHanksRole.setRole(inputLine);
		}
		return(in);
	}

	friend ostream& operator <<(ostream& outStream, const TomHanksRoles& tomHanksRole)
	{
		outStream << "Movie: " << tomHanksRole.getTitle() << " Year: " << tomHanksRole.getYear() << " Role: " << tomHanksRole.getRole() << endl;
		return(outStream);
	}

};

