CREATE PROCEDURE [dbo].[ZElencoDiPagamentoGetById]
(
	@IdElencoPagamento INT
)
AS
	SELECT *
	FROM vELENCO_DI_PAGAMENTO
	WHERE 
		(ID_ELENCO_PAGAMENTO = @IdElencoPagamento)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZElencoDiPagamentoGetById]
(
	@IdElencoPagamento INT
)
AS
	SELECT *
	FROM vELENCO_DI_PAGAMENTO
	WHERE 
		(ID_ELENCO_PAGAMENTO = @IdElencoPagamento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZElencoDiPagamentoGetById';

