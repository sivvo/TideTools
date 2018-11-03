#ifndef __TIDEUTILS_H__
#define __TIDEUTILS_H__

#include "GroupPlugin.h"
#include "ItemPlugin.h"
#include "DKPPlugin.h"
#include "SpellPlugin.h"


class CEQIMConsole;

class TideUtils
{
private : 
	CEQIMConsole* _Console;
	vector<string> AdminDataBase;
	vector<string> UserDataBase;

	GroupPlugin* TP;
	ItemPlugin* IP;
	DKPPlugin* DKP;
	SpellPlugin* Spell;

public :

	TideUtils(CEQIMConsole* _C);
	TideUtils();
	~TideUtils();

	void parseMessage(char* _msg);

	void TideOutput(const char* _Str);
	void getNameFromTell(char* _Name, char* _Tell);
	void getOption(char* _Name, char* _Line, char* _Option);
	void loadDatabase(const char* fileName, vector<string>& DataBase);

	bool isAdmin(char* _Name);
	bool isUser(char* _Name);
	bool isInDB(const char* _Name, vector<string>& DataBase);
	void NotAdminErrorMessage(const char* cAsker);
	void NotUserErrorMessage(const char* cAsker);
};
#endif