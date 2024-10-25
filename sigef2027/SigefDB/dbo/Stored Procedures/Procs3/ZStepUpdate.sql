CREATE PROCEDURE [dbo].[ZStepUpdate]
(
	@IdStep INT, 
	@Descrizione VARCHAR(255), 
	@Automatico BIT, 
	@QuerySql VARCHAR(3000), 
	@CodeMethod VARCHAR(30), 
	@Url VARCHAR(100), 
	@ValMassimo VARCHAR(20), 
	@ValMinimo VARCHAR(20), 
	@QuerySqlPost VARCHAR(300), 
	@CodFase CHAR(1), 
	@Misura VARCHAR(20)
)
AS
	UPDATE STEP
	SET
		DESCRIZIONE = @Descrizione, 
		AUTOMATICO = @Automatico, 
		QUERY_SQL = @QuerySql, 
		CODE_METHOD = @CodeMethod, 
		URL = @Url, 
		VAL_MASSIMO = @ValMassimo, 
		VAL_MINIMO = @ValMinimo, 
		QUERY_SQL_POST = @QuerySqlPost, 
		COD_FASE = @CodFase, 
		MISURA = @Misura
	WHERE 
		(ID_STEP = @IdStep)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZStepUpdate]
(
	@IdStep INT, 
	@Descrizione VARCHAR(255), 
	@Automatico BIT, 
	@QuerySql VARCHAR(3000), 
	@CodeMethod VARCHAR(30), 
	@Url VARCHAR(100), 
	@ValMassimo VARCHAR(20), 
	@ValMinimo VARCHAR(20), 
	@QuerySqlPost VARCHAR(300), 
	@CodFase CHAR(1), 
	@Misura NVARCHAR
)
AS
	UPDATE STEP
	SET
		DESCRIZIONE = @Descrizione, 
		AUTOMATICO = @Automatico, 
		QUERY_SQL = @QuerySql, 
		CODE_METHOD = @CodeMethod, 
		URL = @Url, 
		VAL_MASSIMO = @ValMassimo, 
		VAL_MINIMO = @ValMinimo, 
		QUERY_SQL_POST = @QuerySqlPost, 
		COD_FASE = @CodFase, 
		MISURA = @Misura
	WHERE 
		(ID_STEP = @IdStep)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZStepUpdate';

