CREATE PROCEDURE [dbo].[ZVariantiEsitiRequisitiDelete]
(
	@IdVariante INT, 
	@IdRequisito INT
)
AS
	DELETE VARIANTI_ESITI_REQUISITI
	WHERE 
		(ID_VARIANTE = @IdVariante) AND 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiEsitiRequisitiDelete';

