CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneInsert]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@Barcode VARCHAR(255), 
	@MisuraPrevalente BIT, 
	@ImportoAmmissibile DECIMAL(18,2), 
	@ImportoSanzione DECIMAL(18,2), 
	@ImportoRecuperoAnticipo DECIMAL(18,2), 
	@ImportoAmmesso DECIMAL(18,2), 
	@ImportoLiquidato DECIMAL(18,2), 
	@FlagLiquidato BIT, 
	@IdDecreto INT
)
AS
	INSERT INTO DOMANDA_DI_PAGAMENTO_ESPORTAZIONE
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_PROGETTO, 
		BARCODE, 
		MISURA_PREVALENTE, 
		IMPORTO_AMMISSIBILE, 
		IMPORTO_SANZIONE, 
		IMPORTO_RECUPERO_ANTICIPO, 
		IMPORTO_AMMESSO, 
		IMPORTO_LIQUIDATO, 
		FLAG_LIQUIDATO, 
		ID_DECRETO
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdProgetto, 
		@Barcode, 
		@MisuraPrevalente, 
		@ImportoAmmissibile, 
		@ImportoSanzione, 
		@ImportoRecuperoAnticipo, 
		@ImportoAmmesso, 
		@ImportoLiquidato, 
		@FlagLiquidato, 
		@IdDecreto
	)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneInsert]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@Barcode VARCHAR(255), 
	@MisuraPrevalente BIT, 
	@ImportoAmmissibile DECIMAL(18,2), 
	@ImportoSanzione DECIMAL(18,2), 
	@ImportoRecuperoAnticipo DECIMAL(18,2), 
	@ImportoAmmesso DECIMAL(18,2), 
	@ImportoLiquidato DECIMAL(18,2), 
	@FlagLiquidato BIT, 
	@IdDecreto INT
)
AS
	INSERT INTO DOMANDA_DI_PAGAMENTO_ESPORTAZIONE
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_PROGETTO, 
		BARCODE, 
		MISURA_PREVALENTE, 
		IMPORTO_AMMISSIBILE, 
		IMPORTO_SANZIONE, 
		IMPORTO_RECUPERO_ANTICIPO, 
		IMPORTO_AMMESSO, 
		IMPORTO_LIQUIDATO, 
		FLAG_LIQUIDATO, 
		ID_DECRETO
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdProgetto, 
		@Barcode, 
		@MisuraPrevalente, 
		@ImportoAmmissibile, 
		@ImportoSanzione, 
		@ImportoRecuperoAnticipo, 
		@ImportoAmmesso, 
		@ImportoLiquidato, 
		@FlagLiquidato, 
		@IdDecreto
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoEsportazioneInsert';

