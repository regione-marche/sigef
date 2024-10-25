CREATE PROCEDURE [dbo].[ZControlliParametriDiRischioFindFind]
(
	@IdParametroequalthis INT, 
	@Manualeequalthis BIT, 
	@Descrizionelikethis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PARAMETRO, DESCRIZIONE, MANUALE, QUERY_SQL, PESO FROM CONTROLLI_PARAMETRI_DI_RISCHIO WHERE 1=1';
	IF (@IdParametroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PARAMETRO = @IdParametroequalthis)'; set @lensql=@lensql+len(@IdParametroequalthis);end;
	IF (@Manualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MANUALE = @Manualeequalthis)'; set @lensql=@lensql+len(@Manualeequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdParametroequalthis INT, @Manualeequalthis BIT, @Descrizionelikethis VARCHAR(500)',@IdParametroequalthis , @Manualeequalthis , @Descrizionelikethis ;
	else
		SELECT ID_PARAMETRO, DESCRIZIONE, MANUALE, QUERY_SQL, PESO
		FROM CONTROLLI_PARAMETRI_DI_RISCHIO
		WHERE 
			((@IdParametroequalthis IS NULL) OR ID_PARAMETRO = @IdParametroequalthis) AND 
			((@Manualeequalthis IS NULL) OR MANUALE = @Manualeequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriDiRischioFindFind';

