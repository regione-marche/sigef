﻿-- 180	Data di ricezione della comunicazione di finanziabilità
-- 179	Data inizio interventi programmati
-- 181	Richiesta proroga di 6 MESI per la fine lavori
-- 182	Richiesta proroga di ULTERIORI 3 MESI per la fine lavori
-- 183	Data effettiva di ultimazione interventi programmati (max 18 mesi dalla ricezione della comunicazione di finamziabilità più eventuali 6/3 mesi di proroga)


CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento4131_FL_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@PROROGA_3 INT,
		@DATA_FINE_INTERVENTI DATETIME,@DATA_COM_FINAN DATETIME, @PROROGA_6 INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_COM_FINAN = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 180
SELECT @DATA_FINE_INTERVENTI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 183
SELECT @PROROGA_3=CASE WHEN COUNT(*)>0 THEN 3 ELSE 0 END FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO =182
SELECT @PROROGA_6=CASE WHEN COUNT(*)>0 THEN 6 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO =181
IF(@PROROGA_6 = 0 AND @PROROGA_3>0)SET @RESULT=0 
ELSE BEGIN
  SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(MM,18 +@PROROGA_3+@PROROGA_6 ,(@DATA_COM_FINAN)), @DATA_FINE_INTERVENTI)<=0 THEN 1 ELSE 0 END)
 END
SELECT @RESULT
END