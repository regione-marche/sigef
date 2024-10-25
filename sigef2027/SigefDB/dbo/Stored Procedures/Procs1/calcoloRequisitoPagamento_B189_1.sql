CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B189_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
--=== Data inizio interventi programmati (90 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe) ===--

--164	Richiesta proroga di 6 mesi per la fine lavori
--165	Richiesta proroga di 3 mesi per la fine lavori
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--210	Richiesta proroga di 90 giorni per l`avvio degli interventi
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati
--340	Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)
--341	Data inizio interventi programmati (90 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)


--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DIFFERENZA_PROROGA DECIMAL (18,2),
					@PROROGA_INIZIO INT
				
select @PROROGA_INIZIO = CASE WHEN COUNT(*)>0 THEN 90 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 210
					
-- Data inizio interventi programmati (90 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,90, DATEADD(DD, ISNULL(@PROROGA_INIZIO,0),(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 204)
												 )) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 205))

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
