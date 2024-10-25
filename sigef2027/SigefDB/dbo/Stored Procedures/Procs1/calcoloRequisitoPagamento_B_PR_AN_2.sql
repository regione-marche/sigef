CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B_PR_AN_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN


----==== Richiesta di saldo (entro 15 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori) ====----
-- SALDO
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
---

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1

DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@PROROGA_3 INT,
					@PROROGA_6 INT,
					@DATA_RICHIESTA_SALDO DATETIME,
					@DATA_COM_FINAN DATETIME

SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO
SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
					
-- Richiesta di saldo (entro 15 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)
SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 441
SELECT @PROROGA_6=CASE WHEN COUNT(*)>0 THEN 6 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 440
IF(@PROROGA_6 = 0 AND @PROROGA_3>0)SET @RESULT=0 
ELSE BEGIN
  SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,15 +@PROROGA_3+@PROROGA_6 ,(@DATA_COM_FINAN)), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)
 END
SELECT @RESULT
END
