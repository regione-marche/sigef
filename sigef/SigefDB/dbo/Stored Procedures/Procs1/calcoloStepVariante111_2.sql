CREATE  PROCEDURE [dbo].[calcoloStepVariante111_2]
  @ID_VARIANTE int
AS
BEGIN

--   111b) Zucchero 2008 - 
--   Sportelli informativi <= 70% totale domanda (Codifica investimento = 9a)

DECLARE @Result int, @IdProgetto INT 
SET @Result = 1 -- Impongo lo Step verificato
SET @IdProgetto = (SELECT ID_PROGETTO  FROM VARIANTI WHERE ID_VARIANTE= @ID_VARIANTE)
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- 1. Realizzazione di Sportello Informativo (9a)

DECLARE @SpeseSportelli  decimal (10,2)
DECLARE @NumeroSportello9a int
DECLARE @NumeroSportelli9b int
 

SET @SpeseSportelli  = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
						PI.COD_TIPO_INVESTIMENTO = 1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT  NULL  AND  ID_VARIANTE = @ID_VARIANTE
						AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
															FROM CODIFICA_INVESTIMENTO
															WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
															AND CODICE = '9a'))

--Priorita 117 111 b) Zucchero 2008 - numero Sportelli Informativi per imprese con superficie a bietola <= 10 ha
SET @NumeroSportello9a = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 113)

--Priorita 118  111 b) Zucchero 2008 - numero Sportelli Informativi per imprese con superficie a bietola > 10 ha
SET @NumeroSportelli9b = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 114)



IF (@SpeseSportelli  >  (100 * ISNULL(@NumeroSportello9a,0) +  200 * ISNULL(@NumeroSportelli9b,0))) SET @Result = 0
 
 
--------------------------------------------------------------------------------------------------------------
DECLARE @TOTALE  decimal (10,2)
SET @TOTALE= ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
						PI.COD_TIPO_INVESTIMENTO = 1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL  AND ID_VARIANTE = @ID_VARIANTE    )

						
IF((@SpeseSportelli) > (@TOTALE * 0.7) )SET @Result=0


SELECT @Result AS RESULT


END
