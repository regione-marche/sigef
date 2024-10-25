CREATE PROCEDURE [dbo].[calcoloStep4135bRiap_SI]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
	
-- Rispetto tetto massimo investimenti pari a 150.000€ per i progetti presentati per i bandi misura 4135b1 e 4135b2 -- riaperutara
-- progetti solo per uno dei due bandi

DECLARE @RESULT int,
		@TOTALE decimal(10,2),

		@CONTA404 int,
		@CONTA405 int,
		@ID_IMPRESA INT

SET @RESULT = 1 -- PONGO LO STEP IN STATO   VERIFICATO
SET @TOTALE = 0 		
SET @CONTA404 = 0 	
SET @CONTA405 = 0 	


SELECT @ID_IMPRESA = ID_IMPRESA  FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto 
SET @CONTA404 = (SELECT COUNT(P.ID_PROGETTO) FROM PROGETTO P
	INNER JOIN PROGETTO_STORICO PS ON PS.ID_PROGETTO = P.ID_PROGETTO 
WHERE ID_IMPRESA = @ID_IMPRESA and ID_BANDO in (404) AND ( ( COD_STATO ='P' AND P.ID_PROGETTO = @IdProgetto )OR( COD_STATO ='L' AND P.ID_PROGETTO != @IdProgetto)))

                 
SET @CONTA405 = (SELECT COUNT(P.ID_PROGETTO) FROM PROGETTO P
	INNER JOIN PROGETTO_STORICO PS ON PS.ID_PROGETTO = P.ID_PROGETTO 
WHERE ID_IMPRESA = @ID_IMPRESA and ID_BANDO in (405) AND ( ( COD_STATO ='P' AND P.ID_PROGETTO = @IdProgetto )OR( COD_STATO ='L' AND P.ID_PROGETTO != @IdProgetto)))

SET @TOTALE = (SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) + ISNULL( SUM (SPESE_GENERALI),0) AS Totale_Investimenti 
               FROM vPROGETTO P 
                    INNER JOIN PIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
                WHERE ((I.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL)OR( I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) AND
                      P.ID_PROGETTO IN (SELECT ID_PROGETTO FROM PROGETTO WHERE ID_IMPRESA = @ID_IMPRESA and ID_BANDO IN (404, 405)))


IF(@CONTA404 >= 1  AND @CONTA405 >=1 ) SET @RESULT =0
ELSE IF(@TOTALE > 150000) SET @RESULT=0

SELECT @RESULT
END

---------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
