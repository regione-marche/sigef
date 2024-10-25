CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoFindSelect]
(
	@IdDomandaPagamentoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@IdProgettoequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CodEnteequalthis VARCHAR(255), 
	@Segnaturaequalthis VARCHAR(255), 
	@SegnaturaAllegatiequalthis VARCHAR(255), 
	@IdFidejussioneequalthis INT, 
	@DataCertificazioneAntimafiaequalthis DATETIME, 
	@Approvataequalthis BIT, 
	@SegnaturaApprovazioneequalthis VARCHAR(255), 
	@SegnaturaSecondaApprovazioneequalthis VARCHAR(255), 
	@CfIstruttoreequalthis VARCHAR(255), 
	@DataApprovazioneequalthis DATETIME, 
	@Annullataequalthis BIT, 
	@SegnaturaAnnullamentoequalthis VARCHAR(255), 
	@CfOperatoreAnnullamentoequalthis VARCHAR(255), 
	@DataAnnullamentoequalthis DATETIME, 
	@ValiditaVersioneAdcequalthis BIT, 
	@IdVariazioneAccertataequalthis INT, 
	@PredispostaAControlloequalthis BIT, 
	@DataPredisposizioneAControlloequalthis DATETIME, 
	@VisitaInsituEsitoequalthis VARCHAR(255), 
	@ControlloInlocoEsitoequalthis VARCHAR(255), 
	@VerificaPagamentiEsitoequalthis VARCHAR(255), 
	@VerificaPagamentiMessaggioequalthis VARCHAR(3000), 
	@VerificaPagamentiDataequalthis DATETIME, 
	@FirmaPredispostaequalthis BIT, 
	@FirmaPredispostaRupequalthis BIT, 
	@InIntegrazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA_PAGAMENTO, COD_TIPO, ID_PROGETTO, DATA_INSERIMENTO, DATA_MODIFICA, COD_ENTE, SEGNATURA, DESCRIZIONE, COD_FASE, FASE, ORDINE, ID_FIDEJUSSIONE, OPERATORE, CF_OPERATORE, SEGNATURA_ALLEGATI, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, CF_ISTRUTTORE, DATA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VALUTAZIONE_ISTRUTTORE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, DATA_PREDISPOSIZIONE_A_CONTROLLO, NOMINATIVO_OPERATORE_ANNULLAMENTO, ISTRUTTORE, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE, FIRMA_PREDISPOSTA_RUP FROM vDOMANDA_DI_PAGAMENTO WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE = @CfOperatoreequalthis)'; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@SegnaturaAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis)'; set @lensql=@lensql+len(@SegnaturaAllegatiequalthis);end;
	IF (@IdFidejussioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FIDEJUSSIONE = @IdFidejussioneequalthis)'; set @lensql=@lensql+len(@IdFidejussioneequalthis);end;
	IF (@DataCertificazioneAntimafiaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CERTIFICAZIONE_ANTIMAFIA = @DataCertificazioneAntimafiaequalthis)'; set @lensql=@lensql+len(@DataCertificazioneAntimafiaequalthis);end;
	IF (@Approvataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (APPROVATA = @Approvataequalthis)'; set @lensql=@lensql+len(@Approvataequalthis);end;
	IF (@SegnaturaApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_APPROVAZIONE = @SegnaturaApprovazioneequalthis)'; set @lensql=@lensql+len(@SegnaturaApprovazioneequalthis);end;
	IF (@SegnaturaSecondaApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_SECONDA_APPROVAZIONE = @SegnaturaSecondaApprovazioneequalthis)'; set @lensql=@lensql+len(@SegnaturaSecondaApprovazioneequalthis);end;
	IF (@CfIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_ISTRUTTORE = @CfIstruttoreequalthis)'; set @lensql=@lensql+len(@CfIstruttoreequalthis);end;
	IF (@DataApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_APPROVAZIONE = @DataApprovazioneequalthis)'; set @lensql=@lensql+len(@DataApprovazioneequalthis);end;
	IF (@Annullataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATA = @Annullataequalthis)'; set @lensql=@lensql+len(@Annullataequalthis);end;
	IF (@SegnaturaAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ANNULLAMENTO = @SegnaturaAnnullamentoequalthis)'; set @lensql=@lensql+len(@SegnaturaAnnullamentoequalthis);end;
	IF (@CfOperatoreAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE_ANNULLAMENTO = @CfOperatoreAnnullamentoequalthis)'; set @lensql=@lensql+len(@CfOperatoreAnnullamentoequalthis);end;
	IF (@DataAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ANNULLAMENTO = @DataAnnullamentoequalthis)'; set @lensql=@lensql+len(@DataAnnullamentoequalthis);end;
	IF (@ValiditaVersioneAdcequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALIDITA_VERSIONE_ADC = @ValiditaVersioneAdcequalthis)'; set @lensql=@lensql+len(@ValiditaVersioneAdcequalthis);end;
	IF (@IdVariazioneAccertataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIAZIONE_ACCERTATA = @IdVariazioneAccertataequalthis)'; set @lensql=@lensql+len(@IdVariazioneAccertataequalthis);end;
	IF (@PredispostaAControlloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREDISPOSTA_A_CONTROLLO = @PredispostaAControlloequalthis)'; set @lensql=@lensql+len(@PredispostaAControlloequalthis);end;
	IF (@DataPredisposizioneAControlloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PREDISPOSIZIONE_A_CONTROLLO = @DataPredisposizioneAControlloequalthis)'; set @lensql=@lensql+len(@DataPredisposizioneAControlloequalthis);end;
	IF (@VisitaInsituEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VISITA_INSITU_ESITO = @VisitaInsituEsitoequalthis)'; set @lensql=@lensql+len(@VisitaInsituEsitoequalthis);end;
	IF (@ControlloInlocoEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTROLLO_INLOCO_ESITO = @ControlloInlocoEsitoequalthis)'; set @lensql=@lensql+len(@ControlloInlocoEsitoequalthis);end;
	IF (@VerificaPagamentiEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VERIFICA_PAGAMENTI_ESITO = @VerificaPagamentiEsitoequalthis)'; set @lensql=@lensql+len(@VerificaPagamentiEsitoequalthis);end;
	IF (@VerificaPagamentiMessaggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VERIFICA_PAGAMENTI_MESSAGGIO = @VerificaPagamentiMessaggioequalthis)'; set @lensql=@lensql+len(@VerificaPagamentiMessaggioequalthis);end;
	IF (@VerificaPagamentiDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VERIFICA_PAGAMENTI_DATA = @VerificaPagamentiDataequalthis)'; set @lensql=@lensql+len(@VerificaPagamentiDataequalthis);end;
	IF (@FirmaPredispostaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FIRMA_PREDISPOSTA = @FirmaPredispostaequalthis)'; set @lensql=@lensql+len(@FirmaPredispostaequalthis);end;
	IF (@FirmaPredispostaRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FIRMA_PREDISPOSTA_RUP = @FirmaPredispostaRupequalthis)'; set @lensql=@lensql+len(@FirmaPredispostaRupequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @CodTipoequalthis VARCHAR(255), @IdProgettoequalthis INT, @DataInserimentoequalthis DATETIME, @CfOperatoreequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CodEnteequalthis VARCHAR(255), @Segnaturaequalthis VARCHAR(255), @SegnaturaAllegatiequalthis VARCHAR(255), @IdFidejussioneequalthis INT, @DataCertificazioneAntimafiaequalthis DATETIME, @Approvataequalthis BIT, @SegnaturaApprovazioneequalthis VARCHAR(255), @SegnaturaSecondaApprovazioneequalthis VARCHAR(255), @CfIstruttoreequalthis VARCHAR(255), @DataApprovazioneequalthis DATETIME, @Annullataequalthis BIT, @SegnaturaAnnullamentoequalthis VARCHAR(255), @CfOperatoreAnnullamentoequalthis VARCHAR(255), @DataAnnullamentoequalthis DATETIME, @ValiditaVersioneAdcequalthis BIT, @IdVariazioneAccertataequalthis INT, @PredispostaAControlloequalthis BIT, @DataPredisposizioneAControlloequalthis DATETIME, @VisitaInsituEsitoequalthis VARCHAR(255), @ControlloInlocoEsitoequalthis VARCHAR(255), @VerificaPagamentiEsitoequalthis VARCHAR(255), @VerificaPagamentiMessaggioequalthis VARCHAR(3000), @VerificaPagamentiDataequalthis DATETIME, @FirmaPredispostaequalthis BIT, @FirmaPredispostaRupequalthis BIT, @InIntegrazioneequalthis BIT',@IdDomandaPagamentoequalthis , @CodTipoequalthis , @IdProgettoequalthis , @DataInserimentoequalthis , @CfOperatoreequalthis , @DataModificaequalthis , @CodEnteequalthis , @Segnaturaequalthis , @SegnaturaAllegatiequalthis , @IdFidejussioneequalthis , @DataCertificazioneAntimafiaequalthis , @Approvataequalthis , @SegnaturaApprovazioneequalthis , @SegnaturaSecondaApprovazioneequalthis , @CfIstruttoreequalthis , @DataApprovazioneequalthis , @Annullataequalthis , @SegnaturaAnnullamentoequalthis , @CfOperatoreAnnullamentoequalthis , @DataAnnullamentoequalthis , @ValiditaVersioneAdcequalthis , @IdVariazioneAccertataequalthis , @PredispostaAControlloequalthis , @DataPredisposizioneAControlloequalthis , @VisitaInsituEsitoequalthis , @ControlloInlocoEsitoequalthis , @VerificaPagamentiEsitoequalthis , @VerificaPagamentiMessaggioequalthis , @VerificaPagamentiDataequalthis , @FirmaPredispostaequalthis , @FirmaPredispostaRupequalthis , @InIntegrazioneequalthis ;
	else
		SELECT ID_DOMANDA_PAGAMENTO, COD_TIPO, ID_PROGETTO, DATA_INSERIMENTO, DATA_MODIFICA, COD_ENTE, SEGNATURA, DESCRIZIONE, COD_FASE, FASE, ORDINE, ID_FIDEJUSSIONE, OPERATORE, CF_OPERATORE, SEGNATURA_ALLEGATI, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, CF_ISTRUTTORE, DATA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VALUTAZIONE_ISTRUTTORE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, DATA_PREDISPOSIZIONE_A_CONTROLLO, NOMINATIVO_OPERATORE_ANNULLAMENTO, ISTRUTTORE, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE, FIRMA_PREDISPOSTA_RUP
		FROM vDOMANDA_DI_PAGAMENTO
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@SegnaturaAllegatiequalthis IS NULL) OR SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis) AND 
			((@IdFidejussioneequalthis IS NULL) OR ID_FIDEJUSSIONE = @IdFidejussioneequalthis) AND 
			((@DataCertificazioneAntimafiaequalthis IS NULL) OR DATA_CERTIFICAZIONE_ANTIMAFIA = @DataCertificazioneAntimafiaequalthis) AND 
			((@Approvataequalthis IS NULL) OR APPROVATA = @Approvataequalthis) AND 
			((@SegnaturaApprovazioneequalthis IS NULL) OR SEGNATURA_APPROVAZIONE = @SegnaturaApprovazioneequalthis) AND 
			((@SegnaturaSecondaApprovazioneequalthis IS NULL) OR SEGNATURA_SECONDA_APPROVAZIONE = @SegnaturaSecondaApprovazioneequalthis) AND 
			((@CfIstruttoreequalthis IS NULL) OR CF_ISTRUTTORE = @CfIstruttoreequalthis) AND 
			((@DataApprovazioneequalthis IS NULL) OR DATA_APPROVAZIONE = @DataApprovazioneequalthis) AND 
			((@Annullataequalthis IS NULL) OR ANNULLATA = @Annullataequalthis) AND 
			((@SegnaturaAnnullamentoequalthis IS NULL) OR SEGNATURA_ANNULLAMENTO = @SegnaturaAnnullamentoequalthis) AND 
			((@CfOperatoreAnnullamentoequalthis IS NULL) OR CF_OPERATORE_ANNULLAMENTO = @CfOperatoreAnnullamentoequalthis) AND 
			((@DataAnnullamentoequalthis IS NULL) OR DATA_ANNULLAMENTO = @DataAnnullamentoequalthis) AND 
			((@ValiditaVersioneAdcequalthis IS NULL) OR VALIDITA_VERSIONE_ADC = @ValiditaVersioneAdcequalthis) AND 
			((@IdVariazioneAccertataequalthis IS NULL) OR ID_VARIAZIONE_ACCERTATA = @IdVariazioneAccertataequalthis) AND 
			((@PredispostaAControlloequalthis IS NULL) OR PREDISPOSTA_A_CONTROLLO = @PredispostaAControlloequalthis) AND 
			((@DataPredisposizioneAControlloequalthis IS NULL) OR DATA_PREDISPOSIZIONE_A_CONTROLLO = @DataPredisposizioneAControlloequalthis) AND 
			((@VisitaInsituEsitoequalthis IS NULL) OR VISITA_INSITU_ESITO = @VisitaInsituEsitoequalthis) AND 
			((@ControlloInlocoEsitoequalthis IS NULL) OR CONTROLLO_INLOCO_ESITO = @ControlloInlocoEsitoequalthis) AND 
			((@VerificaPagamentiEsitoequalthis IS NULL) OR VERIFICA_PAGAMENTI_ESITO = @VerificaPagamentiEsitoequalthis) AND 
			((@VerificaPagamentiMessaggioequalthis IS NULL) OR VERIFICA_PAGAMENTI_MESSAGGIO = @VerificaPagamentiMessaggioequalthis) AND 
			((@VerificaPagamentiDataequalthis IS NULL) OR VERIFICA_PAGAMENTI_DATA = @VerificaPagamentiDataequalthis) AND 
			((@FirmaPredispostaequalthis IS NULL) OR FIRMA_PREDISPOSTA = @FirmaPredispostaequalthis) AND 
			((@FirmaPredispostaRupequalthis IS NULL) OR FIRMA_PREDISPOSTA_RUP = @FirmaPredispostaRupequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoFindSelect]
