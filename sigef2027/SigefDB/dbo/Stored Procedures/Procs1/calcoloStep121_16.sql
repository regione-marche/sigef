CREATE PROCEDURE [dbo].[calcoloStep121_16]
@IdProgetto int,
@fase_istruttoria bit=0

AS
BEGIN

-- 121 - verifica punteggio minimo = 9 calcolato sulle priorità A-B

DECLARE @IdSchedaValutazione int, @ID_BANDO INT 

DECLARE @PesoPrioritaA decimal(10,2),@ValoreMAXPrioritaA decimal(10,2),
		@PesoPrioritaB decimal(10,2),@ValoreMAXPrioritaB decimal(10,2),
		@PunteggioPrioritaA decimal(10,4),@PunteggioPrioritaB decimal(10,4) 

  SELECT @IdSchedaValutazione = ID_SCHEDA_VALUTAZIONE, @ID_BANDO =B.ID_BANDO  FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) 
  WHERE P.ID_PROGETTO = @IdProgetto 

-- A: Investimenti relativi a tipologie indicate come priorità di settore
SET @PesoPrioritaA = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-- C: 121 - investimenti realizzati per i settori prioritari ed in territori preferenziali
SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 38 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 38 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-----------------------------------------------------------------
-- CALCOLO PRIORITA'

-- 121 - Investimenti relativi a tipologie indicate come prioritarie dal PSR per i settori produttivi di cui al cap.5
EXEC @PunteggioPrioritaA = calcoloPriorita121_3 @IdProgetto, @fase_istruttoria

 
-- 121 - Investimenti prioritari per il settore di destinazione
IF(@ID_BANDO =434) EXEC @PunteggioPrioritaB = calcoloPriorita121_5 @IdProgetto, @fase_istruttoria
ELSE EXEC @PunteggioPrioritaB = calcoloPriorita121_1 @IdProgetto, @fase_istruttoria

-------------------------------------------------------------------
-- CALCOLO PUNTEGGIO PRIORITA' A+B 
-- Le stored procedure ritornano punteggi da dividere per 100

SELECT ( (((@PunteggioPrioritaA/100) * @PesoPrioritaA) / @ValoreMAXPrioritaA)  
        + (((@PunteggioPrioritaB/100) * @PesoPrioritaB) / @ValoreMAXPrioritaB)   
       ) AS PUNTEGGIO

END
