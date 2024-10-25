CREATE PROCEDURE [dbo].[ZIgrueLogErroriUpdate]
(
	@IdIgrueLogErrori INT, 
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
	UPDATE IGRUE_LOG_ERRORI
	SET
		ID_INVIO = @IdInvio, 
		ID_TICKET = @IdTicket, 
		DATA_RICHIESTA = @DataRichiesta, 
		FILE_ERRORI = @FileErrori, 
		ISTANZA_ERRORI = @IstanzaErrori, 
		ID_OPERATORE = @IdOperatore, 
		CODICE_ESITO = @CodiceEsito, 
		DESCRIZIONE_ESITO = @DescrizioneEsito, 
		DETTAGLIO_ESITO = @DettaglioEsito, 
		TIMESTAMP_ESITO = @TimestampEsito, 
		TIPO_FILE = @TipoFile
	WHERE 
		(ID_IGRUE_LOG_ERRORI = @IdIgrueLogErrori)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIgrueLogErroriUpdate';

