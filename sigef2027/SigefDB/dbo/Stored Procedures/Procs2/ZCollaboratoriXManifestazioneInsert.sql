CREATE PROCEDURE [dbo].[ZCollaboratoriXManifestazioneInsert]
(
	@IdBando INT, 
	@IdManifestazione INT, 
	@CfUtente VARCHAR(16), 
	@Operatore VARCHAR(16), 
	@DataInserimento DATETIME
)
AS
	INSERT INTO COLLABORATORI_X_MANIFESTAZIONE
	(
		ID_BANDO, 
		ID_MANIFESTAZIONE, 
		CF_UTENTE, 
		OPERATORE, 
		DATA_INSERIMENTO
	)
	VALUES
	(
		@IdBando, 
		@IdManifestazione, 
		@CfUtente, 
		@Operatore, 
		@DataInserimento
	)
	SELECT SCOPE_IDENTITY() AS ID_COLLABORATORE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCollaboratoriXManifestazioneInsert';

