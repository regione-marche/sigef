CREATE PROCEDURE [dbo].[ZBandoTipoPagamentoFindSelect]
(
	@IdBandoequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@QuotaMaxequalthis DECIMAL(10,2), 
	@QuotaMinequalthis DECIMAL(10,2), 
	@ImportoMaxequalthis DECIMAL(18,2), 
	@ImportoMinequalthis DECIMAL(18,2), 
	@Numeroequalthis INT, 
	@CodTipoPolizzaequalthis CHAR(3)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, COD_TIPO, QUOTA_MAX, QUOTA_MIN, IMPORTO_MAX, IMPORTO_MIN, DESCRIZIONE, COD_FASE, FASE, ORDINE, NUMERO, COD_TIPO_POLIZZA, TIPO_POLIZZA FROM vBANDO_TIPO_PAGAMENTO WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@QuotaMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUOTA_MAX = @QuotaMaxequalthis)'; set @lensql=@lensql+len(@QuotaMaxequalthis);end;
	IF (@QuotaMinequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUOTA_MIN = @QuotaMinequalthis)'; set @lensql=@lensql+len(@QuotaMinequalthis);end;
	IF (@ImportoMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_MAX = @ImportoMaxequalthis)'; set @lensql=@lensql+len(@ImportoMaxequalthis);end;
	IF (@ImportoMinequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_MIN = @ImportoMinequalthis)'; set @lensql=@lensql+len(@ImportoMinequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@CodTipoPolizzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_POLIZZA = @CodTipoPolizzaequalthis)'; set @lensql=@lensql+len(@CodTipoPolizzaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodTipoequalthis CHAR(3), @QuotaMaxequalthis DECIMAL(10,2), @QuotaMinequalthis DECIMAL(10,2), @ImportoMaxequalthis DECIMAL(18,2), @ImportoMinequalthis DECIMAL(18,2), @Numeroequalthis INT, @CodTipoPolizzaequalthis CHAR(3)',@IdBandoequalthis , @CodTipoequalthis , @QuotaMaxequalthis , @QuotaMinequalthis , @ImportoMaxequalthis , @ImportoMinequalthis , @Numeroequalthis , @CodTipoPolizzaequalthis ;
	else
		SELECT ID_BANDO, COD_TIPO, QUOTA_MAX, QUOTA_MIN, IMPORTO_MAX, IMPORTO_MIN, DESCRIZIONE, COD_FASE, FASE, ORDINE, NUMERO, COD_TIPO_POLIZZA, TIPO_POLIZZA
		FROM vBANDO_TIPO_PAGAMENTO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@QuotaMaxequalthis IS NULL) OR QUOTA_MAX = @QuotaMaxequalthis) AND 
			((@QuotaMinequalthis IS NULL) OR QUOTA_MIN = @QuotaMinequalthis) AND 
			((@ImportoMaxequalthis IS NULL) OR IMPORTO_MAX = @ImportoMaxequalthis) AND 
			((@ImportoMinequalthis IS NULL) OR IMPORTO_MIN = @ImportoMinequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@CodTipoPolizzaequalthis IS NULL) OR COD_TIPO_POLIZZA = @CodTipoPolizzaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoTipoPagamentoFindSelect]
(
	@IdBandoequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@QuotaMaxequalthis DECIMAL(10,2), 
	@QuotaMinequalthis DECIMAL(10,2), 
	@ImportoMaxequalthis DECIMAL(18,2), 
	@ImportoMinequalthis DECIMAL(18,2), 
	@Numeroequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_BANDO, COD_TIPO, QUOTA_MAX, QUOTA_MIN, IMPORTO_MAX, IMPORTO_MIN, DESCRIZIONE, COD_FASE, FASE, ORDINE, NUMERO FROM vBANDO_TIPO_PAGAMENTO WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@QuotaMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUOTA_MAX = @QuotaMaxequalthis)''; set @lensql=@lensql+len(@QuotaMaxequalthis);end;
	IF (@QuotaMinequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUOTA_MIN = @QuotaMinequalthis)''; set @lensql=@lensql+len(@QuotaMinequalthis);end;
	IF (@ImportoMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_MAX = @ImportoMaxequalthis)''; set @lensql=@lensql+len(@ImportoMaxequalthis);end;
	IF (@ImportoMinequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_MIN = @ImportoMinequalthis)''; set @lensql=@lensql+len(@ImportoMinequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO = @Numeroequalthis)''; set @lensql=@lensql+len(@Numeroequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT, @CodTipoequalthis CHAR(3), @QuotaMaxequalthis DECIMAL(10,2), @QuotaMinequalthis DECIMAL(10,2), @ImportoMaxequalthis DECIMAL(18,2), @ImportoMinequalthis DECIMAL(18,2), @Numeroequalthis INT'',@IdBandoequalthis , @CodTipoequalthis , @QuotaMaxequalthis , @QuotaMinequalthis , @ImportoMaxequalthis , @ImportoMinequalthis , @Numeroequalthis ;
	else
		SELECT ID_BANDO, COD_TIPO, QUOTA_MAX, QUOTA_MIN, IMPORTO_MAX, IMPORTO_MIN, DESCRIZIONE, COD_FASE, FASE, ORDINE, NUMERO
		FROM vBANDO_TIPO_PAGAMENTO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@QuotaMaxequalthis IS NULL) OR QUOTA_MAX = @QuotaMaxequalthis) AND 
			((@QuotaMinequalthis IS NULL) OR QUOTA_MIN = @QuotaMinequalthis) AND 
			((@ImportoMaxequalthis IS NULL) OR IMPORTO_MAX = @ImportoMaxequalthis) AND 
			((@ImportoMinequalthis IS NULL) OR IMPORTO_MIN = @ImportoMinequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoPagamentoFindSelect';

