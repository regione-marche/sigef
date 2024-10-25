CREATE PROCEDURE [dbo].[ZRegistroIrregolaritaFindSelect]
(
	@IdIrregolaritaequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@IdControlloOrigineequalthis INT, 
	@DescrizioneControlloEsternoequalthis VARCHAR(max), 
	@SegnalazioneOlafequalthis BIT, 
	@DataSegnalazioneequalthis DATETIME, 
	@TrimestreSegnalazioneequalthis VARCHAR(255), 
	@NumeroRiferimentoOlafequalthis VARCHAR(255), 
	@SospettoFrodeequalthis BIT, 
	@ImportoIrregolareCertificatoequalthis DECIMAL(15,2), 
	@ImportoIrregolareDaRecuperareequalthis DECIMAL(15,2), 
	@IdFondoequalthis INT, 
	@Annoequalthis INT, 
	@PeriodoProgrammazioneequalthis VARCHAR(500), 
	@NumeroRiferimentoNazionaleequalthis VARCHAR(255), 
	@DataCreazioneIdentificazioneequalthis DATETIME, 
	@TrimestreIdentificazioneequalthis VARCHAR(255), 
	@ProcedimentoAmministrativoequalthis BIT, 
	@AzioneGiudiziariaequalthis BIT, 
	@AzionePenaleequalthis BIT, 
	@IdStatoFinanziarioequalthis INT, 
	@DataPrimaInformazioneSospettoequalthis DATETIME, 
	@FontePrimaInformazioneSospettoequalthis VARCHAR(255), 
	@DataIrregolaritaequalthis DATETIME, 
	@DataIrregolaritaDaequalthis DATETIME, 
	@DataIrregolaritaAequalthis DATETIME, 
	@IdImpresaCommessaDaequalthis INT, 
	@NoteCommessaDaequalthis VARCHAR(max), 
	@CommessaAequalthis VARCHAR(max), 
	@IdCategoriaIrregolaritaequalthis INT, 
	@IdTipoIrregolaritaequalthis INT, 
	@ModusOperandiequalthis VARCHAR(max), 
	@DichiarazioneOperatoreequalthis VARCHAR(max), 
	@AccertamentiAmministratoreequalthis VARCHAR(max), 
	@IdClassificazioneIrregolaritaequalthis INT, 
	@DataPrimoAttoConstatazioneAmministrativoequalthis DATETIME, 
	@IdMotivoEsecuzioneControlloequalthis INT, 
	@IdTipoControlloequalthis INT, 
	@IdControlloPrimaDopoPagamentoequalthis INT, 
	@AutoritaControlloequalthis VARCHAR(255), 
	@IndagineOlafequalthis BIT, 
	@ImportoSpesaUeequalthis DECIMAL(15,2), 
	@ImportoSpesaNazionaleequalthis DECIMAL(15,2), 
	@ImportoSpesaPubblicoequalthis DECIMAL(15,2), 
	@ImportoSpesaPrivatoequalthis DECIMAL(15,2), 
	@ImportoSpesaTotaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaUeequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNazionaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPubblicoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPrivatoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaTotaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNonPagatoUeequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNonPagatoNazionaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNonPagatoPubblicoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNonPagatoPrivatoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNonPagatoTotaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPagatoUeequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPagatoNazionaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPagatoPubblicoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPagatoPrivatoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPagatoTotaleequalthis DECIMAL(15,2), 
	@ImportoDaRecuperareUeequalthis DECIMAL(15,2), 
	@ImportoDaRecuperareNazionaleequalthis DECIMAL(15,2), 
	@ImportoDaRecuperarePubblicoequalthis DECIMAL(15,2), 
	@ImportoDaRecuperarePrivatoequalthis DECIMAL(15,2), 
	@ImportoDaRecuperareTotaleequalthis DECIMAL(15,2), 
	@SpesaDecertificataequalthis BIT, 
	@CommentiImpattoFinanziarioequalthis VARCHAR(max), 
	@StabilitaOperazioniequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT SEGNALAZIONE_OLAF, DATA_SEGNALAZIONE, TRIMESTRE_SEGNALAZIONE, DATA_MODIFICA, CF_MODIFICA, DATA_INSERIMENTO, CF_INSERIMENTO, ID_PROGETTO, ID_IRREGOLARITA, NUMERO_RIFERIMENTO_OLAF, SOSPETTO_FRODE, IMPORTO_IRREGOLARE_CERTIFICATO, IMPORTO_IRREGOLARE_DA_RECUPERARE, ANNO, PERIODO_PROGRAMMAZIONE, NUMERO_RIFERIMENTO_NAZIONALE, AZIONE_PENALE, DATA_CREAZIONE_IDENTIFICAZIONE, TRIMESTRE_IDENTIFICAZIONE, PROCEDIMENTO_AMMINISTRATIVO, AZIONE_GIUDIZIARIA, DATA_PRIMA_INFORMAZIONE_SOSPETTO, FONTE_PRIMA_INFORMAZIONE_SOSPETTO, DATA_IRREGOLARITA, DATA_IRREGOLARITA_DA, DATA_IRREGOLARITA_A, COMMESSA_A, ID_CATEGORIA_IRREGOLARITA, ID_TIPO_IRREGOLARITA, MODUS_OPERANDI, DICHIARAZIONE_OPERATORE, ACCERTAMENTI_AMMINISTRATORE, ID_CLASSIFICAZIONE_IRREGOLARITA, DATA_PRIMO_ATTO_CONSTATAZIONE_AMMINISTRATIVO, ID_MOTIVO_ESECUZIONE_CONTROLLO, ID_TIPO_CONTROLLO, ID_CONTROLLO_PRIMA_DOPO_PAGAMENTO, AUTORITA_CONTROLLO, INDAGINE_OLAF, IMPORTO_SPESA_UE, IMPORTO_SPESA_NAZIONALE, IMPORTO_SPESA_PUBBLICO, IMPORTO_SPESA_PRIVATO, IMPORTO_SPESA_TOTALE, IMPORTO_IRREGOLARITA_UE, IMPORTO_IRREGOLARITA_NAZIONALE, IMPORTO_IRREGOLARITA_PUBBLICO, IMPORTO_IRREGOLARITA_PRIVATO, IMPORTO_IRREGOLARITA_TOTALE, IMPORTO_IRREGOLARITA_NON_PAGATO_UE, IMPORTO_IRREGOLARITA_NON_PAGATO_NAZIONALE, IMPORTO_IRREGOLARITA_NON_PAGATO_PUBBLICO, IMPORTO_IRREGOLARITA_NON_PAGATO_PRIVATO, IMPORTO_IRREGOLARITA_NON_PAGATO_TOTALE, IMPORTO_IRREGOLARITA_PAGATO_UE, IMPORTO_IRREGOLARITA_PAGATO_NAZIONALE, IMPORTO_IRREGOLARITA_PAGATO_PUBBLICO, IMPORTO_IRREGOLARITA_PAGATO_PRIVATO, IMPORTO_IRREGOLARITA_PAGATO_TOTALE, IMPORTO_DA_RECUPERARE_UE, IMPORTO_DA_RECUPERARE_NAZIONALE, IMPORTO_DA_RECUPERARE_PUBBLICO, IMPORTO_DA_RECUPERARE_PRIVATO, IMPORTO_DA_RECUPERARE_TOTALE, SPESA_DECERTIFICATA, COMMENTI_IMPATTO_FINANZIARIO, ID_BANDO, COD_AGEA, SEGNATURA_ALLEGATI, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, FIRMA_PREDISPOSTA, ID_FONDO, ID_CONTROLLO_ORIGINE, ID_STATO_FINANZIARIO, DESCRIZIONE_CONTROLLO_ESTERNO, ID_IMPRESA_COMMESSA_DA, NOTE_COMMESSA_DA, STABILITA_OPERAZIONI, ID_DOMANDA_PAGAMENTO, ID_IMPRESA_PROGETTO FROM VREGISTRO_IRREGOLARITA WHERE 1=1';
	IF (@IdIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IRREGOLARITA = @IdIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdIrregolaritaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@IdControlloOrigineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTROLLO_ORIGINE = @IdControlloOrigineequalthis)'; set @lensql=@lensql+len(@IdControlloOrigineequalthis);end;
	IF (@DescrizioneControlloEsternoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_CONTROLLO_ESTERNO = @DescrizioneControlloEsternoequalthis)'; set @lensql=@lensql+len(@DescrizioneControlloEsternoequalthis);end;
	IF (@SegnalazioneOlafequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNALAZIONE_OLAF = @SegnalazioneOlafequalthis)'; set @lensql=@lensql+len(@SegnalazioneOlafequalthis);end;
	IF (@DataSegnalazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SEGNALAZIONE = @DataSegnalazioneequalthis)'; set @lensql=@lensql+len(@DataSegnalazioneequalthis);end;
	IF (@TrimestreSegnalazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TRIMESTRE_SEGNALAZIONE = @TrimestreSegnalazioneequalthis)'; set @lensql=@lensql+len(@TrimestreSegnalazioneequalthis);end;
	IF (@NumeroRiferimentoOlafequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_RIFERIMENTO_OLAF = @NumeroRiferimentoOlafequalthis)'; set @lensql=@lensql+len(@NumeroRiferimentoOlafequalthis);end;
	IF (@SospettoFrodeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SOSPETTO_FRODE = @SospettoFrodeequalthis)'; set @lensql=@lensql+len(@SospettoFrodeequalthis);end;
	IF (@ImportoIrregolareCertificatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARE_CERTIFICATO = @ImportoIrregolareCertificatoequalthis)'; set @lensql=@lensql+len(@ImportoIrregolareCertificatoequalthis);end;
	IF (@ImportoIrregolareDaRecuperareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARE_DA_RECUPERARE = @ImportoIrregolareDaRecuperareequalthis)'; set @lensql=@lensql+len(@ImportoIrregolareDaRecuperareequalthis);end;
	IF (@IdFondoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FONDO = @IdFondoequalthis)'; set @lensql=@lensql+len(@IdFondoequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@PeriodoProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PERIODO_PROGRAMMAZIONE = @PeriodoProgrammazioneequalthis)'; set @lensql=@lensql+len(@PeriodoProgrammazioneequalthis);end;
	IF (@NumeroRiferimentoNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_RIFERIMENTO_NAZIONALE = @NumeroRiferimentoNazionaleequalthis)'; set @lensql=@lensql+len(@NumeroRiferimentoNazionaleequalthis);end;
	IF (@DataCreazioneIdentificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CREAZIONE_IDENTIFICAZIONE = @DataCreazioneIdentificazioneequalthis)'; set @lensql=@lensql+len(@DataCreazioneIdentificazioneequalthis);end;
	IF (@TrimestreIdentificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TRIMESTRE_IDENTIFICAZIONE = @TrimestreIdentificazioneequalthis)'; set @lensql=@lensql+len(@TrimestreIdentificazioneequalthis);end;
	IF (@ProcedimentoAmministrativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROCEDIMENTO_AMMINISTRATIVO = @ProcedimentoAmministrativoequalthis)'; set @lensql=@lensql+len(@ProcedimentoAmministrativoequalthis);end;
	IF (@AzioneGiudiziariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AZIONE_GIUDIZIARIA = @AzioneGiudiziariaequalthis)'; set @lensql=@lensql+len(@AzioneGiudiziariaequalthis);end;
	IF (@AzionePenaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AZIONE_PENALE = @AzionePenaleequalthis)'; set @lensql=@lensql+len(@AzionePenaleequalthis);end;
	IF (@IdStatoFinanziarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STATO_FINANZIARIO = @IdStatoFinanziarioequalthis)'; set @lensql=@lensql+len(@IdStatoFinanziarioequalthis);end;
	IF (@DataPrimaInformazioneSospettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PRIMA_INFORMAZIONE_SOSPETTO = @DataPrimaInformazioneSospettoequalthis)'; set @lensql=@lensql+len(@DataPrimaInformazioneSospettoequalthis);end;
	IF (@FontePrimaInformazioneSospettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FONTE_PRIMA_INFORMAZIONE_SOSPETTO = @FontePrimaInformazioneSospettoequalthis)'; set @lensql=@lensql+len(@FontePrimaInformazioneSospettoequalthis);end;
	IF (@DataIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_IRREGOLARITA = @DataIrregolaritaequalthis)'; set @lensql=@lensql+len(@DataIrregolaritaequalthis);end;
	IF (@DataIrregolaritaDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_IRREGOLARITA_DA = @DataIrregolaritaDaequalthis)'; set @lensql=@lensql+len(@DataIrregolaritaDaequalthis);end;
	IF (@DataIrregolaritaAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_IRREGOLARITA_A = @DataIrregolaritaAequalthis)'; set @lensql=@lensql+len(@DataIrregolaritaAequalthis);end;
	IF (@IdImpresaCommessaDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA_COMMESSA_DA = @IdImpresaCommessaDaequalthis)'; set @lensql=@lensql+len(@IdImpresaCommessaDaequalthis);end;
	IF (@NoteCommessaDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE_COMMESSA_DA = @NoteCommessaDaequalthis)'; set @lensql=@lensql+len(@NoteCommessaDaequalthis);end;
	IF (@CommessaAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COMMESSA_A = @CommessaAequalthis)'; set @lensql=@lensql+len(@CommessaAequalthis);end;
	IF (@IdCategoriaIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CATEGORIA_IRREGOLARITA = @IdCategoriaIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdCategoriaIrregolaritaequalthis);end;
	IF (@IdTipoIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_IRREGOLARITA = @IdTipoIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdTipoIrregolaritaequalthis);end;
	IF (@ModusOperandiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MODUS_OPERANDI = @ModusOperandiequalthis)'; set @lensql=@lensql+len(@ModusOperandiequalthis);end;
	IF (@DichiarazioneOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DICHIARAZIONE_OPERATORE = @DichiarazioneOperatoreequalthis)'; set @lensql=@lensql+len(@DichiarazioneOperatoreequalthis);end;
	IF (@AccertamentiAmministratoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ACCERTAMENTI_AMMINISTRATORE = @AccertamentiAmministratoreequalthis)'; set @lensql=@lensql+len(@AccertamentiAmministratoreequalthis);end;
	IF (@IdClassificazioneIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CLASSIFICAZIONE_IRREGOLARITA = @IdClassificazioneIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdClassificazioneIrregolaritaequalthis);end;
	IF (@DataPrimoAttoConstatazioneAmministrativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PRIMO_ATTO_CONSTATAZIONE_AMMINISTRATIVO = @DataPrimoAttoConstatazioneAmministrativoequalthis)'; set @lensql=@lensql+len(@DataPrimoAttoConstatazioneAmministrativoequalthis);end;
	IF (@IdMotivoEsecuzioneControlloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MOTIVO_ESECUZIONE_CONTROLLO = @IdMotivoEsecuzioneControlloequalthis)'; set @lensql=@lensql+len(@IdMotivoEsecuzioneControlloequalthis);end;
	IF (@IdTipoControlloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_CONTROLLO = @IdTipoControlloequalthis)'; set @lensql=@lensql+len(@IdTipoControlloequalthis);end;
	IF (@IdControlloPrimaDopoPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTROLLO_PRIMA_DOPO_PAGAMENTO = @IdControlloPrimaDopoPagamentoequalthis)'; set @lensql=@lensql+len(@IdControlloPrimaDopoPagamentoequalthis);end;
	IF (@AutoritaControlloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AUTORITA_CONTROLLO = @AutoritaControlloequalthis)'; set @lensql=@lensql+len(@AutoritaControlloequalthis);end;
	IF (@IndagineOlafequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INDAGINE_OLAF = @IndagineOlafequalthis)'; set @lensql=@lensql+len(@IndagineOlafequalthis);end;
	IF (@ImportoSpesaUeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SPESA_UE = @ImportoSpesaUeequalthis)'; set @lensql=@lensql+len(@ImportoSpesaUeequalthis);end;
	IF (@ImportoSpesaNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SPESA_NAZIONALE = @ImportoSpesaNazionaleequalthis)'; set @lensql=@lensql+len(@ImportoSpesaNazionaleequalthis);end;
	IF (@ImportoSpesaPubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SPESA_PUBBLICO = @ImportoSpesaPubblicoequalthis)'; set @lensql=@lensql+len(@ImportoSpesaPubblicoequalthis);end;
	IF (@ImportoSpesaPrivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SPESA_PRIVATO = @ImportoSpesaPrivatoequalthis)'; set @lensql=@lensql+len(@ImportoSpesaPrivatoequalthis);end;
	IF (@ImportoSpesaTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SPESA_TOTALE = @ImportoSpesaTotaleequalthis)'; set @lensql=@lensql+len(@ImportoSpesaTotaleequalthis);end;
	IF (@ImportoIrregolaritaUeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_UE = @ImportoIrregolaritaUeequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaUeequalthis);end;
	IF (@ImportoIrregolaritaNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_NAZIONALE = @ImportoIrregolaritaNazionaleequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaNazionaleequalthis);end;
	IF (@ImportoIrregolaritaPubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_PUBBLICO = @ImportoIrregolaritaPubblicoequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaPubblicoequalthis);end;
	IF (@ImportoIrregolaritaPrivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_PRIVATO = @ImportoIrregolaritaPrivatoequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaPrivatoequalthis);end;
	IF (@ImportoIrregolaritaTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_TOTALE = @ImportoIrregolaritaTotaleequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaTotaleequalthis);end;
	IF (@ImportoIrregolaritaNonPagatoUeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_NON_PAGATO_UE = @ImportoIrregolaritaNonPagatoUeequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaNonPagatoUeequalthis);end;
	IF (@ImportoIrregolaritaNonPagatoNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_NON_PAGATO_NAZIONALE = @ImportoIrregolaritaNonPagatoNazionaleequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaNonPagatoNazionaleequalthis);end;
	IF (@ImportoIrregolaritaNonPagatoPubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_NON_PAGATO_PUBBLICO = @ImportoIrregolaritaNonPagatoPubblicoequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaNonPagatoPubblicoequalthis);end;
	IF (@ImportoIrregolaritaNonPagatoPrivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_NON_PAGATO_PRIVATO = @ImportoIrregolaritaNonPagatoPrivatoequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaNonPagatoPrivatoequalthis);end;
	IF (@ImportoIrregolaritaNonPagatoTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_NON_PAGATO_TOTALE = @ImportoIrregolaritaNonPagatoTotaleequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaNonPagatoTotaleequalthis);end;
	IF (@ImportoIrregolaritaPagatoUeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_PAGATO_UE = @ImportoIrregolaritaPagatoUeequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaPagatoUeequalthis);end;
	IF (@ImportoIrregolaritaPagatoNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_PAGATO_NAZIONALE = @ImportoIrregolaritaPagatoNazionaleequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaPagatoNazionaleequalthis);end;
	IF (@ImportoIrregolaritaPagatoPubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_PAGATO_PUBBLICO = @ImportoIrregolaritaPagatoPubblicoequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaPagatoPubblicoequalthis);end;
	IF (@ImportoIrregolaritaPagatoPrivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_PAGATO_PRIVATO = @ImportoIrregolaritaPagatoPrivatoequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaPagatoPrivatoequalthis);end;
	IF (@ImportoIrregolaritaPagatoTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARITA_PAGATO_TOTALE = @ImportoIrregolaritaPagatoTotaleequalthis)'; set @lensql=@lensql+len(@ImportoIrregolaritaPagatoTotaleequalthis);end;
	IF (@ImportoDaRecuperareUeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE_UE = @ImportoDaRecuperareUeequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperareUeequalthis);end;
	IF (@ImportoDaRecuperareNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE_NAZIONALE = @ImportoDaRecuperareNazionaleequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperareNazionaleequalthis);end;
	IF (@ImportoDaRecuperarePubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE_PUBBLICO = @ImportoDaRecuperarePubblicoequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperarePubblicoequalthis);end;
	IF (@ImportoDaRecuperarePrivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE_PRIVATO = @ImportoDaRecuperarePrivatoequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperarePrivatoequalthis);end;
	IF (@ImportoDaRecuperareTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE_TOTALE = @ImportoDaRecuperareTotaleequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperareTotaleequalthis);end;
	IF (@SpesaDecertificataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESA_DECERTIFICATA = @SpesaDecertificataequalthis)'; set @lensql=@lensql+len(@SpesaDecertificataequalthis);end;
	IF (@CommentiImpattoFinanziarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COMMENTI_IMPATTO_FINANZIARIO = @CommentiImpattoFinanziarioequalthis)'; set @lensql=@lensql+len(@CommentiImpattoFinanziarioequalthis);end;
	IF (@StabilitaOperazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STABILITA_OPERAZIONI = @StabilitaOperazioniequalthis)'; set @lensql=@lensql+len(@StabilitaOperazioniequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdIrregolaritaequalthis INT, @IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @CfInserimentoequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @IdControlloOrigineequalthis INT, @DescrizioneControlloEsternoequalthis VARCHAR(max), @SegnalazioneOlafequalthis BIT, @DataSegnalazioneequalthis DATETIME, @TrimestreSegnalazioneequalthis VARCHAR(255), @NumeroRiferimentoOlafequalthis VARCHAR(255), @SospettoFrodeequalthis BIT, @ImportoIrregolareCertificatoequalthis DECIMAL(15,2), @ImportoIrregolareDaRecuperareequalthis DECIMAL(15,2), @IdFondoequalthis INT, @Annoequalthis INT, @PeriodoProgrammazioneequalthis VARCHAR(500), @NumeroRiferimentoNazionaleequalthis VARCHAR(255), @DataCreazioneIdentificazioneequalthis DATETIME, @TrimestreIdentificazioneequalthis VARCHAR(255), @ProcedimentoAmministrativoequalthis BIT, @AzioneGiudiziariaequalthis BIT, @AzionePenaleequalthis BIT, @IdStatoFinanziarioequalthis INT, @DataPrimaInformazioneSospettoequalthis DATETIME, @FontePrimaInformazioneSospettoequalthis VARCHAR(255), @DataIrregolaritaequalthis DATETIME, @DataIrregolaritaDaequalthis DATETIME, @DataIrregolaritaAequalthis DATETIME, @IdImpresaCommessaDaequalthis INT, @NoteCommessaDaequalthis VARCHAR(max), @CommessaAequalthis VARCHAR(max), @IdCategoriaIrregolaritaequalthis INT, @IdTipoIrregolaritaequalthis INT, @ModusOperandiequalthis VARCHAR(max), @DichiarazioneOperatoreequalthis VARCHAR(max), @AccertamentiAmministratoreequalthis VARCHAR(max), @IdClassificazioneIrregolaritaequalthis INT, @DataPrimoAttoConstatazioneAmministrativoequalthis DATETIME, @IdMotivoEsecuzioneControlloequalthis INT, @IdTipoControlloequalthis INT, @IdControlloPrimaDopoPagamentoequalthis INT, @AutoritaControlloequalthis VARCHAR(255), @IndagineOlafequalthis BIT, @ImportoSpesaUeequalthis DECIMAL(15,2), @ImportoSpesaNazionaleequalthis DECIMAL(15,2), @ImportoSpesaPubblicoequalthis DECIMAL(15,2), @ImportoSpesaPrivatoequalthis DECIMAL(15,2), @ImportoSpesaTotaleequalthis DECIMAL(15,2), @ImportoIrregolaritaUeequalthis DECIMAL(15,2), @ImportoIrregolaritaNazionaleequalthis DECIMAL(15,2), @ImportoIrregolaritaPubblicoequalthis DECIMAL(15,2), @ImportoIrregolaritaPrivatoequalthis DECIMAL(15,2), @ImportoIrregolaritaTotaleequalthis DECIMAL(15,2), @ImportoIrregolaritaNonPagatoUeequalthis DECIMAL(15,2), @ImportoIrregolaritaNonPagatoNazionaleequalthis DECIMAL(15,2), @ImportoIrregolaritaNonPagatoPubblicoequalthis DECIMAL(15,2), @ImportoIrregolaritaNonPagatoPrivatoequalthis DECIMAL(15,2), @ImportoIrregolaritaNonPagatoTotaleequalthis DECIMAL(15,2), @ImportoIrregolaritaPagatoUeequalthis DECIMAL(15,2), @ImportoIrregolaritaPagatoNazionaleequalthis DECIMAL(15,2), @ImportoIrregolaritaPagatoPubblicoequalthis DECIMAL(15,2), @ImportoIrregolaritaPagatoPrivatoequalthis DECIMAL(15,2), @ImportoIrregolaritaPagatoTotaleequalthis DECIMAL(15,2), @ImportoDaRecuperareUeequalthis DECIMAL(15,2), @ImportoDaRecuperareNazionaleequalthis DECIMAL(15,2), @ImportoDaRecuperarePubblicoequalthis DECIMAL(15,2), @ImportoDaRecuperarePrivatoequalthis DECIMAL(15,2), @ImportoDaRecuperareTotaleequalthis DECIMAL(15,2), @SpesaDecertificataequalthis BIT, @CommentiImpattoFinanziarioequalthis VARCHAR(max), @StabilitaOperazioniequalthis BIT',@IdIrregolaritaequalthis , @IdProgettoequalthis , @IdDomandaPagamentoequalthis , @CfInserimentoequalthis , @DataInserimentoequalthis , @CfModificaequalthis , @DataModificaequalthis , @IdControlloOrigineequalthis , @DescrizioneControlloEsternoequalthis , @SegnalazioneOlafequalthis , @DataSegnalazioneequalthis , @TrimestreSegnalazioneequalthis , @NumeroRiferimentoOlafequalthis , @SospettoFrodeequalthis , @ImportoIrregolareCertificatoequalthis , @ImportoIrregolareDaRecuperareequalthis , @IdFondoequalthis , @Annoequalthis , @PeriodoProgrammazioneequalthis , @NumeroRiferimentoNazionaleequalthis , @DataCreazioneIdentificazioneequalthis , @TrimestreIdentificazioneequalthis , @ProcedimentoAmministrativoequalthis , @AzioneGiudiziariaequalthis , @AzionePenaleequalthis , @IdStatoFinanziarioequalthis , @DataPrimaInformazioneSospettoequalthis , @FontePrimaInformazioneSospettoequalthis , @DataIrregolaritaequalthis , @DataIrregolaritaDaequalthis , @DataIrregolaritaAequalthis , @IdImpresaCommessaDaequalthis , @NoteCommessaDaequalthis , @CommessaAequalthis , @IdCategoriaIrregolaritaequalthis , @IdTipoIrregolaritaequalthis , @ModusOperandiequalthis , @DichiarazioneOperatoreequalthis , @AccertamentiAmministratoreequalthis , @IdClassificazioneIrregolaritaequalthis , @DataPrimoAttoConstatazioneAmministrativoequalthis , @IdMotivoEsecuzioneControlloequalthis , @IdTipoControlloequalthis , @IdControlloPrimaDopoPagamentoequalthis , @AutoritaControlloequalthis , @IndagineOlafequalthis , @ImportoSpesaUeequalthis , @ImportoSpesaNazionaleequalthis , @ImportoSpesaPubblicoequalthis , @ImportoSpesaPrivatoequalthis , @ImportoSpesaTotaleequalthis , @ImportoIrregolaritaUeequalthis , @ImportoIrregolaritaNazionaleequalthis , @ImportoIrregolaritaPubblicoequalthis , @ImportoIrregolaritaPrivatoequalthis , @ImportoIrregolaritaTotaleequalthis , @ImportoIrregolaritaNonPagatoUeequalthis , @ImportoIrregolaritaNonPagatoNazionaleequalthis , @ImportoIrregolaritaNonPagatoPubblicoequalthis , @ImportoIrregolaritaNonPagatoPrivatoequalthis , @ImportoIrregolaritaNonPagatoTotaleequalthis , @ImportoIrregolaritaPagatoUeequalthis , @ImportoIrregolaritaPagatoNazionaleequalthis , @ImportoIrregolaritaPagatoPubblicoequalthis , @ImportoIrregolaritaPagatoPrivatoequalthis , @ImportoIrregolaritaPagatoTotaleequalthis , @ImportoDaRecuperareUeequalthis , @ImportoDaRecuperareNazionaleequalthis , @ImportoDaRecuperarePubblicoequalthis , @ImportoDaRecuperarePrivatoequalthis , @ImportoDaRecuperareTotaleequalthis , @SpesaDecertificataequalthis , @CommentiImpattoFinanziarioequalthis , @StabilitaOperazioniequalthis ;
	else
		SELECT SEGNALAZIONE_OLAF, DATA_SEGNALAZIONE, TRIMESTRE_SEGNALAZIONE, DATA_MODIFICA, CF_MODIFICA, DATA_INSERIMENTO, CF_INSERIMENTO, ID_PROGETTO, ID_IRREGOLARITA, NUMERO_RIFERIMENTO_OLAF, SOSPETTO_FRODE, IMPORTO_IRREGOLARE_CERTIFICATO, IMPORTO_IRREGOLARE_DA_RECUPERARE, ANNO, PERIODO_PROGRAMMAZIONE, NUMERO_RIFERIMENTO_NAZIONALE, AZIONE_PENALE, DATA_CREAZIONE_IDENTIFICAZIONE, TRIMESTRE_IDENTIFICAZIONE, PROCEDIMENTO_AMMINISTRATIVO, AZIONE_GIUDIZIARIA, DATA_PRIMA_INFORMAZIONE_SOSPETTO, FONTE_PRIMA_INFORMAZIONE_SOSPETTO, DATA_IRREGOLARITA, DATA_IRREGOLARITA_DA, DATA_IRREGOLARITA_A, COMMESSA_A, ID_CATEGORIA_IRREGOLARITA, ID_TIPO_IRREGOLARITA, MODUS_OPERANDI, DICHIARAZIONE_OPERATORE, ACCERTAMENTI_AMMINISTRATORE, ID_CLASSIFICAZIONE_IRREGOLARITA, DATA_PRIMO_ATTO_CONSTATAZIONE_AMMINISTRATIVO, ID_MOTIVO_ESECUZIONE_CONTROLLO, ID_TIPO_CONTROLLO, ID_CONTROLLO_PRIMA_DOPO_PAGAMENTO, AUTORITA_CONTROLLO, INDAGINE_OLAF, IMPORTO_SPESA_UE, IMPORTO_SPESA_NAZIONALE, IMPORTO_SPESA_PUBBLICO, IMPORTO_SPESA_PRIVATO, IMPORTO_SPESA_TOTALE, IMPORTO_IRREGOLARITA_UE, IMPORTO_IRREGOLARITA_NAZIONALE, IMPORTO_IRREGOLARITA_PUBBLICO, IMPORTO_IRREGOLARITA_PRIVATO, IMPORTO_IRREGOLARITA_TOTALE, IMPORTO_IRREGOLARITA_NON_PAGATO_UE, IMPORTO_IRREGOLARITA_NON_PAGATO_NAZIONALE, IMPORTO_IRREGOLARITA_NON_PAGATO_PUBBLICO, IMPORTO_IRREGOLARITA_NON_PAGATO_PRIVATO, IMPORTO_IRREGOLARITA_NON_PAGATO_TOTALE, IMPORTO_IRREGOLARITA_PAGATO_UE, IMPORTO_IRREGOLARITA_PAGATO_NAZIONALE, IMPORTO_IRREGOLARITA_PAGATO_PUBBLICO, IMPORTO_IRREGOLARITA_PAGATO_PRIVATO, IMPORTO_IRREGOLARITA_PAGATO_TOTALE, IMPORTO_DA_RECUPERARE_UE, IMPORTO_DA_RECUPERARE_NAZIONALE, IMPORTO_DA_RECUPERARE_PUBBLICO, IMPORTO_DA_RECUPERARE_PRIVATO, IMPORTO_DA_RECUPERARE_TOTALE, SPESA_DECERTIFICATA, COMMENTI_IMPATTO_FINANZIARIO, ID_BANDO, COD_AGEA, SEGNATURA_ALLEGATI, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, FIRMA_PREDISPOSTA, ID_FONDO, ID_CONTROLLO_ORIGINE, ID_STATO_FINANZIARIO, DESCRIZIONE_CONTROLLO_ESTERNO, ID_IMPRESA_COMMESSA_DA, NOTE_COMMESSA_DA, STABILITA_OPERAZIONI, ID_DOMANDA_PAGAMENTO, ID_IMPRESA_PROGETTO
		FROM VREGISTRO_IRREGOLARITA
		WHERE 
			((@IdIrregolaritaequalthis IS NULL) OR ID_IRREGOLARITA = @IdIrregolaritaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@IdControlloOrigineequalthis IS NULL) OR ID_CONTROLLO_ORIGINE = @IdControlloOrigineequalthis) AND 
			((@DescrizioneControlloEsternoequalthis IS NULL) OR DESCRIZIONE_CONTROLLO_ESTERNO = @DescrizioneControlloEsternoequalthis) AND 
			((@SegnalazioneOlafequalthis IS NULL) OR SEGNALAZIONE_OLAF = @SegnalazioneOlafequalthis) AND 
			((@DataSegnalazioneequalthis IS NULL) OR DATA_SEGNALAZIONE = @DataSegnalazioneequalthis) AND 
			((@TrimestreSegnalazioneequalthis IS NULL) OR TRIMESTRE_SEGNALAZIONE = @TrimestreSegnalazioneequalthis) AND 
			((@NumeroRiferimentoOlafequalthis IS NULL) OR NUMERO_RIFERIMENTO_OLAF = @NumeroRiferimentoOlafequalthis) AND 
			((@SospettoFrodeequalthis IS NULL) OR SOSPETTO_FRODE = @SospettoFrodeequalthis) AND 
			((@ImportoIrregolareCertificatoequalthis IS NULL) OR IMPORTO_IRREGOLARE_CERTIFICATO = @ImportoIrregolareCertificatoequalthis) AND 
			((@ImportoIrregolareDaRecuperareequalthis IS NULL) OR IMPORTO_IRREGOLARE_DA_RECUPERARE = @ImportoIrregolareDaRecuperareequalthis) AND 
			((@IdFondoequalthis IS NULL) OR ID_FONDO = @IdFondoequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@PeriodoProgrammazioneequalthis IS NULL) OR PERIODO_PROGRAMMAZIONE = @PeriodoProgrammazioneequalthis) AND 
			((@NumeroRiferimentoNazionaleequalthis IS NULL) OR NUMERO_RIFERIMENTO_NAZIONALE = @NumeroRiferimentoNazionaleequalthis) AND 
			((@DataCreazioneIdentificazioneequalthis IS NULL) OR DATA_CREAZIONE_IDENTIFICAZIONE = @DataCreazioneIdentificazioneequalthis) AND 
			((@TrimestreIdentificazioneequalthis IS NULL) OR TRIMESTRE_IDENTIFICAZIONE = @TrimestreIdentificazioneequalthis) AND 
			((@ProcedimentoAmministrativoequalthis IS NULL) OR PROCEDIMENTO_AMMINISTRATIVO = @ProcedimentoAmministrativoequalthis) AND 
			((@AzioneGiudiziariaequalthis IS NULL) OR AZIONE_GIUDIZIARIA = @AzioneGiudiziariaequalthis) AND 
			((@AzionePenaleequalthis IS NULL) OR AZIONE_PENALE = @AzionePenaleequalthis) AND 
			((@IdStatoFinanziarioequalthis IS NULL) OR ID_STATO_FINANZIARIO = @IdStatoFinanziarioequalthis) AND 
			((@DataPrimaInformazioneSospettoequalthis IS NULL) OR DATA_PRIMA_INFORMAZIONE_SOSPETTO = @DataPrimaInformazioneSospettoequalthis) AND 
			((@FontePrimaInformazioneSospettoequalthis IS NULL) OR FONTE_PRIMA_INFORMAZIONE_SOSPETTO = @FontePrimaInformazioneSospettoequalthis) AND 
			((@DataIrregolaritaequalthis IS NULL) OR DATA_IRREGOLARITA = @DataIrregolaritaequalthis) AND 
			((@DataIrregolaritaDaequalthis IS NULL) OR DATA_IRREGOLARITA_DA = @DataIrregolaritaDaequalthis) AND 
			((@DataIrregolaritaAequalthis IS NULL) OR DATA_IRREGOLARITA_A = @DataIrregolaritaAequalthis) AND 
			((@IdImpresaCommessaDaequalthis IS NULL) OR ID_IMPRESA_COMMESSA_DA = @IdImpresaCommessaDaequalthis) AND 
			((@NoteCommessaDaequalthis IS NULL) OR NOTE_COMMESSA_DA = @NoteCommessaDaequalthis) AND 
			((@CommessaAequalthis IS NULL) OR COMMESSA_A = @CommessaAequalthis) AND 
			((@IdCategoriaIrregolaritaequalthis IS NULL) OR ID_CATEGORIA_IRREGOLARITA = @IdCategoriaIrregolaritaequalthis) AND 
			((@IdTipoIrregolaritaequalthis IS NULL) OR ID_TIPO_IRREGOLARITA = @IdTipoIrregolaritaequalthis) AND 
			((@ModusOperandiequalthis IS NULL) OR MODUS_OPERANDI = @ModusOperandiequalthis) AND 
			((@DichiarazioneOperatoreequalthis IS NULL) OR DICHIARAZIONE_OPERATORE = @DichiarazioneOperatoreequalthis) AND 
			((@AccertamentiAmministratoreequalthis IS NULL) OR ACCERTAMENTI_AMMINISTRATORE = @AccertamentiAmministratoreequalthis) AND 
			((@IdClassificazioneIrregolaritaequalthis IS NULL) OR ID_CLASSIFICAZIONE_IRREGOLARITA = @IdClassificazioneIrregolaritaequalthis) AND 
			((@DataPrimoAttoConstatazioneAmministrativoequalthis IS NULL) OR DATA_PRIMO_ATTO_CONSTATAZIONE_AMMINISTRATIVO = @DataPrimoAttoConstatazioneAmministrativoequalthis) AND 
			((@IdMotivoEsecuzioneControlloequalthis IS NULL) OR ID_MOTIVO_ESECUZIONE_CONTROLLO = @IdMotivoEsecuzioneControlloequalthis) AND 
			((@IdTipoControlloequalthis IS NULL) OR ID_TIPO_CONTROLLO = @IdTipoControlloequalthis) AND 
			((@IdControlloPrimaDopoPagamentoequalthis IS NULL) OR ID_CONTROLLO_PRIMA_DOPO_PAGAMENTO = @IdControlloPrimaDopoPagamentoequalthis) AND 
			((@AutoritaControlloequalthis IS NULL) OR AUTORITA_CONTROLLO = @AutoritaControlloequalthis) AND 
			((@IndagineOlafequalthis IS NULL) OR INDAGINE_OLAF = @IndagineOlafequalthis) AND 
			((@ImportoSpesaUeequalthis IS NULL) OR IMPORTO_SPESA_UE = @ImportoSpesaUeequalthis) AND 
			((@ImportoSpesaNazionaleequalthis IS NULL) OR IMPORTO_SPESA_NAZIONALE = @ImportoSpesaNazionaleequalthis) AND 
			((@ImportoSpesaPubblicoequalthis IS NULL) OR IMPORTO_SPESA_PUBBLICO = @ImportoSpesaPubblicoequalthis) AND 
			((@ImportoSpesaPrivatoequalthis IS NULL) OR IMPORTO_SPESA_PRIVATO = @ImportoSpesaPrivatoequalthis) AND 
			((@ImportoSpesaTotaleequalthis IS NULL) OR IMPORTO_SPESA_TOTALE = @ImportoSpesaTotaleequalthis) AND 
			((@ImportoIrregolaritaUeequalthis IS NULL) OR IMPORTO_IRREGOLARITA_UE = @ImportoIrregolaritaUeequalthis) AND 
			((@ImportoIrregolaritaNazionaleequalthis IS NULL) OR IMPORTO_IRREGOLARITA_NAZIONALE = @ImportoIrregolaritaNazionaleequalthis) AND 
			((@ImportoIrregolaritaPubblicoequalthis IS NULL) OR IMPORTO_IRREGOLARITA_PUBBLICO = @ImportoIrregolaritaPubblicoequalthis) AND 
			((@ImportoIrregolaritaPrivatoequalthis IS NULL) OR IMPORTO_IRREGOLARITA_PRIVATO = @ImportoIrregolaritaPrivatoequalthis) AND 
			((@ImportoIrregolaritaTotaleequalthis IS NULL) OR IMPORTO_IRREGOLARITA_TOTALE = @ImportoIrregolaritaTotaleequalthis) AND 
			((@ImportoIrregolaritaNonPagatoUeequalthis IS NULL) OR IMPORTO_IRREGOLARITA_NON_PAGATO_UE = @ImportoIrregolaritaNonPagatoUeequalthis) AND 
			((@ImportoIrregolaritaNonPagatoNazionaleequalthis IS NULL) OR IMPORTO_IRREGOLARITA_NON_PAGATO_NAZIONALE = @ImportoIrregolaritaNonPagatoNazionaleequalthis) AND 
			((@ImportoIrregolaritaNonPagatoPubblicoequalthis IS NULL) OR IMPORTO_IRREGOLARITA_NON_PAGATO_PUBBLICO = @ImportoIrregolaritaNonPagatoPubblicoequalthis) AND 
			((@ImportoIrregolaritaNonPagatoPrivatoequalthis IS NULL) OR IMPORTO_IRREGOLARITA_NON_PAGATO_PRIVATO = @ImportoIrregolaritaNonPagatoPrivatoequalthis) AND 
			((@ImportoIrregolaritaNonPagatoTotaleequalthis IS NULL) OR IMPORTO_IRREGOLARITA_NON_PAGATO_TOTALE = @ImportoIrregolaritaNonPagatoTotaleequalthis) AND 
			((@ImportoIrregolaritaPagatoUeequalthis IS NULL) OR IMPORTO_IRREGOLARITA_PAGATO_UE = @ImportoIrregolaritaPagatoUeequalthis) AND 
			((@ImportoIrregolaritaPagatoNazionaleequalthis IS NULL) OR IMPORTO_IRREGOLARITA_PAGATO_NAZIONALE = @ImportoIrregolaritaPagatoNazionaleequalthis) AND 
			((@ImportoIrregolaritaPagatoPubblicoequalthis IS NULL) OR IMPORTO_IRREGOLARITA_PAGATO_PUBBLICO = @ImportoIrregolaritaPagatoPubblicoequalthis) AND 
			((@ImportoIrregolaritaPagatoPrivatoequalthis IS NULL) OR IMPORTO_IRREGOLARITA_PAGATO_PRIVATO = @ImportoIrregolaritaPagatoPrivatoequalthis) AND 
			((@ImportoIrregolaritaPagatoTotaleequalthis IS NULL) OR IMPORTO_IRREGOLARITA_PAGATO_TOTALE = @ImportoIrregolaritaPagatoTotaleequalthis) AND 
			((@ImportoDaRecuperareUeequalthis IS NULL) OR IMPORTO_DA_RECUPERARE_UE = @ImportoDaRecuperareUeequalthis) AND 
			((@ImportoDaRecuperareNazionaleequalthis IS NULL) OR IMPORTO_DA_RECUPERARE_NAZIONALE = @ImportoDaRecuperareNazionaleequalthis) AND 
			((@ImportoDaRecuperarePubblicoequalthis IS NULL) OR IMPORTO_DA_RECUPERARE_PUBBLICO = @ImportoDaRecuperarePubblicoequalthis) AND 
			((@ImportoDaRecuperarePrivatoequalthis IS NULL) OR IMPORTO_DA_RECUPERARE_PRIVATO = @ImportoDaRecuperarePrivatoequalthis) AND 
			((@ImportoDaRecuperareTotaleequalthis IS NULL) OR IMPORTO_DA_RECUPERARE_TOTALE = @ImportoDaRecuperareTotaleequalthis) AND 
			((@SpesaDecertificataequalthis IS NULL) OR SPESA_DECERTIFICATA = @SpesaDecertificataequalthis) AND 
			((@CommentiImpattoFinanziarioequalthis IS NULL) OR COMMENTI_IMPATTO_FINANZIARIO = @CommentiImpattoFinanziarioequalthis) AND 
			((@StabilitaOperazioniequalthis IS NULL) OR STABILITA_OPERAZIONI = @StabilitaOperazioniequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZRegistroIrregolaritaFindSelect]
