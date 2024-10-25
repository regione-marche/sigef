CREATE PROCEDURE [dbo].[calcoloStepVariante_B334]
@ID_VARIANTE int
AS
BEGIN

--1073	A) Investimenti nelle aree D e C3	SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1073
--1074	B) Avvio di servizi destinati a creare occupazione	SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1074
--1075	C) Almeno 2 Comuni interessati al servizio	SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1075


DECLARE @IdSchedaValutazione int, @IdProgetto INT, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4), @CountNonFinanziabili INT, @CountFinanziabilaParziale INT

SET @IdProgetto = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)

--------------------   Qui imposto valore minimo punteggio    --------------------

SET @CountNonFinanziabili = (SELECT COUNT(*) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N')
SET @CountFinanziabilaParziale = (SELECT COUNT(*) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='P')

IF (@CountNonFinanziabili > 0) 
	SET @MINIMO_GRADUATORIA = (SELECT TOP(1) ISNULL(PUNTEGGIO,0) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)	
ELSE	
	SET @MINIMO_GRADUATORIA = 0
	
IF (@CountFinanziabilaParziale > 0) 
		SET @MINIMO_GRADUATORIA = (SELECT TOP(1) ISNULL(PUNTEGGIO,0) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='P' ORDER BY PUNTEGGIO DESC)

----------------------------------------------------------------------------------------

SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)
 
 ----------------------------------------------------------------------------------------

 --1073	A) Investimenti nelle aree D e C3	
DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1073 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1073 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaA =  ( SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1073)
SET @PunteggioPrioritaA = (@ValorePrioritaA * @PesoPrioritaA)

-----------------------------------------------------------------------------------------

 --1074	B) Avvio di servizi destinati a creare occupazione	
DECLARE @PunteggioPrioritaB decimal(10,2)
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
 
SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1074 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1074 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaB = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5 ELSE 0 END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1074)
SET @PunteggioPrioritaB =  (@ValorePrioritaB * @PesoPrioritaB)  

----------------------------------------------------------------------------------------
--1075	C) Almeno 2 Comuni interessati al servizio
DECLARE @PunteggioPrioritaC decimal(10,2)
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)

SET @PesoPrioritaC= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1075 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1075 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC =  ( SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1075)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)

----------------------------------------------------------------------------------------

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)

SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0)))
select @PUNTEGGIO_VARIANTE as  PUNTEGGIO_VARIANTE

IF(@PUNTEGGIO_VARIANTE > ISNULL(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
