CREATE PROCEDURE [dbo].[ZTipoIntegrazioneDomandaFindSelect]
(
	@CodTipoequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO, DESCRIZIONE FROM VTIPO_INTEGRAZIONE_DOMANDA WHERE 1=1';
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255)',@CodTipoequalthis , @Descrizioneequalthis ;
	else
		SELECT COD_TIPO, DESCRIZIONE
		FROM VTIPO_INTEGRAZIONE_DOMANDA
		WHERE 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoIntegrazioneDomandaFindSelect';

