create PROCEDURE [dbo].[calcoloRequisitoPagamento_B249_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
---===== Data richiesta di saldo (entro 20 mesi dal ricevimento dell`atto di concessione). =====---

--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--280	Data di ricevimento dell`atto di concessione dell`aiuto notificato dal GAL con PEC.
--285	Data di ultimazione degli interventi programmati
--495	Data di ultimazione degli interventi programmati (entro 20 mesi dal ricevimento dell`atto di concessione)
--496	Data richiesta di saldo (entro 20 mesi dal ricevimento dell`atto di concessione)

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DATA_RICHIESTA_SALDO DATETIME,
					@DATA_COM_FINAN DATETIME


SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO
SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 280
					

-- Data richiesta di saldo (entro 20 mesi dal ricevimento dell`atto di concessione)				
SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,20,(@DATA_COM_FINAN)), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)
 
SELECT @RESULT
END
