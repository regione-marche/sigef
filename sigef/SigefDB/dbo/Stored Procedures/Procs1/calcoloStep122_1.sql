﻿-- Rispetto massimale investimento per Miglioramento viabilità forestale

CREATE PROCEDURE [dbo].[calcoloStep122_1]
@IdProgetto int,
@fase_istruttoria int =0
AS
BEGIN

DECLARE @Result int ,
		@INV_VIABILITA decimal(18,2) ,
		@INV_SELVICOLTURA decimal(18,2)


SET @Result = 1 -- Impongo lo Step  verificato

SET @INV_VIABILITA = (SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) + ISNULL( SUM (SPESE_GENERALI),0)  FROM PROGETTO P  INNER JOIN
					 VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
					 WHERE
					 I.COD_TIPO_INVESTIMENTO = 1  AND
					 (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
					 (
					(@FASE_ISTRUTTORIA=0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)
						OR
					(@FASE_ISTRUTTORIA=1 AND I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)
					) AND
					 ID_DETTAGLIO_INVESTIMENTO IN
					 (SELECT ID_DETTAGLIO_INVESTIMENTO  FROM CODIFICA_INVESTIMENTO CI INNER JOIN
								DETTAGLIO_INVESTIMENTI DI ON (CI.ID_CODIFICA_INVESTIMENTO = DI.ID_CODIFICA_INVESTIMENTO) WHERE
								CI.ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto) AND DI.COD_DETTAGLIO = 'a7'))

SET @INV_SELVICOLTURA = (SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) + ISNULL( SUM (SPESE_GENERALI),0)  FROM PROGETTO P  INNER JOIN
					VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) WHERE 
					I.COD_TIPO_INVESTIMENTO = 1 AND
					(P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
					(
					(@FASE_ISTRUTTORIA=0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)
						OR
					(@FASE_ISTRUTTORIA=1 AND I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)
					) AND
					ID_DETTAGLIO_INVESTIMENTO IN
					(SELECT ID_DETTAGLIO_INVESTIMENTO  FROM CODIFICA_INVESTIMENTO CI  INNER JOIN
								DETTAGLIO_INVESTIMENTI DI ON (CI.ID_CODIFICA_INVESTIMENTO = DI.ID_CODIFICA_INVESTIMENTO) WHERE
								CI.ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto) AND DI.COD_DETTAGLIO in ('a1','a2','a3','a4','a5','a6')))
  								   
IF(ISNULL(@INV_VIABILITA,0) > 0)
BEGIN
	IF(ISNULL(@INV_SELVICOLTURA,0) > 0)
		BEGIN
			IF ((@INV_VIABILITA * 100) / @INV_SELVICOLTURA) > 25
			SET @Result=0
		END
	ELSE 
		SET @Result=0
END  
  ELSE 
	SET @Result=1

SELECT @Result
END
