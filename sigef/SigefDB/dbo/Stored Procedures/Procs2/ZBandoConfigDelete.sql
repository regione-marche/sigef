CREATE PROCEDURE [dbo].[ZBandoConfigDelete]
(
	@Id INT
)
AS
	DELETE BANDO_CONFIG
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoConfigDelete]
(
	@Id INT
)
AS
	DELETE BANDO_CONFIG
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoConfigDelete';

