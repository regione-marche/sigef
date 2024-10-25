CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B218_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
--==== Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione) ===--
--204 Data di ricezione della comunicazione di finanziabilità
--206 Numero mesi di proroga richiesti per la fine lavori
--270 Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DATA_COM_FINAN DATETIME, 
					@PROROGA INT
					
SELECT @PROROGA = (select RPP.CODICE FROM DOMANDA_PAGAMENTO_REQUISITI DPR inner join REQUISITI_PAGAMENTO_PLURIVALORE RPP ON DPR.ID_VALORE = RPP.ID_VALORE
						WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND DPR.ID_REQUISITO = 206)

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
					
-- Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)				
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(MM,18 + ISNULL(@PROROGA,0),(@DATA_COM_FINAN)) , (select DATA_MODIFICA from DOMANDA_DI_PAGAMENTO where ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO))
	
IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
