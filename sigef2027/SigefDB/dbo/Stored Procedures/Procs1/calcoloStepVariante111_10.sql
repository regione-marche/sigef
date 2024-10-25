create PROCEDURE [dbo].[calcoloStepVariante111_10]
  @ID_VARIANTE int
AS
BEGIN

-- 111b) - Indicazione coerente delle spese destinate alla realizzazione delle azioni informative sulla sicurezza
-- 1155 id priorita sicurezza

--declare @IdProgetto int = 10353, @FASE_ISTRUTTORIA int =0

DECLARE @Result int, @C INT , @IdProgetto int
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
DECLARE @ID_BANDO INT 

SELECT @IdProgetto  = ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE=@ID_VARIANTE
SELECT @ID_BANDO= ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto

SELECT @C = SUM(ISNULL(inv.COSTO_INVESTIMENTO, 0))   FROM PIANO_INVESTIMENTI INV 
	INNER JOIN PRIORITA_X_INVESTIMENTI PXI ON PXI.ID_INVESTIMENTO = INV.ID_INVESTIMENTO AND PXI.ID_PRIORITA = 1155
	INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = INV.ID_CODIFICA_INVESTIMENTO
WHERE C.CODICE NOT IN ('1','2','3','4','9','10')AND INV.ID_VARIANTE = @ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'x') != 'A'

IF(@C>0) SET @Result = 0
ELSE   SET @Result = 1
SELECT @Result AS RESULT

END
