CREATE PROCEDURE [dbo].[ZZprogFaFindFind]
(
	@IdProgrammazioneequalthis INT, 
	@CodFaequalthis VARCHAR(255), 
	@CodPsrequalthis VARCHAR(255), 
	@Trasversaleequalthis BIT, 
	@ProgCodTipoequalthis VARCHAR(255), 
	@ProgCodiceequalthis VARCHAR(255), 
	@Livelloequalthis INT, 
	@AttivazioneBandiequalthis BIT, 
	@AttivazioneFaequalthis BIT, 
	@AttivazioneObMisuraequalthis BIT, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGRAMMAZIONE, COD_FA, TIPO_CONTRIBUTO, DOT_FINANZIARIA, COD_PSR, FA_DESCRIZIONE, FA_DOT_FINANZIARIA, TRASVERSALE, PROG_COD_TIPO, PROG_CODICE, PROG_DESCRIZIONE, ID_PADRE, PROG_TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVO, DATA, OPERATORE, CF_UTENTE, NOMINATIVO, COD_ENTE FROM vzPROG_FA WHERE 1=1';
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@CodFaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FA = @CodFaequalthis)'; set @lensql=@lensql+len(@CodFaequalthis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Trasversaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TRASVERSALE = @Trasversaleequalthis)'; set @lensql=@lensql+len(@Trasversaleequalthis);end;
	IF (@ProgCodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROG_COD_TIPO = @ProgCodTipoequalthis)'; set @lensql=@lensql+len(@ProgCodTipoequalthis);end;
	IF (@ProgCodiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROG_CODICE = @ProgCodiceequalthis)'; set @lensql=@lensql+len(@ProgCodiceequalthis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LIVELLO = @Livelloequalthis)'; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@AttivazioneBandiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_BANDI = @AttivazioneBandiequalthis)'; set @lensql=@lensql+len(@AttivazioneBandiequalthis);end;
	IF (@AttivazioneFaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_FA = @AttivazioneFaequalthis)'; set @lensql=@lensql+len(@AttivazioneFaequalthis);end;
	IF (@AttivazioneObMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVAZIONE_OB_MISURA = @AttivazioneObMisuraequalthis)'; set @lensql=@lensql+len(@AttivazioneObMisuraequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY PROG_CODICE, COD_FA';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgrammazioneequalthis INT, @CodFaequalthis VARCHAR(255), @CodPsrequalthis VARCHAR(255), @Trasversaleequalthis BIT, @ProgCodTipoequalthis VARCHAR(255), @ProgCodiceequalthis VARCHAR(255), @Livelloequalthis INT, @AttivazioneBandiequalthis BIT, @AttivazioneFaequalthis BIT, @AttivazioneObMisuraequalthis BIT, @Attivoequalthis BIT',@IdProgrammazioneequalthis , @CodFaequalthis , @CodPsrequalthis , @Trasversaleequalthis , @ProgCodTipoequalthis , @ProgCodiceequalthis , @Livelloequalthis , @AttivazioneBandiequalthis , @AttivazioneFaequalthis , @AttivazioneObMisuraequalthis , @Attivoequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, COD_FA, TIPO_CONTRIBUTO, DOT_FINANZIARIA, COD_PSR, FA_DESCRIZIONE, FA_DOT_FINANZIARIA, TRASVERSALE, PROG_COD_TIPO, PROG_CODICE, PROG_DESCRIZIONE, ID_PADRE, PROG_TIPO, LIVELLO, ATTIVAZIONE_BANDI, ATTIVAZIONE_FA, ATTIVAZIONE_OB_MISURA, ATTIVO, DATA, OPERATORE, CF_UTENTE, NOMINATIVO, COD_ENTE
		FROM vzPROG_FA
		WHERE 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@CodFaequalthis IS NULL) OR COD_FA = @CodFaequalthis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Trasversaleequalthis IS NULL) OR TRASVERSALE = @Trasversaleequalthis) AND 
			((@ProgCodTipoequalthis IS NULL) OR PROG_COD_TIPO = @ProgCodTipoequalthis) AND 
			((@ProgCodiceequalthis IS NULL) OR PROG_CODICE = @ProgCodiceequalthis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@AttivazioneBandiequalthis IS NULL) OR ATTIVAZIONE_BANDI = @AttivazioneBandiequalthis) AND 
			((@AttivazioneFaequalthis IS NULL) OR ATTIVAZIONE_FA = @AttivazioneFaequalthis) AND 
			((@AttivazioneObMisuraequalthis IS NULL) OR ATTIVAZIONE_OB_MISURA = @AttivazioneObMisuraequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY PROG_CODICE, COD_FA
