#include "SpellPlugin.h"
#include "TideUtils.h"

#define DATABASEFILE		"eqspells.txt"
#define SPELLCOMMAND		"!spell"
#define RELOADSPELLCOMMAND	"!reloadspells"
#define SPELLMORECOMMAND	"!helpspell"

//===========================================================================
SpellPlugin::SpellPlugin(TideUtils* _TU)
{
	TU = _TU;
	TU->loadDatabase(DATABASEFILE, spellDataBase);
}

//===========================================================================
SpellPlugin::~SpellPlugin()
{
}

//===========================================================================
void SpellPlugin::parseMessage(char* _msg)
{
	if (strstr (_msg,"PRIVATE from"))
	{
		if (strstr (_msg,SPELLCOMMAND) )
		{
			sendSpell(_msg);
		}
		else
		if (strstr (_msg,RELOADSPELLCOMMAND) )
		{
			sendReloadSpell(_msg);
		}
	}
}

//===========================================================================
void SpellPlugin::sendSpell(char* _Line)
{
	char cAsker[60];
	char cName[60];
	char cAnswer[256];

	TU->getNameFromTell(cAsker, _Line);
	TU->getOption(cName, _Line, SPELLCOMMAND);


	if (!TU->isUser(cAsker))
	{
		TU->NotUserErrorMessage(cAsker);
		return;
	}

	getSpell(cAsker, cName);

	sprintf(cAnswer, ";2 [GroupBot] [%s] request Spell", cAsker);
	TU->TideOutput(cAnswer);
}

//===========================================================================
void SpellPlugin::sendReloadSpell(char* _Line)
{
	char cAsker[60];
	char cAnswer[256];

	TU->getNameFromTell(cAsker, _Line);

	if (!TU->isAdmin(cAsker))
	{
		TU->NotAdminErrorMessage(cAsker);
		return;
	}

	TU->loadDatabase(DATABASEFILE, spellDataBase);
	sprintf(cAnswer, ";2 [GroupBot] [%s] requested Spell Reload : Done", cAsker);
}


//===========================================================================
void SpellPlugin::getSpell(char* asker, char* _stofind)
{
	string AskerName(asker);
	string result = "";
	string tellheader = ";tell " + AskerName + " [GroupBot]";

	int iNbfound =0 ;

	for(int i=0; i < spellDataBase.size(); i++)
	{
		string& sT = spellDataBase.at(i);

		int num = sT.find(_stofind, 0);

		if ( num >= 0 )
		{
			iNbfound++;
			result = tellheader + sT;
			TU->TideOutput(result.c_str());

			if (iNbfound>4)
			{
				result = tellheader + " ... too many results";
				TU->TideOutput(result.c_str());
				return;
			}
		}
	}

	if (iNbfound == 0 )
	{
		result = tellheader + " no spell found, check the case and spelling!";
		TU->TideOutput(result.c_str());
	}
	return;
}