CREATE PROCEDURE [dbo].[ZIrregolaritaFindSelect]
(
	@IdIrregolaritaequalthis INT, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@IdProgettoequalthis INT, 
	@IdTipoIrregolaritaequalthis INT, 
	@IdControlloOrigineequalthis INT, 
	@SospettoFrodeequalthis BIT, 
	@DataCostatazioneAmministrativaequalthis DATETIME, 
	@ImportoIrregolareDaRecuperareequalthis BIT, 
	@SegnalazioneOlafequalthis BIT, 
	@DataSegnalazioneOlafequalthis DATETIME, 
	@DataSegnalazioneOlafDaequalthis DATETIME, 
	@DataSegnalazioneOlafAequalthis DATETIME, 
	@TrimestreSegnalazioneOlafequalthis VARCHAR(max), 
	@DataPrimaInformazioneequalthis DATETIME, 
	@FontePrimaInformazioneequalthis VARCHAR(max), 
	@IdImpresaCommessaDaequalthis INT, 
	@NoteCommessaDaequalthis VARCHAR(max), 
	@IdCategoriaequalthis INT, 
	@IdTipoequalthis INT, 
	@IdClassificazioneequalthis INT, 
	@PraticheUtilizzateequalthis VARCHAR(max), 
	@NoteGiustificativiequalthis VARCHAR(max), 
	@ImportoSpesaequalthis DECIMAL(15,2), 
	@ContributoAmmessoequalthis DECIMAL(15,2), 
	@ContributoPubblicoequalthis DECIMAL(15,2), 
	@ContributoAmmessoCertificatoequalthis DECIMAL(15,2), 
	@ContributoPubblicoCertificatoequalthis DECIMAL(15,2), 
	@ContributoPubblicoDaRecuperareequalthis DECIMAL(15,2), 
	@CommentiImpattiFinanziarioequalthis VARCHAR(max), 
	@ProcedimentoAmministrativoequalthis BIT, 
	@AzioneGiudiziariaequalthis BIT, 
	@AzionePenaleequalthis BIT, 
	@IdStatoFinanziarioequalthis INT, 
	@StabilitaOperazioniequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_IRREGOLARITA, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, ID_PROGETTO, ID_TIPO_IRREGOLARITA, ID_CONTROLLO_ORIGINE, SOSPETTO_FRODE, DATA_COSTATAZIONE_AMMINISTRATIVA, IMPORTO_IRREGOLARE_DA_RECUPERARE, SEGNALAZIONE_OLAF, DATA_SEGNALAZIONE_OLAF, DATA_SEGNALAZIONE_OLAF_DA, DATA_SEGNALAZIONE_OLAF_A, TRIMESTRE_SEGNALAZIONE_OLAF, DATA_PRIMA_INFORMAZIONE, FONTE_PRIMA_INFORMAZIONE, ID_IMPRESA_COMMESSA_DA, NOTE_COMMESSA_DA, ID_CATEGORIA, ID_TIPO, ID_CLASSIFICAZIONE, PRATICHE_UTILIZZATE, NOTE_GIUSTIFICATIVI, IMPORTO_SPESA, CONTRIBUTO_AMMESSO, CONTRIBUTO_PUBBLICO, CONTRIBUTO_AMMESSO_CERTIFICATO, CONTRIBUTO_PUBBLICO_CERTIFICATO, CONTRIBUTO_PUBBLICO_DA_RECUPERARE, COMMENTI_IMPATTI_FINANZIARIO, PROCEDIMENTO_AMMINISTRATIVO, AZIONE_GIUDIZIARIA, AZIONE_PENALE, ID_STATO_FINANZIARIO, STABILITA_OPERAZIONI, TIPO_IRREGOLARITA, ATTIVO_TIPO_IRREGOLARITA, ID_BANDO, COD_STATO_PROGETTO, STATO_PROGETTO, COD_FASE_PROGETTO, FASE_PROGETTO, ID_IMPRESA_PROGETTO, CUAA_IMPRESA_IRREGOLARITA, CODICE_FISCALE_IMPRESA_IRREGOLARITA, RAGIONE_SOCIALE_IMPRESA_IRREGOLARITA, DESCRIZIONE_CATEGORIA, DESCRIZIONE_CONTROLLO_ORIGINE, DESCRIZIONE_TIPO, DESCRIZIONE_CLASSIFICAZIONE, DESCRIZIONE_STATO_FINANZIARIO FROM VIRREGOLARITA WHERE 1=1';
	IF (@IdIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IRREGOLARITA = @IdIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdIrregolaritaequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdTipoIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_IRREGOLARITA = @IdTipoIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdTipoIrregolaritaequalthis);end;
	IF (@IdControlloOrigineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTROLLO_ORIGINE = @IdControlloOrigineequalthis)'; set @lensql=@lensql+len(@IdControlloOrigineequalthis);end;
	IF (@SospettoFrodeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SOSPETTO_FRODE = @SospettoFrodeequalthis)'; set @lensql=@lensql+len(@SospettoFrodeequalthis);end;
	IF (@DataCostatazioneAmministrativaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_COSTATAZIONE_AMMINISTRATIVA = @DataCostatazioneAmministrativaequalthis)'; set @lensql=@lensql+len(@DataCostatazioneAmministrativaequalthis);end;
	IF (@ImportoIrregolareDaRecuperareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRREGOLARE_DA_RECUPERARE = @ImportoIrregolareDaRecuperareequalthis)'; set @lensql=@lensql+len(@ImportoIrregolareDaRecuperareequalthis);end;
	IF (@SegnalazioneOlafequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNALAZIONE_OLAF = @SegnalazioneOlafequalthis)'; set @lensql=@lensql+len(@SegnalazioneOlafequalthis);end;
	IF (@DataSegnalazioneOlafequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SEGNALAZIONE_OLAF = @DataSegnalazioneOlafequalthis)'; set @lensql=@lensql+len(@DataSegnalazioneOlafequalthis);end;
	IF (@DataSegnalazioneOlafDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SEGNALAZIONE_OLAF_DA = @DataSegnalazioneOlafDaequalthis)'; set @lensql=@lensql+len(@DataSegnalazioneOlafDaequalthis);end;
	IF (@DataSegnalazioneOlafAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SEGNALAZIONE_OLAF_A = @DataSegnalazioneOlafAequalthis)'; set @lensql=@lensql+len(@DataSegnalazioneOlafAequalthis);end;
	IF (@TrimestreSegnalazioneOlafequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TRIMESTRE_SEGNALAZIONE_OLAF = @TrimestreSegnalazioneOlafequalthis)'; set @lensql=@lensql+len(@TrimestreSegnalazioneOlafequalthis);end;
	IF (@DataPrimaInformazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PRIMA_INFORMAZIONE = @DataPrimaInformazioneequalthis)'; set @lensql=@lensql+len(@DataPrimaInformazioneequalthis);end;
	IF (@FontePrimaInformazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FONTE_PRIMA_INFORMAZIONE = @FontePrimaInformazioneequalthis)'; set @lensql=@lensql+len(@FontePrimaInformazioneequalthis);end;
	IF (@IdImpresaCommessaDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA_COMMESSA_DA = @IdImpresaCommessaDaequalthis)'; set @lensql=@lensql+len(@IdImpresaCommessaDaequalthis);end;
	IF (@NoteCommessaDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE_COMMESSA_DA = @NoteCommessaDaequalthis)'; set @lensql=@lensql+len(@NoteCommessaDaequalthis);end;
	IF (@IdCategoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CATEGORIA = @IdCategoriaequalthis)'; set @lensql=@lensql+len(@IdCategoriaequalthis);end;
	IF (@IdTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO = @IdTipoequalthis)'; set @lensql=@lensql+len(@IdTipoequalthis);end;
	IF (@IdClassificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CLASSIFICAZIONE = @IdClassificazioneequalthis)'; set @lensql=@lensql+len(@IdClassificazioneequalthis);end;
	IF (@PraticheUtilizzateequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PRATICHE_UTILIZZATE = @PraticheUtilizzateequalthis)'; set @lensql=@lensql+len(@PraticheUtilizzateequalthis);end;
	IF (@NoteGiustificativiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE_GIUSTIFICATIVI = @NoteGiustificativiequalthis)'; set @lensql=@lensql+len(@NoteGiustificativiequalthis);end;
	IF (@ImportoSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SPESA = @ImportoSpesaequalthis)'; set @lensql=@lensql+len(@ImportoSpesaequalthis);end;
	IF (@ContributoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_AMMESSO = @ContributoAmmessoequalthis)'; set @lensql=@lensql+len(@ContributoAmmessoequalthis);end;
	IF (@ContributoPubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_PUBBLICO = @ContributoPubblicoequalthis)'; set @lensql=@lensql+len(@ContributoPubblicoequalthis);end;
	IF (@ContributoAmmessoCertificatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_AMMESSO_CERTIFICATO = @ContributoAmmessoCertificatoequalthis)'; set @lensql=@lensql+len(@ContributoAmmessoCertificatoequalthis);end;
	IF (@ContributoPubblicoCertificatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_PUBBLICO_CERTIFICATO = @ContributoPubblicoCertificatoequalthis)'; set @lensql=@lensql+len(@ContributoPubblicoCertificatoequalthis);end;
	IF (@ContributoPubblicoDaRecuperareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_PUBBLICO_DA_RECUPERARE = @ContributoPubblicoDaRecuperareequalthis)'; set @lensql=@lensql+len(@ContributoPubblicoDaRecuperareequalthis);end;
	IF (@CommentiImpattiFinanziarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COMMENTI_IMPATTI_FINANZIARIO = @CommentiImpattiFinanziarioequalthis)'; set @lensql=@lensql+len(@CommentiImpattiFinanziarioequalthis);end;
	IF (@ProcedimentoAmministrativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROCEDIMENTO_AMMINISTRATIVO = @ProcedimentoAmministrativoequalthis)'; set @lensql=@lensql+len(@ProcedimentoAmministrativoequalthis);end;
	IF (@AzioneGiudiziariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AZIONE_GIUDIZIARIA = @AzioneGiudiziariaequalthis)'; set @lensql=@lensql+len(@AzioneGiudiziariaequalthis);end;
	IF (@AzionePenaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AZIONE_PENALE = @AzionePenaleequalthis)'; set @lensql=@lensql+len(@AzionePenaleequalthis);end;
	IF (@IdStatoFinanziarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STATO_FINANZIARIO = @IdStatoFinanziarioequalthis)'; set @lensql=@lensql+len(@IdStatoFinanziarioequalthis);end;
	IF (@StabilitaOperazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STABILITA_OPERAZIONI = @StabilitaOperazioniequalthis)'; set @lensql=@lensql+len(@StabilitaOperazioniequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdIrregolaritaequalthis INT, @CfInserimentoequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @IdProgettoequalthis INT, @IdTipoIrregolaritaequalthis INT, @IdControlloOrigineequalthis INT, @SospettoFrodeequalthis BIT, @DataCostatazioneAmministrativaequalthis DATETIME, @ImportoIrregolareDaRecuperareequalthis BIT, @SegnalazioneOlafequalthis BIT, @DataSegnalazioneOlafequalthis DATETIME, @DataSegnalazioneOlafDaequalthis DATETIME, @DataSegnalazioneOlafAequalthis DATETIME, @TrimestreSegnalazioneOlafequalthis VARCHAR(max), @DataPrimaInformazioneequalthis DATETIME, @FontePrimaInformazioneequalthis VARCHAR(max), @IdImpresaCommessaDaequalthis INT, @NoteCommessaDaequalthis VARCHAR(max), @IdCategoriaequalthis INT, @IdTipoequalthis INT, @IdClassificazioneequalthis INT, @PraticheUtilizzateequalthis VARCHAR(max), @NoteGiustificativiequalthis VARCHAR(max), @ImportoSpesaequalthis DECIMAL(15,2), @ContributoAmmessoequalthis DECIMAL(15,2), @ContributoPubblicoequalthis DECIMAL(15,2), @ContributoAmmessoCertificatoequalthis DECIMAL(15,2), @ContributoPubblicoCertificatoequalthis DECIMAL(15,2), @ContributoPubblicoDaRecuperareequalthis DECIMAL(15,2), @CommentiImpattiFinanziarioequalthis VARCHAR(max), @ProcedimentoAmministrativoequalthis BIT, @AzioneGiudiziariaequalthis BIT, @AzionePenaleequalthis BIT, @IdStatoFinanziarioequalthis INT, @StabilitaOperazioniequalthis BIT',@IdIrregolaritaequalthis , @CfInserimentoequalthis , @DataInserimentoequalthis , @CfModificaequalthis , @DataModificaequalthis , @IdProgettoequalthis , @IdTipoIrregolaritaequalthis , @IdControlloOrigineequalthis , @SospettoFrodeequalthis , @DataCostatazioneAmministrativaequalthis , @ImportoIrregolareDaRecuperareequalthis , @SegnalazioneOlafequalthis , @DataSegnalazioneOlafequalthis , @DataSegnalazioneOlafDaequalthis , @DataSegnalazioneOlafAequalthis , @TrimestreSegnalazioneOlafequalthis , @DataPrimaInformazioneequalthis , @FontePrimaInformazioneequalthis , @IdImpresaCommessaDaequalthis , @NoteCommessaDaequalthis , @IdCategoriaequalthis , @IdTipoequalthis , @IdClassificazioneequalthis , @PraticheUtilizzateequalthis , @NoteGiustificativiequalthis , @ImportoSpesaequalthis , @ContributoAmmessoequalthis , @ContributoPubblicoequalthis , @ContributoAmmessoCertificatoequalthis , @ContributoPubblicoCertificatoequalthis , @ContributoPubblicoDaRecuperareequalthis , @CommentiImpattiFinanziarioequalthis , @ProcedimentoAmministrativoequalthis , @AzioneGiudiziariaequalthis , @AzionePenaleequalthis , @IdStatoFinanziarioequalthis , @StabilitaOperazioniequalthis ;
	else
		SELECT ID_IRREGOLARITA, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, ID_PROGETTO, ID_TIPO_IRREGOLARITA, ID_CONTROLLO_ORIGINE, SOSPETTO_FRODE, DATA_COSTATAZIONE_AMMINISTRATIVA, IMPORTO_IRREGOLARE_DA_RECUPERARE, SEGNALAZIONE_OLAF, DATA_SEGNALAZIONE_OLAF, DATA_SEGNALAZIONE_OLAF_DA, DATA_SEGNALAZIONE_OLAF_A, TRIMESTRE_SEGNALAZIONE_OLAF, DATA_PRIMA_INFORMAZIONE, FONTE_PRIMA_INFORMAZIONE, ID_IMPRESA_COMMESSA_DA, NOTE_COMMESSA_DA, ID_CATEGORIA, ID_TIPO, ID_CLASSIFICAZIONE, PRATICHE_UTILIZZATE, NOTE_GIUSTIFICATIVI, IMPORTO_SPESA, CONTRIBUTO_AMMESSO, CONTRIBUTO_PUBBLICO, CONTRIBUTO_AMMESSO_CERTIFICATO, CONTRIBUTO_PUBBLICO_CERTIFICATO, CONTRIBUTO_PUBBLICO_DA_RECUPERARE, COMMENTI_IMPATTI_FINANZIARIO, PROCEDIMENTO_AMMINISTRATIVO, AZIONE_GIUDIZIARIA, AZIONE_PENALE, ID_STATO_FINANZIARIO, STABILITA_OPERAZIONI, TIPO_IRREGOLARITA, ATTIVO_TIPO_IRREGOLARITA, ID_BANDO, COD_STATO_PROGETTO, STATO_PROGETTO, COD_FASE_PROGETTO, FASE_PROGETTO, ID_IMPRESA_PROGETTO, CUAA_IMPRESA_IRREGOLARITA, CODICE_FISCALE_IMPRESA_IRREGOLARITA, RAGIONE_SOCIALE_IMPRESA_IRREGOLARITA, DESCRIZIONE_CATEGORIA, DESCRIZIONE_CONTROLLO_ORIGINE, DESCRIZIONE_TIPO, DESCRIZIONE_CLASSIFICAZIONE, DESCRIZIONE_STATO_FINANZIARIO
		FROM VIRREGOLARITA
		WHERE 
			((@IdIrregolaritaequalthis IS NULL) OR ID_IRREGOLARITA = @IdIrregolaritaequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdTipoIrregolaritaequalthis IS NULL) OR ID_TIPO_IRREGOLARITA = @IdTipoIrregolaritaequalthis) AND 
			((@IdControlloOrigineequalthis IS NULL) OR ID_CONTROLLO_ORIGINE = @IdControlloOrigineequalthis) AND 
			((@SospettoFrodeequalthis IS NULL) OR SOSPETTO_FRODE = @SospettoFrodeequalthis) AND 
			((@DataCostatazioneAmministrativaequalthis IS NULL) OR DATA_COSTATAZIONE_AMMINISTRATIVA = @DataCostatazioneAmministrativaequalthis) AND 
			((@ImportoIrregolareDaRecuperareequalthis IS NULL) OR IMPORTO_IRREGOLARE_DA_RECUPERARE = @ImportoIrregolareDaRecuperareequalthis) AND 
			((@SegnalazioneOlafequalthis IS NULL) OR SEGNALAZIONE_OLAF = @SegnalazioneOlafequalthis) AND 
			((@DataSegnalazioneOlafequalthis IS NULL) OR DATA_SEGNALAZIONE_OLAF = @DataSegnalazioneOlafequalthis) AND 
			((@DataSegnalazioneOlafDaequalthis IS NULL) OR DATA_SEGNALAZIONE_OLAF_DA = @DataSegnalazioneOlafDaequalthis) AND 
			((@DataSegnalazioneOlafAequalthis IS NULL) OR DATA_SEGNALAZIONE_OLAF_A = @DataSegnalazioneOlafAequalthis) AND 
			((@TrimestreSegnalazioneOlafequalthis IS NULL) OR TRIMESTRE_SEGNALAZIONE_OLAF = @TrimestreSegnalazioneOlafequalthis) AND 
			((@DataPrimaInformazioneequalthis IS NULL) OR DATA_PRIMA_INFORMAZIONE = @DataPrimaInformazioneequalthis) AND 
			((@FontePrimaInformazioneequalthis IS NULL) OR FONTE_PRIMA_INFORMAZIONE = @FontePrimaInformazioneequalthis) AND 
			((@IdImpresaCommessaDaequalthis IS NULL) OR ID_IMPRESA_COMMESSA_DA = @IdImpresaCommessaDaequalthis) AND 
			((@NoteCommessaDaequalthis IS NULL) OR NOTE_COMMESSA_DA = @NoteCommessaDaequalthis) AND 
			((@IdCategoriaequalthis IS NULL) OR ID_CATEGORIA = @IdCategoriaequalthis) AND 
			((@IdTipoequalthis IS NULL) OR ID_TIPO = @IdTipoequalthis) AND 
			((@IdClassificazioneequalthis IS NULL) OR ID_CLASSIFICAZIONE = @IdClassificazioneequalthis) AND 
			((@PraticheUtilizzateequalthis IS NULL) OR PRATICHE_UTILIZZATE = @PraticheUtilizzateequalthis) AND 
			((@NoteGiustificativiequalthis IS NULL) OR NOTE_GIUSTIFICATIVI = @NoteGiustificativiequalthis) AND 
			((@ImportoSpesaequalthis IS NULL) OR IMPORTO_SPESA = @ImportoSpesaequalthis) AND 
			((@ContributoAmmessoequalthis IS NULL) OR CONTRIBUTO_AMMESSO = @ContributoAmmessoequalthis) AND 
			((@ContributoPubblicoequalthis IS NULL) OR CONTRIBUTO_PUBBLICO = @ContributoPubblicoequalthis) AND 
			((@ContributoAmmessoCertificatoequalthis IS NULL) OR CONTRIBUTO_AMMESSO_CERTIFICATO = @ContributoAmmessoCertificatoequalthis) AND 
			((@ContributoPubblicoCertificatoequalthis IS NULL) OR CONTRIBUTO_PUBBLICO_CERTIFICATO = @ContributoPubblicoCertificatoequalthis) AND 
			((@ContributoPubblicoDaRecuperareequalthis IS NULL) OR CONTRIBUTO_PUBBLICO_DA_RECUPERARE = @ContributoPubblicoDaRecuperareequalthis) AND 
			((@CommentiImpattiFinanziarioequalthis IS NULL) OR COMMENTI_IMPATTI_FINANZIARIO = @CommentiImpattiFinanziarioequalthis) AND 
			((@ProcedimentoAmministrativoequalthis IS NULL) OR PROCEDIMENTO_AMMINISTRATIVO = @ProcedimentoAmministrativoequalthis) AND 
			((@AzioneGiudiziariaequalthis IS NULL) OR AZIONE_GIUDIZIARIA = @AzioneGiudiziariaequalthis) AND 
			((@AzionePenaleequalthis IS NULL) OR AZIONE_PENALE = @AzionePenaleequalthis) AND 
			((@IdStatoFinanziarioequalthis IS NULL) OR ID_STATO_FINANZIARIO = @IdStatoFinanziarioequalthis) AND 
			((@StabilitaOperazioniequalthis IS NULL) OR STABILITA_OPERAZIONI = @StabilitaOperazioniequalthis)
		

GO