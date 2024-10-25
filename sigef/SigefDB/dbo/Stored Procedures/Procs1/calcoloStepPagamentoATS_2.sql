﻿CREATE PROCEDURE [dbo].[calcoloStepPagamentoATS_2]
 @IdProgetto INT,
 @IdDomandaPagamento INT
AS
BEGIN

--ATS - Spese generali  capitolo 6 par E inferiori/uguale al 12% delle spese A+B+C+D
--DECLARE @IdDomandaPagamento int
--SET @IdDomandaPagamento = 1050

DECLARE @result INT,@IMPORTO_AMMESSO DECIMAL(18,2),@IMPORTO_DOMANDA_ATTUALE DECIMAL(18,2),
	@IMPORTO_DOMANDA_ATTUALE_E DECIMAL(18,2), @IMPORTO_AMMESSO_E DECIMAL (18,2)

SET @result =1 -- PONGO LO STEP VERIFICATO 
SET @IMPORTO_AMMESSO=(SELECT ISNULL(SUM(ISNULL(PB.IMPORTO_AMMESSO, 0) + ISNULL(PB.SPESA_TECNICA_AMMESSA, 0)), 0) AS Expr1
					  FROM PAGAMENTI_BENEFICIARIO AS PB INNER JOIN
					       pAGAMENTI_RICHIESTI AS PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO INNER JOIN
						   PIANO_INVESTIMENTI AS INV ON PR.ID_INVESTIMENTO = INV.ID_INVESTIMENTO
					  WHERE (PR.ID_DOMANDA_PAGAMENTO IN (SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO !=@IdDomandaPagamento AND ID_PROGETTO = @IdProgetto AND APPROVATA = 1 AND ANNULLATA = 0))AND   
							ID_DETTAGLIO_INVESTIMENTO NOT IN (722,727,732,737,742))	

 SET @IMPORTO_DOMANDA_ATTUALE=(SELECT ISNULL(SUM(ISNULL(PB.IMPORTO_RICHIESTO, 0) + ISNULL(PB.SPESA_TECNICA_RICHIESTA, 0)), 0) AS Expr1
							   FROM PAGAMENTI_BENEFICIARIO AS PB INNER JOIN
									 PAGAMENTI_RICHIESTI AS PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO INNER JOIN
									 PIANO_INVESTIMENTI AS INV ON PR.ID_INVESTIMENTO = INV.ID_INVESTIMENTO
							   WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento AND ID_DETTAGLIO_INVESTIMENTO NOT IN (722,727,732,737,742))	
							   
SET @IMPORTO_AMMESSO_E=(SELECT ISNULL(SUM(ISNULL(PB.IMPORTO_AMMESSO, 0) + ISNULL(PB.SPESA_TECNICA_AMMESSA, 0)), 0) AS Expr1
						FROM PAGAMENTI_BENEFICIARIO AS PB INNER JOIN
						      PAGAMENTI_RICHIESTI AS PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO INNER JOIN
						      PIANO_INVESTIMENTI AS INV ON PR.ID_INVESTIMENTO = INV.ID_INVESTIMENTO
						WHERE (PR.ID_DOMANDA_PAGAMENTO IN  (SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO !=@IdDomandaPagamento AND ID_PROGETTO = @IdProgetto AND APPROVATA = 1 AND ANNULLATA = 0))AND   
							  ID_DETTAGLIO_INVESTIMENTO IN (722,727,732,737,742))	

 SET @IMPORTO_DOMANDA_ATTUALE_E=(SELECT ISNULL(SUM(ISNULL(PB.IMPORTO_RICHIESTO, 0) + ISNULL(PB.SPESA_TECNICA_RICHIESTA, 0)), 0) AS Expr1
								 FROM PAGAMENTI_BENEFICIARIO AS PB INNER JOIN
									PAGAMENTI_RICHIESTI AS PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO INNER JOIN
									PIANO_INVESTIMENTI AS INV ON PR.ID_INVESTIMENTO = INV.ID_INVESTIMENTO
								WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento AND ID_DETTAGLIO_INVESTIMENTO IN (722,727,732,737,742))	

IF((ISNULL(@IMPORTO_AMMESSO_E,0)+ISNULL(@IMPORTO_DOMANDA_ATTUALE_E,0)) > (@IMPORTO_DOMANDA_ATTUALE+ @IMPORTO_AMMESSO)*0.12 )SET @result =0 
SELECT @result AS RESULT
END
