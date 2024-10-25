CREATE PROCEDURE [dbo].[zCUPInsertRichieste] 
	(
		@IdRichiesta INT,
		@IdProgetto INT,
		@CodiceCup VARCHAR(30),
		@DataRichiestaCup DATETIME,
		@IstanzaRichiesta XML,
		@IstanzaRisposta XML,
		@IdRichiestaAssegnataCup INT,
		@EsitoElaborazioneCup VARCHAR(10),
		@DescrizioneEsitoElaborazioneCup NVARCHAR(MAX),
		@TipoEsito VARCHAR(100),
		@DataInserimento DATETIME,
		@DataAggiornamento DATETIME--,
		--@IdCupRichiesta INT
	)
AS
BEGIN
	INSERT INTO CUP_RICHIESTE
	(
		ID_RICHIESTA,
		ID_PROGETTO,
		CODICE_CUP,
		DATA_RICHIESTA_CUP,
		ISTANZA_RICHIESTA,
		ISTANZA_RISPOSTA,
		ID_RICHIESTA_ASSEGNATA_CUP,
		ESITO_ELABORAZIONE_CUP,
		DESCRIZIONE_ESITO_ELABORAZIONE_CUP,
		TIPO_ESITO,
		DATA_INSERIMENTO,
		DATA_AGGIORNAMENTO
	)
	
	VALUES
	(
		@IdRichiesta,
		@IdProgetto,
		@CodiceCup,
		@DataRichiestaCup,
		@IstanzaRichiesta,
		@IstanzaRisposta,
		@IdRichiestaAssegnataCup,
		@EsitoElaborazioneCup,
		@DescrizioneEsitoElaborazioneCup,
		@TipoEsito,
		@DataInserimento,
		@DataAggiornamento
	)
	
	SELECT CAST(SCOPE_IDENTITY() AS INT)
	
END
