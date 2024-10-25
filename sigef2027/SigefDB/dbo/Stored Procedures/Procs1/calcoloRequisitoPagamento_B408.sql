create PROCEDURE [dbo].[calcoloRequisitoPagamento_B408]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
-------==== Data inizio interventi programmati (120 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe) ====------------

--204 Data di ricezione della comunicazione di finanziabilità
--205 Data inizio interventi programmati
--528 Proroga di 30 giorni per l`inizio dei lavori
--530 Data inizio interventi programmati (120 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1

DECLARE @ID_PROGETTO INT, @RESULT INT, @DATA_INIZIO_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_30 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
SELECT @DATA_INIZIO_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 205
SELECT @PROROGA_30=CASE WHEN COUNT(*)>0 THEN 30 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 528

SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY,DATEADD(DD, @PROROGA_30, DATEADD(DD,120,(@DATA_COM_FINAN))), @DATA_INIZIO_INTERVENTI)<=0 THEN 1 ELSE 0 END)

SELECT @RESULT
END

-----------------
