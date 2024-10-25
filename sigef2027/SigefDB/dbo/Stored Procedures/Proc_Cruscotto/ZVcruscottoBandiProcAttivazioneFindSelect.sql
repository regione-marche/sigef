CREATE PROCEDURE [dbo].[ZVcruscottoBandiProcAttivazioneFindSelect]
(
	@IdBandoequalthis INT, 
	@CodEnteequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(2000), 
	@ParoleChiaveequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@DisposizioniAttuativeequalthis BIT, 
	@IdSchedaValutazioneequalthis INT, 
	@Multiprogettoequalthis BIT, 
	@Multimisuraequalthis BIT, 
	@InteresseFilieraequalthis BIT, 
	@FascicoloRichiestoequalthis BIT, 
	@IdStoricoUltimoequalthis INT, 
	@DataAperturaequalthis DATETIME, 
	@IdModelloDomandaequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@IdIntegrazioneUltimaequalthis INT, 
	@DataScadenzaequalthis DATETIME, 
	@Importoequalthis DECIMAL(18,2), 
	@ImportoDiMisuraequalthis DECIMAL(18,2), 
	@QuotaRiservaequalthis DECIMAL(10,2), 
	@IdAttoIntegrazioneequalthis INT, 
	@CodStatoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT, 
	@Segnaturaequalthis VARCHAR(255), 
	@IdAttoequalthis INT, 
	@OrdineStatoequalthis INT, 
	@Statoequalthis VARCHAR(255), 
	@Profiloequalthis VARCHAR(255), 
	@Nominativoequalthis VARCHAR(511), 
	@CodTipoEnteequalthis VARCHAR(255), 
	@Enteequalthis VARCHAR(255), 
	@FirmaRichiestaequalthis BIT, 
	@AbilitaValutazioneequalthis BIT, 
	@Aggregazioneequalthis BIT, 
	@IdUtenteRupequalthis INT, 
	@CfRupequalthis VARCHAR(255), 
	@Rupequalthis VARCHAR(511)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, COD_ENTE, DESCRIZIONE, PAROLE_CHIAVE, DATA_INSERIMENTO, DISPOSIZIONI_ATTUATIVE, ID_SCHEDA_VALUTAZIONE, MULTIPROGETTO, MULTIMISURA, INTERESSE_FILIERA, FASCICOLO_RICHIESTO, ID_STORICO_ULTIMO, DATA_APERTURA, ID_MODELLO_DOMANDA, ID_PROGRAMMAZIONE, ID_INTEGRAZIONE_ULTIMA, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO_INTEGRAZIONE, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, ORDINE_STATO, STATO, PROFILO, NOMINATIVO, COD_TIPO_ENTE, ENTE, FIRMA_RICHIESTA, ABILITA_VALUTAZIONE, AGGREGAZIONE, ID_UTENTE_RUP, CF_RUP, RUP FROM VCRUSCOTTO_BANDI_PROC_ATTIVAZIONE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@ParoleChiaveequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PAROLE_CHIAVE = @ParoleChiaveequalthis)'; set @lensql=@lensql+len(@ParoleChiaveequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DisposizioniAttuativeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DISPOSIZIONI_ATTUATIVE = @DisposizioniAttuativeequalthis)'; set @lensql=@lensql+len(@DisposizioniAttuativeequalthis);end;
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)'; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@Multiprogettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MULTIPROGETTO = @Multiprogettoequalthis)'; set @lensql=@lensql+len(@Multiprogettoequalthis);end;
	IF (@Multimisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MULTIMISURA = @Multimisuraequalthis)'; set @lensql=@lensql+len(@Multimisuraequalthis);end;
	IF (@InteresseFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTERESSE_FILIERA = @InteresseFilieraequalthis)'; set @lensql=@lensql+len(@InteresseFilieraequalthis);end;
	IF (@FascicoloRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FASCICOLO_RICHIESTO = @FascicoloRichiestoequalthis)'; set @lensql=@lensql+len(@FascicoloRichiestoequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)'; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	IF (@DataAperturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_APERTURA = @DataAperturaequalthis)'; set @lensql=@lensql+len(@DataAperturaequalthis);end;
	IF (@IdModelloDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MODELLO_DOMANDA = @IdModelloDomandaequalthis)'; set @lensql=@lensql+len(@IdModelloDomandaequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@IdIntegrazioneUltimaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INTEGRAZIONE_ULTIMA = @IdIntegrazioneUltimaequalthis)'; set @lensql=@lensql+len(@IdIntegrazioneUltimaequalthis);end;
	IF (@DataScadenzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA = @DataScadenzaequalthis)'; set @lensql=@lensql+len(@DataScadenzaequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO = @Importoequalthis)'; set @lensql=@lensql+len(@Importoequalthis);end;
	IF (@ImportoDiMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DI_MISURA = @ImportoDiMisuraequalthis)'; set @lensql=@lensql+len(@ImportoDiMisuraequalthis);end;
	IF (@QuotaRiservaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUOTA_RISERVA = @QuotaRiservaequalthis)'; set @lensql=@lensql+len(@QuotaRiservaequalthis);end;
	IF (@IdAttoIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO_INTEGRAZIONE = @IdAttoIntegrazioneequalthis)'; set @lensql=@lensql+len(@IdAttoIntegrazioneequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO = @IdAttoequalthis)'; set @lensql=@lensql+len(@IdAttoequalthis);end;
	IF (@OrdineStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE_STATO = @OrdineStatoequalthis)'; set @lensql=@lensql+len(@OrdineStatoequalthis);end;
	IF (@Statoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO = @Statoequalthis)'; set @lensql=@lensql+len(@Statoequalthis);end;
	IF (@Profiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROFILO = @Profiloequalthis)'; set @lensql=@lensql+len(@Profiloequalthis);end;
	IF (@Nominativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOMINATIVO = @Nominativoequalthis)'; set @lensql=@lensql+len(@Nominativoequalthis);end;
	IF (@CodTipoEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_ENTE = @CodTipoEnteequalthis)'; set @lensql=@lensql+len(@CodTipoEnteequalthis);end;
	IF (@Enteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ENTE = @Enteequalthis)'; set @lensql=@lensql+len(@Enteequalthis);end;
	IF (@FirmaRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FIRMA_RICHIESTA = @FirmaRichiestaequalthis)'; set @lensql=@lensql+len(@FirmaRichiestaequalthis);end;
	IF (@AbilitaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ABILITA_VALUTAZIONE = @AbilitaValutazioneequalthis)'; set @lensql=@lensql+len(@AbilitaValutazioneequalthis);end;
	IF (@Aggregazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AGGREGAZIONE = @Aggregazioneequalthis)'; set @lensql=@lensql+len(@Aggregazioneequalthis);end;
	IF (@IdUtenteRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_RUP = @IdUtenteRupequalthis)'; set @lensql=@lensql+len(@IdUtenteRupequalthis);end;
	IF (@CfRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_RUP = @CfRupequalthis)'; set @lensql=@lensql+len(@CfRupequalthis);end;
	IF (@Rupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RUP = @Rupequalthis)'; set @lensql=@lensql+len(@Rupequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodEnteequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(2000), @ParoleChiaveequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @DisposizioniAttuativeequalthis BIT, @IdSchedaValutazioneequalthis INT, @Multiprogettoequalthis BIT, @Multimisuraequalthis BIT, @InteresseFilieraequalthis BIT, @FascicoloRichiestoequalthis BIT, @IdStoricoUltimoequalthis INT, @DataAperturaequalthis DATETIME, @IdModelloDomandaequalthis INT, @IdProgrammazioneequalthis INT, @IdIntegrazioneUltimaequalthis INT, @DataScadenzaequalthis DATETIME, @Importoequalthis DECIMAL(18,2), @ImportoDiMisuraequalthis DECIMAL(18,2), @QuotaRiservaequalthis DECIMAL(10,2), @IdAttoIntegrazioneequalthis INT, @CodStatoequalthis VARCHAR(255), @Dataequalthis DATETIME, @Operatoreequalthis INT, @Segnaturaequalthis VARCHAR(255), @IdAttoequalthis INT, @OrdineStatoequalthis INT, @Statoequalthis VARCHAR(255), @Profiloequalthis VARCHAR(255), @Nominativoequalthis VARCHAR(511), @CodTipoEnteequalthis VARCHAR(255), @Enteequalthis VARCHAR(255), @FirmaRichiestaequalthis BIT, @AbilitaValutazioneequalthis BIT, @Aggregazioneequalthis BIT, @IdUtenteRupequalthis INT, @CfRupequalthis VARCHAR(255), @Rupequalthis VARCHAR(511)',@IdBandoequalthis , @CodEnteequalthis , @Descrizioneequalthis , @ParoleChiaveequalthis , @DataInserimentoequalthis , @DisposizioniAttuativeequalthis , @IdSchedaValutazioneequalthis , @Multiprogettoequalthis , @Multimisuraequalthis , @InteresseFilieraequalthis , @FascicoloRichiestoequalthis , @IdStoricoUltimoequalthis , @DataAperturaequalthis , @IdModelloDomandaequalthis , @IdProgrammazioneequalthis , @IdIntegrazioneUltimaequalthis , @DataScadenzaequalthis , @Importoequalthis , @ImportoDiMisuraequalthis , @QuotaRiservaequalthis , @IdAttoIntegrazioneequalthis , @CodStatoequalthis , @Dataequalthis , @Operatoreequalthis , @Segnaturaequalthis , @IdAttoequalthis , @OrdineStatoequalthis , @Statoequalthis , @Profiloequalthis , @Nominativoequalthis , @CodTipoEnteequalthis , @Enteequalthis , @FirmaRichiestaequalthis , @AbilitaValutazioneequalthis , @Aggregazioneequalthis , @IdUtenteRupequalthis , @CfRupequalthis , @Rupequalthis ;
	else
		SELECT ID_BANDO, COD_ENTE, DESCRIZIONE, PAROLE_CHIAVE, DATA_INSERIMENTO, DISPOSIZIONI_ATTUATIVE, ID_SCHEDA_VALUTAZIONE, MULTIPROGETTO, MULTIMISURA, INTERESSE_FILIERA, FASCICOLO_RICHIESTO, ID_STORICO_ULTIMO, DATA_APERTURA, ID_MODELLO_DOMANDA, ID_PROGRAMMAZIONE, ID_INTEGRAZIONE_ULTIMA, DATA_SCADENZA, IMPORTO, IMPORTO_DI_MISURA, QUOTA_RISERVA, ID_ATTO_INTEGRAZIONE, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, ORDINE_STATO, STATO, PROFILO, NOMINATIVO, COD_TIPO_ENTE, ENTE, FIRMA_RICHIESTA, ABILITA_VALUTAZIONE, AGGREGAZIONE, ID_UTENTE_RUP, CF_RUP, RUP
		FROM VCRUSCOTTO_BANDI_PROC_ATTIVAZIONE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@ParoleChiaveequalthis IS NULL) OR PAROLE_CHIAVE = @ParoleChiaveequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DisposizioniAttuativeequalthis IS NULL) OR DISPOSIZIONI_ATTUATIVE = @DisposizioniAttuativeequalthis) AND 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@Multiprogettoequalthis IS NULL) OR MULTIPROGETTO = @Multiprogettoequalthis) AND 
			((@Multimisuraequalthis IS NULL) OR MULTIMISURA = @Multimisuraequalthis) AND 
			((@InteresseFilieraequalthis IS NULL) OR INTERESSE_FILIERA = @InteresseFilieraequalthis) AND 
			((@FascicoloRichiestoequalthis IS NULL) OR FASCICOLO_RICHIESTO = @FascicoloRichiestoequalthis) AND 
			((@IdStoricoUltimoequalthis IS NULL) OR ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis) AND 
			((@DataAperturaequalthis IS NULL) OR DATA_APERTURA = @DataAperturaequalthis) AND 
			((@IdModelloDomandaequalthis IS NULL) OR ID_MODELLO_DOMANDA = @IdModelloDomandaequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@IdIntegrazioneUltimaequalthis IS NULL) OR ID_INTEGRAZIONE_ULTIMA = @IdIntegrazioneUltimaequalthis) AND 
			((@DataScadenzaequalthis IS NULL) OR DATA_SCADENZA = @DataScadenzaequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis) AND 
			((@ImportoDiMisuraequalthis IS NULL) OR IMPORTO_DI_MISURA = @ImportoDiMisuraequalthis) AND 
			((@QuotaRiservaequalthis IS NULL) OR QUOTA_RISERVA = @QuotaRiservaequalthis) AND 
			((@IdAttoIntegrazioneequalthis IS NULL) OR ID_ATTO_INTEGRAZIONE = @IdAttoIntegrazioneequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@IdAttoequalthis IS NULL) OR ID_ATTO = @IdAttoequalthis) AND 
			((@OrdineStatoequalthis IS NULL) OR ORDINE_STATO = @OrdineStatoequalthis) AND 
			((@Statoequalthis IS NULL) OR STATO = @Statoequalthis) AND 
			((@Profiloequalthis IS NULL) OR PROFILO = @Profiloequalthis) AND 
			((@Nominativoequalthis IS NULL) OR NOMINATIVO = @Nominativoequalthis) AND 
			((@CodTipoEnteequalthis IS NULL) OR COD_TIPO_ENTE = @CodTipoEnteequalthis) AND 
			((@Enteequalthis IS NULL) OR ENTE = @Enteequalthis) AND 
			((@FirmaRichiestaequalthis IS NULL) OR FIRMA_RICHIESTA = @FirmaRichiestaequalthis) AND 
			((@AbilitaValutazioneequalthis IS NULL) OR ABILITA_VALUTAZIONE = @AbilitaValutazioneequalthis) AND 
			((@Aggregazioneequalthis IS NULL) OR AGGREGAZIONE = @Aggregazioneequalthis) AND 
			((@IdUtenteRupequalthis IS NULL) OR ID_UTENTE_RUP = @IdUtenteRupequalthis) AND 
			((@CfRupequalthis IS NULL) OR CF_RUP = @CfRupequalthis) AND 
			((@Rupequalthis IS NULL) OR RUP = @Rupequalthis)
		

GO