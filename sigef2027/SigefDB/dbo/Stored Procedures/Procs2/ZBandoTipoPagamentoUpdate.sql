CREATE PROCEDURE [dbo].[ZBandoTipoPagamentoUpdate]
(
	@IdBando INT, 
	@CodTipo CHAR(3), 
	@QuotaMax DECIMAL(10,2), 
	@QuotaMin DECIMAL(10,2), 
	@ImportoMax DECIMAL(18,2), 
	@ImportoMin DECIMAL(18,2), 
	@Numero INT, 
	@CodTipoPolizza CHAR(3)
)
AS
	UPDATE BANDO_TIPO_PAGAMENTO
	SET
		QUOTA_MAX = @QuotaMax, 
		QUOTA_MIN = @QuotaMin, 
		IMPORTO_MAX = @ImportoMax, 
		IMPORTO_MIN = @ImportoMin, 
		NUMERO = @Numero, 
		COD_TIPO_POLIZZA = @CodTipoPolizza
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoTipoPagamentoUpdate]
(
	@IdBando INT, 
	@CodTipo CHAR(3), 
	@QuotaMax DECIMAL(10,2), 
	@QuotaMin DECIMAL(10,2), 
	@ImportoMax DECIMAL(18,2), 
	@ImportoMin DECIMAL(18,2), 
	@Numero INT
)
AS
	UPDATE BANDO_TIPO_PAGAMENTO
	SET
		QUOTA_MAX = @QuotaMax, 
		QUOTA_MIN = @QuotaMin, 
		IMPORTO_MAX = @ImportoMax, 
		IMPORTO_MIN = @ImportoMin, 
		NUMERO = @Numero
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(COD_TIPO = @CodTipo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoPagamentoUpdate';

