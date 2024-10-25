-- Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuale proroga di 3 mesi per la fine lavori) --

--180	Data di ricezione della comunicazione di finanziabilità
--182	Proroga di ulteriori 3 mesi per la fine dei lavori
--205	Data inizio interventi programmati
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--384	Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuale proroga di 3 mesi per la fine lavori)
--385	Data inizio interventi programmati (entro 90 giorni dalla data di ricezione della comunicazione di finanziabilità)

CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B244_337_362_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@PROROGA_3 INT,
		@DATA_RICHIESTA_SALDO DATETIME,@DATA_COM_FINAN DATETIME
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 180
SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO

SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO =182

 SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,18 +@PROROGA_3 ,(@DATA_COM_FINAN)), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)
 
SELECT @RESULT
END
