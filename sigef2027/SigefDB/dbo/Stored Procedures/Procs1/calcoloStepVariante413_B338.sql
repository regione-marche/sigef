CREATE PROCEDURE [dbo].[calcoloStepVariante413_B338]
@ID_VARIANTE int
AS
BEGIN
-- Sottomisura 4.1.3.4 Sviluppo rinnovamento villaggi Mis 322 Sub az b) Interventi pilota recupero borghi rurali storici minori (nuclei abitati di antico impianto con popolazione inferiore  700 abitanti)     
-- € 250.000,00 Fondi PREMIALITA’
-- Controllo validO per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA: 
-- i punteggi in graduatoria sono relativi a 100 --> non divido per 100 


----462	Investimenti realizzati in aree natura 2000	
--SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 462

----610	Investimenti integrativi rispetto ad interventi FESR realizzati nei medesimi siti oggetto dell`intervento ma nettamente distinti tra loro	
--SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 610

----611	Investimenti realizzati in Comuni con meno di 2.000 abitanti	
--SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 611

----612	Investimenti realizzati in Comuni con densità abitativa inferiore a 50 abitanti per Km2	
--SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 612

----614	Progetti che perseguano la massima integrazione tra i diversi interventi – iniziative, promossi dal PSL	
--SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.75 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 614

----615	Progetti promossi da Comuni i cui territori ricadono anche parzialmente in un`area protetta	
--SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PRIORITA = 615 AND   ID_PROGETTO = @IdProgetto


--declare @ID_VARIANTE int
--SET @ID_VARIANTE = 2027
DECLARE @IdSchedaValutazione int, @IdProgetto int, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4)

SET @IdProgetto= ( SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)


SET @MINIMO_GRADUATORIA = (   SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)
--SELECT @MINIMO_GRADUATORIA AS M
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)


-- priorita A  	
-- Investimenti realizzati in aree natura 2000 - ID_PRIORITA = 462
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 462
DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 462 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 462 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaA =  (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 462)
SET @PunteggioPrioritaA = ((@ValorePrioritaA ) * @PesoPrioritaA)
   
-- Priorità B (610 - Investimenti integrativi rispetto ad interventi FESR realizzati nei medesimi siti oggetto dell`intervento ma nettamente distinti tra loro)
--SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 610
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 610 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 610 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 610)
SET @PunteggioPrioritaB = ((@ValorePrioritaB ) * @PesoPrioritaB)

-- C Investimenti realizzati in Comuni con meno di 2.000 abitanti	
----611	Investimenti realizzati in Comuni con meno di 2.000 abitanti	
--SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 611
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 611 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 611 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 611)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)  

--D	Investimenti realizzati in Comuni con densità abitativa inferiore a 50 abitanti per Km2	
----612	Investimenti realizzati in Comuni con densità abitativa inferiore a 50 abitanti per Km2	
--SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 612
DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
DECLARE @PunteggioPrioritaD decimal(10,2)

SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 612 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 612 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaD = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 612)
SET @PunteggioPrioritaD =  (@ValorePrioritaD * @PesoPrioritaD)  

-- E Investimenti realizzati da imprenditrici
----614	Progetti che perseguano la massima integrazione tra i diversi interventi – iniziative, promossi dal PSL	
--SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.75 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 614
DECLARE @PesoPrioritaE decimal(10,2)
DECLARE @ValoreMAXPrioritaE decimal(10,2)
DECLARE @ValorePrioritaE decimal(10,2)
DECLARE @PunteggioPrioritaE decimal(10,2)

SET @PesoPrioritaE = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 614 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaE = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 614 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaE = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.75 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 614)
SET @PunteggioPrioritaE =  (@ValorePrioritaE * @PesoPrioritaE)  

-- F Progetti promossi da Comuni i cui territori ricadono anche parzialmente in un`area protetta	
----615	Progetti promossi da Comuni i cui territori ricadono anche parzialmente in un`area protetta	
--SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PRIORITA = 615 AND   ID_PROGETTO = @IdProgetto
DECLARE @PesoPrioritaF decimal(10,2)
DECLARE @ValoreMAXPrioritaF decimal(10,2)
DECLARE @ValorePrioritaF decimal(10,2)
DECLARE @PunteggioPrioritaF decimal(10,2)

SET @PesoPrioritaF = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 615 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaF = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 615 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaF = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PRIORITA = 615 AND   ID_PROGETTO = @IdProgetto)
SET @PunteggioPrioritaF =  (@ValorePrioritaF * @PesoPrioritaF)  


DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)

SET @PUNTEGGIO_VARIANTE = ( SELECT ( ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0) +
									ISNULL(@PunteggioPrioritaD,0) +ISNULL(@PunteggioPrioritaE,0) + ISNULL(@PunteggioPrioritaF,0)))
							 
 
IF(@PUNTEGGIO_VARIANTE > @MINIMO_GRADUATORIA )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
