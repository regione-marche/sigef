﻿CREATE PROCEDURE [dbo].[calcoloStep4137_MONF]
@IdProgetto int, 
@FASE_ISTRUTTORIA INT = 0,
@IdVariante INT = 0
AS
BEGIN
--- Coerenza tra la tipologia di beneficiario (pubblico o privato) e la tipologia di intervento da attivare
-- SE PUBBLICO PUò FARE ENTRAMBI GLI INTERVENTI (CODIFICHE), SE PRIVATO UNA SOLA
--declare @IdProgetto int, 
--@FASE_ISTRUTTORIA INT 

--set @IdProgetto = 834 
-- set @FASE_ISTRUTTORIA =0

DECLARE @result int , @CONTA_PRIORITA INT, @CONTA_CODIFICHE INT
SET @result = 0 --- INIZIALIZZO IN STATO NON VERIFICATO

SELECT @CONTA_PRIORITA = (SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1089)
 
SELECT @CONTA_CODIFICHE = COUNT (distinct(ISNULL (CODICE,0))) FROM VPIANO_INVESTIMENTI I
WHERE ID_PROGETTO = @IdProgetto AND ((@fase_istruttoria=0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
	OR (@fase_istruttoria=1 AND (I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE  IS NULL AND @IdVariante=0 ) 
		OR (ID_VARIANTE  = @IdVariante AND @IdVariante >0 AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A' )))
	AND I.CODICE IN ('a1','b1') 
 
 
 IF((@CONTA_CODIFICHE <= 2 AND ISNULL(@CONTA_PRIORITA,0) = 1) OR ( @CONTA_CODIFICHE =1 AND ISNULL(@CONTA_PRIORITA,0) = 0)) SET @result = 1

SELECT @result AS RESULT
END
