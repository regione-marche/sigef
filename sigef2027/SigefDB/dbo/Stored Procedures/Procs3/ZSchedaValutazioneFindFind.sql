CREATE PROCEDURE [dbo].[ZSchedaValutazioneFindFind]
(
	@IdSchedaValutazioneequalthis INT, 
	@FlagTemplateequalthis BIT, 
	@Descrizionelikethis VARCHAR(255), 
	@ParoleChiavelikethis VARCHAR(50)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, VALORE_MAX, VALORE_MIN, PAROLE_CHIAVE, DATA_MODIFICA FROM SCHEDA_VALUTAZIONE WHERE 1=1';
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)'; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)'; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@ParoleChiavelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PAROLE_CHIAVE LIKE @ParoleChiavelikethis)'; set @lensql=@lensql+len(@ParoleChiavelikethis);end;
	set @sql = @sql + 'ORDER BY DATA_MODIFICA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSchedaValutazioneequalthis INT, @FlagTemplateequalthis BIT, @Descrizionelikethis VARCHAR(255), @ParoleChiavelikethis VARCHAR(50)',@IdSchedaValutazioneequalthis , @FlagTemplateequalthis , @Descrizionelikethis , @ParoleChiavelikethis ;
	else
		SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, VALORE_MAX, VALORE_MIN, PAROLE_CHIAVE, DATA_MODIFICA
		FROM SCHEDA_VALUTAZIONE
		WHERE 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@ParoleChiavelikethis IS NULL) OR PAROLE_CHIAVE LIKE @ParoleChiavelikethis)
		ORDER BY DATA_MODIFICA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZSchedaValutazioneFindFind]
(
	@IdSchedaValutazioneequalthis INT, 
	@FlagTemplateequalthis BIT, 
	@Descrizionelikethis VARCHAR(255), 
	@ParoleChiavelikethis VARCHAR(50)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, VALORE_MAX, VALORE_MIN, PAROLE_CHIAVE, DATA_MODIFICA FROM SCHEDA_VALUTAZIONE WHERE 1=1'';
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)''; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)''; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE LIKE @Descrizionelikethis)''; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@ParoleChiavelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PAROLE_CHIAVE LIKE @ParoleChiavelikethis)''; set @lensql=@lensql+len(@ParoleChiavelikethis);end;
	set @sql = @sql + ''ORDER BY DATA_MODIFICA DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdSchedaValutazioneequalthis INT, @FlagTemplateequalthis BIT, @Descrizionelikethis VARCHAR(255), @ParoleChiavelikethis VARCHAR(50)'',@IdSchedaValutazioneequalthis , @FlagTemplateequalthis , @Descrizionelikethis , @ParoleChiavelikethis ;
	else
		SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, VALORE_MAX, VALORE_MIN, PAROLE_CHIAVE, DATA_MODIFICA
		FROM SCHEDA_VALUTAZIONE
		WHERE 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@ParoleChiavelikethis IS NULL) OR PAROLE_CHIAVE LIKE @ParoleChiavelikethis)
		ORDER BY DATA_MODIFICA DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaValutazioneFindFind';

