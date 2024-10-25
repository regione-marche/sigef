CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B231_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
--=== Data inizio interventi programmati (90 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe) ===--

-- new
-- 205 - Data inizio inteventi programmati
-- 204 - Data di ricezione della comunicazione di finanziabilità
-- 292 - Data inizio interventi programmati (90 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)
-- 302 - Numero mesi di proroga richiesti per l`inizio dei lavori

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DIFFERENZA_PROROGA DECIMAL (18,2),
					@PROROGA_INIZIO INT
				
SET @PROROGA_INIZIO = (select RPP.CODICE FROM DOMANDA_PAGAMENTO_REQUISITI DPR inner join REQUISITI_PAGAMENTO_PLURIVALORE RPP ON DPR.ID_VALORE = RPP.ID_VALORE
						WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND DPR.ID_REQUISITO = 302)
					
-- 302 - Numero mesi di proroga richiesti per l`inizio dei lavori
-- Data inizio interventi programmati (90 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,90, DATEADD(MM, ISNULL(@PROROGA_INIZIO,0),(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 204)
												 )) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 205))

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