(
	@IdIrregolaritaequalthis INT, 
	@IdProgettoequalthis INT, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@IdControlloOrigineequalthis INT, 
	@DescrizioneControlloEsternoequalthis VARCHAR(max), 
	@SegnalazioneOlafequalthis BIT, 
	@DataSegnalazioneequalthis DATETIME, 
	@TrimestreSegnalazioneequalthis VARCHAR(255), 
	@NumeroRiferimentoOlafequalthis VARCHAR(255), 
	@SospettoFrodeequalthis BIT, 
	@ImportoIrregolareCertificatoequalthis DECIMAL(15,2), 
	@ImportoIrregolareDaRecuperareequalthis DECIMAL(15,2), 
	@IdFondoequalthis INT, 
	@Annoequalthis INT, 
	@PeriodoProgrammazioneequalthis VARCHAR(500), 
	@NumeroRiferimentoNazionaleequalthis VARCHAR(255), 
	@DataCreazioneIdentificazioneequalthis DATETIME, 
	@TrimestreIdentificazioneequalthis VARCHAR(255), 
	@ProcedimentoAmministrativoequalthis BIT, 
	@AzioneGiudiziariaequalthis BIT, 
	@AzionePenaleequalthis BIT, 
	@IdStatoFinanziarioequalthis INT, 
	@DataPrimaInformazioneSospettoequalthis DATETIME, 
	@FontePrimaInformazioneSospettoequalthis VARCHAR(255), 
	@DataIrregolaritaequalthis DATETIME, 
	@DataIrregolaritaDaequalthis DATETIME, 
	@DataIrregolaritaAequalthis DATETIME, 
	@IdImpresaCommessaDaequalthis INT, 
	@NoteCommessaDaequalthis VARCHAR(max), 
	@CommessaAequalthis VARCHAR(max), 
	@IdCategoriaIrregolaritaequalthis INT, 
	@IdTipoIrregolaritaequalthis INT, 
	@ModusOperandiequalthis VARCHAR(max), 
	@DichiarazioneOperatoreequalthis VARCHAR(max), 
	@AccertamentiAmministratoreequalthis VARCHAR(max), 
	@IdClassificazioneIrregolaritaequalthis INT, 
	@DataPrimoAttoConstatazioneAmministrativoequalthis DATETIME, 
	@IdMotivoEsecuzioneControlloequalthis INT, 
	@IdTipoControlloequalthis INT, 
	@IdControlloPrimaDopoPagamentoequalthis INT, 
	@AutoritaControlloequalthis VARCHAR(255), 
	@IndagineOlafequalthis BIT, 
	@ImportoSpesaUeequalthis DECIMAL(15,2), 
	@ImportoSpesaNazionaleequalthis DECIMAL(15,2), 
	@ImportoSpesaPubblicoequalthis DECIMAL(15,2), 
	@ImportoSpesaPrivatoequalthis DECIMAL(15,2), 
	@ImportoSpesaTotaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaUeequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNazionaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPubblicoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPrivatoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaTotaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNonPagatoUeequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNonPagatoNazionaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNonPagatoPubblicoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNonPagatoPrivatoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaNonPagatoTotaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPagatoUeequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPagatoNazionaleequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPagatoPubblicoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPagatoPrivatoequalthis DECIMAL(15,2), 
	@ImportoIrregolaritaPagatoTotaleequalthis DECIMAL(15,2), 
	@ImportoDaRecuperareUeequalthis DECIMAL(15,2), 
	@ImportoDaRecuperareNazionaleequalthis DECIMAL(15,2), 
	@ImportoDaRecuperarePubblicoequalthis DECIMAL(15,2), 
	@ImportoDaRecuperarePrivatoequalthis DECIMAL(15,2), 
	@ImportoDaRecuperareTotaleequalthis DECIMAL(15,2), 
	@SpesaDecertificataequalthis BIT, 
	@CommentiImpattoFinanziarioequalthis VARCHAR(max), 
	@StabilitaOperazioniequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT SEGNALAZIONE_OLAF, DATA_SEGNALAZIONE, TRIMESTRE_SEGNALAZIONE, DATA_MODIFICA, CF_MODIFICA, DATA_INSERIMENTO, CF_INSERIMENTO, ID_PROGETTO, ID_IRREGOLARITA, NUMERO_RIFERIMENTO_OLAF, SOSPETTO_FRODE, IMPORTO_IRREGOLARE_CERTIFICATO, IMPORTO_IRREGOLARE_DA_RECUPERARE, ANNO, PERIODO_PROGRAMMAZIONE, NUMERO_RIFERIMENTO_NAZIONALE, AZIONE_PENALE, DATA_CREAZIONE_IDENTIFICAZIONE, TRIMESTRE_IDENTIFICAZI', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRegistroIrregolaritaFindSelect';

