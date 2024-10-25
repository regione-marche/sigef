CREATE PROCEDURE [dbo].[calcoloStepVariante_B315_1]
@ID_VARIANTE int
AS
BEGIN
--declare @ID_VARIANTE int
--SET @ID_VARIANTE = XXX
-- mantenimento punteggio minimo in graduatoria

DECLARE @IdSchedaValutazione int, @IdProgetto int, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4)

SET @IdProgetto= (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)

SET @MINIMO_GRADUATORIA = (SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)
--SELECT @MINIMO_GRADUATORIA AS M
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

--992	Priorità A. Tipologia di servizi attivati	50.00	SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1   WHEN VP.CODICE = '2' THEN 0.60   WHEN VP.CODICE = '3' THEN 0.30   ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 992
--993	Priorità B. Avvio di servizi destinati a creare occupazione	15.00	SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1'  THEN 1   WHEN VP.CODICE = '2' THEN 0.50   ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 993
--994	Priorità C. Valorizzazione sul piano gestionale di progetti di rete	15.00	SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto and ID_PRIORITA = 994
--995	Priorità D. Numero di soggetti partecipanti alla partnership	10.00	SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto and ID_PRIORITA = 995
--996	Priorità E. Integrazione del servizio su strutture esistenti	5.00	SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto and ID_PRIORITA = 996
--997	Priorità F. Tipologia di servizio attivato (progetti afferenti l`ambito culturale)	5.00	SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto and ID_PRIORITA = 997

--select @MINIMO_GRADUATORIA, @ID_BANDO

--------------------------------------------------------------------------------------------------------------------------   
-------------------------------------------------------------------------------------------------------------------------- 

-- 992	Priorità A. Tipologia di servizi attivati	50.00	
-- SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1   WHEN VP.CODICE = '2' THEN 0.60   WHEN VP.CODICE = '3' THEN 0.30   ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 992
DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 992 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 992 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaA =  (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.6 WHEN VP.CODICE = '3' THEN 0.3 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 992)
SET @PunteggioPrioritaA = (@ValorePrioritaA * @PesoPrioritaA)
--select @PunteggioPrioritaA, '992'
--------------------------------------------------------------------------------------------------------------------------   
--------------------------------------------------------------------------------------------------------------------------   

--993	Priorità B. Avvio di servizi destinati a creare occupazione	15.00	
-- SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1'  THEN 1   WHEN VP.CODICE = '2' THEN 0.50   ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 993
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 993 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 993 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 993)
SET @PunteggioPrioritaB = (@ValorePrioritaB * @PesoPrioritaB) 
--select @PunteggioPrioritaB, '993'
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--994	Priorità C. Valorizzazione sul piano gestionale di progetti di rete	15.00	
-- SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto and ID_PRIORITA = 994
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 994 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 994 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 994)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)  
--select @PunteggioPrioritaC, '994'
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--995	Priorità D. Numero di soggetti partecipanti alla partnership	10.00	
-- SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto and ID_PRIORITA = 995
 DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
DECLARE @PunteggioPrioritaD decimal(10,2)

SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 995 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 995 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaD = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 995)
SET @PunteggioPrioritaD =  (@ValorePrioritaD * @PesoPrioritaD)  
--select @PunteggioPrioritaD, '995'
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--996	Priorità E. Integrazione del servizio su strutture esistenti	5.00	
-- SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto and ID_PRIORITA = 996
DECLARE @PesoPrioritaE decimal(10,2)
DECLARE @ValoreMAXPrioritaE decimal(10,2)
DECLARE @ValorePrioritaE decimal(10,2)
DECLARE @PunteggioPrioritaE decimal(10,2)

SET @PesoPrioritaE = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 996 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaE = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 996 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaE = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 996)
SET @PunteggioPrioritaE =  (@ValorePrioritaE * @PesoPrioritaE)  
--select @PunteggioPrioritaD, '996'
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--997	Priorità F. Tipologia di servizio attivato (progetti afferenti l`ambito culturale)	5.00
-- SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto and ID_PRIORITA = 997
DECLARE @PesoPrioritaF decimal(10,2)
DECLARE @ValoreMAXPrioritaF decimal(10,2)
DECLARE @ValorePrioritaF decimal(10,2)
DECLARE @PunteggioPrioritaF decimal(10,2)

SET @PesoPrioritaF = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 997 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaF = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 997 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaF = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 997)
SET @PunteggioPrioritaF =  (@ValorePrioritaF * @PesoPrioritaF)  
--select @PunteggioPrioritaD, '997'
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------
DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) 
								  +ISNULL(@PunteggioPrioritaC,0) +ISNULL(@PunteggioPrioritaD,0)
								  +ISNULL(@PunteggioPrioritaE,0) +ISNULL(@PunteggioPrioritaF,0)
								  ))
							 
--select @PUNTEGGIO_VARIANTE , @MINIMO_GRADUATORIA
IF(@PUNTEGGIO_VARIANTE > isnull(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
