﻿create PROCEDURE [dbo].[calcoloStepVariante221_14]
(
@ID_VARIANTE int
)
AS
BEGIN
 

DECLARE @RESULT int, @ID_PROGETTO INT, @VALORE_MINIMO DECIMAL(18,2), @CONTRIBUTO_ATTUALE DECIMAL(18,2)
		
SET @RESULT = 1 -- PONGO LO STEP IN STATO VERIFICATO
SELECT @ID_PROGETTO =  ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE 
SELECT @VALORE_MINIMO= ISNULL (VALORE,0) FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 600 AND  ID_PROGETTO = @ID_PROGETTO 
SELECT @CONTRIBUTO_ATTUALE= ISNULL(SUM(CONTRIBUTO_RICHIESTO),0) FROM PROGETTO P
	INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
WHERE I.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A' AND I.COD_TIPO_INVESTIMENTO = 1 


SELECT ISNULL(@VALORE_MINIMO,0) + ISNULL(@CONTRIBUTO_ATTUALE,0)
END