CREATE PROCEDURE [dbo].[ZDisposizioneGetById]
(
	@IdDisposizione INT
)
AS
	SELECT *
	FROM VDISPOSIZIONE
	WHERE 
		(ID_DISPOSIZIONE = @IdDisposizione)

GO