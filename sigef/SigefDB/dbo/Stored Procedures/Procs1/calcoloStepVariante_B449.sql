create PROCEDURE [dbo].[calcoloStepVariante_B449]
@ID_VARIANTE int
AS
BEGIN

-- Controllo validO per MANTENIMENTO PUNTEGGIO MINIMO PER LA GRADUATORIA:
-- i punteggi in graduatoria sono relativi a 100 -->  divido per 100 

--726	Investimenti integrativi rispetto ad interventi FESR	D	SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 726
--727	Investimenti realizzati in aree Natura 2000	I	SELECT VALORE = CASE WHEN ((  (SELECT ISNULL(SUM(I.COSTO_INVESTIMENTO),0) + ISNULL(SUM(I.SPESE_GENERALI),0) AS Totale_Inve_NAT2000 FROM PIANO_INVESTIMENTI I  INNER JOIN    PRIORITA_X_INVESTIMENTI PPI ON I.ID_INVESTIMENTO = PPI.ID_INVESTIMENTO WHERE   I.ID_PROGETTO = @IdProgetto AND PPI.ID_PRIORITA = 727 AND     ((I.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL ) OR  (@FASE_ISTRUTTORIA =1 AND (I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL AND @ID_VARIANTE is null ) OR  (ID_VARIANTE  = @ID_VARIANTE AND @ID_VARIANTE is not null  AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A')))) * 100)     /  (SELECT ISNULL(SUM(I.COSTO_INVESTIMENTO),0) + ISNULL(SUM(I.SPESE_GENERALI),0) AS Totale_Investimenti  FROM PROGETTO P INNER JOIN PIANO_INVESTIMENTI I ON P.ID_PROGETTO=I.ID_PROGETTO WHERE P.ID_PROGETTO=@IdProgetto AND  ((I.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL ) OR  (@FASE_ISTRUTTORIA =1 AND (I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL AND @ID_VARIANTE is null  ) OR  (ID_VARIANTE  = @ID_VARIANTE AND @ID_VARIANTE  is not null  AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A'))))   ) >= 51 THEN 1 ELSE 0 END
--728	Investimenti realizzati in Comuni con meno di 2000 abitanti	D	SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 728
--729	Investimenti realizzati in Comuni con bassa densità abitativa	D	SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 729
--730	Borghi censiti nell`ambito del progetto di cooperazione dell`I.C. Leader Plus denominato “Analisi del sistema dei borghi storici rurali nell`entroterra marchigiano per la loro rivalutazione	D	SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 730
--731	Qualità dell`intervento rispetto il riuso successivo	D	SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.75  WHEN VP.CODICE = '3' THEN 0.5  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 731
--732	Livello della progettazione	D	SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 732


DECLARE @IdSchedaValutazione int, @IdProgetto INT, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4), @CountNonFinanziabili INT, @CountFinanziabilaParziale INT

SET @IdProgetto= (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)


-----  Qui imposto valore minimo punteggio

