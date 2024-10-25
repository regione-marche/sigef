CREATE PROCEDURE [dbo].[calcoloStepVariante121_4]
@ID_VARIANTE int
AS
BEGIN

--  121 - verifica % spese tecniche per fasce di spesa di investimento:
-- SERVE per fasi successive a Presentazione



-- Nella checklist presentazione la condizione da verificare è la seguente:
-- Tutti gli investimenti ad eccezione di MACCHINE, ATTREZZATURE MOBILI E MATERIALI <= 200.000,00 € -> SI

DECLARE @Count int
SET @Count = (SELECT COUNT(ID_INVESTIMENTO)
		      FROM  VPIANO_INVESTIMENTI I 
		      WHERE I.ID_INVESTIMENTO_ORIGINALE IS NULL AND I.COD_TIPO_INVESTIMENTO = 1 
			 AND I.ID_VARIANTE = @ID_VARIANTE   AND    isnull(COD_VARIAZIONE,'x')!='A' 
                              
			  AND ID_CODIFICA_INVESTIMENTO <> 35 AND ID_CODIFICA_INVESTIMENTO <> 240 -- Bando 121
			  AND ID_CODIFICA_INVESTIMENTO <> 140 -- Bando 121 (zucchero)
              AND COSTO_INVESTIMENTO > 200000 -- Investimenti che superano i 200000
             )

IF (@Count > 0) SELECT 0 AS RESULT
ELSE SELECT 1 AS RESULT



	
END
