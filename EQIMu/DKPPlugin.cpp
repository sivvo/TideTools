#include "DKPPlugin.h"
#include "TideUtils.h"

#define DATABASEFILE		"tidedkp.txt"
#define MYDKPCOMMAND		"!dkp"
#define SHOWDKPCOMMAND		"!showdkp"
#define RELOADDKPCOMMAND	"!reloaddkp"

//===========================================================================
DKPPlugin::DKPPlugin(TideUtils* _TU)
{
	TU = _TU;
	TU->loadDatabase(DATABASEFILE, pointDataBase);
}

//===========================================================================
DKPPlugin::~DKPPlugin()
{
}

//===========================================================================
void DKPPlugin::parseMessage(char* _msg)
{
	if (strstr (_msg,"PRIVATE from"))
	{
		if (strstr (_msg,MYDKPCOMMAND) )
		{
			sendDkp(_msg);
		}
		else
		if (strstr (_msg,SHOWDKPCOMMAND) )
		{
			sendShowDkp(_msg);
		}
		else
		if (strstr (_msg,RELOADDKPCOMMAND) )
		{
			sendReloadDkp(_msg);
		}
	}
}

//===========================================================================
void DKPPlugin::sendDkp(char* _Line)
{
	char cAsker[60];
	char cName[60];
	char cAnswer[256];

	TU->getNameFromTell(cAsker, _Line);
	strcpy(cName, cAsker);

	if (!TU->isUser(cAsker))
	{
		TU->NotUserErrorMessage(cAsker);
		return;
	}

	getDKP(cAsker, cName);

	sprintf(cAnswer, ";2 [GroupBot] [%s] request DKP", cAsker);
	TU->TideOutput(cAnswer);
}

//===========================================================================
void DKPPlugin::sendShowDkp(char* _Line)
{
	char cAsker[60];
	char cName[60];
	char cAnswer[256];

	TU->getNameFromTell(cAsker, _Line);
	TU->getOption(cName, _Line, SHOWDKPCOMMAND);

	if (!TU->isUser(cAsker))
	{
		TU->NotUserErrorMessage(cAsker);
		return;
	}

	getDKP(cAsker, cName);

	sprintf(cAnswer, ";2 [GroupBot] [%s] request DKP", cAsker);
	TU->TideOutput(cAnswer);
}

//===========================================================================
void DKPPlugin::sendReloadDkp(char* _Line)
{
	char cAsker[60];
	char cAnswer[256];

	TU->getNameFromTell(cAsker, _Line);

	if (!TU->isAdmin(cAsker))
	{
		TU->NotAdminErrorMessage(cAsker);
		return;
	}

	TU->loadDatabase(DATABASEFILE, pointDataBase);
	sprintf(cAnswer, ";2 [GroupBot] [%s] requested DKP Reload : Done", cAsker);
}


//===========================================================================
void DKPPlugin::getDKP(char* asker, char* _stofind)
{
	string AskerName(asker);
	string result = "";
	string tellheader = ";tell " + AskerName + " [GroupBot]";

	for(int i=0; i < pointDataBase.size(); i++)
	{
		string& sT = pointDataBase.at(i);

		int num = sT.find(_stofind, 0);

		if ( num >= 0 )
		{
			result = tellheader + sT;
			TU->TideOutput(result.c_str());

			return;
		}
	}

	result = tellheader + " no DKP info found";
	TU->TideOutput(result.c_str());

	return;
}