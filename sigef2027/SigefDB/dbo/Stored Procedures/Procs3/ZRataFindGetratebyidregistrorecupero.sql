CREATE PROCEDURE [dbo].[ZRataFindGetratebyidregistrorecupero]
(
	@IdRegistroRecuperoequalthis INT, 
	@Pagataequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_RATA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, DATA_RATA, DATA_SCADENZA, DATA_PAGAMENTO, IMPORTO_RATA, PAGATA, ID_REGISTRO_RECUPERO, ID_TIPO_RATA, DESCRIZIONE FROM VRATA WHERE 1=1';
	IF (@IdRegistroRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REGISTRO_RECUPERO = @IdRegistroRecuperoequalthis)'; set @lensql=@lensql+len(@IdRegistroRecuperoequalthis);end;
	IF (@Pagataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PAGATA = @Pagataequalthis)'; set @lensql=@lensql+len(@Pagataequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRegistroRecuperoequalthis INT, @Pagataequalthis BIT',@IdRegistroRecuperoequalthis , @Pagataequalthis ;
	else
		SELECT ID_RATA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, DATA_RATA, DATA_SCADENZA, DATA_PAGAMENTO, IMPORTO_RATA, PAGATA, ID_REGISTRO_RECUPERO, ID_TIPO_RATA, DESCRIZIONE
		FROM VRATA
		WHERE 
			((@IdRegistroRecuperoequalthis IS NULL) OR ID_REGISTRO_RECUPERO = @IdRegistroRecuperoequalthis) AND 
			((@Pagataequalthis IS NULL) OR PAGATA = @Pagataequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRataFindGetratebyidregistrorecupero';

