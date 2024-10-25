CREATE PROCEDURE [dbo].[ZWorkflowProcedureInsert]
(
	@CodTipoProcedura CHAR(3), 
	@CodWorkflow CHAR(5), 
	@Ordine INT, 
	@Obbligatorio BIT
)
AS
	SET @Obbligatorio = ISNULL(@Obbligatorio,((0)))
	INSERT INTO WORKFLOW_PROCEDURE
	(
		COD_TIPO_PROCEDURA, 
		COD_WORKFLOW, 
		ORDINE, 
		OBBLIGATORIO
	)
	VALUES
	(
		@CodTipoProcedura, 
		@CodWorkflow, 
		@Ordine, 
		@Obbligatorio
	)
	SELECT @Obbligatorio AS OBBLIGATORIO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZWorkflowProcedureInsert';

