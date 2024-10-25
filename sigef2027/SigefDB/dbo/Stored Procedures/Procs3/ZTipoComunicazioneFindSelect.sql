CREATE PROCEDURE [dbo].[ZTipoComunicazioneFindSelect]
(
	@CodTipoequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@InEntrataequalthis BIT, 
	@InUscitaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO, DESCRIZIONE, IN_ENTRATA, IN_USCITA FROM TIPO_COMUNICAZIONE WHERE 1=1';
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@InEntrataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_ENTRATA = @InEntrataequalthis)'; set @lensql=@lensql+len(@InEntrataequalthis);end;
	IF (@InUscitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_USCITA = @InUscitaequalthis)'; set @lensql=@lensql+len(@InUscitaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @InEntrataequalthis BIT, @InUscitaequalthis BIT',@CodTipoequalthis , @Descrizioneequalthis , @InEntrataequalthis , @InUscitaequalthis ;
	else
		SELECT COD_TIPO, DESCRIZIONE, IN_ENTRATA, IN_USCITA
		FROM TIPO_COMUNICAZIONE
		WHERE 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@InEntrataequalthis IS NULL) OR IN_ENTRATA = @InEntrataequalthis) AND 
			((@InUscitaequalthis IS NULL) OR IN_USCITA = @InUscitaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoComunicazioneFindSelect';

