CREATE PROCEDURE [dbo].[ZControlliDomandePagamentoUpdate]
(
	@IdLotto INT, 
	@IdDomandaPagamento INT, 
	@OperatoreAssegnato VARCHAR(16), 
	@SelezionataXControllo BIT, 
	@TipoEstrazione CHAR(1), 
	@ControlloConcluso BIT, 
	@ValoreDiRischio DECIMAL(10,4), 
	@ContributoRichiesto DECIMAL(18,2), 
	@DataModifica DATETIME, 
	@Operatore VARCHAR(16), 
	@ClasseDiRischio CHAR(1), 
	@OrdineClasseDiRischio INT
)
AS
	SET @DataModifica=getdate()
	UPDATE CONTROLLI_DOMANDE_PAGAMENTO
	SET
		OPERATORE_ASSEGNATO = @OperatoreAssegnato, 
		SELEZIONATA_X_CONTROLLO = @SelezionataXControllo, 
		TIPO_ESTRAZIONE = @TipoEstrazione, 
		CONTROLLO_CONCLUSO = @ControlloConcluso, 
		VALORE_DI_RISCHIO = @ValoreDiRischio, 
		CONTRIBUTO_RICHIESTO = @ContributoRichiesto, 
		DATA_MODIFICA = @DataModifica, 
		OPERATORE = @Operatore, 
		CLASSE_DI_RISCHIO = @ClasseDiRischio, 
		ORDINE_CLASSE_DI_RISCHIO = @OrdineClasseDiRischio
	WHERE 
		(ID_LOTTO = @IdLotto) AND 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento)
	SELECT @DataModifica;

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZControlliDomandePagamentoUpdate]
(
	@IdLotto INT, 
	@IdDomandaPagamento INT, 
	@OperatoreAssegnato VARCHAR(16), 
	@SelezionataXControllo BIT, 
	@TipoEstrazione CHAR(1), 
	@ControlloConcluso BIT, 
	@ValoreDiRischio DECIMAL(10,4), 
	@ContributoRichiesto DECIMAL(18,2), 
	@DataModifica DATETIME, 
	@Operatore VARCHAR(16)
)
AS
	SET @DataModifica=getdate()
	UPDATE CONTROLLI_DOMANDE_PAGAMENTO
	SET
		OPERATORE_ASSEGNATO = @OperatoreAssegnato, 
		SELEZIONATA_X_CONTROLLO = @SelezionataXControllo, 
		TIPO_ESTRAZIONE = @TipoEstrazione, 
		CONTROLLO_CONCLUSO = @ControlloConcluso, 
		VALORE_DI_RISCHIO = @ValoreDiRischio, 
		CONTRIBUTO_RICHIESTO = @ContributoRichiesto, 
		DATA_MODIFICA = @DataModifica, 
		OPERATORE = @Operatore
	WHERE 
		(ID_LOTTO = @IdLotto) AND 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento)
	SELECT @DataModifica;

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliDomandePagamentoUpdate';

