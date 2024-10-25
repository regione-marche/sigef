CREATE PROCEDURE [dbo].[ZVariantiEsitiRequisitiFindFind]
(
	@IdVarianteequalthis INT, 
	@IdRequisitoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VARIANTE, ID_REQUISITO, COD_ESITO, DATA, CF_OPERATORE, COD_ESITO_ISTRUTTORE, DATA_VALUTAZIONE, ISTRUTTORE, NOTE, ESCLUDI_DA_COMUNICAZIONE, AUTOMATICO, DESCRIZIONE, QUERY_EVAL, QUERY_INSERT, VAL_MINIMO, VAL_MASSIMO, MISURA, ESITO, ESITO_POSITIVO, ESITO_ISTRUTTORE, ESITO_POSITIVO_ISTRUTTORE FROM vVARIANTI_ESITI_REQUISITI WHERE 1=1';
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REQUISITO = @IdRequisitoequalthis)'; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVarianteequalthis INT, @IdRequisitoequalthis INT',@IdVarianteequalthis , @IdRequisitoequalthis ;
	else
		SELECT ID_VARIANTE, ID_REQUISITO, COD_ESITO, DATA, CF_OPERATORE, COD_ESITO_ISTRUTTORE, DATA_VALUTAZIONE, ISTRUTTORE, NOTE, ESCLUDI_DA_COMUNICAZIONE, AUTOMATICO, DESCRIZIONE, QUERY_EVAL, QUERY_INSERT, VAL_MINIMO, VAL_MASSIMO, MISURA, ESITO, ESITO_POSITIVO, ESITO_ISTRUTTORE, ESITO_POSITIVO_ISTRUTTORE
		FROM vVARIANTI_ESITI_REQUISITI
		WHERE 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiEsitiRequisitiFindFind';

