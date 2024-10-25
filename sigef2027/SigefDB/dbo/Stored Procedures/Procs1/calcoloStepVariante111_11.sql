CREATE PROCEDURE [dbo].[calcoloStepVariante111_11]
 @ID_VARIANTE int
AS
BEGIN

-- 111b) - Spesa relativa alle Azioni informative sulla sicurezza almeno il 20% del costo totale progetto
-- 1155 id priorita sicurezza

DECLARE @Result int, @COSTO_SICUREZZA DECIMAL(18,2), @COSTO_PROGETTO DECIMAL(18,2), @IdProgetto INT 
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
SELECT @COSTO_SICUREZZA = SUM(COSTO_INVESTIMENTO) 
FROM PIANO_INVESTIMENTI INV 
	INNER JOIN PRIORITA_X_INVESTIMENTI PXI ON PXI.ID_INVESTIMENTO = INV.ID_INVESTIMENTO AND PXI.ID_PRIORITA = 1155
	INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = INV.ID_CODIFICA_INVESTIMENTO
WHERE C.CODICE IN ('1','2','3','4','9','10') AND INV.ID_VARIANTE =@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'x') != 'A'
	 	
SELECT @IdProgetto  = ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE=@ID_VARIANTE

SELECT @COSTO_PROGETTO = DBO.calcoloCostoTotaleProgetto(@IdProgetto,1,@ID_VARIANTE)
IF(@COSTO_SICUREZZA < @COSTO_PROGETTO * 0.2) SET @Result = 0
ELSE SET @Result = 1
SELECT @Result AS RESULT

END
