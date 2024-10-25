CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B406_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
-------===== Richiesta di saldo (entro 12 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori) ===---------
--204	Data di ricezione della comunicazione di finanziabilità
--165	Richiesta proroga di 3 mesi per la fine lavori

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1

DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@PROROGA INT,
					@DATA_RICHIESTA_SALDO DATETIME,
					@DATA_COM_FINAN DATETIME

SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO
SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
					
-- Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione, più eventuali proroghe)				
SELECT @PROROGA=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 165
  SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,12 + ISNULL(@PROROGA, 0)  ,(@DATA_COM_FINAN)), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)
SELECT @RESULT
END
