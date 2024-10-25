CREATE PROCEDURE [dbo].[ZPianoDiSviluppoDomandaPagamentoInsert]
(
	@Anno INT, 
	@IdDomandaPagamento INT, 
	@IdImpresa INT, 
	@IdProgetto INT, 
	@CostoInvestimento DECIMAL(10,2), 
	@MezziPropri DECIMAL(10,2), 
	@RisorseTerzi DECIMAL(10,2), 
	@ContributiPubblici DECIMAL(10,2), 
	@SpeseGestione DECIMAL(10,2), 
	@RimborsoDebito DECIMAL(10,2), 
	@EntrataGestione DECIMAL(10,2), 
	@AltreCoperture DECIMAL(10,2)
)
AS
	INSERT INTO PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO
	(
		ANNO, 
		ID_DOMANDA_PAGAMENTO, 
		ID_IMPRESA, 
		ID_PROGETTO, 
		COSTO_INVESTIMENTO, 
		MEZZI_PROPRI, 
		RISORSE_TERZI, 
		CONTRIBUTI_PUBBLICI, 
		SPESE_GESTIONE, 
		RIMBORSO_DEBITO, 
		ENTRATA_GESTIONE, 
		ALTRE_COPERTURE
	)
	VALUES
	(
		@Anno, 
		@IdDomandaPagamento, 
		@IdImpresa, 
		@IdProgetto, 
		@CostoInvestimento, 
		@MezziPropri, 
		@RisorseTerzi, 
		@ContributiPubblici, 
		@SpeseGestione, 
		@RimborsoDebito, 
		@EntrataGestione, 
		@AltreCoperture
	)
	SELECT SCOPE_IDENTITY() AS ID_PIANO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoDiSviluppoDomandaPagamentoInsert';

