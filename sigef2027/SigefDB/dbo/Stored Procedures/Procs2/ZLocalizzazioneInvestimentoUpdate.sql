CREATE PROCEDURE [dbo].[ZLocalizzazioneInvestimentoUpdate]
(
	@IdLocalizzazione INT, 
	@IdInvestimento INT, 
	@IdCatasto INT
)
AS
	UPDATE LOCALIZZAZIONE_INVESTIMENTO
	SET
		ID_INVESTIMENTO = @IdInvestimento, 
		ID_CATASTO = @IdCatasto
	WHERE 
		(ID_LOCALIZZAZIONE = @IdLocalizzazione)
