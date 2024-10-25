CREATE PROCEDURE [dbo].[ZCodificaInvestimentoFindFind]
(
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CODIFICA_INVESTIMENTO, ID_BANDO, COD_TP, DESCRIZIONE, AIUTO_MINIMO, CODICE, IS_MAX, QUERY_SQL, AIUTO_MINIMO_ALTREFONTI, QUERY_SQL_ALTREFONTI FROM CODIFICA_INVESTIMENTO WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @sql = @sql + 'ORDER BY ID_CODIFICA_INVESTIMENTO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT',@IdBandoequalthis ;
	else
		SELECT ID_CODIFICA_INVESTIMENTO, ID_BANDO, COD_TP, DESCRIZIONE, AIUTO_MINIMO, CODICE, IS_MAX, QUERY_SQL, AIUTO_MINIMO_ALTREFONTI, QUERY_SQL_ALTREFONTI
		FROM CODIFICA_INVESTIMENTO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)
		ORDER BY ID_CODIFICA_INVESTIMENTO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCodificaInvestimentoFindFind]
(
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_CODIFICA_INVESTIMENTO, ID_BANDO, COD_TP, DESCRIZIONE, AIUTO_MINIMO, CODICE, IS_MAX FROM CODIFICA_INVESTIMENTO WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @sql = @sql + ''ORDER BY ID_CODIFICA_INVESTIMENTO'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT'',@IdBandoequalthis ;
	else
		SELECT ID_CODIFICA_INVESTIMENTO, ID_BANDO, COD_TP, DESCRIZIONE, AIUTO_MINIMO, CODICE, IS_MAX
		FROM CODIFICA_INVESTIMENTO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)
		ORDER BY ID_CODIFICA_INVESTIMENTO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCodificaInvestimentoFindFind';

