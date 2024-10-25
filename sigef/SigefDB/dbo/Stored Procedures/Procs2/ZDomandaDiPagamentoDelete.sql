CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoDelete]
(
	@IdDomandaPagamento INT
)
AS
	DELETE DOMANDA_DI_PAGAMENTO
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoDelete]
(
	@IdDomandaPagamento INT
)
AS
	DELETE DOMANDA_DI_PAGAMENTO
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoDelete';

