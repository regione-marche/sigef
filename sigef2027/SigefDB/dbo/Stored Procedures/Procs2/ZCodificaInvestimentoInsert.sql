CREATE PROCEDURE [dbo].[ZCodificaInvestimentoInsert]
(
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
	INSERT INTO CODIFICA_INVESTIMENTO
	(
		ID_BANDO, 
		COD_TP, 
		DESCRIZIONE, 
		AIUTO_MINIMO, 
		CODICE, 
		IS_MAX, 
		QUERY_SQL, 
		AIUTO_MINIMO_ALTREFONTI, 
		QUERY_SQL_ALTREFONTI
	)
	VALUES
	(
		@IdBando, 
		@CodTp, 
		@Descrizione, 
		@AiutoMinimo, 
		@Codice, 
		@IsMax, 
		@QuerySql, 
		@AiutoMinimoAltrefonti, 
		@QuerySqlAltrefonti
	)
	SELECT SCOPE_IDENTITY() AS ID_CODIFICA_INVESTIMENTO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCodificaInvestimentoInsert]
(
	@IdBando INT, 
	@CodTp VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@AiutoMinimo DECIMAL(10,2), 
	@Codice VARCHAR(255), 
	@IsMax BIT
)
AS
	INSERT INTO CODIFICA_INVESTIMENTO
	(
		ID_BANDO, 
		COD_TP, 
		DESCRIZIONE, 
		AIUTO_MINIMO, 
		CODICE, 
		IS_MAX
	)
	VALUES
	(
		@IdBando, 
		@CodTp, 
		@Descrizione, 
		@AiutoMinimo, 
		@Codice, 
		@IsMax
	)
	SELECT SCOPE_IDENTITY() AS ID_CODIFICA_INVESTIMENTO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCodificaInvestimentoInsert';

