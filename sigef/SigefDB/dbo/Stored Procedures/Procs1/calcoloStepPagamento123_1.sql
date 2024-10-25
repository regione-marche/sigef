CREATE  PROCEDURE [dbo].[calcoloStepPagamento123_1]
@IdProgetto int,
@IdDomandaPagamento int =NULL
AS
BEGIN
	-- 121 Raggiungimento del minimo contributo concesso in graduatoria necessario per richiedere SAL.
	-- Requisiti pagamento esito positivo =1 

DECLARE @ID_VARIANTE INT, @RESULT INT
DECLARE @CONTRIBUTO_PROGETTO decimal(10,2)

SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		 
 
--CONTROLLO SE ESISTE UNA VARIANTE
SET @ID_VARIANTE =  (SELECT MAX(ID_VARIANTE) FROM VARIANTI WHERE ID_PROGETTO = @IdProgetto AND APPROVATA =1 AND ANNULLATA=0)
 
SET @CONTRIBUTO_PROGETTO = ISNULL((SELECT dbo.[calcoloContributoTotaleProgettoCorrelato] (@IdProgetto, 1, @ID_VARIANTE)), 0)
IF (@CONTRIBUTO_PROGETTO >= 50000)SET @RESULT =1
ELSE SET @RESULT=0
	
SELECT @RESULT
END
