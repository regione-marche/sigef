CREATE PROCEDURE [dbo].[ZZfocusAreaDelete]
(
	@Codice VARCHAR(255)
)
AS
	DELETE zFOCUS_AREA
	WHERE 
		(CODICE = @Codice)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZfocusAreaDelete]
(
	@Codice VARCHAR(255)
)
AS
	DELETE zFOCUS_AREA
	WHERE 
		(CODICE = @Codice)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZfocusAreaDelete';

