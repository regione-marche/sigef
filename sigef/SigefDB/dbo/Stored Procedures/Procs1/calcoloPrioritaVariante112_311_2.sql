CREATE PROCEDURE [dbo].[calcoloPrioritaVariante112_311_2]
@ID_VARIANTE INT ,
@IdProgetto int  -- l'id del progetto integrato se viene chiamata dallo STEP
AS
BEGIN

DECLARE @Punteggio decimal(10,2)

-- FATTO!!! 
--112 - 311 - Numero finale strutture (Per la priorita 112 Calcolo Punteggio BusinessPlan)

-- Controllo dell'esistenza di investimenti destinati a migliorare i servizi agrituristici delle aziende
-- ID Priorità: 104
DECLARE @InvestimentiServiziExists int
SET @InvestimentiServiziExists = (SELECT COUNT(PI.ID_INVESTIMENTO) 
                                  FROM PIANO_INVESTIMENTI PI  
								  WHERE (Pi.ID_PROGETTO=@IdProgetto )and  PI.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A'   
									 AND ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
                                                                 FROM PRIORITA_X_INVESTIMENTI 
                                                                 WHERE ID_PRIORITA = 104))
IF (@InvestimentiServiziExists > 0)
	BEGIN
     
	   DECLARE @InvestimentiPerServizi decimal(10,2)
	   DECLARE @TotaleInvestimenti decimal(10,2)
	   DECLARE @CodiceValore varchar(10)

	   -- 1. Calcolo gli investimenti per servizi
	   SET @InvestimentiPerServizi = (SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
									  FROM PIANO_INVESTIMENTI PI  
									  WHERE (Pi.ID_PROGETTO=@IdProgetto ) AND PI.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A' 
                                            AND PI.ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
                                                                       FROM PRIORITA_X_INVESTIMENTI 
                                                                       WHERE ID_PRIORITA = 104))

	  -- 2. Calcolo il totale degli investimenti
  	  SET @TotaleInvestimenti = (SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
							     FROM PIANO_INVESTIMENTI PI  
								 WHERE (Pi.ID_PROGETTO=@IdProgetto) AND 
                                        PI.COD_TIPO_INVESTIMENTO = 1  and PI.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A'    )

	  -- Investimenti fasi successive
							
	  -- 112 - 311 - Numero finale strutture (ID PRIORITA: 111)				        	  
	  SET @CodiceValore = (SELECT CODICE 
                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)
	                       WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 111)


      -- 3. Calcolo il punteggio	 
     IF (@CodiceValore IS NULL) SET @Punteggio = 0
	 ELSE
       BEGIN
	   
		 -- Quota investimenti per servizi > 30% del costo totale con 3 o più strutture
		 IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.3) AND @CodiceValore = '3') SET @Punteggio = 1

		 -- Quota investimenti per servizi > 20% e < 30% sul costo totale con 3 o più strutture
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.2) AND
				  @InvestimentiPerServizi <= (@TotaleInvestimenti * 0.3) AND @CodiceValore = '3') SET @Punteggio = 0.8

		 -- Quota investimenti per servizi > 20% e < 30% sul costo totale e 2 strutture
         -- la quota deve essere SOLO > 20%
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.2) AND @CodiceValore = '2') SET @Punteggio = 0.65

		 -- Quota investimenti per servizi > 15% e < 20% sul costo totale con 3 o più strutture
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.15) AND
				  @InvestimentiPerServizi <= (@TotaleInvestimenti * 0.2) AND @CodiceValore = '3') SET @Punteggio = 0.5

	     -- Quota investimenti per servizi > 15% e < 20% sul costo totale con 2 strutture
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.15) AND
				  @InvestimentiPerServizi <= (@TotaleInvestimenti * 0.2) AND @CodiceValore = '2') SET @Punteggio = 0.4

		 -- Quota investimenti per servizi > 15% e 1 struttura
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.15) AND @CodiceValore = '1') SET @Punteggio = 0.3
            
		 ELSE SET @Punteggio = 0
                 
       END

	END

ELSE SET @Punteggio = 0
RETURN (@Punteggio * 100)

END
