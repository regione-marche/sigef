CREATE PROCEDURE [dbo].[ZRequisitiPagamentoDelete]
(
	@IdRequisito INT
)
AS
	DELETE REQUISITI_PAGAMENTO
	WHERE 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiPagamentoDelete';

