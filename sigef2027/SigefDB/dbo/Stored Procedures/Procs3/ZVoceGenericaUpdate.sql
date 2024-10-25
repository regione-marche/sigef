CREATE PROCEDURE [dbo].[ZVoceGenericaUpdate]
(
	@IdVoceGenerica INT, 
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
	SET @DataModifica=getdate()
	UPDATE VOCE_GENERICA
	SET
		COD_FASE = @CodFase, 
		DESCRIZIONE = @Descrizione, 
		AUTOMATICO = @Automatico, 
		QUERY_SQL = @QuerySql, 
		QUERY_SQL_POST = @QuerySqlPost, 
		CODE_METHOD = @CodeMethod, 
		URL = @Url, 
		VAL_MINIMO = @ValMinimo, 
		VAL_MASSIMO = @ValMassimo, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		VAL_ESITO_NEGATIVO = @ValEsitoNegativo
	WHERE 
		(ID_VOCE_GENERICA = @IdVoceGenerica)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceGenericaUpdate';

