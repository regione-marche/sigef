CREATE PROCEDURE [dbo].[ZBandoTipoInvestimentiFindFind]
(
	@IdBandoequalthis INT, 
	@CodTipoInvestimentoequalthis INT, 
	@Premioequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_TIPO_INVESTIMENTO, ID_BANDO, COD_TIPO_INVESTIMENTO, IMPORTO_MAX, IMPORTO_MIN, QUOTA_MAX, NOTE, PREMIO, DESCRIZIONE, URL, TEXT FROM vBANDO_TIPO_INVESTIMENTI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis)'; set @lensql=@lensql+len(@CodTipoInvestimentoequalthis);end;
	IF (@Premioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREMIO = @Premioequalthis)'; set @lensql=@lensql+len(@Premioequalthis);end;
	set @sql = @sql + 'ORDER BY ID_TIPO_INVESTIMENTO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodTipoInvestimentoequalthis INT, @Premioequalthis BIT',@IdBandoequalthis , @CodTipoInvestimentoequalthis , @Premioequalthis ;
	else
		SELECT ID_TIPO_INVESTIMENTO, ID_BANDO, COD_TIPO_INVESTIMENTO, IMPORTO_MAX, IMPORTO_MIN, QUOTA_MAX, NOTE, PREMIO, DESCRIZIONE, URL, TEXT
		FROM vBANDO_TIPO_INVESTIMENTI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoInvestimentoequalthis IS NULL) OR COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis) AND 
			((@Premioequalthis IS NULL) OR PREMIO = @Premioequalthis)
		ORDER BY ID_TIPO_INVESTIMENTO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZBandoTipoInvestimentiFindFind]
(
	@IdTipoInvestimentoequalthis INT, 
	@IdBandoequalthis INT, 
	@CodTipoInvestimentoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_TIPO_INVESTIMENTO, ID_BANDO, COD_TIPO_INVESTIMENTO, IMPORTO_MAX, IMPORTO_MIN, QUOTA_MAX, NOTE, PREMIO, DESCRIZIONE, URL, TEXT FROM vBANDO_TIPO_INVESTIMENTO WHERE 1=1'';
	IF (@IdTipoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_TIPO_INVESTIMENTO = @IdTipoInvestimentoequalthis)''; set @lensql=@lensql+len(@IdTipoInvestimentoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis)''; set @lensql=@lensql+len(@CodTipoInvestimentoequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdTipoInvestimentoequalthis INT, @IdBandoequalthis INT, @CodTipoInvestimentoequalthis INT'',@IdTipoInvestimentoequalthis , @IdBandoequalthis , @CodTipoInvestimentoequalthis ;
	else
		SELECT ID_TIPO_INVESTIMENTO, ID_BANDO, COD_TIPO_INVESTIMENTO, IMPORTO_MAX, IMPORTO_MIN, QUOTA_MAX, NOTE, PREMIO, DESCRIZIONE, URL, TEXT
		FROM vBANDO_TIPO_INVESTIMENTO
		WHERE 
			((@IdTipoInvestimentoequalthis IS NULL) OR ID_TIPO_INVESTIMENTO = @IdTipoInvestimentoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoInvestimentoequalthis IS NULL) OR COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis)
		-- order by ecc.ecc.

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoInvestimentiFindFind';

