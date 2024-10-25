CREATE PROCEDURE [dbo].[ZCheckListXStepGetById]
(
	@IdStep INT, 
	@IdCheckList INT
)
AS
	SELECT *
	FROM vCHECKLIST
	WHERE 
		(ID_STEP = @IdStep) AND 
		(ID_CHECK_LIST = @IdCheckList)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCheckListXStepGetById]
(
	@IdStep INT, 
	@IdCheckList INT
)
AS
	SELECT *
	FROM vCHECKLIST
	WHERE 
		(ID_STEP = @IdStep) AND 
		(ID_CHECK_LIST = @IdCheckList)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListXStepGetById';

