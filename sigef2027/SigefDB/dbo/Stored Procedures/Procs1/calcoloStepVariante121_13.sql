create PROCEDURE [dbo].[calcoloStepVariante121_13]
@ID_VARIANTE INT

AS
BEGIN

-- verifica sostenibilità investimento:
-- rata annua reintegrazione < 40% PLV post-investimento

--DECLARE @IdProgetto int =2962 , 
--	@FASE_ISTRUTTORIA INT = 1


DECLARE @result int, @RataIntegrazione decimal(10,2)
DECLARE @PLV_PostInvestimento decimal(10,2)

declare @IdProgetto int
select @IdProgetto = ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE 
 
SET @RataIntegrazione = (SELECT ISNULL(SUM((CASE I.MOBILE
												 WHEN 1 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI)/ 10 
												 WHEN 0 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 ELSE (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 END)) , 0)
							FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
							WHERE I.COD_TIPO_INVESTIMENTO = 1 AND i.ID_VARIANTE = @ID_VARIANTE and isnull(i.COD_VARIAZIONE,0) != 'A'
							 
                        )	

 
SET @PLV_PostInvestimento = (SELECT ISNULL(SUM(PLV),0) AS PLV 
                             FROM PLV_IMPRESA 
                             WHERE PREVISIONALE = 1 AND ID_PROGETTO = @IdProgetto)

--SELECT @RataIntegrazione, @PLV_PostInvestimento
IF (@RataIntegrazione <= (@PLV_PostInvestimento * 0.40)) SET @result = 1
ELSE SET @result = 0

SELECT @result AS RESULT

END
