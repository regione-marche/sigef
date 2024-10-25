CREATE PROCEDURE [dbo].[ZPagamentiRichiestiFemInsert]
(
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
	SET @Ammesso = ISNULL(@Ammesso,((0)))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO PAGAMENTI_RICHIESTI_FEM
	(
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		ID_CONTRATTO, 
		ID_INVESTIMENTO, 
		IMPORTO_RICHIESTO, 
		IMPORTO_AMMESSO, 
		AMMESSO, 
		CF_ISTRUTTORE, 
		DATA_VALUTAZIONE, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		NOTE_ISTRUTTORE, 
		ID_DOMANDA_PAGAMENTO, 
		ID_GIUSTIFICATIVO
	)
	VALUES
	(
		@DataInserimento, 
		@CfInserimento, 
		@IdContratto, 
		@IdInvestimento, 
		@ImportoRichiesto, 
		@ImportoAmmesso, 
		@Ammesso, 
		@CfIstruttore, 
		@DataValutazione, 
		@DataModifica, 
		@CfModifica, 
		@NoteIstruttore, 
		@IdDomandaPagamento, 
		@IdGiustificativo
	)
	SELECT SCOPE_IDENTITY() AS ID_PAGAMENTO_RICHIESTO_FEM, @Ammesso AS AMMESSO, @DataModifica AS DATA_MODIFICA

GO