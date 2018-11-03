SELECT flattab

SCAN
IF ALLTRIM(addr4) == ALLTRIM(pcode)
	replace addr4 WITH addr3
	replace addr3 WITH ""
ENDIF
endscan