﻿CREATE  PROCEDURE [dbo].[calcoloRequisitoPagamento112_4]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO =28
DECLARE @ID_PROGETTO INT, @DATA_VERIFICA DATETIME,	
					@RESULT INT ,@DATA_PAGAMENTO DATETIME

SET @RESULT =1 -- IMPONGO IL CONTROLLO VERIFICATO

SELECT @ID_PROGETTO =   ID_PROGETTO, @DATA_VERIFICA=VERIFICA_PAGAMENTI_DATA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO 
SELECT @DATA_PAGAMENTO =MAX(DATA_RICHIESTA_PAGAMENTO) FROM  PAGAMENTI_RICHIESTI PR WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO
 IF(@DATA_VERIFICA IS NULL OR @DATA_PAGAMENTO > @DATA_VERIFICA) 
	SET @RESULT =0
SELECT @RESULT
END
