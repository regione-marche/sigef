CREATE PROCEDURE [dbo].[ZAccorpamentoInvestimentiInsert]
(
	@CfCreazione VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@IdDomandaPagamento INT, 
	@IdInvestimentoX INT, 
	@IdInvestimentoY INT, 
	@IstanzaPianoInvestimenti XML, 
	@DataCreazione DATETIME
)
AS
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @DataCreazione = ISNULL(@DataCreazione,(getdate()))
	INSERT INTO ACCORPAMENTO_INVESTIMENTI
	(
		CF_CREAZIONE, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		ID_DOMANDA_PAGAMENTO, 
		ID_INVESTIMENTO_X, 
		ID_INVESTIMENTO_Y, 
		ISTANZA_PIANO_INVESTIMENTI, 
		DATA_CREAZIONE
	)
	VALUES
	(
		@CfCreazione, 
		@DataModifica, 
		@CfModifica, 
		@IdDomandaPagamento, 
		@IdInvestimentoX, 
		@IdInvestimentoY, 
		@IstanzaPianoInvestimenti, 
		@DataCreazione
	)
	SELECT SCOPE_IDENTITY() AS ID_ACCORPAMENTO_INVESTIMENTI, @DataModifica AS DATA_MODIFICA, @DataCreazione AS DATA_CREAZIONE

GO