﻿CREATE PROCEDURE [dbo].[calcoloStep12_1 ]
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0 
AS
BEGIN

--  % SPESE TECNICHE RISPETTO AD a+ b

--declare @IdProgetto int = 10353, @FASE_ISTRUTTORIA int =0

DECLARE @Result int, @COSTO_A_B DECIMAL(18,2),@SPESE_TECNICHE DECIMAL(18,2)
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
DECLARE @ID_BANDO INT 
SELECT @ID_BANDO= ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto


---controllo corretta imputazione codifica --> programmazione

declare @A_GESTIONE INT , @B_SPAZI INT

SELECT @A_GESTIONE= COUNT(*) 
FROM PIANO_INVESTIMENTI INV 
INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = INV.ID_CODIFICA_INVESTIMENTO
WHERE ID_BANDO = @ID_BANDO AND CODICE  IN ('a') AND ID_PROGRAMMAZIONE = 323 AND INV.ID_PROGETTO =@IdProgetto AND 
	((@FASE_ISTRUTTORIA=0 AND INV.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
		OR(@FASE_ISTRUTTORIA=1 AND INV.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NOT NULL ))

IF(@A_GESTIONE > 0) SET @Result = 0
ELSE BEGIN  
	SELECT @COSTO_A_B = SUM(ISNULL(inv.COSTO_INVESTIMENTO, 0))
	FROM PIANO_INVESTIMENTI INV 
			INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = INV.ID_CODIFICA_INVESTIMENTO
			INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_CODIFICA_INVESTIMENTO = C.ID_CODIFICA_INVESTIMENTO
	WHERE ID_BANDO = @ID_BANDO AND COD_DETTAGLIO IN ('b1','b2')AND INV.ID_PROGETTO =@IdProgetto AND 
		((@FASE_ISTRUTTORIA=0 AND INV.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
			OR(@FASE_ISTRUTTORIA=1 AND INV.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NOT NULL ))

	SELECT @SPESE_TECNICHE = SUM(ISNULL(inv.COSTO_INVESTIMENTO, 0))
	FROM PIANO_INVESTIMENTI INV 
			INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = INV.ID_CODIFICA_INVESTIMENTO
			INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_CODIFICA_INVESTIMENTO = C.ID_CODIFICA_INVESTIMENTO
	WHERE ID_BANDO = @ID_BANDO AND COD_DETTAGLIO IN ('b1','b2')AND INV.ID_PROGETTO =@IdProgetto AND 
		((@FASE_ISTRUTTORIA=0 AND INV.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
			OR(@FASE_ISTRUTTORIA=1 AND INV.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NOT NULL ))

			 
	IF(@SPESE_TECNICHE > @COSTO_A_B* 10/100 ) SET @Result = 0
	ELSE SET @Result = 1

END
SELECT @Result AS RESULT

END