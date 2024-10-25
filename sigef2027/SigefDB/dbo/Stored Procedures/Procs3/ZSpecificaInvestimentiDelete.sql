CREATE PROCEDURE [dbo].[ZSpecificaInvestimentiDelete]
(
	@IdSpecificaInvestimento INT
)
AS
	DELETE SPECIFICA_INVESTIMENTI
	WHERE 
		(ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSpecificaInvestimentiDelete]
(
	@IdSpecificaInvestimento INT
)
AS
	DELETE SPECIFICA_INVESTIMENTI
	WHERE 
		(ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimento)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpecificaInvestimentiDelete';

