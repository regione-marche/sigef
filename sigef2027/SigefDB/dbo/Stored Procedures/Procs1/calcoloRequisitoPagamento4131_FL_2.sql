create  PROCEDURE [dbo].[calcoloRequisitoPagamento4131_FL_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN


-- 180	Data di ricezione della comunicazione di finanziabilità
-- 179 data inizio interventi programmati
-- 3 MESI MAX

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 

DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT		
					
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(MM,3,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 180) -- Data di ricezione della comunicazione di finanziabilità
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 179)) -- Data inizio interventi programmati

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
