CREATE PROCEDURE [dbo].[calcoloStep121_12]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
 -- microfiliera  
 /*
 Per ciascun beneficiario è fissato un tetto massimo di contributo per il presente accoro di filiera pari a 100.000 Euro, 
 fermo restando che per le aziende agricole individuali e per le società agricole che impiegano fino a 3 ULA, il massimale stabilito in termini 
 di contributo pubblico è di € 500.000 per beneficiario per l’intero periodo di programmazione 2007-2013, per tutte le misure del primo asse e del terzo asse del presente Programma.
 Per le aziende agricole individuali e per le società agricole che impiegano oltre 3 ULA tale massimale è elevato di 50.000 € 
 per ogni ULA aggiuntiva e fino ad un massimo di € 1.000.000
 */


--CONTROLLO ULA IMPRESA

DECLARE @OreTotali decimal(10,2),  @OreTotaliColture decimal(10,2),
  @OreTotaliZootecnia decimal(10,2),  @OreTotaliAttivita decimal(10,2),
  @ULA INT, 	@id_impresa int, 	@result int
DECLARE @CONTRIBUTO_RICHIESTO DECIMAL(18,2),@CONTRIBUTO_RICHIESTO_TOT DECIMAL(18,2),
					@ID_PROG INT , @STATO CHAR(1), @ID_BANDO INT,  @COD_PSR VARCHAR(20), @CODICE VARCHAR(20)
SET @RESULT =1 --PONGO LO STEP VERIFICATO

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
SET @id_impresa= ( SELECT ID_IMPRESA FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto )

DECLARE PROGETTI CURSOR FOR
SELECT  ID_PROGETTO, STATO,  (CONTRIBUTO + ISNULL(PREMIO,0))  AS CONTRIBUTO 
FROM (	SELECT V.ID_VARIANTE, ISNULL(SP.ID_PROG_INTEGRATO,SP.ID_PROGETTO) AS ID_PROGETTO, STATO, SP.ID_BANDO,  
								dbo.calcoloContributoTotaleProgetto(ISNULL(SP.ID_PROGETTO,SP.ID_PROGETTO), FLAG_DEFINITIVO, v.ID_VARIANTE) AS CONTRIBUTO , 
								dbo.calcoloPremioContoCapitale( SP.ID_PROGETTO,FLAG_DEFINITIVO  , v.ID_VARIANTE)  AS PREMIO
					FROM  VPROGETTO SP   LEFT JOIN 
								( SELECT TOP(1) ID_VARIANTE , ID_PROGETTO FROM  VARIANTI    WHERE  APPROVATA = 1 ORDER BY ID_VARIANTE DESC) AS V ON V.ID_PROGETTO = SP.ID_PROGETTO
									WHERE SP.ID_PROGETTO IN  (SELECT ID_PROGETTO FROM vPROGETTO WHERE ID_IMPRESA= @id_impresa AND FLAG_PREADESIONE =0  AND COD_STATO NOT IN ('P','Q','B', 'R','N') OR ID_PROGETTO = @IdProgetto   )  
								 GROUP BY SP.ID_PROGETTO , STATO, SP.ID_BANDO, SP.ID_PROG_INTEGRATO, V.ID_VARIANTE, FLAG_DEFINITIVO) AS PROG
					GROUP BY ID_PROGETTO, STATO , CONTRIBUTO, PREMIO 

SET @CONTRIBUTO_RICHIESTO_TOT =0

OPEN PROGETTI
FETCH NEXT FROM PROGETTI 
INTO  @ID_PROG , @STATO , @CONTRIBUTO_RICHIESTO 
WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT  TOP(1) @COD_PSR = COD_PSR , @CODICE = PR.CODICE 
    FROM BANDO B INNER JOIN vzPROGRAMMAZIONE PR ON PR.ID= B.ID_PROGRAMMAZIONE  
	WHERE ID_BANDO = ( SELECT  ID_BANDO  FROM  PROGETTO  WHERE  ID_PROGETTO = @ID_PROG ) 
	IF( @COD_PSR LIKE 'PSR%' AND @CODICE NOT LIKE '2.%' )
			SET @CONTRIBUTO_RICHIESTO_TOT  = ISNULL(@CONTRIBUTO_RICHIESTO_TOT,0) + ISNULL(@CONTRIBUTO_RICHIESTO,0)
FETCH NEXT FROM PROGETTI 
INTO  @ID_PROG , @STATO,@CONTRIBUTO_RICHIESTO 
END
CLOSE PROGETTI
DEALLOCATE PROGETTI 
 

IF(@ULA<=3)  
	IF(@CONTRIBUTO_RICHIESTO > 500000 ) SET @result =0
ELSE 
	IF((@CONTRIBUTO_RICHIESTO > (500000 + @ULA*50000) ) or (@CONTRIBUTO_RICHIESTO >  1000000 ))
	  SET @result =0
SELECT @result AS RESULT
END
