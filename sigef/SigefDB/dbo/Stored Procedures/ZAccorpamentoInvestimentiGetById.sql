CREATE PROCEDURE [dbo].[ZAccorpamentoInvestimentiGetById]
(
	@IdAccorpamentoInvestimenti INT
)
AS
	SELECT *
	FROM VACCORPAMENTO_INVESTIMENTI
	WHERE 
		(ID_ACCORPAMENTO_INVESTIMENTI = @IdAccorpamentoInvestimenti)

GO