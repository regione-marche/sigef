CREATE PROCEDURE [dbo].[calcoloStep121_A2]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN

	-- L'aumento del rendimento globale dell'azienda, si considera ottenuto qualora gli investimenti richiesti
    -- in domanda siano volti al raggiungimento di almeno una delle condizioni indicate nella prima colonna della tabella XXX
    -- Tali condizioni si intendono soddisfatte quando il costo complessivo degli investimenti è per oltre il 50% riferibile
    -- ad una o più di esse

	DECLARE @TotaleInvestimenti decimal(10,2)
	DECLARE @TotaleInvestimentiPriorita decimal(10,2)
 
	 
	SET @TotaleInvestimenti = (
							   SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO ),0)
							   FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
							   WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND 
							   ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR
								(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
                                AND COD_TIPO_INVESTIMENTO = 1  
							  )

--SELECT @TotaleInvestimenti
	-- Investimenti volti al miglioramento globale dell'azienda (PRIORITA 37)
	SET @TotaleInvestimentiPriorita = ( 
									   SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO ),0)
									   FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
									   WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND 
										((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR
										(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
											 AND PI.ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
																	    FROM PRIORITA_X_INVESTIMENTI 
																	    WHERE ID_PRIORITA = 37 AND ID_VALORE IN (SELECT ID_VALORE FROM VALORI_PRIORITA WHERE ID_PRIORITA = 37)																	    
																	    )
									  )
--	SELECT 	@TotaleInvestimentiPriorita 
	IF (@TotaleInvestimentiPriorita = 0) SELECT 0 AS RESULT
	ELSE
	BEGIN		
		IF (@TotaleInvestimentiPriorita >= (@TotaleInvestimenti/2)) SELECT 1 AS RESULT
		ELSE SELECT 0 AS RESULT
	END

END
