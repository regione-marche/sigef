﻿CREATE PROCEDURE [dbo].[calcoloStep413_MONF_1]
@IdProgetto int, 
@FASE_ISTRUTTORIA INT = 0
AS
BEGIN

DECLARE @result int , @INVESTI int,  @DICHIARA int
SET @result = 0

SELECT @INVESTI = (SELECT COUNT(ID_INVESTIMENTO) FROM vPIANO_INVESTIMENTI WHERE ID_PROGETTO = @IdProgetto AND CODICE = 'A')

SELECT @DICHIARA = (SELECT COUNT(ID_DICHIARAZIONE) FROM DICHIARAZIONI_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_DICHIARAZIONE = 491)

IF  ((ISNULL(@INVESTI,0) >= 1 AND @DICHIARA = 1) OR (@INVESTI IS NULL OR @INVESTI = 0))SET @result = 1
	ELSE SET @result = 0

SELECT @result AS RESULT
END