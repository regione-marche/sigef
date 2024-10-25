CREATE PROCEDURE [dbo].[calcoloStepVariante124_1]
 @ID_VARIANTE  int
AS
BEGIN

--    124 - Costo massimo unitario per codifica

DECLARE @Result int
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
DECLARE @ID_BANDO INT , @IdProgetto INT 
SELECT @ID_BANDO = ID_BANDO, @IdProgetto=P.ID_PROGETTO FROM PROGETTO P INNER JOIN VARIANTI V ON V.ID_PROGETTO = P.ID_PROGETTO WHERE ID_VARIANTE = @ID_VARIANTE

-- 1. Incontri informativi collegiali
DECLARE @SpeseIncontri  decimal (10,2)
DECLARE @NumeroIncontri int
 
 
SET @SpeseIncontri  = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_CODIFICA_INVESTIMENTO = pi.ID_CODIFICA_INVESTIMENTO and d.ID_DETTAGLIO_INVESTIMENTO = pi.ID_DETTAGLIO_INVESTIMENTO 
						WHERE PI.COD_TIPO_INVESTIMENTO = 1 AND PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A' 
							  AND COD_DETTAGLIO  = '5') 
--Priorita  393
SET @NumeroIncontri = (SELECT ISNULL( PP.VALORE ,0)FROM PRIORITA_X_PROGETTO PP WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 393)
IF (@SpeseIncontri > (200 * ISNULL(@NumeroIncontri,0))) SET @Result = 0
 
 --------------------------------------------------------------------------------------------------------------
 --Seminari informativi

DECLARE @SpeseSeminari decimal (10,2)
DECLARE @NumeroSeminari int
 
SET @SpeseSeminari  = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_CODIFICA_INVESTIMENTO = pi.ID_CODIFICA_INVESTIMENTO and d.ID_DETTAGLIO_INVESTIMENTO = pi.ID_DETTAGLIO_INVESTIMENTO 
						WHERE PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A'  AND PI.COD_TIPO_INVESTIMENTO = 1
							 AND  COD_DETTAGLIO= '6') 
--Priorita  394
SET @NumeroSeminari = (SELECT ISNULL( PP.VALORE ,0)FROM PRIORITA_X_PROGETTO PP WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 394)
IF (@SpeseSeminari > (800 * ISNULL(@NumeroSeminari,0))) SET @Result = 0

 --------------------------------------------------------------------------------------------------------------
 -- Visite guidate, campi dimostrativi, Open day

DECLARE @SpeseVisite decimal (10,2)
DECLARE @NumeroVisite  int
 
SET @SpeseVisite  = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_CODIFICA_INVESTIMENTO = pi.ID_CODIFICA_INVESTIMENTO and d.ID_DETTAGLIO_INVESTIMENTO = pi.ID_DETTAGLIO_INVESTIMENTO 
						WHERE PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A'  AND PI.COD_TIPO_INVESTIMENTO = 1
 							AND COD_DETTAGLIO  = '7') 
--Priorita  394
SET @NumeroVisite = (SELECT ISNULL( PP.VALORE ,0)FROM PRIORITA_X_PROGETTO PP WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 395)
IF (@SpeseVisite > (1500 * ISNULL(@NumeroVisite,0))) SET @Result = 0
--------------------------------------------------------------------------------------------------------------
 --  Pubblicazioni

DECLARE @SpeseVisiteGui decimal (10,2)
DECLARE @NumeroVisiteGui   int
SET @SpeseVisiteGui  = ( SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
						FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
							INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_CODIFICA_INVESTIMENTO = pi.ID_CODIFICA_INVESTIMENTO and d.ID_DETTAGLIO_INVESTIMENTO = pi.ID_DETTAGLIO_INVESTIMENTO 
						WHERE  PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A' AND PI.COD_TIPO_INVESTIMENTO = 1  
 						AND COD_DETTAGLIO  = '8')
--Priorita  396
SET @NumeroVisiteGui = (SELECT ISNULL( PP.VALORE ,0)FROM PRIORITA_X_PROGETTO PP WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 396)
IF (@SpeseVisiteGui > (1500 * ISNULL(@NumeroVisiteGui,0))) SET @Result = 0
SELECT @Result AS RESULT
END
