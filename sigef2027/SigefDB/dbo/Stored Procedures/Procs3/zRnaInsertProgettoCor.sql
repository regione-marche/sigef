CREATE PROCEDURE [dbo].[zRnaInsertProgettoCor]
(
	@IdProgetto INT,
	@IdProgettoRna varchar(255),
	@IdImpresa INT,
	@IdFiscaleImpresa varchar(16),
	@IdRichiesta varchar(50),
	@IdOperatoreAssegnazioneCor INT,
	@Cor varchar(50),
	@StatoConcessione varchar(50),
	@DataAssegnazioneCor datetime,
	@IdOperatoreConfermaConcessione int,
	@DataConfermaConcessione datetime,
	@Annullato bit,
	@IdOperatoreAnnullamento int,
	@DataAnnullamento datetime
)
AS
INSERT INTO RNA_PROGETTO_COR
           (   
			   ID_PROGETTO,
			   ID_PROGETTO_RNA,
			   ID_RICHIESTA,
			   ID_IMPRESA,
			   ID_FISCALE_IMPRESA,
			   ID_OPERATORE_ASSEGNAZIONE_COR,
			   COR,
			   STATO_CONCESSIONE,
			   CONFERMATO,
			   DATA_ASSEGNAZIONE_COR,
			   ID_OPERATORE_CONFERMA_CONCESSIONE,
			   DATA_CONFERMA_CONCESSIONE,
			   ANNULLATO,
			   ID_OPERATORE_ANNULLAMENTO,
			   DATA_ANNULLAMENTO,
			   DATA_INSERIMENTO,
			   DATA_AGGIORNAMENTO
		   )
		   
     VALUES
           (
				@IdProgetto,
				@IdProgettoRna, 
				@IdRichiesta,
				@IdImpresa,
				@IdFiscaleImpresa,
				@IdOperatoreAssegnazioneCor,
				@Cor,
				@StatoConcessione,
				0,
				@DataAssegnazioneCor,
				@IdOperatoreConfermaConcessione,
				@DataConfermaConcessione,
				0,
				@IdOperatoreAnnullamento,
				@DataAnnullamento,
				getdate(),
				getdate()
		   )
	SELECT CAST(SCOPE_IDENTITY() AS INT)

GO

