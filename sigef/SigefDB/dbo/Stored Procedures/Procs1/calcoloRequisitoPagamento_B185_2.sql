-- SALDO
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--258	Data inizio interventi programmati (90 giorni dal ricevimento della comunicazione di finanziabilità)

--206	Numero mesi di proroga richiesti per la fine lavori
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--258	Data inizio interventi programmati (90 giorni dal ricevimento della comunicazione di finanziabilità)
--259	Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe)


-- 258 Data inizio interventi programmati (90 giorni dal ricevimento della comunicazione di finanziabilità)
CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B185_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @RESULT INT,@DIFFERENZA INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

--258	Data inizio interventi programmati (90 giorni dal ricevimento della comunicazione di finanziabilità)		
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,90,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 204)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 205))

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
