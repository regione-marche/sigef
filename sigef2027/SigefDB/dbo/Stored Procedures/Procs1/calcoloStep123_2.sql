CREATE PROCEDURE [dbo].[calcoloStep123_2]
@IdProgetto int
AS
BEGIN

	-- 123 - obiettivi di miglioramento del rendimento globale dell`impresa ( Priorita n. 116 )

	DECLARE @TotaleInvestimenti decimal(10,2),@TotaleInvestimentiPriorita decimal(10,2)
	DECLARE @CodFaseProgetto char(1),@FASE_ISTRUTTORIA bit
	
	--SET @CodFaseProgetto = (SELECT TOP(1) ISNULL(COD_FASE,'P') FROM dbo.vSTATO_PROGETTO WHERE ID_PROGETTO = @IdProgetto ORDER BY ORDINE DESC)
			
	-- Totale investimenti fase "Presentazione"
	--IF (@CodFaseProgetto = 'P') 
	
	SELECT @FASE_ISTRUTTORIA = FLAG_DEFINITIVO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto
	SELECT @TotaleInvestimenti = DBO.calcoloCostoTotaleProgetto( @IdProgetto,@FASE_ISTRUTTORIA ,NULL)

	-- Investimenti volti al miglioramento globale dell'azienda (PRIORITA 116)
	SET @TotaleInvestimentiPriorita = ( 
									   SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO + SPESE_GENERALI),0)
									   FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
									   WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)
											 AND PI.ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
																	    FROM PRIORITA_X_INVESTIMENTI 
																	    WHERE ID_PRIORITA = 116 AND ID_VALORE IN (SELECT ID_VALORE FROM VALORI_PRIORITA WHERE ID_PRIORITA = 116)																	    
																	    )
								     	AND ( (PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND P.FLAG_DEFINITIVO=0 ) OR (PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND P.FLAG_DEFINITIVO=1 AND ID_VARIANTE IS NULL ) )
									  )
		
	IF (@TotaleInvestimentiPriorita = 0) SELECT 0 AS RESULT
	ELSE
	BEGIN		
		IF (@TotaleInvestimentiPriorita > (@TotaleInvestimenti/2)) SELECT 1 AS RESULT
		ELSE SELECT 0 AS RESULT
	END

END
