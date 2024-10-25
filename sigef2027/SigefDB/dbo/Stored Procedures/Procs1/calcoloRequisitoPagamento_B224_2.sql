-- SALDO
--=== Data di ultimazione degli interventi programmati (entro 12 mesi dal ricevimento dell`atto di concessione) ===--
----------------
--249	Data di ricevimento dell`atto di concessione dell`aiuto notificato dal GAL con PEC.
--250	Proroga di 6 mesi per la fine dei lavori.
--251	Proroga di ulteriori 3 mesi per la fine dei lavori.
--253	Data di ultimazione degli interventi programmati (entro 12 mesi dal ricevimento dell`atto di concessione)
--254	Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione)
--255	Data inizio lavori (entro 120 giorni dalla data di ricevimento dell`atto di concessione dell`aiuto)
----------------

CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B224_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@PROROGA_3 INT,
		@DATA_FINE_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_6 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 249
SELECT @DATA_FINE_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 253
SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 251
SELECT @PROROGA_6=CASE WHEN COUNT(*)>0 THEN 6 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 250
IF(@PROROGA_6 = 0 AND @PROROGA_3>0)SET @RESULT=0 
ELSE BEGIN
  SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,12 +@PROROGA_3+@PROROGA_6 ,(@DATA_COM_FINAN)), @DATA_FINE_INTERVENTI)<=0 THEN 1 ELSE 0 END)
 END
SELECT @RESULT
END

-----------------
