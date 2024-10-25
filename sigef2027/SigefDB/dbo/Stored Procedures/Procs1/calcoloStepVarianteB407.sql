CREATE PROCEDURE [dbo].[calcoloStepVarianteB407]
@ID_VARIANTE int
AS
BEGIN
--declare @ID_VARIANTE int
--SET @ID_VARIANTE = XXX
-- mantenimento punteggio minimo in graduatoria

DECLARE @IdSchedaValutazione int, @IdProgetto int, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4)

SET @IdProgetto= (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)

SET @MINIMO_GRADUATORIA = (SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)
--SELECT @MINIMO_GRADUATORIA AS M
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)


--1121
--	Interventi attuati da soggetti rappresentativi del territorio, quali Enti, Associazioni di categoria e/o loro associazioni temporanee o di scopo	
-- SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1121

--1122
--Presenza di un legame diretto, in termini di immagine e di messaggio comunicato, con le diverse iniziative promozionali del territorio, attivate a livello istituzionale dalla Regione Marche.	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1122

--1123
-- Promozione territoriale che faccia riferimento in maniera sinergica ai tre principali elementi di attrazione del territorio marchigiano: bellezze naturali, patrimonio storico e culturale, prodotti enogastronomici di qualità.	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1123

--1124
-- Investimenti per la promozione delle aree protette o aree di elevato valore ambientale o di comprensori rurali caratterizzati dalla presenza di produzioni di qualità e/o di beni storico-architettonici e/o di tradizioni storiche e culturali individuati come prioritari dal piano di “Marketing Territoriale Integrato” di cui alla Scheda Intervento n. 11	
--SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1124



--select @MINIMO_GRADUATORIA, @ID_BANDO

-- ID_PRIORITA=1121	priorità A - Interventi attuati da soggetti rappresentativi del territorio, quali Enti, Associazioni di categoria e/o loro associazioni temporanee o di scopo	
DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1121 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1121 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaA =  (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1121)
SET @PunteggioPrioritaA = (@ValorePrioritaA * @PesoPrioritaA)
--select @PunteggioPrioritaA, '1121'
   
   
-- ID_PRIORITA=1122	priorità B - Presenza di un legame diretto, in termini di immagine e di messaggio comunicato, con le diverse iniziative promozionali del territorio, attivate a livello istituzionale dalla Regione Marche.	
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1122 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1122 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1122)
SET @PunteggioPrioritaB = (@ValorePrioritaB * @PesoPrioritaB) 
--select @PunteggioPrioritaB, '1122'


-- ID_PRIORITA=1123 priorità C - Promozione territoriale che faccia riferimento in maniera sinergica ai tre principali elementi di attrazione del territorio marchigiano: bellezze naturali, patrimonio storico e culturale, prodotti enogastronomici di qualità.	
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1123 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1123 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1123)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)  
--select @PunteggioPrioritaC, '1123'

--ID_PRIORITA= 1124	priorità D - Investimenti per la promozione delle aree protette o aree di elevato valore ambientale o di comprensori rurali caratterizzati dalla presenza di produzioni di qualità e/o di beni storico-architettonici e/o di tradizioni storiche e culturali individuati come prioritari dal piano di “Marketing Territoriale Integrato” di cui alla Scheda Intervento n. 11	
 DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
DECLARE @PunteggioPrioritaD decimal(10,2)

SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1124 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1124 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaD = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1124)
SET @PunteggioPrioritaD =  (@ValorePrioritaD * @PesoPrioritaD)  
--select @PunteggioPrioritaD, '654'

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) 
								  +ISNULL(@PunteggioPrioritaC,0) +ISNULL(@PunteggioPrioritaD,0)))
							 
--select @PUNTEGGIO_VARIANTE , @MINIMO_GRADUATORIA
IF(@PUNTEGGIO_VARIANTE > isnull(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
