CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B213_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
-------==== Data richiesta saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe) ====------------

--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--320	Proroga di 6 mesi per la fine dei lavori.
--321	Data di ultimazione degli interventi programmati
--322	Data ultimazione interventi programmati (entro 18 mesi dalla data di ricezione dell’atto di concessione dell’aiuto oltre eventuali proroghe)
--323	Data richiesta saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe)

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DATA_COM_FINAN DATETIME, 
					@PROROGA_6 INT
					
SELECT @PROROGA_6=CASE WHEN COUNT(*)>0 THEN 6 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 320

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
					
-- Data richiesta saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe)
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(MM,18 + @PROROGA_6,(@DATA_COM_FINAN)) , (select DATA_MODIFICA from DOMANDA_DI_PAGAMENTO where ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO))
	
IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
