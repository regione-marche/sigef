CREATE PROCEDURE [dbo].[ZWorkflowProcedureFindFind]
(
	@CodTipoProceduraequalthis CHAR(3), 
	@CodWorkflowequalthis CHAR(5), 
	@Obbligatorioequalthis BIT, 
	@Ordineeqgreaterthanthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_TIPO_PROCEDURA, COD_WORKFLOW, ORDINE, OBBLIGATORIO, DESCRIZIONE, URL FROM vWORKFLOW_PROCEDURE WHERE 1=1';
	IF (@CodTipoProceduraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_PROCEDURA = @CodTipoProceduraequalthis)'; set @lensql=@lensql+len(@CodTipoProceduraequalthis);end;
	IF (@CodWorkflowequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_WORKFLOW = @CodWorkflowequalthis)'; set @lensql=@lensql+len(@CodWorkflowequalthis);end;
	IF (@Obbligatorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OBBLIGATORIO = @Obbligatorioequalthis)'; set @lensql=@lensql+len(@Obbligatorioequalthis);end;
	IF (@Ordineeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE >= @Ordineeqgreaterthanthis)'; set @lensql=@lensql+len(@Ordineeqgreaterthanthis);end;
	set @sql = @sql + 'ORDER BY ORDINE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoProceduraequalthis CHAR(3), @CodWorkflowequalthis CHAR(5), @Obbligatorioequalthis BIT, @Ordineeqgreaterthanthis INT',@CodTipoProceduraequalthis , @CodWorkflowequalthis , @Obbligatorioequalthis , @Ordineeqgreaterthanthis ;
	else
		SELECT COD_TIPO_PROCEDURA, COD_WORKFLOW, ORDINE, OBBLIGATORIO, DESCRIZIONE, URL
		FROM vWORKFLOW_PROCEDURE
		WHERE 
			((@CodTipoProceduraequalthis IS NULL) OR COD_TIPO_PROCEDURA = @CodTipoProceduraequalthis) AND 
			((@CodWorkflowequalthis IS NULL) OR COD_WORKFLOW = @CodWorkflowequalthis) AND 
			((@Obbligatorioequalthis IS NULL) OR OBBLIGATORIO = @Obbligatorioequalthis) AND 
			((@Ordineeqgreaterthanthis IS NULL) OR ORDINE >= @Ordineeqgreaterthanthis)
		ORDER BY ORDINE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZWorkflowProcedureFindFind';

