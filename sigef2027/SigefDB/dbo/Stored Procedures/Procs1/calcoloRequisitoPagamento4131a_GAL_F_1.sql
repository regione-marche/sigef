CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento4131a_GAL_F_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- GAL FERMANO
-- SALDO
-- step : Data inizio interventi programmati (90 giorni dalla comunicazione di finanziabilità + eventuali proroghe)
-- 208	Data di ricezione della comunicazione di finanziabilità
-- 209	Data inizio interventi programmati
-- 210	Richiesta proroga di 90 giorni per l`inizio lavori

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, @RESULT INT,
		@DIFFERENZA INT,@DIFFERENZA_PROROGA DECIMAL (18,2),
		@PROROGA INT
					
-- Data inizio interventi programmati 90 GIORNI dalla data di ricezione della comunicazione di finanziabilità		
SELECT @PROROGA = count(ID_REQUISITO) FROM  DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND ID_REQUISITO = 210

			
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,90,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO =208)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO =209))

-- PROROGATO DI 90 GIORNI
SELECT @DIFFERENZA_PROROGA = DATEDIFF(DAY, DATEADD(DD,180,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 208)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 209)) 

							
IF (((@DIFFERENZA <= 0) AND (@PROROGA = 0)) OR ((@DIFFERENZA_PROROGA <= 0) AND (@PROROGA = 1)))SET @RESULT = 1 	
ELSE SET @RESULT = 0 	

SELECT @RESULT
END
