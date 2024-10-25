CREATE PROCEDURE [dbo].[calcoloStep121_8]
@IdProgetto int
AS
BEGIN

	-- 121 - verifica massimale investimento fotovoltaico:
	-- a) Ciascun investimento avente come specifica "fotovoltaico" non può superare i 400000€
    -- b) Ciascun contributo ammissibile non può superare il 30% della somma di tutti gli investimenti

	DECLARE @Count_a int
	DECLARE @Count_b int
	DECLARE @TotaleInvestimenti decimal(10,2)

	-- Numero di investimenti "fotovoltaico" che superano i 400000€
	SET @Count_a = (SELECT COUNT(PI.ID_INVESTIMENTO)
				    FROM PIANO_INVESTIMENTI PI 
						 INNER JOIN VPROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
				    WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
						   AND PI.COD_TIPO_INVESTIMENTO = 1 AND 
					(( P.COD_STATO='P' AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(P.COD_STATO!='P'
					AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
						   AND (PI.ID_SPECIFICA_INVESTIMENTO = 236 or PI.ID_SPECIFICA_INVESTIMENTO = 757  )  -- fotovoltaica						   
						   AND PI.COSTO_INVESTIMENTO > 400000)

	-- Totale investimenti 
	SET @TotaleInvestimenti = (SELECT ISNULL(SUM(PI.CONTRIBUTO_RICHIESTO),0)
							   FROM  PIANO_INVESTIMENTI PI INNER JOIN VPROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
							   WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)  AND 
							   ((P.COD_STATO ='P' AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)
								OR(P.COD_STATO!='P' AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
									  AND PI.COD_TIPO_INVESTIMENTO = 1)
--select @TotaleInvestimenti

	-- Numero di investimenti in cui il contributo ammissibile supera il 30% del totale di tutti gli investimenti
	SET @Count_b = (SELECT COUNT(PI.ID_INVESTIMENTO)
				    FROM  PIANO_INVESTIMENTI PI INNER JOIN VPROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
				    WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
						   AND PI.COD_TIPO_INVESTIMENTO = 1 AND 
					((P.COD_STATO ='P' AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(P.COD_STATO!='P'
							AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
						   AND (PI.ID_SPECIFICA_INVESTIMENTO = 236 or PI.ID_SPECIFICA_INVESTIMENTO = 757  )  -- fotovoltaica	
                           AND PI.CONTRIBUTO_RICHIESTO > (@TotaleInvestimenti * 0.3))


	-- Se almeno uno dei due count è > 0 allora il controllo da esito negativo
	IF (@Count_a > 0 OR @Count_b > 0) SELECT 0 AS RESULT
	ELSE SELECT 1 AS RESULT

END
