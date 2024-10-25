CREATE PROCEDURE [dbo].[calcoloStep121_11]
(
	@IdProgetto int,
	@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN

	-- Per le aziende che impiegano fino a 3 ULA, il massimale stabilito in termini di contributo pubblico è di € 1.000.000 per beneficiario 
	-- per l’intero periodo di programmazione 2007-2013, per tutte le misure del primo asse e del terzo asse del presente Programma.
	-- Per le aziende che impiegano oltre 3 ULA tale massimale è elevato di 50.000 € per ogni ULA aggiuntiva e 
	-- fino ad un massimo di € 2.000.000.


--CONTROLLO ULA IMPRESA

DECLARE @OreTotali decimal(10,2),@OreTotaliColture decimal(10,2),
		@OreTotaliZootecnia decimal(10,2), @OreTotaliAttivita decimal(10,2),
		@ULA INT,@CUAA VARCHAR(16), @result int, @ID_IMPRESA INT

SET @RESULT =1 --PONGO LO STEP VERIFICATO
SELECT @ID_IMPRESA = ID_IMPRESA FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto 

SET @OreTotaliColture = (SELECT ISNULL(SUM(ISNULL((SAU/10000),0) * ISNULL(ORE_UNITARIE,0)),0) 
                         FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 0 AND COD_PRODOTTO IS NOT NULL)

SET @OreTotaliZootecnia = (SELECT ISNULL(SUM(ISNULL(SAU,0) * ISNULL(ORE_UNITARIE,0)),0) 
                           FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 0 AND ID_CLASSE_ALLEVAMENTO IS NOT NULL)

SET @OreTotaliAttivita = (SELECT ISNULL(SUM(ISNULL(SAU,0) * ISNULL(ORE_UNITARIE,0)),0) 
                          FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto AND PREVISIONALE = 0 AND ID_ATTIVITA_CONNESSA IS NOT NULL)

SET @OreTotali = ISNULL(@OreTotaliColture,0) + ISNULL(@OreTotaliZootecnia,0) + ISNULL(@OreTotaliAttivita,0)

-- Controllo della maggiorazione del 20%
IF ((@OreTotali * 0.2) > 400) 
	SET @OreTotali = @OreTotali + 400
ELSE 
	SET @OreTotali = @OreTotali + (@OreTotali * 0.2)

SET  @ULA = (@OreTotali/1800)  --TOTALE ULA PLV ANNO CORRENTE ASSOCIATA AL PROGETTO

 -- CONTRIBUTO RICHIESTO AMMISSIBILE PER LE DOMANDE AMMISSIBILI DELL'IMPRESA (il contriburo va calcolato solo per le domande del PSR e non per i bandi PABS )
DECLARE @CONTRIBUTO_RICHIESTO DECIMAL(18,2)
SET @CONTRIBUTO_RICHIESTO = 
	  (SELECT SUM(ISNULL (PIANO_INVESTIMENTI.CONTRIBUTO_RICHIESTO ,0)) as CONTRIBUTO
		FROM PIANO_INVESTIMENTI INNER JOIN
			( SELECT DISTINCT PROGETTO.ID_PROGETTO, FLAG_DEFINITIVO 
			  FROM PROGETTO INNER JOIN  PROGETTO_STORICO ON PROGETTO.ID_PROGETTO = PROGETTO_STORICO.ID_PROGETTO 
			WHERE ( PROGETTO_STORICO.ID_PROGETTO not in ( select Id_Progetto from VPROGETTO where  VPROGETTO.COD_STATO  IN ('P','Q','B', 'N'))   OR (PROGETTO.ID_PROGETTO = @IdProgetto  )) 
			AND ID_IMPRESA = @ID_IMPRESA 
			AND FLAG_PREADESIONE =0 AND PROGETTO.ID_BANDO NOT IN (69, 40, 41, 42,88, 89))AS PROG   
		ON PROG.ID_PROGETTO = PIANO_INVESTIMENTI.ID_PROGETTO                     
WHERE ( (ID_INVESTIMENTO_ORIGINALE IS NULL AND FLAG_DEFINITIVO =0) OR (ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND FLAG_DEFINITIVO =1   AND ID_VARIANTE IS NULL) )   )

-- CALCOLO PREMIO CONTO CAPITALE ??? 

IF(@ULA<=3)  
	IF(@CONTRIBUTO_RICHIESTO > 1000000 ) SET @result =0
ELSE 
	IF((@CONTRIBUTO_RICHIESTO > (1000000 + @ULA*50000) ) OR (@CONTRIBUTO_RICHIESTO >  2000000 ))
	  SET @result =0
SELECT @result AS RESULT
END
