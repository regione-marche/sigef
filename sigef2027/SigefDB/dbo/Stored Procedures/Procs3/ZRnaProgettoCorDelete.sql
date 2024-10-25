CREATE PROCEDURE ZRnaProgettoCorDelete
(
	@IdRnaProgettoCor INT
)
AS
	DELETE RNA_PROGETTO_COR
	WHERE 
		(ID_RNA_PROGETTO_COR = @IdRnaProgettoCor)

GO