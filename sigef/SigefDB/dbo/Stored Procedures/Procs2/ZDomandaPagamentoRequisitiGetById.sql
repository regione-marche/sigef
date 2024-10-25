CREATE PROCEDURE [dbo].[ZDomandaPagamentoRequisitiGetById]
(
	@IdDomandaPagamento INT, 
	@IdRequisito INT
)
AS
	SELECT *
	FROM vDOMANDA_REQUISITI_PAGAMENTO
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZDomandaPagamentoRequisitiGetById]
(
	@IdDomandaPagamento INT, 
	@IdRequisito INT
)
AS
	SELECT *
	FROM vDOMANDA_REQUISITI_PAGAMENTO
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_REQUISITO = @IdRequisito)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaPagamentoRequisitiGetById';

