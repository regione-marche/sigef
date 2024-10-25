CREATE PROCEDURE [dbo].[ZProgettoComunicazioniAllegatiInsert]
(
	@IdComunicazione INT, 
	@IdProgettoAllegati INT, 
	@IdAllegato INT, 
	@IdNote INT
)
AS
	INSERT INTO PROGETTO_COMUNICAZIONI_ALLEGATI
	(
		ID_COMUNICAZIONE, 
		ID_PROGETTO_ALLEGATI, 
		ID_ALLEGATO, 
		ID_NOTE
	)
	VALUES
	(
		@IdComunicazione, 
		@IdProgettoAllegati, 
		@IdAllegato, 
		@IdNote
	)
	SELECT SCOPE_IDENTITY() AS ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniAllegatiInsert';

