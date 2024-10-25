CREATE PROCEDURE [dbo].[ZSpecificaInvestimentiUpdate]
(
	@IdSpecificaInvestimento INT, 
	@IdDettaglioInvestimento INT, 
	@CodSpecifica VARCHAR(255), 
	@Descrizione VARCHAR(500)
)
AS
	UPDATE SPECIFICA_INVESTIMENTI
	SET
		ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimento, 
		COD_SPECIFICA = @CodSpecifica, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSpecificaInvestimentiUpdate]
(
	@IdSpecificaInvestimento INT, 
	@IdDettaglioInvestimento INT, 
	@CodSpecifica CHAR(2), 
	@Descrizione VARCHAR(500)
)
AS
	UPDATE SPECIFICA_INVESTIMENTI
	SET
		ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimento, 
		COD_SPECIFICA = @CodSpecifica, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimento)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpecificaInvestimentiUpdate';

