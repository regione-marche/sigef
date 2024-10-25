CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B175_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO  --- 
--=== -- Data inizio interventi programmati (140 giorni dalla comunicazione di finanziabilità)	===--

--397	Data inizio interventi programmati
--398	Data di ricezione della comunicazione di finanziabilità
--399	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--400	Rendicontazione degli interventi programmati entro 18 mesi dal ricevimento della comunicazione di finanziabilità, salvo proroghe.
--401	Prima proroga di 6 mesi per la fine dei lavori
--402	Data inizio interventi programmati (140 giorni dalla comunicazione di finanziabilità)
--407	Seconda proroga di 3 mesi per la fine dei lavori

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT
					
-- Data inizio interventi programmati (140 giorni dalla comunicazione di finanziabilità)			
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,140,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 398)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 397))

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
