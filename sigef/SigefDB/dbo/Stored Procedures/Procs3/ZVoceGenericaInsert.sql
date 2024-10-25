CREATE PROCEDURE [dbo].[ZVoceGenericaInsert]
(
	@CodFase VARCHAR(255), 
	@Descrizione VARCHAR(8000), 
	@Automatico BIT, 
	@QuerySql VARCHAR(8000), 
	@QuerySqlPost VARCHAR(300), 
	@CodeMethod VARCHAR(255), 
	@Url VARCHAR(255), 
	@ValMinimo VARCHAR(255), 
	@ValMassimo VARCHAR(255), 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@ValEsitoNegativo BIT
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @ValEsitoNegativo = ISNULL(@ValEsitoNegativo,((0)))
	INSERT INTO VOCE_GENERICA
	(
		COD_FASE, 
		DESCRIZIONE, 
		AUTOMATICO, 
		QUERY_SQL, 
		QUERY_SQL_POST, 
		CODE_METHOD, 
		URL, 
		VAL_MINIMO, 
		VAL_MASSIMO, 
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		VAL_ESITO_NEGATIVO
	)
	VALUES
	(
		@CodFase, 
		@Descrizione, 
		@Automatico, 
		@QuerySql, 
		@QuerySqlPost, 
		@CodeMethod, 
		@Url, 
		@ValMinimo, 
		@ValMassimo, 
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@ValEsitoNegativo
	)
	SELECT SCOPE_IDENTITY() AS ID_VOCE_GENERICA, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @ValEsitoNegativo AS VAL_ESITO_NEGATIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceGenericaInsert';

