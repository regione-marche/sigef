CREATE PROCEDURE [dbo].[ZSchedaValutazioneFindSelect]
(
	@IdSchedaValutazioneequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@FlagTemplateequalthis BIT, 
	@ValoreMaxequalthis DECIMAL(10,2), 
	@ValoreMinequalthis DECIMAL(10,2), 
	@ParoleChiaveequalthis VARCHAR(50), 
	@DataModificaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, VALORE_MAX, VALORE_MIN, PAROLE_CHIAVE, DATA_MODIFICA FROM SCHEDA_VALUTAZIONE WHERE 1=1';
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)'; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)'; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	IF (@ValoreMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_MAX = @ValoreMaxequalthis)'; set @lensql=@lensql+len(@ValoreMaxequalthis);end;
	IF (@ValoreMinequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_MIN = @ValoreMinequalthis)'; set @lensql=@lensql+len(@ValoreMinequalthis);end;
	IF (@ParoleChiaveequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PAROLE_CHIAVE = @ParoleChiaveequalthis)'; set @lensql=@lensql+len(@ParoleChiaveequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSchedaValutazioneequalthis INT, @Descrizioneequalthis VARCHAR(255), @FlagTemplateequalthis BIT, @ValoreMaxequalthis DECIMAL(10,2), @ValoreMinequalthis DECIMAL(10,2), @ParoleChiaveequalthis VARCHAR(50), @DataModificaequalthis DATETIME',@IdSchedaValutazioneequalthis , @Descrizioneequalthis , @FlagTemplateequalthis , @ValoreMaxequalthis , @ValoreMinequalthis , @ParoleChiaveequalthis , @DataModificaequalthis ;
	else
		SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, VALORE_MAX, VALORE_MIN, PAROLE_CHIAVE, DATA_MODIFICA
		FROM SCHEDA_VALUTAZIONE
		WHERE 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis) AND 
			((@ValoreMaxequalthis IS NULL) OR VALORE_MAX = @ValoreMaxequalthis) AND 
			((@ValoreMinequalthis IS NULL) OR VALORE_MIN = @ValoreMinequalthis) AND 
			((@ParoleChiaveequalthis IS NULL) OR PAROLE_CHIAVE = @ParoleChiaveequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZSchedaValutazioneFindSelect]
(
	@IdSchedaValutazioneequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@FlagTemplateequalthis BIT, 
	@ValoreMaxequalthis DECIMAL(10,2), 
	@ValoreMinequalthis DECIMAL(10,2), 
	@ParoleChiaveequalthis VARCHAR(50), 
	@DataModificaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, VALORE_MAX, VALORE_MIN, PAROLE_CHIAVE, DATA_MODIFICA FROM SCHEDA_VALUTAZIONE WHERE 1=1'';
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)''; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@FlagTemplateequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_TEMPLATE = @FlagTemplateequalthis)''; set @lensql=@lensql+len(@FlagTemplateequalthis);end;
	IF (@ValoreMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE_MAX = @ValoreMaxequalthis)''; set @lensql=@lensql+len(@ValoreMaxequalthis);end;
	IF (@ValoreMinequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE_MIN = @ValoreMinequalthis)''; set @lensql=@lensql+len(@ValoreMinequalthis);end;
	IF (@ParoleChiaveequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PAROLE_CHIAVE = @ParoleChiaveequalthis)''; set @lensql=@lensql+len(@ParoleChiaveequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_MODIFICA = @DataModificaequalthis)''; set @lensql=@lensql+len(@DataModificaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdSchedaValutazioneequalthis INT, @Descrizioneequalthis VARCHAR(255), @FlagTemplateequalthis BIT, @ValoreMaxequalthis DECIMAL(10,2), @ValoreMinequalthis DECIMAL(10,2), @ParoleChiaveequalthis VARCHAR(50), @DataModificaequalthis DATETIME'',@IdSchedaValutazioneequalthis , @Descrizioneequalthis , @FlagTemplateequalthis , @ValoreMaxequalthis , @ValoreMinequalthis , @ParoleChiaveequalthis , @DataModificaequalthis ;
	else
		SELECT ID_SCHEDA_VALUTAZIONE, DESCRIZIONE, FLAG_TEMPLATE, VALORE_MAX, VALORE_MIN, PAROLE_CHIAVE, DATA_MODIFICA
		FROM SCHEDA_VALUTAZIONE
		WHERE 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@FlagTemplateequalthis IS NULL) OR FLAG_TEMPLATE = @FlagTemplateequalthis) AND 
			((@ValoreMaxequalthis IS NULL) OR VALORE_MAX = @ValoreMaxequalthis) AND 
			((@ValoreMinequalthis IS NULL) OR VALORE_MIN = @ValoreMinequalthis) AND 
			((@ParoleChiaveequalthis IS NULL) OR PAROLE_CHIAVE = @ParoleChiaveequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSchedaValutazioneFindSelect';

