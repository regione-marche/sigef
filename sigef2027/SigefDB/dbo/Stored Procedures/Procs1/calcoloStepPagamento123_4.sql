CREATE  PROCEDURE [dbo].[calcoloStepPagamento123_4]
@IdProgetto int,
@IdDomandaPagamento int =NULL
AS
BEGIN
DECLARE @TotaleInvestimenti decimal(18,2),
		@IMPORTO_AMMESSO decimal(18,2),
		@IMPORTO_AMMESSO_ATTUALE decimal (18,2),
		@TotaleInvestimentiPrioritaAttuale decimal(18,2),
		@TotaleInvestimentiPrioritaAmmesso decimal(18,2) 
--		 
--DECLARE  @IdProgetto int , @IdDomandaPagamento int
--SET @IdDomandaPagamento =3
--SET @IdProgetto = 1673
 	
	-- Totale investimenti fase "PAGAMENTO" SALDO
	-- COSTO INVESTIMENTO AMMESSO NELLE DOMANDE PRECEDENTI

	SET @IMPORTO_AMMESSO = (SELECT  SUM( ISNULL( PR.IMPORTO_AMMESSO,0 ))
							FROM PAGAMENTI_RICHIESTI PR 
							WHERE ID_DOMANDA_PAGAMENTO  IN (SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO 
															WHERE ID_PROGETTO = @IdProgetto AND APPROVATA = 1 AND ANNULLATA =0 AND ID_DOMANDA_PAGAMENTO < @IdDomandaPagamento) 			 
															)	
 
	SET @IMPORTO_AMMESSO_ATTUALE = (SELECT SUM(ISNULL( PR.IMPORTO_AMMESSO,0 )) FROM  PAGAMENTI_RICHIESTI PR WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento     )	
 
	-- Investimenti volti al miglioramento globale dell'azienda (PRIORITA 116)
	SET @TotaleInvestimentiPrioritaAmmesso = (
										SELECT SUM( ISNULL( PR.IMPORTO_AMMESSO,0))
										FROM PAGAMENTI_RICHIESTI PR  
										WHERE ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA =116)																	    
										AND ID_DOMANDA_PAGAMENTO IN 
											( SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO WHERE APPROVATA = 1 AND ID_PROGETTO= @IdProgetto  AND ANNULLATA =0  AND ID_DOMANDA_PAGAMENTO < @IdDomandaPagamento 	)	  )

 	SET @TotaleInvestimentiPrioritaAttuale = (										 
										SELECT SUM( ISNULL( PR.IMPORTO_AMMESSO,0))
										FROM PAGAMENTI_RICHIESTI PR WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento 
												AND ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA =116))
	--	SELECT @TotaleInvestimentiPrioritaAttuale
	IF ((isnull(@TotaleInvestimentiPrioritaAttuale,0) + isnull(@TotaleInvestimentiPrioritaAmmesso,0)) = 0) SELECT 0 AS RESULT
	ELSE
	BEGIN		
		IF ((isnull(@TotaleInvestimentiPrioritaAttuale,0) + isnull(@TotaleInvestimentiPrioritaAmmesso,0)) > ((isnull(@IMPORTO_AMMESSO,0)+ISNULL(@IMPORTO_AMMESSO_ATTUALE ,0))/2)) SELECT 1 AS RESULT
		ELSE SELECT 0 AS RESULT
	END

END
