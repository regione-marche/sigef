CREATE PROCEDURE ZVrnaEsitoVisureFindFind
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdRichiestaequalthis VARCHAR(255), 
	@TipoVisuraequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_PROGETTO, ID_IMPRESA, ID_RICHIESTA, TIPO_VISURA, CODICE_ESITO, DATA_AGGIORNAMENTO, CODICE_STATO_RICHIESTA FROM vRNA_ESITO_VISURE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RICHIESTA = @IdRichiestaequalthis)'; set @lensql=@lensql+len(@IdRichiestaequalthis);end;
	IF (@TipoVisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_VISURA = @TipoVisuraequalthis)'; set @lensql=@lensql+len(@TipoVisuraequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT, @IdRichiestaequalthis VARCHAR(255), @TipoVisuraequalthis VARCHAR(255)',@IdBandoequalthis , @IdProgettoequalthis , @IdImpresaequalthis , @IdRichiestaequalthis , @TipoVisuraequalthis ;
	else
		SELECT ID_BANDO, ID_PROGETTO, ID_IMPRESA, ID_RICHIESTA, TIPO_VISURA, CODICE_ESITO, DATA_AGGIORNAMENTO, CODICE_STATO_RICHIESTA
		FROM vRNA_ESITO_VISURE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdRichiestaequalthis IS NULL) OR ID_RICHIESTA = @IdRichiestaequalthis) AND 
			((@TipoVisuraequalthis IS NULL) OR TIPO_VISURA = @TipoVisuraequalthis)
		

GO