CREATE PROCEDURE [dbo].[calcoloStep121_15]
@IdProgetto int
,@FASE_ISTRUTTORIA int=0
AS
BEGIN
---bando light il calcolo si fa sul costo!

	-- 121 - verifica massimale investimento fotovoltaico:
	-- a) Ciascun investimento avente come specifica "fotovoltaico" non può superare i 100000€
    -- b) Ciascun costo ammissibile non può superare il 30% della somma di tutti gli investimenti

	DECLARE @Count_a int
	DECLARE @Count_b int
	DECLARE @TotaleInvestimenti decimal(18,2),@Costo_fotovoltaico decimal(18,2)

	-- Numero di investimenti "fotovoltaico" che superano i 100000€ - BANDO 2013
SET @Count_a = (SELECT COUNT(ID_PROGETTO)
				FROM VPIANO_INVESTIMENTI inv
				WHERE (inv.ID_PROGETTO=@IdProgetto) AND inv.COD_TIPO_INVESTIMENTO = 1 AND 
						((@FASE_ISTRUTTORIA=0 AND inv.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
							OR(@FASE_ISTRUTTORIA =1 AND inv.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))	
					 AND (inv.CODICE = 7)  -- fotovoltaica						   
					 AND inv.COSTO_INVESTIMENTO > 100000
				group by ID_PROGETTO 
				HAVING SUM(COSTO_INVESTIMENTO) + SUM(isnull(SPESE_GENERALI,0)) > 100000)

-- Totale investimenti 
SELECT @TotaleInvestimenti =  dbo.calcoloCostoTotaleProgetto (@IdProgetto,@FASE_ISTRUTTORIA,null)

-- Numero di investimenti in cui il contributo ammissibile supera il 30% del totale di tutti gli investimenti
SET @Costo_fotovoltaico = (SELECT SUM(COSTO_INVESTIMENTO) + SUM(isnull(SPESE_GENERALI,0))
								FROM VPIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
								WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)  AND (PI.CODICE = '7')  -- fotovoltaica	
									   AND PI.COD_TIPO_INVESTIMENTO = 1 AND 
										((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
											OR(@FASE_ISTRUTTORIA =1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))									  
									   )


	-- Se almeno uno dei due count è > 0 allora il controllo da esito negativo
	IF (@Count_a > 0 OR @Costo_fotovoltaico > (@TotaleInvestimenti*0.3) ) SELECT 0 AS RESULT
	ELSE SELECT 1 AS RESULT

END
