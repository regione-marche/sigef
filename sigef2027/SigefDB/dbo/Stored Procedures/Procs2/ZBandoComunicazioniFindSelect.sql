CREATE PROCEDURE [dbo].[ZBandoComunicazioniFindSelect]
(
	@CodTipoequalthis VARCHAR(255), 
	@IdBandoequalthis INT, 
	@IdAttoequalthis INT, 
	@Dataequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO, ID_BANDO, TESTO, MODALITA_ANTICIPO, OBBLIGHI_BENEFICIARIO, ID_ATTO, DATA FROM BANDO_COMUNICAZIONI WHERE 1=1';
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO = @IdAttoequalthis)'; set @lensql=@lensql+len(@IdAttoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoequalthis VARCHAR(255), @IdBandoequalthis INT, @IdAttoequalthis INT, @Dataequalthis DATETIME',@CodTipoequalthis , @IdBandoequalthis , @IdAttoequalthis , @Dataequalthis ;
	else
		SELECT COD_TIPO, ID_BANDO, TESTO, MODALITA_ANTICIPO, OBBLIGHI_BENEFICIARIO, ID_ATTO, DATA
		FROM BANDO_COMUNICAZIONI
		WHERE 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdAttoequalthis IS NULL) OR ID_ATTO = @IdAttoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoComunicazioniFindSelect';