(
	@IdDomandaPagamentoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@IdProgettoequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CodEnteequalthis VARCHAR(255), 
	@Segnaturaequalthis VARCHAR(255), 
	@SegnaturaAllegatiequalthis VARCHAR(255), 
	@IdFidejussioneequalthis INT, 
	@DataCertificazioneAntimafiaequalthis DATETIME, 
	@Approvataequalthis BIT, 
	@SegnaturaApprovazioneequalthis VARCHAR(255), 
	@SegnaturaSecondaApprovazioneequalthis VARCHAR(255), 
	@CfIstruttoreequalthis VARCHAR(255), 
	@DataApprovazioneequalthis DATETIME, 
	@Annullataequalthis BIT, 
	@SegnaturaAnnullamentoequalthis VARCHAR(255), 
	@CfOperatoreAnnullamentoequalthis VARCHAR(255), 
	@DataAnnullamentoequalthis DATETIME, 
	@ValiditaVersioneAdcequalthis BIT, 
	@IdVariazioneAccertataequalthis INT, 
	@PredispostaAControlloequalthis BIT, 
	@DataPredisposizioneAControlloequalthis DATETIME, 
	@VisitaInsituEsitoequalthis VARCHAR(255), 
	@ControlloInlocoEsitoequalthis VARCHAR(255), 
	@VerificaPagamentiEsitoequalthis VARCHAR(255), 
	@VerificaPagamentiMessaggioequalthis VARCHAR(3000), 
	@VerificaPagamentiDataequalthis DATETIME, 
	@FirmaPredispostaequalthis BIT, 
	@InIntegrazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_DOMANDA_PAGAMENTO, COD_TIPO, ID_PROGETTO, DATA_INSERIMENTO, DATA_MODIFICA, COD_ENTE, SEGNATURA, DESCRIZIONE, COD_FASE, FASE, ORDINE, ID_FIDEJUSSIONE, OPERATORE, CF_OPERATORE, SEGNATURA_ALLEGATI, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, CF_ISTRUTTORE, DATA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VALUTAZIONE_ISTRUTTORE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, DATA_PREDISPOSIZIONE_A_CONTROLLO, NOMINATIVO_OPERATORE_ANNULLAMENTO, ISTRUTTORE, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE FROM vDOMANDA_DI_PAGAMENTO WHERE 1=1'';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)''; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_OPERATORE = @CfOperatoreequalthis)''; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_MODIFICA = @DataModificaequalthis)''; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE = @CodEnteequalthis)''; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA = @Segnaturaequalthis)''; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@SegnaturaAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis)''; set @lensql=@lensql+len(@SegnaturaAllegatiequalthis);end;
	IF (@IdFidejussioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FIDEJUSSIONE = @IdFidejussioneequalthis)''; set @lensql=@lensql+len(@IdFidejussioneequalthis);end;
	IF (@DataCertificazioneAntimafiaequalthis IS NOT NUL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoFindSelect';

