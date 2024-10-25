CREATE PROCEDURE [dbo].[ZBandoFindFind]
(
	@CodEnteequalthis VARCHAR(255), 
	@CodStatoequalthis VARCHAR(255), 
	@OrdineStatoeqgreaterthanthis INT, 
	@DataScadenzaeqlessthanthis DATETIME, 
	@IdProgrammazioneequalthis INT, 
	@Multiprogettoequalthis BIT, 
	@Multimisuraequalthis BIT, 
	@DisposizioniAttuativeequalthis BIT, 
	@ParoleChiavelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, COD_ENTE, DESCRIZIONE, PAROLE_CHIAVE, DATA_INSERIMENTO, DISPOSIZIONI_ATTUATIVE, ID_SCHEDA_VALUTAZIONE, MULTIPROGETTO, MULTIMISURA, INTERESSE_FILIERA, FASCICOLO_RICHIESTO, ID_STORICO_ULTIMO, DATA_APERTURA, ID_MODELLO_DOMANDA, ID_PROGRAMMAZIONE, ID_INTEGRAZIONE_ULTIMA, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO_INTEGRAZIONE, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, ORDINE_STATO, STATO, PROFILO, NOMINATIVO, COD_TIPO_ENTE, ENTE, FIRMA_RICHIESTA, ABILITA_VALUTAZIONE FROM vBANDO WHERE 1=1';
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@OrdineStatoeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE_STATO >= @OrdineStatoeqgreaterthanthis)'; set @lensql=@lensql+len(@OrdineStatoeqgreaterthanthis);end;
	IF (@DataScadenzaeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA <= @DataScadenzaeqlessthanthis)'; set @lensql=@lensql+len(@DataScadenzaeqlessthanthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Multiprogettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MULTIPROGETTO = @Multiprogettoequalthis)'; set @lensql=@lensql+len(@Multiprogettoequalthis);end;
	IF (@Multimisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MULTIMISURA = @Multimisuraequalthis)'; set @lensql=@lensql+len(@Multimisuraequalthis);end;
	IF (@DisposizioniAttuativeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DISPOSIZIONI_ATTUATIVE = @DisposizioniAttuativeequalthis)'; set @lensql=@lensql+len(@DisposizioniAttuativeequalthis);end;
	IF (@ParoleChiavelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PAROLE_CHIAVE LIKE @ParoleChiavelikethis)'; set @lensql=@lensql+len(@ParoleChiavelikethis);end;
	set @sql = @sql + 'ORDER BY DATA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodEnteequalthis VARCHAR(255), @CodStatoequalthis VARCHAR(255), @OrdineStatoeqgreaterthanthis INT, @DataScadenzaeqlessthanthis DATETIME, @IdProgrammazioneequalthis INT, @Multiprogettoequalthis BIT, @Multimisuraequalthis BIT, @DisposizioniAttuativeequalthis BIT, @ParoleChiavelikethis VARCHAR(255)',@CodEnteequalthis , @CodStatoequalthis , @OrdineStatoeqgreaterthanthis , @DataScadenzaeqlessthanthis , @IdProgrammazioneequalthis , @Multiprogettoequalthis , @Multimisuraequalthis , @DisposizioniAttuativeequalthis , @ParoleChiavelikethis ;
	else
		SELECT ID_BANDO, COD_ENTE, DESCRIZIONE, PAROLE_CHIAVE, DATA_INSERIMENTO, DISPOSIZIONI_ATTUATIVE, ID_SCHEDA_VALUTAZIONE, MULTIPROGETTO, MULTIMISURA, INTERESSE_FILIERA, FASCICOLO_RICHIESTO, ID_STORICO_ULTIMO, DATA_APERTURA, ID_MODELLO_DOMANDA, ID_PROGRAMMAZIONE, ID_INTEGRAZIONE_ULTIMA, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO_INTEGRAZIONE, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, ORDINE_STATO, STATO, PROFILO, NOMINATIVO, COD_TIPO_ENTE, ENTE, FIRMA_RICHIESTA, ABILITA_VALUTAZIONE
		FROM vBANDO
		WHERE 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@OrdineStatoeqgreaterthanthis IS NULL) OR ORDINE_STATO >= @OrdineStatoeqgreaterthanthis) AND 
			((@DataScadenzaeqlessthanthis IS NULL) OR DATA_SCADENZA <= @DataScadenzaeqlessthanthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@Multiprogettoequalthis IS NULL) OR MULTIPROGETTO = @Multiprogettoequalthis) AND 
			((@Multimisuraequalthis IS NULL) OR MULTIMISURA = @Multimisuraequalthis) AND 
			((@DisposizioniAttuativeequalthis IS NULL) OR DISPOSIZIONI_ATTUATIVE = @DisposizioniAttuativeequalthis) AND 
			((@ParoleChiavelikethis IS NULL) OR PAROLE_CHIAVE LIKE @ParoleChiavelikethis)
		ORDER BY DATA DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoFindFind]
