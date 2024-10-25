CREATE PROCEDURE ZRnaLogConcessioniDelete
(
	@IdRnaLogConcessione INT
)
AS
	DELETE RNA_LOG_CONCESSIONI
	WHERE 
		(ID_RNA_LOG_CONCESSIONE = @IdRnaLogConcessione)

GO