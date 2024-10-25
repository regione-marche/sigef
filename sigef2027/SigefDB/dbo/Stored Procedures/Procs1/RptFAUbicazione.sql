create PROCEDURE [dbo].[RptFAUbicazione]
@IdFascicolo int	
AS
BEGIN	
	
	--DECLARE @IdFascicolo INT
	--SET @IdFascicolo = 75

	
	SELECT TERRITORIO.Id_Fascicolo, 
       dbo.MqAEttari((Select sum(superficie_catastale) as territorio_vantaggio 
			from (select Distinct(territorio.id_catasto) from TERRITORIO 
			where  TERRITORIO.id_fascicolo =@IdFascicolo) as terr 
			inner join vcatasto on vcatasto.id_catasto = terr.id_catasto 
			where vcatasto.id_catasto is not null and vcatasto.svantaggio is  null ))as NON_Svantaggiato, 
       dbo.MqAEttari((Select sum(superficie_catastale) as territorio_svantaggiato 
			from (select Distinct(territorio.id_catasto) from TERRITORIO 
			where  TERRITORIO.id_fascicolo =@IdFascicolo) as terr 
			inner join vcatasto on vcatasto.id_catasto = terr.id_catasto 
			where vcatasto.id_catasto is not null and vcatasto.svantaggio is not null )) as Svantaggiato, 
       dbo.MqAEttari((Select sum(superficie_catastale) as territorio_irriguo 
			from (select Distinct territorio.id_catasto,flag_iRRIGUO  from TERRITORIO 
			where  TERRITORIO.id_fascicolo =@IdFascicolo) as terr 
			inner join vcatasto on vcatasto.id_catasto = terr.id_catasto where terr.FLAG_IRRIGUO =1 )) as Irriguo,
       dbo.MqAEttari((Select Sum(superficie_catastale) 
			from (select Distinct(territorio.id_catasto) from TERRITORIO 
			where TERRITORIO.id_fascicolo =@IdFascicolo) as terr 
			inner join vcatasto on vcatasto.id_catasto = Terr.id_catasto )) as Totale
    FROM TERRITORIO 
    where  TERRITORIO.Id_fascicolo =@IdFascicolo
    group by TERRITORIO.Id_fascicolo
	
END
