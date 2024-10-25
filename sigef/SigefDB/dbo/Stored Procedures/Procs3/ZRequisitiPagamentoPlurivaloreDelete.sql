CREATE PROCEDURE [dbo].[ZRequisitiPagamentoPlurivaloreDelete]
(
	@IdValore INT
)
AS
	DELETE REQUISITI_PAGAMENTO_PLURIVALORE
	WHERE 
		(ID_VALORE = @IdValore)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiPagamentoPlurivaloreDelete';

