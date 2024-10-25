﻿CREATE PROCEDURE [dbo].[calcoloStep121_4]
@IdProgetto int
AS
BEGIN

--  121 - verifica % spese tecniche per fasce di spesa di investimento:
-- SERVE per fasi successive a Presentazione
 
--  < 200.000,00 € -> 10%  
--  >= 200.000,00 € e < 500.000,00 € -> 6%  
--  >= 500.000,00 € -> 3%

--UPDATE PIANO_INVESTIMENTI SET SPESE_GENERALI = COSTO_INVESTIMENTO * 0.1
--WHERE ID_INVESTIMENTO IN ( SELECT DISTINCT ID_INVESTIMENTO
--						   FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
--						   WHERE I.ID_INVESTIMENTO_ORIGINALE IS NULL AND I.COD_TIPO_INVESTIMENTO = 1 AND
--						   (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
--                           AND I.COSTO_INVESTIMENTO < 200000 )
--
--
--UPDATE PIANO_INVESTIMENTI SET SPESE_GENERALI = COSTO_INVESTIMENTO * 0.06
--WHERE ID_INVESTIMENTO IN ( SELECT DISTINCT ID_INVESTIMENTO
--						   FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
--						   WHERE I.ID_INVESTIMENTO_ORIGINALE IS NULL AND I.COD_TIPO_INVESTIMENTO = 1 AND
--						   (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
--                           AND (I.COSTO_INVESTIMENTO >= 200000 AND I.COSTO_INVESTIMENTO < 500000) )
--
--
--UPDATE PIANO_INVESTIMENTI SET SPESE_GENERALI = COSTO_INVESTIMENTO * 0.03
--WHERE ID_INVESTIMENTO IN ( SELECT DISTINCT ID_INVESTIMENTO
--						   FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
--						   WHERE I.ID_INVESTIMENTO_ORIGINALE IS NULL AND I.COD_TIPO_INVESTIMENTO = 1 AND
--						   (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
--                           AND I.COSTO_INVESTIMENTO >= 500000 )
--
--SELECT 1 AS RESULT


-- Nella checklist presentazione la condizione da verificare è la seguente:
-- Tutti gli investimenti ad eccezione di MACCHINE, ATTREZZATURE MOBILI E MATERIALI <= 200.000,00 € -> SI

DECLARE @Count int
SET @Count = (SELECT COUNT(ID_INVESTIMENTO)
		      FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
		      WHERE I.ID_INVESTIMENTO_ORIGINALE IS NULL AND I.COD_TIPO_INVESTIMENTO = 1 
			  AND (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)
			  AND ID_CODIFICA_INVESTIMENTO <> 35 AND ID_CODIFICA_INVESTIMENTO <> 240 -- Bando 121
			  AND ID_CODIFICA_INVESTIMENTO <> 140 -- Bando 121 (zucchero)
              AND COSTO_INVESTIMENTO > 200000 -- Investimenti che superano i 200000
             )

IF (@Count > 0) SELECT 0 AS RESULT
ELSE SELECT 1 AS RESULT



	
END
