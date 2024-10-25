CREATE PROCEDURE [dbo].[ZAccorpamentoInvestimentiDelete]
(
	@IdAccorpamentoInvestimenti INT
)
AS
	DELETE ACCORPAMENTO_INVESTIMENTI
	WHERE 
		(ID_ACCORPAMENTO_INVESTIMENTI = @IdAccorpamentoInvestimenti)

GO