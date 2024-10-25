create PROCEDURE [dbo].[calcoloRequisitoPagamento_B215]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SAL
--221	relazione descrittiva da cui emerga la conformità con il progetto e con il cronoprogramma approvati, corredata della documentazione prodotta (copia) e delle altre spese previste nel paragrafo 7 del bando;
--222	data di ricezione della comunicazione della finanziabilità
--223	Data inizio interventi programmati (30 giorni dalla comunicazione di finanziabilità)

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DIFFERENZA_PROROGA DECIMAL (18,2),
					@PROROGA INT
					
-- Data inizio interventi programmati 120 GIORNI dalla data di ricezione della comunicazione di finanziabilità					
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,30,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 222)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 223))

				
IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
