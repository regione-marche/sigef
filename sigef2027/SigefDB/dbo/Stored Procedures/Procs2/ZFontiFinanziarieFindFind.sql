CREATE PROCEDURE [dbo].[ZFontiFinanziarieFindFind]
(
	@Descrizionelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FONTE, PERCENTUALE, DESCRIZIONE FROM FONTI_FINANZIARIE WHERE 1=1';
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @sql = @sql + 'ORDER BY DESCRIZIONE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Descrizionelikethis VARCHAR(255)',@Descrizionelikethis ;
	else
		SELECT ID_FONTE, PERCENTUALE, DESCRIZIONE
		FROM FONTI_FINANZIARIE
		WHERE 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis)
		ORDER BY DESCRIZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'





CREATE PROCEDURE [dbo].[ZFontifinanziarieFindFind]
(
	@ID_FONTEEQUALTHIS INT
)
AS
	SELECT * 
	FROM FONTI_FINANZIARIE
	WHERE 
		((@ID_FONTEEQUALTHIS IS NULL) OR ID_FONTE = @ID_FONTEEQUALTHIS)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFontiFinanziarieFindFind';

