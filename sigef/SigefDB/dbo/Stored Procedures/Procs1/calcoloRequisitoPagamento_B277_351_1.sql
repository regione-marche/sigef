CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B277_351_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
--==== Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione) ===--
-- 204 Data di ricezione della comunicazione di finanziabilità
-- 409 Richiesta proroga di 4 mesi per la fine lavori
-- 416 Richiesta proroga di ulteriori 2 mesi per la fine lavori
-- 417 Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori per un massimo di 6 mesi)

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DATA_COM_FINAN DATETIME, 
					@PROROGA_2 INT, @PROROGA_4 INT
					
SELECT @PROROGA_2=CASE WHEN COUNT(*)>0 THEN 2 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 416
SELECT @PROROGA_4=CASE WHEN COUNT(*)>0 THEN 4 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 409

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
					
-- Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori per un massimo di 6 mesi)
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(MM,18 + @PROROGA_4 + @PROROGA_2,(@DATA_COM_FINAN)) , (select DATA_MODIFICA from DOMANDA_DI_PAGAMENTO where ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO))
	
IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
