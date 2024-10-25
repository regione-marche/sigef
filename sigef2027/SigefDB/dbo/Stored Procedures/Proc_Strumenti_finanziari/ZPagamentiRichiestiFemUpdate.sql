CREATE PROCEDURE [dbo].[ZPagamentiRichiestiFemUpdate]
(
	@IdPagamentoRichiestoFem INT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@IdContratto INT, 
	@IdInvestimento INT, 
	@ImportoRichiesto DECIMAL(18,2), 
	@ImportoAmmesso DECIMAL(18,2), 
	@Ammesso BIT, 
	@CfIstruttore VARCHAR(255), 
	@DataValutazione DATETIME, 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@NoteIstruttore VARCHAR(max), 
	@IdDomandaPagamento INT, 
	@IdGiustificativo INT
)
AS
	SET @DataModifica=getdate()
	UPDATE PAGAMENTI_RICHIESTI_FEM
	SET
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		ID_CONTRATTO = @IdContratto, 
		ID_INVESTIMENTO = @IdInvestimento, 
		IMPORTO_RICHIESTO = @ImportoRichiesto, 
		IMPORTO_AMMESSO = @ImportoAmmesso, 
		AMMESSO = @Ammesso, 
		CF_ISTRUTTORE = @CfIstruttore, 
		DATA_VALUTAZIONE = @DataValutazione, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		NOTE_ISTRUTTORE = @NoteIstruttore, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_GIUSTIFICATIVO = @IdGiustificativo
	WHERE 
		(ID_PAGAMENTO_RICHIESTO_FEM = @IdPagamentoRichiestoFem)
	SELECT @DataModifica;

GO