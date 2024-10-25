CREATE PROCEDURE [dbo].[ZRequisitiVarianteUpdate]
(
	@IdRequisito INT, 
	@Automatico BIT, 
	@Descrizione VARCHAR(500), 
	@QueryEval VARCHAR(3000), 
	@QueryInsert VARCHAR(3000), 
	@ValMinimo DECIMAL(18,2), 
	@ValMassimo DECIMAL(18,2), 
	@Misura VARCHAR(10)
)
AS
	UPDATE REQUISITI_VARIANTE
	SET
		AUTOMATICO = @Automatico, 
		DESCRIZIONE = @Descrizione, 
		QUERY_EVAL = @QueryEval, 
		QUERY_INSERT = @QueryInsert, 
		VAL_MINIMO = @ValMinimo, 
		VAL_MASSIMO = @ValMassimo, 
		MISURA = @Misura
	WHERE 
		(ID_REQUISITO = @IdRequisito)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiVarianteUpdate';

