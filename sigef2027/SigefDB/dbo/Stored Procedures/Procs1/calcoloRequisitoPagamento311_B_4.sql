CREATE  PROCEDURE [dbo].[calcoloRequisitoPagamento311_B_4]
@ID_DOMANDA_PAGAMENTO  int
AS
BEGIN

-- BANDO 311 B
-- Controllo validO per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA:
--declare @ID_DOMANDA_PAGAMENTO  int
--set @ID_DOMANDA_PAGAMENTO  =1463

DECLARE @IdSchedaValutazione int, @IdProgetto int
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4), @PesoPrioritaA DECIMAL(18,4), @ValoreMAXPrioritaA DECIMAL(18,4), @ValorePrioritaA DECIMAL(18,4),
		@PesoPrioritaC DECIMAL(18,4), @ValoreMAXPrioritaC DECIMAL(18,4), @ValorePrioritaC DECIMAL(18,4),
		@PesoPrioritaD DECIMAL(18,4), @ValoreMAXPrioritaD DECIMAL(18,4), @ValorePrioritaD DECIMAL(18,4)


DECLARE @PunteggioPrioritaA decimal(10,4),@PunteggioPrioritaD decimal(10,4),      @PunteggioPrioritaC decimal(10,4)


SET @MINIMO_GRADUATORIA = ( SELECT TOP(1) ISNULL( PUNTEGGIO,0) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = 89 AND FINANZIABILITA ='N'orDER BY PUNTEGGIO ASC)
 SET @IdProgetto= ( SELECT ID_PROGETTO FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO= @ID_DOMANDA_PAGAMENTO )
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

 -- A  	Investimenti nelle aree A, C1, C2, C3 e D (zonizzazione definita nel vigente PSR Marche) e tipologia degli impianti
SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 145 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 145 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePrioritaA =  calcoloPrioritaRequisitoPagamento311_B_1 @ID_DOMANDA_PAGAMENTO
SET @PunteggioPrioritaA = ( ((@ValorePrioritaA/100)*@PesoPrioritaA) /@ValoreMAXPrioritaA  ) 

-- B.	Imprenditori ex-bieticoltori (elenco CUAA – AGEA)
DECLARE @PunteggioPrioritaB DECIMAL (18,6)
set @PunteggioPrioritaB = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA = 146 AND ID_PROGETTO=@IdProgetto )


-- C.	Efficienza energetica
SET @PesoPrioritaC= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 147 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 147 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePrioritaC =  calcoloRequisitoPagamento311_B_2  @ID_DOMANDA_PAGAMENTO
SET @PunteggioPrioritaC = ( ((@ValorePrioritaC/100)*@PesoPrioritaC) /@ValoreMAXPrioritaC  ) 


 -- D Biomassa proveniente dal bacino bieticolo-

SET @PesoPrioritad= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 148 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritad = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 148 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePrioritad =  calcoloRequisitoPagamento311_B_3  @ID_DOMANDA_PAGAMENTO
 SET @PunteggioPrioritad = ( ((@ValorePrioritad/100)*@PesoPrioritad) /@ValoreMAXPrioritad  ) 

--  E.	Investimenti realizzati giovani agricoltori IAP
DECLARE @PunteggioPrioritaE DECIMAL (18,6)
set @PunteggioPrioritaE = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA = 21 AND ID_PROGETTO=@IdProgetto )
 
DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)

 SET @PUNTEGGIO_VARIANTE = ( SELECT ( ISNULL(@PunteggioPrioritaA,0)*100 +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0)*100 +ISNULL(@PunteggioPrioritaD,0)*100 +
								ISNULL(@PunteggioPrioritaE,0) ) )

IF(@PUNTEGGIO_VARIANTE >=isnull(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
