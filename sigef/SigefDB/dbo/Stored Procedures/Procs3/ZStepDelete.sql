CREATE PROCEDURE [dbo].[ZStepDelete]
(
	@IdStep INT
)
AS
	DELETE STEP
	WHERE 
		(ID_STEP = @IdStep)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZStepDelete]
(
	@IdStep INT
)
AS
	DELETE STEP
	WHERE 
		(ID_STEP = @IdStep)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZStepDelete';

