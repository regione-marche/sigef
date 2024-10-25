CREATE PROCEDURE [dbo].[ZCheckListGetById]
(
	@IdCheckList INT
)
AS
	SELECT *
	FROM CHECK_LIST
	WHERE 
		(ID_CHECK_LIST = @IdCheckList)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZChecklistGetById]
(
	@ID_CHECK_LIST INT
)
AS
	SELECT *
	FROM CHECK_LIST
	WHERE 
		(ID_CHECK_LIST = @ID_CHECK_LIST)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListGetById';

