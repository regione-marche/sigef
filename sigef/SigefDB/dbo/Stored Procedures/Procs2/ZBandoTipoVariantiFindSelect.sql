CREATE PROCEDURE [dbo].[ZBandoTipoVariantiFindSelect]
(
	@IdBandoequalthis INT, 
	@CodTipoequalthis CHAR(2), 
	@NumeroMassimoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, COD_TIPO, NUMERO_MASSIMO FROM BANDO_TIPO_VARIANTI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@NumeroMassimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_MASSIMO = @NumeroMassimoequalthis)'; set @lensql=@lensql+len(@NumeroMassimoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodTipoequalthis CHAR(2), @NumeroMassimoequalthis INT',@IdBandoequalthis , @CodTipoequalthis , @NumeroMassimoequalthis ;
	else
		SELECT ID_BANDO, COD_TIPO, NUMERO_MASSIMO
		FROM BANDO_TIPO_VARIANTI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@NumeroMassimoequalthis IS NULL) OR NUMERO_MASSIMO = @NumeroMassimoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoVariantiFindSelect';

