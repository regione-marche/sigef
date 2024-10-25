CREATE PROCEDURE [dbo].[calcoloStep111_10]
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0 
AS
BEGIN

-- 111b) - Indicazione coerente delle spese destinate alla realizzazione delle azioni informative sulla sicurezza
-- 1155 id priorita sicurezza

--declare @IdProgetto int = 10353, @FASE_ISTRUTTORIA int =0

DECLARE @Result int, @C INT
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
DECLARE @ID_BANDO INT 
SELECT @ID_BANDO= ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto

SELECT @C = SUM(ISNULL(inv.COSTO_INVESTIMENTO, 0))   FROM PIANO_INVESTIMENTI INV 
	INNER JOIN PRIORITA_X_INVESTIMENTI PXI ON PXI.ID_INVESTIMENTO = INV.ID_INVESTIMENTO AND PXI.ID_PRIORITA = 1155
	INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = INV.ID_CODIFICA_INVESTIMENTO
WHERE C.CODICE NOT IN ('1','2','3','4','9','10') AND INV.ID_PROGETTO =@IdProgetto AND 
	((@FASE_ISTRUTTORIA=0 AND INV.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
		OR(@FASE_ISTRUTTORIA=1 AND INV.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NOT NULL ))

IF(@C>0) SET @Result = 0
ELSE   SET @Result = 1
SELECT @Result AS RESULT

END
