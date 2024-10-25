CREATE PROCEDURE [dbo].[calcoloStepPagamento_B485]
@IdProgetto int,
@IdDomandaPagamento int =NULL
AS
BEGIN

-- GAL FERMANO
-- SALDO
-- step : Data inizio interventi programmati (15 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroga di 15 giorni)

--205	Data inizio interventi programmati
--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati
--541	Fine lavori e richiesta di saldo entro il 31/08/2015

---------------------------------------------------------------------------
------ 542	Data inizio interventi programmati (15 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroga di 15 giorni)   

--204	Data di ricezione della comunicazione di finanziabilità
--540	Richiesta proroga di 15 giorni per l`avvio degli interventi
---------------------------------------------------------------------------


--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @RESULT INT,@DIFFERENZA INT,
		@DIFFERENZA_PROROGA DECIMAL (18,2),@PROROGA INT
									
SELECT @PROROGA = count(ID_REQUISITO) FROM  DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  AND ID_REQUISITO = 540					
					
-- Data inizio interventi programmati (15 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroga di 15 giorni				
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,15,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  and ID_REQUISITO =204))
							 , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  and ID_REQUISITO =205))

-- PROROGATO DI 15 GIORNI
SELECT @DIFFERENZA_PROROGA = DATEDIFF(DAY, DATEADD(DD,30,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  and ID_REQUISITO = 204)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  and ID_REQUISITO = 205)) 
							
IF (((@DIFFERENZA <= 0) AND (@PROROGA = 0)) OR ((@DIFFERENZA_PROROGA <= 0) AND (@PROROGA = 1))) SET @RESULT = 1 	
ELSE SET @RESULT = 0 	

SELECT @RESULT
END
