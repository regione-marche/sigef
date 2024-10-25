CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B407_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
-------===== Richiesta di saldo (entro 12 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuale proroga di 3 mesi) ===---------

--208	Data di ricezione della comunicazione di finanziabilità
--459	Data inizio interventi programmati
--455	Data inizio interventi programmati (60 giorni dalla comunicazione di finanziabilità)

--214	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta

--456	Proroga di 3 mesi per la fine dei lavori
--458	Richiesta di saldo (entro 12 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuale proroga di 3 mesi)

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1

DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@PROROGA_3 INT,
					@DATA_RICHIESTA_SALDO DATETIME,
					@DATA_COM_FINAN DATETIME

SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO
SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 208
					
SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 456

-- Richiesta di saldo (entro 12 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuale proroga di 3 mesi) 
SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,12 +@PROROGA_3,(@DATA_COM_FINAN)), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)
 
SELECT @RESULT
END
