CREATE PROCEDURE [dbo].[ZTipoComunicazioneFindFind]
(
	@InEntrataequalthis BIT, 
	@InUscitaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO, DESCRIZIONE, IN_ENTRATA, IN_USCITA FROM TIPO_COMUNICAZIONE WHERE 1=1';
	IF (@InEntrataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_ENTRATA = @InEntrataequalthis)'; set @lensql=@lensql+len(@InEntrataequalthis);end;
	IF (@InUscitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_USCITA = @InUscitaequalthis)'; set @lensql=@lensql+len(@InUscitaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@InEntrataequalthis BIT, @InUscitaequalthis BIT',@InEntrataequalthis , @InUscitaequalthis ;
	else
		SELECT COD_TIPO, DESCRIZIONE, IN_ENTRATA, IN_USCITA
		FROM TIPO_COMUNICAZIONE
		WHERE 
			((@InEntrataequalthis IS NULL) OR IN_ENTRATA = @InEntrataequalthis) AND 
			((@InUscitaequalthis IS NULL) OR IN_USCITA = @InUscitaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoComunicazioneFindFind';

