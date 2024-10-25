CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoGetById]
(
	@IdDomandaPagamento INT
)
AS
	SELECT *
	FROM vDOMANDA_DI_PAGAMENTO
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoGetById]
(
	@IdDomandaPagamento INT
)
AS
	SELECT *
	FROM vDOMANDA_DI_PAGAMENTO
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoGetById';

