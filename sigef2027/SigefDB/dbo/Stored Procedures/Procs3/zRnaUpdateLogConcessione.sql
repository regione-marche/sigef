CREATE PROCEDURE [dbo].[zRnaUpdateLogConcessione]
(
	@IdRnaLogConcessione int,
	@IdProgetto INT,
	@IdProgettoRna varchar(255),
	@IdImpresa INT,
	@IdFiscaleImpresa varchar(16),
	@IdRichiesta varchar(50),
	@IdOperatoreRegAiuto INT,
	--@Metodo varchar(100),
	@DataRichiesta datetime,
	@IstanzaRichiesta xml,
	@IstanzaRisposta xml,
	@Cor varchar(50),
	@CodiceEsito int,
	@DescrizioneEsito nvarchar(max),
	--@TipoRisposta varchar(80),
	@CodiceEsitoStatoRichiesta int,
	@DescrizioneEsitoStatoRichiesta  nvarchar(max),
	@IdOperatoreStatoRichiesta int,
	@DataStatoRichiesta datetime,
	--@Payload varbinary(max),
	@Errore nvarchar(max)
)
AS
UPDATE RNA_LOG_CONCESSIONI
   SET 	ID_PROGETTO = @IdProgetto,
		ID_PROGETTO_RNA = @IdProgettoRna,
		ID_IMPRESA = @IdImpresa,
		ID_FISCALE_IMPRESA = @IdFiscaleImpresa,
		ID_RICHIESTA = @IdRichiesta,
		DATA_RICHIESTA = @DataRichiesta,
		ID_OPERATORE_REG_AIUTO = @IdOperatoreRegAiuto,
		ISTANZA_RICHIESTA = @IstanzaRichiesta,
		ISTANZA_RISPOSTA = @IstanzaRisposta,
		COR = @Cor,
		CODICE_ESITO = @CodiceEsito,
		DESCRIZIONE_ESITO = @DescrizioneEsito,
		CODICE_ESITO_STATO_RICHIESTA = @CodiceEsitoStatoRichiesta,
		DESCRIZIONE_ESITO_STATO_RICHIESTA = @DescrizioneEsitoStatoRichiesta,
		ID_OPERATORE_STATO_RICHIESTA = @IdOperatoreStatoRichiesta,
		DATA_STATO_RICHIESTA = @DataStatoRichiesta,
		--TIPO_RISPOSTA = @TipoRisposta,
		--PAYLOAD = @Payload,
		ERRORE = @Errore,
		--METODO = @Metodo,
		DATA_AGGIORNAMENTO = getdate()
 WHERE 
 ID_RNA_LOG_CONCESSIONE = @IdRnaLogConcessione
GO

