CREATE PROCEDURE [dbo].[ZRequisitiVarianteGetById]
(
	@IdRequisito INT
)
AS
	SELECT *
	FROM REQUISITI_VARIANTE
	WHERE 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiVarianteGetById';

