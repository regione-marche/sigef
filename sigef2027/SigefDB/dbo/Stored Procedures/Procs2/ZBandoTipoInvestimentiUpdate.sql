CREATE PROCEDURE [dbo].[ZBandoTipoInvestimentiUpdate]
(
	@IdTipoInvestimento INT, 
	@IdBando INT, 
	@CodTipoInvestimento INT, 
	@ImportoMax DECIMAL(15,2), 
	@ImportoMin DECIMAL(15,2), 
	@QuotaMax DECIMAL(10,2), 
	@Note VARCHAR(500), 
	@Premio BIT
)
AS
	UPDATE BANDO_TIPO_INVESTIMENTI
	SET
		ID_BANDO = @IdBando, 
		COD_TIPO_INVESTIMENTO = @CodTipoInvestimento, 
		IMPORTO_MAX = @ImportoMax, 
		IMPORTO_MIN = @ImportoMin, 
		QUOTA_MAX = @QuotaMax, 
		NOTE = @Note, 
		PREMIO = @Premio
	WHERE 
		(ID_TIPO_INVESTIMENTO = @IdTipoInvestimento)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZBandoTipoInvestimentiUpdate]
(
	@IdTipoInvestimento INT, 
	@IdBando INT, 
	@CodTipoInvestimento INT, 
	@ImportoMax DECIMAL(15,2), 
	@ImportoMin DECIMAL(15,2), 
	@QuotaMax DECIMAL(10,2), 
	@Note VARCHAR(500), 
	@Premio BIT
)
AS
	UPDATE BANDO_TIPO_INVESTIMENTI
	SET
		ID_BANDO = @IdBando, 
		COD_TIPO_INVESTIMENTO = @CodTipoInvestimento, 
		IMPORTO_MAX = @ImportoMax, 
		IMPORTO_MIN = @ImportoMin, 
		QUOTA_MAX = @QuotaMax, 
		NOTE = @Note, 
		PREMIO = @Premio
	WHERE 
		(ID_TIPO_INVESTIMENTO = @IdTipoInvestimento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoInvestimentiUpdate';

