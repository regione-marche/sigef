﻿CREATE  PROCEDURE [dbo].[calcoloStepPagamento121_3]
@IdProgetto int , 
@IdDomandaPagamento int
AS
BEGIN

	-- (Zucchero) L'aumento del rendimento globale dell'azienda, si considera ottenuto qualora gli investimenti richiesti
    -- in domanda siano volti al raggiungimento di almeno una delle condizioni indicate nella prima colonna della tabella XXX
    -- Tali condizioni si intendono soddisfatte quando il costo complessivo degli investimenti è per oltre il 50% riferibile
    -- ad una o più di esse

	DECLARE @TotaleInvestimenti decimal(18,2),
			@IMPORTO_AMMESSO decimal(18,2),
			@IMPORTO_DOMANDA_ATTUALE decimal (18,2),
			@TotaleInvestimentiPriorita decimal(18,2),
			@TotaleInvestimentiPrioritaAmmesso decimal(18,2)  

	-- Totale investimenti fase "PAGAMENTO" SALDO
	-- COSTO INVESTIMENTO AMMESSO NELLE DOMANDE PRECEDENTI

SET @IMPORTO_AMMESSO = (SELECT  SUM( ISNULL(IMPORTO_AMMISSIBILE ,0 ))
						FROM DOMANDA_DI_PAGAMENTO_ESPORTAZIONE PE
					    WHERE ID_DOMANDA_PAGAMENTO  IN (SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO 
							 WHERE ID_PROGETTO = @IdProgetto AND APPROVATA = 1 AND ANNULLATA =0 AND  ID_DOMANDA_PAGAMENTO< @IdDomandaPagamento
							  ) )	
					 
SET @IMPORTO_DOMANDA_ATTUALE = (SELECT  SUM( ISNULL(IMPORTO_AMMISSIBILE ,0 ))
																			 FROM     DOMANDA_DI_PAGAMENTO_ESPORTAZIONE PE
																			 WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  )	

   -- PRIORITA 88: 121- zucchero - Obiettivo di miglioramento aziendale 
SET @TotaleInvestimentiPrioritaAmmesso = (
										SELECT  SUM (ISNULL(PB.IMPORTO_AMMESSO,0))
										FROM    PAGAMENTI_BENEFICIARIO PB INNER JOIN
												PAGAMENTI_RICHIESTI PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO
										WHERE   SPESA_TECNICA_RICHIESTA =0 AND ID_INVESTIMENTO IN
										(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA IN ( 88)  )																	    
										AND ID_DOMANDA_PAGAMENTO IN 
										( SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO WHERE APPROVATA = 1 AND ID_PROGETTO= @IdProgetto  AND ANNULLATA =0 AND  ID_DOMANDA_PAGAMENTO<>@IdDomandaPagamento
											)									  
									  )

SET @TotaleInvestimentiPriorita = (SELECT  SUM (ISNULL(PB.IMPORTO_AMMESSO,0))
									FROM    PAGAMENTI_BENEFICIARIO PB INNER JOIN
											PAGAMENTI_RICHIESTI PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO
									WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  AND SPESA_TECNICA_RICHIESTA =0 AND ID_INVESTIMENTO IN
									(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA IN ( 88)  )
									  )
		
	IF ((@TotaleInvestimentiPriorita + isnull(@TotaleInvestimentiPrioritaAmmesso,0)) = 0) SELECT 0 AS RESULT
	ELSE
	BEGIN		
		IF ((@TotaleInvestimentiPriorita + isnull(@TotaleInvestimentiPrioritaAmmesso,0)) > ((isnull(@IMPORTO_AMMESSO,0)+@IMPORTO_DOMANDA_ATTUALE )/2)) SELECT 1 AS RESULT
		ELSE SELECT 0 AS RESULT
	END

END