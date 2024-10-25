CREATE PROCEDURE [dbo].[ZBandoTipoPagamentoFindFind]
(
	@IdBandoequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@CodFaseequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, COD_TIPO, QUOTA_MAX, QUOTA_MIN, IMPORTO_MAX, IMPORTO_MIN, DESCRIZIONE, COD_FASE, FASE, ORDINE, NUMERO, COD_TIPO_POLIZZA, TIPO_POLIZZA FROM vBANDO_TIPO_PAGAMENTO WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodTipoequalthis CHAR(3), @CodFaseequalthis CHAR(1)',@IdBandoequalthis , @CodTipoequalthis , @CodFaseequalthis ;
	else
		SELECT ID_BANDO, COD_TIPO, QUOTA_MAX, QUOTA_MIN, IMPORTO_MAX, IMPORTO_MIN, DESCRIZIONE, COD_FASE, FASE, ORDINE, NUMERO, COD_TIPO_POLIZZA, TIPO_POLIZZA
		FROM vBANDO_TIPO_PAGAMENTO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoTipoPagamentoFindFind]
(
	@IdBandoequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@CodFaseequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_BANDO, COD_TIPO, QUOTA_MAX, QUOTA_MIN, IMPORTO_MAX, IMPORTO_MIN, DESCRIZIONE, COD_FASE, FASE, ORDINE, NUMERO FROM vBANDO_TIPO_PAGAMENTO WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FASE = @CodFaseequalthis)''; set @lensql=@lensql+len(@CodFaseequalthis);end;
	set @sql = @sql + ''ORDER BY ORDINE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT, @CodTipoequalthis CHAR(3), @CodFaseequalthis CHAR(1)'',@IdBandoequalthis , @CodTipoequalthis , @CodFaseequalthis ;
	else
		SELECT ID_BANDO, COD_TIPO, QUOTA_MAX, QUOTA_MIN, IMPORTO_MAX, IMPORTO_MIN, DESCRIZIONE, COD_FASE, FASE, ORDINE, NUMERO
		FROM vBANDO_TIPO_PAGAMENTO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)
		ORDER BY ORDINE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoPagamentoFindFind';

