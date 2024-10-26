﻿CREATE  PROCEDURE [dbo].[calcoloStep311_12]
(
	@IdProgetto int,
	@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
 -- CONTROLLO TIPOLOGIE DI INTERVENTO FATTO!!! 
DECLARE @ID_IMPRESA INT , @PROG_311_GIOVANI INT ,@COUNT INT,@RESULT INT
SELECT @ID_IMPRESA = P.ID_IMPRESA  
FROM PROGETTO P INNER JOIN IMPRESA IMP ON IMP.ID_IMPRESA = P.ID_IMPRESA  WHERE ID_PROGETTO = @IdProgetto 
 
SELECT @PROG_311_GIOVANI=COUNT( p.ID_PROGETTO) FROM VPROGETTO P
		INNER JOIN PIANO_INVESTIMENTI INV ON INV.ID_PROGETTO= P.ID_PROGETTO
		INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE  = '3.1.1.A'
WHERE P.ID_BANDO = 135 AND COD_STATO = 'N' and p.ID_IMPRESA = @ID_IMPRESA
 
IF(ISNULL(@PROG_311_GIOVANI,0)> 0 ) BEGIN 
			SELECT @COUNT= COUNT(*) 
			FROM vPIANO_INVESTIMENTI INV 
				INNER JOIN ZPROGRAMMAZIONE P  ON P.ID = INV.ID_PROGRAMMAZIONE 
			WHERE ID_PROGETTO = @IdProgetto AND P.CODICE IN ('3.1.1.A.1','3.1.1.A.2','3.1.1.A.3','3.1.1.A.4')
				AND ((@FASE_ISTRUTTORIA=0 AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
						OR(@FASE_ISTRUTTORIA=1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
	IF(ISNULL(@COUNT,0)=0 ) SET @RESULT =1
	ELSE SET @RESULT =0
END
ELSE BEGIN 
	SELECT @COUNT= COUNT(*) 
	FROM vPIANO_INVESTIMENTI INV 
		INNER JOIN ZPROGRAMMAZIONE P  ON P.ID = INV.ID_PROGRAMMAZIONE 
	WHERE ID_PROGETTO = @IdProgetto AND P.CODICE  IN ('3.1.1.A.A','3.1.1.A.B','3.1.1.A.C','3.1.1.A.D','3.1.1.A.E','3.1.1.A.F','3.1.1.A.G','3.1.1.A.H','3.1.1.A.I','3.1.1.A.J') AND
			((@FASE_ISTRUTTORIA=0 AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
				OR(@FASE_ISTRUTTORIA=1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
	IF(ISNULL(@COUNT,0)=0 ) SET @RESULT =1
	ELSE SET @RESULT =0
END

SELECT @RESULT  AS RESULT
END
