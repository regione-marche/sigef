CREATE PROCEDURE [dbo].[ZDomandaPagamentoLiquidazioneDelete]
(
	@Id INT
)
AS
	DELETE DOMANDA_PAGAMENTO_LIQUIDAZIONE
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaPagamentoLiquidazioneDelete]
(
	@Id INT
)
AS
	DELETE DOMANDA_PAGAMENTO_LIQUIDAZIONE
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaPagamentoLiquidazioneDelete';

