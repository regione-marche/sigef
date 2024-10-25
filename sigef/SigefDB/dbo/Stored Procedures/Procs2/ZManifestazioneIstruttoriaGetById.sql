CREATE PROCEDURE [dbo].[ZManifestazioneIstruttoriaGetById]
(
	@IdManifestazione INT
)
AS
	SELECT *
	FROM vMANIFESTAZIONE_ISTRUTTORIA
	WHERE 
		(ID_MANIFESTAZIONE_COLLABORATORE = @IdManifestazione)
