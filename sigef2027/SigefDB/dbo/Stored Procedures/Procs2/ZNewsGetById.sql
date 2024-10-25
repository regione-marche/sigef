CREATE PROCEDURE [dbo].[ZNewsGetById]
(
	@IdNews INT
)
AS
	SELECT *
	FROM NEWS
	WHERE 
		(ID_NEWS = @IdNews)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZNewsGetById]
(
	@IdNews INT
)
AS
	SELECT *
	FROM NEWS
	WHERE 
		(ID_NEWS = @IdNews)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZNewsGetById';

