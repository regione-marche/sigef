CREATE PROCEDURE [dbo].[calcoloStepVariante4134_B224]
@ID_VARIANTE int
AS
BEGIN
-- GAL Sibilla - Bando 4.1.3.4 Sviluppo e rinnovamento villaggi - Centri Storici
-- Controllo validO per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA: 
---- i punteggi in graduatoria sono relativi a 100 --> non divido per 100 


--declare @ID_VARIANTE int
--SET @ID_VARIANTE = XXXX

DECLARE @IdSchedaValutazione int, @IdProgetto int, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4)

SET @IdProgetto= (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)

SET @MINIMO_GRADUATORIA = (SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)
--SELECT @MINIMO_GRADUATORIA AS M
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

--select @MINIMO_GRADUATORIA, @ID_BANDO
--	ID_P	PESO	COD_LIVELLO	PLURI_VALORE	PRIORITA
--A	675		5.00	D			0				Progetto esecutivo approvato dell`intervento proposto.

DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 675 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 675 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaA =  (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 675)
SET @PunteggioPrioritaA = (@ValorePrioritaA  * @PesoPrioritaA)
--select @PunteggioPrioritaA, '675'
   
   
--	ID_P	PESO	COD_LIVELLO	PLURI_VALORE	PRIORITA
--B	678		10.00	D			0				Investimenti realizzati in Comuni con densita` abitativa inferiore a 50 abitanti per Kmq.
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 678 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 678 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 678)
SET @PunteggioPrioritaB = (@ValorePrioritaB * @PesoPrioritaB) 
--select @PunteggioPrioritaB, '678'


--	ID_P	PESO	COD_LIVELLO	PLURI_VALORE	PRIORITA
--C	679		20.00	D			0				Investimenti realizzati in Comuni con meno di 2.000 abitanti.
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 679 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 679 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 679)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)  
--select @PunteggioPrioritaC, '679'


--	ID_P	PESO	COD_LIVELLO	PLURI_VALORE	PRIORITA
--D	681		20.00	D			0				Investimenti integrativi rispetto ad interventi FESR realizzati nei medesimi siti oggetto dell`intervento ma nettamente distinti tra loro.
DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
DECLARE @PunteggioPrioritaD decimal(10,2)

SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 681 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 681 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaD = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 681)
SET @PunteggioPrioritaD =  (@ValorePrioritaD * @PesoPrioritaD)  
--select @PunteggioPrioritaD, '681'

--	ID_P	PESO	COD_LIVELLO	PLURI_VALORE	PRIORITA
--E	682		15.00	D			0				Progetti promossi da Comuni i cui territori ricadono, anche parzialmente, all`interno di aree naturali  protette (parchi nazionali e regionali e riserve naturali) (riserva di approvazione)
DECLARE @PunteggioPrioritaE decimal(10,2)
DECLARE @PesoPrioritaE decimal(10,2)
DECLARE @ValoreMAXPrioritaE decimal(10,2)
DECLARE @ValorePrioritaE decimal(10,2)

SET @PesoPrioritaE = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 682	 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaE = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 682 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaE = (SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 682)
SET @PunteggioPrioritaE =  (@ValorePrioritaE * @PesoPrioritaE)
--select @PunteggioPrioritaE, '682'

--	ID_P	PESO	COD_LIVELLO	PLURI_VALORE	PRIORITA
--F	683		10.00	D			0				Totalità degli investimenti realizzati in aree Natura 2000.
DECLARE @PunteggioPrioritaF decimal(10,2)
DECLARE @PesoPrioritaF decimal(10,2)
DECLARE @ValoreMAXPrioritaF decimal(10,2)
DECLARE @ValorePrioritaF decimal(10,2)
 
SET @PesoPrioritaF = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 683 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaF = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 683 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaF = (SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 683)
SET @PunteggioPrioritaF =  (@ValorePrioritaF * @PesoPrioritaF)
--select @PunteggioPrioritaF, '683'


--	ID_P	PESO	COD_LIVELLO	PLURI_VALORE	PRIORITA
--G	690		20.00	D			1				Progetto inserito in un piano/programma di sviluppo (socio economico, turistico, altro)  partecipato e sostenuto finanziariamente
DECLARE @PunteggioPrioritaG decimal(10,2)
DECLARE @PesoPrioritaG decimal(10,2)
DECLARE @ValoreMAXPrioritaG decimal(10,2)
DECLARE @ValorePrioritaG decimal(10,2)
 
SET @PesoPrioritaG = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 690 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaG = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 690 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaG = ( SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5  ELSE 0  END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 690)
SET @PunteggioPrioritaG =  (@ValorePrioritaG * @PesoPrioritaG)  
--select @PunteggioPrioritag, '690'

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0) +
								   ISNULL(@PunteggioPrioritaD,0) +ISNULL(@PunteggioPrioritaE,0) + ISNULL(@PunteggioPrioritaF,0) +
								   ISNULL(@PunteggioPrioritaG,0)))
							 
--select @PUNTEGGIO_VARIANTE , @MINIMO_GRADUATORIA
IF(@PUNTEGGIO_VARIANTE > isnull(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
