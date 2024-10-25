CREATE  PROCEDURE [dbo].[calcoloRequisitoPagamento311_3]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- Controllo validO per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA:
-- i punteggi in graduatoria sono relativi a 100 --> non divido per 100 

DECLARE @IdSchedaValutazione int, @IdProgetto int, @ID_BANDO int
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4)
 

SET @IdProgetto= ( SELECT ID_PROGETTO FROM DOMANDA_DI_PAGAMENTO  WHERE  ID_DOMANDA_PAGAMENTO= @ID_DOMANDA_PAGAMENTO )
set @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE id_progetto = @IdProgetto)

SET @MINIMO_GRADUATORIA = (   SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)
 
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B  WHERE ID_BANDO = @ID_BANDO )
 
-- priorita A  	Investimenti nelle aree C1, C2, C3 e A (zonizzazione definita nel vigente PSR Marche)
-- resta invariato prendo valore dalla graduatoria - ID_PRIORITA = 87 OPPURE ID= 56 PER IL PSR
DECLARE @PunteggioPrioritaA decimal(10,2)
set @PunteggioPrioritaA = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA IN(56, 87) AND ID_PROGETTO=@IdProgetto )

-- Priorità B (311 - investimenti destinati a migliorare i servizi agrituristici delle aziende) ID: 29

DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 29 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 29 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
EXEC @ValorePrioritaB =  calcoloPrioritaRequisitoPagamento311_1  @IdProgetto, @ID_DOMANDA_PAGAMENTO
SET @PunteggioPrioritaB = ((@ValorePrioritaB ) * @PesoPrioritaB) / @ValoreMAXPrioritaB

-- C.	Investimenti realizzati in aree Natura 2000 ID_PRIORITA = 25
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 25 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 25 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT VALORE = CASE WHEN 
											( SELECT  COUNT(ID_INVESTIMENTO )
												FROM    PAGAMENTI_BENEFICIARIO PB INNER JOIN
												PAGAMENTI_RICHIESTI PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO
												WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND SPESA_TECNICA_RICHIESTA =0 AND ID_INVESTIMENTO IN
												(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA =25  )   ) > 0 THEN 1 ELSE 0 END )

SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)  

--D	Investimenti realizzati da aziende con offerta integrata di ricettività e ristorazione  ID_PRIORITA =  61
DECLARE @PunteggioPrioritaD decimal(10,2)
set @PunteggioPrioritaD = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA =  61 AND ID_PROGETTO=@IdProgetto )

-- E.	Investimenti realizzati da imprenditrici
DECLARE @PunteggioPrioritaE decimal(10,2)
SET @PunteggioPrioritaE = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA = 26 AND ID_PROGETTO=@IdProgetto )


-- F.	Investimenti realizzati da aziende biologiche  ID_PRIORITA = 32

DECLARE @PunteggioPrioritaF decimal(10,2)
SET @PunteggioPrioritaF = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA = 32 AND ID_PROGETTO=@IdProgetto )

--G.	Investimenti realizzati da giovani agricoltori IAP
DECLARE @PunteggioPrioritaG decimal(10,2)
SET @PunteggioPrioritaG  = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA = 54 AND ID_PROGETTO=@IdProgetto )



 -- H.	Investimenti strutturali realizzati con tecniche di bioedilizia
DECLARE @PunteggioPrioritaH decimal(10,2)
SET @PunteggioPrioritaH  = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA = 27 AND ID_PROGETTO=@IdProgetto )


-- Priorità I (311 - Investimenti strutturali realizzati con tecniche di bioedilizia) ID: 27 


DECLARE @PesoPrioritaI decimal(10,2)
DECLARE @ValoreMAXPrioritaI decimal(10,2)
DECLARE @ValorePrioritaI decimal(10,2)
DECLARE @PunteggioPrioritaI decimal(10,2)

SET @PesoPrioritaI = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 27 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaI = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 27 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaI = (SELECT VALORE = CASE WHEN COUNT(VP.PUNTEGGIO) > 0 THEN MAX(VP.PUNTEGGIO) ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PRIORITA = 27 AND PP.ID_PROGETTO = @IdProgetto)
SET @PunteggioPrioritaI = (@ValorePrioritaI * @PesoPrioritaI)  

 


-- Priorità J (311 - investimenti con riqualificazione architettonica riguardanti tutto il patrimonio aziendale) ID: 31

DECLARE @PesoPrioritaJ decimal(10,2)
DECLARE @ValoreMAXPrioritaJ decimal(10,2)
DECLARE @ValorePrioritaJ decimal(10,2)
DECLARE @PunteggioPrioritaJ decimal(10,2)

SET @PesoPrioritaJ = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 31 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaJ = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 31 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaJ = (SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 31 AND ID_PROGETTO = @IdProgetto)
SET @PunteggioPrioritaJ = (@ValorePrioritaJ * @PesoPrioritaJ) --/ @ValoreMAXPrioritaJ

-- Priorità K (311 - investimenti destinati all`utilizzo di fonti energetiche rinnovabili) ID: 62

DECLARE @PesoPrioritaK decimal(10,2)
DECLARE @ValoreMAXPrioritaK decimal(10,2)
DECLARE @ValorePrioritaK decimal(10,2)
DECLARE @PunteggioPrioritaK decimal(10,2)

SET @PesoPrioritaK = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 62 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaK = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 62 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaK = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 0.8 
                                                WHEN VP.CODICE = '2' THEN 1 
                                                WHEN VP.CODICE = '3' THEN 0.4 
                                                WHEN VP.CODICE = '4' THEN 0.6 
                                                ELSE 0 END 
                                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) 
                                           WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 62)

SET @PunteggioPrioritaK = (@ValorePrioritaK * @PesoPrioritaK)  


--  priorità 63 (311 - investimenti destinati a creare occupazione) 
 -- H.	Investimenti strutturali realizzati con tecniche di bioedilizia
DECLARE @PunteggioPrioritaM decimal(10,6)
SET @PunteggioPrioritaM  = (SELECT PUNTEGGIO FROM  GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA = 63 AND ID_PROGETTO=@IdProgetto )


DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)

SET @PUNTEGGIO_VARIANTE = ( SELECT ( ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0) +
									ISNULL(@PunteggioPrioritaD,0) +ISNULL(@PunteggioPrioritaE,0) + ISNULL(@PunteggioPrioritaF,0) +
									ISNULL(@PunteggioPrioritaG,0) +ISNULL(@PunteggioPrioritaH,0)  + 
									 ISNULL(@PunteggioPrioritaJ,0) + ISNULL(@PunteggioPrioritaK,0) + ISNULL(@PunteggioPrioritaM,0) )  )
 
IF(@PUNTEGGIO_VARIANTE > isnull(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
