CREATE PROCEDURE [dbo].[ZZpsrAlberoDelete]
(
	@Codice VARCHAR(255)
)
AS
	DELETE zPSR_ALBERO
	WHERE 
		(CODICE = @Codice)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZpsrAlberoDelete]
(
	@Codice VARCHAR(255)
)
AS
	DELETE zPSR_ALBERO
	WHERE 
		(CODICE = @Codice)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZpsrAlberoDelete';

