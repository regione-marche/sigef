CREATE PROCEDURE [dbo].[ZBandoRequisitiPagamentoUpdate]
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
	UPDATE BANDO_REQUISITI_PAGAMENTO
	SET
		OBBLIGATORIO = @Obbligatorio, 
		REQUISITO_DI_CONTROLLO = @RequisitoDiControllo, 
		ORDINE = @Ordine, 
		REQUISITO_DI_INSERIMENTO = @RequisitoDiInserimento
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(COD_TIPO = @CodTipo) AND 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRequisitiPagamentoUpdate';

