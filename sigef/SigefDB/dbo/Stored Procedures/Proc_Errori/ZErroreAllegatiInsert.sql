CREATE PROCEDURE [dbo].[ZErroreAllegatiInsert]
(
	@IdErrore INT, 
	@Protocollato BIT, 
	@SegnaturaAllegato VARCHAR(255), 
	@IdAllegato INT, 
	@CfInserimento VARCHAR(255), 
	@DataInserimento DATETIME, 
	@CfModifica VARCHAR(255), 
	@DataModifica DATETIME
)
AS
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO ERRORE_ALLEGATI
	(
		ID_ERRORE, 
		PROTOCOLLATO, 
		SEGNATURA_ALLEGATO, 
		ID_ALLEGATO, 
		CF_INSERIMENTO, 
		DATA_INSERIMENTO, 
		CF_MODIFICA, 
		DATA_MODIFICA
	)
	VALUES
	(
		@IdErrore, 
		@Protocollato, 
		@SegnaturaAllegato, 
		@IdAllegato, 
		@CfInserimento, 
		@DataInserimento, 
		@CfModifica, 
		@DataModifica
	)
	SELECT SCOPE_IDENTITY() AS ID_ERRORE_ALLEGATI, @DataModifica AS DATA_MODIFICA

GO