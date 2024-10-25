create  PROCEDURE [dbo].[calcoloRequisitoPagamento_B244_362_411_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN
--== Data inizio interventi programmati (entro 90 giorni dalla data di ricezione della comunicazione di finanziabilità) ==--

--180	Data di ricezione della comunicazione di finanziabilità
--182	Proroga di ulteriori 3 mesi per la fine dei lavori
--205	Data inizio interventi programmati
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--384	Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuale proroga di 3 mesi per la fine lavori)
--385	Data inizio interventi programmati (entro 90 giorni dalla data di ricezione della comunicazione di finanziabilità)


--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 

DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT		
					
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,90,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 180) -- Data di ricezione della comunicazione di finanziabilità
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 205)) -- Data inizio interventi programmati

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
