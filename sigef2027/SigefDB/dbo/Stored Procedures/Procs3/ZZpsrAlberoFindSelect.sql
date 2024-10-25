CREATE PROCEDURE [dbo].[ZZpsrAlberoFindSelect]
(
	@Codiceequalthis VARCHAR(255), 
	@CodPsrequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@Livelloequalthis INT, 
	@AttivazioneBandiequalthis BIT, 
	@AttivazioneFaequalthis BIT, 
	@AttivazioneObMisuraequalthis BIT, 
	@AttivazioneInvestimentiequalthis BIT, 
	@AttivazioneFfequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT CODICE, COD_PSR, DESCRIZIONE, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVAZIONE_INVESTIMENTI, ATTIVAZIONE_FF FROM zPSR_ALBERO WHERE 1=1';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LIVELLO = @Livelloequalthis)'; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@AttivazioneBandiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_BANDI = @AttivazioneBandiequalthis)'; set @lensql=@lensql+len(@AttivazioneBandiequalthis);end;
	IF (@AttivazioneFaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_FA = @AttivazioneFaequalthis)'; set @lensql=@lensql+len(@AttivazioneFaequalthis);end;
	IF (@AttivazioneObMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_OB_MISURA = @AttivazioneObMisuraequalthis)'; set @lensql=@lensql+len(@AttivazioneObMisuraequalthis);end;
	IF (@AttivazioneInvestimentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_INVESTIMENTI = @AttivazioneInvestimentiequalthis)'; set @lensql=@lensql+len(@AttivazioneInvestimentiequalthis);end;
	IF (@AttivazioneFfequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_FF = @AttivazioneFfequalthis)'; set @lensql=@lensql+len(@AttivazioneFfequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Codiceequalthis VARCHAR(255), @CodPsrequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @Livelloequalthis INT, @AttivazioneBandiequalthis BIT, @AttivazioneFaequalthis BIT, @AttivazioneObMisuraequalthis BIT, @AttivazioneInvestimentiequalthis BIT, @AttivazioneFfequalthis BIT',@Codiceequalthis , @CodPsrequalthis , @Descrizioneequalthis , @Livelloequalthis , @AttivazioneBandiequalthis , @AttivazioneFaequalthis , @AttivazioneObMisuraequalthis , @AttivazioneInvestimentiequalthis , @AttivazioneFfequalthis ;
	else
		SELECT CODICE, COD_PSR, DESCRIZIONE, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVAZIONE_INVESTIMENTI, ATTIVAZIONE_FF
		FROM zPSR_ALBERO
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@AttivazioneBandiequalthis IS NULL) OR ATTIVAZIONE_BANDI = @AttivazioneBandiequalthis) AND 
			((@AttivazioneFaequalthis IS NULL) OR ATTIVAZIONE_FA = @AttivazioneFaequalthis) AND 
			((@AttivazioneObMisuraequalthis IS NULL) OR ATTIVAZIONE_OB_MISURA = @AttivazioneObMisuraequalthis) AND 
			((@AttivazioneInvestimentiequalthis IS NULL) OR ATTIVAZIONE_INVESTIMENTI = @AttivazioneInvestimentiequalthis) AND 
			((@AttivazioneFfequalthis IS NULL) OR ATTIVAZIONE_FF = @AttivazioneFfequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZpsrAlberoFindSelect]
(
	@Codiceequalthis VARCHAR(255), 
	@CodPsrequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@Livelloequalthis INT, 
	@AttivazioneBandiequalthis BIT, 
	@AttivazioneFaequalthis BIT, 
	@AttivazioneObMisuraequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT CODICE, COD_PSR, DESCRIZIONE, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA FROM zPSR_ALBERO WHERE 1=1'';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE = @Codiceequalthis)''; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_PSR = @CodPsrequalthis)''; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (LIVELLO = @Livelloequalthis)''; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@AttivazioneBandiequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVAZIONE_BANDI = @AttivazioneBandiequalthis)''; set @lensql=@lensql+len(@AttivazioneBandiequalthis);end;
	IF (@AttivazioneFaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVAZIONE_FA = @AttivazioneFaequalthis)''; set @lensql=@lensql+len(@AttivazioneFaequalthis);end;
	IF (@AttivazioneObMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVAZIONE_OB_MISURA = @AttivazioneObMisuraequalthis)''; set @lensql=@lensql+len(@AttivazioneObMisuraequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Codiceequalthis VARCHAR(255), @CodPsrequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @Livelloequalthis INT, @AttivazioneBandiequalthis BIT, @AttivazioneFaequalthis BIT, @AttivazioneObMisuraequalthis BIT'',@Codiceequalthis , @CodPsrequalthis , @Descrizioneequalthis , @Livelloequalthis , @AttivazioneBandiequalthis , @AttivazioneFaequalthis , @AttivazioneObMisuraequalthis ;
	else
		SELECT CODICE, COD_PSR, DESCRIZIONE, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA
		FROM zPSR_ALBERO
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@AttivazioneBandiequalthis IS NULL) OR ATTIVAZIONE_BANDI = @AttivazioneBandiequalthis) AND 
			((@AttivazioneFaequalthis IS NULL) OR ATTIVAZIONE_FA = @AttivazioneFaequalthis) AND 
			((@AttivazioneObMisuraequalthis IS NULL) OR ATTIVAZIONE_OB_MISURA = @AttivazioneObMisuraequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZpsrAlberoFindSelect';

