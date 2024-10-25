CREATE PROCEDURE [dbo].[ZDecretiXDomPagEsportazioneFindSelect]
(
	@IdDecretiXDomPagEsportazioneequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDecretoequalthis INT, 
	@Importoequalthis DECIMAL(18,2), 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DECRETI_X_DOM_PAG_ESPORTAZIONE, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_DECRETO, IMPORTO, DATA_INSERIMENTO, DATA_MODIFICA, ID_ATTO, NUMERO, DATA, DESCRIZIONE, SERVIZIO, REGISTRO, COD_TIPO, COD_DEFINIZIONE, COD_ORGANO_ISTITUZIONALE, DATA_BUR, NUMERO_BUR, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO, DEFINIZIONE_ATTO, TIPO_ATTO, ORGANO_ISTITUZIONALE FROM vDECRETI_X_DOM_PAG_ESPORTAZIONE WHERE 1=1';
	IF (@IdDecretiXDomPagEsportazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DECRETI_X_DOM_PAG_ESPORTAZIONE = @IdDecretiXDomPagEsportazioneequalthis)'; set @lensql=@lensql+len(@IdDecretiXDomPagEsportazioneequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDecretoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DECRETO = @IdDecretoequalthis)'; set @lensql=@lensql+len(@IdDecretoequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO = @Importoequalthis)'; set @lensql=@lensql+len(@Importoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDecretiXDomPagEsportazioneequalthis INT, @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @IdDecretoequalthis INT, @Importoequalthis DECIMAL(18,2), @DataInserimentoequalthis DATETIME, @DataModificaequalthis DATETIME',@IdDecretiXDomPagEsportazioneequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis , @IdDecretoequalthis , @Importoequalthis , @DataInserimentoequalthis , @DataModificaequalthis ;
	else
		SELECT ID_DECRETI_X_DOM_PAG_ESPORTAZIONE, ID_DOMANDA_PAGAMENTO, ID_PROGETTO, ID_DECRETO, IMPORTO, DATA_INSERIMENTO, DATA_MODIFICA, ID_ATTO, NUMERO, DATA, DESCRIZIONE, SERVIZIO, REGISTRO, COD_TIPO, COD_DEFINIZIONE, COD_ORGANO_ISTITUZIONALE, DATA_BUR, NUMERO_BUR, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO, DEFINIZIONE_ATTO, TIPO_ATTO, ORGANO_ISTITUZIONALE
		FROM vDECRETI_X_DOM_PAG_ESPORTAZIONE
		WHERE 
			((@IdDecretiXDomPagEsportazioneequalthis IS NULL) OR ID_DECRETI_X_DOM_PAG_ESPORTAZIONE = @IdDecretiXDomPagEsportazioneequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDecretoequalthis IS NULL) OR ID_DECRETO = @IdDecretoequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDecretiXDomPagEsportazioneFindSelect';

