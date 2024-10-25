CREATE PROCEDURE [dbo].[ZRevisioneDomandaPagamentoGetById]
(
	@IdDomandaPagamento INT, 
	@IdLotto INT
)
AS
	SELECT *
	FROM vREVISIONE_DOMANDA_PAGAMENTO
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_LOTTO = @IdLotto)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZRevisioneDomandaPagamentoGetById]
(
	@IdDomandaPagamento INT, 
	@IdLotto INT
)
AS
	SELECT *
	FROM vREVISIONE_DOMANDA_PAGAMENTO
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_LOTTO = @IdLotto)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRevisioneDomandaPagamentoGetById';

