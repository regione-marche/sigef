CREATE PROCEDURE [dbo].[ZProgettoUpdate]
(
	@IdProgetto INT, 
	@IdBando INT, 
	@CodAgea VARCHAR(255), 
	@SegnaturaAllegati VARCHAR(255), 
	@IdProgIntegrato INT, 
	@FlagPreadesione BIT, 
	@FlagDefinitivo BIT, 
	@IdFascicolo INT, 
	@ProvinciaDiPresentazione VARCHAR(255), 
	@SelezionataXRevisione BIT, 
	@IdImpresa INT, 
	@IdStoricoUltimo INT, 
	@DataCreazione DATETIME, 
	@OperatoreCreazione INT, 
	@FirmaPredisposta BIT
)
AS
	UPDATE PROGETTO
	SET
		ID_BANDO = @IdBando, 
		COD_AGEA = @CodAgea, 
		SEGNATURA_ALLEGATI = @SegnaturaAllegati, 
		ID_PROG_INTEGRATO = @IdProgIntegrato, 
		FLAG_PREADESIONE = @FlagPreadesione, 
		FLAG_DEFINITIVO = @FlagDefinitivo, 
		ID_FASCICOLO = @IdFascicolo, 
		PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazione, 
		SELEZIONATA_X_REVISIONE = @SelezionataXRevisione, 
		ID_IMPRESA = @IdImpresa, 
		ID_STORICO_ULTIMO = @IdStoricoUltimo, 
		DATA_CREAZIONE = @DataCreazione, 
		OPERATORE_CREAZIONE = @OperatoreCreazione, 
		FIRMA_PREDISPOSTA = @FirmaPredisposta
	WHERE 
		(ID_PROGETTO = @IdProgetto)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoUpdate]
(
	@IdProgetto INT, 
	@IdBando INT, 
	@CodAgea VARCHAR(255), 
	@SegnaturaAllegati VARCHAR(255), 
	@IdProgIntegrato INT, 
	@FlagPreadesione BIT, 
	@FlagDefinitivo BIT, 
	@IdFascicolo INT, 
	@ProvinciaDiPresentazione VARCHAR(255), 
	@SelezionataXRevisione BIT, 
	@IdImpresa INT, 
	@IdStoricoUltimo INT, 
	@DataCreazione DATETIME, 
	@OperatoreCreazione INT, 
	@FirmaPredisposta BIT
)
AS
	UPDATE PROGETTO
	SET
		ID_BANDO = @IdBando, 
		COD_AGEA = @CodAgea, 
		SEGNATURA_ALLEGATI = @SegnaturaAllegati, 
		ID_PROG_INTEGRATO = @IdProgIntegrato, 
		FLAG_PREADESIONE = @FlagPreadesione, 
		FLAG_DEFINITIVO = @FlagDefinitivo, 
		ID_FASCICOLO = @IdFascicolo, 
		PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazione, 
		SELEZIONATA_X_REVISIONE = @SelezionataXRevisione, 
		ID_IMPRESA = @IdImpresa, 
		ID_STORICO_ULTIMO = @IdStoricoUltimo, 
		DATA_CREAZIONE = @DataCreazione, 
		OPERATORE_CREAZIONE = @OperatoreCreazione, 
		FIRMA_PREDISPOSTA = @FirmaPredisposta
	WHERE 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoUpdate';

