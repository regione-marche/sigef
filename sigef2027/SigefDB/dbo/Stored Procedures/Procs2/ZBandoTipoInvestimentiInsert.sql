CREATE PROCEDURE [dbo].[ZBandoTipoInvestimentiInsert]
(
	@IdBando INT, 
	@CodTipoInvestimento INT, 
	@ImportoMax DECIMAL(15,2), 
	@ImportoMin DECIMAL(15,2), 
	@QuotaMax DECIMAL(10,2), 
	@Note VARCHAR(500), 
	@Premio BIT
)
AS
	SET @Premio = ISNULL(@Premio,((0)))
	INSERT INTO BANDO_TIPO_INVESTIMENTI
	(
		ID_BANDO, 
		COD_TIPO_INVESTIMENTO, 
		IMPORTO_MAX, 
		IMPORTO_MIN, 
		QUOTA_MAX, 
		NOTE, 
		PREMIO
	)
	VALUES
	(
		@IdBando, 
		@CodTipoInvestimento, 
		@ImportoMax, 
		@ImportoMin, 
		@QuotaMax, 
		@Note, 
		@Premio
	)
	SELECT SCOPE_IDENTITY() AS ID_TIPO_INVESTIMENTO, @Premio AS PREMIO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoTipoInvestimentiInsert]
(
	@IdBando INT, 
	@CodTipoInvestimento INT, 
	@ImportoMax DECIMAL(15,2), 
	@ImportoMin DECIMAL(15,2), 
	@QuotaMax DECIMAL(10,2), 
	@Note VARCHAR(500), 
	@Premio BIT
)
AS
IF (SELECT COUNT(*) FROM BANDO_TIPO_INVESTIMENTI WHERE ID_BANDO=@IdBando AND COD_TIPO_INVESTIMENTO=@CodTipoInvestimento)>0
BEGIN
	RAISERROR(''Tipologia già associata.'',16,1)
	RETURN
END
	INSERT INTO BANDO_TIPO_INVESTIMENTI
	(
		ID_BANDO, 
		COD_TIPO_INVESTIMENTO, 
		IMPORTO_MAX, 
		IMPORTO_MIN, 
		QUOTA_MAX, 
		NOTE, 
		PREMIO
	)
	VALUES
	(
		@IdBando, 
		@CodTipoInvestimento, 
		@ImportoMax, 
		@ImportoMin, 
		@QuotaMax, 
		@Note, 
		@Premio
	)
	SELECT SCOPE_IDENTITY() AS ID_TIPO_INVESTIMENTO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoInvestimentiInsert';

