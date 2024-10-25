CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B_PR_AN_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO  --
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati

--440	Richiesta proroga di 6 mesi per la fine lavori
--441	Richiesta proroga di ulteriori 3 mesi per la fine lavori
--445	Richiesta di saldo (entro 15 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)

--446	Data inizio interventi programmati (120 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuale proroga)
--439	Proroga di 30 giorni per l`inizio dei lavori
--447	Proroga di ulteriori 120 giorni per l`inizio dei lavori


--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@PROROGA_30G INT,
					@PROROGA_120G INT
					

SELECT @PROROGA_30G=CASE WHEN COUNT(*)>0 THEN 30 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 439			
SELECT @PROROGA_120G=CASE WHEN COUNT(*)>0 THEN 120 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 447			
					
-- Data inizio lavori (entro 120 giorni dalla data di ricevimento dell`atto di concessione dell`aiuto				
IF(@PROROGA_30G = 0 AND @PROROGA_120G>0)SET @RESULT=0 
ELSE BEGIN
		SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,120 +@PROROGA_30G+@PROROGA_120G,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 204)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 205))


		IF (@DIFFERENZA <= 0) SET @RESULT = 1 	
		ELSE SET @RESULT = 0 	
END

SELECT @RESULT
END
