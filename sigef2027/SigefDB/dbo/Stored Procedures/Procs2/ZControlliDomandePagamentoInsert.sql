CREATE PROCEDURE [dbo].[ZControlliDomandePagamentoInsert]
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
	SET @SelezionataXControllo = ISNULL(@SelezionataXControllo,((0)))
	SET @ControlloConcluso = ISNULL(@ControlloConcluso,((0)))
	INSERT INTO CONTROLLI_DOMANDE_PAGAMENTO
	(
		ID_LOTTO, 
		ID_DOMANDA_PAGAMENTO, 
		OPERATORE_ASSEGNATO, 
		SELEZIONATA_X_CONTROLLO, 
		TIPO_ESTRAZIONE, 
		CONTROLLO_CONCLUSO, 
		VALORE_DI_RISCHIO, 
		CONTRIBUTO_RICHIESTO, 
		DATA_MODIFICA, 
		OPERATORE, 
		CLASSE_DI_RISCHIO, 
		ORDINE_CLASSE_DI_RISCHIO
	)
	VALUES
	(
		@IdLotto, 
		@IdDomandaPagamento, 
		@OperatoreAssegnato, 
		@SelezionataXControllo, 
		@TipoEstrazione, 
		@ControlloConcluso, 
		@ValoreDiRischio, 
		@ContributoRichiesto, 
		@DataModifica, 
		@Operatore, 
		@ClasseDiRischio, 
		@OrdineClasseDiRischio
	)
	SELECT @SelezionataXControllo AS SELEZIONATA_X_CONTROLLO, @ControlloConcluso AS CONTROLLO_CONCLUSO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZControlliDomandePagamentoInsert]
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
	SET @SelezionataXControllo = ISNULL(@SelezionataXControllo,((0)))
	SET @ControlloConcluso = ISNULL(@ControlloConcluso,((0)))
	INSERT INTO CONTROLLI_DOMANDE_PAGAMENTO
	(
		ID_LOTTO, 
		ID_DOMANDA_PAGAMENTO, 
		OPERATORE_ASSEGNATO, 
		SELEZIONATA_X_CONTROLLO, 
		TIPO_ESTRAZIONE, 
		CONTROLLO_CONCLUSO, 
		VALORE_DI_RISCHIO, 
		CONTRIBUTO_RICHIESTO, 
		DATA_MODIFICA, 
		OPERATORE
	)
	VALUES
	(
		@IdLotto, 
		@IdDomandaPagamento, 
		@OperatoreAssegnato, 
		@SelezionataXControllo, 
		@TipoEstrazione, 
		@ControlloConcluso, 
		@ValoreDiRischio, 
		@ContributoRichiesto, 
		@DataModifica, 
		@Operatore
	)
	SELECT @SelezionataXControllo AS SELEZIONATA_X_CONTROLLO, @ControlloConcluso AS CONTROLLO_CONCLUSO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliDomandePagamentoInsert';

