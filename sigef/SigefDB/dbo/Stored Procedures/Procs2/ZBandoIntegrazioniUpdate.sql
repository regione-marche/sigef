CREATE PROCEDURE [dbo].[ZBandoIntegrazioniUpdate]
(
	@Id INT, 
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
	UPDATE BANDO_INTEGRAZIONI
	SET
		ID_BANDO = @IdBando, 
		DATA = @Data, 
		OPERATORE = @Operatore, 
		DATA_SCADENZA = @DataScadenza, 
		IMPORTO = @Importo, 
		IMPORTO_DI_MISURA = @ImportoDiMisura, 
		QUOTA_RISERVA = @QuotaRiserva, 
		ID_ATTO = @IdAtto
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoIntegrazioniUpdate]
(
	@Id INT, 
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
	UPDATE BANDO_INTEGRAZIONI
	SET
		ID_BANDO = @IdBando, 
		DATA = @Data, 
		OPERATORE = @Operatore, 
		DATA_SCADENZA = @DataScadenza, 
		IMPORTO = @Importo, 
		IMPORTO_DI_MISURA = @ImportoDiMisura, 
		QUOTA_RISERVA = @QuotaRiserva, 
		ID_ATTO = @IdAtto
	WHERE 
		(ID = @Id)


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoIntegrazioniUpdate';

