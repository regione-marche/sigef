﻿CREATE PROCEDURE [dbo].[calcoloStep311_B_4]
@IdProgetto int
AS
BEGIN


DECLARE @result int
DECLARE @TOTALE_CONTRIBUTO decimal(18,2)
 
 DECLARE @COUNT INT

SET @result =1 -- PONGO LO STEP VERIFICATO 

SET @COUNT=(select count(*) from priorita_x_progetto where ID_PROGETTO= @IdProgetto AND (ID_PRIORITA =  141 or ID_PRIORITA =  144))

IF(@COUNT>0 )
	BEGIN
		SET @TOTALE_CONTRIBUTO = ( SELECT     SUM(PIANO_INVESTIMENTI.CONTRIBUTO_RICHIESTO) AS CONTRIBUTO_RICHIESTO
							FROM  PROGETTO INNER JOIN PIANO_INVESTIMENTI ON PROGETTO.ID_PROGETTO = PIANO_INVESTIMENTI.ID_PROGETTO 
							WHERE  PROGETTO.ID_PROGETTO= @IdProgetto AND PIANO_INVESTIMENTI.ID_INVESTIMENTO_ORIGINALE IS NULL  )

			IF(@TOTALE_CONTRIBUTO > 200000 )SET @result =0
	END

SELECT @result AS RESULT

END