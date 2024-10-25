CREATE PROCEDURE [dbo].[ZRequisitiPagamentoPlurivaloreInsert]
(
	@IdRequisito INT, 
	@Codice VARCHAR(10), 
	@Descrizione VARCHAR(500)
)
AS
	INSERT INTO REQUISITI_PAGAMENTO_PLURIVALORE
	(
		ID_REQUISITO, 
		CODICE, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdRequisito, 
		@Codice, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_VALORE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiPagamentoPlurivaloreInsert';

