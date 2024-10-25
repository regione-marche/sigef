CREATE PROCEDURE [dbo].[ZProgettoStoricoGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vPROGETTO_STORICO
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoStoricoGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vPROGETTO_STORICO
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoStoricoGetById';

