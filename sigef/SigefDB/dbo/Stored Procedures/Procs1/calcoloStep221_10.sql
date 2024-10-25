--- almeno un investimento per codifica investimento

CREATE PROCEDURE [dbo].[calcoloStep221_10]
@IdProgetto int, 
@FASE_ISTRUTTORIA INT = 0
AS
BEGIN

DECLARE @result int , @ALL int
SET @result = 0


SET @ALL = (select COUNT(*) from (SELECT distinct codice fROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) WHERE I.ID_INVESTIMENTO_ORIGINALE IS NULL AND I.COD_TIPO_INVESTIMENTO = 1 AND (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)  AND CODICE in ('a','b','c','d') group by CODICE) as codifiche_presenti)

IF(@ALL = 4)SET @result = 4
	ELSE SET @result = 0

SELECT @result AS RESULT
END
