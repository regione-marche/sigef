-- SALDO -- GAL SIBILLA -- misura 4131b
-------====================== Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione, più eventuali proroghe) ======================-------

--226	Data inizio lavori
--307	Ulteriore proroga di  3 mesi quando il valore dei lavori realizzati e pagati sia pari o superiore al 85% dell’importo totale degli investimenti  ammessi.
--308	Proroga di 6 mesi quando il valore dei lavori realizzati e pagati, sia pari o superiore al 60% dell’importo totale degli investimenti ammessi;
--309	Data di ricevimento dell`atto di concessione dell`aiuto notificato dal GAL con PEC.
--311	Data di ultimazione degli interventi programmati (entro 12 mesi dal ricevimento dell`atto di concessione, più eventuali proroghe)
--313	Data di ultimazione degli interventi programmati

--312	Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione, più eventuali proroghe)

CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B221_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@PROROGA_3 INT,
		@DATA_RICHIESTA_SALDO DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_6 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 309
SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO

SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 307
SELECT @PROROGA_6=CASE WHEN COUNT(*)>0 THEN 6 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 308
IF(@PROROGA_6 = 0 AND @PROROGA_3>0)SET @RESULT=0 
ELSE BEGIN
  SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,12 +@PROROGA_3+@PROROGA_6 ,(@DATA_COM_FINAN)), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)
 END
SELECT @RESULT
END

-----------------=======================================================================================================================================-----------------
