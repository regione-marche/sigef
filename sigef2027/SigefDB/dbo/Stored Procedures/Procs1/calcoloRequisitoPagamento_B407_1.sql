CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B407_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
--------=== Data inizio interventi programmati (60 giorni dalla comunicazione di finanziabilità) ===-----------

--208	Data di ricezione della comunicazione di finanziabilità
--459	Data inizio interventi programmati
--455	Data inizio interventi programmati (60 giorni dalla comunicazione di finanziabilità)

--214	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--456	Proroga di 3 mesi per la fine dei lavori
--458	Richiesta di saldo (entro 12 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuale proroga di 3 mesi)



--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT
					
--	Data inizio interventi programmati (60 giorni dalla comunicazione di finanziabilità)
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,60,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 208)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 459))

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
