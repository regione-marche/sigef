CREATE  PROCEDURE [dbo].[calcoloRequisitoPagamentoGAL]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO =174
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT



-- 162 --> Data di ricezione della comunicazione di finanziabilità
-- 163 --> Data inizio inteventi programmati
	


SELECT @DIFFERENZA = DATEDIFF(DAY, (DATEADD(DD, 90,( DATEADD(MM,0,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO =162))))),
														(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO =163)) 
						



IF (@DIFFERENZA <= 0)
SET @RESULT = 1 	
ELSE SET @RESULT = 0 	

SELECT @RESULT
END
