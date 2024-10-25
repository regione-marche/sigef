CREATE PROCEDURE [dbo].[calcoloStep124_3]
@IdProgetto int,
@fase_istruttoria int =0
AS
BEGIN

--    124 - Costo massimo unitario per codifica

DECLARE @Result int
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------

-- 1. Incontri informativi collegiali


DECLARE @SpeseIncontri  decimal (10,2)
DECLARE @NumeroIncontri int
 
 
SET @SpeseIncontri  = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI 
							INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = PI.ID_CODIFICA_INVESTIMENTO 
								INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_CODIFICA_INVESTIMENTO = pi.ID_CODIFICA_INVESTIMENTO and d.ID_DETTAGLIO_INVESTIMENTO = pi.ID_DETTAGLIO_INVESTIMENTO 
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND PI.COD_TIPO_INVESTIMENTO = 1 AND
							((PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @fase_istruttoria=0) OR (PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL AND @fase_istruttoria=1))
							 and D.COD_DETTAGLIO = '5')
--Priorita  393
SET @NumeroIncontri = (SELECT ISNULL( PP.VALORE ,0)FROM PRIORITA_X_PROGETTO PP WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 393)
IF (@SpeseIncontri > (200 * ISNULL(@NumeroIncontri,0))) SET @Result = 0
 
 --------------------------------------------------------------------------------------------------------------
 --Seminari informativi

DECLARE @SpeseSeminari decimal (10,2)
DECLARE @NumeroSeminari int
 
SET @SpeseSeminari  = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI 
							INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = PI.ID_CODIFICA_INVESTIMENTO 
								INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_CODIFICA_INVESTIMENTO = pi.ID_CODIFICA_INVESTIMENTO and d.ID_DETTAGLIO_INVESTIMENTO = pi.ID_DETTAGLIO_INVESTIMENTO 
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND PI.COD_TIPO_INVESTIMENTO = 1 AND
							((PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @fase_istruttoria=0) OR (PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL AND @fase_istruttoria=1))
							 and D.COD_DETTAGLIO = '6')
--Priorita  394
SET @NumeroSeminari = (SELECT ISNULL( PP.VALORE ,0)FROM PRIORITA_X_PROGETTO PP WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 394)
IF (@SpeseSeminari > (800 * ISNULL(@NumeroSeminari,0))) SET @Result = 0

 --------------------------------------------------------------------------------------------------------------
 -- Visite guidate, campi dimostrativi, Open day

DECLARE @SpeseVisite decimal (10,2)
DECLARE @NumeroVisite  int
 
SET @SpeseVisite  = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI 
							INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = PI.ID_CODIFICA_INVESTIMENTO 
								INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_CODIFICA_INVESTIMENTO = pi.ID_CODIFICA_INVESTIMENTO and d.ID_DETTAGLIO_INVESTIMENTO = pi.ID_DETTAGLIO_INVESTIMENTO 
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND PI.COD_TIPO_INVESTIMENTO = 1 AND
							((PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @fase_istruttoria=0) OR (PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL AND @fase_istruttoria=1))
							 and D.COD_DETTAGLIO = '7')
--Priorita  394
SET @NumeroVisite = (SELECT ISNULL( PP.VALORE ,0)FROM PRIORITA_X_PROGETTO PP WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 395)
IF (@SpeseVisite > (1500 * ISNULL(@NumeroVisite,0))) SET @Result = 0
--------------------------------------------------------------------------------------------------------------
 -- Visite guidate, campi dimostrativi, Open day

DECLARE @SpeseVisiteGui decimal (10,2)
DECLARE @NumeroVisiteGui   int
SET @SpeseVisiteGui  = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI 
							INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = PI.ID_CODIFICA_INVESTIMENTO 
								INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_CODIFICA_INVESTIMENTO = pi.ID_CODIFICA_INVESTIMENTO and d.ID_DETTAGLIO_INVESTIMENTO = pi.ID_DETTAGLIO_INVESTIMENTO 
						WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND PI.COD_TIPO_INVESTIMENTO = 1 AND
							((PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @fase_istruttoria=0) OR (PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL AND @fase_istruttoria=1))
							 and D.COD_DETTAGLIO = '8')
--Priorita  396
SET @NumeroVisiteGui = (SELECT ISNULL( PP.VALORE ,0)FROM PRIORITA_X_PROGETTO PP WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 396)
IF (@SpeseVisiteGui > (1500 * ISNULL(@NumeroVisiteGui,0))) SET @Result = 0
SELECT @Result AS RESULT
END
