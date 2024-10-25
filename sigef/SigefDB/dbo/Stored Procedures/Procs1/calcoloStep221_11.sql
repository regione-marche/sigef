--- verifica se è presente una sola delle due dichiarazioni in fatto di de minimis
--- e nel caso in cui l'azienda ha già chiesto aiuti verifica che abbia inserito il valore
--- nella priorità

CREATE PROCEDURE [dbo].[calcoloStep221_11]
@IdProgetto int, 
@FASE_ISTRUTTORIA INT = 0
AS
BEGIN

DECLARE @result int , @D1 int,  @D2 int, @REQ decimal(18,2), @CONTRIBUTO_RICHIESTO decimal(18,2)
SET @result = 0

SELECT @D1 = COUNT(*) FROM DICHIARAZIONI_X_PROGETTO   WHERE ID_PROGETTO = @IdProgetto AND ID_DICHIARAZIONE IN (599) --- ha beneficiato
SELECT @D2 = COUNT(*) FROM DICHIARAZIONI_X_PROGETTO   WHERE ID_PROGETTO = @IdProgetto AND ID_DICHIARAZIONE IN (600) --- non ha beneficiato

SELECT @REQ = (SELECT ISNULL (VALORE,0) from PRIORITA_X_PROGETTO WHERE  ID_PRIORITA = 600 AND  ID_PROGETTO = @IdProgetto) 
SELECT @CONTRIBUTO_RICHIESTO = (SELECT SUM(PIANO_INVESTIMENTI.CONTRIBUTO_RICHIESTO) AS CONTRIBUTO_RICHIESTO
							FROM  PROGETTO INNER JOIN PIANO_INVESTIMENTI ON PROGETTO.ID_PROGETTO = PIANO_INVESTIMENTI.ID_PROGETTO 
							WHERE  PROGETTO.ID_PROGETTO= @IdProgetto AND PIANO_INVESTIMENTI.ID_INVESTIMENTO_ORIGINALE IS NULL  )
							
IF( (ISNULL(@D2,0) = 1 AND ISNULL(@D1,0) = 0 AND (@REQ = 0 OR @REQ IS NULL))
	 OR
	(ISNULL(@D2,0) = 0 and ISNULL(@D1,0) = 1 and ISNULL(@REQ,0) > 0 )
  )SET @result = 1
ELSE SET @result = 0

SELECT @result AS RESULT
END
