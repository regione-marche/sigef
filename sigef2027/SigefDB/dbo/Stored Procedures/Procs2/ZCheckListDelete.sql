CREATE PROCEDURE [dbo].[ZCheckListDelete]
(
	@IdCheckList INT
)
AS
	DELETE CHECK_LIST
	WHERE 
		(ID_CHECK_LIST = @IdCheckList)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZChecklistDelete]
(
	@ID_CHECK_LIST INT
)
AS
	DELETE CHECK_LIST
	WHERE 
		(ID_CHECK_LIST = @ID_CHECK_LIST)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListDelete';

