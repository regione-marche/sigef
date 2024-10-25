CREATE PROCEDURE [dbo].[calcoloStep111_1]
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0 
AS
BEGIN

-- 111b) - Verifica spesa di investimento per codifica 
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
						PI.COD_TIPO_INVESTIMENTO = 1 AND ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
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

-- 2. Spese per "Convegni" (Codice 2)
DECLARE @SpeseConvegni decimal (10,2)
DECLARE @NumeroConvegni int

SET @SpeseConvegni = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
						PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
						AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
															FROM CODIFICA_INVESTIMENTO
															WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
															AND CODICE = '2'))

-- Priorita 73 (111 b) - numero Convegni programmati (codifica 2))
SET @NumeroConvegni = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 73)

IF (@SpeseConvegni > (5000 * ISNULL (@NumeroConvegni,0))) SET @Result = 0

--------------------------------------------------------------------------------------------------------------

-- 3. Spese per "Seminari informativi" (Codice 3)
DECLARE @SpeseSeminari decimal (10,2)
DECLARE @NumeroSeminari int

SET @SpeseSeminari = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
						PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
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
						PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
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

-- 5. Spese per "Viaggi di studio" (Codice 5)
DECLARE @SpeseViaggi decimal (10,2)
DECLARE @NumeroViaggi int

SET @SpeseViaggi = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
						PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
						AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
															FROM CODIFICA_INVESTIMENTO
															WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
															AND CODICE = '5'))

-- Priorita 76 (111 b) - numero Viaggi di studio programmati (codifica 5))
SET @NumeroViaggi = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 76)

IF (@SpeseViaggi >  (10000 * ISNULL(@NumeroViaggi,0))) SET @Result = 0

 
--------------------------------------------------------------------------------------------------------------

-- 6. Spese per "Workshop e scambi di buone pratiche" (Codice 6)
DECLARE @SpeseWorkshop decimal (10,2)
DECLARE @NumeroWorkshop int

SET @SpeseWorkshop = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
						PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
						AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
															FROM CODIFICA_INVESTIMENTO
															WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
															AND CODICE = '6'))

-- Priorita 77 (111 b) - numero Workshop e scambi di buone pratiche programmati (codifica 6))
SET @NumeroWorkshop = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 77)

IF (@SpeseWorkshop >  (2000 * ISNULL(@NumeroWorkshop,0))) SET @Result = 0

 
--------------------------------------------------------------------------------------------------------------

-- 7. Spese per "Organizzazione di fiere ed esposizioni" (Codice 7)
DECLARE @SpeseFiere decimal (10,2)
DECLARE @NumeroFiere int

SET @SpeseFiere = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
					FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
					WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
					PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
					AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
														FROM CODIFICA_INVESTIMENTO
														WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
														AND CODICE = '7'))

-- Priorita 78 (111 b) - numero Organizzazione di fiere ed esposizioni programmati (codifica 7))
SET @NumeroFiere = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 78)

IF (@SpeseFiere >  (10000 * ISNULL(@NumeroFiere,0))) SET @Result = 0
 
--------------------------------------------------------------------------------------------------------------

-- (111 b) - numero Partecipazione ad eventi, iniziative fieristiche, espositive ed informative programmati)

-- 8a. Iniziative in ambito regionale a cui partecipano 15 destinatari
DECLARE @Spese8a decimal (10,2)
DECLARE @Numero8a int

SET @Spese8a = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
							FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
							PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
							AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
																FROM CODIFICA_INVESTIMENTO
																WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
																AND CODICE = '8a'))

-- Priorita 83 (111 b)111 b) - numero Partecipazione ad eventi, iniziative fieristiche, in ambito regionale a cui partecipano 15 destinatari (codifica 8a)
SET @Numero8a = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 83)

IF (@Spese8a > (1500 * ISNULL(@Numero8a,0))) SET @Result = 0 

 
-- 8b. Iniziative nazionali extraregionali a cui partecipano 30 destinatari, anche su più giorni
DECLARE @Spese8b decimal (10,2)
DECLARE @Numero8b int

SET @Spese8b = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
							FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
							PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
							AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
																FROM CODIFICA_INVESTIMENTO
																WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
																AND CODICE = '8b'))

-- Priorita 84 (111 b) - numero Partecipazione ad eventi, iniziative fieristiche, in ambito nazionale extraregionale a cui partecipano 30 destinatari (codifica 8b)
SET @Numero8b = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 84)

IF (@Spese8b > (4000 * ISNULL(@Numero8b,0))) SET @Result = 0 
 
 

-- 8c. Manifestazioni internazionali nell` Unione Europea a cui partecipano 10 destinatari, anche su più giorni
DECLARE @Spese8c decimal (10,2)
DECLARE @Numero8c int

SET @Spese8c = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
							FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
							PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
							AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
																FROM CODIFICA_INVESTIMENTO
																WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
																AND CODICE = '8c'))

-- Priorita 85 111 b) - numero Partecipazione ad eventi, iniziative fieristiche, in ambito internazionale nell`Unione Europea a cui partecipano 10 destinatari (codifica 8c)
SET @Numero8c = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 85)

IF (@Spese8c > (6000 * ISNULL(@Numero8c,0))) SET @Result = 0 
 


--------------------------------------------------------------------------------------------------------------

-- 9. Spese per "Pubblicazioni specialistiche, bollettini, newsletter" (Codice 9)
DECLARE @SpesePubblicazioni decimal (10,2)
DECLARE @NumeroPubblicazioni int, 
					@ID_BANDO INT

SET @SpesePubblicazioni = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
							FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
							PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
							AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
																FROM CODIFICA_INVESTIMENTO
																WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
																AND CODICE = '9'))

-- Priorita 80 (111 b) - numero Pubblicazioni specialistiche, bollettini, newsletter programmati (codifica 9))
SET @NumeroPubblicazioni = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 80)
SET @ID_BANDO = ( SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto  )

-- MODIFICA PER IL BANDO 111 b - c  2010
IF(@ID_BANDO = 120) 
BEGIN 
		IF (@SpesePubblicazioni > (2500 * ISNULL(@NumeroPubblicazioni,0))) SET @Result = 0 
END
ELSE  IF (@SpesePubblicazioni > (2000 * ISNULL(@NumeroPubblicazioni,0))) SET @Result = 0 
 
 
--------------------------------------------------------------------------------------------------------------

-- 10. Spese per "Realizzazione di pagine web e forum multimediali" (Codice 10)
DECLARE @SpeseWeb decimal (10,2)
DECLARE @NumeroWeb int

SET @SpeseWeb = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
				FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
				WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND
				PI.COD_TIPO_INVESTIMENTO = 1 AND  ((@FASE_ISTRUTTORIA=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@FASE_ISTRUTTORIA=1 AND PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)) 
				AND PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO 
													FROM CODIFICA_INVESTIMENTO
													WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto)
													AND CODICE = '10'))

-- Priorita 81 (111 b) - numero Realizzazione di pagine web e forum multimediali programmati (codifica 10))
SET @NumeroWeb = (SELECT ISNULL( PP.VALORE ,0)
					   FROM PRIORITA_X_PROGETTO PP  
					   WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 81)

IF (@SpeseWeb > (8000 * ISNULL(@NumeroWeb,0))) SET @Result = 0 
 

--------------------------------------------------------------------------------------------------------------


SELECT @Result AS RESULT


END
