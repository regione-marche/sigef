CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoSegnatureDelete]
(
	@IdDomandaPagamento INT, 
	@CodTipo CHAR(3)
)
AS
	DELETE DOMANDA_DI_PAGAMENTO_SEGNATURE
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoSegnatureDelete';

