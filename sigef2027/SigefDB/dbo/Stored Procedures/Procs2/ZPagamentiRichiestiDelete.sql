CREATE PROCEDURE [dbo].[ZPagamentiRichiestiDelete]
(
	@IdPagamentoRichiesto INT
)
AS
	DELETE PAGAMENTI_RICHIESTI
	WHERE 
		(ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiesto)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPagamentiRichiestiDelete]
(
	@IdPagamentoRichiesto INT
)
AS
	DELETE PAGAMENTI_RICHIESTI
	WHERE 
		(ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiesto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPagamentiRichiestiDelete';

