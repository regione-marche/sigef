CREATE PROCEDURE [dbo].[ZIgrueLogErroriInsert]
(
	@IdInvio INT, 
	@IdTicket VARCHAR(255), 
	@DataRichiesta DATETIME, 
	@FileErrori VARBINARY(max), 
	@IstanzaErrori XML, 
	@IdOperatore INT, 
	@CodiceEsito INT, 
	@DescrizioneEsito NVARCHAR(max), 
	@DettaglioEsito NVARCHAR(max), 
	@TimestampEsito DATETIME, 
	@TipoFile VARCHAR(255)
)
AS
	INSERT INTO IGRUE_LOG_ERRORI
	(
		ID_INVIO, 
		ID_TICKET, 
		DATA_RICHIESTA, 
		FILE_ERRORI, 
		ISTANZA_ERRORI, 
		ID_OPERATORE, 
		CODICE_ESITO, 
		DESCRIZIONE_ESITO, 
		DETTAGLIO_ESITO, 
		TIMESTAMP_ESITO, 
		TIPO_FILE
	)
	VALUES
	(
		@IdInvio, 
		@IdTicket, 
		@DataRichiesta, 
		@FileErrori, 
		@IstanzaErrori, 
		@IdOperatore, 
		@CodiceEsito, 
		@DescrizioneEsito, 
		@DettaglioEsito, 
		@TimestampEsito, 
		@TipoFile
	)
	SELECT SCOPE_IDENTITY() AS ID_IGRUE_LOG_ERRORI


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueLogErroriInsert';

