#ifndef __ITEMPLUGIN_H__
#define __ITEMPLUGIN_H__

#include "EQIMConsole.h"
#include <string>
#include <vector>
using namespace std;

class ItemPlugin
{

public :

	ItemPlugin(CEQIMConsole* _C);
	~ItemPlugin();

	void parseMessage(char* _msg);
	void findString(char* asker, char* _stofind, bool findfirst);

private : 

	vector<string> DataBase;
	CEQIMConsole* _Console;

	void	getNameFromTell(char* _Name, char* _Tell);
	void	getOption(char* _Name, char* _Line, char* _Option);
	void	sendItem(char* _Line);
	void	sendFirstItem(char* _Line);

	void	loadDatabase();
	
};

#endif