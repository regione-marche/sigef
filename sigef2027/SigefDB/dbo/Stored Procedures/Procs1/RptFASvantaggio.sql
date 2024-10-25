create PROCEDURE [dbo].[RptFASvantaggio]
@IdFascicolo int	
AS
BEGIN	
	
	--DECLARE @IdFascicolo INT
	--SET @IdFascicolo = 75

	SELECT Terr.SVANTAGGIO, dbo.MqAEttari(SUM(Terr.SUPERFICIE_CATASTALE)) AS Superficie,
             dbo.MqAEttari( (Select Sum(superficie_catastale) 
				from (select Distinct(territorio.id_catasto) 
					from TERRITORIO where  TERRITORIO.id_fascicolo =@IdFascicolo) as terr  
					inner join vcatasto on vcatasto.id_catasto = Terr.id_catasto )) as Totale
	FROM  (select Distinct vterritorio.id_catasto, SVANTAGGIO , SUPERFICIE_CATASTALE   
			from vTERRITORIO where  vTERRITORIO.id_fascicolo = @IdFascicolo AND SVANTAGGIO IS NOT NULL) as Terr 
	group by Terr.SVANTAGGIO
END
