CREATE PROCEDURE [dbo].[ZErroreAllegatiUpdate]
(
	@IdErroreAllegati INT, 
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
	SET @DataModifica=getdate()
	UPDATE ERRORE_ALLEGATI
	SET
		ID_ERRORE = @IdErrore, 
		PROTOCOLLATO = @Protocollato, 
		SEGNATURA_ALLEGATO = @SegnaturaAllegato, 
		ID_ALLEGATO = @IdAllegato, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_MODIFICA = @CfModifica, 
		DATA_MODIFICA = @DataModifica
	WHERE 
		(ID_ERRORE_ALLEGATI = @IdErroreAllegati)
	SELECT @DataModifica;

GO