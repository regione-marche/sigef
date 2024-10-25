CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento4137a_GAL_F_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- GAL FERMANO
-- SALDO

-- NEW
-- 233	Data inizio interventi programmati (60 giorni dalla comunicazione di finanziabilità)
-- 232	Data di ricezione della comunicazione di finanziabilità

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DIFFERENZA_PROROGA DECIMAL (18,2),
					@PROROGA INT
					
-- Data inizio interventi programmati 60 GIORNI dalla data di ricezione della comunicazione di finanziabilità					
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,60,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 232)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 233))
						
IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
