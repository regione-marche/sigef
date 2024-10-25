create PROCEDURE [dbo].[calcoloStepVarinate111_14]
@ID_VARIANTE  int
AS
BEGIN
--- Totale costo di ricognizione <= 20% totale domanda
  
DECLARE @COSTO_INVESTIMENTI DECIMAL(18,2)
SELECT @COSTO_INVESTIMENTI=SUM(COSTO_INVESTIMENTO) FROM PIANO_INVESTIMENTI WHERE COD_TIPO_INVESTIMENTO=1 and 
 ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x') != 'A' 
---------------------------------------------------------------------------------------------------
declare @RESULT int= 1
-- 2. Totale spese ricognizione <= 20% totale domanda (codifica investimento = 11)

DECLARE @COSTO_INVESTIMENTI_RICOG DECIMAL(18,2)
 
IF @COSTO_INVESTIMENTI>0 BEGIN
	SELECT @COSTO_INVESTIMENTI_RICOG=ISNULL(SUM(COSTO_INVESTIMENTO),0) FROM  VPIANO_INVESTIMENTI I 
	WHERE  ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x') != 'A' and I.COD_TIPO_INVESTIMENTO = 1
			AND CODICE = '11' 
	  IF @COSTO_INVESTIMENTI_RICOG>(@COSTO_INVESTIMENTI*0.20)  SET @RESULT=0 
		 
	END
SELECT @RESULT 

END
