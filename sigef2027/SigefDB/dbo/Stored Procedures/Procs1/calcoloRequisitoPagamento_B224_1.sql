CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B224_1]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- SALDO  --- requisito modificato mediante richiesta GAL fax - protocollo 0130454|24/02/2014|R_MARCHE|GRM|AEA|A|300.40/2011/AFP/12
--=== -- Data inizio lavori (entro 240 giorni dalla data di ricevimento dell`atto di concessione dell`aiuto, salvo eventuale richiesta motivata di proroga di ulteriori 30 giorni)	===--

--249	Data di ricevimento dell`atto di concessione dell`aiuto notificato dal GAL con PEC.
--250	Proroga di 6 mesi per la fine dei lavori.
--251	Proroga di ulteriori 3 mesi per la fine dei lavori.
--253	Data di ultimazione degli interventi programmati (entro 12 mesi dal ricevimento dell`atto di concessione, più eventuali proroghe)
--254	Data richiesta di saldo (entro 12 mesi dal ricevimento dell`atto di concessione)
--255	Data inizio lavori (entro 240 giorni dalla data di ricevimento dell`atto di concessione dell`aiuto, salvo eventuale richiesta motivata di proroga di ulteriori 30 giorni)

--DECLARE @ID_DOMANDA_PAGAMENTO int
--SET @ID_DOMANDA_PAGAMENTO = 1
DECLARE @ID_PROGETTO INT, 
					@RESULT INT,
					@DIFFERENZA INT,
					@DIFFERENZA_PROROGA DECIMAL (18,2),
					@PROROGA INT
					
-- Data inizio lavori (entro 120 giorni dalla data di ricevimento dell`atto di concessione dell`aiuto				
SELECT @DIFFERENZA = DATEDIFF(DAY, DATEADD(DD,240,(select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where 
														ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 249)
												 ) , (select VAL_DATA from DOMANDA_PAGAMENTO_REQUISITI where
												        ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  and ID_REQUISITO = 255))


							


IF (@DIFFERENZA <= 0) 
SET @RESULT = 1 	
	 ELSE SET @RESULT = 0 	

SELECT @RESULT
END
