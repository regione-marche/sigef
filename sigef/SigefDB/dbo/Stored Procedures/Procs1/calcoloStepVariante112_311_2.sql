CREATE PROCEDURE [dbo].[calcoloStepVariante112_311_2]
@ID_VARIANTE int
AS

-- Controllo valido per la variante:

-- 1. 112 - 311 - VERIFICA PUNTEGGIO MINIMO = 0,08 (CRITERI B-I-J-K) 
DECLARE @IdProgetto INT, @ID_PROG_CORRENTE_311 INT,@ID_BANDO_311 INT
 
SET @IdProgetto = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE) -- PROGETTO 112

SELECT DISTINCT @ID_PROG_CORRENTE_311 = p.ID_PROGETTO, @ID_BANDO_311=P.ID_BANDO FROM PROGETTO P
		INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '3.1.1.A'
WHERE ID_PROG_INTEGRATO = @IdProgetto

DECLARE @IdSchedaValutazione int
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B WHERE ID_BANDO = @ID_BANDO_311)

-- Priorità B (112 - 311 - investimenti destinati a migliorare i servizi agrituristici delle aziende) ID: 104

DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,4)
DECLARE @PunteggioPrioritaB decimal(10,4)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 104 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA 
WHERE ID_PRIORITA = 104 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePrioritaB = calcoloPrioritaVariante112_311_1  @ID_VARIANTE, @ID_PROG_CORRENTE_311

SET @PunteggioPrioritaB = ((@ValorePrioritaB/100) * @PesoPrioritaB) / @ValoreMAXPrioritaB

 

-- Priorità I (112 - 311 - Investimenti strutturali realizzati con tecniche di bioedilizia) ID: 105
-- Priorità I (Investimenti strutturali realizzati con tecniche di bioedilizia) ID: 154 II SCADENZA

DECLARE @PesoPrioritaI decimal(10,2)
DECLARE @ValoreMAXPrioritaI decimal(10,2)
DECLARE @ValorePrioritaI decimal(10,4)
DECLARE @PunteggioPrioritaI decimal(10,4)


IF @IdSchedaValutazione IN (83, 114, 280)
BEGIN
	SET @PesoPrioritaI = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 154 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
	SET @ValoreMAXPrioritaI = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA 
							   WHERE ID_PRIORITA = 154 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
	EXEC @ValorePrioritaI =   calcoloPrioritaVariante112_311_3  @ID_VARIANTE, @ID_PROG_CORRENTE_311
	SET @PunteggioPrioritaI = ((@ValorePrioritaI/100) * @PesoPrioritaI) / @ValoreMAXPrioritaI
	
END
ELSE 
BEGIN
	SET @PesoPrioritaI = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 105 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
	SET @ValoreMAXPrioritaI = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA 
							   WHERE ID_PRIORITA = 105 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
	SET @ValorePrioritaI = (SELECT VALORE = CASE WHEN COUNT(VP.PUNTEGGIO) > 0 THEN MAX(VP.PUNTEGGIO) ELSE 0 END 
						FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
						WHERE PP.ID_PRIORITA = 105 AND PP.ID_PROGETTO = @ID_PROG_CORRENTE_311)
	SET @PunteggioPrioritaI = (@ValorePrioritaI * @PesoPrioritaI) / @ValoreMAXPrioritaI
END

 
---------------------------------------
--NON CAMBIANO PER IL CALCOLO DELLA VARIANTE PERCHè SONO TUTTI REQUISITI SOGGETTIVI
----------------------------------------

SELECT @PunteggioPrioritaI AS PUNTEGGIO_I 
-- Priorità J (112 - 311 - investimenti con riqualificazione architettonica riguardanti tutto il patrimonio aziendale) ID: 106

DECLARE @PesoPrioritaJ decimal(10,2)
DECLARE @ValoreMAXPrioritaJ decimal(10,2)
DECLARE @ValorePrioritaJ decimal(10,4)
DECLARE @PunteggioPrioritaJ decimal(10,4)

SET @PesoPrioritaJ = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 106 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaJ = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 106 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaJ = (SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 106 AND ID_PROGETTO = @ID_PROG_CORRENTE_311)
SET @PunteggioPrioritaJ = (@ValorePrioritaJ * @PesoPrioritaJ) / @ValoreMAXPrioritaJ

-- Priorità K (112 - 311 - investimenti destinati all`utilizzo di fonti energetiche rinnovabili) ID: 107

DECLARE @PesoPrioritaK decimal(10,2)
DECLARE @ValoreMAXPrioritaK decimal(10,2)
DECLARE @ValorePrioritaK decimal(10,4)
DECLARE @PunteggioPrioritaK decimal(10,4)

SET @PesoPrioritaK = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 107 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaK = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 107 
AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaK = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 0.8 
                                                WHEN VP.CODICE = '2' THEN 1 
                                                WHEN VP.CODICE = '3' THEN 0.4 
                                                WHEN VP.CODICE = '4' THEN 0.6 
                                                ELSE 0 END 
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @ID_PROG_CORRENTE_311 AND PP.ID_PRIORITA = 107)

SET @PunteggioPrioritaK = (@ValorePrioritaK * @PesoPrioritaK) / @ValoreMAXPrioritaK
SELECT ( ISNULL(@PunteggioPrioritaB,0) + ISNULL(@PunteggioPrioritaI,0) + ISNULL(@PunteggioPrioritaJ,0) + ISNULL(@PunteggioPrioritaK,0)) AS PUNTEGGIO
--SELECT @PunteggioPrioritaB , @PunteggioPrioritaI , @PunteggioPrioritaJ , @PunteggioPrioritaK
