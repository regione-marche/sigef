CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B214_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
-------==== Data inizio interventi programmati (120 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe) ====------------

--164	Richiesta proroga di 6 mesi per la fine lavori
--165	Richiesta proroga di 3 mesi per la fine lavori
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati
--328	Proroga di 60 giorni per l`inizio dei lavori
--335	Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)
--336	Data inizio interventi programmati (120 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@PROROGA_3 INT,
		@DATA_INIZIO_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_60 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
SELECT @DATA_INIZIO_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 205
SELECT @PROROGA_60=CASE WHEN COUNT(*)>0 THEN 60 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 328

SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY,DATEADD(DD, @PROROGA_60, DATEADD(DD,120,(@DATA_COM_FINAN))), @DATA_INIZIO_INTERVENTI)<=0 THEN 1 ELSE 0 END)

SELECT @RESULT
END

-----------------
