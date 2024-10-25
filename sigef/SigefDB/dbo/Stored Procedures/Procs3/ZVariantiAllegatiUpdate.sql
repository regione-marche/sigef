CREATE PROCEDURE [dbo].[ZVariantiAllegatiUpdate]
(
	@IdAllegato INT, 
	@IdVariante INT, 
	@CodTipoDocumento VARCHAR(255), 
	@IdFile INT, 
	@Descrizione VARCHAR(255), 
	@CodEnteEmettitore VARCHAR(255), 
	@IdComune INT, 
	@Numero VARCHAR(255), 
	@Data DATETIME, 
	@CodEsito VARCHAR(255), 
	@NoteIstruttore NTEXT
)
AS
	UPDATE VARIANTI_ALLEGATI
	SET
		ID_VARIANTE = @IdVariante, 
		COD_TIPO_DOCUMENTO = @CodTipoDocumento, 
		ID_FILE = @IdFile, 
		DESCRIZIONE = @Descrizione, 
		COD_ENTE_EMETTITORE = @CodEnteEmettitore, 
		ID_COMUNE = @IdComune, 
		NUMERO = @Numero, 
		DATA = @Data, 
		COD_ESITO = @CodEsito, 
		NOTE_ISTRUTTORE = @NoteIstruttore
	WHERE 
		(ID_ALLEGATO = @IdAllegato)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZVariantiAllegatiUpdate]
(
	@IdAllegato INT, 
	@IdVariante INT, 
	@Descrizione VARCHAR(255), 
	@CodEsito CHAR(2), 
	@NoteIstruttore NTEXT
)
AS
	UPDATE VARIANTI_ALLEGATI
	SET
		ID_VARIANTE = @IdVariante, 
		DESCRIZIONE = @Descrizione, 
		COD_ESITO = @CodEsito, 
		NOTE_ISTRUTTORE = @NoteIstruttore
	WHERE 
		(ID_ALLEGATO = @IdAllegato)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiAllegatiUpdate';

