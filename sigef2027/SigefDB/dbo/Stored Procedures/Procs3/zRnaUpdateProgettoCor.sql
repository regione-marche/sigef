CREATE PROCEDURE [dbo].[zRnaUpdateProgettoCor]
(
	--@IdProgetto INT,
	--@IdProgettoRna varchar(255),
	--@IdImpresa INT,
	--@IdFiscaleImpresa varchar(16),
	--@IdRichiesta varchar(50),
	--@IdOperatoreAssegnazioneCor INT,
	--@Cor varchar(50),
	@IdRnaProgettoCor int,
	@StatoConcessione varchar(50),
	--@DataAssegnazioneCor datetime,
	@Confermato bit,
	@IdOperatoreConfermaConcessione int,
	@DataConfermaConcessione datetime,
	@Annullato bit,
	@IdOperatoreAnnullamento int,
	@DataAnnullamento datetime
)
AS
UPDATE RNA_PROGETTO_COR
             
	--ID_PROGETTO,
	--ID_PROGETTO_RNA,
	--ID_RICHIESTA,
	--ID_IMPRESA,
	--ID_FISCALE_IMPRESA,
	--ID_OPERATORE_ASSEGNAZIONE_COR,
	--COR,
	SET STATO_CONCESSIONE = @StatoConcessione,
	--DATA_ASSEGNAZIONE_COR = @DataAssegnazioneCor,
	ID_OPERATORE_CONFERMA_CONCESSIONE = @IdOperatoreConfermaConcessione,
	CONFERMATO = @Confermato,
	DATA_CONFERMA_CONCESSIONE = @DataConfermaConcessione,
	ANNULLATO = @Annullato,
	ID_OPERATORE_ANNULLAMENTO = @IdOperatoreAnnullamento,
	DATA_ANNULLAMENTO = @DataAnnullamento,		   
	DATA_AGGIORNAMENTO = GETDATE()
		   
WHERE ID_RNA_PROGETTO_COR = @IdRnaProgettoCor		   
 

GO

