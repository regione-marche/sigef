CREATE PROCEDURE [dbo].[ZPianoInvestimentiDelete]
(
	@IdInvestimento INT
)
AS
	DELETE PIANO_INVESTIMENTI
	WHERE 
		(ID_INVESTIMENTO = @IdInvestimento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPianoInvestimentiDelete]
(
	@IdInvestimento INT
)
AS
	DELETE PIANO_INVESTIMENTI
	WHERE 
		(ID_INVESTIMENTO = @IdInvestimento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoInvestimentiDelete';

