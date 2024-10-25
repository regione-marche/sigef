CREATE PROCEDURE ZRnaLogVisureDelete
(
	@IdRnaLogVisura INT
)
AS
	DELETE RNA_LOG_VISURE
	WHERE 
		(ID_RNA_LOG_VISURA = @IdRnaLogVisura)

GO