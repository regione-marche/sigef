CREATE PROCEDURE [dbo].[calcoloStep121_13]
	@IdProgetto int, 
	@FASE_ISTRUTTORIA INT =0
AS
BEGIN

-- verifica sostenibilità investimento:
-- rata annua reintegrazione < 40% PLV post-investimento

--DECLARE @IdProgetto int =2962 , 
--	@FASE_ISTRUTTORIA INT = 1


DECLARE @result int
DECLARE @RataIntegrazione decimal(10,2)
DECLARE @PLV_PostInvestimento decimal(10,2)
 
SET @RataIntegrazione = (SELECT ISNULL(SUM((CASE I.MOBILE
												 WHEN 1 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI)/ 10 
												 WHEN 0 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 ELSE (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 END)) , 0)
							FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
							WHERE I.COD_TIPO_INVESTIMENTO = 1 AND (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)
							 AND ((@FASE_ISTRUTTORIA =0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL) OR 
									(@FASE_ISTRUTTORIA =1 AND I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
                        )	

 
SET @PLV_PostInvestimento = (SELECT ISNULL(SUM(PLV),0) AS PLV 
                             FROM PLV_IMPRESA 
                             WHERE PREVISIONALE = 1 AND ID_PROGETTO = @IdProgetto)

--SELECT @RataIntegrazione, @PLV_PostInvestimento
IF (@RataIntegrazione <= (@PLV_PostInvestimento * 0.40)) SET @result = 1
ELSE SET @result = 0

SELECT @result AS RESULT

END
