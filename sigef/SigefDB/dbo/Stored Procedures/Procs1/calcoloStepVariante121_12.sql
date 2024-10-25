CREATE PROCEDURE [dbo].[calcoloStepVariante121_12]
@ID_VARIANTE int
AS
BEGIN

-- 121 - VERIFICA AUMENTO ULA AD ALMENO UNA UNITA'

DECLARE @OreTotali decimal(10,2),@IdProgetto int
DECLARE @OreTotaliColture decimal(10,2)
DECLARE @OreTotaliZootecnia decimal(10,2)
DECLARE @OreTotaliAttivita decimal(10,2)

SELECT @IdProgetto =ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE=@ID_VARIANTE 

SET @OreTotaliColture = (SELECT ISNULL(SUM(ISNULL((SAU/10000),0) * ISNULL(ORE_UNITARIE,0)),0) 
                         FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 1 AND COD_PRODOTTO IS NOT NULL)

SET @OreTotaliZootecnia = (SELECT ISNULL(SUM(ISNULL(SAU,0) * ISNULL(ORE_UNITARIE,0)),0) 
                           FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 1 AND ID_CLASSE_ALLEVAMENTO IS NOT NULL)

SET @OreTotaliAttivita = (SELECT ISNULL(SUM(ISNULL(SAU,0) * ISNULL(ORE_UNITARIE,0)),0) 
                          FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 1 AND ID_ATTIVITA_CONNESSA IS NOT NULL)

SET @OreTotali = ISNULL(@OreTotaliColture,0) + ISNULL(@OreTotaliZootecnia,0) + ISNULL(@OreTotaliAttivita,0)

-- Controllo della maggiorazione del 20%
IF ((@OreTotali * 0.2) > 400) SET @OreTotali = @OreTotali + 400
ELSE SET @OreTotali = @OreTotali + (@OreTotali * 0.2)

IF ((@OreTotali/1800) >= 1) SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT

	
END
