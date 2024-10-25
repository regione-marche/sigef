CREATE PROCEDURE [dbo].[ZLocalizzazioneInvestimentoGetById]
(
	@IdLocalizzazione INT
)
AS
	SELECT *
	FROM vLOCALIZZAZIONE_INVESTIMENTO
	WHERE 
		(ID_LOCALIZZAZIONE = @IdLocalizzazione)
