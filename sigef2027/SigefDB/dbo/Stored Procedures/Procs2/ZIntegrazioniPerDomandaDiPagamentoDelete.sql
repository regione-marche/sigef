CREATE PROCEDURE [dbo].[ZIntegrazioniPerDomandaDiPagamentoDelete]
(
	@IdIntegrazioneDomandaDiPagamento INT
)
AS
	DELETE INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO
	WHERE 
		(ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO = @IdIntegrazioneDomandaDiPagamento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIntegrazioniPerDomandaDiPagamentoDelete]
(
	@IdIntegrazioneDomandaDiPagamento INT
)
AS
	DELETE INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO
	WHERE 
		(ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO = @IdIntegrazioneDomandaDiPagamento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIntegrazioniPerDomandaDiPagamentoDelete';

