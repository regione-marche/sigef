CREATE  PROCEDURE [dbo].[calcoloStepVariante121_3]
@ID_VARIANTE int
AS
BEGIN

	--121 PSR  L'aumento del rendimento globale dell'azienda 
  

	DECLARE @TotaleInvestimenti decimal(10,2)
	DECLARE @TotaleInvestimentiPriorita decimal(10,2)

	 		
	-- Totale investimenti fase "VARIANTE"
	 SET @TotaleInvestimenti = (SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
								FROM PIANO_INVESTIMENTI PI  
								WHERE  COD_TIPO_INVESTIMENTO = 1  AND PI.ID_VARIANTE = @ID_VARIANTE   AND    isnull(COD_VARIAZIONE,'x')!='A' 
                                )
	
	-- PRIORITA 37: 121 - obiettivo di miglioramento aziendale
	SET @TotaleInvestimentiPriorita = ( 
									   SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
									   FROM PIANO_INVESTIMENTI PI 
									   WHERE    PI.ID_VARIANTE = @ID_VARIANTE   AND    isnull(COD_VARIAZIONE,'x')!='A' 
                                         	 AND PI.ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
																	    FROM PRIORITA_X_INVESTIMENTI 
																	    WHERE ID_PRIORITA = 37 AND ID_VALORE IN (SELECT ID_VALORE FROM VALORI_PRIORITA WHERE ID_PRIORITA = 37)																	    
																	    )
									  )
		
	IF (@TotaleInvestimentiPriorita = 0) SELECT 0 AS RESULT
	ELSE
	BEGIN		
		IF (@TotaleInvestimentiPriorita > (@TotaleInvestimenti/2)) SELECT 1 AS RESULT
		ELSE SELECT 0 AS RESULT
	END

END
