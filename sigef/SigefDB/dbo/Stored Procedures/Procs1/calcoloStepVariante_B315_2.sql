CREATE PROCEDURE [dbo].[calcoloStepVariante_B315_2]
@ID_VARIANTE int

AS
BEGIN

DECLARE @ID_PROGETTO int, @FASE_ISTRUTTORIA INT = 1
----- Verifica se il contributo rispetta il massimo per tipologia di richiedente

SET @ID_PROGETTO = ( SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE)

DECLARE @result int, @CONTRIBUTO_RICHIESTO decimal(10,2), @TIPOLOGIA int
SET @result = 0

SET @CONTRIBUTO_RICHIESTO = dbo.calcoloContributoTotaleProgetto (@ID_PROGETTO,@FASE_ISTRUTTORIA,@ID_VARIANTE) 

SET @TIPOLOGIA = (SELECT isnull(COUNT(ID_PRIORITA),0) from priorita_x_progetto WHERE ID_PROGETTO = @ID_PROGETTO  and ID_PRIORITA = 1012)


IF(
((@TIPOLOGIA = 0)  AND (@CONTRIBUTO_RICHIESTO <= 36000)) OR  
((@TIPOLOGIA = 1)  AND (@CONTRIBUTO_RICHIESTO <= 60000))
) 
SET @result = 1
ELSE SET @result = 0

SELECT @result AS RESULT
END
