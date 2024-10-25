create PROCEDURE [dbo].[ZPrioritaXManifestazioneDelete]
(
	@IdManifestazione INT, 
	@IdPriorita INT
)
AS
	DELETE PRIORITA_X_MANIFESTAZIONE
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione) AND 
		(ID_PRIORITA = @IdPriorita)
