CREATE PROCEDURE [dbo].[ZBandoRequisitiPagamentoInsert]
(
	@IdBando INT, 
	@CodTipo CHAR(3), 
	@IdRequisito INT, 
	@Obbligatorio BIT, 
	@RequisitoDiControllo BIT, 
	@Ordine INT, 
	@RequisitoDiInserimento BIT
)
AS
	SET @Obbligatorio = ISNULL(@Obbligatorio,((0)))
	SET @RequisitoDiControllo = ISNULL(@RequisitoDiControllo,((0)))
	INSERT INTO BANDO_REQUISITI_PAGAMENTO
	(
		ID_BANDO, 
		COD_TIPO, 
		ID_REQUISITO, 
		OBBLIGATORIO, 
		REQUISITO_DI_CONTROLLO, 
		ORDINE, 
		REQUISITO_DI_INSERIMENTO
	)
	VALUES
	(
		@IdBando, 
		@CodTipo, 
		@IdRequisito, 
		@Obbligatorio, 
		@RequisitoDiControllo, 
		@Ordine, 
		@RequisitoDiInserimento
	)
	SELECT @Obbligatorio AS OBBLIGATORIO, @RequisitoDiControllo AS REQUISITO_DI_CONTROLLO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRequisitiPagamentoInsert';

