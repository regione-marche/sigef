CREATE PROCEDURE [dbo].[ZDecretiXDomPagEsportazioneFindFind]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDecretoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DECRETI_X_DOM_PAG_ESPORTAZIONE, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_DECRETO, IMPORTO, DATA_INSERIMENTO, DATA_MODIFICA, ID_ATTO, NUMERO, DATA, DESCRIZIONE, SERVIZIO, REGISTRO, COD_TIPO, COD_DEFINIZIONE, COD_ORGANO_ISTITUZIONALE, DATA_BUR, NUMERO_BUR, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO, DEFINIZIONE_ATTO, TIPO_ATTO, ORGANO_ISTITUZIONALE FROM vDECRETI_X_DOM_PAG_ESPORTAZIONE WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDecretoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DECRETO = @IdDecretoequalthis)'; set @lensql=@lensql+len(@IdDecretoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @IdDecretoequalthis INT',@IdDomandaPagamentoequalthis , @IdProgettoequalthis , @IdDecretoequalthis ;
	else
		SELECT ID_DECRETI_X_DOM_PAG_ESPORTAZIONE, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_DECRETO, IMPORTO, DATA_INSERIMENTO, DATA_MODIFICA, ID_ATTO, NUMERO, DATA, DESCRIZIONE, SERVIZIO, REGISTRO, COD_TIPO, COD_DEFINIZIONE, COD_ORGANO_ISTITUZIONALE, DATA_BUR, NUMERO_BUR, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO, DEFINIZIONE_ATTO, TIPO_ATTO, ORGANO_ISTITUZIONALE
		FROM vDECRETI_X_DOM_PAG_ESPORTAZIONE
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDecretoequalthis IS NULL) OR ID_DECRETO = @IdDecretoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDecretiXDomPagEsportazioneFindFind';

