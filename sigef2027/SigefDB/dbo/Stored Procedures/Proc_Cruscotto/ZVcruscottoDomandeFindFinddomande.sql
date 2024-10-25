CREATE PROCEDURE [dbo].[ZVcruscottoDomandeFindFinddomande]
(
	@IdUtenteRupequalthis INT, 
	@FirmaPredispostaRupequalthis BIT, 
	@IdUtenteIstruttoreequalthis INT, 
	@CodEnteBandoequalthis VARCHAR(255), 
	@CodStatoProgettoequalthis VARCHAR(255), 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, COD_ENTE_BANDO, COD_STATO_PROGETTO, DATA_SCADENZA_BANDO, ID_PROGETTO, STATO, ID_IMPRESA, IMPRESA, ID_DOMANDA_PAGAMENTO, SEGNATURA_DOMANDA_PAGAMENTO, FASE_DOMANDA_PAGAMENTO, ANNULLATA, APPROVATA, SELEZIONATA_X_REVISIONE, APPROVATA_REVISIONE, SEGNATURA_SECONDA_APPROVAZIONE, ID_UTENTE_RUP, RUP, ID_UTENTE_ISTRUTTORE, ISTRUTTORE, IMPORTO_RICHIESTO, CONTRIBUTO_RICHIESTO, IMPORTO_AMMESSO, CONTRIBUTO_AMMESSO, IN_INTEGRAZIONE, FIRMA_PREDISPOSTA_RUP FROM VCRUSCOTTO_DOMANDE WHERE 1=1';
	IF (@IdUtenteRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_RUP = @IdUtenteRupequalthis)'; set @lensql=@lensql+len(@IdUtenteRupequalthis);end;
	IF (@FirmaPredispostaRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FIRMA_PREDISPOSTA_RUP = @FirmaPredispostaRupequalthis)'; set @lensql=@lensql+len(@FirmaPredispostaRupequalthis);end;
	IF (@IdUtenteIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_ISTRUTTORE = @IdUtenteIstruttoreequalthis)'; set @lensql=@lensql+len(@IdUtenteIstruttoreequalthis);end;
	IF (@CodEnteBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_BANDO = @CodEnteBandoequalthis)'; set @lensql=@lensql+len(@CodEnteBandoequalthis);end;
	IF (@CodStatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO_PROGETTO = @CodStatoProgettoequalthis)'; set @lensql=@lensql+len(@CodStatoProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	set @sql = @sql + 'ORDER BY DATA_SCADENZA_BANDO ASC, ID_PROGETTO ASC, ID_DOMANDA_PAGAMENTO ASC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdUtenteRupequalthis INT, @FirmaPredispostaRupequalthis BIT, @IdUtenteIstruttoreequalthis INT, @CodEnteBandoequalthis VARCHAR(255), @CodStatoProgettoequalthis VARCHAR(255), @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT',@IdUtenteRupequalthis , @FirmaPredispostaRupequalthis , @IdUtenteIstruttoreequalthis , @CodEnteBandoequalthis , @CodStatoProgettoequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, COD_ENTE_BANDO, COD_STATO_PROGETTO, DATA_SCADENZA_BANDO, ID_PROGETTO, STATO, ID_IMPRESA, IMPRESA, ID_DOMANDA_PAGAMENTO, SEGNATURA_DOMANDA_PAGAMENTO, FASE_DOMANDA_PAGAMENTO, ANNULLATA, APPROVATA, SELEZIONATA_X_REVISIONE, APPROVATA_REVISIONE, SEGNATURA_SECONDA_APPROVAZIONE, ID_UTENTE_RUP, RUP, ID_UTENTE_ISTRUTTORE, ISTRUTTORE, IMPORTO_RICHIESTO, CONTRIBUTO_RICHIESTO, IMPORTO_AMMESSO, CONTRIBUTO_AMMESSO, IN_INTEGRAZIONE, FIRMA_PREDISPOSTA_RUP
		FROM VCRUSCOTTO_DOMANDE
		WHERE 
			((@IdUtenteRupequalthis IS NULL) OR ID_UTENTE_RUP = @IdUtenteRupequalthis) AND 
			((@FirmaPredispostaRupequalthis IS NULL) OR FIRMA_PREDISPOSTA_RUP = @FirmaPredispostaRupequalthis) AND 
			((@IdUtenteIstruttoreequalthis IS NULL) OR ID_UTENTE_ISTRUTTORE = @IdUtenteIstruttoreequalthis) AND 
			((@CodEnteBandoequalthis IS NULL) OR COD_ENTE_BANDO = @CodEnteBandoequalthis) AND 
			((@CodStatoProgettoequalthis IS NULL) OR COD_STATO_PROGETTO = @CodStatoProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis)
		ORDER BY DATA_SCADENZA_BANDO ASC, ID_PROGETTO ASC, ID_DOMANDA_PAGAMENTO ASC

GO