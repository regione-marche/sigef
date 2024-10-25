CREATE PROCEDURE [dbo].[ZPagamentiRichiestiFemFindFind]
(
	@IdPagamentoRichiestoFemequalthis INT, 
	@IdContrattoequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdGiustificativoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PAGAMENTO_RICHIESTO_FEM, DATA_INSERIMENTO, CF_INSERIMENTO, ID_CONTRATTO, ID_INVESTIMENTO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, AMMESSO, CF_ISTRUTTORE, DATA_VALUTAZIONE, DATA_MODIFICA, CF_MODIFICA, NOTE_ISTRUTTORE, ID_DOMANDA_PAGAMENTO, ID_GIUSTIFICATIVO, ID_BANDO, ID_PROGETTO, ID_IMPRESA_CONTRATTO, IMPRESA_CONTRATTO, IMPORTO_CONTRATTO, SEGNATURA_CONTRATTO, DATA_CONTRATTO, NUMERO_GIUSTIFICATIVO, COD_TIPO_GIUSTIFICATIVO, TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, IMPONIBILE_GIUSTIFICATIVO, IVA_GIUSTIFICATIVO, DESCRIZIONE_GIUSTIFICATIVO, CF_FORNITORE_GIUSTIFICATIVO, DESCRIZIONE_FORNITORE_GIUSTIFICATIVO, IVA_NON_RECUPERABILE_GIUSTIFICATIVO, ID_FILE_GIUSTIFICATIVO, IN_INTEGRAZIONE_GIUSTIFICATIVO, ID_FILE_MODIFICATO_INTEGRAZIONE_GIUSTIFICATIVO FROM VPAGAMENTI_RICHIESTI_FEM WHERE 1=1';
	IF (@IdPagamentoRichiestoFemequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PAGAMENTO_RICHIESTO_FEM = @IdPagamentoRichiestoFemequalthis)'; set @lensql=@lensql+len(@IdPagamentoRichiestoFemequalthis);end;
	IF (@IdContrattoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTRATTO = @IdContrattoequalthis)'; set @lensql=@lensql+len(@IdContrattoequalthis);end;
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	set @sql = @sql + 'ORDER BY DATA_INSERIMENTO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPagamentoRichiestoFemequalthis INT, @IdContrattoequalthis INT, @IdInvestimentoequalthis INT, @IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdGiustificativoequalthis INT',@IdPagamentoRichiestoFemequalthis , @IdContrattoequalthis , @IdInvestimentoequalthis , @IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdGiustificativoequalthis ;
	else
		SELECT ID_PAGAMENTO_RICHIESTO_FEM, DATA_INSERIMENTO, CF_INSERIMENTO, ID_CONTRATTO, ID_INVESTIMENTO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, AMMESSO, CF_ISTRUTTORE, DATA_VALUTAZIONE, DATA_MODIFICA, CF_MODIFICA, NOTE_ISTRUTTORE, ID_DOMANDA_PAGAMENTO, ID_GIUSTIFICATIVO, ID_BANDO, ID_PROGETTO, ID_IMPRESA_CONTRATTO, IMPRESA_CONTRATTO, IMPORTO_CONTRATTO, SEGNATURA_CONTRATTO, DATA_CONTRATTO, NUMERO_GIUSTIFICATIVO, COD_TIPO_GIUSTIFICATIVO, TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, IMPONIBILE_GIUSTIFICATIVO, IVA_GIUSTIFICATIVO, DESCRIZIONE_GIUSTIFICATIVO, CF_FORNITORE_GIUSTIFICATIVO, DESCRIZIONE_FORNITORE_GIUSTIFICATIVO, IVA_NON_RECUPERABILE_GIUSTIFICATIVO, ID_FILE_GIUSTIFICATIVO, IN_INTEGRAZIONE_GIUSTIFICATIVO, ID_FILE_MODIFICATO_INTEGRAZIONE_GIUSTIFICATIVO
		FROM VPAGAMENTI_RICHIESTI_FEM
		WHERE 
			((@IdPagamentoRichiestoFemequalthis IS NULL) OR ID_PAGAMENTO_RICHIESTO_FEM = @IdPagamentoRichiestoFemequalthis) AND 
			((@IdContrattoequalthis IS NULL) OR ID_CONTRATTO = @IdContrattoequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)
		ORDER BY DATA_INSERIMENTO DESC

GO