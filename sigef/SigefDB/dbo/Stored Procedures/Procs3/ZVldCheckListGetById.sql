﻿CREATE PROCEDURE [dbo].[ZVldCheckListGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM VLD_CHECK_LIST
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldCheckListGetById';
