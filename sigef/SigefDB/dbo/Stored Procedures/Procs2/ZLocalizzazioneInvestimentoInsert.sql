CREATE PROCEDURE [dbo].[ZLocalizzazioneInvestimentoInsert]
(
	@IdInvestimento INT, 
	@IdCatasto INT
)
AS
	INSERT INTO LOCALIZZAZIONE_INVESTIMENTO
	(
		ID_INVESTIMENTO, 
		ID_CATASTO
	)
	VALUES
	(
		@IdInvestimento, 
		@IdCatasto
	)
	SELECT SCOPE_IDENTITY() AS ID_LOCALIZZAZIONE
