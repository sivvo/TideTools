*SELECT flat1
SELECT flattab
GO TOP
*SKIP 158
SCAN REST

	lcAddr = store_addr
*	lcAddr = STRTRAN(store_addr, "'", "")
	lcAddr = STRTRAN(store_addr, '"', "")
	FOR i = 1 TO 5
		lnLoc = AT(CHR(10), lcAddr)
		IF lnLoc>0
			lcstring = [line]+ALLTRIM(STR(i))+[ = "]+ SUBSTR(lcaddr,1,lnloc-1)+["]
		ELSE
			lcstring = [line]+ALLTRIM(STR(i))+[ = "]+ ALLTRIM(lcaddr)+["]
		ENDIF

		&lcstring

		lcAddr = SUBSTR(lcAddr,lnLoc+1)		
	ENDFOR
	REPLACE addr1 WITH line1, addr2 WITH line2, addr3 WITH line3, addr4 WITH line4, pcode WITH line5
		
ENDSCAN