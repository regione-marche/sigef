CREATE PROCEDURE [dbo].[ZSpecificaInvestimentiInsert]
(
	@IdDettaglioInvestimento INT, 
	@CodSpecifica VARCHAR(255), 
	@Descrizione VARCHAR(500)
)
AS
	INSERT INTO SPECIFICA_INVESTIMENTI
	(
		ID_DETTAGLIO_INVESTIMENTO, 
		COD_SPECIFICA, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdDettaglioInvestimento, 
		@CodSpecifica, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_SPECIFICA_INVESTIMENTO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSpecificaInvestimentiInsert]
(
	@IdDettaglioInvestimento INT, 
	@CodSpecifica CHAR(2), 
	@Descrizione VARCHAR(500)
)
AS
	INSERT INTO SPECIFICA_INVESTIMENTI
	(
		ID_DETTAGLIO_INVESTIMENTO, 
		COD_SPECIFICA, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdDettaglioInvestimento, 
		@CodSpecifica, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_SPECIFICA_INVESTIMENTO
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpecificaInvestimentiInsert';

