create PROCEDURE [dbo].[calcoloRequisitoPagamento_B413_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO
-- 204	Data di ricezione della comunicazione di finanziabilità
-- 544	Data inizio interventi programmati
-- 545	Data inizio interventi programmati (6 mesi dal ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)
-- 546	Richiesta proroga per la fine lavori
-- 547	Richiesta di saldo (entro 10 mesi dalla data di ricezione della comunicazione della finanzi abilità oltre eventuali proroghe)
-- 550	Numero mesi di proroga per l’inizio lavori (max 7 mesi)


--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DIFFERENZA_PROROGA DECIMAL (18,2),
					@PROROGA_INIZIO INT
				
SET @PROROGA_INIZIO = (select RPP.CODICE FROM DOMANDA_PAGAMENTO_REQUISITI DPR inner join REQUISITI_PAGAMENTO_PLURIVALORE RPP ON DPR.ID_VALORE = RPP.ID_VALORE
						WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND DPR.ID_REQUISITO = 550)
					
--	Data inizio interventi programmati (6 mesi dal ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(MM,6, DATEADD(MM, ISNULL(@PROROGA_INIZIO,0),(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 204)
												 )) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 544))

IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
