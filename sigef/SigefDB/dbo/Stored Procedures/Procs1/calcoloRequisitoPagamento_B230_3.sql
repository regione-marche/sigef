CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B230_3]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
--==== Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione) ===--
-- è diventato --> Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione, più eventuali proroghe)
-- controllo modificato a fronte fax  0130454|24/02/2014|R_MARCHE|GRM|AEA|A|300.40/2011/AFP/12

--243	Proroga di ulteriori 3 mesi per la fine dei lavori.
--244	Proroga di 6 mesi per la fine dei lavori.
--245	Data inizio lavori (entro 120 giorni dalla data di ricevimento dell`atto di concessione dell`aiuto)
--246	Data di ricevimento dell`atto di concessione dell`aiuto notificato dal GAL con PEC.
--247	Data di ultimazione degli interventi programmati (entro 18 mesi dal ricevimento dell`atto di concessione, più eventuale proroga di 3 mesi)
--248	Data richiesta di saldo (entro 18 mesi dal ricevimento dell`atto di concessione, più eventuale proroga di tre mesi)

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@PROROGA_3 INT,
					@DATA_RICHIESTA_SALDO DATETIME,
					@DATA_COM_FINAN DATETIME


SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO
SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 246
					
-- Data richiesta di saldo (entro 18 mesi dal ricevimento dell`atto di concessione, più eventuale proroga di tre mesi)			
SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 243

  SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,18 +@PROROGA_3,(@DATA_COM_FINAN)), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)

SELECT @RESULT
END
