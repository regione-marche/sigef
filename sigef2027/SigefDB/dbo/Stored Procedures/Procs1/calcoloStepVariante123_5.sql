﻿CREATE PROCEDURE [dbo].[calcoloStepVariante123_5]
@ID_VARIANTE int
AS
BEGIN

-- BANDO 123 pabs 
-- Controllo valido per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA:

DECLARE @IdSchedaValutazione int, @IdProgetto int
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4), @PesoPriorita112A DECIMAL(18,4), @ValoreMAXPriorita112A DECIMAL(18,4), @ValorePriorita112A DECIMAL(18,4),
		@PesoPriorita112C DECIMAL(18,4), @ValoreMAXPriorita112C DECIMAL(18,4), @ValorePriorita112C DECIMAL(18,4),
		@PesoPriorita112D DECIMAL(18,4), @ValoreMAXPriorita112D DECIMAL(18,4), @ValorePriorita112D DECIMAL(18,4) 

DECLARE @PunteggioPriorita112A decimal(10,4) 


SET @MINIMO_GRADUATORIA = ( SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = 27 AND FINANZIABILITA ='S'
							ORDER BY PUNTEGGIO ASC)

DECLARE @ID_PROGETTO_ULTIMO_GRADUATORIA INT

SET @ID_PROGETTO_ULTIMO_GRADUATORIA = (SELECT TOP(1) ID_PROGETTO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = 27 AND FINANZIABILITA ='S'
										ORDER BY PUNTEGGIO ASC)


SET @IdProgetto= ( SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )

SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

 -- A  112 -  Qualità e livello degli obiettivi previsti dal business plan aziendale
SET @PesoPriorita112A= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 98 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPriorita112A = (SELECT ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 98 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

EXEC @ValorePriorita112A =  calcoloPrioritaVariante112_3  @ID_VARIANTE
SET @PunteggioPriorita112A = ( ((@ValorePriorita112A/100)*@PesoPriorita112A) /@ValoreMAXPriorita112A  ) 

-- B.	 112 - insediamento effettuato da giovane imprenditrice
DECLARE @PunteggioPriorita112B DECIMAL (18,6)
set @PunteggioPriorita112B = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA = 95 AND ID_PROGETTO=@IdProgetto )


-- C.	 112 - insediamento effettuato nelle aree svantaggiate e montane
 DECLARE @PunteggioPriorita112C DECIMAL (18,6)
set @PunteggioPriorita112C = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA = 96 AND ID_PROGETTO=@IdProgetto )

--  D  112 - insediamento con acquisizione in proprietà dell`azienda
DECLARE @PunteggioPriorita112D DECIMAL (18,6)
SET @PunteggioPriorita112D = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA =  97 AND ID_PROGETTO=@IdProgetto )
 

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
 SET @PUNTEGGIO_VARIANTE = ( SELECT ( ISNULL(@PunteggioPriorita112A,0) +ISNULL(@PunteggioPriorita112B,0) +ISNULL(@PunteggioPriorita112C,0) +ISNULL(@PunteggioPriorita112D,0)  
								  ) )

IF(@PUNTEGGIO_VARIANTE >@MINIMO_GRADUATORIA )SELECT 1 AS RESULT
ELSE 
	IF( @PUNTEGGIO_VARIANTE = @MINIMO_GRADUATORIA AND @ID_PROGETTO_ULTIMO_GRADUATORIA = @IdProgetto ) SELECT 1
	ELSE SELECT 0 AS RESULT
	
END