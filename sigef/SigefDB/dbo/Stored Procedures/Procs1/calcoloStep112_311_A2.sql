﻿CREATE PROCEDURE [dbo].[calcoloStep112_311_A2]
@IdProgetto int
AS
/*FATTO!!! 
DECLARE @IdProgetto INT
SET @IdProgetto =399*/

/* CONTROLLO SU MASSIMALE DI SPESE TECNICHE <20.000 €*/

/*QUESTA SP SOSTITUISCE LA QUERY:
SELECT SUM(I.CONTRIBUTO_RICHIESTO - (I.COSTO_INVESTIMENTO * I.QUOTA_CONTRIBUTO_RICHIESTO/100))   AS RESULT FROM PROGETTO P INNER JOIN PIANO_INVESTIMENTI I ON P.ID_PROGETTO=I.ID_PROGETTO WHERE ((SEGNATURA IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL )OR(SEGNATURA IS NOT NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL)) AND (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) and (P.id_bando = 29 or P.id_bando = 85)
*/

DECLARE @ID_PROG_CORRENTE_311 INT, @ID_BANDO_311 INT 

SELECT DISTINCT @ID_PROG_CORRENTE_311 = p.ID_PROGETTO, @ID_BANDO_311 =P.ID_BANDO FROM PROGETTO P
	INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '3.1.1.A'
WHERE ID_PROG_INTEGRATO = @IdProgetto

DECLARE @QUOTA_SPESE_GENERALI DECIMAL(10,2)
DECLARE @SPESE_TECNICHE DECIMAL(18,2)
DECLARE @MAX_SPESE_TECNICHE DECIMAL(18,2)
DECLARE @CONTRIBUTO DECIMAL(18,2)
DECLARE @COSTO_INVESTIMENTO DECIMAL(18,2)
DECLARE @TOTALE_SPESE DECIMAL(18,2)
SET @TOTALE_SPESE=0

DECLARE INVESTIMENTO CURSOR FOR 
(SELECT COSTO_INVESTIMENTO,SPESE_GENERALI,QUOTA_CONTRIBUTO_RICHIESTO,QUOTA_SPESE_GENERALI FROM PIANO_INVESTIMENTI I
INNER JOIN DETTAGLIO_INVESTIMENTI D ON I.ID_CODIFICA_INVESTIMENTO=D.ID_CODIFICA_INVESTIMENTO AND
I.ID_DETTAGLIO_INVESTIMENTO=D.ID_DETTAGLIO_INVESTIMENTO 
WHERE ID_PROGETTO=@ID_PROG_CORRENTE_311 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)

OPEN INVESTIMENTO
FETCH NEXT FROM INVESTIMENTO INTO @COSTO_INVESTIMENTO,@SPESE_TECNICHE,@CONTRIBUTO,@QUOTA_SPESE_GENERALI
WHILE @@FETCH_STATUS=0 BEGIN
	SET @MAX_SPESE_TECNICHE=@COSTO_INVESTIMENTO*@QUOTA_SPESE_GENERALI/100
	IF(@SPESE_TECNICHE>@MAX_SPESE_TECNICHE) SET @SPESE_TECNICHE=@MAX_SPESE_TECNICHE	
--SELECT @SPESE_TECNICHE,@MAX_SPESE_TECNICHE
	SET @TOTALE_SPESE=@TOTALE_SPESE+ CASE WHEN @SPESE_TECNICHE>0 THEN @SPESE_TECNICHE*@CONTRIBUTO/100 ELSE 0 END
	FETCH NEXT FROM INVESTIMENTO INTO @COSTO_INVESTIMENTO,@SPESE_TECNICHE,@CONTRIBUTO,@QUOTA_SPESE_GENERALI
END
CLOSE INVESTIMENTO
DEALLOCATE INVESTIMENTO

SELECT @TOTALE_SPESE
