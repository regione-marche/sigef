﻿create   PROCEDURE [dbo].[calcoloStepVariante133_5]
@ID_VARIANTE int
AS
BEGIN
-- Investimenti completi di indicazione dell`annualità di realizzazione
DECLARE @CUAA VARCHAR(16), @result int
--@IdProgetto int

--set @IdProgetto =  7343 
SET @RESULT =1 --PONGO LO STEP VERIFICATO
 
 SELECT ((SELECT COUNT(*) AS A FROM PIANO_INVESTIMENTI PI WHERE ID_VARIANTE = @ID_VARIANTE AND COD_TIPO_INVESTIMENTO = 1 AND isnull(COD_VARIAZIONE,'x')!='A' ) - 
	(SELECT COUNT(*) FROM PIANO_INVESTIMENTI AS PI INNER JOIN PRIORITA_X_INVESTIMENTI ON PI.ID_INVESTIMENTO = PRIORITA_X_INVESTIMENTI.ID_INVESTIMENTO 
WHERE (PI.ID_VARIANTE = @ID_VARIANTE )  AND isnull(COD_VARIAZIONE,'x')!='A' AND COD_TIPO_INVESTIMENTO = 1 AND ID_PRIORITA in ( 228,404,859) ))

  
END