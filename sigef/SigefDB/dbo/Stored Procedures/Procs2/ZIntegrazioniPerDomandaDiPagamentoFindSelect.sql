CREATE PROCEDURE [dbo].[ZIntegrazioniPerDomandaDiPagamentoFindSelect]
(
	@IdIntegrazioneDomandaDiPagamentoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME, 
	@IntegrazioneCompletaequalthis BIT, 
	@NoteIntegrazioneDomandaequalthis VARCHAR(max), 
	@CfIstruttoreequalthis VARCHAR(255), 
	@DataRichiestaIntegrazioneDomandaequalthis DATETIME, 
	@SegnaturaIstruttoreequalthis VARCHAR(255), 
	@CfBenficiarioequalthis VARCHAR(255), 
	@SegnaturaBeneficiarioequalthis VARCHAR(255), 
	@DataConclusioneIntegrazioneequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO, DATA_MODIFICA, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, COD_TIPO, ID_PROGETTO, DATA_INSERIMENTO_DOMANDA, CF_OPERATORE_DOMANDA, DATA_MODIFICA_DOMANDA, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, ID_FIDEJUSSIONE, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, CF_ISTRUTTORE_DOMANDA, DATA_APPROVAZIONE, VALUTAZIONE_ISTRUTTORE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, DATA_PREDISPOSIZIONE_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE, ID_DOMANDA_PAGAMENTO_DOMANDA FROM VINTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO WHERE 1=1';
	IF (@IdIntegrazioneDomandaDiPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO = @IdIntegrazioneDomandaDiPagamentoequalthis)'; set @lensql=@lensql+len(@IdIntegrazioneDomandaDiPagamentoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@IntegrazioneCompletaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTEGRAZIONE_COMPLETA = @IntegrazioneCompletaequalthis)'; set @lensql=@lensql+len(@IntegrazioneCompletaequalthis);end;
	IF (@NoteIntegrazioneDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE_INTEGRAZIONE_DOMANDA = @NoteIntegrazioneDomandaequalthis)'; set @lensql=@lensql+len(@NoteIntegrazioneDomandaequalthis);end;
	IF (@CfIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_ISTRUTTORE = @CfIstruttoreequalthis)'; set @lensql=@lensql+len(@CfIstruttoreequalthis);end;
	IF (@DataRichiestaIntegrazioneDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RICHIESTA_INTEGRAZIONE_DOMANDA = @DataRichiestaIntegrazioneDomandaequalthis)'; set @lensql=@lensql+len(@DataRichiestaIntegrazioneDomandaequalthis);end;
	IF (@SegnaturaIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ISTRUTTORE = @SegnaturaIstruttoreequalthis)'; set @lensql=@lensql+len(@SegnaturaIstruttoreequalthis);end;
	IF (@CfBenficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_BENFICIARIO = @CfBenficiarioequalthis)'; set @lensql=@lensql+len(@CfBenficiarioequalthis);end;
	IF (@SegnaturaBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_BENEFICIARIO = @SegnaturaBeneficiarioequalthis)'; set @lensql=@lensql+len(@SegnaturaBeneficiarioequalthis);end;
	IF (@DataConclusioneIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CONCLUSIONE_INTEGRAZIONE = @DataConclusioneIntegrazioneequalthis)'; set @lensql=@lensql+len(@DataConclusioneIntegrazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdIntegrazioneDomandaDiPagamentoequalthis INT, @IdDomandaPagamentoequalthis INT, @DataInserimentoequalthis DATETIME, @DataModificaequalthis DATETIME, @IntegrazioneCompletaequalthis BIT, @NoteIntegrazioneDomandaequalthis VARCHAR(max), @CfIstruttoreequalthis VARCHAR(255), @DataRichiestaIntegrazioneDomandaequalthis DATETIME, @SegnaturaIstruttoreequalthis VARCHAR(255), @CfBenficiarioequalthis VARCHAR(255), @SegnaturaBeneficiarioequalthis VARCHAR(255), @DataConclusioneIntegrazioneequalthis DATETIME',@IdIntegrazioneDomandaDiPagamentoequalthis , @IdDomandaPagamentoequalthis , @DataInserimentoequalthis , @DataModificaequalthis , @IntegrazioneCompletaequalthis , @NoteIntegrazioneDomandaequalthis , @CfIstruttoreequalthis , @DataRichiestaIntegrazioneDomandaequalthis , @SegnaturaIstruttoreequalthis , @CfBenficiarioequalthis , @SegnaturaBeneficiarioequalthis , @DataConclusioneIntegrazioneequalthis ;
	else
		SELECT ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO, DATA_MODIFICA, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, COD_TIPO, ID_PROGETTO, DATA_INSERIMENTO_DOMANDA, CF_OPERATORE_DOMANDA, DATA_MODIFICA_DOMANDA, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, ID_FIDEJUSSIONE, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, CF_ISTRUTTORE_DOMANDA, DATA_APPROVAZIONE, VALUTAZIONE_ISTRUTTORE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, DATA_PREDISPOSIZIONE_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE, ID_DOMANDA_PAGAMENTO_DOMANDA
		FROM VINTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO
		WHERE 
			((@IdIntegrazioneDomandaDiPagamentoequalthis IS NULL) OR ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO = @IdIntegrazioneDomandaDiPagamentoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@IntegrazioneCompletaequalthis IS NULL) OR INTEGRAZIONE_COMPLETA = @IntegrazioneCompletaequalthis) AND 
			((@NoteIntegrazioneDomandaequalthis IS NULL) OR NOTE_INTEGRAZIONE_DOMANDA = @NoteIntegrazioneDomandaequalthis) AND 
			((@CfIstruttoreequalthis IS NULL) OR CF_ISTRUTTORE = @CfIstruttoreequalthis) AND 
			((@DataRichiestaIntegrazioneDomandaequalthis IS NULL) OR DATA_RICHIESTA_INTEGRAZIONE_DOMANDA = @DataRichiestaIntegrazioneDomandaequalthis) AND 
			((@SegnaturaIstruttoreequalthis IS NULL) OR SEGNATURA_ISTRUTTORE = @SegnaturaIstruttoreequalthis) AND 
			((@CfBenficiarioequalthis IS NULL) OR CF_BENFICIARIO = @CfBenficiarioequalthis) AND 
			((@SegnaturaBeneficiarioequalthis IS NULL) OR SEGNATURA_BENEFICIARIO = @SegnaturaBeneficiarioequalthis) AND 
			((@DataConclusioneIntegrazioneequalthis IS NULL) OR DATA_CONCLUSIONE_INTEGRAZIONE = @DataConclusioneIntegrazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIntegrazioniPerDomandaDiPagamentoFindSelect]
(
	@IdIntegrazioneDomandaDiPagamentoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME, 
	@IntegrazioneCompletaequalthis BIT, 
	@NoteIntegrazioneDomandaequalthis VARCHAR(255), 
	@CfIstruttoreequalthis VARCHAR(255), 
	@DataRichiestaIntegrazioneDomandaequalthis DATETIME, 
	@SegnaturaIstruttoreequalthis VARCHAR(255), 
	@CfBenficiarioequalthis VARCHAR(255), 
	@SegnaturaBeneficiarioequalthis VARCHAR(255), 
	@DataConclusioneIntegrazioneequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO, DATA_MODIFICA, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, ID_DOMANDA_PAGAMENTO_DOMANDA, COD_TIPO, ID_PROGETTO, DATA_INSERIMENTO_DOMANDA, CF_OPERATORE_DOMANDA, DATA_MODIFICA_DOMANDA, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, ID_FIDEJUSSIONE, DATA_CERTIFICAZIONE_ANTIMAFIA, APPROVATA, SEGNATURA_APPROVAZIONE, SEGNATURA_SECONDA_APPROVAZIONE, CF_ISTRUTTORE_DOMANDA, DATA_APPROVAZIONE, VALUTAZIONE_ISTRUTTORE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, VALIDITA_VERSIONE_ADC, ID_VARIAZIONE_ACCERTATA, PREDISPOSTA_A_CONTROLLO, DATA_PREDISPOSIZIONE_A_CONTROLLO, VISITA_INSITU_ESITO, VISITA_INSITU_NOTE, CONTROLLO_INLOCO_ESITO, CONTROLLO_INLOCO_NOTE, VERIFICA_PAGAMENTI_ESITO, VERIFICA_PAGAMENTI_MESSAGGIO, VERIFICA_PAGAMENTI_DATA, FIRMA_PREDISPOSTA, IN_INTEGRAZIONE FROM VINTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO WHERE 1=1'';
	IF (@IdIntegrazioneDomandaDiPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO = @IdIntegrazioneDomandaDiPagamentoequalthis)''; set @lensql=@lensql+len(@IdIntegrazioneDomandaDiPagamentoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)''; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_MODIFICA = @DataModificaequalthis)''; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@IntegrazioneCompletaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (INTEGRAZIONE_COMPLETA = @IntegrazioneCompletaequalthis)''; set @lensql=@lensql+len(@IntegrazioneCompletaequalthis);end;
	IF (@NoteIntegrazioneDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NOTE_INTEGRAZIONE_DOMANDA = @NoteIntegrazioneDomandaequalthis)''; set @lensql=@lensql+len(@NoteIntegrazioneDomandaequalthis);end;
	IF (@CfIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_ISTRUTTORE = @CfIstruttoreequalthis)''; set @lensql=@lensql+len(@CfIstruttoreequalthis);end;
	IF (@DataRichiestaIntegrazioneDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_RICHIESTA_INTEGRAZIONE_DOMANDA = @DataRichiestaIntegrazioneDomandaequalthis)''; set @lensql=@lensql+len(@DataRichiestaIntegrazioneDomandaequalthis);end;
	IF (@SegnaturaIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA_ISTRUTTORE = @SegnaturaIstruttoreequalthis)''; set @lensql=@lensql+len(@SegnaturaIstruttoreequalthis);end;
	IF (@CfBenficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_BENFICIARIO = @CfBenficiarioequalthis)''; set @lensql=@lensql+len(@CfBenficiarioequalthis);end;
	IF (@SegnaturaBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA_BENEFICIARIO = @SegnaturaBeneficiarioequalthis)''; set @lensql=@lensql+len(@SegnaturaBeneficiarioequal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIntegrazioniPerDomandaDiPagamentoFindSelect';

