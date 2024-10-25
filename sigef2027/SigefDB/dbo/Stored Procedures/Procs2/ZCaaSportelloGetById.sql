CREATE PROCEDURE [dbo].[ZCaaSportelloGetById]
(
	@Codice VARCHAR(255)
)
AS
	SELECT *
	FROM vCAA_SPORTELLO
	WHERE 
		(CODICE = @Codice)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaSportelloGetById';

