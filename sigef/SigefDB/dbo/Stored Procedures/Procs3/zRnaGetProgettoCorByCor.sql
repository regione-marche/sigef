CREATE PROCEDURE [dbo].[zRnaGetProgettoCorByCor]
	(
		@Cor varchar(50)
	)
AS
BEGIN
	SELECT * FROM RNA_PROGETTO_COR
	WHERE
	COR = @Cor
	
END
GO


