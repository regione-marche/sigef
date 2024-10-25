CREATE PROCEDURE [dbo].[ZVariantiEsitiRequisitiFindSelect]
(
	@IdVarianteequalthis INT, 
	@IdRequisitoequalthis INT, 
	@CodEsitoequalthis CHAR(2), 
	@Dataequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(16), 
	@CodEsitoIstruttoreequalthis CHAR(2), 
	@DataValutazioneequalthis DATETIME, 
	@Istruttoreequalthis VARCHAR(16), 
	@EscludiDaComunicazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VARIANTE, ID_REQUISITO, COD_ESITO, DATA, CF_OPERATORE, COD_ESITO_ISTRUTTORE, DATA_VALUTAZIONE, ISTRUTTORE, NOTE, ESCLUDI_DA_COMUNICAZIONE, AUTOMATICO, DESCRIZIONE, QUERY_EVAL, QUERY_INSERT, VAL_MINIMO, VAL_MASSIMO, MISURA, ESITO, ESITO_POSITIVO, ESITO_ISTRUTTORE, ESITO_POSITIVO_ISTRUTTORE FROM vVARIANTI_ESITI_REQUISITI WHERE 1=1';
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REQUISITO = @IdRequisitoequalthis)'; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO = @CodEsitoequalthis)'; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE = @CfOperatoreequalthis)'; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@CodEsitoIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO_ISTRUTTORE = @CodEsitoIstruttoreequalthis)'; set @lensql=@lensql+len(@CodEsitoIstruttoreequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)'; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE = @Istruttoreequalthis)'; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	IF (@EscludiDaComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazioneequalthis)'; set @lensql=@lensql+len(@EscludiDaComunicazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVarianteequalthis INT, @IdRequisitoequalthis INT, @CodEsitoequalthis CHAR(2), @Dataequalthis DATETIME, @CfOperatoreequalthis VARCHAR(16), @CodEsitoIstruttoreequalthis CHAR(2), @DataValutazioneequalthis DATETIME, @Istruttoreequalthis VARCHAR(16), @EscludiDaComunicazioneequalthis BIT',@IdVarianteequalthis , @IdRequisitoequalthis , @CodEsitoequalthis , @Dataequalthis , @CfOperatoreequalthis , @CodEsitoIstruttoreequalthis , @DataValutazioneequalthis , @Istruttoreequalthis , @EscludiDaComunicazioneequalthis ;
	else
		SELECT ID_VARIANTE, ID_REQUISITO, COD_ESITO, DATA, CF_OPERATORE, COD_ESITO_ISTRUTTORE, DATA_VALUTAZIONE, ISTRUTTORE, NOTE, ESCLUDI_DA_COMUNICAZIONE, AUTOMATICO, DESCRIZIONE, QUERY_EVAL, QUERY_INSERT, VAL_MINIMO, VAL_MASSIMO, MISURA, ESITO, ESITO_POSITIVO, ESITO_ISTRUTTORE, ESITO_POSITIVO_ISTRUTTORE
		FROM vVARIANTI_ESITI_REQUISITI
		WHERE 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis) AND 
			((@CodEsitoIstruttoreequalthis IS NULL) OR COD_ESITO_ISTRUTTORE = @CodEsitoIstruttoreequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@Istruttoreequalthis IS NULL) OR ISTRUTTORE = @Istruttoreequalthis) AND 
			((@EscludiDaComunicazioneequalthis IS NULL) OR ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazioneequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiEsitiRequisitiFindSelect';

