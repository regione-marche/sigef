CREATE   PROCEDURE [dbo].[calcoloStepPagamento121_8]
@IdProgetto int , 
@IdDomandaPagamento int
AS
BEGIN

-- verifica sostenibilità investimento:
-- rata annua reintegrazione < 40% PLV post-investimento
--declare @IdProgetto int , 
--@IdDomandaPagamento int

--set @IdProgetto  = 2281 
-- set @IdDomandaPagamento = 2826

DECLARE @result int,@RataIntegrazione decimal(10,2),@anno int,
		@PLV_PostInvestimento decimal(10,2),@ID_VARIANTE INT
 
SET  @ID_VARIANTE = ( SELECT MAX(ID_VARIANTE) AS ID_VARIANTE FROM VARIANTI WHERE ID_PROGETTO =@IdProgetto   )
 
 SET @RataIntegrazione = (SELECT ISNULL(SUM((CASE I.MOBILE
												 WHEN 1 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 10 
												 WHEN 0 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 ELSE (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 END)) , 0)
								FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
								WHERE (( @ID_VARIANTE IS NULL AND I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND  ID_VARIANTE IS NULL) OR ( @ID_VARIANTE IS NOT NULL  AND ID_VARIANTE =@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'X') !='A'  ) )
                                      AND I.COD_TIPO_INVESTIMENTO = 1 AND (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)                                   
							 )
							 
-- modifica del 17/10/2013 						 
--SET @PLV_PostInvestimento = (SELECT ISNULL(SUM(PLV),0) AS PLV 
--                             FROM PLV_IMPRESA 
--                             WHERE PREVISIONALE = 1 AND ID_PROGETTO = @IdProgetto)

declare @id_BANDO INT 
SELECT @id_BANDO= ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto
IF(@id_BANDO !=34)BEGIN 
	set @anno = (select MAX(anno) from PLV_IMPRESA where ID_PROGETTO = @IdProgetto AND PREVISIONALE =0)
	set @PLV_PostInvestimento =(SELECT SUM(PLV) 
								FROM PLV_iMPRESA 
								WHERE PREVISIONALE = 0 AND ID_PROGETTO = @IdProgetto AND ANNO = @anno)
END
ELSE BEGIN 
	SET @PLV_PostInvestimento =(SELECT SUM(PLV) 
								FROM PLV_iMPRESA 
								WHERE PREVISIONALE = 1 AND ID_PROGETTO = @IdProgetto )
END
--select @PLV_PostInvestimento , @RataIntegrazione, (@PLV_PostInvestimento * 0.4), @anno
IF (@RataIntegrazione <= (@PLV_PostInvestimento * 0.4)) SET @result = 1
ELSE SET @result = 0

SELECT @result AS RESULT

END
