CREATE PROCEDURE ZRnaLogConcessioniInsert
(
	@IdProgetto INT, 
	@IdProgettoRna VARCHAR(255), 
	@IdImpresa INT, 
	@IdFiscaleImpresa VARCHAR(255), 
	@IdRichiesta VARCHAR(255), 
	@DataRichiesta DATETIME, 
	@IdOperatoreRegAiuto INT, 
	@IstanzaRichiesta XML, 
	@IstanzaRisposta XML, 
	@Cor VARCHAR(255), 
	@CodiceEsito INT, 
	@DescrizioneEsito NVARCHAR(max), 
	@CodiceEsitoStatoRichiesta INT, 
	@DescrizioneEsitoStatoRichiesta NVARCHAR(max), 
	@IdOperatoreStatoRichiesta INT, 
	@DataStatoRichiesta DATETIME, 
	@Errore NVARCHAR(max), 
	@DataInserimento DATETIME, 
	@DataAggiornamento DATETIME
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataAggiornamento = ISNULL(@DataAggiornamento,(getdate()))
	INSERT INTO RNA_LOG_CONCESSIONI
	(
		ID_PROGETTO, 
		ID_PROGETTO_RNA, 
		ID_IMPRESA, 
		ID_FISCALE_IMPRESA, 
		ID_RICHIESTA, 
		DATA_RICHIESTA, 
		ID_OPERATORE_REG_AIUTO, 
		ISTANZA_RICHIESTA, 
		ISTANZA_RISPOSTA, 
		COR, 
		CODICE_ESITO, 
		DESCRIZIONE_ESITO, 
		CODICE_ESITO_STATO_RICHIESTA, 
		DESCRIZIONE_ESITO_STATO_RICHIESTA, 
		ID_OPERATORE_STATO_RICHIESTA, 
		DATA_STATO_RICHIESTA, 
		ERRORE, 
		DATA_INSERIMENTO, 
		DATA_AGGIORNAMENTO
	)
	VALUES
	(
		@IdProgetto, 
		@IdProgettoRna, 
		@IdImpresa, 
		@IdFiscaleImpresa, 
		@IdRichiesta, 
		@DataRichiesta, 
		@IdOperatoreRegAiuto, 
		@IstanzaRichiesta, 
		@IstanzaRisposta, 
		@Cor, 
		@CodiceEsito, 
		@DescrizioneEsito, 
		@CodiceEsitoStatoRichiesta, 
		@DescrizioneEsitoStatoRichiesta, 
		@IdOperatoreStatoRichiesta, 
		@DataStatoRichiesta, 
		@Errore, 
		@DataInserimento, 
		@DataAggiornamento
	)
	SELECT SCOPE_IDENTITY() AS ID_RNA_LOG_CONCESSIONE, @DataInserimento AS DATA_INSERIMENTO, @DataAggiornamento AS DATA_AGGIORNAMENTO

GO
