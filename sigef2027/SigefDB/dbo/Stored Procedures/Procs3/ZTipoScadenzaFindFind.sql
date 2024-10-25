CREATE PROCEDURE [dbo].[ZTipoScadenzaFindFind]
(
	@CodTipoScadenzaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO_SCADENZA, DESCRIZIONE, QUERY_SQL, VAL_MINIMO, VAL_MASSIMO, MESSAGGIO_BASE, URL_BASE FROM TIPO_SCADENZA WHERE 1=1';
	IF (@CodTipoScadenzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_SCADENZA = @CodTipoScadenzaequalthis)'; set @lensql=@lensql+len(@CodTipoScadenzaequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoScadenzaequalthis INT',@CodTipoScadenzaequalthis ;
	else
		SELECT COD_TIPO_SCADENZA, DESCRIZIONE, QUERY_SQL, VAL_MINIMO, VAL_MASSIMO, MESSAGGIO_BASE, URL_BASE
		FROM TIPO_SCADENZA
		WHERE 
			((@CodTipoScadenzaequalthis IS NULL) OR COD_TIPO_SCADENZA = @CodTipoScadenzaequalthis)
		-- order by ecc.ecc.
