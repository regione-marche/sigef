CREATE PROCEDURE [dbo].[ZVworkflowPagamentoFindSelect]
(
	@CodTipoequalthis CHAR(3), 
	@CodWorkflowequalthis CHAR(5), 
	@Ordineequalthis INT, 
	@Obbligatorioequalthis BIT, 
	@Descrizioneequalthis VARCHAR(500), 
	@Urlequalthis VARCHAR(100), 
	@TipoPagamentoequalthis VARCHAR(100), 
	@CodFaseequalthis CHAR(1), 
	@Faseequalthis VARCHAR(100), 
	@OrdineFaseequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO, COD_WORKFLOW, ORDINE, OBBLIGATORIO, DESCRIZIONE, URL, TIPO_PAGAMENTO, COD_FASE, FASE, ORDINE_FASE FROM vWORKFLOW_PAGAMENTO WHERE 1=1';
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@CodWorkflowequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_WORKFLOW = @CodWorkflowequalthis)'; set @lensql=@lensql+len(@CodWorkflowequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Obbligatorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OBBLIGATORIO = @Obbligatorioequalthis)'; set @lensql=@lensql+len(@Obbligatorioequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Urlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (URL = @Urlequalthis)'; set @lensql=@lensql+len(@Urlequalthis);end;
	IF (@TipoPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_PAGAMENTO = @TipoPagamentoequalthis)'; set @lensql=@lensql+len(@TipoPagamentoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@Faseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FASE = @Faseequalthis)'; set @lensql=@lensql+len(@Faseequalthis);end;
	IF (@OrdineFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE_FASE = @OrdineFaseequalthis)'; set @lensql=@lensql+len(@OrdineFaseequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoequalthis CHAR(3), @CodWorkflowequalthis CHAR(5), @Ordineequalthis INT, @Obbligatorioequalthis BIT, @Descrizioneequalthis VARCHAR(500), @Urlequalthis VARCHAR(100), @TipoPagamentoequalthis VARCHAR(100), @CodFaseequalthis CHAR(1), @Faseequalthis VARCHAR(100), @OrdineFaseequalthis INT',@CodTipoequalthis , @CodWorkflowequalthis , @Ordineequalthis , @Obbligatorioequalthis , @Descrizioneequalthis , @Urlequalthis , @TipoPagamentoequalthis , @CodFaseequalthis , @Faseequalthis , @OrdineFaseequalthis ;
	else
		SELECT COD_TIPO, COD_WORKFLOW, ORDINE, OBBLIGATORIO, DESCRIZIONE, URL, TIPO_PAGAMENTO, COD_FASE, FASE, ORDINE_FASE
		FROM vWORKFLOW_PAGAMENTO
		WHERE 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@CodWorkflowequalthis IS NULL) OR COD_WORKFLOW = @CodWorkflowequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Obbligatorioequalthis IS NULL) OR OBBLIGATORIO = @Obbligatorioequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Urlequalthis IS NULL) OR URL = @Urlequalthis) AND 
			((@TipoPagamentoequalthis IS NULL) OR TIPO_PAGAMENTO = @TipoPagamentoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@Faseequalthis IS NULL) OR FASE = @Faseequalthis) AND 
			((@OrdineFaseequalthis IS NULL) OR ORDINE_FASE = @OrdineFaseequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVworkflowPagamentoFindSelect]
(
	@CodTipoequalthis CHAR(3), 
	@IdWorkflowequalthis INT, 
	@Ordineequalthis INT, 
	@Obbligatorioequalthis BIT, 
	@Descrizioneequalthis VARCHAR(500), 
	@Urlequalthis VARCHAR(100), 
	@TipoPagamentoequalthis VARCHAR(100), 
	@CodFaseequalthis CHAR(1), 
	@Faseequalthis VARCHAR(100), 
	@OrdineFaseequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT COD_TIPO, ID_WORKFLOW, ORDINE, OBBLIGATORIO, DESCRIZIONE, URL, TIPO_PAGAMENTO, COD_FASE, FASE, ORDINE_FASE FROM vWORKFLOW_PAGAMENTO WHERE 1=1'';
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@IdWorkflowequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_WORKFLOW = @IdWorkflowequalthis)''; set @lensql=@lensql+len(@IdWorkflowequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Obbligatorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OBBLIGATORIO = @Obbligatorioequalthis)''; set @lensql=@lensql+len(@Obbligatorioequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Urlequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (URL = @Urlequalthis)''; set @lensql=@lensql+len(@Urlequalthis);end;
	IF (@TipoPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TIPO_PAGAMENTO = @TipoPagamentoequalthis)''; set @lensql=@lensql+len(@TipoPagamentoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FASE = @CodFaseequalthis)''; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@Faseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FASE = @Faseequalthis)''; set @lensql=@lensql+len(@Faseequalthis);end;
	IF (@OrdineFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE_FASE = @OrdineFaseequalthis)''; set @lensql=@lensql+len(@OrdineFaseequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@CodTipoequalthis CHAR(3), @IdWorkflowequalthis INT, @Ordineequalthis INT, @Obbligatorioequalthis BIT, @Descrizioneequalthis VARCHAR(500), @Urlequalthis VARCHAR(100), @TipoPagamentoequalthis VARCHAR(100), @CodFaseequalthis CHAR(1), @Faseequalthis VARCHAR(100), @OrdineFaseequalthis INT'',@CodTipoequalthis , @IdWorkflowequalthis , @Ordineequalthis , @Obbligatorioequalthis , @Descrizioneequalthis , @Urlequalthis , @TipoPagamentoequalthis , @CodFaseequalthis , @Faseequalthis , @OrdineFaseequalthis ;
	else
		SELECT COD_TIPO, ID_WORKFLOW, ORDINE, OBBLIGATORIO, DESCRIZIONE, URL, TIPO_PAGAMENTO, COD_FASE, FASE, ORDINE_FASE
		FROM vWORKFLOW_PAGAMENTO
		WHERE 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@IdWorkflowequalthis IS NULL) OR ID_WORKFLOW = @IdWorkflowequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Obbligatorioequalthis IS NULL) OR OBBLIGATORIO = @Obbligatorioequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Urlequalthis IS NULL) OR URL = @Urlequalthis) AND 
			((@TipoPagamentoequalthis IS NULL) OR TIPO_PAGAMENTO = @TipoPagamentoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@Faseequalthis IS NULL) OR FASE = @Faseequalthis) AND 
			((@OrdineFaseequalthis IS NULL) OR ORDINE_FASE = @OrdineFaseequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVworkflowPagamentoFindSelect';

