#ifndef __DKPPLUGIN_H__
#define __DKPPLUGIN_H__

#include <string>
#include <vector>
using namespace std;

class DKPPlugin
{

public :

	DKPPlugin(class TideUtils* _TU);
	~DKPPlugin();

	void parseMessage(char* _msg);
	void getDKP(char* asker, char* _stofind);

private : 

	vector<string> pointDataBase;
	class TideUtils* TU;

	void	sendDkp(char* _Line);
	void	sendShowDkp(char* _Line);
	void	sendReloadDkp(char* _Line);
};

#endif