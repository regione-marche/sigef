CREATE PROCEDURE [dbo].[ZBandoTipoPagamentoInsert]
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
	INSERT INTO BANDO_TIPO_PAGAMENTO
	(
		ID_BANDO, 
		COD_TIPO, 
		QUOTA_MAX, 
		QUOTA_MIN, 
		IMPORTO_MAX, 
		IMPORTO_MIN, 
		NUMERO, 
		COD_TIPO_POLIZZA
	)
	VALUES
	(
		@IdBando, 
		@CodTipo, 
		@QuotaMax, 
		@QuotaMin, 
		@ImportoMax, 
		@ImportoMin, 
		@Numero, 
		@CodTipoPolizza
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'create PROCEDURE [dbo].[ZBandoTipoPagamentoInsert]
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
	INSERT INTO BANDO_TIPO_PAGAMENTO
	(
		ID_BANDO, 
		COD_TIPO, 
		QUOTA_MAX, 
		QUOTA_MIN, 
		IMPORTO_MAX, 
		IMPORTO_MIN, 
		NUMERO
	)
	VALUES
	(
		@IdBando, 
		@CodTipo, 
		@QuotaMax, 
		@QuotaMin, 
		@ImportoMax, 
		@ImportoMin, 
		@Numero
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoPagamentoInsert';

