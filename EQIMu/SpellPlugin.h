#ifndef __SPELLPLUGIN_H__
#define __SPELLPLUGIN_H__

#include <string>
#include <vector>
using namespace std;

class SpellPlugin
{

public :

	SpellPlugin(class TideUtils* _TU);
	~SpellPlugin();

	void parseMessage(char* _msg);
	void getSpell(char* asker, char* _stofind);

private : 

	vector<string> spellDataBase;
	class TideUtils* TU;

	void	sendSpell(char* _Line);
	void	sendReloadSpell(char* _Line);
	void	sendHelp(char* _Line);
	
};

#endif