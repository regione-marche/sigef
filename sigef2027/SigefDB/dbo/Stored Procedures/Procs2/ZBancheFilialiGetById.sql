CREATE PROCEDURE [dbo].[ZBancheFilialiGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM BANCHE_FILIALI
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheFilialiGetById';

