CREATE PROCEDURE [dbo].[calcoloStep311_MF_1]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN

-- I richiedenti ai quali, nei tre anni precedenti, ai sensi di altre normative, fosse già stato assegnato un contributo pubblico per interventi finalizzati all’attività agrituristica, 
-- senza aver ancora raggiunto il tetto massimo dei 200.000 euro, potranno presentare nuova istanza di finanziamento per il valore residuale, purché la stessa, naturalmente, non riguardi spese già rendicontate. 
 

DECLARE @ID_IMPRESA INT, @result int
SET @RESULT =1 --PONGO LO STEP VERIFICATO

 -- CONTRIBUTO RICHIESTO FINANZIABILE PER LE DOMANDE FINANZIABILI  DELL'IMPRESA (il contriburo va calcolato solo per le domande del PRESENTATE SULLA MISURA 311  )
 
DECLARE @CONTRIBUTO_RICHIESTO DECIMAL(18,2)
SELECT @ID_IMPRESA = ID_IMPRESA FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto 

SET @CONTRIBUTO_RICHIESTO = (SELECT SUM(CONTRIBUTO) FROM (
							 SELECT dbo.calcoloContributoTotaleProgetto(ID_PROGETTO , 1, NULL) AS CONTRIBUTO 
							 FROM ( SELECT DISTINCT PROGETTO.ID_PROGETTO, FLAG_DEFINITIVO 
									FROM PROGETTO 
										INNER JOIN PROGETTO_STORICO ON PROGETTO.ID_PROGETTO = PROGETTO_STORICO.ID_PROGETTO
													 AND (COD_STATO IN ('F') OR (PROGETTO_STORICO.ID_PROGETTO = @IdProgetto))
									WHERE ID_IMPRESA = @ID_IMPRESA AND FLAG_PREADESIONE =0
										  AND PROGETTO.ID_BANDO IN (SELECT B.ID_BANDO FROM BANDO AS B INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE LIKE '3%'
																	GROUP BY B.ID_BANDO, B.DESCRIZIONE)
								)AS PROG)AS SOMMA )    
								               
IF(@CONTRIBUTO_RICHIESTO > 200000)SET @RESULT =0
SELECT @result AS RESULT

END
