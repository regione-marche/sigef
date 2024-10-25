CREATE PROCEDURE [dbo].[ZSpeseSostenuteFileFindGetbyidspesa]
(
	@IdSpesaequalthis INT, 
	@InIntegrazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FILE_SPESE_SOSTENUTE, ID_SPESA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, IN_INTEGRAZIONE, DESCRIZIONE, ID_FILE, NOME_FILE, NOME_COMPLETO FROM VSPESE_SOSTENUTE_FILE WHERE 1=1';
	IF (@IdSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPESA = @IdSpesaequalthis)'; set @lensql=@lensql+len(@IdSpesaequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSpesaequalthis INT, @InIntegrazioneequalthis BIT',@IdSpesaequalthis , @InIntegrazioneequalthis ;
	else
		SELECT ID_FILE_SPESE_SOSTENUTE, ID_SPESA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, IN_INTEGRAZIONE, DESCRIZIONE, ID_FILE, NOME_FILE, NOME_COMPLETO
		FROM VSPESE_SOSTENUTE_FILE
		WHERE 
			((@IdSpesaequalthis IS NULL) OR ID_SPESA = @IdSpesaequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteFileFindGetbyidspesa';

