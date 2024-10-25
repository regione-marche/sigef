CREATE PROCEDURE [dbo].[ZProgettoComunicazioneGetById]
(
	@IdComunicazione INT
)
AS
	SELECT *
	FROM vPROGETTO_COMUNICAZIONE
	WHERE 
		(ID_COMUNICAZIONE = @IdComunicazione)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioneGetById';

