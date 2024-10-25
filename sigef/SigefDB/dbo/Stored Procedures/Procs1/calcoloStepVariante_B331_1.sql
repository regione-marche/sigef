create PROCEDURE [dbo].[calcoloStepVariante_B331_1]
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

--1047	A) Tipologia di servizi attivati	50.00	SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.6 WHEN VP.CODICE = '3' THEN 0.3 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1047
--1048	B) Avvio di servizi destinati a creare occupazione	15.00	SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1048
--1049	C) Interventi finalizzati a migliorare il servizio scolastico	20.00	SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1049
--1050	D) Interventi finalizzati ad aumentare l’offerta di centri culturali, ricreativi e di aggregazione per la popolazione	15.00	SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1050

--select @MINIMO_GRADUATORIA, @ID_BANDO

--------------------------------------------------------------------------------------------------------------------------   
-------------------------------------------------------------------------------------------------------------------------- 

--1047	
-- A) Tipologia di servizi attivati - peso 50.00
-- SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1 WHEN VP.CODICE = '2' THEN 0.6 WHEN VP.CODICE = '3' THEN 0.3 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE) WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1047
DECLARE @PunteggioPrioritaA decimal(10,2)
DECLARE @PesoPrioritaA decimal(10,2)
DECLARE @ValoreMAXPrioritaA decimal(10,2)
DECLARE @ValorePrioritaA decimal(10,2)

SET @PesoPrioritaA= (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1047 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaA = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1047 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaA =  (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.6 WHEN VP.CODICE = '3' THEN 0.3 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1047)
SET @PunteggioPrioritaA = (@ValorePrioritaA * @PesoPrioritaA)
--select @PunteggioPrioritaA, '1047'
--------------------------------------------------------------------------------------------------------------------------   
--------------------------------------------------------------------------------------------------------------------------   

--1048	
--B) Avvio di servizi destinati a creare occupazione - peso	15.00
-- SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1048
DECLARE @PesoPrioritaB decimal(10,2)
DECLARE @ValoreMAXPrioritaB decimal(10,2)
DECLARE @ValorePrioritaB decimal(10,2)
DECLARE @PunteggioPrioritaB decimal(10,2)

SET @PesoPrioritaB = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1048 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaB = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1048 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaB = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1048)
SET @PunteggioPrioritaB = (@ValorePrioritaB * @PesoPrioritaB) 
--select @PunteggioPrioritaB, '1048'
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--1049	
-- C) Interventi finalizzati a migliorare il servizio scolastico - peso	20.00
-- SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1049
DECLARE @PesoPrioritaC decimal(10,2)
DECLARE @ValoreMAXPrioritaC decimal(10,2)
DECLARE @ValorePrioritaC decimal(10,2)
DECLARE @PunteggioPrioritaC decimal(10,2)

SET @PesoPrioritaC = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1049 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaC = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1049 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValorePrioritaC = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1049)
SET @PunteggioPrioritaC = (@ValorePrioritaC * @PesoPrioritaC)  
--select @PunteggioPrioritaC, '994'
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

--1050
-- D) Interventi finalizzati ad aumentare l’offerta di centri culturali, ricreativi e di aggregazione per la popolazione - peso	15.00
-- SELECT PUNTEGGIO = CASE   WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1050
 DECLARE @PesoPrioritaD decimal(10,2)
DECLARE @ValoreMAXPrioritaD decimal(10,2)
DECLARE @ValorePrioritaD decimal(10,2)
DECLARE @PunteggioPrioritaD decimal(10,2)

SET @PesoPrioritaD = (SELECT ISNULL(PESO,0) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1050 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
SET @ValoreMAXPrioritaD = (SELECT ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA WHERE ID_PRIORITA = 1050 AND ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione)
set @ValorePrioritaD = (SELECT PUNTEGGIO = CASE WHEN VP.CODICE = '1' THEN 1  WHEN VP.CODICE = '2' THEN 0.5 ELSE 0  END  FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)  WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1050)
SET @PunteggioPrioritaD =  (@ValorePrioritaD * @PesoPrioritaD)  
--select @PunteggioPrioritaD, '995'
--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

DECLARE @PUNTEGGIO_VARIANTE DECIMAL(18,4)
SET @PUNTEGGIO_VARIANTE = (SELECT (ISNULL(@PunteggioPrioritaA,0) +ISNULL(@PunteggioPrioritaB,0) 
								  +ISNULL(@PunteggioPrioritaC,0) +ISNULL(@PunteggioPrioritaD,0)
								  ))
							 
--select @PUNTEGGIO_VARIANTE , @MINIMO_GRADUATORIA
IF(@PUNTEGGIO_VARIANTE > isnull(@MINIMO_GRADUATORIA,0) )SELECT 1 AS RESULT
ELSE SELECT 0 AS RESULT
	
END
