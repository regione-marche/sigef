CREATE PROCEDURE [dbo].[calcoloStepVariante123_2]
@ID_VARIANTE int
AS
BEGIN

	-- 123 - obiettivi di miglioramento del rendimento globale dell`impresa ( Priorita n. 116 )

	DECLARE @TotaleInvestimenti decimal(10,2)
	DECLARE @TotaleInvestimentiPriorita decimal(10,2)
		
	SET @TotaleInvestimenti = (SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO + SPESE_GENERALI),0)
							   FROM PIANO_INVESTIMENTI PI  
								WHERE  PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A' AND 
                                      COD_TIPO_INVESTIMENTO = 1)  
 
-- Investimenti volti al miglioramento globale dell'azienda (PRIORITA 116)
SET @TotaleInvestimentiPriorita = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO + SPESE_GENERALI),0)
									FROM PIANO_INVESTIMENTI PI  
									WHERE  PI.ID_VARIANTE = @ID_VARIANTE   AND    isnull(COD_VARIAZIONE,'x')!='A'   
											 AND PI.ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
																	    FROM PRIORITA_X_INVESTIMENTI 
																	    WHERE ID_PRIORITA = 116 AND ID_VALORE IN (SELECT ID_VALORE FROM VALORI_PRIORITA WHERE ID_PRIORITA = 116)																	    
																	    ))
								     			  
IF (@TotaleInvestimentiPriorita = 0) SELECT 0 AS RESULT
ELSE
	BEGIN		
		IF (@TotaleInvestimentiPriorita > (@TotaleInvestimenti/2)) SELECT 1 AS RESULT
		ELSE SELECT 0 AS RESULT
	END

END
