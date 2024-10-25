CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseAllegatiUpdate]
(
	@IdAllegato INT, 
	@IdManifestazione INT, 
	@Descrizione VARCHAR(255), 
	@CodEsito CHAR(2), 
	@NoteIstruttore NTEXT
)
AS
	UPDATE MANIFESTAZIONE_DI_INTERESSE_ALLEGATI
	SET
		ID_MANIFESTAZIONE = @IdManifestazione, 
		DESCRIZIONE = @Descrizione, 
		COD_ESITO = @CodEsito, 
		NOTE_ISTRUTTORE = @NoteIstruttore
	WHERE 
		(ID_ALLEGATO = @IdAllegato)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneDiInteresseAllegatiUpdate';

