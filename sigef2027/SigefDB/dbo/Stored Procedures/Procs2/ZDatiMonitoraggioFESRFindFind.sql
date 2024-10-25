
--TEMA_PRIORITARIO, ID_ATECO, ATTIVITA_ECON, CPT_SETTORE, CUP_DIMENSIONE_TERR, CUP_NATURA


CREATE PROCEDURE [dbo].[ZDatiMonitoraggioFESRFindFind]
(
	@IdDatiMonitoraggioFESRequalthis INT, 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DATI_MONIT, ID_PROGETTO, CUP_CATEGORIA, CUP_CATEGORIA_SOGGETTO, TEMA_PRIORITARIO, ID_ATECO, ATTIVITA_ECON, CPT_SETTORE, CUP_DIMENSIONE_TERR, CUP_NATURA, CUP_CATEGORIA_TIPOOPER FROM DATI_MONITORAGGIO_FESR WHERE 1=1';
	IF (@IdDatiMonitoraggioFESRequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DATI_MONIT = @IdDatiMonitoraggioFESRequalthis)'; set @lensql=@lensql+len(@IdDatiMonitoraggioFESRequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
  	  exec sp_executesql @sql,N'@IdDatiMonitoraggioFESRequalthis INT, @IdProgettoequalthis INT',@IdDatiMonitoraggioFESRequalthis, @IdProgettoequalthis;
	else
		SELECT ID_DATI_MONIT, ID_PROGETTO, CUP_CATEGORIA, CUP_CATEGORIA_SOGGETTO, TEMA_PRIORITARIO, ID_ATECO, ATTIVITA_ECON, CPT_SETTORE, CUP_DIMENSIONE_TERR, CUP_NATURA, CUP_CATEGORIA_TIPOOPER
		FROM DATI_MONITORAGGIO_FESR
		WHERE 
			((@IdDatiMonitoraggioFESRequalthis IS NULL) OR ID_DATI_MONIT = @IdDatiMonitoraggioFESRequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) 


