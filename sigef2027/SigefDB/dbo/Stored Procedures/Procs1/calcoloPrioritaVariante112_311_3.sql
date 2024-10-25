CREATE  PROCEDURE [dbo].[calcoloPrioritaVariante112_311_3]
@ID_VARIANTE int,
@IdProgetto int 
AS
BEGIN

--311 - Investimento in bioedilizia livello Investimento
-- ID_PRIORITA =  154	

DECLARE @Punteggio decimal(10,2),@InvestimentiFabbricati decimal(10,2)
DECLARE @TotaleInvestimenti decimal(10,2), @InvestimentiBioedilizia decimal (10,2)

DECLARE @CodFaseProgetto char(1)
SET @CodFaseProgetto = (SELECT TOP(1) ISNULL(COD_FASE,'P') FROM dbo.vPROGETTO WHERE ID_PROGETTO = @IdProgetto)



 SET @TotaleInvestimenti = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO,0))
							 FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							 WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND 
                                        PI.COD_TIPO_INVESTIMENTO = 1 AND 
                                        ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A'     )
	
 -- Calcolo gli investimenti per Codifica A e B
 
SET @InvestimentiFabbricati = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO ,0))
									  FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
									  	INNER JOIN vzPROGRAMMAZIONE PR ON PR.ID=PI.ID_PROGRAMMAZIONE AND PR.CODICE IN ('3.1.1.a.A','3.1.1.a.B', '3.1.1.a.1')
									  WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
											  AND ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A'    )

SET @InvestimentiBioedilizia = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO ,0))
                                  FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
								  WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)  
											AND ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A'  AND 
										    ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
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

SELECT @Punteggio AS PUNTEGGIO
RETURN (@Punteggio * 100)

END
