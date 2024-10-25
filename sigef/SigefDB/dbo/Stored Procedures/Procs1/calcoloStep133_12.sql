﻿CREATE PROCEDURE [dbo].[calcoloStep133_12]
(
	@IdProgetto int,
	@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
-- CONTROLLO % SPESE PRODOTTO
 
DECLARE @RESULT INT  
		
--SET @IdProgetto = 9023
SET @RESULT =0 --PONGO LO STEP NON VERIFICATO
 
SELECT @RESULT= ISNULL(COUNT(*) ,0)
FROM (SELECT ((SUM(ISNULL( SPESE_PRODOTTO,0)) *100 ) / SUM(ISNULL(NULLIF( SPESE_TOTALI,0), 1)) )  AS C 
	  FROM (SELECT PXI.VALORE, 'SPESE_TOTALI' = CASE WHEN PI.CODICE NOT IN ('4','8','12','16')THEN  SUM(COSTO_INVESTIMENTO) END, 
								'SPESE_PRODOTTO' = CASE WHEN D.COD_DETTAGLIO='27' THEN  SUM(COSTO_INVESTIMENTO) END 
			FROM VPIANO_INVESTIMENTI AS PI 
				INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_DETTAGLIO_INVESTIMENTO = PI.ID_DETTAGLIO_INVESTIMENTO AND D.ID_CODIFICA_INVESTIMENTO= PI.ID_CODIFICA_INVESTIMENTO 
				INNER JOIN  PRIORITA_X_INVESTIMENTI PXI ON PI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND ID_PRIORITA = 858 
				INNER JOIN PROGETTO P ON P.ID_PROGETTO = PI.ID_PROGETTO  
			WHERE   P.ID_PROGETTO = @IdProgetto AND ((@FASE_ISTRUTTORIA =0 and ID_INVESTIMENTO_ORIGINALE  is null and ID_VARIANTE is null )
													 or (@FASE_ISTRUTTORIA =1 and id_investimento_originale  is not null and id_variante is null ))
			GROUP BY  PXI.VALORE, CODICE, COD_DETTAGLIO ) AS T 
	  GROUP BY VALORE HAVING ((SUM(ISNULL(SPESE_PRODOTTO,0)) *100 ) /  SUM(ISNULL(NULLIF( SPESE_TOTALI,0), 1)))>5) AS C 

SELECT @RESULT 
END
