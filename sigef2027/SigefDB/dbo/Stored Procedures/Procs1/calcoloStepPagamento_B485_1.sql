-- QUESTO E' UNO STEP DI SALDO
-------===== Fine lavori entro il 31/08/2015 ===---------


--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--540	Richiesta proroga di 15 giorni per l`avvio degli interventi
--542	Data inizio interventi programmati (15 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)     (requisito di controllo)
----- 541	--541	Fine lavori e richiesta di saldo entro il 31/08/2015    (requisito di controllo)

--------------------------------------------------------------------
--260	Data fine interventi programmati    (requisito di inserimento)
--------------------------------------------------------------------

CREATE PROCEDURE [dbo].[calcoloStepPagamento_B485_1] 
@IdProgetto int,
@IdDomandaPagamento int =NULL
AS
BEGIN

DECLARE @CODICE INT,@RESULT INT,@PROROGA_3 INT,@DATA_FINE_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_6 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_FINE_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento AND ID_REQUISITO = 260

SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY,'2015-08-31', @DATA_FINE_INTERVENTI)<=0 THEN 1 ELSE 0 END)
 
SELECT @RESULT
END
