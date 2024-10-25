
CREATE PROCEDURE [dbo].[ZLocalizzazioneProgettoGetById]
(
	@IdLocalizzazione INT
)
AS
	SELECT *
	FROM vLOCALIZZAZIONE_PROGETTO
	WHERE 
		(ID_LOCALIZZAZIONE = @IdLocalizzazione)

