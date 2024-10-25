CREATE PROCEDURE [dbo].[ZSpeseSostenuteFindSelect]
(
	@IdSpesaequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdGiustificativoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Estremiequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Importoequalthis DECIMAL(18,2), 
	@Nettoequalthis DECIMAL(18,2), 
	@Ammessoequalthis BIT, 
	@DataApprovazioneequalthis DATETIME, 
	@OperatoreApprovazioneequalthis INT, 
	@IdFileequalthis INT, 
	@InIntegrazioneequalthis BIT, 
	@IdFileModificatoIntegrazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SPESA, ID_GIUSTIFICATIVO, COD_TIPO, ESTREMI, DATA, IMPORTO, NETTO, TIPO_PAGAMENTO, ID_PROGETTO, NUMERO, COD_TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, ID_DOMANDA_PAGAMENTO, IVA_NON_RECUPERABILE, DOMANDA_PAGAMENTO_ANNULLATA, DOMANDA_PAGAMENTO_APPROVATA, AMMESSO, DATA_APPROVAZIONE, OPERATORE_APPROVAZIONE, ID_FILE, ID_FILE_GIUSTIFICATIVO, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE FROM vSPESE_SOSTENUTE WHERE 1=1';
	IF (@IdSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPESA = @IdSpesaequalthis)'; set @lensql=@lensql+len(@IdSpesaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Estremiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESTREMI = @Estremiequalthis)'; set @lensql=@lensql+len(@Estremiequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO = @Importoequalthis)'; set @lensql=@lensql+len(@Importoequalthis);end;
	IF (@Nettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NETTO = @Nettoequalthis)'; set @lensql=@lensql+len(@Nettoequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMESSO = @Ammessoequalthis)'; set @lensql=@lensql+len(@Ammessoequalthis);end;
	IF (@DataApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_APPROVAZIONE = @DataApprovazioneequalthis)'; set @lensql=@lensql+len(@DataApprovazioneequalthis);end;
	IF (@OperatoreApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_APPROVAZIONE = @OperatoreApprovazioneequalthis)'; set @lensql=@lensql+len(@OperatoreApprovazioneequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	IF (@IdFileModificatoIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazioneequalthis)'; set @lensql=@lensql+len(@IdFileModificatoIntegrazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSpesaequalthis INT, @IdDomandaPagamentoequalthis INT, @IdGiustificativoequalthis INT, @CodTipoequalthis VARCHAR(255), @Estremiequalthis VARCHAR(255), @Dataequalthis DATETIME, @Importoequalthis DECIMAL(18,2), @Nettoequalthis DECIMAL(18,2), @Ammessoequalthis BIT, @DataApprovazioneequalthis DATETIME, @OperatoreApprovazioneequalthis INT, @IdFileequalthis INT, @InIntegrazioneequalthis BIT, @IdFileModificatoIntegrazioneequalthis BIT',@IdSpesaequalthis , @IdDomandaPagamentoequalthis , @IdGiustificativoequalthis , @CodTipoequalthis , @Estremiequalthis , @Dataequalthis , @Importoequalthis , @Nettoequalthis , @Ammessoequalthis , @DataApprovazioneequalthis , @OperatoreApprovazioneequalthis , @IdFileequalthis , @InIntegrazioneequalthis , @IdFileModificatoIntegrazioneequalthis ;
	else
		SELECT ID_SPESA, ID_GIUSTIFICATIVO, COD_TIPO, ESTREMI, DATA, IMPORTO, NETTO, TIPO_PAGAMENTO, ID_PROGETTO, NUMERO, COD_TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, ID_DOMANDA_PAGAMENTO, IVA_NON_RECUPERABILE, DOMANDA_PAGAMENTO_ANNULLATA, DOMANDA_PAGAMENTO_APPROVATA, AMMESSO, DATA_APPROVAZIONE, OPERATORE_APPROVAZIONE, ID_FILE, ID_FILE_GIUSTIFICATIVO, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE
		FROM vSPESE_SOSTENUTE
		WHERE 
			((@IdSpesaequalthis IS NULL) OR ID_SPESA = @IdSpesaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Estremiequalthis IS NULL) OR ESTREMI = @Estremiequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis) AND 
			((@Nettoequalthis IS NULL) OR NETTO = @Nettoequalthis) AND 
			((@Ammessoequalthis IS NULL) OR AMMESSO = @Ammessoequalthis) AND 
			((@DataApprovazioneequalthis IS NULL) OR DATA_APPROVAZIONE = @DataApprovazioneequalthis) AND 
			((@OperatoreApprovazioneequalthis IS NULL) OR OPERATORE_APPROVAZIONE = @OperatoreApprovazioneequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis) AND 
			((@IdFileModificatoIntegrazioneequalthis IS NULL) OR ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteFindSelect';

