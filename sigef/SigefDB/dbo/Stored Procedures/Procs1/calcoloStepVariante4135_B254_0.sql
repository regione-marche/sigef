CREATE PROCEDURE [dbo].[calcoloStepVariante4135_B254_0]
@ID_VARIANTE int
AS
BEGIN
--- MANTENIMENTO PUNTEGGIO MINIMO

--declare @ID_VARIANTE int
--SET @ID_VARIANTE = 


DECLARE @IdSchedaValutazione int, @IdProgetto int, @ID_BANDO INT
DECLARE @MINIMO_GRADUATORIA DECIMAL(18,4)

SET @IdProgetto= (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE )
SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO= @IdProgetto)

SET @MINIMO_GRADUATORIA = (SELECT TOP(1) PUNTEGGIO FROM  GRADUATORIA_PROGETTI WHERE ID_BANDO = @ID_BANDO AND FINANZIABILITA ='P' ORDER BY PUNTEGGIO DESC)

--SELECT @MINIMO_GRADUATORIA AS M
SET @IdSchedaValutazione = (SELECT ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON (B.ID_BANDO = P.ID_BANDO) WHERE P.ID_PROGETTO = @IdProgetto)

--Studi e ricerche riguardanti aree Natura 2000 (azione a)	
--SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 894) =  1  THEN 0.2 ELSE 0 END

DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 894 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 894 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET  @ValorePrioritaA =  (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 894) =  1  THEN 0.2 ELSE 0 END)
SET @PunteggioPrioritaA = ((@ValorePrioritaA ) * @PesoPrioritaA)
--select @PunteggioPrioritaA, '894'
   
   
--Studi e ricerche totalmente riguardanti aree D e C3 (azione a)	
--SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 895) =  1  THEN 0.2 ELSE 0 END
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 895 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 895 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 895) =  1  THEN 0.2 ELSE 0 END)
SET @PunteggioPrioritaB = ((@ValorePrioritaB ) * @PesoPrioritaB) 
--select @PunteggioPrioritaB, '895'

--studi e ricerche riguardanti il patrimonio artistico, storico ed archeologico delle aree rurali. (azione a)	
--SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 896) =  1  THEN 0.2 ELSE 0 END
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 896 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 896 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 896) =  1  THEN 0.2 ELSE 0 END)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)
  
--studio e ricerca  finalizzato ad individuare modalità di valorizzazione del bene oggetto di intervento. (azione a)	
--- SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 897) =  1  THEN 0.2 ELSE 0 END
 DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
DECLARE @PunteggioPrioritaD decimal(10,2)

SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 897 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 897 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaD = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 897) =  1  THEN 0.2 ELSE 0 END)
SET @PunteggioPrioritaD =  (@ValorePrioritaD * @PesoPrioritaD)  
--select @PunteggioPrioritaD, '897'

--Investimenti integrativi rispetto ad interventi FESR (azione b)	
---SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 898) =  1  THEN 0.8 ELSE 0 END
DECLARE @PunteggioPrioritaE decimal(10,2)
DECLARE @PesoPrioritaE decimal(10,2)
DECLARE @ValoreMAXPrioritaE decimal(10,2)
DECLARE @ValorePrioritaE decimal(10,2)

SET @PesoPrioritaE = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 898 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaE = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 898 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaE = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 898) =  1  THEN 0.8 ELSE 0 END)
SET @PunteggioPrioritaE =  (@ValorePrioritaE * @PesoPrioritaE)
--select @PunteggioPrioritaE, '898'

--Investimenti realizzati in aree Natura 2000 (azione b)	
---SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 899) =  1  THEN 0.8 ELSE 0 END
DECLARE @PunteggioPrioritaF decimal(10,2)
DECLARE @PesoPrioritaF decimal(10,2)
DECLARE @ValoreMAXPrioritaF decimal(10,2)
DECLARE @ValorePrioritaF decimal(10,2)
 
SET @PesoPrioritaF = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 899 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaF = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 899 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaF = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 899) =  1  THEN 0.8 ELSE 0 END)
SET @PunteggioPrioritaF =  (@ValorePrioritaF * @PesoPrioritaF)
--select @PunteggioPrioritaF, '899'

--Investimenti totalmente realizzati nelle aree D e C3 (azione b)	
---SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 900) =  1  THEN 0.8 ELSE 0 END
DECLARE @PunteggioPrioritaG decimal(10,2)
DECLARE @PesoPrioritaG decimal(10,2)
DECLARE @ValoreMAXPrioritaG decimal(10,2)
DECLARE @ValorePrioritaG decimal(10,2)
 
SET @PesoPrioritaG = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 900 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaG = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 900 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaG = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 900) =  1  THEN 0.8 ELSE 0 END)
SET @PunteggioPrioritaG =  (@ValorePrioritaG* @PesoPrioritaG)  
--select @PunteggioPrioritag, '900'

--investimenti da realizzarsi nell`ambito di un progetto integrato in termini di investimenti complementari (azione b)	
--SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 901) =  1  THEN 0.8 ELSE 0 END
DECLARE @PunteggioPrioritaH decimal(10,2)
DECLARE @PesoPrioritaH decimal(10,2)
DECLARE @ValoreMAXPrioritaH decimal(10,2)
DECLARE @ValorePrioritaH decimal(10,2)
 
SET @PesoPrioritaH = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 901 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaH = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 901 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaH = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 901) =  1  THEN 0.8 ELSE 0 END)
SET @PunteggioPrioritaH =  (@ValorePrioritaH* @PesoPrioritaH)  
--select @PunteggioPrioritaH, '901'

--interventi riguardanti il patrimonio artistico, storico ed archeologico delle aree rurali. (azione b)	
--SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 902) =  1  THEN 0.8 ELSE 0 END
DECLARE @PunteggioPrioritaI decimal(10,2)
DECLARE @PesoPrioritaI decimal(10,2)
DECLARE @ValoreMAXPrioritaI decimal(10,2)
DECLARE @ValorePrioritaI decimal(10,2)
 
SET @PesoPrioritaI = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 902 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaI = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 902 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaI = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 902) =  1  THEN 0.8 ELSE 0 END)
SET @PunteggioPrioritaI =  (@ValorePrioritaI* @PesoPrioritaI)  
--select @PunteggioPrioritaI, '902'

--interventi che migliorino la sicurezza, la accessibilità e la fruizione per i diversamente abili (azione b)	
--SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 903) =  1  THEN 0.8 ELSE 0 END
DECLARE @PunteggioPrioritaL decimal(10,2)
DECLARE @PesoPrioritaL decimal(10,2)
DECLARE @ValoreMAXPrioritaL decimal(10,2)
DECLARE @ValorePrioritaL decimal(10,2)
 
SET @PesoPrioritaL = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 903 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaL = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 903 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaL = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 903) =  1  THEN 0.8 ELSE 0 END)
SET @PunteggioPrioritaL =  (@ValorePrioritaL * @PesoPrioritaL)  
--select @PunteggioPrioritaL, '903'


--interventi che prevedano dispositivi tecnologici (ICT). (azione b)	
--SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 904) =  1  THEN 0.8 ELSE 0 END
DECLARE @PunteggioPrioritaM decimal(10,2)
DECLARE @PesoPrioritaM decimal(10,2)
DECLARE @ValoreMAXPrioritaM decimal(10,2)
DECLARE @ValorePrioritaM decimal(10,2)
 
SET @PesoPrioritaM = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 904 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaM = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 904 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaM = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 904) =  1  THEN 0.8 ELSE 0 END)
SET @PunteggioPrioritaM =  (@ValorePrioritaM * @PesoPrioritaM)  
--select @PunteggioPrioritaM, '904'

--investimenti e partecipazione finanziaria del proponente (Azione b)	
--SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 0.8  WHEN VP.CODICE = '2' THEN 0.56 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 905
DECLARE @PunteggioPrioritaN decimal(10,2)
DECLARE @PesoPrioritaN decimal(10,2)
DECLARE @ValoreMAXPrioritaN decimal(10,2)
DECLARE @ValorePrioritaN decimal(10,2)
 
SET @PesoPrioritaN = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 905 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaN = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 905 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaN = (SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 0.8  WHEN VP.CODICE = '2' THEN 0.56 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 905)
SET @PunteggioPrioritaN =  (@ValorePrioritaN * @PesoPrioritaN)  
--select @PunteggioPrioritaN, '905'

--iniziative economiche sostenibili (azione b)	
--SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 906) =  1  THEN 0.8 ELSE 0 END
DECLARE @PunteggioPrioritaO decimal(10,2)
DECLARE @PesoPrioritaO decimal(10,2)
DECLARE @ValoreMAXPrioritaO decimal(10,2)
DECLARE @ValorePrioritaO decimal(10,2)
 
SET @PesoPrioritaO = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 906 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaO = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 906 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaO = (SELECT VALORE = CASE  WHEN (SELECT COUNT(*) FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 906) =  1  THEN 0.8 ELSE 0 END)
SET @PunteggioPrioritaO =  (@ValorePrioritaO * @PesoPrioritaO)  
--select @PunteggioPrioritaO, '906'


DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) +ISNULL(@PunteggioPrioritaC,0) +
								   ISNULL(@PunteggioPrioritaD,0) +ISNULL(@PunteggioPrioritaE,0) +ISNULL(@PunteggioPrioritaF,0) +
								   ISNULL(@PunteggioPrioritaG,0) +ISNULL(@PunteggioPrioritaH,0) +ISNULL(@PunteggioPrioritaI,0) + 
								   ISNULL(@PunteggioPrioritaL,0) +ISNULL(@PunteggioPrioritaM,0) +ISNULL(@PunteggioPrioritaN,0) +
								   ISNULL(@PunteggioPrioritaO,0) ))
							 
--select @PUNTEGGIO_VARIANTE , @MINIMO_GRADUATORIA
IF(@PUNTEGGIO_VARIANTE >= isnull(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
