CREATE PROCEDURE [dbo].[calcoloStep112_121_5]
@IdProgetto int, @fase_istruttoria int =0
AS
BEGIN

--declare @IdProgetto int, @fase_istruttoria int 
--set @IdProgetto= 5648  
--set @fase_istruttoria = 1

-- 121 - verifica punteggio minimo = 20 calcolato sulle priorità A-B-C
--DECLARE @IdProgetto INT 
--SET @IdProgetto = 5972

DECLARE @IdSchedaValutazione int

DECLARE @PesoPrioritaA decimal(10,2),@ValoreMAXPrioritaA decimal(10,2)
DECLARE @PesoPrioritaB decimal(10,2),@ValoreMAXPrioritaB decimal(10,2)
DECLARE @PesoPrioritaC decimal(10,2),@ValoreMAXPrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaA decimal(10,4), @PunteggioPrioritaB decimal(10,4),@PunteggioPrioritaC decimal(10,4)

-- TROVO IL PROGETTO INTEGRATO
DECLARE @ID_PROG_CORRENTE_121 INT, @ID_PROG_INTEG_311 INT, @ID_PROG_INTEG_111 INT,@ID_PROG_INTEG_114 INT,
		@ID_BANDO_112 INT, @ID_BANDO_121 INT, @ID_BANDO_311 INT,@ID_BANDO_111 INT,@ID_BANDO_114 INT

SELECT DISTINCT @ID_PROG_CORRENTE_121 = p.ID_PROGETTO, @ID_BANDO_121=P.ID_BANDO FROM PROGETTO P
		INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.2.1.'
WHERE ID_PROG_INTEGRATO = @IdProgetto

 

SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B WHERE ID_BANDO = @ID_BANDO_121)
 
-- A: Investimenti relativi a tipologie indicate come priorità di settore
SET @PesoPrioritaA = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-- B: 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico (escluso l`acquisto di macchine e attrezzature agricole)
SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 23 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 23 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

-- C: 121 - investimenti realizzati per i settori prioritari ed in territori preferenziali
SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 112 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 112 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)


-----------------------------------------------------------------
-- CALCOLO PRIORITA'

-- 121 - Investimenti relativi a tipologie indicate come prioritarie dal PSR per i settori produttivi di cui al cap.5
 EXEC @PunteggioPrioritaA = calcoloPriorita121_3 @ID_PROG_CORRENTE_121,@fase_istruttoria,null
 
-- 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico (escluso l`acquisto di macchine e attrezzature agricole)
  EXEC @PunteggioPrioritaB = calcoloPriorita121_2 @ID_PROG_CORRENTE_121, @fase_istruttoria,null
 
-- 121 - Investimenti prioritari per il settore di destinazione
  EXEC @PunteggioPrioritaC = calcoloPriorita112_121_2 @ID_PROG_CORRENTE_121, @fase_istruttoria,null

 -------------------------------------------------------------------
-- CALCOLO PUNTEGGIO PRIORITA' A+B+C
-- Le stored procedure ritornano punteggi da dividere per 100

SELECT ( (((@PunteggioPrioritaA/100) * @PesoPrioritaA) / @ValoreMAXPrioritaA)  
        + (((@PunteggioPrioritaB/100) * @PesoPrioritaB) / @ValoreMAXPrioritaB)  
        + (((@PunteggioPrioritaC/100) * @PesoPrioritaC) / @ValoreMAXPrioritaC)  
       ) AS PUNTEGGIO

END
