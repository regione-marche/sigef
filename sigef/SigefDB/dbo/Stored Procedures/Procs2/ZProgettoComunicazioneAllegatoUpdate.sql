CREATE PROCEDURE [dbo].[ZProgettoComunicazioneAllegatoUpdate]
(
	@Id INT, 
	@IdComunicazione INT, 
	@IdProgetto INT, 
	@IdFile INT, 
	@Descrizione VARCHAR(max)
)
AS
	UPDATE PROGETTO_COMUNICAZIONE_ALLEGATO
	SET
		ID_COMUNICAZIONE = @IdComunicazione, 
		ID_PROGETTO = @IdProgetto, 
		ID_FILE = @IdFile, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioneAllegatoUpdate';

