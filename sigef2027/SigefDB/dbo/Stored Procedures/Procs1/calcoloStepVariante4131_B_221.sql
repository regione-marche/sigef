CREATE PROCEDURE [dbo].[calcoloStepVariante4131_B_221]
@ID_VARIANTE int
AS
BEGIN
-- Bando Misura 4.1.3.1.b - microimprese turistiche - Gal Sibilla
-- Controllo validO per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA: 
---- i punteggi in graduatoria sono relativi a 100 --> non divido per 100 

--declare @ID_VARIANTE int
--SET @ID_VARIANTE = 


--ID_PRIORITA	PRIORITA	COD_LIVELLO	EVAL
--665	Investimenti interamente realizzati nelle aree D e C3	I	
--SELECT VALORE = CASE WHEN (SELECT COUNT(*) FROM vLOCALIZZAZIONE_INVESTIMENTO AS li INNER JOIN VCOMUNI ON li.ID_COMUNE = VCOMUNI.ID_COMUNE INNER JOIN PIANO_INVESTIMENTI  I ON li.ID_INVESTIMENTO = I.ID_INVESTIMENTO WHERE ID_PROGETTO = @IdProgetto AND TIPO_AREA NOT IN ('D','C3') AND ( (I.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL ) OR (@FASE_ISTRUTTORIA =1 AND (I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL AND @IdVariante is null ) OR (ID_VARIANTE  = @IdVariante AND @IdVariante is NOT null AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A')))) >= 1 THEN 0 ELSE 1 END

--666	Investimenti interamente realizzati in aree Natura 2000	D	
--SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 666

--667	Investimenti realizzati da imprenditrici	D	
--SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 667

--668	Investimenti relativi all`utilizzo delle Tecnologie di Informazione e Comunicazione  > =  2% del totale investimenti (escluse le spese tecniche)	D	
--SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 668

--669	Investimenti destinati a creare occupazione nelle nuove imprese	D	
--SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5  ELSE 0  END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 669

--670	Microimpresa di nuova costituzione	D	
--SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 670

--671	Investimenti realizzati da giovani imprenditori	D	
--SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 671

--672	Investimenti realizzati in edifici siti in centri/nuclei storici, o edifici di pregio storico architettonico o edifici di pregio paesistico ambientale	D	
--SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5  ELSE 0  END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 672




DECLARE @IdSchedaValutazione int, @IdProgetto int, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4)

SET @IdProgetto= (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)

SET @MINIMO_GRADUATORIA = (SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)
--SELECT @MINIMO_GRADUATORIA AS M
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

--select @MINIMO_GRADUATORIA, @ID_BANDO
--ID_PRIORITA= 665	priorità A - Investimenti interamente realizzati nelle aree D e C3	-- livello I
----!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 665 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 665 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaA =  (SELECT VALORE = CASE WHEN (SELECT COUNT(*) FROM vLOCALIZZAZIONE_INVESTIMENTO AS li INNER JOIN VCOMUNI ON li.ID_COMUNE = VCOMUNI.ID_COMUNE INNER JOIN PIANO_INVESTIMENTI  I ON li.ID_INVESTIMENTO = I.ID_INVESTIMENTO WHERE ID_PROGETTO = @IdProgetto AND TIPO_AREA NOT IN ('D','C3') AND (ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x') != 'A')) >= 1 THEN 0 ELSE 1 END)
SET @PunteggioPrioritaA = ((@ValorePrioritaA ) * @PesoPrioritaA)
--select @PunteggioPrioritaA, '665'
   
   
-- ID_PRIORITA=666	priorità B - Investimenti interamente realizzati in aree Natura 200- livello D	
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 666 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 666 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB = (SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 666)
SET @PunteggioPrioritaB = ((@ValorePrioritaB ) * @PesoPrioritaB) 
--select @PunteggioPrioritaB, '666'


-- ID_PRIORITA=667	priorità C - Investimenti realizzati da imprenditrici - livello D	
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 667 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 667 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 667)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)  
--select @PunteggioPrioritaC, '667'

--ID_PRIORITA= 668	Investimenti relativi all`utilizzo delle Tecnologie di Informazione e Comunicazione  > =  2% del totale investimenti (escluse le spese tecniche) - livello D	
 DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
DECLARE @PunteggioPrioritaD decimal(10,2)

SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 668 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 668 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaD = (SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 668)
SET @PunteggioPrioritaD =  (@ValorePrioritaD * @PesoPrioritaD)  
--select @PunteggioPrioritaD, '668'

--ID_PRIORITA= 669	priorità E - Investimenti destinati a creare occupazione nelle nuove impres- livello D
DECLARE @PunteggioPrioritaE decimal(10,2)
DECLARE @PesoPrioritaE decimal(10,2)
DECLARE @ValoreMAXPrioritaE decimal(10,2)
DECLARE @ValorePrioritaE decimal(10,2)

SET @PesoPrioritaE = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 669 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaE = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 669 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaE = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5  ELSE 0  END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 669)
SET @PunteggioPrioritaE =  (@ValorePrioritaE * @PesoPrioritaE)
--select @PunteggioPrioritaE, '669'

--ID_PRIORITA=670	priorità F - Microimpresa di nuova costituzione	- livello D
DECLARE @PunteggioPrioritaF decimal(10,2)
DECLARE @PesoPrioritaF decimal(10,2)
DECLARE @ValoreMAXPrioritaF decimal(10,2)
DECLARE @ValorePrioritaF decimal(10,2)
 
SET @PesoPrioritaF = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 670 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaF = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 670 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaF = (SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 670)
SET @PunteggioPrioritaF =  (@ValorePrioritaF * @PesoPrioritaF)
--select @PunteggioPrioritaF, '670'

--ID_PRIORITA=671	priorità G - Investimenti realizzati da giovani imprenditori - LIVELLO	D	
DECLARE @PunteggioPrioritaG decimal(10,2)
DECLARE @PesoPrioritaG decimal(10,2)
DECLARE @ValoreMAXPrioritaG decimal(10,2)
DECLARE @ValorePrioritaG decimal(10,2)
 
SET @PesoPrioritaG = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 671 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaG = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 671 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaG = (SELECT COUNT(ID_PRIORITA) AS VALORE  FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 671)
SET @PunteggioPrioritaG =  (@ValorePrioritaG * @PesoPrioritaG)  
--select @PunteggioPrioritag, '671'

--ID_PRIORITA=672	priorità H - Investimenti realizzati in edifici siti in centri/nuclei storici, o edifici di pregio storico architettonico o edifici di pregio paesistico ambientale	- LIVELLO D	
DECLARE @PunteggioPrioritaH decimal(10,2)
DECLARE @PesoPrioritaH decimal(10,2)
DECLARE @ValoreMAXPrioritaH decimal(10,2)
DECLARE @ValorePrioritaH decimal(10,2)
 
SET @PesoPrioritaH = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 672 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaH = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 672 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaH = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.5  ELSE 0  END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 672)
SET @PunteggioPrioritaH =  (@ValorePrioritaH * @PesoPrioritaH)  
--select @PunteggioPrioritag, '672'

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0) +
								   ISNULL(@PunteggioPrioritaD,0) +ISNULL(@PunteggioPrioritaE,0) + ISNULL(@PunteggioPrioritaF,0) +
								   ISNULL(@PunteggioPrioritaG,0) +ISNULL(@PunteggioPrioritaH,0) ))
							 
--select @PUNTEGGIO_VARIANTE , @MINIMO_GRADUATORIA
IF(@PUNTEGGIO_VARIANTE > isnull(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
