﻿CREATE  PROCEDURE [dbo].[calcoloStepVariante123_19]
  @ID_VARIANTE int
AS
BEGIN

--  123 - Totale inivestimenti per interventi 
-- id priorita 1171
 

DECLARE @COSTO DECIMAL (20,2), @RESULT INT,  @TIPO_PROGETTO CHAR(1),@IdProgetto INT
SET @RESULT =0  --- NON VERIFICATO

SET @IdProgetto = (SELECT id_progetto FROM VARIANTI WHERE ID_VARIANTE=@ID_VARIANTE)

SELECT @TIPO_PROGETTO =VP.CODICE
FROM PRIORITA_X_PROGETTO PP 
INNER JOIN VALORI_PRIORITA VP ON VP.ID_PRIORITA = PP.ID_PRIORITA AND VP.ID_VALORE = PP.ID_VALORE
WHERE ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 1171

IF (@TIPO_PROGETTO IS NULL )SET @RESULT=0
ELSE BEGIN
	SET @COSTO = DBO.calcoloCostoTotaleProgetto(@IdProgetto, 1, @ID_VARIANTE)
		IF(@TIPO_PROGETTO IN ('T','X'))BEGIN  IF( @COSTO > 100000) SET @RESULT=1 END
		ELSE BEGIN  IF( @COSTO > 20000) SET @RESULT=1 END		
END
 
SELECT @RESULT AS RESULT
END