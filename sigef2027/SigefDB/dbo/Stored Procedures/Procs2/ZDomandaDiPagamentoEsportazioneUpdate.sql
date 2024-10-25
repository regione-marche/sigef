CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneUpdate]
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
	UPDATE DOMANDA_DI_PAGAMENTO_ESPORTAZIONE
	SET
		BARCODE = @Barcode, 
		MISURA_PREVALENTE = @MisuraPrevalente, 
		IMPORTO_AMMISSIBILE = @ImportoAmmissibile, 
		IMPORTO_SANZIONE = @ImportoSanzione, 
		IMPORTO_RECUPERO_ANTICIPO = @ImportoRecuperoAnticipo, 
		IMPORTO_AMMESSO = @ImportoAmmesso, 
		IMPORTO_LIQUIDATO = @ImportoLiquidato, 
		FLAG_LIQUIDATO = @FlagLiquidato, 
		ID_DECRETO = @IdDecreto
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_PROGETTO = @IdProgetto)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoEsportazioneUpdate]
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
	UPDATE DOMANDA_DI_PAGAMENTO_ESPORTAZIONE
	SET
		BARCODE = @Barcode, 
		MISURA_PREVALENTE = @MisuraPrevalente, 
		IMPORTO_AMMISSIBILE = @ImportoAmmissibile, 
		IMPORTO_SANZIONE = @ImportoSanzione, 
		IMPORTO_RECUPERO_ANTICIPO = @ImportoRecuperoAnticipo, 
		IMPORTO_AMMESSO = @ImportoAmmesso, 
		IMPORTO_LIQUIDATO = @ImportoLiquidato, 
		FLAG_LIQUIDATO = @FlagLiquidato, 
		ID_DECRETO = @IdDecreto
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoEsportazioneUpdate';

