CREATE PROCEDURE [dbo].[ZZquerySqlGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM zQUERY_SQL
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZquerySqlGetById';

