-- SALDO
--=== Data ultimazione interventi programmati (entro 18 mesi dalla data di ricezione dell’atto di concessione dell’aiuto oltre eventuali proroghe) ===--

--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--320	Proroga di 6 mesi per la fine dei lavori.
--321	Data di ultimazione degli interventi programmati
--322	Data ultimazione interventi programmati (entro 18 mesi dalla data di ricezione dell’atto di concessione dell’aiuto oltre eventuali proroghe)
--323	Data richiesta saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe)


CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B213_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@DATA_FINE_LAVORI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_6 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
SELECT @DATA_FINE_LAVORI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 321

SELECT @PROROGA_6=CASE WHEN COUNT(*)>0 THEN 6 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 320

SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,18 + @PROROGA_6 ,(@DATA_COM_FINAN)), @DATA_FINE_LAVORI)<=0 THEN 1 ELSE 0 END)
 
SELECT @RESULT
END

-----------------
