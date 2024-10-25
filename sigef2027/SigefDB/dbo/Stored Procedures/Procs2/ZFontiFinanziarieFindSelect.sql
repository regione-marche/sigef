CREATE PROCEDURE [dbo].[ZFontiFinanziarieFindSelect]
(
	@IdFonteequalthis INT, 
	@Percentualeequalthis DECIMAL(10,3), 
	@Descrizioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FONTE, PERCENTUALE, DESCRIZIONE FROM FONTI_FINANZIARIE WHERE 1=1';
	IF (@IdFonteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FONTE = @IdFonteequalthis)'; set @lensql=@lensql+len(@IdFonteequalthis);end;
	IF (@Percentualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PERCENTUALE = @Percentualeequalthis)'; set @lensql=@lensql+len(@Percentualeequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdFonteequalthis INT, @Percentualeequalthis DECIMAL(10,3), @Descrizioneequalthis VARCHAR(255)',@IdFonteequalthis , @Percentualeequalthis , @Descrizioneequalthis ;
	else
		SELECT ID_FONTE, PERCENTUALE, DESCRIZIONE
		FROM FONTI_FINANZIARIE
		WHERE 
			((@IdFonteequalthis IS NULL) OR ID_FONTE = @IdFonteequalthis) AND 
			((@Percentualeequalthis IS NULL) OR PERCENTUALE = @Percentualeequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFontiFinanziarieFindSelect';

