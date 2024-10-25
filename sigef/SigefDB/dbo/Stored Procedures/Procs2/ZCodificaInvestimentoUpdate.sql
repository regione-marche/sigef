CREATE PROCEDURE [dbo].[ZCodificaInvestimentoUpdate]
(
	@IdCodificaInvestimento INT, 
	@IdBando INT, 
	@CodTp VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@AiutoMinimo DECIMAL(10,2), 
	@Codice VARCHAR(255), 
	@IsMax BIT, 
	@QuerySql VARCHAR(3000), 
	@AiutoMinimoAltrefonti DECIMAL(10,2), 
	@QuerySqlAltrefonti VARCHAR(3000)
)
AS
	UPDATE CODIFICA_INVESTIMENTO
	SET
		ID_BANDO = @IdBando, 
		COD_TP = @CodTp, 
		DESCRIZIONE = @Descrizione, 
		AIUTO_MINIMO = @AiutoMinimo, 
		CODICE = @Codice, 
		IS_MAX = @IsMax, 
		QUERY_SQL = @QuerySql, 
		AIUTO_MINIMO_ALTREFONTI = @AiutoMinimoAltrefonti, 
		QUERY_SQL_ALTREFONTI = @QuerySqlAltrefonti
	WHERE 
		(ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCodificaInvestimentoUpdate]
(
	@IdCodificaInvestimento INT, 
	@IdBando INT, 
	@CodTp VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@AiutoMinimo DECIMAL(10,2), 
	@Codice VARCHAR(255), 
	@IsMax BIT
)
AS
	UPDATE CODIFICA_INVESTIMENTO
	SET
		ID_BANDO = @IdBando, 
		COD_TP = @CodTp, 
		DESCRIZIONE = @Descrizione, 
		AIUTO_MINIMO = @AiutoMinimo, 
		CODICE = @Codice, 
		IS_MAX = @IsMax
	WHERE 
		(ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCodificaInvestimentoUpdate';

