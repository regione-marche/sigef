CREATE PROCEDURE [dbo].[calcoloStep311_1]
@IdProgetto int
AS
BEGIN

-- 311 - VERIFICA AUMENTO OCCUPAZIONE
-- - AUMENTO ORE >= 800 e < 1600 -> 0,50 
-- - AUMENTO ORE >= 1600 -> 1

DECLARE @IdSchedaValutazione int
DECLARE @PesoPriorita decimal(10,2)
DECLARE @ValoreMAXPriorita decimal(10,2)

DECLARE @OreTotali decimal(10,2)
DECLARE @OreTotaliColture decimal(10,2)
DECLARE @OreTotaliZootecnia decimal(10,2)
DECLARE @OreTotaliAttivita decimal(10,2)

SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P 
ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

-- Calcolo delle ore totali

SET @OreTotaliColture = (SELECT ISNULL(SUM(ISNULL((SAU/10000),0) * ISNULL(ORE_UNITARIE,0)),0) 
                         FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 1 AND COD_PRODOTTO IS NOT NULL)

SET @OreTotaliZootecnia = (SELECT ISNULL(SUM(ISNULL(SAU,0) * ISNULL(ORE_UNITARIE,0)),0) 
                           FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 1 AND ID_CLASSE_ALLEVAMENTO IS NOT NULL)

SET @OreTotaliAttivita = (SELECT ISNULL(SUM(ISNULL(SAU,0) * ISNULL(ORE_UNITARIE,0)),0) 
                          FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 1 AND ID_ATTIVITA_CONNESSA IS NOT NULL)

SET @OreTotali = ISNULL(@OreTotaliColture,0) + ISNULL(@OreTotaliZootecnia,0) + ISNULL(@OreTotaliAttivita,0)


SET @PesoPriorita = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 63 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPriorita = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA 
WHERE ID_PRIORITA = 63 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

 

-- Controllo della maggiorazione del 20%
IF ((@OreTotali * 0.2) > 400) SET @OreTotali = @OreTotali + 400
ELSE SET @OreTotali = @OreTotali + (@OreTotali * 0.2)


-- Esistenza della priorità in PRIORITA_X_PROGETTO
DECLARE @Exists int
SET @Exists = (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 63)

/*
-- Imposto il valore di default alla priorità 63 (311 - investimenti destinati a creare occupazione) nella graduatoria
IF (@Exists > 0)
BEGIN
  
   IF (@OreTotali >= 1600) UPDATE PRIORITA_X_PROGETTO
						   SET VALORE = (1 * @PesoPriorita)/@ValoreMAXPriorita
						   WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 63
   
   ELSE IF (@OreTotali >= 800 AND @OreTotali < 1600) UPDATE PRIORITA_X_PROGETTO
													 SET VALORE = (0.5 * @PesoPriorita)/@ValoreMAXPriorita
													 WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 63
   
   ELSE UPDATE PRIORITA_X_PROGETTO SET VALORE = 0 WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 63
 
END
ELSE 
BEGIN

   IF (@OreTotali >= 1600) INSERT INTO PRIORITA_X_PROGETTO(ID_PROGETTO,ID_PRIORITA,VALORE,MODIFICA_MANUALE)
						   VALUES (@IdProgetto,63,(1 * @PesoPriorita)/@ValoreMAXPriorita,0)
						   
   
   ELSE IF (@OreTotali >= 800 AND @OreTotali < 1600) INSERT INTO PRIORITA_X_PROGETTO(ID_PROGETTO,ID_PRIORITA,VALORE,MODIFICA_MANUALE)
													 VALUES (@IdProgetto,63,(0.5 * @PesoPriorita)/@ValoreMAXPriorita,0)
   
   ELSE INSERT INTO PRIORITA_X_PROGETTO(ID_PROGETTO,ID_PRIORITA,VALORE,MODIFICA_MANUALE)
						VALUES (@IdProgetto,63,0,0)

END

*/
SELECT 1 AS RESULT
	
END
