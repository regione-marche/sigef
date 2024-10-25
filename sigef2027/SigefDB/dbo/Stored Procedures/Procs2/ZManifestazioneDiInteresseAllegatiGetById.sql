CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseAllegatiGetById]
(
	@IdAllegato INT
)
AS
	SELECT *
	FROM MANIFESTAZIONE_DI_INTERESSE_ALLEGATI
	WHERE 
		(ID_ALLEGATO = @IdAllegato)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseAllegatiGetById]
(
	@IdAllegato INT
)
AS
	SELECT *
	FROM MANIFESTAZIONE_DI_INTERESSE_ALLEGATI
	WHERE 
		(ID_ALLEGATO = @IdAllegato)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneDiInteresseAllegatiGetById';

