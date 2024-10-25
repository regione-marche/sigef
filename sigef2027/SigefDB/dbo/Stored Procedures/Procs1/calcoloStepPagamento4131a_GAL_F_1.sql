CREATE PROCEDURE [dbo].[calcoloStepPagamento4131a_GAL_F_1]
@IdProgetto int,
@IdDomandaPagamento int =NULL
AS
BEGIN

-- GAL FERMANO
-- SALDO
-- step : Data inizio interventi programmati (90 giorni dalla comunicazione di finanziabilità + eventuali proroghe)


--- REQUISITI PAGAMENTO
--165	Richiesta proroga di 3 mesi per la fine lavori
--204	Data di ricezione della comunicazione di finanziabilità
--205	Data inizio interventi programmati
--210	Richiesta proroga di 90 giorni per l`avvio degli interventi
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati
--343	Richiesta di saldo (entro 18 mesi dalla data di ricezione della comunicazione della finanziabilità oltre eventuali proroghe per la fine lavori)
--344	Data inizio interventi programmati (90 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)


--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @RESULT INT,@DIFFERENZA INT,
		@DIFFERENZA_PROROGA DECIMAL (18,2),@PROROGA INT
					
					
SELECT @PROROGA = count(ID_REQUISITO) FROM  DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  AND ID_REQUISITO = 210					
					
-- Data inizio interventi programmati 90 GIORNI dalla data di ricezione della comunicazione di finanziabilità					
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,90,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  and ID_REQUISITO =204))
							 , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  and ID_REQUISITO =205))

-- PROROGATO DI 90 GIORNI
SELECT @DIFFERENZA_PROROGA = DATEDIFF(DAY, DATEADD(DD,180,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  and ID_REQUISITO = 204)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  and ID_REQUISITO = 205)) 

							
IF (((@DIFFERENZA <= 0) AND (@PROROGA = 0)) OR ((@DIFFERENZA_PROROGA <= 0) AND (@PROROGA = 1))) SET @RESULT = 1 	
ELSE SET @RESULT = 0 	

SELECT @RESULT
END
