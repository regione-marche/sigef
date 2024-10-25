CREATE PROCEDURE ZRnaLogVisureInsert
(
	@IdProgetto INT, 
	@IdImpresa INT, 
	@IdFiscaleImpresa VARCHAR(255), 
	@IdRichiesta VARCHAR(255), 
	@TipoVisura VARCHAR(255), 
	@CodiceEsito INT, 
	@DescrizioneEsito NVARCHAR(max), 
	@DataRichiesta DATETIME, 
	@CodiceStatoRichiesta INT, 
	@DescrizioneStatoRichiesta NVARCHAR(max), 
	@DataStatoRichiesta DATETIME, 
	@IdOperatore INT, 
	@DataInserimento DATETIME, 
	@DataAggiornamento DATETIME, 
	@Payload VARBINARY(max)
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataAggiornamento = ISNULL(@DataAggiornamento,(getdate()))
	INSERT INTO RNA_LOG_VISURE
	(
		ID_PROGETTO, 
		ID_IMPRESA, 
		ID_FISCALE_IMPRESA, 
		ID_RICHIESTA, 
		TIPO_VISURA, 
		CODICE_ESITO, 
		DESCRIZIONE_ESITO, 
		DATA_RICHIESTA, 
		CODICE_STATO_RICHIESTA, 
		DESCRIZIONE_STATO_RICHIESTA, 
		DATA_STATO_RICHIESTA, 
		ID_OPERATORE, 
		DATA_INSERIMENTO, 
		DATA_AGGIORNAMENTO, 
		PAYLOAD
	)
	VALUES
	(
		@IdProgetto, 
		@IdImpresa, 
		@IdFiscaleImpresa, 
		@IdRichiesta, 
		@TipoVisura, 
		@CodiceEsito, 
		@DescrizioneEsito, 
		@DataRichiesta, 
		@CodiceStatoRichiesta, 
		@DescrizioneStatoRichiesta, 
		@DataStatoRichiesta, 
		@IdOperatore, 
		@DataInserimento, 
		@DataAggiornamento, 
		@Payload
	)
	SELECT SCOPE_IDENTITY() AS ID_RNA_LOG_VISURA, @DataInserimento AS DATA_INSERIMENTO, @DataAggiornamento AS DATA_AGGIORNAMENTO

GO