﻿CREATE PROCEDURE [dbo].[calcoloStepPagamento112_8]
(
  @IdProgetto INT,
  @IdDomandaPagamento  INT 
)
AS
BEGIN
/*DECLARE @ID_DOMANDA_PAGAMENTO int =1287*/
DECLARE @RESULT INT, @DATA_PRESENTAZIONE DATETIME 
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		 
--la data DELLA DOMADNA DI sal DEVE ESSERE PRESENTATA ENTRO IL 31/3/2015
 
SELECT @DATA_PRESENTAZIONE = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO =@IdDomandaPagamento	 
IF( @DATA_PRESENTAZIONE < '2015-04-01') SET @RESULT =1

 
SELECT @RESULT
END