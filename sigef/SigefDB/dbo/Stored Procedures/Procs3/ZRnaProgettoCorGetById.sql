CREATE PROCEDURE ZRnaProgettoCorGetById
(
	@IdRnaProgettoCor INT
)
AS
	SELECT *
	FROM RNA_PROGETTO_COR
	WHERE 
		(ID_RNA_PROGETTO_COR = @IdRnaProgettoCor)

GO