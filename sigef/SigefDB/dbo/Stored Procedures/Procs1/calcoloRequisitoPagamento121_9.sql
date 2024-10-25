CREATE   PROCEDURE [dbo].[calcoloRequisitoPagamento121_9]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- BANDO 121 PSR 
-- Controllo valido per MANTENIMENTO PUNTEGGIO MINIMO  0.2 

DECLARE @IdSchedaValutazione int, @IdProgetto int
DECLARE   @RESULT INT
 


 SET @IdProgetto= ( SELECT ID_PROGETTO FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO= @ID_DOMANDA_PAGAMENTO )
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

 
 
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


-- F 121 - investimenti realizzati per i settori prioritari ed in territori preferenzial 

 DECLARE @PunteggioPriorita121F DECIMAL (18,6), @PesoPriorita121F decimal (18,6), @ValoreMAXPriorita121F decimal (18,6), @ValorePriorita121F decimal (18,6)

SET @PesoPriorita121F= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 38 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPriorita121F = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 38 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePriorita121F =    calcoloPrioritaRequisitoPagamento121_4   @ID_DOMANDA_PAGAMENTO, @IdProgetto
SET @PunteggioPriorita121F = ( ((@ValorePriorita121F/100)*@PesoPriorita121F) /@ValoreMAXPriorita121F  ) 

DECLARE @PUNTEGGIO_PAGAMENTO DECIMAL(18,4)
 SET @PUNTEGGIO_PAGAMENTO = ( SELECT (   (ISNULL(@PunteggioPriorita121D,0)*100) + (ISNULL(@PunteggioPriorita121E,0)*100) + (ISNULL(@PunteggioPriorita121F,0)*100)) )
 

IF(@PUNTEGGIO_PAGAMENTO >0.2) SET @RESULT = 1
ELSE  SET @RESULT = 0
	
SELECT @RESULT
END
