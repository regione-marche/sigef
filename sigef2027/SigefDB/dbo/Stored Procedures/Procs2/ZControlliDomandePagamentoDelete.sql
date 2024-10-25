CREATE PROCEDURE [dbo].[ZControlliDomandePagamentoDelete]
(
	@IdLotto INT, 
	@IdDomandaPagamento INT
)
AS
	DELETE CONTROLLI_DOMANDE_PAGAMENTO
	WHERE 
		(ID_LOTTO = @IdLotto) AND 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZControlliDomandePagamentoDelete]
(
	@IdLotto INT, 
	@IdDomandaPagamento INT
)
AS
	DELETE CONTROLLI_DOMANDE_PAGAMENTO
	WHERE 
		(ID_LOTTO = @IdLotto) AND 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliDomandePagamentoDelete';

