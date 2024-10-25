CREATE PROCEDURE [dbo].[ZVldStepInsert]
(
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
	INSERT INTO VLD_STEP
	(
		DESCRIZIONE, 
		AUTOMATICO, 
		QUERY_SQL, 
		QUERY_SQL_POST, 
		CODE_METHOD, 
		URL, 
		VAL_MINIMO, 
		VAL_MASSIMO, 
		MISURA
	)
	VALUES
	(
		@Descrizione, 
		@Automatico, 
		@QuerySql, 
		@QuerySqlPost, 
		@CodeMethod, 
		@Url, 
		@ValMinimo, 
		@ValMassimo, 
		@Misura
	)
	SELECT SCOPE_IDENTITY() AS ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVldStepInsert';

