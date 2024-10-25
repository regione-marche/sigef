CREATE PROCEDURE [dbo].[ZCatastoTerreniFindFind]
(
	@IdCatastoequalthis INT, 
	@IdComuneequalthis INT, 
	@FoglioCatastaleequalthis VARCHAR(255), 
	@Particellaequalthis VARCHAR(255), 
	@Sezioneequalthis VARCHAR(255), 
	@Subalternoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CATASTO, ID_COMUNE, FOGLIO_CATASTALE, PARTICELLA, SEZIONE, SUBALTERNO, SUPERFICIE_CATASTALE, SVANTAGGIO, COD_BELFIORE, DENOMINAZIONE, SIGLA, CAP, TIPO_AREA, PROVINCIA, REGIONE FROM vCATASTO WHERE 1=1';
	IF (@IdCatastoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CATASTO = @IdCatastoequalthis)'; set @lensql=@lensql+len(@IdCatastoequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@FoglioCatastaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FOGLIO_CATASTALE = @FoglioCatastaleequalthis)'; set @lensql=@lensql+len(@FoglioCatastaleequalthis);end;
	IF (@Particellaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PARTICELLA = @Particellaequalthis)'; set @lensql=@lensql+len(@Particellaequalthis);end;
	IF (@Sezioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEZIONE = @Sezioneequalthis)'; set @lensql=@lensql+len(@Sezioneequalthis);end;
	IF (@Subalternoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SUBALTERNO = @Subalternoequalthis)'; set @lensql=@lensql+len(@Subalternoequalthis);end;
	set @sql = @sql + 'ORDER BY DENOMINAZIONE, FOGLIO_CATASTALE, PARTICELLA';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCatastoequalthis INT, @IdComuneequalthis INT, @FoglioCatastaleequalthis VARCHAR(255), @Particellaequalthis VARCHAR(255), @Sezioneequalthis VARCHAR(255), @Subalternoequalthis VARCHAR(255)',@IdCatastoequalthis , @IdComuneequalthis , @FoglioCatastaleequalthis , @Particellaequalthis , @Sezioneequalthis , @Subalternoequalthis ;
	else
		SELECT ID_CATASTO, ID_COMUNE, FOGLIO_CATASTALE, PARTICELLA, SEZIONE, SUBALTERNO, SUPERFICIE_CATASTALE, SVANTAGGIO, COD_BELFIORE, DENOMINAZIONE, SIGLA, CAP, TIPO_AREA, PROVINCIA, REGIONE
		FROM vCATASTO
		WHERE 
			((@IdCatastoequalthis IS NULL) OR ID_CATASTO = @IdCatastoequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@FoglioCatastaleequalthis IS NULL) OR FOGLIO_CATASTALE = @FoglioCatastaleequalthis) AND 
			((@Particellaequalthis IS NULL) OR PARTICELLA = @Particellaequalthis) AND 
			((@Sezioneequalthis IS NULL) OR SEZIONE = @Sezioneequalthis) AND 
			((@Subalternoequalthis IS NULL) OR SUBALTERNO = @Subalternoequalthis)
		ORDER BY DENOMINAZIONE, FOGLIO_CATASTALE, PARTICELLA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCatastoTerreniFindFind';

