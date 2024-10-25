CREATE  PROCEDURE [dbo].[calcoloStepVariante121_6]
@ID_VARIANTE int
AS
BEGIN

	-- (Zucchero) L'aumento del rendimento globale dell'azienda, si considera ottenuto qualora gli investimenti richiesti
    -- in domanda siano volti al raggiungimento di almeno una delle condizioni indicate nella prima colonna della tabella XXX
    -- Tali condizioni si intendono soddisfatte quando il costo complessivo degli investimenti è per oltre il 50% riferibile
    -- ad una o più di esse

	DECLARE @TotaleInvestimenti decimal(10,2)
	DECLARE @TotaleInvestimentiPriorita decimal(10,2)

	 		
	-- Totale investimenti fase "VARIANTE"
	 SET @TotaleInvestimenti = (
								    SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
								    FROM PIANO_INVESTIMENTI PI  
								    WHERE  COD_TIPO_INVESTIMENTO = 1  AND PI.ID_VARIANTE = @ID_VARIANTE   AND    isnull(COD_VARIAZIONE,'x')!='A' 
                                         
								    )
	
	-- PRIORITA 88: 121- zucchero - Obiettivo di miglioramento aziendale 
	SET @TotaleInvestimentiPriorita = ( 
									   SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
									   FROM PIANO_INVESTIMENTI PI 
									   WHERE    PI.ID_VARIANTE = @ID_VARIANTE   AND    isnull(COD_VARIAZIONE,'x')!='A' 
                                         	 AND PI.ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
																	    FROM PRIORITA_X_INVESTIMENTI 
																	    WHERE ID_PRIORITA = 88 AND ID_VALORE IN (SELECT ID_VALORE FROM VALORI_PRIORITA WHERE ID_PRIORITA = 88)																	    
																	    )
									  )
		
	IF (@TotaleInvestimentiPriorita = 0) SELECT 0 AS RESULT
	ELSE
	BEGIN		
		IF (@TotaleInvestimentiPriorita > (@TotaleInvestimenti/2)) SELECT 1 AS RESULT
		ELSE SELECT 0 AS RESULT
	END

END
