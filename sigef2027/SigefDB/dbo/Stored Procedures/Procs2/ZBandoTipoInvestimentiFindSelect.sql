CREATE PROCEDURE [dbo].[ZBandoTipoInvestimentiFindSelect]
(
	@IdTipoInvestimentoequalthis INT, 
	@IdBandoequalthis INT, 
	@CodTipoInvestimentoequalthis INT, 
	@ImportoMaxequalthis DECIMAL(15,2), 
	@ImportoMinequalthis DECIMAL(15,2), 
	@QuotaMaxequalthis DECIMAL(10,2), 
	@Noteequalthis VARCHAR(500), 
	@Premioequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_TIPO_INVESTIMENTO, ID_BANDO, COD_TIPO_INVESTIMENTO, IMPORTO_MAX, IMPORTO_MIN, QUOTA_MAX, NOTE, PREMIO, DESCRIZIONE, URL, TEXT FROM vBANDO_TIPO_INVESTIMENTI WHERE 1=1';
	IF (@IdTipoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_INVESTIMENTO = @IdTipoInvestimentoequalthis)'; set @lensql=@lensql+len(@IdTipoInvestimentoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis)'; set @lensql=@lensql+len(@CodTipoInvestimentoequalthis);end;
	IF (@ImportoMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_MAX = @ImportoMaxequalthis)'; set @lensql=@lensql+len(@ImportoMaxequalthis);end;
	IF (@ImportoMinequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_MIN = @ImportoMinequalthis)'; set @lensql=@lensql+len(@ImportoMinequalthis);end;
	IF (@QuotaMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUOTA_MAX = @QuotaMaxequalthis)'; set @lensql=@lensql+len(@QuotaMaxequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@Premioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREMIO = @Premioequalthis)'; set @lensql=@lensql+len(@Premioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdTipoInvestimentoequalthis INT, @IdBandoequalthis INT, @CodTipoInvestimentoequalthis INT, @ImportoMaxequalthis DECIMAL(15,2), @ImportoMinequalthis DECIMAL(15,2), @QuotaMaxequalthis DECIMAL(10,2), @Noteequalthis VARCHAR(500), @Premioequalthis BIT',@IdTipoInvestimentoequalthis , @IdBandoequalthis , @CodTipoInvestimentoequalthis , @ImportoMaxequalthis , @ImportoMinequalthis , @QuotaMaxequalthis , @Noteequalthis , @Premioequalthis ;
	else
		SELECT ID_TIPO_INVESTIMENTO, ID_BANDO, COD_TIPO_INVESTIMENTO, IMPORTO_MAX, IMPORTO_MIN, QUOTA_MAX, NOTE, PREMIO, DESCRIZIONE, URL, TEXT
		FROM vBANDO_TIPO_INVESTIMENTI
		WHERE 
			((@IdTipoInvestimentoequalthis IS NULL) OR ID_TIPO_INVESTIMENTO = @IdTipoInvestimentoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoInvestimentoequalthis IS NULL) OR COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis) AND 
			((@ImportoMaxequalthis IS NULL) OR IMPORTO_MAX = @ImportoMaxequalthis) AND 
			((@ImportoMinequalthis IS NULL) OR IMPORTO_MIN = @ImportoMinequalthis) AND 
			((@QuotaMaxequalthis IS NULL) OR QUOTA_MAX = @QuotaMaxequalthis) AND 
			((@Noteequalthis IS NULL) OR NOTE = @Noteequalthis) AND 
			((@Premioequalthis IS NULL) OR PREMIO = @Premioequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'





CREATE PROCEDURE [dbo].[ZBandoTipoInvestimentiFindSelect]
(
	@IdTipoInvestimentoequalthis INT, 
	@IdBandoequalthis INT, 
	@CodTipoInvestimentoequalthis INT, 
	@ImportoMaxequalthis DECIMAL(15,2), 
	@ImportoMinequalthis DECIMAL(15,2), 
	@QuotaMaxequalthis DECIMAL(10,2), 
	@Noteequalthis VARCHAR(500), 
	@Premioequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_TIPO_INVESTIMENTO, ID_BANDO, COD_TIPO_INVESTIMENTO, IMPORTO_MAX, IMPORTO_MIN, QUOTA_MAX, NOTE, PREMIO, DESCRIZIONE, URL, TEXT FROM vBANDO_TIPO_INVESTIMENTO WHERE 1=1'';
	IF (@IdTipoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_TIPO_INVESTIMENTO = @IdTipoInvestimentoequalthis)''; set @lensql=@lensql+len(@IdTipoInvestimentoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis)''; set @lensql=@lensql+len(@CodTipoInvestimentoequalthis);end;
	IF (@ImportoMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_MAX = @ImportoMaxequalthis)''; set @lensql=@lensql+len(@ImportoMaxequalthis);end;
	IF (@ImportoMinequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_MIN = @ImportoMinequalthis)''; set @lensql=@lensql+len(@ImportoMinequalthis);end;
	IF (@QuotaMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUOTA_MAX = @QuotaMaxequalthis)''; set @lensql=@lensql+len(@QuotaMaxequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NOTE = @Noteequalthis)''; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@Premioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PREMIO = @Premioequalthis)''; set @lensql=@lensql+len(@Premioequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdTipoInvestimentoequalthis INT, @IdBandoequalthis INT, @CodTipoInvestimentoequalthis INT, @ImportoMaxequalthis DECIMAL(15,2), @ImportoMinequalthis DECIMAL(15,2), @QuotaMaxequalthis DECIMAL(10,2), @Noteequalthis VARCHAR(500), @Premioequalthis BIT'',@IdTipoInvestimentoequalthis , @IdBandoequalthis , @CodTipoInvestimentoequalthis , @ImportoMaxequalthis , @ImportoMinequalthis , @QuotaMaxequalthis , @Noteequalthis , @Premioequalthis ;
	else
		SELECT ID_TIPO_INVESTIMENTO, ID_BANDO, COD_TIPO_INVESTIMENTO, IMPORTO_MAX, IMPORTO_MIN, QUOTA_MAX, NOTE, PREMIO, DESCRIZIONE, URL, TEXT
		FROM vBANDO_TIPO_INVESTIMENTO
		WHERE 
			((@IdTipoInvestimentoequalthis IS NULL) OR ID_TIPO_INVESTIMENTO = @IdTipoInvestimentoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoInvestimentoequalthis IS NULL) OR COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis) AND 
			((@ImportoMaxequalthis IS NULL) OR IMPORTO_MAX = @ImportoMaxequalthis) AND 
			((@ImportoMinequalthis IS NULL) OR IMPORTO_MIN = @ImportoMinequalthis) AND 
			((@QuotaMaxequalthis IS NULL) OR QUOTA_MAX = @QuotaMaxequalthis) AND 
			((@Noteequalthis IS NULL) OR NOTE = @Noteequalthis) AND 
			((@Premioequalthis IS NULL) OR PREMIO = @Premioequalthis)
		-- order by ecc.ecc.

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoTipoInvestimentiFindSelect';

