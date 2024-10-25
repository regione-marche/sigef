CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseGetById]
(
	@IdManifestazione INT
)
AS
	SELECT *
	FROM vMANIFESTAZIONE_DI_INTERESSE
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseGetById]
(
	@IdManifestazione INT
)
AS
	SELECT *
	FROM vMANIFESTAZIONE_DI_INTERESSE
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneDiInteresseGetById';

