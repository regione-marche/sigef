﻿CREATE PROCEDURE [dbo].[calcoloStep111_15]
@IdProgetto int
AS
BEGIN

-- 111 a -  Domande presentate da beneficiari delle misure 121 – 122

DECLARE @Result int,@ID_IMPRESA INT, @C_121 INT , @C_122 INT

SET @Result = 0 -- Impongo lo Step NON  verificato

-- ELENCO PROGETTI FINANZIATI NELLA MISURA  111 
-- CONTROLLO I PROGETTO AMMISSIBILI 

SELECT @ID_IMPRESA =  ID_IMPRESA FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto

SELECT @C_121 =COUNT(*) FROM (
	SELECT DISTINCT PB.ID_BANDO, P.ID_PROGETTO 
	FROM vBANDO_PROGRAMMAZIONE AS PB 
		 INNER JOIN vPROGETTO AS P ON PB.ID_BANDO = P.ID_BANDO AND (P.ORDINE_FASE >= 3 AND P.COD_STATO NOT IN ('N','B'))
 	WHERE (PB.MISURA_PREVALENTE = 1) AND PB.CODICE LIKE '1.2.1.%' AND PB.COD_PSR LIKE 'PSR%'
 			AND (PB.ID_DISPOSIZIONI_ATTUATIVE IS NULL) AND ID_IMPRESA = @ID_IMPRESA ) AS B121

IF(ISNULL(@C_121,0) >0 ) SET @Result =1
ELSE BEGIN
	SELECT @C_122 =COUNT(*) FROM (
	SELECT DISTINCT PB.ID_BANDO, P.ID_PROGETTO 
	FROM vBANDO_PROGRAMMAZIONE AS PB 
		 INNER JOIN vPROGETTO AS P ON PB.ID_BANDO = P.ID_BANDO AND (P.ORDINE_FASE >= 3 AND P.COD_STATO NOT IN ('N','B'))
 	WHERE (PB.MISURA_PREVALENTE = 1) AND PB.CODICE LIKE '1.2.2.%' AND PB.COD_PSR LIKE 'PSR%'
 			AND (PB.ID_DISPOSIZIONI_ATTUATIVE IS NULL) AND ID_IMPRESA = @ID_IMPRESA ) AS B121
	
	IF(ISNULL(@C_122,0) >0 ) SET @Result =1
END
 
SELECT @Result AS RESULT
END