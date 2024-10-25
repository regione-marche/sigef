CREATE PROCEDURE [dbo].[ZTipoDocumentoFindFind]
(
	@Codiceequalthis VARCHAR(255), 
	@Formatoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT CODICE, FORMATO, DESCRIZIONE, ATTIVO FROM TIPO_DOCUMENTO WHERE 1=1';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Formatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FORMATO = @Formatoequalthis)'; set @lensql=@lensql+len(@Formatoequalthis);end;
	set @sql = @sql + 'ORDER BY DESCRIZIONE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Codiceequalthis VARCHAR(255), @Formatoequalthis VARCHAR(255)',@Codiceequalthis , @Formatoequalthis ;
	else
		SELECT CODICE, FORMATO, DESCRIZIONE, ATTIVO
		FROM TIPO_DOCUMENTO
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Formatoequalthis IS NULL) OR FORMATO = @Formatoequalthis)
		ORDER BY DESCRIZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoDocumentoFindFind';