SET @CountNonFinanziabili = (SELECT COUNT(*) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N')
SET @CountFinanziabilaParziale = (SELECT COUNT(*) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='P')

IF (@CountNonFinanziabili > 0) 
	SET @MINIMO_GRADUATORIA = (SELECT TOP(1) ISNULL(PUNTEGGIO,0) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='N' ORDER BY PUNTEGGIO DESC)	
ELSE	
	SET @MINIMO_GRADUATORIA = 0
	
IF (@CountFinanziabilaParziale > 0) 
		SET @MINIMO_GRADUATORIA = (SELECT TOP(1) ISNULL(PUNTEGGIO,0) FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='P' ORDER BY PUNTEGGIO DESC)

---

SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

 
--726	Investimenti integrativi rispetto ad interventi FESR	D	SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 726
DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 726 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 726 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaA =  ( SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 726)
SET @PunteggioPrioritaA = (@ValorePrioritaA * @PesoPrioritaA)


--727	Investimenti realizzati in aree Natura 2000	I	
DECLARE @PesoPrioritaB decimal(10,2),
        @ValoreMAXPrioritaB decimal(10,2),
        @ValorePrioritaB decimal(10,2),
        @PunteggioPrioritaB decimal(10,2),
        @COSTO_inv_prio decimal(18,2),
        @costo_investimenti Decimal(18,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 727 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 727 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)

SELECT @costo_inv_prio =  ISNULL(SUM(I.COSTO_INVESTIMENTO),0) + ISNULL(SUM(I.SPESE_GENERALI),0) 
FROM PIANO_INVESTIMENTI I 
    INNER JOIN PRIORITA_X_INVESTIMENTI PPI ON I.ID_INVESTIMENTO = PPI.ID_INVESTIMENTO 
WHERE I.ID_PROGETTO = @IdProgetto AND PPI.ID_PRIORITA = 727 AND 
     ID_VARIANTE  = @ID_VARIANTE AND @ID_VARIANTE is not null  AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A' 
 
SET @costo_investimenti = (SELECT DBO.calcoloCostoTotaleProgetto (@IdProgetto,1,@ID_VARIANTE))

if(@costo_inv_prio >= @costo_investimenti * 0.51)
set @ValorePrioritaB = 1
else set @ValorePrioritaB = 0
 
SET @PunteggioPrioritaB = ((@ValorePrioritaB ) * @PesoPrioritaB)


--728	Investimenti realizzati in Comuni con meno di 2000 abitanti	D	
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 728 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 728 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 728)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)  

--729	Investimenti realizzati in Comuni con bassa densità abitativa	D	
 DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
DECLARE @PunteggioPrioritaD decimal(10,2)

SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 729 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 729 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaD = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 729)
SET @PunteggioPrioritaD =  (@ValorePrioritaD * @PesoPrioritaD)  

--730	Borghi censiti nell`ambito del progetto di cooperazione dell`I.C. Leader Plus denominato “Analisi del sistema dei borghi storici rurali nell`entroterra marchigiano per la loro rivalutazione	D	
DECLARE @PunteggioPrioritaE decimal(10,2)
 DECLARE @PesoPrioritaE decimal(10,2)
DECLARE @ValoreMAXPrioritaE decimal(10,2)
DECLARE @ValorePrioritaE decimal(10,2)

SET @PesoPrioritaE = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 730 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaE = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 730 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaE = (SELECT COUNT(ID_PRIORITA) AS VALORE   FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 730)
SET @PunteggioPrioritaE =  (@ValorePrioritaE * @PesoPrioritaE)  

--731	Qualità dell`intervento rispetto il riuso successivo	D
DECLARE @PunteggioPrioritaF decimal(10,2)
DECLARE @PesoPrioritaF decimal(10,2)
DECLARE @ValoreMAXPrioritaF decimal(10,2)
DECLARE @ValorePrioritaF decimal(10,2)
 
SET @PesoPrioritaF = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 731 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaF = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 731 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaF = (SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.75  WHEN VP.CODICE = '3' THEN 0.5  ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 731)
SET @PunteggioPrioritaF =  (@ValorePrioritaF* @PesoPrioritaF)  

--732	Livello della progettazione	D	
DECLARE @PunteggioPrioritaG decimal(10,2)
DECLARE @PesoPrioritaG decimal(10,2)
DECLARE @ValoreMAXPrioritaG decimal(10,2)
DECLARE @ValorePrioritaG decimal(10,2)
 
SET @PesoPrioritaG = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 732 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaG = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 732 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaG = (SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 732)
SET @PunteggioPrioritaG =  (@ValorePrioritaG* @PesoPrioritaG)  


DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)

SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0) +
									ISNULL(@PunteggioPrioritaD,0) +ISNULL(@PunteggioPrioritaE,0) + ISNULL(@PunteggioPrioritaF,0) +
									ISNULL(@PunteggioPrioritaG,0)))
select @PUNTEGGIO_VARIANTE as  PUNTEGGIO_VARIANTE

IF(@PUNTEGGIO_VARIANTE > ISNULL(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
