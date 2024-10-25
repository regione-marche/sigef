CREATE PROCEDURE [dbo].[ZErroreFindFind]
(
	@IdErroreequalthis INT, 
	@IdAsseequalthis INT, 
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdLottoCertificazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ERRORE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, DATA_RILEVAZIONE, IMPRESE_BENEFICIARI, SOGGETTO_RILEVAZIONE, CERTIFICATO, ID_LOTTO_CERTIFICAZIONE, DATA_INIZIO_CERTIFICAZIONE, SPESA_AMMESSA_ERRORE, CONTRIBUTO_PUBBLICO_ERRORE, DA_RECUPERARE, RECUPERATO, AZIONE_CERTIFICAZIONE, ID_LOTTO_IMPATTATO, NOTE, DATA_FINE_CERTIFICAZIONE, ID_ASSE, ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_STATO_PROGETTO, STATO_PROGETTO FROM VERRORE WHERE 1=1';
	IF (@IdErroreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ERRORE = @IdErroreequalthis)'; set @lensql=@lensql+len(@IdErroreequalthis);end;
	IF (@IdAsseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ASSE = @IdAsseequalthis)'; set @lensql=@lensql+len(@IdAsseequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdLottoCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO_CERTIFICAZIONE = @IdLottoCertificazioneequalthis)'; set @lensql=@lensql+len(@IdLottoCertificazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdErroreequalthis INT, @IdAsseequalthis INT, @IdBandoequalthis INT, @IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdLottoCertificazioneequalthis INT',@IdErroreequalthis , @IdAsseequalthis , @IdBandoequalthis , @IdProgettoequalthis , @IdDomandaPagamentoequalthis , @IdLottoCertificazioneequalthis ;
	else
		SELECT ID_ERRORE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, DATA_RILEVAZIONE, IMPRESE_BENEFICIARI, SOGGETTO_RILEVAZIONE, CERTIFICATO, ID_LOTTO_CERTIFICAZIONE, DATA_INIZIO_CERTIFICAZIONE, SPESA_AMMESSA_ERRORE, CONTRIBUTO_PUBBLICO_ERRORE, DA_RECUPERARE, RECUPERATO, AZIONE_CERTIFICAZIONE, ID_LOTTO_IMPATTATO, NOTE, DATA_FINE_CERTIFICAZIONE, ID_ASSE, ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_STATO_PROGETTO, STATO_PROGETTO
		FROM VERRORE
		WHERE 
			((@IdErroreequalthis IS NULL) OR ID_ERRORE = @IdErroreequalthis) AND 
			((@IdAsseequalthis IS NULL) OR ID_ASSE = @IdAsseequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdLottoCertificazioneequalthis IS NULL) OR ID_LOTTO_CERTIFICAZIONE = @IdLottoCertificazioneequalthis)
		

GO