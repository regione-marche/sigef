﻿create PROCEDURE [dbo].[calcoloStep221_4]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN

DECLARE @RESULT int,
		@SPESEIMPIANTO int,
		@SPESEGENERALI int

--- Spese GENERALI di impianto <=10% Costi impianto
SET @RESULT = 0 -- PONGO LO STEP IN STATO NON VERIFICATO

--- Spese GENERALI di impianto <=10% Costi impianto
SET @SPESEIMPIANTO = (SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) FROM PROGETTO P
INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) WHERE
((I.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL)OR(I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) AND
I.COD_TIPO_INVESTIMENTO = 1 AND
(P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
I.CODICE = 'a' AND
I.ID_PROGETTO = @IdProgetto) -- spese impianto 

SET @SPESEGENERALI = (SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) FROM PROGETTO P
INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) WHERE
((I.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL)OR(I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) AND
I.COD_TIPO_INVESTIMENTO = 1 AND
(P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
I.CODICE = 'b' AND
I.ID_PROGETTO = @IdProgetto) -- spese generali

IF(@SPESEGENERALI <= ((@SPESEIMPIANTO*10)/100))
    SET @RESULT =1
ELSE  SET @RESULT=0
SELECT @RESULT
END