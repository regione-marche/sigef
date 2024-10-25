CREATE PROCEDURE [dbo].[zRnaGetLogVisuraById]
	(
		@IdRnaLogVisura INT
	)
AS
BEGIN
	SELECT * FROM RNA_LOG_VISURE
	WHERE
	ID_RNA_LOG_VISURA = @IdRnaLogVisura
	
END
GO

