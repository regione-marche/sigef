-- QUESTO E' UNO STEP DI SALDO
-- Data di ultimazione degli interventi programmati (18 mesi dal ricevimento della comunicazione di finanziabilità  + eventuali proroghe)


--- ELENCO REQUISITI PAGAMENTO
--165	Richiesta proroga di 3 mesi per la fine lavori
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--210	Richiesta proroga di 90 giorni per l`avvio degli interventi
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati
--343	Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)
--344	Data inizio interventi programmati (90 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)


CREATE PROCEDURE [dbo].[calcoloStepPagamento4131a_GAL_F] 
@IdProgetto int,
@IdDomandaPagamento int =NULL
AS
BEGIN

DECLARE @CODICE INT,@RESULT INT,@PROROGA_3 INT,
		@DATA_FINE_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_6 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento AND ID_REQUISITO = 204
SELECT @DATA_FINE_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  AND ID_REQUISITO = 260
SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  AND ID_REQUISITO = 165

SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,18 +@PROROGA_3 ,(@DATA_COM_FINAN)), @DATA_FINE_INTERVENTI)<=0 THEN 1 ELSE 0 END)
 
SELECT @RESULT
END
