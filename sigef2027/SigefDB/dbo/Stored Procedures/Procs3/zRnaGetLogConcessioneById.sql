CREATE PROCEDURE [dbo].[zRnaGetLogConcessioneById]
	(
		@IdRnaLogConcessione int
	)
AS
BEGIN
	SELECT * FROM RNA_LOG_CONCESSIONI
	WHERE
	ID_RNA_LOG_CONCESSIONE = @IdRnaLogConcessione
	
END
GO


