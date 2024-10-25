CREATE PROCEDURE [dbo].[ZProgettoAllegatiUpdate]
(
	@Id INT, 
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
	UPDATE PROGETTO_ALLEGATI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_ALLEGATO = @IdAllegato, 
		ID_FILE = @IdFile, 
		DESCRIZIONE_BREVE = @DescrizioneBreve, 
		COD_ENTE_EMETTITORE = @CodEnteEmettitore, 
		ID_COMUNE = @IdComune, 
		NUMERO = @Numero, 
		DATA = @Data, 
		GIA_PRESENTATO = @GiaPresentato, 
		COD_ESITO_ISTRUTTORIA = @CodEsitoIstruttoria, 
		NOTE_ISTRUTTORIA = @NoteIstruttoria
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoAllegatiUpdate]
(
	@Id INT, 
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
	UPDATE PROGETTO_ALLEGATI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_ALLEGATO = @IdAllegato, 
		ID_FILE = @IdFile, 
		DESCRIZIONE_BREVE = @DescrizioneBreve, 
		COD_ENTE_EMETTITORE = @CodEnteEmettitore, 
		ID_COMUNE = @IdComune, 
		NUMERO = @Numero, 
		DATA = @Data, 
		GIA_PRESENTATO = @GiaPresentato, 
		COD_ESITO_ISTRUTTORIA = @CodEsitoIstruttoria, 
		NOTE_ISTRUTTORIA = @NoteIstruttoria
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoAllegatiUpdate';

