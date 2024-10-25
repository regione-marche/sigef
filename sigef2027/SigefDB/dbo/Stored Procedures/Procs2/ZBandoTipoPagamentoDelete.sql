CREATE PROCEDURE [dbo].[ZBandoTipoPagamentoDelete]
(
	@IdBando INT, 
	@CodTipo CHAR(3)
)
AS
	DELETE BANDO_TIPO_PAGAMENTO
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoTipoPagamentoDelete]
(
	@IdBando INT, 
	@CodTipo CHAR(3)
)
AS
	DELETE BANDO_TIPO_PAGAMENTO
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(COD_TIPO = @CodTipo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoPagamentoDelete';

