CREATE PROCEDURE [dbo].[ZCheckListFindSelect]
(
	@IdCheckListequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@FlagTemplateequalthis BIT, 
	@DataModificaequalthis DATETIME, 
	@Operatoreequalthis CHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CHECK_LIST, DESCRIZIONE, FLAG_TEMPLATE, DATA_MODIFICA, OPERATORE FROM CHECK_LIST WHERE 1=1';
	IF (@IdCheckListequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECK_LIST = @IdCheckListequalthis)'; set @lensql=@lensql+len(@IdCheckListequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)'; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCheckListequalthis INT, @Descrizioneequalthis VARCHAR(255), @FlagTemplateequalthis BIT, @DataModificaequalthis DATETIME, @Operatoreequalthis CHAR(16)',@IdCheckListequalthis , @Descrizioneequalthis , @FlagTemplateequalthis , @DataModificaequalthis , @Operatoreequalthis ;
	else
		SELECT ID_CHECK_LIST, DESCRIZIONE, FLAG_TEMPLATE, DATA_MODIFICA, OPERATORE
		FROM CHECK_LIST
		WHERE 
			((@IdCheckListequalthis IS NULL) OR ID_CHECK_LIST = @IdCheckListequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListFindSelect';

