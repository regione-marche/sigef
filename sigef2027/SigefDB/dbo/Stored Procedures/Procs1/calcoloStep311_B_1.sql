﻿CREATE PROCEDURE [dbo].[calcoloStep311_B_1]
@IdProgetto int
AS
BEGIN

-- 165 -  70% bacino Bieticolo
DECLARE @result int
DECLARE @QUANTITA_PROPRIA decimal(10,2)
DECLARE @VALORE_DA_ACCORDI decimal(10,2)

DECLARE PRODOTTO CURSOR FOR
SELECT isnull(SUM(QUANTITA_PROPRIA+QUANTITA_EXTRA),0) AS QUANTITA_PROPRIA, isnull(SUM(QUANTITA_DA_BACINO_BIETICOLO+QUANTITA_PROPRIA),0) AS QUANTITA_DA_BACINO_BIETICOLO
FROM PRODOTTI_VENDITE 
WHERE ID_PROGETTO=@IdProgetto  AND MATERIA_PRIMA=1
GROUP BY ANNO

SET @result =1 -- PONGO LO STEP VERIFICATO

OPEN PRODOTTO
 
		FETCH NEXT FROM PRODOTTO INTO @QUANTITA_PROPRIA, @VALORE_DA_ACCORDI
		WHILE @@FETCH_STATUS=0 BEGIN
			
				IF  (@VALORE_DA_ACCORDI< (@QUANTITA_PROPRIA*0.7 ))
					BEGIN
					SET @result=0;
					BREAK

					END			
				FETCH NEXT FROM PRODOTTO INTO @QUANTITA_PROPRIA, @VALORE_DA_ACCORDI
		END
		CLOSE PRODOTTO
		DEALLOCATE PRODOTTO

 

SELECT @result AS RESULT

END