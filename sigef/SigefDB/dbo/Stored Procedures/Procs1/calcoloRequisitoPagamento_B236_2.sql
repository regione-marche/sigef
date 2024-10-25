CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B236_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
-------==== Richiesta di saldo (entro 12 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori) ====------------
--new
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati
--* 266	Richiesta di saldo (entro 12 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)
--* 408	Data inizio interventi programmati (entro 6 mesi dalla data di ricezione della comunicazione di finanziabilità oltre eventuale proroga)
--409	Richiesta proroga di 4 mesi per la fine lavori
--410	Richiesta proroga di 2 mesi per la fine lavori
--411	Proroga di 90 giorni per l`inizio dei lavori

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@PROROGA_2 INT,
		@DATA_RICHIESTA_SALDO DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_4 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO

SELECT @PROROGA_2=CASE WHEN COUNT(*)>0 THEN 2 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 410
SELECT @PROROGA_4=CASE WHEN COUNT(*)>0 THEN 4 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 409
IF(@PROROGA_4 = 0 AND @PROROGA_2>0)SET @RESULT=0 
ELSE BEGIN
  SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,12 +@PROROGA_2+@PROROGA_4 ,(@DATA_COM_FINAN)), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)
 END
SELECT @RESULT
END
