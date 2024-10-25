CREATE PROCEDURE [dbo].[calcoloStepVariante_B312]
@ID_VARIANTE int
AS
BEGIN
 
---================ MANTENIMENTO PUNTEGGIO MINIMO ================---
--ID_PRIORITA	PRIORITA
--A 932	Investimenti integrativi rispetto ad interventi FESR
--B 933	Investimenti riguardanti beni culturali o beni paesaggistici di cui al D.Lgs. n. 42/2004
--C 934	Investimenti realizzati in aree Natura 2000 (interamente)
--D 935	Investimenti nelle aree D e C3 (interamente)
--E 936	Progetto esecutivo
--F 937	Interventi inseriti in itinerari tematici e territoriali finalizzati alla valorizzazione del territorio rurale

--declare @ID_VARIANTE int
--SET @ID_VARIANTE = 


DECLARE @IdSchedaValutazione int, @IdProgetto int, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4)

SET @IdProgetto= (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)

---- IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE ----
---- IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE ----
---- IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE IMPORTANTE ----
---- @MINIMO_GRADUATORI PRENDO IL PRIMO FINANZIABILE PARZIALMENTE PERCHE' NON CI SONO DOMANDE NON FINANZIATE -----

SET @MINIMO_GRADUATORIA = (SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='P' ORDER BY PUNTEGGIO DESC)
--SELECT @MINIMO_GRADUATORIA AS M
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

----------------------------------------------------------------------------------------------------------------------------------------------
-- priorita A  	
-- 932	Investimenti integrativi rispetto ad interventi FESR
DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 932 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 932 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaA =  (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 932)
SET @PunteggioPrioritaA = (@ValorePrioritaA * @PesoPrioritaA)
----------------------------------------------------------------------------------------------------------------------------------------------

-- PRIORITA B 
-- 933	Investimenti riguardanti beni culturali o beni paesaggistici di cui al D.Lgs. n. 42/2004
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 933 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 933 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1
												WHEN VP.CODICE = '2' THEN 0.5
												ELSE 0 END
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 933)

SET @PunteggioPrioritaB = (@ValorePrioritaB * @PesoPrioritaB) 

----------------------------------------------------------------------------------------------------------------------------------------------

-- priorita C  	
-- 934	Investimenti realizzati in aree Natura 2000 (interamente)
DECLARE @PunteggioPrioritaC decimal(10,2)
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)

SET @PesoPrioritaC= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 934 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 934 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC =  (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 934)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)

----------------------------------------------------------------------------------------------------------------------------------------------

-- priorita D  	
--935	Investimenti nelle aree D e C3 (interamente)
DECLARE @PunteggioPrioritaD decimal(10,2)
DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)

SET @PesoPrioritaD= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 935 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 935 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaD =  (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 935)
SET @PunteggioPrioritaD = (@ValorePrioritaD * @PesoPrioritaD)

----------------------------------------------------------------------------------------------------------------------------------------------

-- priorita E  	
-- 936	Progetto esecutivo
DECLARE @PunteggioPrioritaE decimal(10,2)
DECLARE @PesoPrioritaE decimal(10,2)
DECLARE @ValoreMAXPrioritaE decimal(10,2)
DECLARE @ValorePrioritaE decimal(10,2)

SET @PesoPrioritaE= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 936 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaE = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 936 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaE =  (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 936)
SET @PunteggioPrioritaE = (@ValorePrioritaE * @PesoPrioritaE)

----------------------------------------------------------------------------------------------------------------------------------------------
-- priorita F  	
-- 937	Interventi inseriti in itinerari tematici e territoriali finalizzati alla valorizzazione del territorio rurale
DECLARE @PunteggioPrioritaF decimal(10,2)
DECLARE @PesoPrioritaF decimal(10,2)
DECLARE @ValoreMAXPrioritaF decimal(10,2)
DECLARE @ValorePrioritaF decimal(10,2)

SET @PesoPrioritaF= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 937 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaF = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 937 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaF =  (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 937)
SET @PunteggioPrioritaF = (@ValorePrioritaF * @PesoPrioritaF)

----------------------------------------------------------------------------------------------------------------------------------------------
---- == VERIFICO MANTENIMENTO PUNTEGGIO MINIMO IN GRADUATORIA == ----

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0) +
								   ISNULL(@PunteggioPrioritaD,0) +ISNULL(@PunteggioPrioritaE,0) +ISNULL(@PunteggioPrioritaF,0)))
							 
--select @PUNTEGGIO_VARIANTE , @MINIMO_GRADUATORIA
IF(@PUNTEGGIO_VARIANTE >= isnull(@MINIMO_GRADUATORIA,0))SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
