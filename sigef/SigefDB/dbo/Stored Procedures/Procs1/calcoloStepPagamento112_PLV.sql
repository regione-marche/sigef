CREATE PROCEDURE [dbo].[calcoloStepPagamento112_PLV] 
	@IdProgetto int,
	@IdDomandaPagamento int =NULL
AS
BEGIN
   	
    	
-- 112 - Verificato il raggiungimento di almeno il 50% della dimensione economica, in termini di PLV aziendale, prevista dal Business plan
    	
DECLARE @Result int, @anno int, @PREVISIONALE_FALSE int, @PREVISIONALE_TRUE int

SET @Result = 1
set @anno = (select MAX(anno) from PLV_IMPRESA where ID_PROGETTO = @IdProgetto AND PREVISIONALE =0)
set @PREVISIONALE_FALSE =(SELECT SUM(PLV) FROM PLV_iMPRESA WHERE PREVISIONALE = 0 AND ID_PROGETTO = @IdProgetto AND ANNO = @anno)
set @PREVISIONALE_TRUE =(SELECT SUM(PLV) FROM PLV_iMPRESA WHERE PREVISIONALE = 1  AND ID_PROGETTO = @IdProgetto)

IF (@PREVISIONALE_FALSE <= ( ISNULL(@PREVISIONALE_TRUE ,0 ) * 0.5 ))
SET @Result = 0

SELECT @RESULT AS RESULT
END
