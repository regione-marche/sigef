CREATE PROCEDURE [dbo].[ZVldStepDelete]
(
	@Id INT
)
AS
	DELETE VLD_STEP
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldStepDelete';

