CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B189_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
-------==== Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori) ====------------

--164	Richiesta proroga di 6 mesi per la fine lavori
--165	Richiesta proroga di 3 mesi per la fine lavori
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--210	Richiesta proroga di 90 giorni per l`avvio degli interventi
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati

--- CONTROLLI
--340	Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)
--341	Data inizio interventi programmati (90 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)


--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@PROROGA_3 INT,
		@DATA_RICHIESTA_SALDO DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_6 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO

SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 165
SELECT @PROROGA_6=CASE WHEN COUNT(*)>0 THEN 6 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 164
IF(@PROROGA_6 = 0 AND @PROROGA_3>0)SET @RESULT=0 
ELSE BEGIN
  SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,18 +@PROROGA_3+@PROROGA_6 ,(@DATA_COM_FINAN)), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)
 END
SELECT @RESULT
END
