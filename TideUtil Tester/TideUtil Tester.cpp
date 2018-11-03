#include "../EQIMu/TideUtils.h"
#include <iostream>
#include <tchar.h>


void TestString(char* _msg, TideUtils* _TU)
{
	printf("=================================================\n");
	printf("Message : \n");
	printf(_msg);
	printf("\n");
	printf("Result : \n");
	_TU->parseMessage(_msg);
	printf("=================================================\n");
	system("pause") ;
}

int _tmain(int argc, _TCHAR* argv[])
{
	TideUtils* mTideUtils = new TideUtils;

	TestString("[22:15:54] -PRIVATE from Antonius.Meemers- !dkp", mTideUtils);
	TestString("[22:15:54] -PRIVATE from Antonius.Llaenx- !dkp", mTideUtils);
	TestString("[22:15:54] -PRIVATE from Antonius.Meemers- !spell Wanton", mTideUtils);
	TestString("[22:15:54] -PRIVATE from Antonius.Anonymus- !motd", mTideUtils);
	TestString("[22:15:54] -PRIVATE from Antonius.Llaenx- !broadcast", mTideUtils);
	TestString("[22:15:54] -PRIVATE from Antonius.Anonymus- !broadcast", mTideUtils);

	delete mTideUtils;

	return 0;
}


