CREATE PROCEDURE [dbo].[zRnaGetProgettoCorById]
	(
		@IdRnaProgettoCor INT
	)
AS
BEGIN
	SELECT * FROM RNA_PROGETTO_COR
	WHERE
	ID_RNA_PROGETTO_COR = @IdRnaProgettoCor
	
END
GO


