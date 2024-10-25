CREATE PROCEDURE [dbo].[zIgrueGetLogErroriById]
	(
		@IdIgrueLogErrori INT
	)
AS
BEGIN
	SELECT * FROM IGRUE_LOG_ERRORI
	WHERE
	ID_IGRUE_LOG_ERRORI = @IdIgrueLogErrori
	
END
