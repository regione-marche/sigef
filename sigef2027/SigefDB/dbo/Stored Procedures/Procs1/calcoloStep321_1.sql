CREATE   PROCEDURE [dbo].[calcoloStep321_1]
@IdProgetto int, @faseIstruttoria int=0
AS
BEGIN
 
--- 321 microfiliera - spesa lavoi in economia  non  superiore  al  20%  del  costo  totale  del  progetto  e  comunque  per  una  sp esa  complessiva  non superiore a 50.000 €
 
DECLARE @RESULT int, @costo_progetto decimal(18,2),@COSTO_LEC DECIMAL(18,2)
 
SET @RESULT = 1  -- Impongo lo Step   verificato
--------------------------------------------------------------------------------------------------------------
 
-- SELECT @costo_progetto = dbo.calcoloCostoTotaleProgetto (@IdProgetto,@faseIstruttoria, NULL) 
 
 SELECT @costo_progetto=SUM(COSTO_INVESTIMENTO)FROM PIANO_INVESTIMENTI INV 
 WHERE ID_PROGETTO=@IdProgetto AND ((INV.ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL AND @faseIstruttoria=0)OR(INV.ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @faseIstruttoria=1 ))
 
 SELECT @COSTO_LEC = SUM(VALORE)FROM PIANO_INVESTIMENTI INV 
	INNER JOIN PRIORITA_X_INVESTIMENTI PXI ON PXI.ID_INVESTIMENTO= INV.ID_INVESTIMENTO AND ID_PRIORITA =1202
 WHERE ID_PROGETTO=@IdProgetto AND ((INV.ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL AND @faseIstruttoria=0)OR(INV.ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @faseIstruttoria=1 ))
  
 IF(@COSTO_LEC >50000 OR @COSTO_LEC >(@costo_progetto *0.20))SET @RESULT =0 

SELECT @RESULT
 END
