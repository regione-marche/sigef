﻿CREATE PROCEDURE [dbo].[ZWorkflowProcedureGetById]
(
	@CodTipoProcedura CHAR(3), 
	@CodWorkflow CHAR(5)
)
AS
	SELECT *
	FROM vWORKFLOW_PROCEDURE
	WHERE 
		(COD_TIPO_PROCEDURA = @CodTipoProcedura) AND 
		(COD_WORKFLOW = @CodWorkflow)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZWorkflowProcedureGetById';
