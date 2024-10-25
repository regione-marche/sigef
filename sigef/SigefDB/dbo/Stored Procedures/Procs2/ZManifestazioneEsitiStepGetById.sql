CREATE PROCEDURE [dbo].[ZManifestazioneEsitiStepGetById]
(
	@IdManifestazione INT, 
	@IdStep INT
)
AS
	SELECT *
	FROM vMANIFESTAZIONE_ESITI_STEP
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione) AND 
		(ID_STEP = @IdStep)
