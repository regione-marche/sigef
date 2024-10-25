CREATE PROCEDURE [dbo].[calcoloStepVariante121_1]
@ID_VARIANTE int
AS
BEGIN

-- 121 - verifica punteggio minimo = 20 calcolato sulle priorità A-B-C

DECLARE @IdSchedaValutazione int, @IdProgetto INT

DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)

DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)

DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)

DECLARE @PunteggioPrioritaA decimal(10,4)
DECLARE @PunteggioPrioritaB decimal(10,4)
DECLARE @PunteggioPrioritaC decimal(10,4)


SET @IdProgetto = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE )

SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

-- A: Investimenti relativi a tipologie indicate come priorità di settore
SET @PesoPrioritaA = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-- B: 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico (escluso l`acquisto di macchine e attrezzature agricole)
SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 23 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 23 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-- C: 121 - investimenti realizzati per i settori prioritari ed in territori preferenziali
SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 38 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 38 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)


-----------------------------------------------------------------
-- CALCOLO PRIORITA'

-- 121 - Investimenti relativi a tipologie indicate come prioritarie dal PSR per i settori produttivi di cui al cap.5
EXEC @PunteggioPrioritaA =  calcoloPrioritaVariante121_3 @ID_VARIANTE, @IdProgetto

-- 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico (escluso l`acquisto di macchine e attrezzature agricole)
EXEC @PunteggioPrioritaB = calcoloPrioritaVariante121_2 @ID_VARIANTE,  @IdProgetto

-- 121 - Investimenti prioritari per il settore di destinazione
EXEC @PunteggioPrioritaC = calcoloPrioritaVariante121_1 @ID_VARIANTE

-------------------------------------------------------------------
-- CALCOLO PUNTEGGIO PRIORITA' A+B+C
-- Le stored procedure ritornano punteggi da dividere per 100

SELECT ( (((@PunteggioPrioritaA/100) * @PesoPrioritaA) / @ValoreMAXPrioritaA)  
        + (((@PunteggioPrioritaB/100) * @PesoPrioritaB) / @ValoreMAXPrioritaB)  
        + (((@PunteggioPrioritaC/100) * @PesoPrioritaC) / @ValoreMAXPrioritaC)  
       ) AS PUNTEGGIO

END
