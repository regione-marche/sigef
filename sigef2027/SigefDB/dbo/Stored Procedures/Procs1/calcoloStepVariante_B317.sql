CREATE PROCEDURE [dbo].[calcoloStepVariante_B317]
@ID_VARIANTE int
AS
BEGIN

-- Controllo validO per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA:
-- i punteggi in graduatoria sono relativi a 100 -->  divido per 100 

-- id 1044 tipologia dei servizi attivati	SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.6 WHEN VP.CODICE = '3' THEN 0.3 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1044	50.00
-- id 1045 avvio dei servizi destinati a creare occupazione	SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1045	15.00
-- id 1046 capacità di creare reti di associazionismo locale	SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1046	35.00


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
 --1044 tipologia dei servizi attivati D
DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)
 
SET @PesoPrioritaA = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1044 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1044 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaA = (SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.6  WHEN VP.CODICE = '3' THEN 0.3  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1044)
SET @PunteggioPrioritaA =  (@ValorePrioritaA * @PesoPrioritaA)  

 ----------------------------------------------------------------------------------------
 
 --1045 avvio dei servizi destinati a creare occupazione	
DECLARE @PunteggioPrioritaB decimal(10,2)
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
 
SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1045 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1045 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaB = (SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0 END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1045)
SET @PunteggioPrioritaB =  (@ValorePrioritaB * @PesoPrioritaB)  

----------------------------------------------------------------------------------------

 --1046 capacità di creare reti di associazionismo locale
DECLARE @PunteggioPrioritaC decimal(10,2)
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)

SET @PesoPrioritaC= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1046 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1046 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaC =  ( SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1046)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)

----------------------------------------------------------------------------------------

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)

SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0)))
select @PUNTEGGIO_VARIANTE as  PUNTEGGIO_VARIANTE

IF(@PUNTEGGIO_VARIANTE > ISNULL(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
