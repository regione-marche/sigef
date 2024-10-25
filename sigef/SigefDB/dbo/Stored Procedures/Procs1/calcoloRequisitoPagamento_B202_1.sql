CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B202_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
--=== Data inizio interventi programmati (90 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe) ===--

--new
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--206	Numero mesi di proroga richiesti per la fine lavori
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati
--298	Data inizio interventi programmati (entro 90 gg. dalla data del ricevimento della comunicazione di finanzi abilità, oltre eventuali proroghe)
--299	Data di completamento degli interventi programmati (entro il 31/12/2014, oltre eventuali proroghe)


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
