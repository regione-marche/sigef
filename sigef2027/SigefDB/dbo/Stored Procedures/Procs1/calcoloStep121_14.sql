CREATE PROCEDURE [dbo].[calcoloStep121_14]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
 -- BANDO 121 LIGHT
 /* 
	In ogni caso il massimale di aiuto per beneficiario (CUAA) per l’intero periodo di programmazione 2007-2013, 
	per tutte le misure del primo asse e del terzo asse del presente Programma ammonta complessivamente ad € 500.000 per aziende che impiegano meno di 3 ULA, 
	e di € 1.000.000 per aziende che impiegano più di 3 ULA.
 */
--CONTROLLO ULA IMPRESA

DECLARE @OreTotali decimal(10,2),@OreTotaliColture decimal(10,2),@ID_IMPRESA INT,
		@OreTotaliZootecnia decimal(10,2),@OreTotaliAttivita decimal(10,2),
		@ULA INT, @CUAA VARCHAR(16), @result int

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
IF ((@OreTotali * 0.2) > 400) SET @OreTotali = @OreTotali + 400
ELSE 
	SET @OreTotali = @OreTotali + (@OreTotali * 0.2)

SET @ULA = (@OreTotali/1800)  --TOTALE ULA PLV ANNO CORRENTE ASSOCIATA AL PROGETTO

 -- CONTRIBUTO RICHIESTO AMMISSIBILE PER LE DOMANDE AMMISSIBILI DELL'IMPRESA (il contriburo va calcolato solo per le domande del PSR e non per i bandi PABS )
DECLARE @CONTRIBUTO_RICHIESTO DECIMAL(18,2), @CONTRIBUTO_RICHIESTO_ATTUALE DECIMAL(18,2)

SELECT @CONTRIBUTO_RICHIESTO_ATTUALE = DBO.calcoloContributoTotaleProgetto(@IdProgetto, @FASE_ISTRUTTORIA, NULL)
SET @CONTRIBUTO_RICHIESTO = (SELECT  Sum(ISNULL (GP.CONTRIBUTO_TOTALE  ,0)) as CONTRIBUTO
							  FROM VPROGETTO P 
									INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO  
									INNER JOIN vzPROGRAMMAZIONE PROG ON PROG.id= b.ID_PROGRAMMAZIONE  AND PROG.COD_PSR like 'PSR%'
									INNER JOIN GRADUATORIA_PROGETTI GP ON GP.ID_PROGETTO = P.ID_PROGETTO
								WHERE P.ID_IMPRESA =@ID_IMPRESA AND P.ORDINE_FASE >3 AND COD_STATO NOT IN ('P','Q','B','R', 'N')AND FLAG_PREADESIONE =0 
 )
-- CALCOLO PREMIO CONTO CAPITALE ???

SET @CONTRIBUTO_RICHIESTO = ISNULL(@CONTRIBUTO_RICHIESTO,0) + ISNULL(@CONTRIBUTO_RICHIESTO_ATTUALE,0)
IF(@ULA<=3) BEGIN IF(@CONTRIBUTO_RICHIESTO > 500000 ) SET @result =0 END
ELSE 
	BEGIN 
		SET @ULA = @ULA - 3 
		IF((@CONTRIBUTO_RICHIESTO > (@ULA * 50000 + 500000)) OR (@CONTRIBUTO_RICHIESTO > 1000000)) SET @result =0
	END
SELECT @result AS RESULT
END
