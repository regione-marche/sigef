CREATE PROCEDURE [dbo].[ZTipoScadenzaFindSelect]
(
	@CodTipoScadenzaequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@QuerySqlequalthis VARCHAR(3000), 
	@ValMinimoequalthis VARCHAR(20), 
	@ValMassimoequalthis VARCHAR(20), 
	@MessaggioBaseequalthis VARCHAR(2000), 
	@UrlBaseequalthis VARCHAR(100)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO_SCADENZA, DESCRIZIONE, QUERY_SQL, VAL_MINIMO, VAL_MASSIMO, MESSAGGIO_BASE, URL_BASE FROM TIPO_SCADENZA WHERE 1=1';
	IF (@CodTipoScadenzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_SCADENZA = @CodTipoScadenzaequalthis)'; set @lensql=@lensql+len(@CodTipoScadenzaequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@QuerySqlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_SQL = @QuerySqlequalthis)'; set @lensql=@lensql+len(@QuerySqlequalthis);end;
	IF (@ValMinimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_MINIMO = @ValMinimoequalthis)'; set @lensql=@lensql+len(@ValMinimoequalthis);end;
	IF (@ValMassimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_MASSIMO = @ValMassimoequalthis)'; set @lensql=@lensql+len(@ValMassimoequalthis);end;
	IF (@MessaggioBaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MESSAGGIO_BASE = @MessaggioBaseequalthis)'; set @lensql=@lensql+len(@MessaggioBaseequalthis);end;
	IF (@UrlBaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (URL_BASE = @UrlBaseequalthis)'; set @lensql=@lensql+len(@UrlBaseequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoScadenzaequalthis INT, @Descrizioneequalthis VARCHAR(255), @QuerySqlequalthis VARCHAR(3000), @ValMinimoequalthis VARCHAR(20), @ValMassimoequalthis VARCHAR(20), @MessaggioBaseequalthis VARCHAR(2000), @UrlBaseequalthis VARCHAR(100)',@CodTipoScadenzaequalthis , @Descrizioneequalthis , @QuerySqlequalthis , @ValMinimoequalthis , @ValMassimoequalthis , @MessaggioBaseequalthis , @UrlBaseequalthis ;
	else
		SELECT COD_TIPO_SCADENZA, DESCRIZIONE, QUERY_SQL, VAL_MINIMO, VAL_MASSIMO, MESSAGGIO_BASE, URL_BASE
		FROM TIPO_SCADENZA
		WHERE 
			((@CodTipoScadenzaequalthis IS NULL) OR COD_TIPO_SCADENZA = @CodTipoScadenzaequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@QuerySqlequalthis IS NULL) OR QUERY_SQL = @QuerySqlequalthis) AND 
			((@ValMinimoequalthis IS NULL) OR VAL_MINIMO = @ValMinimoequalthis) AND 
			((@ValMassimoequalthis IS NULL) OR VAL_MASSIMO = @ValMassimoequalthis) AND 
			((@MessaggioBaseequalthis IS NULL) OR MESSAGGIO_BASE = @MessaggioBaseequalthis) AND 
			((@UrlBaseequalthis IS NULL) OR URL_BASE = @UrlBaseequalthis)
		-- order by ecc.ecc.
