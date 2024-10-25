CREATE PROCEDURE [dbo].[ZProgettoInsert]
(
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
	SET @SelezionataXRevisione = ISNULL(@SelezionataXRevisione,((0)))
	SET @FirmaPredisposta = ISNULL(@FirmaPredisposta,((0)))
	INSERT INTO PROGETTO
	(
		ID_BANDO, 
		COD_AGEA, 
		SEGNATURA_ALLEGATI, 
		ID_PROG_INTEGRATO, 
		FLAG_PREADESIONE, 
		FLAG_DEFINITIVO, 
		ID_FASCICOLO, 
		PROVINCIA_DI_PRESENTAZIONE, 
		SELEZIONATA_X_REVISIONE, 
		ID_IMPRESA, 
		ID_STORICO_ULTIMO, 
		DATA_CREAZIONE, 
		OPERATORE_CREAZIONE, 
		FIRMA_PREDISPOSTA
	)
	VALUES
	(
		@IdBando, 
		@CodAgea, 
		@SegnaturaAllegati, 
		@IdProgIntegrato, 
		@FlagPreadesione, 
		@FlagDefinitivo, 
		@IdFascicolo, 
		@ProvinciaDiPresentazione, 
		@SelezionataXRevisione, 
		@IdImpresa, 
		@IdStoricoUltimo, 
		@DataCreazione, 
		@OperatoreCreazione, 
		@FirmaPredisposta
	)
	SELECT SCOPE_IDENTITY() AS ID_PROGETTO, @SelezionataXRevisione AS SELEZIONATA_X_REVISIONE, @FirmaPredisposta AS FIRMA_PREDISPOSTA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoInsert]
(
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
	SET @SelezionataXRevisione = ISNULL(@SelezionataXRevisione,((0)))
	SET @FirmaPredisposta = ISNULL(@FirmaPredisposta,((0)))
	INSERT INTO PROGETTO
	(
		ID_BANDO, 
		COD_AGEA, 
		SEGNATURA_ALLEGATI, 
		ID_PROG_INTEGRATO, 
		FLAG_PREADESIONE, 
		FLAG_DEFINITIVO, 
		ID_FASCICOLO, 
		PROVINCIA_DI_PRESENTAZIONE, 
		SELEZIONATA_X_REVISIONE, 
		ID_IMPRESA, 
		ID_STORICO_ULTIMO, 
		DATA_CREAZIONE, 
		OPERATORE_CREAZIONE, 
		FIRMA_PREDISPOSTA
	)
	VALUES
	(
		@IdBando, 
		@CodAgea, 
		@SegnaturaAllegati, 
		@IdProgIntegrato, 
		@FlagPreadesione, 
		@FlagDefinitivo, 
		@IdFascicolo, 
		@ProvinciaDiPresentazione, 
		@SelezionataXRevisione, 
		@IdImpresa, 
		@IdStoricoUltimo, 
		@DataCreazione, 
		@OperatoreCreazione, 
		@FirmaPredisposta
	)
	SELECT SCOPE_IDENTITY() AS ID_PROGETTO, @SelezionataXRevisione AS SELEZIONATA_X_REVISIONE, @FirmaPredisposta AS FIRMA_PREDISPOSTA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoInsert';

