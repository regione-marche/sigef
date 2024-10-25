CREATE PROCEDURE [dbo].[calcoloPrioritaVariante112_311_1]
@ID_VARIANTE int , @IdProgetto INT
AS
/*
DECLARE @IdProgetto INT
SET @IdProgetto=338
*/

--112 - 311 - Numero finale strutture

-- Controllo dell'esistenza di investimenti destinati a migliorare i servizi agrituristici delle aziende
-- ID Priorità: 104

 
DECLARE @Punteggio decimal(10,2)
SET @Punteggio = 0
DECLARE @InvestimentiPerServizi decimal(10,2)

-- 1. Calcolo gli investimenti per servizi
SET @InvestimentiPerServizi = (SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) FROM PIANO_INVESTIMENTI PI
								WHERE ID_PROGETTO=@IdProgetto AND  PI.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A' AND
							    COD_TIPO_INVESTIMENTO = 1 AND ID_INVESTIMENTO IN 
								(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA = 104))

IF (@InvestimentiPerServizi > 0)
BEGIN     	   
	   DECLARE @TotaleInvestimenti decimal(10,2)
	   DECLARE @CodiceValore varchar(10)

	  -- 2. Calcolo il totale degli investimenti
	  SET @TotaleInvestimenti = (SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) FROM PIANO_INVESTIMENTI PI WHERE ID_PROGETTO=@IdProgetto 
								AND COD_TIPO_INVESTIMENTO = 1  AND PI.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A' 
								  )
						
	  -- 112 - 311 - Numero finale strutture (ID PRIORITA: 111)				        	  
	  SET @CodiceValore = (SELECT CODICE FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)
	                       WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 111)

      -- 3. Calcolo il punteggio	 
     IF (@CodiceValore IS NULL) SET @Punteggio = 0
	 ELSE BEGIN
	   
		 -- Quota investimenti per servizi > 30% del costo totale con 3 o più strutture
		 IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.3) AND @CodiceValore = '3') SET @Punteggio = 1

		 -- Quota investimenti per servizi > 20% e < 30% sul costo totale con 3 o più strutture
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.2) AND
				  @InvestimentiPerServizi <= (@TotaleInvestimenti * 0.3) AND @CodiceValore = '3') SET @Punteggio = 0.8

		 -- Quota investimenti per servizi > 20% e < 30% sul costo totale e 2 strutture
		-- la quota deve essere > 20 %
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.2)  AND @CodiceValore = '2') SET @Punteggio = 0.65

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

SELECT @Punteggio AS PUNTEGGIO
RETURN (@Punteggio * 100)
