CREATE PROCEDURE [dbo].[ZDettaglioInvestimentiDelete]
(
	@IdDettaglioInvestimento INT
)
AS
	DELETE DETTAGLIO_INVESTIMENTI
	WHERE 
		(ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDettaglioInvestimentiDelete]
(
	@IdDettaglioInvestimento INT
)
AS
	DELETE DETTAGLIO_INVESTIMENTI
	WHERE 
		(ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimento)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDettaglioInvestimentiDelete';

