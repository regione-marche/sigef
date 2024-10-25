﻿CREATE   PROCEDURE [dbo].[calcoloStep133_2]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
-- Investimenti completi di indicazione dell`annualità di realizzazione
DECLARE @CUAA VARCHAR(16), @result int
--@IdProgetto int
--set @IdProgetto =  7343 
SET @RESULT =1 --PONGO LO STEP VERIFICATO
 
 SELECT ((SELECT COUNT(*) AS A  
		  FROM  PIANO_INVESTIMENTI PI  
		  WHERE  ID_PROGETTO = @IdProgetto AND ((ID_INVESTIMENTO_ORIGINALE  IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL )
												OR(ID_INVESTIMENTO_ORIGINALE  IS NOT NULL AND @FASE_ISTRUTTORIA=1 AND ID_VARIANTE IS NULL))
				AND COD_TIPO_INVESTIMENTO = 1) - 
		(SELECT COUNT(*) FROM PIANO_INVESTIMENTI AS PI INNER JOIN PRIORITA_X_INVESTIMENTI ON PI.ID_INVESTIMENTO = PRIORITA_X_INVESTIMENTI.ID_INVESTIMENTO 
		 WHERE (PI.ID_PROGETTO = @IdProgetto )AND cod_tipo_investimento = 1  
			AND ((ID_INVESTIMENTO_ORIGINALE  IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL )
				OR(ID_INVESTIMENTO_ORIGINALE  IS NOT NULL AND @FASE_ISTRUTTORIA=1 AND ID_VARIANTE IS NULL)) AND ID_PRIORITA IN (228,374,404,859)))

  
END
