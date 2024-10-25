﻿CREATE  PROCEDURE [dbo].[calcoloStepVariante112_8]
@ID_VARIANTE int
AS
BEGIN


-- BANDO 112 TERZA SCADENZA
---- Controllo valido per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA:
--declare  @ID_VARIANTE int 
--set @ID_VARIANTE  =  2785

DECLARE @IdSchedaValutazione int, @IdProgetto int, @PunteggioPriorita112A decimal(10,4) , 
					@ID_BANDO int ,  @ID_PROGETTO_ULTIMO_GRADUATORIA INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4), @PesoPriorita112A DECIMAL(18,4), @ValoreMAXPriorita112A DECIMAL(18,4), @ValorePriorita112A DECIMAL(18,4),
		@PesoPriorita112C DECIMAL(18,4), @ValoreMAXPriorita112C DECIMAL(18,4), @ValorePriorita112C DECIMAL(18,4),
		@PesoPriorita112D DECIMAL(18,4), @ValoreMAXPriorita112D DECIMAL(18,4), @ValorePriorita112D DECIMAL(18,4) 

 
SET @IdProgetto= ( SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
 SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)

SET @MINIMO_GRADUATORIA = ( SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='n'
							ORDER BY PUNTEGGIO desc)
SET @ID_PROGETTO_ULTIMO_GRADUATORIA = (SELECT TOP(1) ID_PROGETTO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='S'
																							ORDER BY PUNTEGGIO ASC)

SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B WHERE  ID_BANDO =@ID_BANDO)

 -- A  112 -  Qualità e livello degli obiettivi previsti dal business plan aziendale
-- PER QUESTA SCADENZA è CAMBIATA
SET @PesoPriorita112A= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 175  AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPriorita112A = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 175  AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePriorita112A =  calcoloPrioritaVariante112_4   @ID_VARIANTE, @IdProgetto
SET @PunteggioPriorita112A = ( ((@ValorePriorita112A/100)*@PesoPriorita112A)   ) 
 

-- B.	 112 - insediamento effettuato da giovane imprenditrice
DECLARE @PunteggioPriorita112B DECIMAL (18,6)
 DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 95 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 95 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaB = ( SELECT COUNT(ID_PRIORITA) AS PUNTEGGIO   FROM PRIORITA_X_PROGETTO PP   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 95)
set @PunteggioPriorita112B = (@ValorePrioritaB* @PesoPrioritaB)  

 -- C.	 112 - insediamento effettuato nelle aree svantaggiate e montane
 DECLARE @PunteggioPriorita112C DECIMAL (18,6)
set @PunteggioPriorita112C = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA = 96 AND ID_PROGETTO=@IdProgetto )

 --  D  112 - insediamento con acquisizione in proprietà dell`azienda
DECLARE @PunteggioPriorita112D DECIMAL (18,6)
SET @PunteggioPriorita112D = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA =  97 AND ID_PROGETTO=@IdProgetto )
 
 
DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
 SET @PUNTEGGIO_VARIANTE = ( SELECT ( ISNULL(@PunteggioPriorita112A,0)  +ISNULL(@PunteggioPriorita112B,0) +ISNULL(@PunteggioPriorita112C,0) +ISNULL(@PunteggioPriorita112D,0)  ) )

--select @PUNTEGGIO_VARIANTE, @MINIMO_GRADUATORIA


IF(@PUNTEGGIO_VARIANTE > @MINIMO_GRADUATORIA or isnull(@MINIMO_GRADUATORIA,0) =0 )SELECT 1 AS RESULT
ELSE 
	IF( @PUNTEGGIO_VARIANTE = @MINIMO_GRADUATORIA AND @ID_PROGETTO_ULTIMO_GRADUATORIA = @IdProgetto ) SELECT 1
	ELSE SELECT 0 AS RESULT
	
END
