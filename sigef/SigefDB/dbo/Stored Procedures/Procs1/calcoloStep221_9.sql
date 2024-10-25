﻿CREATE PROCEDURE [dbo].[calcoloStep221_9]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
	
-- Investimenti completi dell`indicazione di superficie (m2) e anno
-- R_IMPIANTO --> solo metri 
-- Spese generali R_IMPIANTO --> solo metri 
-- Perdita reddito --> solo metri 
-- R_MANUTENZIONE --> metrei + anno 

DECLARE @loopANNO int,
		@RESULT int
		
SET @RESULT = 1 -- PONGO LO STEP IN STATO VERIFICATO

-- ANNO
DECLARE @ANNO INT
SELECT @ANNO = COUNT(*) FROM PIANO_INVESTIMENTI AS PI INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON PI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO WHERE (PI.ID_PROGETTO = @IdProgetto) AND (((PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL)OR(PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) AND PXI.ID_PRIORITA = 604)

-- ETTARI
DECLARE @ETTARI INT
SELECT @ETTARI = COUNT(*) FROM PIANO_INVESTIMENTI AS PI INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON PI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO WHERE (PI.ID_PROGETTO = @IdProgetto) AND (((PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL)OR(PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) AND PXI.ID_PRIORITA = 605)

-- MANUTENZIONE DEVE ESSERE 1
DECLARE @MANUTENZIONE INT
SELECT @MANUTENZIONE = (SELECT count(distinct vpi.id_investimento)  FROM VPIANO_INVESTIMENTI VPI inner join 
		PRIORITA_X_INVESTIMENTI PXI ON VPI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO 
WHERE 
		VPI.ID_PROGETTO = @IdProgetto AND
		((VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL)OR(VPI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL))	AND	
		VPI.CODICE = 'c')
		-
		(SELECT COUNT(*) FROM VPIANO_INVESTIMENTI VPI inner join 
		PRIORITA_X_INVESTIMENTI PXI ON VPI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO WHERE
		VPI.ID_PROGETTO = @IdProgetto AND
		((VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL)OR(VPI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL))	AND	
		PXI.ID_PRIORITA IN (640,605) AND VPI.CODICE = 'c')

DECLARE @NUMERO_INVESTIMENTI INT
SELECT @NUMERO_INVESTIMENTI = (SELECT COUNT(*) from PIANO_INVESTIMENTI PI WHERE PI.ID_PROGETTO = @IdProgetto AND ((PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL)OR(PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)))

IF (@MANUTENZIONE IS NOT NULL OR @MANUTENZIONE = 1) AND (@ETTARI = @NUMERO_INVESTIMENTI)
 SET @RESULT = 1 -- VA BENE
 ELSE SET @RESULT = 0  
 
SELECT @RESULT
END
