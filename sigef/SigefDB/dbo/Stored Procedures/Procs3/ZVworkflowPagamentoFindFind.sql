CREATE PROCEDURE [dbo].[ZVworkflowPagamentoFindFind]
(
	@CodTipoequalthis CHAR(3), 
	@CodWorkflowequalthis CHAR(5), 
	@CodFaseequalthis CHAR(1), 
	@Descrizionelikethis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO, COD_WORKFLOW, ORDINE, OBBLIGATORIO, DESCRIZIONE, URL, TIPO_PAGAMENTO, COD_FASE, FASE, ORDINE_FASE FROM vWORKFLOW_PAGAMENTO WHERE 1=1';
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@CodWorkflowequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_WORKFLOW = @CodWorkflowequalthis)'; set @lensql=@lensql+len(@CodWorkflowequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @sql = @sql + 'ORDER BY ORDINE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoequalthis CHAR(3), @CodWorkflowequalthis CHAR(5), @CodFaseequalthis CHAR(1), @Descrizionelikethis VARCHAR(500)',@CodTipoequalthis , @CodWorkflowequalthis , @CodFaseequalthis , @Descrizionelikethis ;
	else
		SELECT COD_TIPO, COD_WORKFLOW, ORDINE, OBBLIGATORIO, DESCRIZIONE, URL, TIPO_PAGAMENTO, COD_FASE, FASE, ORDINE_FASE
		FROM vWORKFLOW_PAGAMENTO
		WHERE 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@CodWorkflowequalthis IS NULL) OR COD_WORKFLOW = @CodWorkflowequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis)
		ORDER BY ORDINE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVworkflowPagamentoFindFind]
(
	@CodTipoequalthis CHAR(3), 
	@IdWorkflowequalthis INT, 
	@CodFaseequalthis CHAR(1), 
	@Descrizionelikethis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT COD_TIPO, ID_WORKFLOW, ORDINE, OBBLIGATORIO, DESCRIZIONE, URL, TIPO_PAGAMENTO, COD_FASE, FASE, ORDINE_FASE FROM vWORKFLOW_PAGAMENTO WHERE 1=1'';
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@IdWorkflowequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_WORKFLOW = @IdWorkflowequalthis)''; set @lensql=@lensql+len(@IdWorkflowequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FASE = @CodFaseequalthis)''; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE LIKE @Descrizionelikethis)''; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @sql = @sql + ''ORDER BY ORDINE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@CodTipoequalthis CHAR(3), @IdWorkflowequalthis INT, @CodFaseequalthis CHAR(1), @Descrizionelikethis VARCHAR(500)'',@CodTipoequalthis , @IdWorkflowequalthis , @CodFaseequalthis , @Descrizionelikethis ;
	else
		SELECT COD_TIPO, ID_WORKFLOW, ORDINE, OBBLIGATORIO, DESCRIZIONE, URL, TIPO_PAGAMENTO, COD_FASE, FASE, ORDINE_FASE
		FROM vWORKFLOW_PAGAMENTO
		WHERE 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@IdWorkflowequalthis IS NULL) OR ID_WORKFLOW = @IdWorkflowequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis)
		ORDER BY ORDINE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVworkflowPagamentoFindFind';

