CREATE PROCEDURE [dbo].[ZRequisitiPagamentoPlurivaloreUpdate]
(
	@IdValore INT, 
	@IdRequisito INT, 
	@Codice VARCHAR(10), 
	@Descrizione VARCHAR(500)
)
AS
	UPDATE REQUISITI_PAGAMENTO_PLURIVALORE
	SET
		ID_REQUISITO = @IdRequisito, 
		CODICE = @Codice, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_VALORE = @IdValore)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiPagamentoPlurivaloreUpdate';

