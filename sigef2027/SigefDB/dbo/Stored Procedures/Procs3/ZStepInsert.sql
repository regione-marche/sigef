CREATE PROCEDURE [dbo].[ZStepInsert]
(
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
	INSERT INTO STEP
	(
		DESCRIZIONE, 
		AUTOMATICO, 
		QUERY_SQL, 
		CODE_METHOD, 
		URL, 
		VAL_MASSIMO, 
		VAL_MINIMO, 
		QUERY_SQL_POST, 
		COD_FASE, 
		MISURA
	)
	VALUES
	(
		@Descrizione, 
		@Automatico, 
		@QuerySql, 
		@CodeMethod, 
		@Url, 
		@ValMassimo, 
		@ValMinimo, 
		@QuerySqlPost, 
		@CodFase, 
		@Misura
	)
	SELECT SCOPE_IDENTITY() AS ID_STEP

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZStepInsert]
(
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
	INSERT INTO STEP
	(
		DESCRIZIONE, 
		AUTOMATICO, 
		QUERY_SQL, 
		CODE_METHOD, 
		URL, 
		VAL_MASSIMO, 
		VAL_MINIMO, 
		QUERY_SQL_POST, 
		COD_FASE, 
		MISURA
	)
	VALUES
	(
		@Descrizione, 
		@Automatico, 
		@QuerySql, 
		@CodeMethod, 
		@Url, 
		@ValMassimo, 
		@ValMinimo, 
		@QuerySqlPost, 
		@CodFase, 
		@Misura
	)
	SELECT SCOPE_IDENTITY() AS ID_STEP

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZStepInsert';

