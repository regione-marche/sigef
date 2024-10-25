CREATE PROCEDURE [dbo].[ZSpesaIrregolareFindFind]
(
	@IdSpesaIrregolareequalthis INT, 
	@IdIrregolaritaequalthis INT, 
	@IdSpesaequalthis INT, 
	@IdGiustificativoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdLottoCertificazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SPESA_IRREGOLARE, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, ID_IRREGOLARITA, ID_SPESA, IMPORTO_IRREGOLARE, ID_GIUSTIFICATIVO, COD_TIPO_SPESA, ESTREMI_SPESA, DATA_SPESA, IMPORTO_SPESA, NETTO_SPESA, TIPO_SPESA, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOMANDA, TIPO_DOMANDA, ID_PROGETTO, NUMERO_GIUSTIFICATIVO, COD_TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, NUMERO_DOCTRASPORTO_GIUSTIFICATIVO, IMPONIBILE_GIUSTIFICATIVO, IVA_GIUSTIFICATIVO, IVA_NON_RECUPERABILE_GIUSTIFICATIVO, DESCRIZIONE_GIUSTIFICATIVO, CF_FORNITORE_GIUSTIFICATIVO, DESCRIZIONE_FORNITORE_GIUSTIFICATIVO, TIPO_GIUSTIFICATIVO, ID_LOTTO_CERTIFICAZIONE, COD_PSR_CERTIFICAZIONE, DATA_INIZIO_LOTTO_CERTIFICAZIONE, DATA_FINE_LOTTO_CERTIFICAZIONE FROM VSPESA_IRREGOLARE WHERE 1=1';
	IF (@IdSpesaIrregolareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPESA_IRREGOLARE = @IdSpesaIrregolareequalthis)'; set @lensql=@lensql+len(@IdSpesaIrregolareequalthis);end;
	IF (@IdIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IRREGOLARITA = @IdIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdIrregolaritaequalthis);end;
	IF (@IdSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPESA = @IdSpesaequalthis)'; set @lensql=@lensql+len(@IdSpesaequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdLottoCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO_CERTIFICAZIONE = @IdLottoCertificazioneequalthis)'; set @lensql=@lensql+len(@IdLottoCertificazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSpesaIrregolareequalthis INT, @IdIrregolaritaequalthis INT, @IdSpesaequalthis INT, @IdGiustificativoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT, @IdLottoCertificazioneequalthis INT',@IdSpesaIrregolareequalthis , @IdIrregolaritaequalthis , @IdSpesaequalthis , @IdGiustificativoequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis , @IdLottoCertificazioneequalthis ;
	else
		SELECT ID_SPESA_IRREGOLARE, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, ID_IRREGOLARITA, ID_SPESA, IMPORTO_IRREGOLARE, ID_GIUSTIFICATIVO, COD_TIPO_SPESA, ESTREMI_SPESA, DATA_SPESA, IMPORTO_SPESA, NETTO_SPESA, TIPO_SPESA, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOMANDA, TIPO_DOMANDA, ID_PROGETTO, NUMERO_GIUSTIFICATIVO, COD_TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, NUMERO_DOCTRASPORTO_GIUSTIFICATIVO, IMPONIBILE_GIUSTIFICATIVO, IVA_GIUSTIFICATIVO, IVA_NON_RECUPERABILE_GIUSTIFICATIVO, DESCRIZIONE_GIUSTIFICATIVO, CF_FORNITORE_GIUSTIFICATIVO, DESCRIZIONE_FORNITORE_GIUSTIFICATIVO, TIPO_GIUSTIFICATIVO, ID_LOTTO_CERTIFICAZIONE, COD_PSR_CERTIFICAZIONE, DATA_INIZIO_LOTTO_CERTIFICAZIONE, DATA_FINE_LOTTO_CERTIFICAZIONE
		FROM VSPESA_IRREGOLARE
		WHERE 
			((@IdSpesaIrregolareequalthis IS NULL) OR ID_SPESA_IRREGOLARE = @IdSpesaIrregolareequalthis) AND 
			((@IdIrregolaritaequalthis IS NULL) OR ID_IRREGOLARITA = @IdIrregolaritaequalthis) AND 
			((@IdSpesaequalthis IS NULL) OR ID_SPESA = @IdSpesaequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdLottoCertificazioneequalthis IS NULL) OR ID_LOTTO_CERTIFICAZIONE = @IdLottoCertificazioneequalthis)
		

GO