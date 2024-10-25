CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento121_5]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- BANDO 121 pabs 
-- Controllo valido per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA:

DECLARE @IdSchedaValutazione int, @IdProgetto int
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4), @PesoPriorita112A DECIMAL(18,4), @ValoreMAXPriorita112A DECIMAL(18,4), @ValorePriorita112A DECIMAL(18,4),
		@PesoPriorita112C DECIMAL(18,4), @ValoreMAXPriorita112C DECIMAL(18,4), @ValorePriorita112C DECIMAL(18,4),
		@PesoPriorita112D DECIMAL(18,4), @ValoreMAXPriorita112D DECIMAL(18,4), @ValorePriorita112D DECIMAL(18,4) 

DECLARE @PunteggioPriorita112A decimal(10,4) 


SET @MINIMO_GRADUATORIA = ( SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = 42 AND FINANZIABILITA ='N'
							ORDER BY PUNTEGGIO DESC)
 
SET @IdProgetto= ( SELECT ID_PROGETTO FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO= @ID_DOMANDA_PAGAMENTO )
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

-- A  121 - Investimenti realizzati da cooperative sociali di tipo "B"

DECLARE @PunteggioPriorita121A DECIMAL (18,6)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 20 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 20 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaA =  ( SELECT COUNT(ID_PRIORITA) AS PUNTEGGIO   FROM PRIORITA_X_PROGETTO PP   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 20 )
SET @PunteggioPriorita121A = ((@ValorePrioritaA ) * @PesoPrioritaA)

-- B.	Investimenti realizzati da Imprenditori Agricoli Professionali (IAP) ai sensi del d.lgs. 99/04 e succ. mod. e int.
DECLARE @PunteggioPriorita121B DECIMAL (18,6)
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)

SET @PesoPrioritaB= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 21 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 21 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaB =  ( SELECT COUNT(ID_PRIORITA) AS PUNTEGGIO   FROM PRIORITA_X_PROGETTO PP   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 21 )
SET @PunteggioPriorita121B = ((@ValorePrioritaB ) * @PesoPrioritaB)

-- C.	 121 - Investimenti realizzati da giovane agricoltore o imprenditrice
 DECLARE @PunteggioPriorita121C DECIMAL (18,6)
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)

SET @PesoPrioritaC= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 51 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 51  AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaC =  ( SELECT COUNT(ID_PRIORITA) AS PUNTEGGIO   FROM PRIORITA_X_PROGETTO PP   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 51  )
SET @PunteggioPriorita121C = ((@ValorePrioritaC ) * @PesoPrioritaC)
  
 
--D  121 - Investimenti relativi a tipologie indicate come prioritarie dal PSR per i settori produttivi di cui al cap.5
 DECLARE @PunteggioPriorita121D DECIMAL (18,6), @PesoPriorita121D decimal (18,6), @ValoreMAXPriorita121D decimal (18,6), @ValorePriorita121D decimal (18,6)

SET @PesoPriorita121D= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPriorita121D = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 22 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePriorita121D =  calcoloPrioritaRequisitoPagamento121_3  @ID_DOMANDA_PAGAMENTO, @IdProgetto
SET @PunteggioPriorita121D = ( ((@ValorePriorita121D/100)*@PesoPriorita121D) /@ValoreMAXPriorita121D  ) 


-- E 121 - Investimenti di ammodernamento o 
-- ricostruzione con tecniche di risparmio energetico (escluso l`acquisto di macchine e attrezzature agricole)

 DECLARE @PunteggioPriorita121E DECIMAL (18,6), @PesoPriorita121E decimal (18,6), @ValoreMAXPriorita121E decimal (18,6), @ValorePriorita121E decimal (18,6)

SET @PesoPriorita121E= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 23 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPriorita121E = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 23 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePriorita121E =    calcoloPrioritaRequisitoPagamento121_2   @ID_DOMANDA_PAGAMENTO, @IdProgetto
SET @PunteggioPriorita121E = ( ((@ValorePriorita121E/100)*@PesoPriorita121E) /@ValoreMAXPriorita121E  ) 


-- F 121 - investimenti realizzati per i settori prioritari ed in territori preferenziali (zucchero)

 DECLARE @PunteggioPriorita121F DECIMAL (18,6), @PesoPriorita121F decimal (18,6), @ValoreMAXPriorita121F decimal (18,6), @ValorePriorita121F decimal (18,6)

SET @PesoPriorita121F= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 86 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPriorita121F = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 86 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePriorita121F =    calcoloPrioritaRequisitoPagamento121_4   @ID_DOMANDA_PAGAMENTO, @IdProgetto
SET @PunteggioPriorita121F = ( ((@ValorePriorita121F/100)*@PesoPriorita121F) /@ValoreMAXPriorita121F  ) 

DECLARE @PUNTEGGIO_PAGAMENTO DECIMAL(18,4)
 SET @PUNTEGGIO_PAGAMENTO = ( SELECT ( ISNULL(@PunteggioPriorita121A,0) +ISNULL(@PunteggioPriorita121B,0) +ISNULL(@PunteggioPriorita121C,0) +  
(ISNULL(@PunteggioPriorita121D,0)*100) + (ISNULL(@PunteggioPriorita121E,0)*100) + (ISNULL(@PunteggioPriorita121F,0)*100)) )
 
 IF(@PUNTEGGIO_PAGAMENTO > @MINIMO_GRADUATORIA )SELECT 1 AS RESULT
ELSE 
	 SELECT 0 AS RESULT
	
END
