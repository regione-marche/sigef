﻿CREATE  PROCEDURE [dbo].[calcoloRequisitoPagamento413_CE]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- 159	Data di ricezione della comunicazione di finanziabilità
-- 160	Data inizio interventi programmati
-- 161	Richiesta proroga di 30 giorni per la fine lavori

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 174
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DIFFERENZA_PROROGA DECIMAL (18,2),
					@PROROGA INT
					
					
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,120,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO =159)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO =160))

-- PROROGATO DI 30 GIORNI
SELECT @DIFFERENZA_PROROGA = DATEDIFF(DAY, DATEADD(DD,150,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO =159)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO =160)) 

							
SELECT @PROROGA = count(ID_REQUISITO) FROM  DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 161


IF (((@DIFFERENZA <= 0) AND (@PROROGA = 0)) OR ((@DIFFERENZA_PROROGA <= 0) AND (@PROROGA = 1)))
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END