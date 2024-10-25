CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneDelete]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT
)
AS
	DELETE DOMANDA_DI_PAGAMENTO_ESPORTAZIONE
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_PROGETTO = @IdProgetto)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneDelete]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT
)
AS
	DELETE DOMANDA_DI_PAGAMENTO_ESPORTAZIONE
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoEsportazioneDelete';

