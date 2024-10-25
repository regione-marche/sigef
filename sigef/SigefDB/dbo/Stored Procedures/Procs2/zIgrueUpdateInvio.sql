CREATE PROCEDURE [dbo].[zIgrueUpdateInvio]
	(
		@IdInvio INT,
		@IdTicket VARCHAR(50),
		@DataInvio DATETIME,
		@DataDa DATETIME,
		@DataA DATETIME,
		@FileInvio VARBINARY(MAX),
		@IdOperatore INT,
		@CodiceEsito INT,
		@DescrizioneEsito NVARCHAR(MAX),
		@DettaglioEsito NVARCHAR(MAX),
		@TimeStampEsito DATETIME,
		@TipoFile VARCHAR(200)
	)
AS
BEGIN
	UPDATE IGRUE_INVIO
	SET
	ID_TICKET = @IdTicket,
	DATA_DA = @DataDa,
	DATA_A = @DataA,
	FILE_INVIO = @FileInvio,
	ID_OPERATORE = @IdOperatore,
	CODICE_ESITO = @CodiceEsito,
	DESCRIZIONE_ESITO = @DescrizioneEsito,
	DETTAGLIO_ESITO = @DettaglioEsito,
    TIMESTAMP_ESITO = @TimeStampEsito,
    TIPO_FILE = @TipoFile
	
	WHERE ID_INVIO = @IdInvio
	
END
