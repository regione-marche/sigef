CREATE PROCEDURE [dbo].[calcoloStepVariante_B278]
@ID_VARIANTE int
AS
BEGIN

-- Controllo valido per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA:
-- i punteggi in graduatoria sono relativi a 100 -->  divido per 100 

-- D
--A-Legame diretto con le iniziative promozionali attivate della Regione Marche
-- SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 956	

-- D
--B-Promozione territoriale che faccia riferimento in maniera sinergica ai tre principali elementi di 
--attrazione del territorio marchigiano: bellezze naturali, patrimonio storico e culturale, prodotti enogastronomici di qualità	
-- SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 957

-- D
--C- Rappresentatività del soggetto proponente sia in termini di territorio che di popolazione o di operatori residenti in area GAL	
-- SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1   WHEN VP.CODICE = '2' THEN 0.75   WHEN VP.CODICE = '3' THEN 0.50   WHEN VP.CODICE = '4' THEN 0.25   ELSE 0  END   FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 958	D

-- D
--D- Presentazione del progetto da parte di forme associative finalizzate alla promozione e valorizzazione del 
-- territorio del Montefeltro costituite o da costituirsi	
-- SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1   WHEN VP.CODICE = '2' THEN 0.75   WHEN VP.CODICE = '3' THEN 0.50   ELSE 0  END   FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 969	D


DECLARE @IdSchedaValutazione int, @IdProgetto INT, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4), @CountNonFinanziabili INT, @CountFinanziabilaParziale INT

SET @IdProgetto= (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)


--------------------   Qui imposto valore minimo punteggio    --------------------

SET @CountNonFinanziabili = (SELECT COUNT(*) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N')
SET @CountFinanziabilaParziale = (SELECT COUNT(*) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='P')

IF (@CountNonFinanziabili > 0) 
	SET @MINIMO_GRADUATORIA = (SELECT TOP(1) ISNULL(PUNTEGGIO,0) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)	
ELSE	
	SET @MINIMO_GRADUATORIA = 0
	
IF (@CountFinanziabilaParziale > 0) 
		SET @MINIMO_GRADUATORIA = (SELECT TOP(1) ISNULL(PUNTEGGIO,0) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='P' ORDER BY PUNTEGGIO DESC)

----------------------------------------------------------------------------------------

SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)
 
 ----------------------------------------------------------------------------------------

 -- 956 Legame diretto con le iniziative promozionali attivate della Regione Marche - D
DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 956 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 956 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaA =  ( SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 956)
SET @PunteggioPrioritaA = (@ValorePrioritaA * @PesoPrioritaA)

-----------------------------------------------------------------------------------------

-- 957 Promozione territoriale che faccia riferimento in maniera sinergica ai tre principali elementi di 
--attrazione del territorio marchigiano: bellezze naturali, patrimonio storico e culturale, prodotti enogastronomici di qualità

DECLARE @PunteggioPrioritaB decimal(10,2)
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)

SET @PesoPrioritaB= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 957 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 957 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB =  ( SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 957)
SET @PunteggioPrioritaB = (@ValorePrioritaB * @PesoPrioritaB)

----------------------------------------------------------------------------------------

 -- 958 Rappresentatività del soggetto proponente sia in termini di territorio che di popolazione o di operatori residenti in area GAL		
DECLARE @PunteggioPrioritaC decimal(10,2)
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
 
SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 958 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 958 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaC = (SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.75 WHEN VP.CODICE = '3' THEN 0.50 WHEN VP.CODICE = '4' THEN 0.25 ELSE 0 END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 958)
SET @PunteggioPrioritaC =  (@ValorePrioritaC * @PesoPrioritaC)  

----------------------------------------------------------------------------------------

 -- 969 Rappresentatività del soggetto proponente sia in termini di territorio che di popolazione o di operatori residenti in area GAL		
DECLARE @PunteggioPrioritaD decimal(10,2)
DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
 
SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 969 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 969 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaD = (SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.75 WHEN VP.CODICE = '3' THEN 0.50 ELSE 0 END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 969)
SET @PunteggioPrioritaD =  (@ValorePrioritaD * @PesoPrioritaD)  

----------------------------------------------------------------------------------------

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)

SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0) +ISNULL(@PunteggioPrioritaD,0)))
select @PUNTEGGIO_VARIANTE as  PUNTEGGIO_VARIANTE

IF(@PUNTEGGIO_VARIANTE > ISNULL(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
