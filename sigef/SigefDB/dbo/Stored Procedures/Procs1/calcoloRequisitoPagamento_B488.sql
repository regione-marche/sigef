﻿-- SALDO
--=== Richiesta di saldo entro il 31 agosto 2015 ===--

create PROCEDURE [dbo].[calcoloRequisitoPagamento_B488]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @RESULT INT, @DATA_IMPOSTA DATETIME, @DIFFERENZA INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 
SELECT @DATA_IMPOSTA = '2015-08-31 00:00:00.000' -- DATA ENTRO LA QUALE DEVONO PRESENTARE IL SALDO
  
SELECT @DIFFERENZA = DATEDIFF(DAY,(@DATA_IMPOSTA) , (select DATA_MODIFICA from DOMANDA_DI_PAGAMENTO where ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO))
	
IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	
END
SELECT @RESULT