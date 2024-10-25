CREATE PROCEDURE [dbo].[zRnaGetLogVisuraByIdRichiesta]
	(
		@IdRichiesta INT
	)
AS
BEGIN
	SELECT * FROM RNA_LOG_VISURE
	WHERE
	ID_RICHIESTA = @IdRichiesta
	
END
GO

