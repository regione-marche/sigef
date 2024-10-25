CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiUpdate]
(
	@Id INT, 
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
	UPDATE PROGETTO_COMUNICAZIONI_DOCUMENTI
	SET
		ID_COMUNICAZIONE = @IdComunicazione, 
		ID_DOMANDA_PAGAMENTO_ALLEGATI = @IdDomandaPagamentoAllegati, 
		ID_VARIANTE_ALLEGATI = @IdVarianteAllegati, 
		COD_TIPO_DOCUMENTO = @CodTipoDocumento, 
		ID_FILE = @IdFile, 
		COD_ENTE_EMETTITORE = @CodEnteEmettitore, 
		ID_COMUNE = @IdComune, 
		NUMERO = @Numero, 
		DATA = @Data, 
		DESCRIZIONE = @Descrizione, 
		ID_NOTE_COMUNICAZIONE = @IdNoteComunicazione
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDocumentiUpdate]
(
	@Id INT, 
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
	UPDATE PROGETTO_COMUNICAZIONI_DOCUMENTI
	SET
		ID_COMUNICAZIONE = @IdComunicazione, 
		COD_TIPO_DOCUMENTO = @CodTipoDocumento, 
		ID_FILE = @IdFile, 
		COD_ENTE_EMETTITORE = @CodEnteEmettitore, 
		ID_COMUNE = @IdComune, 
		NUMERO = @Numero, 
		DATA = @Data, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniDocumentiUpdate';

