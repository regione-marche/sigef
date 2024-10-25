CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseDelete]
(
	@IdManifestazione INT
)
AS
	DELETE MANIFESTAZIONE_DI_INTERESSE
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseDelete]
(
	@IdManifestazione INT
)
AS
	DELETE MANIFESTAZIONE_DI_INTERESSE
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneDiInteresseDelete';

