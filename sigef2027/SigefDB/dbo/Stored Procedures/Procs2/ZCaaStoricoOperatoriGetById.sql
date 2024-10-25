CREATE PROCEDURE [dbo].[ZCaaStoricoOperatoriGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM CAA_STORICO_OPERATORI
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaStoricoOperatoriGetById';

