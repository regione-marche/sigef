﻿CREATE PROCEDURE [dbo].[RptSezioneE]
	@IdFascicolo INT 
AS
BEGIN

--DECLARE @IdFascicolo INT 
--SET @IdFascicolo = 88

SELECT  MAX(ID_TERRITORIO) AS ID_TERRITORIO,  vTERRITORIO.FOGLIO_CATASTALE, vTERRITORIO.PARTICELLA, vTERRITORIO.SEZIONE, vTERRITORIO.SUBALTERNO, 
                      COMUNI.SIGLA, COMUNI.CAP, SUBSTRING(COMUNI.ISTAT_LUNGO, 1, 3) AS ISTAT_PROVINCIA, 
                      SUBSTRING(COMUNI.ISTAT_LUNGO, 4, 6) AS ISTAT_COMUNE, vTERRITORIO.PROVINCIA, vTERRITORIO.TIPO_AREA, 
					  DBO.MqAEttari(SUM(ISNULL(vTERRITORIO.SUPERFICIE_CATASTALE, 0))) AS SUPERFICIE_CATASTALE,
					  DBO.MqAEttari(SUM(ISNULL(vTERRITORIO.SUPERFICIE_CONVENZIONALE, 0))) AS SUPERFICIE_CONVENZIONALE,
					  DBO.MqAEttari(SUM(ISNULL(vTERRITORIO.SUPERFICIE_BIOLOGICA, 0))) AS SUPERFICIE_BIOLOGICA, 
					  DBO.MqAEttari(SUM(ISNULL(vTERRITORIO.SUPERFICIE_CONVERSIONE, 0))) AS SUPERFICIE_CONVERSIONE, TIPO_CONDUZIONE, TIPO_CONTRATTO
FROM         vTERRITORIO INNER JOIN
                      COMUNI ON vTERRITORIO.ID_COMUNE = COMUNI.ID_COMUNE
WHERE     (vTERRITORIO.ID_FASCICOLO =  @IdFascicolo) 
GROUP BY vTERRITORIO.FOGLIO_CATASTALE, vTERRITORIO.PARTICELLA, vTERRITORIO.SEZIONE, vTERRITORIO.SUBALTERNO, 
                      vTERRITORIO.SUPERFICIE_CATASTALE, COMUNI.SIGLA, COMUNI.CAP, COMUNI.ISTAT_LUNGO, 
					  vTERRITORIO.PROVINCIA, vTERRITORIO.TIPO_AREA, TIPO_CONDUZIONE, TIPO_CONTRATTO,
					  COMUNE, FOGLIO_CATASTALE, PARTICELLA
ORDER BY COMUNE, FOGLIO_CATASTALE, PARTICELLA
END