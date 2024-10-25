CREATE PROCEDURE [dbo].[ZBandoRequisitiVarianteFindSelect]
(
	@IdBandoequalthis INT, 
	@CodTipoequalthis CHAR(2), 
	@IdRequisitoequalthis INT, 
	@Obbligatorioequalthis BIT, 
	@RequisitoDiPresentazioneequalthis BIT, 
	@RequisitoDiIstruttoriaequalthis BIT, 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, COD_TIPO, ID_REQUISITO, OBBLIGATORIO, REQUISITO_DI_PRESENTAZIONE, REQUISITO_DI_ISTRUTTORIA, ORDINE, AUTOMATICO, DESCRIZIONE, QUERY_EVAL, QUERY_INSERT, VAL_MINIMO, VAL_MASSIMO, MISURA FROM vBANDO_REQUISITI_VARIANTE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REQUISITO = @IdRequisitoequalthis)'; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	IF (@Obbligatorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OBBLIGATORIO = @Obbligatorioequalthis)'; set @lensql=@lensql+len(@Obbligatorioequalthis);end;
	IF (@RequisitoDiPresentazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REQUISITO_DI_PRESENTAZIONE = @RequisitoDiPresentazioneequalthis)'; set @lensql=@lensql+len(@RequisitoDiPresentazioneequalthis);end;
	IF (@RequisitoDiIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REQUISITO_DI_ISTRUTTORIA = @RequisitoDiIstruttoriaequalthis)'; set @lensql=@lensql+len(@RequisitoDiIstruttoriaequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodTipoequalthis CHAR(2), @IdRequisitoequalthis INT, @Obbligatorioequalthis BIT, @RequisitoDiPresentazioneequalthis BIT, @RequisitoDiIstruttoriaequalthis BIT, @Ordineequalthis INT',@IdBandoequalthis , @CodTipoequalthis , @IdRequisitoequalthis , @Obbligatorioequalthis , @RequisitoDiPresentazioneequalthis , @RequisitoDiIstruttoriaequalthis , @Ordineequalthis ;
	else
		SELECT ID_BANDO, COD_TIPO, ID_REQUISITO, OBBLIGATORIO, REQUISITO_DI_PRESENTAZIONE, REQUISITO_DI_ISTRUTTORIA, ORDINE, AUTOMATICO, DESCRIZIONE, QUERY_EVAL, QUERY_INSERT, VAL_MINIMO, VAL_MASSIMO, MISURA
		FROM vBANDO_REQUISITI_VARIANTE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis) AND 
			((@Obbligatorioequalthis IS NULL) OR OBBLIGATORIO = @Obbligatorioequalthis) AND 
			((@RequisitoDiPresentazioneequalthis IS NULL) OR REQUISITO_DI_PRESENTAZIONE = @RequisitoDiPresentazioneequalthis) AND 
			((@RequisitoDiIstruttoriaequalthis IS NULL) OR REQUISITO_DI_ISTRUTTORIA = @RequisitoDiIstruttoriaequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRequisitiVarianteFindSelect';

