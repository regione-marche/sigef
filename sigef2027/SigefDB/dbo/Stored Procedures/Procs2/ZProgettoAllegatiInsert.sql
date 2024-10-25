CREATE PROCEDURE [dbo].[ZProgettoAllegatiInsert]
(
	@IdProgetto INT, 
	@IdAllegato INT, 
	@IdFile INT, 
	@DescrizioneBreve VARCHAR(255), 
	@CodEnteEmettitore VARCHAR(255), 
	@IdComune INT, 
	@Numero VARCHAR(255), 
	@Data DATETIME, 
	@GiaPresentato BIT, 
	@CodEsitoIstruttoria VARCHAR(255), 
	@NoteIstruttoria VARCHAR(1000)
)
AS
	SET @GiaPresentato = ISNULL(@GiaPresentato,((0)))
	INSERT INTO PROGETTO_ALLEGATI
	(
		ID_PROGETTO, 
		ID_ALLEGATO, 
		ID_FILE, 
		DESCRIZIONE_BREVE, 
		COD_ENTE_EMETTITORE, 
		ID_COMUNE, 
		NUMERO, 
		DATA, 
		GIA_PRESENTATO, 
		COD_ESITO_ISTRUTTORIA, 
		NOTE_ISTRUTTORIA
	)
	VALUES
	(
		@IdProgetto, 
		@IdAllegato, 
		@IdFile, 
		@DescrizioneBreve, 
		@CodEnteEmettitore, 
		@IdComune, 
		@Numero, 
		@Data, 
		@GiaPresentato, 
		@CodEsitoIstruttoria, 
		@NoteIstruttoria
	)
	SELECT SCOPE_IDENTITY() AS ID, @GiaPresentato AS GIA_PRESENTATO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoAllegatiInsert]
(
	@IdProgetto INT, 
	@IdAllegato INT, 
	@IdFile INT, 
	@DescrizioneBreve VARCHAR(255), 
	@CodEnteEmettitore VARCHAR(255), 
	@IdComune INT, 
	@Numero VARCHAR(255), 
	@Data DATETIME, 
	@GiaPresentato BIT, 
	@CodEsitoIstruttoria VARCHAR(255), 
	@NoteIstruttoria VARCHAR(1000)
)
AS
	SET @GiaPresentato = ISNULL(@GiaPresentato,((0)))
	INSERT INTO PROGETTO_ALLEGATI
	(
		ID_PROGETTO, 
		ID_ALLEGATO, 
		ID_FILE, 
		DESCRIZIONE_BREVE, 
		COD_ENTE_EMETTITORE, 
		ID_COMUNE, 
		NUMERO, 
		DATA, 
		GIA_PRESENTATO, 
		COD_ESITO_ISTRUTTORIA, 
		NOTE_ISTRUTTORIA
	)
	VALUES
	(
		@IdProgetto, 
		@IdAllegato, 
		@IdFile, 
		@DescrizioneBreve, 
		@CodEnteEmettitore, 
		@IdComune, 
		@Numero, 
		@Data, 
		@GiaPresentato, 
		@CodEsitoIstruttoria, 
		@NoteIstruttoria
	)
	SELECT SCOPE_IDENTITY() AS ID, @GiaPresentato AS GIA_PRESENTATO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoAllegatiInsert';

