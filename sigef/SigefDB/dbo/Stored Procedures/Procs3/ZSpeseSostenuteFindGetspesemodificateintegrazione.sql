CREATE PROCEDURE [dbo].[ZSpeseSostenuteFindGetspesemodificateintegrazione]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdGiustificativoequalthis INT, 
	@IdProgettoequalthis INT, 
	@InIntegrazioneequalthis BIT, 
	@IdFileModificatoIntegrazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SPESA, ID_GIUSTIFICATIVO, COD_TIPO, ESTREMI, DATA, IMPORTO, NETTO, TIPO_PAGAMENTO, ID_PROGETTO, NUMERO, COD_TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, ID_DOMANDA_PAGAMENTO, IVA_NON_RECUPERABILE, DOMANDA_PAGAMENTO_ANNULLATA, DOMANDA_PAGAMENTO_APPROVATA, AMMESSO, DATA_APPROVAZIONE, OPERATORE_APPROVAZIONE, ID_FILE, ID_FILE_GIUSTIFICATIVO, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE FROM vSPESE_SOSTENUTE WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	IF (@IdFileModificatoIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazioneequalthis)'; set @lensql=@lensql+len(@IdFileModificatoIntegrazioneequalthis);end;
	set @sql = @sql + 'ORDER BY ID_GIUSTIFICATIVO, ID_SPESA';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @IdGiustificativoequalthis INT, @IdProgettoequalthis INT, @InIntegrazioneequalthis BIT, @IdFileModificatoIntegrazioneequalthis BIT',@IdDomandaPagamentoequalthis , @IdGiustificativoequalthis , @IdProgettoequalthis , @InIntegrazioneequalthis , @IdFileModificatoIntegrazioneequalthis ;
	else
		SELECT ID_SPESA, ID_GIUSTIFICATIVO, COD_TIPO, ESTREMI, DATA, IMPORTO, NETTO, TIPO_PAGAMENTO, ID_PROGETTO, NUMERO, COD_TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, ID_DOMANDA_PAGAMENTO, IVA_NON_RECUPERABILE, DOMANDA_PAGAMENTO_ANNULLATA, DOMANDA_PAGAMENTO_APPROVATA, AMMESSO, DATA_APPROVAZIONE, OPERATORE_APPROVAZIONE, ID_FILE, ID_FILE_GIUSTIFICATIVO, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE
		FROM vSPESE_SOSTENUTE
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis) AND 
			((@IdFileModificatoIntegrazioneequalthis IS NULL) OR ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazioneequalthis)
		ORDER BY ID_GIUSTIFICATIVO, ID_SPESA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteFindGetspesemodificateintegrazione';

