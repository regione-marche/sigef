﻿CREATE PROCEDURE [dbo].[RptFAConduzioneTerritorio] 
(
	@ID_FASCICOLO INT,
	@DATA DATETIME=null,
	@TIPO_UMA BIT=null
)
AS
BEGIN
	SET NOCOUNT ON;

DECLARE @TMP TABLE (COD_TIPO_CONDUZIONE INT, TIPO_CONDUZIONE VARCHAR(500), SUPERFICIE_CONDOTTA INT, TOTALE INT)
IF(@TIPO_UMA=1) 
	BEGIN
		INSERT INTO @TMP 
		EXEC DBO.SpRiepilogoFascicoloUma @ID_FASCICOLO, 'TIPO_CONDUZIONE_UMA', @DATA

		SELECT TIPO_CONDUZIONE, DBO.MqAEttari(SUPERFICIE_CONDOTTA) AS SUPERFICIE_CONDOTTA_HA, SUPERFICIE_CONDOTTA, TOTALE 
		FROM @TMP
	END
	ELSE
		INSERT INTO @TMP 
		EXEC SpGetFAConduzioneTerritorio @ID_FASCICOLO
	
	SELECT COD_TIPO_CONDUZIONE, TIPO_CONDUZIONE, dbo.MqAEttari(SUPERFICIE_CONDOTTA) AS SUPERFICIE_CONDOTTA, DBO.MqAEttari(TOTALE) AS TOTALE, 
	SUPERFICIE_CONDOTTA as SUPERFICIE_CONDOTTA_MQ, TOTALE AS TOTALE_MQ
	FROM @TMP
END