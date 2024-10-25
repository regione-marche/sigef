create PROCEDURE [dbo].[calcoloRequisitoPagamento_B279_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
-- 374 Data di ricezione della comunicazione di finanziabilità
-- 375 Data inizio interventi programmati (120 giorni dalla comunicazione di finanziabilità)
-- 379 Data inizio interventi programmati



--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DIFFERENZA_PROROGA DECIMAL (18,2),
					@PROROGA INT
					
-- Data inizio interventi programmati 120 GIORNI dalla data di ricezione della comunicazione di finanziabilità					
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,120,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 374)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 379))


							


IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
