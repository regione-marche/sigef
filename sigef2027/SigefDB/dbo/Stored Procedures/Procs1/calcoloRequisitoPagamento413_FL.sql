create  PROCEDURE [dbo].[calcoloRequisitoPagamento413_FL]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN


-- 175	Data di ricezione della comunicazione di finanziabilità
-- 173 data inizio interventi programmati
-- 6 MESI MAX

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 

DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT		
					
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(MM,6,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 175) -- Data di ricezione della comunicazione di finanziabilità
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 173)) -- Data inizio interventi programmati

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
