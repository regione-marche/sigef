﻿CREATE PROCEDURE [dbo].[ZZfocusAreaGetById]
(
	@Codice VARCHAR(255)
)
AS
	SELECT *
	FROM zFOCUS_AREA
	WHERE 
		(CODICE = @Codice)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZfocusAreaGetById]
(
	@Codice VARCHAR(255)
)
AS
	SELECT *
	FROM zFOCUS_AREA
	WHERE 
		(CODICE = @Codice)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZfocusAreaGetById';
