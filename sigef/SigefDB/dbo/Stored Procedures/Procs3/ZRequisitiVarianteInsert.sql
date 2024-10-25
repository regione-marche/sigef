CREATE PROCEDURE [dbo].[ZRequisitiVarianteInsert]
(
	@Automatico BIT, 
	@Descrizione VARCHAR(500), 
	@QueryEval VARCHAR(3000), 
	@QueryInsert VARCHAR(3000), 
	@ValMinimo DECIMAL(18,2), 
	@ValMassimo DECIMAL(18,2), 
	@Misura VARCHAR(10)
)
AS
	INSERT INTO REQUISITI_VARIANTE
	(
		AUTOMATICO, 
		DESCRIZIONE, 
		QUERY_EVAL, 
		QUERY_INSERT, 
		VAL_MINIMO, 
		VAL_MASSIMO, 
		MISURA
	)
	VALUES
	(
		@Automatico, 
		@Descrizione, 
		@QueryEval, 
		@QueryInsert, 
		@ValMinimo, 
		@ValMassimo, 
		@Misura
	)
	SELECT SCOPE_IDENTITY() AS ID_REQUISITO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiVarianteInsert';

