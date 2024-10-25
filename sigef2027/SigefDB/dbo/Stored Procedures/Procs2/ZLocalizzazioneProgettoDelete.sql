
CREATE PROCEDURE [dbo].ZLocalizzazioneProgettoDelete
(
	@IdLocalizzazione INT
)
AS
	DELETE LOCALIZZAZIONE_PROGETTO
	WHERE 
		(ID_LOCALIZZAZIONE = @IdLocalizzazione)

