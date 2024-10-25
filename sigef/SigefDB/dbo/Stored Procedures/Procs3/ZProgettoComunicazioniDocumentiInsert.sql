CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiInsert]
(
	@IdComunicazione INT, 
	@IdDomandaPagamentoAllegati INT, 
	@IdVarianteAllegati INT, 
	@CodTipoDocumento VARCHAR(255), 
	@IdFile INT, 
	@CodEnteEmettitore VARCHAR(255), 
	@IdComune INT, 
	@Numero VARCHAR(255), 
	@Data DATETIME, 
	@Descrizione VARCHAR(255), 
	@IdNoteComunicazione INT
)
AS
	INSERT INTO PROGETTO_COMUNICAZIONI_DOCUMENTI
	(
		ID_COMUNICAZIONE, 
		ID_DOMANDA_PAGAMENTO_ALLEGATI, 
		ID_VARIANTE_ALLEGATI, 
		COD_TIPO_DOCUMENTO, 
		ID_FILE, 
		COD_ENTE_EMETTITORE, 
		ID_COMUNE, 
		NUMERO, 
		DATA, 
		DESCRIZIONE, 
		ID_NOTE_COMUNICAZIONE
	)
	VALUES
	(
		@IdComunicazione, 
		@IdDomandaPagamentoAllegati, 
		@IdVarianteAllegati, 
		@CodTipoDocumento, 
		@IdFile, 
		@CodEnteEmettitore, 
		@IdComune, 
		@Numero, 
		@Data, 
		@Descrizione, 
		@IdNoteComunicazione
	)
	SELECT SCOPE_IDENTITY() AS ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiInsert]
(
	@IdComunicazione INT, 
	@CodTipoDocumento VARCHAR(255), 
	@IdFile INT, 
	@CodEnteEmettitore VARCHAR(255), 
	@IdComune INT, 
	@Numero VARCHAR(255), 
	@Data DATETIME, 
	@Descrizione VARCHAR(255)
)
AS
	INSERT INTO PROGETTO_COMUNICAZIONI_DOCUMENTI
	(
		ID_COMUNICAZIONE, 
		COD_TIPO_DOCUMENTO, 
		ID_FILE, 
		COD_ENTE_EMETTITORE, 
		ID_COMUNE, 
		NUMERO, 
		DATA, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdComunicazione, 
		@CodTipoDocumento, 
		@IdFile, 
		@CodEnteEmettitore, 
		@IdComune, 
		@Numero, 
		@Data, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniDocumentiInsert';

