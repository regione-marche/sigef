CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B236_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
--=== Data inizio interventi programmati (entro 6 mesi dalla data di ricezione della comunicazione di finanziabilità oltre eventuale proroga) ===--

--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati
--* 266	Richiesta di saldo (entro 12 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)
--* 408	Data inizio interventi programmati (entro 6 mesi dalla data di ricezione della comunicazione di finanziabilità oltre eventuale proroga)
--409	Richiesta proroga di 4 mesi per la fine lavori
--410	Richiesta proroga di 2 mesi per la fine lavori
--411	Proroga di 90 giorni per l`inizio dei lavori



--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DIFFERENZA_PROROGA DECIMAL (18,2),
					@PROROGA_INIZIO INT
				
SELECT @PROROGA_INIZIO = CASE WHEN COUNT(*)>0 THEN 90 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 411
			
-- Data inizio interventi programmati (entro 6 mesi dalla data di ricezione della comunicazione di finanziabilità oltre eventuale proroga)
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(MM,6, DATEADD(DD, ISNULL(@PROROGA_INIZIO,0),(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 204)
												 )) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 205))

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
