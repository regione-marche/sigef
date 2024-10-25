CREATE PROCEDURE [dbo].[ZIgrueInvioUpdate]
(
	@IdInvio INT, 
	@IdTicket VARCHAR(255), 
	@DataInvio DATETIME, 
	@DataDa DATE, 
	@DataA DATE, 
	@FileInvio VARBINARY(max), 
	@IdOperatore INT, 
	@CodiceEsito INT, 
	@DescrizioneEsito NVARCHAR(max), 
	@DettaglioEsito NVARCHAR(max), 
	@TimestampEsito DATETIME, 
	@TipoFile VARCHAR(255)
)
AS
	UPDATE IGRUE_INVIO
	SET
		ID_TICKET = @IdTicket, 
		DATA_INVIO = @DataInvio, 
		DATA_DA = @DataDa, 
		DATA_A = @DataA, 
		FILE_INVIO = @FileInvio, 
		ID_OPERATORE = @IdOperatore, 
		CODICE_ESITO = @CodiceEsito, 
		DESCRIZIONE_ESITO = @DescrizioneEsito, 
		DETTAGLIO_ESITO = @DettaglioEsito, 
		TIMESTAMP_ESITO = @TimestampEsito, 
		TIPO_FILE = @TipoFile
	WHERE 
		(ID_INVIO = @IdInvio)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIgrueInvioUpdate]
(
	@IdInvio INT, 
	@IdTicket VARCHAR(255), 
	@DataInvio DATETIME, 
	@DataDa DATE, 
	@DataA DATE, 
	@FileInvio VARBINARY(max), 
	@IdOperatore INT, 
	@CodiceEsito INT, 
	@DescrizioneEsito NVARCHAR(max), 
	@DettaglioEsito NVARCHAR(max), 
	@TimestampEsito DATETIME, 
	@TipoFile VARCHAR(255)
)
AS
	UPDATE IGRUE_INVIO
	SET
		ID_TICKET = @IdTicket, 
		DATA_INVIO = @DataInvio, 
		DATA_DA = @DataDa, 
		DATA_A = @DataA, 
		FILE_INVIO = @FileInvio, 
		ID_OPERATORE = @IdOperatore, 
		CODICE_ESITO = @CodiceEsito, 
		DESCRIZIONE_ESITO = @DescrizioneEsito, 
		DETTAGLIO_ESITO = @DettaglioEsito, 
		TIMESTAMP_ESITO = @TimestampEsito, 
		TIPO_FILE = @TipoFile
	WHERE 
		(ID_INVIO = @IdInvio)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueInvioUpdate';

