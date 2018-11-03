#ifndef __DKPPLUGIN_H__
#define __DKPPLUGIN_H__

//#include "EQIMConsole.h"
#include <string>
#include <vector>
using namespace std;

class DKPPlugin
{

public :

	DKPPlugin(CEQIMConsole* _C);
	~DKPPlugin();

	void parseMessage(char* _msg);
	void findString(char* asker, char* _stofind, bool findfirst);

private : 

	vector<string> DataBase;
	CEQIMConsole* _Console;

	void	getNameFromTell(char* _Name, char* _Tell);
	void	getOption(char* _Name, char* _Line, char* _Option);
	void	sendDkp(char* _Line);
	void	sendShowDkp(char* _Line);

	void	loadDatabase();
	
};

#endif