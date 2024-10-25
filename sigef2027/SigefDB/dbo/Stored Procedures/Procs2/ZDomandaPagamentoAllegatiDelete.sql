CREATE PROCEDURE [dbo].[ZDomandaPagamentoAllegatiDelete]
(
	@IdAllegato INT
)
AS
	DELETE DOMANDA_PAGAMENTO_ALLEGATI
	WHERE 
		(ID_ALLEGATO = @IdAllegato)

GO