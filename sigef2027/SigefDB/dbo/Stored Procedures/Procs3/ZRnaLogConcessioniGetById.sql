CREATE PROCEDURE ZRnaLogConcessioniGetById
(
	@IdRnaLogConcessione INT
)
AS
	SELECT *
	FROM RNA_LOG_CONCESSIONI
	WHERE 
		(ID_RNA_LOG_CONCESSIONE = @IdRnaLogConcessione)

GO