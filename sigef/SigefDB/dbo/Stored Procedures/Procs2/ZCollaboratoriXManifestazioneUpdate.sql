CREATE PROCEDURE [dbo].[ZCollaboratoriXManifestazioneUpdate]
(
	@IdCollaboratore INT, 
	@IdBando INT, 
	@IdManifestazione INT, 
	@CfUtente VARCHAR(16), 
	@Operatore VARCHAR(16), 
	@DataInserimento DATETIME
)
AS
	UPDATE COLLABORATORI_X_MANIFESTAZIONE
	SET
		ID_BANDO = @IdBando, 
		ID_MANIFESTAZIONE = @IdManifestazione, 
		CF_UTENTE = @CfUtente, 
		OPERATORE = @Operatore, 
		DATA_INSERIMENTO = @DataInserimento
	WHERE 
		(ID_COLLABORATORE = @IdCollaboratore)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCollaboratoriXManifestazioneUpdate';

