CREATE PROCEDURE [dbo].[zRnaGetLogConcessioneByIdRichiesta]
	(
		@IdRichiesta VARCHAR(50)
	)
AS
BEGIN
	SELECT * FROM RNA_LOG_CONCESSIONI
	WHERE
	ID_RICHIESTA = @IdRichiesta
	
END
GO

