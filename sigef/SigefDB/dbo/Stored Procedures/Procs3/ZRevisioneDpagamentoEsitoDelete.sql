CREATE PROCEDURE [dbo].[ZRevisioneDpagamentoEsitoDelete]
(
	@Id INT
)
AS
	DELETE REVISIONE_DPAGAMENTO_ESITO
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRevisioneDpagamentoEsitoDelete';

