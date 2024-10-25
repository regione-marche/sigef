CREATE PROCEDURE [dbo].[ZPianoDiSviluppoDomandaPagamentoDelete]
(
	@IdPiano INT
)
AS
	DELETE PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO
	WHERE 
		(ID_PIANO = @IdPiano)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoDiSviluppoDomandaPagamentoDelete';

