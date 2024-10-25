CREATE  PROCEDURE [dbo].[calcoloPriorita311_B_7]
@IdProgetto int,
@FASE_ISTRUTTORIA bit = 0,
@IdVariante INT 
AS
BEGIN

--311 - Investimento in bioedilizia livello Investiemnto
 -- ID_PRIORITA = 1184 
DECLARE @Punteggio decimal(10,2), @InvestimentiFabbricati decimal(10,2), @TotaleInvestimenti decimal(10,2)
		, @InvestimentiBioedilizia decimal (10,2), @CodFaseProgetto char(1)
 
-- AGGIUNTA PRIORITA A LIVELLO INVESTIMENTO  priorità E - investimenti strutturali realizzati con tecniche di bioedilizia
SET @TotaleInvestimenti = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO,0))
							FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND 
									PI.COD_TIPO_INVESTIMENTO = 1 AND ((@FASE_ISTRUTTORIA =0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)or(@FASE_ISTRUTTORIA =1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)))

-- Calcolo gli investimenti per Codifica A 

SET @InvestimentiFabbricati = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO ,0))
									  FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
									  WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
											((@FASE_ISTRUTTORIA =0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)OR(@FASE_ISTRUTTORIA =1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
                                            AND ID_PROGRAMMAZIONE = 226)

SET @InvestimentiBioedilizia = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO ,0))
                                  FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
								  WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND  
										((@FASE_ISTRUTTORIA =0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)or(@FASE_ISTRUTTORIA =1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))
                                         AND ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
                                                                 FROM PRIORITA_X_INVESTIMENTI 
                                                                 WHERE ID_PRIORITA = 1184))


IF (@InvestimentiFabbricati >=( 0.65 *@TotaleInvestimenti) )
BEGIN
    -- si considera il costo totale come costo totale sui fabbricati
		 -- Quota investimenti prioritari superiore all’80% sul costo totale
		 IF (@InvestimentiBioedilizia > (@InvestimentiFabbricati * 0.8) ) SET @Punteggio = 1

		 --Quota investimenti prioritari > 65% e < 80% sul costo totale
	     ELSE IF (@InvestimentiBioedilizia > (@InvestimentiFabbricati * 0.65) AND
				  @InvestimentiBioedilizia <= (@InvestimentiFabbricati * 0.8)) SET @Punteggio = 0.65

		 -- Quota investimenti prioritari > 50% e < 65% sul costo totale
	     ELSE IF (@InvestimentiBioedilizia > (@InvestimentiFabbricati * 0.50) AND
				  @InvestimentiBioedilizia <= (@InvestimentiFabbricati * 0.65) ) SET @Punteggio = 0.35

		--Quota investimenti prioritari inferiori al 50% sul costo totale
	   
		 ELSE SET @Punteggio = 0
                 
   
END
ELSE SET @Punteggio = 0

SELECT @Punteggio AS PUNTEGGIO
RETURN (@Punteggio * 100)

END
