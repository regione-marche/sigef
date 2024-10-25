CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B240_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
--=== Data di completamento degli interventi programmati (18 mesi dal ricevimento della comunicazione di finanziabilità oltre eventuali proroghe) ===--

-- new
--new
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--206	Numero mesi di proroga richiesti per la fine lavori
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati
--286	Data inizio interventi programmati (180 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)
--287	Data di completamento degli interventi programmati (18 mesi dal ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)
--302	Numero mesi di proroga richiesti per l`inizio dei lavori


--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1

DECLARE @ID_PROGETTO INT, 
		@CODICE INT,
		@RESULT INT,
		@PROROGA INT,
		@DATA_FINE_INT DATETIME,
		@DATA_COM_FINAN DATETIME

SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SET @DATA_COM_FINAN = (SELECT VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204)
SET @DATA_FINE_INT = (SELECT VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 260)

SET @PROROGA = (select RPP.CODICE FROM DOMANDA_PAGAMENTO_REQUISITI DPR inner join REQUISITI_PAGAMENTO_PLURIVALORE RPP ON DPR.ID_VALORE = RPP.ID_VALORE
						WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND DPR.ID_REQUISITO = 206)

SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,18 + ISNULL(@PROROGA,0) ,(@DATA_COM_FINAN)), @DATA_FINE_INT)<=0 THEN 1 ELSE 0 END)
 
SELECT @RESULT
END
