CREATE PROCEDURE [dbo].[ZAccorpamentoInvestimentiUpdate]
(
	@IdAccorpamentoInvestimenti INT, 
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
	SET @DataModifica=getdate()
	UPDATE ACCORPAMENTO_INVESTIMENTI
	SET
		CF_CREAZIONE = @CfCreazione, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_INVESTIMENTO_X = @IdInvestimentoX, 
		ID_INVESTIMENTO_Y = @IdInvestimentoY, 
		ISTANZA_PIANO_INVESTIMENTI = @IstanzaPianoInvestimenti, 
		DATA_CREAZIONE = @DataCreazione
	WHERE 
		(ID_ACCORPAMENTO_INVESTIMENTI = @IdAccorpamentoInvestimenti)
	SELECT @DataModifica;

GO