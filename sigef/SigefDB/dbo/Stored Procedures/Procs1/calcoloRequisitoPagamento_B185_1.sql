-- SALDO
--=== Data di ultimazione degli interventi programmati (entro 12 mesi dal ricevimento dell`atto di concessione) ===--

-- 204	Data di ricezione della comunicazione di finanziabilità
-- 205	Data inizio inteventi programmati
-- 206	Numero mesi di proroga richiesti per la fine lavori
-- 242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
-- 258	Data inizio interventi programmati (90 giorni dal ricevimento della comunicazione di finanziabilità)
-- 259	Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità)
-- 260	Data fine interventi programmati


-- Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità)
create PROCEDURE [dbo].[calcoloRequisitoPagamento_B185_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@DATA_FINE_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 204
SELECT @PROROGA = (select RPP.CODICE FROM DOMANDA_PAGAMENTO_REQUISITI DPR inner join REQUISITI_PAGAMENTO_PLURIVALORE RPP ON DPR.ID_VALORE = RPP.ID_VALORE WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND DPR.ID_REQUISITO = 206)

SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,18 + ISNULL(@PROROGA,0) ,(@DATA_COM_FINAN)), (select DATA_MODIFICA from DOMANDA_DI_PAGAMENTO where ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO))<=0 THEN 1 ELSE 0 END)

SELECT @RESULT
END
