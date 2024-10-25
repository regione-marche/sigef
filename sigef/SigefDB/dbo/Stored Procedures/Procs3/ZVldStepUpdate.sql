CREATE PROCEDURE [dbo].[ZVldStepUpdate]
(
	@Id INT, 
	@Descrizione VARCHAR(500), 
	@Automatico BIT, 
	@QuerySql VARCHAR(3000), 
	@QuerySqlPost VARCHAR(300), 
	@CodeMethod VARCHAR(255), 
	@Url VARCHAR(255), 
	@ValMinimo VARCHAR(255), 
	@ValMassimo VARCHAR(255), 
	@Misura VARCHAR(255)
)
AS
	UPDATE VLD_STEP
	SET
		DESCRIZIONE = @Descrizione, 
		AUTOMATICO = @Automatico, 
		QUERY_SQL = @QuerySql, 
		QUERY_SQL_POST = @QuerySqlPost, 
		CODE_METHOD = @CodeMethod, 
		URL = @Url, 
		VAL_MINIMO = @ValMinimo, 
		VAL_MASSIMO = @ValMassimo, 
		MISURA = @Misura
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldStepUpdate';

