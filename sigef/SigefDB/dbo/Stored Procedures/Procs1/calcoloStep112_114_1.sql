﻿CREATE   PROCEDURE [dbo].[calcoloStep112_114_1]
@IdProgetto int
AS
-- CONTROLLO SU ALLEGATI OBBLIGATORI  114
-- FATTO!!! 

/*
DECLARE @IdProgetto INT
SET @IdProgetto=375
*/
DECLARE @RESULT INT
DECLARE @ID_PROG_INTEG_114 INT

SELECT DISTINCT @ID_PROG_INTEG_114 = p.ID_PROGETTO FROM PROGETTO P
INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.1.4.'
WHERE ID_PROG_INTEGRATO = @IdProgetto

IF @ID_PROG_INTEG_114 IS NULL SET @RESULT=2
ELSE BEGIN
	DECLARE @NUMERO_INVESTIMENTI INT
	SET @NUMERO_INVESTIMENTI =(SELECT COUNT(*) FROM PIANO_INVESTIMENTI WHERE ID_PROGETTO=@ID_PROG_INTEG_114 AND ID_INVESTIMENTO_ORIGINALE IS NULL )
	IF (ISNULL(@NUMERO_INVESTIMENTI,0) =0 ) SET @RESULT=2
	ELSE BEGIN
		SET @RESULT=(SELECT COUNT(*) FROM ALLEGATI_x_PROGETTO  A WHERE ID_PROGETTO=@IdProgetto  AND ID_ALLEGATO IN (228,229))
	END
END
SELECT @RESULT