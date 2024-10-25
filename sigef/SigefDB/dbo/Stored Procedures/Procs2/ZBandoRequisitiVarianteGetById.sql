CREATE PROCEDURE [dbo].[ZBandoRequisitiVarianteGetById]
(
	@IdBando INT, 
	@CodTipo CHAR(2), 
	@IdRequisito INT
)
AS
	SELECT *
	FROM vBANDO_REQUISITI_VARIANTE
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(COD_TIPO = @CodTipo) AND 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRequisitiVarianteGetById';

