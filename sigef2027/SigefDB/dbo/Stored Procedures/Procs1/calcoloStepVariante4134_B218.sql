CREATE PROCEDURE [dbo].[calcoloStepVariante4134_B218]
@ID_VARIANTE int
AS
BEGIN
-- Bando Misura 4134 BANDO ID : 218 - FLAMINIA CESANO
-- Controllo validO per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA: 
---- i punteggi in graduatoria sono relativi a 100 --> non divido per 100 

--declare @ID_VARIANTE int
--SET @ID_VARIANTE = XXX


DECLARE @IdSchedaValutazione int, @IdProgetto int, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4)

SET @IdProgetto= (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)

SET @MINIMO_GRADUATORIA = (SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)
--SELECT @MINIMO_GRADUATORIA AS M
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)



--651	Investimenti integrativi rispetto ad interventi FESR	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 651

--652	investimenti realizzati in Comuni con meno di 2.000 abitanti	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 652

--653	investimenti realizzati in Comuni con densità abitativa inferiore a 50 abitanti per Km2	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 653

--654	indice di utilizzo del patrimonio abitativo	
-- SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.7  WHEN VP.CODICE = '3' THEN 0.4  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 654

--655	iniziative economiche sostenibili ed accessibili	
-- SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.7  WHEN VP.CODICE = '3' THEN 0.4  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 655

--656	investimenti strutturali realizzati con tecniche di bioedilizia.	
-- SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.7  WHEN VP.CODICE = '3' THEN 0.4  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 656

--657	investimenti su strutture destinate all`attivazione di servizi a beneficio della popolazione	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 657

--658	Investimenti relativi ad immobili localizzati interamente in AREA Natura 2000	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 658



--select @MINIMO_GRADUATORIA, @ID_BANDO
--ID_PRIORITA= 651	priorità A - Investimenti integrativi rispetto ad interventi FESR

DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 651 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 651 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaA =  (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 651)
SET @PunteggioPrioritaA = (@ValorePrioritaA * @PesoPrioritaA)
--select @PunteggioPrioritaA, '651'
   
   
-- ID_PRIORITA=652	priorità B - investimenti realizzati in Comuni con meno di 2.000 abitanti	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 652
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 652 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 652 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 652)
SET @PunteggioPrioritaB = (@ValorePrioritaB * @PesoPrioritaB) 
--select @PunteggioPrioritaB, '652'

-- ID_PRIORITA=653	priorità C - investimenti realizzati in Comuni con densità abitativa inferiore a 50 abitanti per Km2	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 653
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 653 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 653 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 653)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)  
--select @PunteggioPrioritaC, '653'

--ID_PRIORITA= 654	priorità D - indice di utilizzo del patrimonio abitativo	
-- SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.7  WHEN VP.CODICE = '3' THEN 0.4  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 654
 DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
DECLARE @PunteggioPrioritaD decimal(10,2)

SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 654 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 654 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaD = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.7  WHEN VP.CODICE = '3' THEN 0.4  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 654)
SET @PunteggioPrioritaD =  (@ValorePrioritaD * @PesoPrioritaD)  
--select @PunteggioPrioritaD, '654'

--ID_PRIORITA= 655	priorità E - iniziative economiche sostenibili ed accessibili
-- SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.7  WHEN VP.CODICE = '3' THEN 0.4  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 655
DECLARE @PunteggioPrioritaE decimal(10,2)
DECLARE @PesoPrioritaE decimal(10,2)
DECLARE @ValoreMAXPrioritaE decimal(10,2)
DECLARE @ValorePrioritaE decimal(10,2)

SET @PesoPrioritaE = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 655 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaE = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 655 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaE = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.7  WHEN VP.CODICE = '3' THEN 0.4  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 655)
SET @PunteggioPrioritaE =  (@ValorePrioritaE * @PesoPrioritaE)
--select @PunteggioPrioritaE, '655'

--ID_PRIORITA=656	priorità F - investimenti strutturali realizzati con tecniche di bioedilizia.	
-- SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.7  WHEN VP.CODICE = '3' THEN 0.4  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 656
DECLARE @PunteggioPrioritaF decimal(10,2)
DECLARE @PesoPrioritaF decimal(10,2)
DECLARE @ValoreMAXPrioritaF decimal(10,2)
DECLARE @ValorePrioritaF decimal(10,2)
 
SET @PesoPrioritaF = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 656 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaF = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 656 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaF =  (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.7  WHEN VP.CODICE = '3' THEN 0.4  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 656)
SET @PunteggioPrioritaF =  (@ValorePrioritaF* @PesoPrioritaF)
--select @PunteggioPrioritaF, '656'

--ID_PRIORITA=657	priorità G - investimenti su strutture destinate all`attivazione di servizi a beneficio della popolazione	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 657
DECLARE @PunteggioPrioritaG decimal(10,2)
DECLARE @PesoPrioritaG decimal(10,2)
DECLARE @ValoreMAXPrioritaG decimal(10,2)
DECLARE @ValorePrioritaG decimal(10,2)
 
SET @PesoPrioritaG = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 657 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaG = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 657 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaG = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 657)
SET @PunteggioPrioritaG =  (@ValorePrioritaG* @PesoPrioritaG)  
--select @PunteggioPrioritag, '657'

--ID_PRIORITA=658	priorità G - Investimenti relativi ad immobili localizzati interamente in AREA Natura 2000	
-- SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 658
DECLARE @PunteggioPrioritaH decimal(10,2)
DECLARE @PesoPrioritaH decimal(10,2)
DECLARE @ValoreMAXPrioritaH decimal(10,2)
DECLARE @ValorePrioritaH decimal(10,2)
 
SET @PesoPrioritaH = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 658 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaH = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 658 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaH = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 658)
SET @PunteggioPrioritaH =  (@ValorePrioritaH * @PesoPrioritaH)  
--select @PunteggioPrioritag, '658'

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0) +
								   ISNULL(@PunteggioPrioritaD,0) +ISNULL(@PunteggioPrioritaE,0) + ISNULL(@PunteggioPrioritaF,0) +
								   ISNULL(@PunteggioPrioritaG,0) +ISNULL(@PunteggioPrioritaH,0)))
							 
--select @PUNTEGGIO_VARIANTE , @MINIMO_GRADUATORIA
IF(@PUNTEGGIO_VARIANTE > isnull(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
