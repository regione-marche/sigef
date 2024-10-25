CREATE PROCEDURE [dbo].[ZManifestazioneEsitiStepDelete]
(
	@IdManifestazione INT, 
	@IdStep INT
)
AS
	DELETE MANIFESTAZIONE_ESITI_STEP
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione) AND 
		(ID_STEP = @IdStep)
