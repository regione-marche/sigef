CREATE PROCEDURE [dbo].[zRnaGetProgettoCorByIdRichiesta]
	(
		@IdRichiesta varchar(50)
	)
AS
BEGIN
	SELECT * FROM RNA_PROGETTO_COR
	WHERE
	ID_RICHIESTA = @IdRichiesta
	
END
GO

