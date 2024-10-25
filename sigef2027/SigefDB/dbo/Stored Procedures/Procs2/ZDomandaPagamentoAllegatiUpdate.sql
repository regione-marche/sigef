CREATE PROCEDURE [dbo].[ZDomandaPagamentoAllegatiUpdate]
(
	@IdAllegato INT, 
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
	SET @DataModifica=getdate()
	UPDATE DOMANDA_PAGAMENTO_ALLEGATI
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		COD_TIPO_DOCUMENTO = @CodTipoDocumento, 
		ID_FILE = @IdFile, 
		DESCRIZIONE = @Descrizione, 
		COD_ENTE_EMETTITORE = @CodEnteEmettitore, 
		ID_COMUNE = @IdComune, 
		NUMERO = @Numero, 
		DATA = @Data, 
		COD_ESITO = @CodEsito, 
		NOTE_ISTRUTTORE = @NoteIstruttore, 
		IN_INTEGRAZIONE = @InIntegrazione, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica
	WHERE 
		(ID_ALLEGATO = @IdAllegato)
	SELECT @DataModifica;

GO