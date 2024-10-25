CREATE PROCEDURE [dbo].[ZBandoFindSelect]
(
	@IdBandoequalthis INT, 
	@CodEnteequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(2000), 
	@ParoleChiaveequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@DataAperturaequalthis DATETIME, 
	@DisposizioniAttuativeequalthis BIT, 
	@IdSchedaValutazioneequalthis INT, 
	@IdModelloDomandaequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@Multiprogettoequalthis BIT, 
	@Multimisuraequalthis BIT, 
	@InteresseFilieraequalthis BIT, 
	@FascicoloRichiestoequalthis BIT, 
	@IdStoricoUltimoequalthis INT, 
	@IdIntegrazioneUltimaequalthis INT, 
	@FirmaRichiestaequalthis BIT, 
	@AbilitaValutazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, COD_ENTE, DESCRIZIONE, PAROLE_CHIAVE, DATA_INSERIMENTO, DISPOSIZIONI_ATTUATIVE, ID_SCHEDA_VALUTAZIONE, MULTIPROGETTO, MULTIMISURA, INTERESSE_FILIERA, FASCICOLO_RICHIESTO, ID_STORICO_ULTIMO, DATA_APERTURA, ID_MODELLO_DOMANDA, ID_PROGRAMMAZIONE, ID_INTEGRAZIONE_ULTIMA, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO_INTEGRAZIONE, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, ORDINE_STATO, STATO, PROFILO, NOMINATIVO, COD_TIPO_ENTE, ENTE, FIRMA_RICHIESTA, ABILITA_VALUTAZIONE FROM vBANDO WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@ParoleChiaveequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PAROLE_CHIAVE = @ParoleChiaveequalthis)'; set @lensql=@lensql+len(@ParoleChiaveequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataAperturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_APERTURA = @DataAperturaequalthis)'; set @lensql=@lensql+len(@DataAperturaequalthis);end;
	IF (@DisposizioniAttuativeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DISPOSIZIONI_ATTUATIVE = @DisposizioniAttuativeequalthis)'; set @lensql=@lensql+len(@DisposizioniAttuativeequalthis);end;
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)'; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@IdModelloDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MODELLO_DOMANDA = @IdModelloDomandaequalthis)'; set @lensql=@lensql+len(@IdModelloDomandaequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Multiprogettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MULTIPROGETTO = @Multiprogettoequalthis)'; set @lensql=@lensql+len(@Multiprogettoequalthis);end;
	IF (@Multimisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MULTIMISURA = @Multimisuraequalthis)'; set @lensql=@lensql+len(@Multimisuraequalthis);end;
	IF (@InteresseFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTERESSE_FILIERA = @InteresseFilieraequalthis)'; set @lensql=@lensql+len(@InteresseFilieraequalthis);end;
	IF (@FascicoloRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FASCICOLO_RICHIESTO = @FascicoloRichiestoequalthis)'; set @lensql=@lensql+len(@FascicoloRichiestoequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)'; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	IF (@IdIntegrazioneUltimaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INTEGRAZIONE_ULTIMA = @IdIntegrazioneUltimaequalthis)'; set @lensql=@lensql+len(@IdIntegrazioneUltimaequalthis);end;
	IF (@FirmaRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FIRMA_RICHIESTA = @FirmaRichiestaequalthis)'; set @lensql=@lensql+len(@FirmaRichiestaequalthis);end;
	IF (@AbilitaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ABILITA_VALUTAZIONE = @AbilitaValutazioneequalthis)'; set @lensql=@lensql+len(@AbilitaValutazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodEnteequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(2000), @ParoleChiaveequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @DataAperturaequalthis DATETIME, @DisposizioniAttuativeequalthis BIT, @IdSchedaValutazioneequalthis INT, @IdModelloDomandaequalthis INT, @IdProgrammazioneequalthis INT, @Multiprogettoequalthis BIT, @Multimisuraequalthis BIT, @InteresseFilieraequalthis BIT, @FascicoloRichiestoequalthis BIT, @IdStoricoUltimoequalthis INT, @IdIntegrazioneUltimaequalthis INT, @FirmaRichiestaequalthis BIT, @AbilitaValutazioneequalthis BIT',@IdBandoequalthis , @CodEnteequalthis , @Descrizioneequalthis , @ParoleChiaveequalthis , @DataInserimentoequalthis , @DataAperturaequalthis , @DisposizioniAttuativeequalthis , @IdSchedaValutazioneequalthis , @IdModelloDomandaequalthis , @IdProgrammazioneequalthis , @Multiprogettoequalthis , @Multimisuraequalthis , @InteresseFilieraequalthis , @FascicoloRichiestoequalthis , @IdStoricoUltimoequalthis , @IdIntegrazioneUltimaequalthis , @FirmaRichiestaequalthis , @AbilitaValutazioneequalthis ;
	else
		SELECT ID_BANDO, COD_ENTE, DESCRIZIONE, PAROLE_CHIAVE, DATA_INSERIMENTO, DISPOSIZIONI_ATTUATIVE, ID_SCHEDA_VALUTAZIONE, MULTIPROGETTO, MULTIMISURA, INTERESSE_FILIERA, FASCICOLO_RICHIESTO, ID_STORICO_ULTIMO, DATA_APERTURA, ID_MODELLO_DOMANDA, ID_PROGRAMMAZIONE, ID_INTEGRAZIONE_ULTIMA, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO_INTEGRAZIONE, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, ORDINE_STATO, STATO, PROFILO, NOMINATIVO, COD_TIPO_ENTE, ENTE, FIRMA_RICHIESTA, ABILITA_VALUTAZIONE
		FROM vBANDO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@ParoleChiaveequalthis IS NULL) OR PAROLE_CHIAVE = @ParoleChiaveequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataAperturaequalthis IS NULL) OR DATA_APERTURA = @DataAperturaequalthis) AND 
			((@DisposizioniAttuativeequalthis IS NULL) OR DISPOSIZIONI_ATTUATIVE = @DisposizioniAttuativeequalthis) AND 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@IdModelloDomandaequalthis IS NULL) OR ID_MODELLO_DOMANDA = @IdModelloDomandaequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@Multiprogettoequalthis IS NULL) OR MULTIPROGETTO = @Multiprogettoequalthis) AND 
			((@Multimisuraequalthis IS NULL) OR MULTIMISURA = @Multimisuraequalthis) AND 
			((@InteresseFilieraequalthis IS NULL) OR INTERESSE_FILIERA = @InteresseFilieraequalthis) AND 
			((@FascicoloRichiestoequalthis IS NULL) OR FASCICOLO_RICHIESTO = @FascicoloRichiestoequalthis) AND 
			((@IdStoricoUltimoequalthis IS NULL) OR ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis) AND 
			((@IdIntegrazioneUltimaequalthis IS NULL) OR ID_INTEGRAZIONE_ULTIMA = @IdIntegrazioneUltimaequalthis) AND 
			((@FirmaRichiestaequalthis IS NULL) OR FIRMA_RICHIESTA = @FirmaRichiestaequalthis) AND 
			((@AbilitaValutazioneequalthis IS NULL) OR ABILITA_VALUTAZIONE = @AbilitaValutazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoFindSelect]
