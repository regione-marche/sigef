﻿
CREATE PROCEDURE [dbo].RptPrioritaXInvestimento
(
@IdInvestimento int
)
AS
BEGIN	

SET NOCOUNT ON;
	--DECLARE @IdInvestimento int = 16977
	DECLARE @ID_Domanda INT 
SET @ID_Domanda = (SELECT ISNULL(ID_PROG_INTEGRATO, P.ID_PROGETTO) 
									FROM PROGETTO P INNER JOIN PIANO_INVESTIMENTI I ON P.ID_PROGETTO = I.ID_PROGETTO WHERE ID_INVESTIMENTO = @IdInvestimento)
	
	DECLARE @TMP AS TABLE (ID_PRIORITA INT, ID_INVESTIMENTO INT, TESTO VARCHAR(MAX), VAL_TESTO VARCHAR(1000), DESCRIZIONE VARCHAR(1000), FATTO BIT)


INSERT INTO @TMP
select PP.ID_PRIORITA, PIN.ID_INVESTIMENTO, Q.TESTO, VAL_TESTO, NULL, 0
from vPIANO_INVESTIMENTI PIN
INNER JOIN vPROGETTO AS P ON PIN.ID_PROGETTO = P.ID_PROGETTO
INNER JOIN vPRIORITA_X_INVESTIMENTI PP ON PIN.ID_INVESTIMENTO = PP.ID_INVESTIMENTO
inner join PRIORITA PRIO ON PP.ID_PRIORITA = PRIO.ID_PRIORITA
INNER JOIN dbo.zQUERY_SQL Q ON PRIO.QUERY_PLURIVALORE = Q.NOME
WHERE PIN.ID_INVESTIMENTO = @IdInvestimento

WHILE (
SELECT COUNT(*) FROM @TMP WHERE FATTO = 0) > 0
BEGIN 

DECLARE @TESTO nVARCHAR(MAX), @ID_PRIORITA INT, @DESCRIZIONE VARCHAR(1000), @COD VARCHAR(1000)
SELECT TOP 1 @TESTO = TESTO, @ID_PRIORITA = ID_PRIORITA, @COD = VAL_TESTO FROM @TMP WHERE FATTO = 0 


IF(@TESTO IS NOT NULL) 
BEGIN
	DECLARE @RISULT AS TABLE (CODICE VARCHAR(1000), DESCRIZIONE VARCHAR(1000))
	INSERT INTO @RISULT 
		EXECute sp_executesql @TESTO,N'@CODICE VARCHAR(1000), @IdProgetto INT, @fase_istruttoria BIT',@COD, @ID_Domanda, 1
	SELECT @DESCRIZIONE = case when DESCRIZIONE != @cod then descrizione else CODICE end FROM @RISULT	
END
UPDATE @TMP
SET DESCRIZIONE = @DESCRIZIONE, FATTO = 1 
WHERE ID_PRIORITA = @ID_PRIORITA

END


SELECT      PRIORITA.DESCRIZIONE AS DESCRIZIONE_PRIORITA, VPRIORITA_X_INVESTIMENTI.SCELTO AS PRIORITA_SELEZIONATA, 
	     ISNULL(VPRIORITA_X_INVESTIMENTI.DESCRIZIONE, '')  + ISNULL(CONVERT(VARCHAR(15),  vPRIORITA_X_INVESTIMENTI.VAL_DATA, 103), '')  
					  +  ISNULL(TMP.DESCRIZIONE, ISNULL(vPRIORITA_X_INVESTIMENTI.VAL_TESTO, ''))  AS DESCRIZIONE_SELEZIONATA, VPRIORITA_X_INVESTIMENTI.VALORE AS INPUT_SELEZIONATO
FROM         PRIORITA INNER JOIN
                      vPRIORITA_X_INVESTIMENTI ON PRIORITA.ID_PRIORITA = vPRIORITA_X_INVESTIMENTI.ID_PRIORITA
LEFT JOIN @TMP TMP ON  PRIORITA.ID_PRIORITA  = TMP.ID_PRIORITA AND vPRIORITA_X_INVESTIMENTI.ID_INVESTIMENTO = TMP.ID_INVESTIMENTO
WHERE vPRIORITA_X_INVESTIMENTI.ID_INVESTIMENTO = @IdInvestimento

END