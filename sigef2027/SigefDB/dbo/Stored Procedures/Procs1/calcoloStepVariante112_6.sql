CREATE PROCEDURE [dbo].[calcoloStepVariante112_6]
(
 @ID_VARIANTE INT
)
AS
BEGIN
 
-- verifica sostenibilità investimento:
-- rata annua reintegrazione < 40% PLV post-investimento
--declare  @ID_VARIANTE INT
--set @ID_VARIANTE = 320
DECLARE @result int, @IdProgetto INT
DECLARE @RataIntegrazione decimal(10,2)
DECLARE @PLV_PostInvestimento decimal(10,2)

SET @IdProgetto = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE)

SET @RataIntegrazione = (SELECT ISNULL(SUM((CASE I.MOBILE
												 WHEN 1 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 10 
												 WHEN 0 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 ELSE (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 END)) , 0)
							FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
							WHERE (  ID_VARIANTE = @ID_VARIANTE) 
								AND I.COD_TIPO_INVESTIMENTO = 1 AND (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND p.ID_BANDO not in (59,61, 86,87,110,111) 
								AND  ISNULL(COD_VARIAZIONE, 'X')!='A'
                        )	

 SET @PLV_PostInvestimento = (SELECT ISNULL(SUM(PLV),0) AS PLV 
                             FROM PLV_IMPRESA 
                             WHERE PREVISIONALE = 1 AND ID_PROGETTO = @IdProgetto)

IF (@RataIntegrazione <= (@PLV_PostInvestimento * 0.4)) SET @result = 1
ELSE SET @result = 0

SELECT @result AS RESULT

END
