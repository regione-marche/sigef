CREATE PROCEDURE [dbo].[zIgrueInsertLogErrori] 
	
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
	--@IdInvio INT OUT
AS
BEGIN

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
	@TimeStampEsito,
	@TipoFile
)

SELECT CAST(SCOPE_IDENTITY() AS INT)
	
	
END
