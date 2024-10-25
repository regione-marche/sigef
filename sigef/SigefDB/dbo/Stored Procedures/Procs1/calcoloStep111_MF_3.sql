CREATE  PROCEDURE [dbo].[calcoloStep111_MF_3]
@IdProgetto int
AS
BEGIN

-- 111b) C MACROFILIERE  - Verifica spesa di investimento per codifica 
-- (Totale investimenti per codifica diviso numero delle iniziative)

DECLARE @Result int
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------

-- 1. Spese per "Incontri informativi collegiali" (Codice 1)
DECLARE @SpeseIncontri decimal (10,2)
DECLARE @NumeroIncontri int

SET @SpeseIncontri = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
						PI.COD_TIPO_INVESTIMENTO = 1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL
						AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
															FROM CODIFICA_INVESTIMENTO
															WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
															AND CODICE = '1'))

--Priorita 72 (111 b) - numero Incontri informativi collegiali programmati (codifica 1))
SET @NumeroIncontri = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 72)

IF (@SpeseIncontri >  (250 * ISNULL(@NumeroIncontri,0))) SET @Result = 0
 
--------------------------------------------------------------------------------------------------------------

 -- 3. Spese per "Seminari informativi" (Codice 3)
DECLARE @SpeseSeminari decimal (10,2)
DECLARE @NumeroSeminari int

SET @SpeseSeminari = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
						PI.COD_TIPO_INVESTIMENTO = 1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL
						AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
															FROM CODIFICA_INVESTIMENTO
															WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
															AND CODICE = '3'))

-- Priorita 74 (111 b) - numero Seminari Informativi  programmati (codifica 3))
SET @NumeroSeminari = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 74)

IF (@SpeseSeminari >  (1000 * ISNULL(@NumeroSeminari,0))) SET @Result = 0

 
--------------------------------------------------------------------------------------------------------------

-- 4. Spese per "Visite guidate" (Codice 4)
DECLARE @SpeseVisite decimal (10,2)
DECLARE @NumeroVisite int

SET @SpeseVisite = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
						PI.COD_TIPO_INVESTIMENTO = 1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL
						AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
															FROM CODIFICA_INVESTIMENTO
															WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
															AND CODICE = '4'))


-- Priorita 75 (111 b) - numero Visite guidate, campi dimostrativi, Open day programmati (codifica 4))
SET @NumeroVisite = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 75)

IF (@SpeseVisite >  (2000 * ISNULL(@NumeroVisite,0))) SET @Result = 0
 
--------------------------------------------------------------------------------------------------------------

-- 9. Spese per "Pubblicazioni specialistiche, bollettini, newsletter" (Codice 9)
DECLARE @SpesePubblicazioni decimal (10,2)
DECLARE @NumeroPubblicazioni int, 
					@ID_BANDO INT

SET @SpesePubblicazioni = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
							FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
							PI.COD_TIPO_INVESTIMENTO = 1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL
							AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
																FROM CODIFICA_INVESTIMENTO
																WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
																AND CODICE = '9'))

-- Priorita 80 (111 b) - numero Pubblicazioni specialistiche, bollettini, newsletter programmati (codifica 9))
SET @NumeroPubblicazioni = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 80)
 
 IF (@SpesePubblicazioni > (2000 * ISNULL(@NumeroPubblicazioni,0))) SET @Result = 0 
 

SELECT @Result AS RESULT


END
