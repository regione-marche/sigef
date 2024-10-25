CREATE PROCEDURE [dbo].[ZZobMisuraGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM zOB_MISURA
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZobMisuraGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM zOB_MISURA
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZobMisuraGetById';