(
	@IdBandoequalthis INT, 
	@CodEnteequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(2000), 
	@ParoleChiaveequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@DataAperturaequalthis DATETIME, 
	@DisposizioniAttuativeequalthis BIT, 
	@IdSchedaValutazioneequalthis INT, 
	@IdModelloDomandaequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@Multiprogettoequalthis BIT, 
	@Multimisuraequalthis BIT, 
	@InteresseFilieraequalthis BIT, 
	@FascicoloRichiestoequalthis BIT, 
	@IdStoricoUltimoequalthis INT, 
	@IdIntegrazioneUltimaequalthis INT, 
	@FirmaRichiestaequalthis BIT, 
	@AbilitaValutazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_BANDO, COD_ENTE, DESCRIZIONE, PAROLE_CHIAVE, DATA_INSERIMENTO, DISPOSIZIONI_ATTUATIVE, ID_SCHEDA_VALUTAZIONE, MULTIPROGETTO, MULTIMISURA, INTERESSE_FILIERA, FASCICOLO_RICHIESTO, ID_STORICO_ULTIMO, DATA_APERTURA, ID_MODELLO_DOMANDA, ID_PROGRAMMAZIONE, ID_INTEGRAZIONE_ULTIMA, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO_INTEGRAZIONE, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, ORDINE_STATO, STATO, PROFILO, NOMINATIVO, COD_TIPO_ENTE, ENTE, FIRMA_RICHIESTA, ABILITA_VALUTAZIONE FROM vBANDO WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE = @CodEnteequalthis)''; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@ParoleChiaveequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PAROLE_CHIAVE = @ParoleChiaveequalthis)''; set @lensql=@lensql+len(@ParoleChiaveequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)''; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataAperturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_APERTURA = @DataAperturaequalthis)''; set @lensql=@lensql+len(@DataAperturaequalthis);end;
	IF (@DisposizioniAttuativeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DISPOSIZIONI_ATTUATIVE = @DisposizioniAttuativeequalthis)''; set @lensql=@lensql+len(@DisposizioniAttuativeequalthis);end;
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)''; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@IdModelloDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_MODELLO_DOMANDA = @IdModelloDomandaequalthis)''; set @lensql=@lensql+len(@IdModelloDomandaequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)''; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Multiprogettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MULTIPROGETTO = @Multiprogettoequalthis)''; set @lensql=@lensql+len(@Multiprogettoequalthis);end;
	IF (@Multimisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MULTIMISURA = @Multimisuraequalthis)''; set @lensql=@lensql+len(@Multimisuraequalthis);end;
	IF (@InteresseFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (INTERESSE_FILIERA = @InteresseFilieraequalthis)''; set @lensql=@lensql+len(@InteresseFilieraequalthis);end;
	IF (@FascicoloRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FASCICOLO_RICHIESTO = @FascicoloRichiestoequalthis)''; set @lensql=@lensql+len(@FascicoloRichiestoequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)''; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	IF (@IdIntegrazioneUltimaequalthis IS NOT NULL) B', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoFindSelect';

