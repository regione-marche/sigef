CREATE PROCEDURE [dbo].[ZElencoDiPagamentoDelete]
(
	@IdElencoPagamento INT
)
AS
	DELETE ELENCO_DI_PAGAMENTO
	WHERE 
		(ID_ELENCO_PAGAMENTO = @IdElencoPagamento)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZElencoDiPagamentoDelete]
(
	@IdElencoPagamento INT
)
AS
	DELETE ELENCO_DI_PAGAMENTO
	WHERE 
		(ID_ELENCO_PAGAMENTO = @IdElencoPagamento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZElencoDiPagamentoDelete';

