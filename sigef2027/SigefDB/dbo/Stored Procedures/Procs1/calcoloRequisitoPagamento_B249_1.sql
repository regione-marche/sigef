-- SALDO --
-------====================== Data di ultimazione degli interventi programmati (entro 21 mesi dal ricevimento dell`atto di concessione) ======================-------

--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--280	Data di ricevimento dell`atto di concessione dell`aiuto notificato dal GAL con PEC.
--285	Data di ultimazione degli interventi programmati
--495	Data di ultimazione degli interventi programmati (entro 20 mesi dal ricevimento dell`atto di concessione)
--496	Data richiesta di saldo (entro 20 mesi dal ricevimento dell`atto di concessione)

CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B249_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @RESULT INT,
		@DATA_ULTIMAZIONE_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 280
SELECT @DATA_ULTIMAZIONE_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 285

 SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,20,(@DATA_COM_FINAN)), @DATA_ULTIMAZIONE_INTERVENTI)<=0 THEN 1 ELSE 0 END)

SELECT @RESULT
END

-----------------=======================================================================================================================================-----------------
