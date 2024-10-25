CREATE PROCEDURE [dbo].[ZControlliParametriDiRischioFindSelect]
(
	@IdParametroequalthis INT, 
	@Descrizioneequalthis VARCHAR(500), 
	@Manualeequalthis BIT, 
	@QuerySqlequalthis VARCHAR(3000), 
	@Pesoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PARAMETRO, DESCRIZIONE, MANUALE, QUERY_SQL, PESO FROM CONTROLLI_PARAMETRI_DI_RISCHIO WHERE 1=1';
	IF (@IdParametroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PARAMETRO = @IdParametroequalthis)'; set @lensql=@lensql+len(@IdParametroequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Manualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MANUALE = @Manualeequalthis)'; set @lensql=@lensql+len(@Manualeequalthis);end;
	IF (@QuerySqlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_SQL = @QuerySqlequalthis)'; set @lensql=@lensql+len(@QuerySqlequalthis);end;
	IF (@Pesoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PESO = @Pesoequalthis)'; set @lensql=@lensql+len(@Pesoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdParametroequalthis INT, @Descrizioneequalthis VARCHAR(500), @Manualeequalthis BIT, @QuerySqlequalthis VARCHAR(3000), @Pesoequalthis INT',@IdParametroequalthis , @Descrizioneequalthis , @Manualeequalthis , @QuerySqlequalthis , @Pesoequalthis ;
	else
		SELECT ID_PARAMETRO, DESCRIZIONE, MANUALE, QUERY_SQL, PESO
		FROM CONTROLLI_PARAMETRI_DI_RISCHIO
		WHERE 
			((@IdParametroequalthis IS NULL) OR ID_PARAMETRO = @IdParametroequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Manualeequalthis IS NULL) OR MANUALE = @Manualeequalthis) AND 
			((@QuerySqlequalthis IS NULL) OR QUERY_SQL = @QuerySqlequalthis) AND 
			((@Pesoequalthis IS NULL) OR PESO = @Pesoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriDiRischioFindSelect';

