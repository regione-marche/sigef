CREATE PROCEDURE [dbo].[calcoloPrioritaVariante112_311_4]
@IdVariante int, 
@IdProgetto int
AS
BEGIN
-- FATTO!!! 
--311 - Investimento in bioedilizia livello Investimento - (Per la priorita 112 Calcolo Punteggio BusinessPlan)
-- ID_PRIORITA =  154	


DECLARE @Punteggio decimal(10,2)
DECLARE @InvestimentiFabbricati decimal(10,2)
DECLARE @TotaleInvestimenti decimal(10,2)
DECLARE @InvestimentiBioedilizia decimal (10,2)

       
 SET @TotaleInvestimenti = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO,0))
							     FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
								 WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND 
                                        PI.COD_TIPO_INVESTIMENTO = 1 AND  ID_VARIANTE = @IdVariante  )
	
 -- Calcolo gli investimenti per Codifica A e B
 -- ID_PRIORITA = 154
 
SET @InvestimentiFabbricati = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO ,0))
							   FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
									INNER JOIN vzPROGRAMMAZIONE PR ON PR.ID=PI.ID_PROGRAMMAZIONE AND PR.CODICE IN ('3.1.1.a.A','3.1.1.a.B', '3.1.1.a.1')
							    WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND 
										  ID_VARIANTE = @IdVariante   )

SET @InvestimentiBioedilizia = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO ,0))
                                  FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
								  WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
										     AND ID_VARIANTE =@IdVariante AND ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
                                                                 FROM PRIORITA_X_INVESTIMENTI 
                                                                 WHERE ID_PRIORITA = 154))


 
IF (@InvestimentiFabbricati >=( 0.65 *@TotaleInvestimenti) )
BEGIN
  
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

 RETURN (@Punteggio * 100)

END
