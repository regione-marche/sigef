CREATE PROCEDURE [dbo].[ZBandoStoricoGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vBANDO_STORICO
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoStoricoGetById';

