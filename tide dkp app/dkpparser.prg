SELECT tidedkp
GO TOP

nFile = FCREATE("c:\tidedkp.txt")
SCAN

lcString = ALLTRIM(name) + " ("+ALLTRIM(STR(dkp,4,3))+" DKP)"
FPUTS(nFile, lcString)
ENDSCAN

FCLOSE(nFile)