CREATE PROCEDURE [dbo].[ZProgettoComunicazioniAllegatiUpdate]
(
	@Id INT, 
	@IdComunicazione INT, 
	@IdProgettoAllegati INT, 
	@IdAllegato INT, 
	@IdNote INT
)
AS
	UPDATE PROGETTO_COMUNICAZIONI_ALLEGATI
	SET
		ID_COMUNICAZIONE = @IdComunicazione, 
		ID_PROGETTO_ALLEGATI = @IdProgettoAllegati, 
		ID_ALLEGATO = @IdAllegato, 
		ID_NOTE = @IdNote
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniAllegatiUpdate';

