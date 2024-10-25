CREATE PROCEDURE [dbo].[ZControlliParametriXLottoFindFind]
(
	@IdLottoequalthis INT, 
	@IdParametroequalthis INT, 
	@Manualeequalthis BIT, 
	@Descrizionelikethis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_LOTTO, ID_PARAMETRO, PESO_REALE, DESCRIZIONE, QUERY_SQL, PESO, MANUALE FROM vCONTROLLI_PARAMETRI_X_LOTTO WHERE 1=1';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdParametroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PARAMETRO = @IdParametroequalthis)'; set @lensql=@lensql+len(@IdParametroequalthis);end;
	IF (@Manualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MANUALE = @Manualeequalthis)'; set @lensql=@lensql+len(@Manualeequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLottoequalthis INT, @IdParametroequalthis INT, @Manualeequalthis BIT, @Descrizionelikethis VARCHAR(500)',@IdLottoequalthis , @IdParametroequalthis , @Manualeequalthis , @Descrizionelikethis ;
	else
		SELECT ID_LOTTO, ID_PARAMETRO, PESO_REALE, DESCRIZIONE, QUERY_SQL, PESO, MANUALE
		FROM vCONTROLLI_PARAMETRI_X_LOTTO
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdParametroequalthis IS NULL) OR ID_PARAMETRO = @IdParametroequalthis) AND 
			((@Manualeequalthis IS NULL) OR MANUALE = @Manualeequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriXLottoFindFind';

