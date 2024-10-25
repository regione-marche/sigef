create PROCEDURE [dbo].[ZPrioritaXManifestazioneGetById]
(
	@IdManifestazione INT, 
	@IdPriorita INT
)
AS
	SELECT *
	FROM vPRIORITA_X_MANIFESTAZIONE
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione) AND 
		(ID_PRIORITA = @IdPriorita)
