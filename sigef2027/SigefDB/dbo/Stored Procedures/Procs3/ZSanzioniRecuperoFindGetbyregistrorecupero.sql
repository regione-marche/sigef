CREATE PROCEDURE [dbo].[ZSanzioniRecuperoFindGetbyregistrorecupero]
(
	@IdRegistroRecuperoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SANZIONE_RECUPERO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_REGISTRO_RECUPERO, ID_CATEGORIA_SANZIONE, ID_TIPO_SANZIONE, IMPORTO_SANZIONE, DATA_CONCLUSIONE, ID_STATO_SANZIONE, ID_REGISTRO_IRREGOLARITA FROM VSANZIONI_RECUPERO WHERE 1=1';
	IF (@IdRegistroRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REGISTRO_RECUPERO = @IdRegistroRecuperoequalthis)'; set @lensql=@lensql+len(@IdRegistroRecuperoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRegistroRecuperoequalthis INT',@IdRegistroRecuperoequalthis ;
	else
		SELECT ID_SANZIONE_RECUPERO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_REGISTRO_RECUPERO, ID_CATEGORIA_SANZIONE, ID_TIPO_SANZIONE, IMPORTO_SANZIONE, DATA_CONCLUSIONE, ID_STATO_SANZIONE, ID_REGISTRO_IRREGOLARITA
		FROM VSANZIONI_RECUPERO
		WHERE 
			((@IdRegistroRecuperoequalthis IS NULL) OR ID_REGISTRO_RECUPERO = @IdRegistroRecuperoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSanzioniRecuperoFindGetbyregistrorecupero';

