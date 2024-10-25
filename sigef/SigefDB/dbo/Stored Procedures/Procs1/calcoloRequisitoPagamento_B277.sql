-- SALDO
--=== Data inizio interventi programmati (6 mesi dal ricevimento della comunicazione di finanziabilità oltre eventuali proroghe per un massimo di ulteriori 8 mesi) ===--

--204 Data di ricezione della comunicazione di finanziabilità
--418 Data inizio interventi programmati (180 giorni dal ricevimento della comunicazione di finanziabilità oltre eventuali proroghe per un massimo di ulteriori 8 mesi)
--419 Data inizio interventi programmati
--415 Proroga per l’inizio lavori (max 8 mesi)

--239 Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242 Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--409 Richiesta proroga di 4 mesi per la fine lavori

--416 Richiesta proroga di ulteriori 2 mesi per la fine lavori
--417 Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori per un massimo di 6 mesi)


CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B277]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,
		@DATA_INIZIO_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_8 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
SELECT @DATA_INIZIO_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 419
SELECT @PROROGA_8=CASE WHEN COUNT(*)>0 THEN 8 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 415

SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY,DATEADD(MM, @PROROGA_8, DATEADD(MM,6,(@DATA_COM_FINAN))), @DATA_INIZIO_INTERVENTI)<=0 THEN 1 ELSE 0 END)

SELECT @RESULT
END

-----------------
