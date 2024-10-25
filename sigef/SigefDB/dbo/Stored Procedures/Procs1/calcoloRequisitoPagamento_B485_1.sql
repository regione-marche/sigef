CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B485_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
-------==== Data inizio interventi programmati (15 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe) ====------------

--204	Data di ricezione della comunicazione di finanziabilità

--205	Data inizio interventi programmati
--540	Richiesta proroga di 15 giorni per l`avvio degli interventi
--542	Data inizio interventi programmati (15 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)

--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati

--541	Fine lavori e richiesta di saldo entro il 31/08/2015


--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT, @DATA_INIZIO_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_15 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
SELECT @DATA_INIZIO_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 205
SELECT @PROROGA_15=CASE WHEN COUNT(*)>0 THEN 15 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 540

SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY,DATEADD(DD, @PROROGA_15, DATEADD(DD,15,(@DATA_COM_FINAN))), @DATA_INIZIO_INTERVENTI)<=0 THEN 1 ELSE 0 END)

SELECT @RESULT
END

-----------------
