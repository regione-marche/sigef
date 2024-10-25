CREATE PROCEDURE [dbo].[zRnaInsertLogVisura]
(
	@IdProgetto INT, 
	@IdImpresa INT, 
	@IdFiscaleImpresa VARCHAR(16), 
	@IdRichiesta VARCHAR(50), 
	@TipoVisura VARCHAR(50), 
	@CodiceEsito INT,  
	@DescrizioneEsito NVARCHAR(max), 
	@DataRichiesta DATETIME,
	@IdOperatore INT
)
AS
INSERT INTO RNA_LOG_VISURE
           (
			   ID_PROGETTO,
			   ID_IMPRESA,
			   ID_FISCALE_IMPRESA,
			   ID_RICHIESTA,
			   TIPO_VISURA,
			   CODICE_ESITO,
			   DESCRIZIONE_ESITO,
			   DATA_RICHIESTA,
			   ID_OPERATORE
		   )
     VALUES
           (
				@IdProgetto, 
				@IdImpresa, 
				@IdFiscaleImpresa, 
				@IdRichiesta, 
				@TipoVisura, 
				@CodiceEsito,  
				@DescrizioneEsito, 
				@DataRichiesta,
				@IdOperatore
		   )
	SELECT CAST(SCOPE_IDENTITY() AS INT)

GO


