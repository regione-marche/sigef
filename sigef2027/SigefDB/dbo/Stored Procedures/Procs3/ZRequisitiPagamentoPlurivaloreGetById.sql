CREATE PROCEDURE [dbo].[ZRequisitiPagamentoPlurivaloreGetById]
(
	@IdValore INT
)
AS
	SELECT *
	FROM REQUISITI_PAGAMENTO_PLURIVALORE
	WHERE 
		(ID_VALORE = @IdValore)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiPagamentoPlurivaloreGetById';

