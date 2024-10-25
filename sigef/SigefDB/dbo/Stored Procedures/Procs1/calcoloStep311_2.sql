CREATE PROCEDURE [dbo].[calcoloStep311_2]
@IdProgetto int,@fase_istruttoria bit=0 

AS
BEGIN

-- Controllo valid per gli STEP:

-- 1. 311 - VERIFICA PUNTEGGIO MINIMO = 0,08 (CRITERI B-I-J-K) 
-- 2. 311 (zucchero) - VERIFICA PUNTEGGIO MINIMO = 0,08 (CRITERI B-H-I-J) (nello zucchero la H equivale alla B del PSR)

DECLARE @IdSchedaValutazione int
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

-- Priorità B (311 - investimenti destinati a migliorare i servizi agrituristici delle aziende) ID: 29

DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 29 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 29 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePrioritaB = calcoloPriorita311_1 @IdProgetto, @fase_istruttoria 

SET @PunteggioPrioritaB = ((@ValorePrioritaB/100) * @PesoPrioritaB) / @ValoreMAXPrioritaB

-- Priorità I (311 - Investimenti strutturali realizzati con tecniche di bioedilizia) ID: 27

DECLARE @PesoPrioritaI decimal(10,2)
DECLARE @ValoreMAXPrioritaI decimal(10,2)
DECLARE @ValorePrioritaI decimal(10,2)
DECLARE @PunteggioPrioritaI decimal(10,2)

SET @PesoPrioritaI = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 27 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaI = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 27 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaI = (SELECT VALORE = CASE WHEN COUNT(VP.PUNTEGGIO) > 0 THEN MAX(VP.PUNTEGGIO) ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PRIORITA = 27 AND PP.ID_PROGETTO = @IdProgetto)
SET @PunteggioPrioritaI = (@ValorePrioritaI * @PesoPrioritaI) / @ValoreMAXPrioritaI

-- Priorità J (311 - investimenti con riqualificazione architettonica riguardanti tutto il patrimonio aziendale) ID: 31

DECLARE @PesoPrioritaJ decimal(10,2)
DECLARE @ValoreMAXPrioritaJ decimal(10,2)
DECLARE @ValorePrioritaJ decimal(10,2)
DECLARE @PunteggioPrioritaJ decimal(10,2)

SET @PesoPrioritaJ = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 31 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaJ = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 31 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaJ = (SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 31 AND ID_PROGETTO = @IdProgetto)
SET @PunteggioPrioritaJ = (@ValorePrioritaJ * @PesoPrioritaJ) / @ValoreMAXPrioritaJ

-- Priorità K (311 - investimenti destinati all`utilizzo di fonti energetiche rinnovabili) ID: 62

DECLARE @PesoPrioritaK decimal(10,2)
DECLARE @ValoreMAXPrioritaK decimal(10,2)
DECLARE @ValorePrioritaK decimal(10,2)
DECLARE @PunteggioPrioritaK decimal(10,2)

SET @PesoPrioritaK = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 62 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaK = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 62 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaK = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 0.8 
                                                WHEN VP.CODICE = '2' THEN 1 
                                                WHEN VP.CODICE = '3' THEN 0.4 
                                                WHEN VP.CODICE = '4' THEN 0.6 
                                                ELSE 0 END 
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 62)

SET @PunteggioPrioritaK = (@ValorePrioritaK * @PesoPrioritaK) / @ValoreMAXPrioritaK

SELECT ( ISNULL(@PunteggioPrioritaB,0) + ISNULL(@PunteggioPrioritaI,0) + ISNULL(@PunteggioPrioritaJ,0) + ISNULL(@PunteggioPrioritaK,0)) AS PUNTEGGIO

	
END
