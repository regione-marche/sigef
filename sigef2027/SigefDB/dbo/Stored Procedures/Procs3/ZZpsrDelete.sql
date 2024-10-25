CREATE PROCEDURE [dbo].[ZZpsrDelete]
(
	@Codice VARCHAR(255)
)
AS
	DELETE zPSR
	WHERE 
		(CODICE = @Codice)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZpsrDelete]
(
	@Codice VARCHAR(255)
)
AS
	DELETE zPSR
	WHERE 
		(CODICE = @Codice)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZpsrDelete';

