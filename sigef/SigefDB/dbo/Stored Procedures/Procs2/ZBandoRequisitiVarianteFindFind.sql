CREATE PROCEDURE [dbo].[ZBandoRequisitiVarianteFindFind]
(
	@IdBandoequalthis INT, 
	@CodTipoequalthis CHAR(2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, COD_TIPO, ID_REQUISITO, OBBLIGATORIO, REQUISITO_DI_PRESENTAZIONE, REQUISITO_DI_ISTRUTTORIA, ORDINE, AUTOMATICO, DESCRIZIONE, QUERY_EVAL, QUERY_INSERT, VAL_MINIMO, VAL_MASSIMO, MISURA FROM vBANDO_REQUISITI_VARIANTE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	set @sql = @sql + 'ORDER BY ORDINE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodTipoequalthis CHAR(2)',@IdBandoequalthis , @CodTipoequalthis ;
	else
		SELECT ID_BANDO, COD_TIPO, ID_REQUISITO, OBBLIGATORIO, REQUISITO_DI_PRESENTAZIONE, REQUISITO_DI_ISTRUTTORIA, ORDINE, AUTOMATICO, DESCRIZIONE, QUERY_EVAL, QUERY_INSERT, VAL_MINIMO, VAL_MASSIMO, MISURA
		FROM vBANDO_REQUISITI_VARIANTE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis)
		ORDER BY ORDINE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRequisitiVarianteFindFind';

