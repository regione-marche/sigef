﻿CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento112_8]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN
/*DECLARE @ID_DOMANDA_PAGAMENTO int =1287*/
DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT, 
		@DATA_PRESENTAZIONE DATETIME,@DATA_GRADUATORIA DATETIME 
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		 
--la data DELLA DOMADNA DI sal DEVE ESSERE PRESENTATA ENTRO IL 31/3/2015
 
SELECT @DATA_PRESENTAZIONE = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO =@ID_DOMANDA_PAGAMENTO	 
IF( @DATA_PRESENTAZIONE < '2015-04-01') SET @RESULT =1

 
SELECT @RESULT
END
