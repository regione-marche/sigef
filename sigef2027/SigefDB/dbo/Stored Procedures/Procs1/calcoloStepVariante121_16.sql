create  PROCEDURE [dbo].[calcoloStepVariante121_16]
 @ID_VARIANTE int
AS
BEGIN

-- 121 - verifica punteggio minimo = 9 calcolato sulle priorità A-B

DECLARE @IdSchedaValutazione int, @IdProgetto int

DECLARE @PesoPrioritaA decimal(10,2),@ValoreMAXPrioritaA decimal(10,2),
		@PesoPrioritaB decimal(10,2),@ValoreMAXPrioritaB decimal(10,2),
		@PunteggioPrioritaA decimal(10,4),@PunteggioPrioritaB decimal(10,4) 

SELECT @IdProgetto = ID_PROGETTO from VARIANTI where ID_VARIANTE = @ID_VARIANTE

SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

-- A: Investimenti relativi a tipologie indicate come priorità di settore
SET @PesoPrioritaA = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-- C: 121 - investimenti realizzati per i settori prioritari ed in territori preferenziali
SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 38 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 38 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-----------------------------------------------------------------
-- CALCOLO PRIORITA'

-- 121 - Investimenti relativi a tipologie indicate come prioritarie dal PSR per i settori produttivi di cui al cap.5
EXEC @PunteggioPrioritaA = calcoloPriorita121_3 @IdProgetto, 1,@ID_VARIANTE

 
-- 121 - Investimenti prioritari per il settore di destinazione
EXEC @PunteggioPrioritaB = calcoloPriorita121_1 @IdProgetto, 1,@ID_VARIANTE

-------------------------------------------------------------------
-- CALCOLO PUNTEGGIO PRIORITA' A+B 
-- Le stored procedure ritornano punteggi da dividere per 100

SELECT ( (((@PunteggioPrioritaA/100) * @PesoPrioritaA) / @ValoreMAXPrioritaA)  
        + (((@PunteggioPrioritaB/100) * @PesoPrioritaB) / @ValoreMAXPrioritaB)   
       ) AS PUNTEGGIO

END
