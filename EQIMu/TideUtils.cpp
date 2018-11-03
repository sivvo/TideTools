#include "TideUtils.h"

#ifndef TEST_TIDE_UTIL
	#pragma message("EQIMU CONFIG")
	#include "EQIMConsole.h"
#else
	#pragma message("TEST CONFIG")
#endif

#include <iostream>
#include <string>
#include <vector>
using namespace std;

#define TELLHEADERLENGTH	25						// [22:15:54] -PRIVATE from "
#define ADMINFILE		"Admins.txt"
#define USERFILE		"Users.txt"

//===========================================================================
TideUtils::TideUtils(CEQIMConsole* _C)
{
	_Console = _C;

	TP = new GroupPlugin(this);
	IP = new ItemPlugin(this);
	DKP = new DKPPlugin(this);
	Spell = new SpellPlugin(this);
	loadDatabase(ADMINFILE, AdminDataBase);
	loadDatabase(USERFILE, UserDataBase);
}

//===========================================================================
TideUtils::TideUtils()
{
	_Console = 0;

	TP = new GroupPlugin(this);
	IP = new ItemPlugin(this);
	DKP = new DKPPlugin(this);
	Spell = new SpellPlugin(this);

	loadDatabase(ADMINFILE, AdminDataBase);
	loadDatabase(USERFILE, UserDataBase);
}

//===========================================================================
TideUtils::~TideUtils()
{
	delete TP;
	delete IP;
	delete DKP;
	delete Spell;
}

//===========================================================================
void TideUtils::parseMessage(char* _msg)
{
	TP->parseMessage(_msg);
	IP->parseMessage(_msg);
	DKP->parseMessage(_msg);
	Spell->parseMessage(_msg);
}

//===========================================================================
void TideUtils::TideOutput(const char* _Str)
{
	#ifndef TEST_TIDE_UTIL
		int MaxLength = 225;
		int iLength = 0;
		int iDecal = 0;
		char str1[225];

		iLength = strlen(_Str + iDecal);
		while(iLength>MaxLength)
		{
			strncpy (str1, _Str + iDecal, MaxLength);
			
			_Console->ChatCommand(str1);
			iDecal+=MaxLength;
			iLength = strlen(_Str + iDecal);
		}
		_Console->ChatCommand(_Str);

//		iLength = strlen(_Str);
//		if (iLength>225)
//		{
//			str1.substr(0, 224);
//			str2.substr(225, 450);
//			_Console->ChatCommand(str1);
//			_Console->ChatCommand(str2);
//		}
//		else
//		{
//		_Console->ChatCommand(_Str);
//		}
	#else
		printf("[Simulation] %s \n", _Str);	
	#endif
}


//===========================================================================
void TideUtils::getNameFromTell(char* _Name, char* _Tell)
{
	strcpy(_Name,_Tell + TELLHEADERLENGTH);

	for(size_t i=0; i < strlen(_Name) ;i++)
		if ((_Name[i]==20) || (_Name[i]==10) || (_Name[i]=='-'))
			_Name[i]=0;

	strcpy( _Name, strrchr(_Name,'.')+1 );
}

//===========================================================================
void TideUtils::getOption(char* _Name, char* _Line, char* _Option)
{
	strcpy(_Name,strstr(_Line,_Option)+ strlen(_Option) +1);

	for(size_t i=0; i < strlen(_Name) ;i++)
		if (_Name[i]=='\n')
			_Name[i]=0;
}

//===========================================================================
void TideUtils::loadDatabase(const char* fileName, vector<string>& DataBase)
{
	int iLength=0;
	printf("Loading %s, please wait.\n", fileName);
	FILE *file=fopen(fileName,"r");

	if (!file)
	{
		printf("ERROR : File not valid \n", iLength);
		printf("\n");
		return;
	}

	char line[256];

	DataBase.clear();

	while(fgets(line, 256, file) != NULL)
	{
		for(size_t i=0; i< strlen(line); i++)
		{
			if (line[i]=='\n')
			{
				line[i] = 0; 
				break; 
			}
		}
		DataBase.push_back(line);
		iLength++;
	}

	fclose(file);
	printf("Database Loaded : %d entries. \n", iLength);
	printf("\n");
}


//===========================================================================
bool TideUtils::isAdmin(char* _Name)
{
	return isInDB(_Name, AdminDataBase);
}

//===========================================================================
bool TideUtils::isUser(char* _Name)
{
	return isInDB(_Name, UserDataBase);
}

bool TideUtils::isInDB(const char* _Name, vector<string>& DataBase)
{
	for(int i=0; i < DataBase.size(); i++)
	{
		string& sT = DataBase.at(i);

		int iNum = sT.find(_Name, 0);

		if ( iNum >= 0 )
		{
			return true;
		}
	}
	return false;
}

//===========================================================================
void TideUtils::NotAdminErrorMessage(const char* cAsker)
{
	char cAnswer[256];

//	sprintf(cAnswer, ";tell %s [GroupBot] ERROR : you need administrator privilege for that command", cAsker);
//	TideOutput(cAnswer);

	sprintf(cAnswer, ";2 [GroupBot] [%s] tryed to use an administrator restricted command", cAsker);
	TideOutput(cAnswer);
}

//===========================================================================
void TideUtils::NotUserErrorMessage(const char* cAsker)
{
	char cAnswer[256];

//	sprintf(cAnswer, ";tell %s [GroupBot] ERROR : you need User privilege for that command", cAsker);
//	TideOutput(cAnswer);

	sprintf(cAnswer, ";2 [GroupBot] [%s] tryed to use a User restricted command", cAsker);
	TideOutput(cAnswer);
}
