CREATE PROCEDURE [dbo].[zIgrueInsertInvio] 
	
	@IdTicket VARCHAR(50),
	@DataInvio DATETIME,
	@DataDa DATETIME,
	@DataA DATETIME,
	@FileInvio VARBINARY(MAX) = NULL,
	@IdOperatore INT,
	@TipoFile VARCHAR(200)
	--@CodiceEsito VARCHAR(20),
	--@DescrizioneEsito NVARCHAR(MAX),
	--@DettaglioEsito NVARCHAR(MAX),
	--@TimeStampEsito DATETIME
	--@IdInvio INT OUT
AS
BEGIN

INSERT INTO IGRUE_INVIO
(
   ID_TICKET,
   DATA_INVIO,
   DATA_DA,
   DATA_A,
   FILE_INVIO,
   ID_OPERATORE,
   TIPO_FILE
   --CODICE_ESITO,
   --DESCRIZIONE_ESITO,
   --DETTAGLIO_ESITO,
   --TIMESTAMP_ESITO
)
VALUES
(
	@IdTicket,
	@DataInvio,
	@DataDa,
	@DataA,
	@FileInvio,
	@IdOperatore,
	@TipoFile
	--@CodiceEsito,
	--@DescrizioneEsito,
	--@DettaglioEsito,
	--@TimeStampEsito
)

SELECT CAST(SCOPE_IDENTITY() AS INT)
	
	
END
