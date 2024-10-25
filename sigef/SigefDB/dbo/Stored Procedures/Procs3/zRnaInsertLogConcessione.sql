CREATE PROCEDURE [dbo].[zRnaInsertLogConcessione]
(
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
	@DescrizioneEsito nvarchar(max)--,
	--@TipoRisposta varchar(80)
)
AS
INSERT INTO RNA_LOG_CONCESSIONI
           (
			   ID_PROGETTO,
			   ID_PROGETTO_RNA,
			   ID_IMPRESA,
			   ID_FISCALE_IMPRESA,
			   ID_RICHIESTA,
			   DATA_RICHIESTA,
			   ID_OPERATORE_REG_AIUTO,
			   ISTANZA_RICHIESTA,
			   ISTANZA_RISPOSTA,
			   COR,
			   CODICE_ESITO,
			   DESCRIZIONE_ESITO,
			   CODICE_ESITO_STATO_RICHIESTA,
			   DESCRIZIONE_ESITO_STATO_RICHIESTA,
			   ID_OPERATORE_STATO_RICHIESTA,
			   DATA_STATO_RICHIESTA,
			   --TIPO_RISPOSTA,
			   --PAYLOAD,
			   ERRORE,
			   --METODO,
			   DATA_INSERIMENTO,
			   DATA_AGGIORNAMENTO
		   )
     VALUES
           (
				@IdProgetto,
				@IdProgettoRna, 
				@IdImpresa,
				@IdFiscaleImpresa,
				@IdRichiesta,
				@DataRichiesta,
				@IdOperatoreRegAiuto,
				@IstanzaRichiesta,
				@IstanzaRisposta,
				@Cor,
				@CodiceEsito,
				@DescrizioneEsito,
				null,
				null,
				null,
				null,
				--@TipoRisposta,
				--null,
				null,
				--@Metodo,
				getdate(),
				getdate()
		   )
	SELECT CAST(SCOPE_IDENTITY() AS INT)

GO

