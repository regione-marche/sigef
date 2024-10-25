CREATE PROCEDURE [dbo].[calcoloStepVariante123b_B306]
@ID_VARIANTE int
AS
BEGIN
 
---================ MANTENIMENTO PUNTEGGIO MINIMO ================---
--A --Ricaduta positiva sui produttori forestali di base	40.00	SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 911
--B --Investimenti da realizzare in area C3 e D	30.00	SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 912
--C --Qualificazione dell`impresa	12.00	SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 913
--D --Prevalenza lavorativa forestale dell`impresa	7.00	SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.7 WHEN VP.CODICE = '3' THEN 0.3 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 914
--E --Occupazione dell`impresa	5.00	SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.7 WHEN VP.CODICE = '3' THEN 0.3 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 915
--F --Dimensione economica dell`impresa	5.00	SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 916
--G --Domande di aiuto presentate da microimprese il cui legale rappresentante è giovane imprenditore	0.50	SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 917
--H --Domande di aiuto presentate da microimprese il cui legale rappresentante è una donna	0.50	SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 918

--declare @ID_VARIANTE int
--SET @ID_VARIANTE = 


DECLARE @IdSchedaValutazione int, @IdProgetto int, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4)

SET @IdProgetto= (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)

SET @MINIMO_GRADUATORIA = (SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)
--SELECT @MINIMO_GRADUATORIA AS M
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)


-- PRIORITA A - Ricaduta positiva sui produttori forestali di base - ID 911
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)
DECLARE @PunteggioPrioritaA decimal(10,2)

SET @PesoPrioritaA = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 911 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 911 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaA = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1
												WHEN VP.CODICE = '2' THEN 0.5
												ELSE 0 END
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 911)

SET @PunteggioPrioritaA = (@ValorePrioritaA * @PesoPrioritaA) 



-- PRIORITA B - Investimenti da realizzare in area C3 e D - ID 912
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 912 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 912 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1
												WHEN VP.CODICE = '2' THEN 0.5
												ELSE 0 END
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 912)

SET @PunteggioPrioritaB = (@ValorePrioritaB * @PesoPrioritaB) 


-- PRIORITA C - Qualificazione dell`impresa - ID 913
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 913 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 913 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1
												WHEN VP.CODICE = '2' THEN 0.5
												ELSE 0 END
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 913)

SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC) 


-- PRIORITA D - Prevalenza lavorativa forestale dell`impresa - ID 914
DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
DECLARE @PunteggioPrioritaD decimal(10,2)

SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 914 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 914 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaD = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 
												WHEN VP.CODICE = '2' THEN 0.7
												WHEN VP.CODICE = '3' THEN 0.3
												ELSE 0 END
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 914)

SET @PunteggioPrioritaD = (@ValorePrioritaD * @PesoPrioritaD) 

-- PRIORITA E - Occupazione dell`impresa - ID 915
DECLARE @PesoPrioritaE decimal(10,2)
DECLARE @ValoreMAXPrioritaE decimal(10,2)
DECLARE @ValorePrioritaE decimal(10,2)
DECLARE @PunteggioPrioritaE decimal(10,2)

SET @PesoPrioritaE = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 915 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaE = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 915 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaE = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 
												WHEN VP.CODICE = '2' THEN 0.7
												WHEN VP.CODICE = '3' THEN 0.3
												ELSE 0 END
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 915)

SET @PunteggioPrioritaE = (@ValorePrioritaE * @PesoPrioritaE) 


-- PRIORITA F - Dimensione economica dell`impresa - ID 916
DECLARE @PesoPrioritaF decimal(10,2)
DECLARE @ValoreMAXPrioritaF decimal(10,2)
DECLARE @ValorePrioritaF decimal(10,2)
DECLARE @PunteggioPrioritaF decimal(10,2)

SET @PesoPrioritaF = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 916 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaF = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 916 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaF = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 
 												WHEN VP.CODICE = '2' THEN 0.5 
												ELSE 0 END
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 916)

SET @PunteggioPrioritaF = (@ValorePrioritaF * @PesoPrioritaF) 

-- Priorità G - Domande di aiuto presentate da microimprese il cui legale rappresentante è giovane imprenditore - ID 917
DECLARE @PesoPrioritaG decimal(10,2)
DECLARE @ValoreMAXPrioritaG decimal(10,2)
DECLARE @ValorePrioritaG decimal(10,2)
DECLARE @PunteggioPrioritaG decimal(10,2)

SET @PesoPrioritaG = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 917 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaG = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 917 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaG = (SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 917)

SET @PunteggioPrioritaG = (@ValorePrioritaG * @PesoPrioritaG)


-- Priorità H - Domande di aiuto presentate da microimprese il cui legale rappresentante è una donna - ID 918
DECLARE @PesoPrioritaH decimal(10,2)
DECLARE @ValoreMAXPrioritaH decimal(10,2)
DECLARE @ValorePrioritaH decimal(10,2)
DECLARE @PunteggioPrioritaH decimal(10,2)

SET @PesoPrioritaH = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 918 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaH = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 918 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaH = (SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 918)

SET @PunteggioPrioritaH = (@ValorePrioritaH * @PesoPrioritaH)


---- == VERIFICO MANTENIMENTO PUNTEGGIO MINIMO IN GRADUATORIA == ----

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0) +
								   ISNULL(@PunteggioPrioritaD,0) +ISNULL(@PunteggioPrioritaE,0) +ISNULL(@PunteggioPrioritaF,0) +
								   ISNULL(@PunteggioPrioritaG,0) +ISNULL(@PunteggioPrioritaH,0)))
							 
--select @PUNTEGGIO_VARIANTE , @MINIMO_GRADUATORIA
IF(@PUNTEGGIO_VARIANTE >= isnull(@MINIMO_GRADUATORIA,0))SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
