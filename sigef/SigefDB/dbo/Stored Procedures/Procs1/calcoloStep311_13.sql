﻿CREATE PROCEDURE [dbo].[calcoloStep311_13]
(
	@IdProgetto int,
	@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
 -- CONTROLLO TIPOLOGIE DI INTERVENTO 
DECLARE @ID_IMPRESA INT , @PROG_311_GIOVANI INT ,@COUNT INT,@RESULT INT
SELECT @ID_IMPRESA = P.ID_IMPRESA  
FROM PROGETTO P INNER JOIN IMPRESA IMP ON IMP.ID_IMPRESA = P.ID_IMPRESA  WHERE ID_PROGETTO = @IdProgetto 
 
SELECT @PROG_311_GIOVANI=COUNT( p.ID_PROGETTO) FROM VPROGETTO P
		INNER JOIN PIANO_INVESTIMENTI INV ON INV.ID_PROGETTO= P.ID_PROGETTO
		INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '3.1.1.A'
WHERE P.ID_BANDO = 135 AND COD_STATO = 'N' and p.ID_IMPRESA = @ID_IMPRESA

DECLARE @SPESE_IMMATERIALI DECIMAL(18,2)
SELECT @SPESE_IMMATERIALI = ISNULL(SUM(I.CONTRIBUTO_RICHIESTO - (I.COSTO_INVESTIMENTO * I.QUOTA_CONTRIBUTO_RICHIESTO/100)),0)  
FROM PROGETTO P 
	 INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
WHERE P.ID_PROGETTO = @IdProgetto AND  ((@FASE_ISTRUTTORIA =0 AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)OR
		(@FASE_ISTRUTTORIA = 1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))

IF(ISNULL(@PROG_311_GIOVANI,0)> 0 ) BEGIN 
	IF(@SPESE_IMMATERIALI>20000) SET @RESULT =0	 
	ELSE SET @RESULT =1
	
END
ELSE BEGIN 
	IF(@SPESE_IMMATERIALI>4500) SET @RESULT =0	 
	ELSE SET @RESULT =1
 
END

SELECT @RESULT  AS RESULT
END