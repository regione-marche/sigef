CREATE PROCEDURE [dbo].[ZDomandaPagamentoAllegatiInsert]
(
	@IdDomandaPagamento INT, 
	@CodTipoDocumento VARCHAR(255), 
	@IdFile INT, 
	@Descrizione VARCHAR(255), 
	@CodEnteEmettitore VARCHAR(255), 
	@IdComune INT, 
	@Numero VARCHAR(255), 
	@Data DATETIME, 
	@CodEsito VARCHAR(255), 
	@NoteIstruttore NTEXT, 
	@InIntegrazione BIT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255)
)
AS
	SET @InIntegrazione = ISNULL(@InIntegrazione,((0)))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO DOMANDA_PAGAMENTO_ALLEGATI
	(
		ID_DOMANDA_PAGAMENTO, 
		COD_TIPO_DOCUMENTO, 
		ID_FILE, 
		DESCRIZIONE, 
		COD_ENTE_EMETTITORE, 
		ID_COMUNE, 
		NUMERO, 
		DATA, 
		COD_ESITO, 
		NOTE_ISTRUTTORE, 
		IN_INTEGRAZIONE, 
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@CodTipoDocumento, 
		@IdFile, 
		@Descrizione, 
		@CodEnteEmettitore, 
		@IdComune, 
		@Numero, 
		@Data, 
		@CodEsito, 
		@NoteIstruttore, 
		@InIntegrazione, 
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica
	)
	SELECT SCOPE_IDENTITY() AS ID_ALLEGATO, @InIntegrazione AS IN_INTEGRAZIONE, @DataModifica AS DATA_MODIFICA

GO