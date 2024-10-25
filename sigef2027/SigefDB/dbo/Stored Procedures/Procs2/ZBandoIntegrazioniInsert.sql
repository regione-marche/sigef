CREATE PROCEDURE [dbo].[ZBandoIntegrazioniInsert]
(
	@IdBando INT, 
	@Data DATETIME, 
	@Operatore INT, 
	@DataScadenza DATETIME, 
	@Importo DECIMAL(18,2), 
	@ImportoDiMisura DECIMAL(18,2), 
	@QuotaRiserva DECIMAL(10,2), 
	@IdAtto INT
)
AS
	SET @ImportoDiMisura = ISNULL(@ImportoDiMisura,((0)))
	SET @QuotaRiserva = ISNULL(@QuotaRiserva,((0)))
	INSERT INTO BANDO_INTEGRAZIONI
	(
		ID_BANDO, 
		DATA, 
		OPERATORE, 
		DATA_SCADENZA, 
		IMPORTO, 
		IMPORTO_DI_MISURA, 
		QUOTA_RISERVA, 
		ID_ATTO
	)
	VALUES
	(
		@IdBando, 
		@Data, 
		@Operatore, 
		@DataScadenza, 
		@Importo, 
		@ImportoDiMisura, 
		@QuotaRiserva, 
		@IdAtto
	)
	SELECT SCOPE_IDENTITY() AS ID, @ImportoDiMisura AS IMPORTO_DI_MISURA, @QuotaRiserva AS QUOTA_RISERVA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoIntegrazioniInsert]
(
	@IdBando INT, 
	@Data DATETIME, 
	@Operatore INT, 
	@DataScadenza DATETIME, 
	@Importo DECIMAL(18,2), 
	@ImportoDiMisura DECIMAL(18,2), 
	@QuotaRiserva DECIMAL(10,2), 
	@IdAtto INT
)
AS
	SET @ImportoDiMisura = ISNULL(@ImportoDiMisura,((0)))
	SET @QuotaRiserva = ISNULL(@QuotaRiserva,((0)))
	INSERT INTO BANDO_INTEGRAZIONI
	(
		ID_BANDO, 
		DATA, 
		OPERATORE, 
		DATA_SCADENZA, 
		IMPORTO, 
		IMPORTO_DI_MISURA, 
		QUOTA_RISERVA, 
		ID_ATTO
	)
	VALUES
	(
		@IdBando, 
		@Data, 
		@Operatore, 
		@DataScadenza, 
		@Importo, 
		@ImportoDiMisura, 
		@QuotaRiserva, 
		@IdAtto
	)
	SELECT SCOPE_IDENTITY() AS ID, @ImportoDiMisura AS IMPORTO_DI_MISURA, @QuotaRiserva AS QUOTA_RISERVA


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoIntegrazioniInsert';

