CREATE PROCEDURE [dbo].[ZLocalizzazioneInvestimentoDelete]
(
	@IdLocalizzazione INT
)
AS
	DELETE LOCALIZZAZIONE_INVESTIMENTO
	WHERE 
		(ID_LOCALIZZAZIONE = @IdLocalizzazione)
