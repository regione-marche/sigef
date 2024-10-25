CREATE PROCEDURE [dbo].[ZManifestazioneIstruttoriaDelete]
(
	@IdManifestazione INT
)
AS
	DELETE MANIFESTAZIONE_ISTRUTTORIA
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione)
