CREATE PROCEDURE [dbo].[calcoloStepVariante123_6]
@ID_VARIANTE int
AS
BEGIN

--  123 - verifica % spese tecniche per fasce di spesa di investimento:
 
-- Nella checklist  la condizione da verificare è la seguente:
-- Tutti gli investimenti  <= 500.000,00 €  % spese ammissibili 

DECLARE  @COSTO DECIMAL(18,2)
 SELECT @COSTO= SUM(COSTO_INVESTIMENTO)
              FROM PIANO_INVESTIMENTI  PI
		      WHERE  PI.ID_VARIANTE = @ID_VARIANTE   AND   isnull(COD_VARIAZIONE,'x')!='A' AND  PI.COD_TIPO_INVESTIMENTO = 1 
 	 
            
--select @Count as conta

IF (@COSTO > 500000) SELECT 0 AS RESULT
ELSE SELECT 1 AS RESULT
END
