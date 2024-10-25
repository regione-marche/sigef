create PROCEDURE [dbo].[RptFATipoArea]
@IdFascicolo int	
AS
BEGIN	
	
	--DECLARE @ID_ASSEGNAZIONE INT
	--SET @ID_ASSEGNAZIONE = 75
	
	SELECT TIPO_AREA, dbo.MqAEttari(SUM(Terr.SUPERFICIE_CATASTALE)) AS Superficie,
		dbo.MqAEttari((Select Sum(superficie_catastale) 
			FROM (select Distinct(territorio.id_catasto) from TERRITORIO where  TERRITORIO.id_fascicolo =@IdFascicolo) as terr  
			inner join vcatasto on vcatasto.id_catasto = Terr.id_catasto )) as Totale
	FROM (select Distinct vterritorio.id_catasto, TIPO_AREA , SUPERFICIE_CATASTALE   
		from vTERRITORIO where  vTERRITORIO.id_fascicolo =@IdFascicolo and TIPO_AREA IS NOT NULL) as Terr 
	group by TIPO_AREA
END
