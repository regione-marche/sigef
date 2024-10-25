-- requisito aggiornato il 09/09/2014 con protocollo 0634964|08/09/2014|R_MARCHE|GRM|AEA|A|300.40/2011/AFP/12

-- SALDO
--=== Data di ultimazione degli interventi programmati (entro 12 mesi dal ricevimento dell`atto di concessione) ===--

--243	Proroga di ulteriori 3 mesi per la fine dei lavori.
--244	Proroga di 6 mesi per la fine dei lavori. --- TOLTO
--245	Data inizio lavori (entro 120 giorni dalla data di ricevimento dell`atto di concessione dell`aiuto)
--246	Data di ricevimento dell`atto di concessione dell`aiuto notificato dal GAL con PEC.
--247	Data di ultimazione degli interventi programmati (entro 18 mesi dal ricevimento dell`atto di concessione, più eventuale proroga di 3 mesi)
--248	Data richiesta di saldo (entro 18 mesi dal ricevimento dell`atto di concessione, più eventuale proroga di tre mesi)

CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B230_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@PROROGA_3 INT,
		@DATA_FINE_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_6 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 246
SELECT @DATA_FINE_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 247
SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 243

  SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,18 +@PROROGA_3 ,(@DATA_COM_FINAN)), @DATA_FINE_INTERVENTI)<=0 THEN 1 ELSE 0 END)
 SELECT @RESULT
END

-----------------
