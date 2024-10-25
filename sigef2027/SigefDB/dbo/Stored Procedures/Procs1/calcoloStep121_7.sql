CREATE PROCEDURE [dbo].[calcoloStep121_7]
@IdProgetto int
AS
BEGIN

	-- 121 (zucchero) - verifica massimale investimento fotovoltaico:
	-- a) Ciascun investimento avente come specifica "fotovoltaico" non può superare i 400000€
    -- b) Ciascun contributo ammissibile non può superare il 30% della somma di tutti gli investimenti

	DECLARE @Count_a int
	DECLARE @Count_b int
	DECLARE @TotaleInvestimenti decimal(10,2)

	-- Numero di investimenti "fotovoltaico" che superano i 400000€
	SET @Count_a = (SELECT COUNT(PI.ID_INVESTIMENTO)
				    FROM VPIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
				    WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
						   AND PI.COD_TIPO_INVESTIMENTO = 1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL
						   AND PI.ID_SPECIFICA_INVESTIMENTO = 232 -- fotovoltaica						   
						   AND PI.COSTO_INVESTIMENTO > 400000)


	-- Totale investimenti
	SET @TotaleInvestimenti = (SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
							   FROM VPIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
							   WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
									  AND PI.COD_TIPO_INVESTIMENTO = 1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)

	-- Numero di investimenti in cui il contributo ammissibile supera il 30% del totale di tutti gli investimenti
	SET @Count_b = (SELECT COUNT(PI.ID_INVESTIMENTO)
				    FROM VPIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
				    WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
						   AND PI.COD_TIPO_INVESTIMENTO = 1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL
						   AND PI.ID_SPECIFICA_INVESTIMENTO = 232 -- fotovoltaica
                           AND PI.CONTRIBUTO_RICHIESTO > (@TotaleInvestimenti * 0.3))

		
	-- Se almeno uno dei due count è > 0 allora il controllo da esito negativo
	IF (@Count_a > 0 OR @Count_b > 0) SELECT 0 AS RESULT
	ELSE SELECT 1 AS RESULT

END
