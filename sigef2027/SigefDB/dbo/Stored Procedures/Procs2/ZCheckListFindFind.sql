CREATE PROCEDURE [dbo].[ZCheckListFindFind]
(
	@Descrizionelikethis VARCHAR(255), 
	@FlagTemplateequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CHECK_LIST, DESCRIZIONE, FLAG_TEMPLATE, DATA_MODIFICA, OPERATORE FROM CHECK_LIST WHERE 1=1';
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)'; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	set @sql = @sql + 'ORDER BY ID_CHECK_LIST';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Descrizionelikethis VARCHAR(255), @FlagTemplateequalthis BIT',@Descrizionelikethis , @FlagTemplateequalthis ;
	else
		SELECT ID_CHECK_LIST, DESCRIZIONE, FLAG_TEMPLATE, DATA_MODIFICA, OPERATORE
		FROM CHECK_LIST
		WHERE 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis)
		ORDER BY ID_CHECK_LIST

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'





CREATE PROCEDURE [dbo].[ZChecklistFindFind]
(
	@ID_CHECK_LISTEQUALTHIS INT
)
AS
	SELECT * 
	FROM CHECK_LIST
	WHERE 
		((@ID_CHECK_LISTEQUALTHIS IS NULL) OR ID_CHECK_LIST = @ID_CHECK_LISTEQUALTHIS)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListFindFind';

