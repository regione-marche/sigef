CREATE PROCEDURE [dbo].[ZProgettoComunicazioneAllegatoInsert]
(
	@IdComunicazione INT, 
	@IdProgetto INT, 
	@IdFile INT, 
	@Descrizione VARCHAR(max)
)
AS
	INSERT INTO PROGETTO_COMUNICAZIONE_ALLEGATO
	(
		ID_COMUNICAZIONE, 
		ID_PROGETTO, 
		ID_FILE, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdComunicazione, 
		@IdProgetto, 
		@IdFile, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioneAllegatoInsert';

