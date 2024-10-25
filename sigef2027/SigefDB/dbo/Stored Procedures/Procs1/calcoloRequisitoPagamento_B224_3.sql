CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B224_3]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
--==== Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione) ===--
----------------modificato dopo fax 0130454|24/02/2014|R_MARCHE|GRM|AEA|A|300.40/2011/AFP/12
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--249	Data di ricevimento dell`atto di concessione dell`aiuto notificato dal GAL con PEC.
--250	Proroga di 6 mesi per la fine dei lavori.
--251	Proroga di ulteriori 3 mesi per la fine dei lavori.
--253	Data di ultimazione degli interventi programmati (entro 15 mesi dal ricevimento dell`atto di concessione, più eventuali proroghe)
--254	Data richiesta di saldo (entro 15 mesi dal ricevimento dell`atto di concessione, più eventuali proroghe)
--255	Data inizio lavori (entro 240 giorni dalla data di ricevimento dell`atto di concessione dell`aiuto, salvo eventuale richiesta motivata di proroga di ulteriori 30 giorni)
----------------
-- Il CdA nella seduta del 07/02/2014 ha modificato i tempi di realizzazione degli interventi del bando in oggetto, i 12 mesi previsti sono passati a 15 mesi
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
SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 249
					
-- Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione, più eventuali proroghe)				
SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 251
SELECT @PROROGA_6=CASE WHEN COUNT(*)>0 THEN 6 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 250
IF(@PROROGA_6 = 0 AND @PROROGA_3>0)SET @RESULT=0 
ELSE BEGIN
  SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,15 +@PROROGA_3+@PROROGA_6 ,(@DATA_COM_FINAN)), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)
 END
SELECT @RESULT
END
