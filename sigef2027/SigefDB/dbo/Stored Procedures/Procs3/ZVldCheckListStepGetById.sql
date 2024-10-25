CREATE PROCEDURE [dbo].[ZVldCheckListStepGetById]
(
	@IdVldCheckList INT, 
	@IdVldStep INT
)
AS
	SELECT *
	FROM vVLD_CHECK_LIST_STEP
	WHERE 
		(ID_VLD_CHECK_LIST = @IdVldCheckList) AND 
		(ID_VLD_STEP = @IdVldStep)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldCheckListStepGetById';

