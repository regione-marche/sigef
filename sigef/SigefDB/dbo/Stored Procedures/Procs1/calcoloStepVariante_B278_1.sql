﻿CREATE PROCEDURE [dbo].[calcoloStepVariante_B278_1]
@ID_VARIANTE int
AS
BEGIN

---=== Coerenza tra la tipologia di beneficiario (pubblico o privato) e la tipologia di intervento da attivare ===--
-- SE PUBBLICO PUO' FARE ENTRAMBI GLI INTERVENTI (CODIFICHE), SE PRIVATO UNA SOLA

DECLARE @Result int,
		@IdProgetto int,
		@CONTA_PRIORITA INT,
		@CONTA_CODIFICHE INT
		

SET @Result = 1 -- Impongo lo Step  verificato

set @IdProgetto = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE =@ID_VARIANTE )

SELECT @CONTA_PRIORITA = (SELECT COUNT(ID_PRIORITA) AS VALORE FROM PRIORITA_X_PROGETTO  WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 1089)

SELECT @CONTA_CODIFICHE = COUNT (distinct(ISNULL (CODICE,0))) FROM VPIANO_INVESTIMENTI I
						  WHERE ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x') != 'A' AND I.CODICE IN ('a1','b1')

IF((@CONTA_CODIFICHE <= 2 AND ISNULL(@CONTA_PRIORITA,0) = 1) OR ( @CONTA_CODIFICHE =1 AND ISNULL(@CONTA_PRIORITA,0) = 0)) SET @result = 1
ELSE
	SET @result = 0			

SELECT @result AS RESULT
END