(
	@CodEnteequalthis VARCHAR(255), 
	@CodStatoequalthis VARCHAR(255), 
	@OrdineStatoeqgreaterthanthis INT, 
	@DataScadenzaeqlessthanthis DATETIME, 
	@IdProgrammazioneequalthis INT, 
	@Multiprogettoequalthis BIT, 
	@Multimisuraequalthis BIT, 
	@DisposizioniAttuativeequalthis BIT, 
	@ParoleChiavelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_BANDO, COD_ENTE, DESCRIZIONE, PAROLE_CHIAVE, DATA_INSERIMENTO, DISPOSIZIONI_ATTUATIVE, ID_SCHEDA_VALUTAZIONE, MULTIPROGETTO, MULTIMISURA, INTERESSE_FILIERA, FASCICOLO_RICHIESTO, ID_STORICO_ULTIMO, DATA_APERTURA, ID_MODELLO_DOMANDA, ID_PROGRAMMAZIONE, ID_INTEGRAZIONE_ULTIMA, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO_INTEGRAZIONE, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, ORDINE_STATO, STATO, PROFILO, NOMINATIVO, COD_TIPO_ENTE, ENTE, FIRMA_RICHIESTA, ABILITA_VALUTAZIONE FROM vBANDO WHERE 1=1'';
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE = @CodEnteequalthis)''; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_STATO = @CodStatoequalthis)''; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@OrdineStatoeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE_STATO >= @OrdineStatoeqgreaterthanthis)''; set @lensql=@lensql+len(@OrdineStatoeqgreaterthanthis);end;
	IF (@DataScadenzaeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_SCADENZA <= @DataScadenzaeqlessthanthis)''; set @lensql=@lensql+len(@DataScadenzaeqlessthanthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)''; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Multiprogettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MULTIPROGETTO = @Multiprogettoequalthis)''; set @lensql=@lensql+len(@Multiprogettoequalthis);end;
	IF (@Multimisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MULTIMISURA = @Multimisuraequalthis)''; set @lensql=@lensql+len(@Multimisuraequalthis);end;
	IF (@DisposizioniAttuativeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DISPOSIZIONI_ATTUATIVE = @DisposizioniAttuativeequalthis)''; set @lensql=@lensql+len(@DisposizioniAttuativeequalthis);end;
	IF (@ParoleChiavelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PAROLE_CHIAVE LIKE @ParoleChiavelikethis)''; set @lensql=@lensql+len(@ParoleChiavelikethis);end;
	set @sql = @sql + ''ORDER BY DATA DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@CodEnteequalthis VARCHAR(255), @CodStatoequalthis VARCHAR(255), @OrdineStatoeqgreaterthanthis INT, @DataScadenzaeqlessthanthis DATETIME, @IdProgrammazioneequalthis INT, @Multiprogettoequalthis BIT, @Multimisuraequalthis BIT, @DisposizioniAttuativeequalthis BIT, @ParoleChiavelikethis VARCHAR(255)'',@CodEnteequalthis , @CodStatoequalthis , @OrdineStatoeqgreaterthanthis , @DataScadenzaeqlessthanthis , @IdProgrammazioneequalthis , @Multiprogettoequalthis , @Multimisuraequalthis , @DisposizioniAttuativeequalthis , @ParoleChiavelikethis ;
	else
		SELECT ID_BANDO, COD_ENTE, DESCRIZIONE, PAROLE_CHIAVE, DATA_INSERIMENTO, DISPOSIZIONI_ATTUATIVE, ID_SCHEDA_VALUTAZIONE, MULTIPROGETTO, MULTIMISURA, INTERESSE_FILIERA, FASCICOLO_RICHIESTO, ID_STORICO_ULTIMO, DATA_APERTURA, ID_MODELLO_DOMANDA, ID_PROGRAMMAZIONE, ID_INTEGRAZIONE_ULTIMA, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO_INTEGRAZIONE, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, ORDINE_STATO, STATO, PROFILO, NOMINATIVO, COD_TIPO_ENTE, ENTE, FIRMA_RICHIESTA, ABILITA_VALUTAZIONE
		FROM vBANDO
		WHERE 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@OrdineStatoeqgreaterthanthis IS NULL) OR ORDINE_STATO >= @OrdineStatoeqgreatert', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoFindFind';

