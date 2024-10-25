CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseAllegatiInsert]
(
	@IdManifestazione INT, 
	@Descrizione VARCHAR(255), 
	@CodEsito CHAR(2), 
	@NoteIstruttore NTEXT
)
AS
	INSERT INTO MANIFESTAZIONE_DI_INTERESSE_ALLEGATI
	(
		ID_MANIFESTAZIONE, 
		DESCRIZIONE, 
		COD_ESITO, 
		NOTE_ISTRUTTORE
	)
	VALUES
	(
		@IdManifestazione, 
		@Descrizione, 
		@CodEsito, 
		@NoteIstruttore
	)
	SELECT SCOPE_IDENTITY() AS ID_ALLEGATO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneDiInteresseAllegatiInsert';

