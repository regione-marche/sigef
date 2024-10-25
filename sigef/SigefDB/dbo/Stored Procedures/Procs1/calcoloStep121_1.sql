CREATE PROCEDURE [dbo].[calcoloStep121_1]
@IdProgetto int
AS
BEGIN

-- verifica sostenibilità investimento:
-- rata annua reintegrazione < 40% PLV post-investimento

DECLARE @result int
DECLARE @RataIntegrazione decimal(10,2)
DECLARE @PLV_PostInvestimento decimal(10,2)
DECLARE @CodFaseProgetto char(1)

SET @CodFaseProgetto = (SELECT TOP(1) ISNULL(COD_FASE,'P') FROM dbo.vPROGETTO WHERE ID_PROGETTO = @IdProgetto  )

IF (@CodFaseProgetto = 'P') 
SET @RataIntegrazione = (SELECT ISNULL(SUM((CASE I.MOBILE
												 WHEN 1 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI)/ 10 
												 WHEN 0 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 ELSE (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 END)) , 0)
							FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
							WHERE I.ID_INVESTIMENTO_ORIGINALE IS NULL AND I.COD_TIPO_INVESTIMENTO = 1 AND
								  (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)
                        )	

ELSE SET @RataIntegrazione = (SELECT ISNULL(SUM((CASE I.MOBILE
												 WHEN 1 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 10 
												 WHEN 0 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 ELSE (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 END)) , 0)
								FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
								WHERE I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL
                                      AND I.COD_TIPO_INVESTIMENTO = 1 AND (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)                                   
							 )

SET @PLV_PostInvestimento = (SELECT ISNULL(SUM(PLV),0) AS PLV 
                             FROM PLV_IMPRESA 
                             WHERE PREVISIONALE = 1 AND ID_PROGETTO = @IdProgetto)

IF (@RataIntegrazione <= (@PLV_PostInvestimento * 0.4)) SET @result = 1
ELSE SET @result = 0

SELECT @result AS RESULT

END
