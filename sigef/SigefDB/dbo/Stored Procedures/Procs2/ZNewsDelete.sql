CREATE PROCEDURE [dbo].[ZNewsDelete]
(
	@IdNews INT
)
AS
	DELETE NEWS
	WHERE 
		(ID_NEWS = @IdNews)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZNewsDelete]
(
	@IdNews INT
)
AS
	DELETE NEWS
	WHERE 
		(ID_NEWS = @IdNews)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZNewsDelete';

