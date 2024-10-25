CREATE PROCEDURE [dbo].[ZVldCheckListStepDelete]
(
	@IdVldCheckList INT, 
	@IdVldStep INT
)
AS
	DELETE VLD_CHECK_LIST_STEP
	WHERE 
		(ID_VLD_CHECK_LIST = @IdVldCheckList) AND 
		(ID_VLD_STEP = @IdVldStep)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldCheckListStepDelete';

