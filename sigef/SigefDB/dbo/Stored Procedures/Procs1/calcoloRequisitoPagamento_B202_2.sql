-- SALDO
--=== Data di completamento degli interventi programmati (entro il 31/12/2014, oltre eventuali proroghe) ===--

-- new
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--206	Numero mesi di proroga richiesti per la fine lavori
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati
--298	Data inizio interventi programmati (entro 90 gg. dalla data del ricevimento della comunicazione di finanzi abilità, oltre eventuali proroghe)
--299	Data di completamento degli interventi programmati (entro il 31/12/2014, oltre eventuali proroghe) 

CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B202_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, 
		@RESULT INT,
		@PROROGA INT,
		@DIFFERENZA INT,
		@DATA_IMPOSTA DATETIME,
		@DATA_FINE_INT DATETIME
		
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		
--- Data di completamento degli interventi programmati (entro il 31/12/2014, oltre eventuali proroghe) 

-- declare @ID_DOMANDA_PAGAMENTO int = 
SELECT @DATA_IMPOSTA = '2014-12-31 00:00:00.000' -- Data di completamento degli interventi programmati (entro il 31/12/2014, oltre eventuali proroghe) 

SET @PROROGA = (select RPP.CODICE FROM DOMANDA_PAGAMENTO_REQUISITI DPR inner join REQUISITI_PAGAMENTO_PLURIVALORE RPP ON DPR.ID_VALORE = RPP.ID_VALORE
						WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND DPR.ID_REQUISITO = 206)

SET @DATA_FINE_INT = (SELECT VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 260)

SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(MM,@PROROGA ,(@DATA_IMPOSTA)),(@DATA_FINE_INT))

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0
END
SELECT @RESULT
