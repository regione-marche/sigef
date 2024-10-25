﻿CREATE PROCEDURE [dbo].[ZIrregolaritaInsert]
(
	@CfInserimento VARCHAR(255), 
	@DataInserimento DATETIME, 
	@CfModifica VARCHAR(255), 
	@DataModifica DATETIME, 
	@IdProgetto INT, 
	@IdTipoIrregolarita INT, 
	@IdControlloOrigine INT, 
	@SospettoFrode BIT, 
	@DataCostatazioneAmministrativa DATETIME, 
	@ImportoIrregolareDaRecuperare BIT, 
	@SegnalazioneOlaf BIT, 
	@DataSegnalazioneOlaf DATETIME, 
	@DataSegnalazioneOlafDa DATETIME, 
	@DataSegnalazioneOlafA DATETIME, 
	@TrimestreSegnalazioneOlaf VARCHAR(max), 
	@DataPrimaInformazione DATETIME, 
	@FontePrimaInformazione VARCHAR(max), 
	@IdImpresaCommessaDa INT, 
	@NoteCommessaDa VARCHAR(max), 
	@IdCategoria INT, 
	@IdTipo INT, 
	@IdClassificazione INT, 
	@PraticheUtilizzate VARCHAR(max), 
	@NoteGiustificativi VARCHAR(max), 
	@ImportoSpesa DECIMAL(15,2), 
	@ContributoAmmesso DECIMAL(15,2), 
	@ContributoPubblico DECIMAL(15,2), 
	@ContributoAmmessoCertificato DECIMAL(15,2), 
	@ContributoPubblicoCertificato DECIMAL(15,2), 
	@ContributoPubblicoDaRecuperare DECIMAL(15,2), 
	@CommentiImpattiFinanziario VARCHAR(max), 
	@ProcedimentoAmministrativo BIT, 
	@AzioneGiudiziaria BIT, 
	@AzionePenale BIT, 
	@IdStatoFinanziario INT, 
	@StabilitaOperazioni BIT
)
AS
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @DataCostatazioneAmministrativa = ISNULL(@DataCostatazioneAmministrativa,(getdate()))
	INSERT INTO IRREGOLARITA
	(
		CF_INSERIMENTO, 
		DATA_INSERIMENTO, 
		CF_MODIFICA, 
		DATA_MODIFICA, 
		ID_PROGETTO, 
		ID_TIPO_IRREGOLARITA, 
		ID_CONTROLLO_ORIGINE, 
		SOSPETTO_FRODE, 
		DATA_COSTATAZIONE_AMMINISTRATIVA, 
		IMPORTO_IRREGOLARE_DA_RECUPERARE, 
		SEGNALAZIONE_OLAF, 
		DATA_SEGNALAZIONE_OLAF, 
		DATA_SEGNALAZIONE_OLAF_DA, 
		DATA_SEGNALAZIONE_OLAF_A, 
		TRIMESTRE_SEGNALAZIONE_OLAF, 
		DATA_PRIMA_INFORMAZIONE, 
		FONTE_PRIMA_INFORMAZIONE, 
		ID_IMPRESA_COMMESSA_DA, 
		NOTE_COMMESSA_DA, 
		ID_CATEGORIA, 
		ID_TIPO, 
		ID_CLASSIFICAZIONE, 
		PRATICHE_UTILIZZATE, 
		NOTE_GIUSTIFICATIVI, 
		IMPORTO_SPESA, 
		CONTRIBUTO_AMMESSO, 
		CONTRIBUTO_PUBBLICO, 
		CONTRIBUTO_AMMESSO_CERTIFICATO, 
		CONTRIBUTO_PUBBLICO_CERTIFICATO, 
		CONTRIBUTO_PUBBLICO_DA_RECUPERARE, 
		COMMENTI_IMPATTI_FINANZIARIO, 
		PROCEDIMENTO_AMMINISTRATIVO, 
		AZIONE_GIUDIZIARIA, 
		AZIONE_PENALE, 
		ID_STATO_FINANZIARIO, 
		STABILITA_OPERAZIONI
	)
	VALUES
	(
		@CfInserimento, 
		@DataInserimento, 
		@CfModifica, 
		@DataModifica, 
		@IdProgetto, 
		@IdTipoIrregolarita, 
		@IdControlloOrigine, 
		@SospettoFrode, 
		@DataCostatazioneAmministrativa, 
		@ImportoIrregolareDaRecuperare, 
		@SegnalazioneOlaf, 
		@DataSegnalazioneOlaf, 
		@DataSegnalazioneOlafDa, 
		@DataSegnalazioneOlafA, 
		@TrimestreSegnalazioneOlaf, 
		@DataPrimaInformazione, 
		@FontePrimaInformazione, 
		@IdImpresaCommessaDa, 
		@NoteCommessaDa, 
		@IdCategoria, 
		@IdTipo, 
		@IdClassificazione, 
		@PraticheUtilizzate, 
		@NoteGiustificativi, 
		@ImportoSpesa, 
		@ContributoAmmesso, 
		@ContributoPubblico, 
		@ContributoAmmessoCertificato, 
		@ContributoPubblicoCertificato, 
		@ContributoPubblicoDaRecuperare, 
		@CommentiImpattiFinanziario, 
		@ProcedimentoAmministrativo, 
		@AzioneGiudiziaria, 
		@AzionePenale, 
		@IdStatoFinanziario, 
		@StabilitaOperazioni
	)
	SELECT SCOPE_IDENTITY() AS ID_IRREGOLARITA, @DataModifica AS DATA_MODIFICA, @DataCostatazioneAmministrativa AS DATA_COSTATAZIONE_AMMINISTRATIVA

GO