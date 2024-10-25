CREATE PROCEDURE [dbo].[ZRnaObiettiviGetById]
(
	@IdObiettivo INT
)
AS
	SELECT *
	FROM RNA_OBIETTIVI
	WHERE 
		(ID_OBIETTIVO = @IdObiettivo)