CREATE PROCEDURE [dbo].[ZDisposizioneDelete]
(
	@IdDisposizione INT
)
AS
	DELETE DISPOSIZIONE
	WHERE 
		(ID_DISPOSIZIONE = @IdDisposizione)

GO