CREATE PROCEDURE [dbo].[ZContrattiFemPagamentiFindFind]
(
	@IdContrattoFemPagamentiequalthis INT, 
	@IdContrattoFemequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdDomandaPagamentoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_PROGETTO_CONTRATTO, DATA_STIPULA_CONTRATTO, SEGNATURA_CONTRATTO, IMPORTO_CONTRATTO, ID_IMPRESA_CONTRATTO, ID_CONTRATTO_FEM_PAGAMENTI, ID_CONTRATTO_FEM, ID_PROGETTO, COD_TIPO, ESTREMI, DATA, IMPORTO, ID_FILE, DATA_CREAZIONE, OPERATORE_CREAZIONE, DATA_AGGIORNAMENTO, OPERATORE_AGGIORNAMENTO, ID_IMPRESA, ID_DOMANDA_PAGAMENTO, IMPRESA_PAGAMENTO, CODICE_FISCALE_IMPRESA_PAGAMENTO, CUAA_IMPRESA_PAGAMENTO, TIPO_PAGAMENTO FROM VCONTRATTI_FEM_PAGAMENTI WHERE 1=1';
	IF (@IdContrattoFemPagamentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTRATTO_FEM_PAGAMENTI = @IdContrattoFemPagamentiequalthis)'; set @lensql=@lensql+len(@IdContrattoFemPagamentiequalthis);end;
	IF (@IdContrattoFemequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTRATTO_FEM = @IdContrattoFemequalthis)'; set @lensql=@lensql+len(@IdContrattoFemequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdContrattoFemPagamentiequalthis INT, @IdContrattoFemequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT, @IdDomandaPagamentoequalthis INT',@IdContrattoFemPagamentiequalthis , @IdContrattoFemequalthis , @IdProgettoequalthis , @IdImpresaequalthis , @IdDomandaPagamentoequalthis ;
	else
		SELECT ID_BANDO, ID_PROGETTO_CONTRATTO, DATA_STIPULA_CONTRATTO, SEGNATURA_CONTRATTO, IMPORTO_CONTRATTO, ID_IMPRESA_CONTRATTO, ID_CONTRATTO_FEM_PAGAMENTI, ID_CONTRATTO_FEM, ID_PROGETTO, COD_TIPO, ESTREMI, DATA, IMPORTO, ID_FILE, DATA_CREAZIONE, OPERATORE_CREAZIONE, DATA_AGGIORNAMENTO, OPERATORE_AGGIORNAMENTO, ID_IMPRESA, ID_DOMANDA_PAGAMENTO, IMPRESA_PAGAMENTO, CODICE_FISCALE_IMPRESA_PAGAMENTO, CUAA_IMPRESA_PAGAMENTO, TIPO_PAGAMENTO
		FROM VCONTRATTI_FEM_PAGAMENTI
		WHERE 
			((@IdContrattoFemPagamentiequalthis IS NULL) OR ID_CONTRATTO_FEM_PAGAMENTI = @IdContrattoFemPagamentiequalthis) AND 
			((@IdContrattoFemequalthis IS NULL) OR ID_CONTRATTO_FEM = @IdContrattoFemequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)
		

GO