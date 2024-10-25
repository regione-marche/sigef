CREATE PROCEDURE [dbo].[ZBandoRequisitiVarianteUpdate]
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
	UPDATE BANDO_REQUISITI_VARIANTE
	SET
		OBBLIGATORIO = @Obbligatorio, 
		REQUISITO_DI_PRESENTAZIONE = @RequisitoDiPresentazione, 
		REQUISITO_DI_ISTRUTTORIA = @RequisitoDiIstruttoria, 
		ORDINE = @Ordine
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(COD_TIPO = @CodTipo) AND 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRequisitiVarianteUpdate';

