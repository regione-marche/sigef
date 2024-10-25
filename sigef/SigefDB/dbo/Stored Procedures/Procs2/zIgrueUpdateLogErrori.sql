CREATE PROCEDURE [dbo].[zIgrueUpdateLogErrori] 
	
	@IdIgrueLogErrori INT,
	@IdInvio INT,
	@IdTicket VARCHAR(50),
	@DataRichiesta DATETIME,
	@FileErrori VARBINARY(MAX) = NULL,
	@IstanzaErrori XML,
	@IdOperatore INT,
	@CodiceEsito INT,
	@DescrizioneEsito NVARCHAR(MAX),
	@DettaglioEsito NVARCHAR(MAX),
	@TimeStampEsito DATETIME,
	@TipoFile VARCHAR(200)
AS
BEGIN

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
TIMESTAMP_ESITO = @TimeStampEsito,
TIPO_FILE = @TipoFile
WHERE 
ID_IGRUE_LOG_ERRORI = @IdIgrueLogErrori
	
END
