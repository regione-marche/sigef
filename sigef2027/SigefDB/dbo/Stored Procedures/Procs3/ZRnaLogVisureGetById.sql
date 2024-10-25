CREATE PROCEDURE ZRnaLogVisureGetById
(
	@IdRnaLogVisura INT
)
AS
	SELECT *
	FROM RNA_LOG_VISURE
	WHERE 
		(ID_RNA_LOG_VISURA = @IdRnaLogVisura)

GO