CREATE PROCEDURE [dbo].[ZIgrueInvioInsert]
(
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
	INSERT INTO IGRUE_INVIO
	(
		ID_TICKET, 
		DATA_INVIO, 
		DATA_DA, 
		DATA_A, 
		FILE_INVIO, 
		ID_OPERATORE, 
		CODICE_ESITO, 
		DESCRIZIONE_ESITO, 
		DETTAGLIO_ESITO, 
		TIMESTAMP_ESITO, 
		TIPO_FILE
	)
	VALUES
	(
		@IdTicket, 
		@DataInvio, 
		@DataDa, 
		@DataA, 
		@FileInvio, 
		@IdOperatore, 
		@CodiceEsito, 
		@DescrizioneEsito, 
		@DettaglioEsito, 
		@TimestampEsito, 
		@TipoFile
	)
	SELECT SCOPE_IDENTITY() AS ID_INVIO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIgrueInvioInsert]
(
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
	INSERT INTO IGRUE_INVIO
	(
		ID_TICKET, 
		DATA_INVIO, 
		DATA_DA, 
		DATA_A, 
		FILE_INVIO, 
		ID_OPERATORE, 
		CODICE_ESITO, 
		DESCRIZIONE_ESITO, 
		DETTAGLIO_ESITO, 
		TIMESTAMP_ESITO, 
		TIPO_FILE
	)
	VALUES
	(
		@IdTicket, 
		@DataInvio, 
		@DataDa, 
		@DataA, 
		@FileInvio, 
		@IdOperatore, 
		@CodiceEsito, 
		@DescrizioneEsito, 
		@DettaglioEsito, 
		@TimestampEsito, 
		@TipoFile
	)
	SELECT SCOPE_IDENTITY() AS ID_INVIO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueInvioInsert';

