CREATE PROCEDURE [dbo].[ZBandoRequisitiVarianteInsert]
(
	@IdBando INT, 
	@CodTipo CHAR(2), 
	@IdRequisito INT, 
	@Obbligatorio BIT, 
	@RequisitoDiPresentazione BIT, 
	@RequisitoDiIstruttoria BIT, 
	@Ordine INT
)
AS
	SET @Obbligatorio = ISNULL(@Obbligatorio,((0)))
	SET @RequisitoDiPresentazione = ISNULL(@RequisitoDiPresentazione,((0)))
	SET @RequisitoDiIstruttoria = ISNULL(@RequisitoDiIstruttoria,((0)))
	INSERT INTO BANDO_REQUISITI_VARIANTE
	(
		ID_BANDO, 
		COD_TIPO, 
		ID_REQUISITO, 
		OBBLIGATORIO, 
		REQUISITO_DI_PRESENTAZIONE, 
		REQUISITO_DI_ISTRUTTORIA, 
		ORDINE
	)
	VALUES
	(
		@IdBando, 
		@CodTipo, 
		@IdRequisito, 
		@Obbligatorio, 
		@RequisitoDiPresentazione, 
		@RequisitoDiIstruttoria, 
		@Ordine
	)
	SELECT @Obbligatorio AS OBBLIGATORIO, @RequisitoDiPresentazione AS REQUISITO_DI_PRESENTAZIONE, @RequisitoDiIstruttoria AS REQUISITO_DI_ISTRUTTORIA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRequisitiVarianteInsert';

