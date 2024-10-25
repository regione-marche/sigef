-- SALDO
----------------
--- 524	Data ultimazione interventi programmati
--- 525	Data ultimazione interventi programmati entro e non oltre il 31 luglio 2015
----------------

CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B455_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @RESULT INT, @DATA_ULTI_INTERVENTI DATETIME
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_ULTI_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 524


IF @DATA_ULTI_INTERVENTI <= '2015-07-31' SET @RESULT = 1 	
 ELSE SET @RESULT = 0 	

SELECT @RESULT
END

-----------------
