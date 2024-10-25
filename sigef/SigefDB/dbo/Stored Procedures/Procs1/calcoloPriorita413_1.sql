CREATE PROCEDURE [dbo].[calcoloPriorita413_1]
(
@IdProgetto int,
@fase_istruttoria bit,
@IdVariante INT
)
AS
BEGIN

--   D.	Investimenti che determinano un aumento dell’occupazione nelle nuove  imprese
-- - AUMENTO ORE >= 800 e < 1600 -> 0,50 
-- - AUMENTO ORE >= 1600 -> 1
 
DECLARE @ORE_ATTIVITA_ANTE decimal(10,2),
		@ORE_ATTIVITA_POST decimal(10,2),
		@PUNTEGGIO decimal(10,2), 
		@OREINCREMENTO decimal(10,2)
 
-- Calcolo delle ore totali per le attività connesse

 SET @ORE_ATTIVITA_ANTE = (SELECT ISNULL(SUM(ISNULL(SAU,0) * ISNULL(ORE_UNITARIE,0)),0) 
                           FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 0 AND ID_ATTIVITA_CONNESSA IS NOT NULL)

 SET @ORE_ATTIVITA_POST = (SELECT ISNULL(SUM(ISNULL(SAU,0) * ISNULL(ORE_UNITARIE,0)),0) 
                           FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 1 AND ID_ATTIVITA_CONNESSA IS NOT NULL)


SET @OREINCREMENTO = ISNULL(@ORE_ATTIVITA_POST,0 ) - ISNULL(@ORE_ATTIVITA_ANTE,0)
  
   IF (@OREINCREMENTO >= 1600)  
		SET @PUNTEGGIO = 1
    ELSE 
		IF (@OREINCREMENTO >= 800 AND @OREINCREMENTO < 1600)  
			SET @PUNTEGGIO = 0.5	
		ELSE  
			SET @PUNTEGGIO = 0

SELECT @Punteggio AS PUNTEGGIO

END
