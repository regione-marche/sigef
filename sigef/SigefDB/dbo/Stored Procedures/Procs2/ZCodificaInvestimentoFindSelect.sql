CREATE PROCEDURE [dbo].[ZCodificaInvestimentoFindSelect]
(
	@IdCodificaInvestimentoequalthis INT, 
	@IdBandoequalthis INT, 
	@CodTpequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@AiutoMinimoequalthis DECIMAL(10,2), 
	@Codiceequalthis VARCHAR(255), 
	@IsMaxequalthis BIT, 
	@QuerySqlequalthis VARCHAR(3000), 
	@AiutoMinimoAltrefontiequalthis DECIMAL(10,2), 
	@QuerySqlAltrefontiequalthis VARCHAR(3000)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CODIFICA_INVESTIMENTO, ID_BANDO, COD_TP, DESCRIZIONE, AIUTO_MINIMO, CODICE, IS_MAX, QUERY_SQL, AIUTO_MINIMO_ALTREFONTI, QUERY_SQL_ALTREFONTI FROM CODIFICA_INVESTIMENTO WHERE 1=1';
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTpequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TP = @CodTpequalthis)'; set @lensql=@lensql+len(@CodTpequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@AiutoMinimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AIUTO_MINIMO = @AiutoMinimoequalthis)'; set @lensql=@lensql+len(@AiutoMinimoequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@IsMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IS_MAX = @IsMaxequalthis)'; set @lensql=@lensql+len(@IsMaxequalthis);end;
	IF (@QuerySqlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_SQL = @QuerySqlequalthis)'; set @lensql=@lensql+len(@QuerySqlequalthis);end;
	IF (@AiutoMinimoAltrefontiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AIUTO_MINIMO_ALTREFONTI = @AiutoMinimoAltrefontiequalthis)'; set @lensql=@lensql+len(@AiutoMinimoAltrefontiequalthis);end;
	IF (@QuerySqlAltrefontiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_SQL_ALTREFONTI = @QuerySqlAltrefontiequalthis)'; set @lensql=@lensql+len(@QuerySqlAltrefontiequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCodificaInvestimentoequalthis INT, @IdBandoequalthis INT, @CodTpequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @AiutoMinimoequalthis DECIMAL(10,2), @Codiceequalthis VARCHAR(255), @IsMaxequalthis BIT, @QuerySqlequalthis VARCHAR(3000), @AiutoMinimoAltrefontiequalthis DECIMAL(10,2), @QuerySqlAltrefontiequalthis VARCHAR(3000)',@IdCodificaInvestimentoequalthis , @IdBandoequalthis , @CodTpequalthis , @Descrizioneequalthis , @AiutoMinimoequalthis , @Codiceequalthis , @IsMaxequalthis , @QuerySqlequalthis , @AiutoMinimoAltrefontiequalthis , @QuerySqlAltrefontiequalthis ;
	else
		SELECT ID_CODIFICA_INVESTIMENTO, ID_BANDO, COD_TP, DESCRIZIONE, AIUTO_MINIMO, CODICE, IS_MAX, QUERY_SQL, AIUTO_MINIMO_ALTREFONTI, QUERY_SQL_ALTREFONTI
		FROM CODIFICA_INVESTIMENTO
		WHERE 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTpequalthis IS NULL) OR COD_TP = @CodTpequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@AiutoMinimoequalthis IS NULL) OR AIUTO_MINIMO = @AiutoMinimoequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@IsMaxequalthis IS NULL) OR IS_MAX = @IsMaxequalthis) AND 
			((@QuerySqlequalthis IS NULL) OR QUERY_SQL = @QuerySqlequalthis) AND 
			((@AiutoMinimoAltrefontiequalthis IS NULL) OR AIUTO_MINIMO_ALTREFONTI = @AiutoMinimoAltrefontiequalthis) AND 
			((@QuerySqlAltrefontiequalthis IS NULL) OR QUERY_SQL_ALTREFONTI = @QuerySqlAltrefontiequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCodificaInvestimentoFindSelect]
(
	@IdCodificaInvestimentoequalthis INT, 
	@IdBandoequalthis INT, 
	@CodTpequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@AiutoMinimoequalthis DECIMAL(10,2), 
	@Codiceequalthis VARCHAR(255), 
	@IsMaxequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_CODIFICA_INVESTIMENTO, ID_BANDO, COD_TP, DESCRIZIONE, AIUTO_MINIMO, CODICE, IS_MAX FROM CODIFICA_INVESTIMENTO WHERE 1=1'';
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)''; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTpequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TP = @CodTpequalthis)''; set @lensql=@lensql+len(@CodTpequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@AiutoMinimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AIUTO_MINIMO = @AiutoMinimoequalthis)''; set @lensql=@lensql+len(@AiutoMinimoequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE = @Codiceequalthis)''; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@IsMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IS_MAX = @IsMaxequalthis)''; set @lensql=@lensql+len(@IsMaxequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdCodificaInvestimentoequalthis INT, @IdBandoequalthis INT, @CodTpequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @AiutoMinimoequalthis DECIMAL(10,2), @Codiceequalthis VARCHAR(255), @IsMaxequalthis BIT'',@IdCodificaInvestimentoequalthis , @IdBandoequalthis , @CodTpequalthis , @Descrizioneequalthis , @AiutoMinimoequalthis , @Codiceequalthis , @IsMaxequalthis ;
	else
		SELECT ID_CODIFICA_INVESTIMENTO, ID_BANDO, COD_TP, DESCRIZIONE, AIUTO_MINIMO, CODICE, IS_MAX
		FROM CODIFICA_INVESTIMENTO
		WHERE 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTpequalthis IS NULL) OR COD_TP = @CodTpequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@AiutoMinimoequalthis IS NULL) OR AIUTO_MINIMO = @AiutoMinimoequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@IsMaxequalthis IS NULL) OR IS_MAX = @IsMaxequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCodificaInvestimentoFindSelect';

