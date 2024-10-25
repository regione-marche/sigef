CREATE PROCEDURE [dbo].[zIgrueGetInvioMonitoraggioById]
	(
		@IdInvio INT
	)
AS
BEGIN
	SELECT * FROM IGRUE_INVIO
	WHERE
	ID_INVIO = @IdInvio
	
END
