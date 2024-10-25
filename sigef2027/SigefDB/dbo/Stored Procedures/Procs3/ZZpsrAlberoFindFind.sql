CREATE PROCEDURE [dbo].[ZZpsrAlberoFindFind]
(
	@CodPsrequalthis VARCHAR(255), 
	@Descrizionelikethis VARCHAR(255), 
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
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LIVELLO = @Livelloequalthis)'; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@AttivazioneBandiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_BANDI = @AttivazioneBandiequalthis)'; set @lensql=@lensql+len(@AttivazioneBandiequalthis);end;
	IF (@AttivazioneFaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_FA = @AttivazioneFaequalthis)'; set @lensql=@lensql+len(@AttivazioneFaequalthis);end;
	IF (@AttivazioneObMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_OB_MISURA = @AttivazioneObMisuraequalthis)'; set @lensql=@lensql+len(@AttivazioneObMisuraequalthis);end;
	IF (@AttivazioneInvestimentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_INVESTIMENTI = @AttivazioneInvestimentiequalthis)'; set @lensql=@lensql+len(@AttivazioneInvestimentiequalthis);end;
	IF (@AttivazioneFfequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_FF = @AttivazioneFfequalthis)'; set @lensql=@lensql+len(@AttivazioneFfequalthis);end;
	set @sql = @sql + 'ORDER BY LIVELLO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodPsrequalthis VARCHAR(255), @Descrizionelikethis VARCHAR(255), @Livelloequalthis INT, @AttivazioneBandiequalthis BIT, @AttivazioneFaequalthis BIT, @AttivazioneObMisuraequalthis BIT, @AttivazioneInvestimentiequalthis BIT, @AttivazioneFfequalthis BIT',@CodPsrequalthis , @Descrizionelikethis , @Livelloequalthis , @AttivazioneBandiequalthis , @AttivazioneFaequalthis , @AttivazioneObMisuraequalthis , @AttivazioneInvestimentiequalthis , @AttivazioneFfequalthis ;
	else
		SELECT CODICE, COD_PSR, DESCRIZIONE, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVAZIONE_INVESTIMENTI, ATTIVAZIONE_FF
		FROM zPSR_ALBERO
		WHERE 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@AttivazioneBandiequalthis IS NULL) OR ATTIVAZIONE_BANDI = @AttivazioneBandiequalthis) AND 
			((@AttivazioneFaequalthis IS NULL) OR ATTIVAZIONE_FA = @AttivazioneFaequalthis) AND 
			((@AttivazioneObMisuraequalthis IS NULL) OR ATTIVAZIONE_OB_MISURA = @AttivazioneObMisuraequalthis) AND 
			((@AttivazioneInvestimentiequalthis IS NULL) OR ATTIVAZIONE_INVESTIMENTI = @AttivazioneInvestimentiequalthis) AND 
			((@AttivazioneFfequalthis IS NULL) OR ATTIVAZIONE_FF = @AttivazioneFfequalthis)
		ORDER BY LIVELLO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZpsrAlberoFindFind]
(
	@CodPsrequalthis VARCHAR(255), 
	@Descrizionelikethis VARCHAR(255), 
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
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_PSR = @CodPsrequalthis)''; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE LIKE @Descrizionelikethis)''; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (LIVELLO = @Livelloequalthis)''; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@AttivazioneBandiequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVAZIONE_BANDI = @AttivazioneBandiequalthis)''; set @lensql=@lensql+len(@AttivazioneBandiequalthis);end;
	IF (@AttivazioneFaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVAZIONE_FA = @AttivazioneFaequalthis)''; set @lensql=@lensql+len(@AttivazioneFaequalthis);end;
	IF (@AttivazioneObMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVAZIONE_OB_MISURA = @AttivazioneObMisuraequalthis)''; set @lensql=@lensql+len(@AttivazioneObMisuraequalthis);end;
	set @sql = @sql + ''ORDER BY LIVELLO'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@CodPsrequalthis VARCHAR(255), @Descrizionelikethis VARCHAR(255), @Livelloequalthis INT, @AttivazioneBandiequalthis BIT, @AttivazioneFaequalthis BIT, @AttivazioneObMisuraequalthis BIT'',@CodPsrequalthis , @Descrizionelikethis , @Livelloequalthis , @AttivazioneBandiequalthis , @AttivazioneFaequalthis , @AttivazioneObMisuraequalthis ;
	else
		SELECT CODICE, COD_PSR, DESCRIZIONE, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA
		FROM zPSR_ALBERO
		WHERE 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@AttivazioneBandiequalthis IS NULL) OR ATTIVAZIONE_BANDI = @AttivazioneBandiequalthis) AND 
			((@AttivazioneFaequalthis IS NULL) OR ATTIVAZIONE_FA = @AttivazioneFaequalthis) AND 
			((@AttivazioneObMisuraequalthis IS NULL) OR ATTIVAZIONE_OB_MISURA = @AttivazioneObMisuraequalthis)
		ORDER BY LIVELLO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZpsrAlberoFindFind';

