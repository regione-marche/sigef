CREATE PROCEDURE [dbo].[calcoloStep123_6]
@IdProgetto int
AS
BEGIN

--  123 - verifica % spese tecniche per fasce di spesa di investimento:
 
-- Nella checklist presentazione la condizione da verificare è la seguente:
-- Tutti gli investimenti  <= 500.000,00 €  % spese ammissibili 

DECLARE @Count int
SET @Count = (SELECT COUNT(ID_INVESTIMENTO)
		      FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
		      WHERE I.ID_INVESTIMENTO_ORIGINALE IS NULL AND I.COD_TIPO_INVESTIMENTO = 1 
			  AND (P.ID_PROGETTO=@IdProgetto )
			  AND COSTO_INVESTIMENTO > 500000 -- Investimenti che superano i 500.000,00
             )
IF (@Count > 0) 
SELECT 0 AS RESULT
ELSE SELECT 1 AS RESULT

END
