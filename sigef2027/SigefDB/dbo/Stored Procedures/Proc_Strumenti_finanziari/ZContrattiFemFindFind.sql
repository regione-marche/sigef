CREATE PROCEDURE [dbo].[ZContrattiFemFindFind]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdDomandaPagamentoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CONTRATTO_FEM, ID_BANDO, ID_PROGETTO, DATA_STIPULA_CONTRATTO, SEGNATURA, DATA_SEGNATURA, IMPORTO, DATA_CREAZIONE, DATA_AGGIORNAMENTO, OPERATORE_CREAZIONE, OPERATORE_AGGIORNAMENTO, ID_IMPRESA, ID_DOMANDA_PAGAMENTO, NUMERO, ID_FILE, DESCRIZIONE, ID_PROGETTO_RIF, IMPRESA, CODICE_FISCALE_IMPRESA, CUAA_IMPRESA FROM VCONTRATTI_FEM WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT, @IdDomandaPagamentoequalthis INT',@IdBandoequalthis , @IdProgettoequalthis , @IdImpresaequalthis , @IdDomandaPagamentoequalthis ;
	else
		SELECT ID_CONTRATTO_FEM, ID_BANDO, ID_PROGETTO, DATA_STIPULA_CONTRATTO, SEGNATURA, DATA_SEGNATURA, IMPORTO, DATA_CREAZIONE, DATA_AGGIORNAMENTO, OPERATORE_CREAZIONE, OPERATORE_AGGIORNAMENTO, ID_IMPRESA, ID_DOMANDA_PAGAMENTO, NUMERO, ID_FILE, DESCRIZIONE, ID_PROGETTO_RIF, IMPRESA, CODICE_FISCALE_IMPRESA, CUAA_IMPRESA
		FROM VCONTRATTI_FEM
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)
		

GO