CREATE PROCEDURE [dbo].[ZVariantiAllegatiInsert]
(
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
	INSERT INTO VARIANTI_ALLEGATI
	(
		ID_VARIANTE, 
		COD_TIPO_DOCUMENTO, 
		ID_FILE, 
		DESCRIZIONE, 
		COD_ENTE_EMETTITORE, 
		ID_COMUNE, 
		NUMERO, 
		DATA, 
		COD_ESITO, 
		NOTE_ISTRUTTORE
	)
	VALUES
	(
		@IdVariante, 
		@CodTipoDocumento, 
		@IdFile, 
		@Descrizione, 
		@CodEnteEmettitore, 
		@IdComune, 
		@Numero, 
		@Data, 
		@CodEsito, 
		@NoteIstruttore
	)
	SELECT SCOPE_IDENTITY() AS ID_ALLEGATO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZVariantiAllegatiInsert]
(
	@IdVariante INT, 
	@Descrizione VARCHAR(255), 
	@CodEsito CHAR(2), 
	@NoteIstruttore NTEXT
)
AS
	INSERT INTO VARIANTI_ALLEGATI
	(
		ID_VARIANTE, 
		DESCRIZIONE, 
		COD_ESITO, 
		NOTE_ISTRUTTORE
	)
	VALUES
	(
		@IdVariante, 
		@Descrizione, 
		@CodEsito, 
		@NoteIstruttore
	)
	SELECT SCOPE_IDENTITY() AS ID_ALLEGATO
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiAllegatiInsert';

