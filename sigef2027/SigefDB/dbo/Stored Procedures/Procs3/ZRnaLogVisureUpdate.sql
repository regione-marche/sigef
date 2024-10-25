CREATE PROCEDURE ZRnaLogVisureUpdate
(
	@IdRnaLogVisura INT, 
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
	UPDATE RNA_LOG_VISURE
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_IMPRESA = @IdImpresa, 
		ID_FISCALE_IMPRESA = @IdFiscaleImpresa, 
		ID_RICHIESTA = @IdRichiesta, 
		TIPO_VISURA = @TipoVisura, 
		CODICE_ESITO = @CodiceEsito, 
		DESCRIZIONE_ESITO = @DescrizioneEsito, 
		DATA_RICHIESTA = @DataRichiesta, 
		CODICE_STATO_RICHIESTA = @CodiceStatoRichiesta, 
		DESCRIZIONE_STATO_RICHIESTA = @DescrizioneStatoRichiesta, 
		DATA_STATO_RICHIESTA = @DataStatoRichiesta, 
		ID_OPERATORE = @IdOperatore, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_AGGIORNAMENTO = @DataAggiornamento, 
		PAYLOAD = @Payload
	WHERE 
		(ID_RNA_LOG_VISURA = @IdRnaLogVisura)

GO
