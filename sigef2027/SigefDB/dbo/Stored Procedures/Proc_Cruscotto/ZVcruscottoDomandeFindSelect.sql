CREATE PROCEDURE [dbo].[ZVcruscottoDomandeFindSelect]
(
	@IdBandoequalthis INT, 
	@DescrizioneBandoequalthis VARCHAR(2000), 
	@CodEnteBandoequalthis VARCHAR(255), 
	@CodStatoProgettoequalthis VARCHAR(255), 
	@DataScadenzaBandoequalthis DATETIME, 
	@IdProgettoequalthis INT, 
	@Statoequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@Impresaequalthis VARCHAR(255), 
	@IdDomandaPagamentoequalthis INT, 
	@SegnaturaDomandaPagamentoequalthis VARCHAR(255), 
	@FaseDomandaPagamentoequalthis VARCHAR(255), 
	@Annullataequalthis BIT, 
	@Approvataequalthis BIT, 
	@SelezionataXRevisioneequalthis BIT, 
	@ApprovataRevisioneequalthis BIT, 
	@SegnaturaSecondaApprovazioneequalthis VARCHAR(255), 
	@IdUtenteRupequalthis INT, 
	@Rupequalthis VARCHAR(511), 
	@IdUtenteIstruttoreequalthis INT, 
	@Istruttoreequalthis VARCHAR(511), 
	@ImportoRichiestoequalthis DECIMAL(38,2), 
	@ContributoRichiestoequalthis DECIMAL(38,2), 
	@ImportoAmmessoequalthis DECIMAL(38,2), 
	@ContributoAmmessoequalthis DECIMAL(38,2), 
	@InIntegrazioneequalthis BIT, 
	@FirmaPredispostaRupequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, COD_ENTE_BANDO, COD_STATO_PROGETTO, DATA_SCADENZA_BANDO, ID_PROGETTO, STATO, ID_IMPRESA, IMPRESA, ID_DOMANDA_PAGAMENTO, SEGNATURA_DOMANDA_PAGAMENTO, FASE_DOMANDA_PAGAMENTO, ANNULLATA, APPROVATA, SELEZIONATA_X_REVISIONE, APPROVATA_REVISIONE, SEGNATURA_SECONDA_APPROVAZIONE, ID_UTENTE_RUP, RUP, ID_UTENTE_ISTRUTTORE, ISTRUTTORE, IMPORTO_RICHIESTO, CONTRIBUTO_RICHIESTO, IMPORTO_AMMESSO, CONTRIBUTO_AMMESSO, IN_INTEGRAZIONE, FIRMA_PREDISPOSTA_RUP FROM VCRUSCOTTO_DOMANDE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@DescrizioneBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_BANDO = @DescrizioneBandoequalthis)'; set @lensql=@lensql+len(@DescrizioneBandoequalthis);end;
	IF (@CodEnteBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_BANDO = @CodEnteBandoequalthis)'; set @lensql=@lensql+len(@CodEnteBandoequalthis);end;
	IF (@CodStatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO_PROGETTO = @CodStatoProgettoequalthis)'; set @lensql=@lensql+len(@CodStatoProgettoequalthis);end;
	IF (@DataScadenzaBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA_BANDO = @DataScadenzaBandoequalthis)'; set @lensql=@lensql+len(@DataScadenzaBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Statoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO = @Statoequalthis)'; set @lensql=@lensql+len(@Statoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Impresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPRESA = @Impresaequalthis)'; set @lensql=@lensql+len(@Impresaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@SegnaturaDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_DOMANDA_PAGAMENTO = @SegnaturaDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@SegnaturaDomandaPagamentoequalthis);end;
	IF (@FaseDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FASE_DOMANDA_PAGAMENTO = @FaseDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@FaseDomandaPagamentoequalthis);end;
	IF (@Annullataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATA = @Annullataequalthis)'; set @lensql=@lensql+len(@Annullataequalthis);end;
	IF (@Approvataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (APPROVATA = @Approvataequalthis)'; set @lensql=@lensql+len(@Approvataequalthis);end;
	IF (@SelezionataXRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis)'; set @lensql=@lensql+len(@SelezionataXRevisioneequalthis);end;
	IF (@ApprovataRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (APPROVATA_REVISIONE = @ApprovataRevisioneequalthis)'; set @lensql=@lensql+len(@ApprovataRevisioneequalthis);end;
	IF (@SegnaturaSecondaApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_SECONDA_APPROVAZIONE = @SegnaturaSecondaApprovazioneequalthis)'; set @lensql=@lensql+len(@SegnaturaSecondaApprovazioneequalthis);end;
	IF (@IdUtenteRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_RUP = @IdUtenteRupequalthis)'; set @lensql=@lensql+len(@IdUtenteRupequalthis);end;
	IF (@Rupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RUP = @Rupequalthis)'; set @lensql=@lensql+len(@Rupequalthis);end;
	IF (@IdUtenteIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_ISTRUTTORE = @IdUtenteIstruttoreequalthis)'; set @lensql=@lensql+len(@IdUtenteIstruttoreequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE = @Istruttoreequalthis)'; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	IF (@ImportoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RICHIESTO = @ImportoRichiestoequalthis)'; set @lensql=@lensql+len(@ImportoRichiestoequalthis);end;
	IF (@ContributoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_RICHIESTO = @ContributoRichiestoequalthis)'; set @lensql=@lensql+len(@ContributoRichiestoequalthis);end;
	IF (@ImportoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_AMMESSO = @ImportoAmmessoequalthis)'; set @lensql=@lensql+len(@ImportoAmmessoequalthis);end;
	IF (@ContributoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_AMMESSO = @ContributoAmmessoequalthis)'; set @lensql=@lensql+len(@ContributoAmmessoequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	IF (@FirmaPredispostaRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FIRMA_PREDISPOSTA_RUP = @FirmaPredispostaRupequalthis)'; set @lensql=@lensql+len(@FirmaPredispostaRupequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @DescrizioneBandoequalthis VARCHAR(2000), @CodEnteBandoequalthis VARCHAR(255), @CodStatoProgettoequalthis VARCHAR(255), @DataScadenzaBandoequalthis DATETIME, @IdProgettoequalthis INT, @Statoequalthis VARCHAR(255), @IdImpresaequalthis INT, @Impresaequalthis VARCHAR(255), @IdDomandaPagamentoequalthis INT, @SegnaturaDomandaPagamentoequalthis VARCHAR(255), @FaseDomandaPagamentoequalthis VARCHAR(255), @Annullataequalthis BIT, @Approvataequalthis BIT, @SelezionataXRevisioneequalthis BIT, @ApprovataRevisioneequalthis BIT, @SegnaturaSecondaApprovazioneequalthis VARCHAR(255), @IdUtenteRupequalthis INT, @Rupequalthis VARCHAR(511), @IdUtenteIstruttoreequalthis INT, @Istruttoreequalthis VARCHAR(511), @ImportoRichiestoequalthis DECIMAL(38,2), @ContributoRichiestoequalthis DECIMAL(38,2), @ImportoAmmessoequalthis DECIMAL(38,2), @ContributoAmmessoequalthis DECIMAL(38,2), @InIntegrazioneequalthis BIT, @FirmaPredispostaRupequalthis BIT',@IdBandoequalthis , @DescrizioneBandoequalthis , @CodEnteBandoequalthis , @CodStatoProgettoequalthis , @DataScadenzaBandoequalthis , @IdProgettoequalthis , @Statoequalthis , @IdImpresaequalthis , @Impresaequalthis , @IdDomandaPagamentoequalthis , @SegnaturaDomandaPagamentoequalthis , @FaseDomandaPagamentoequalthis , @Annullataequalthis , @Approvataequalthis , @SelezionataXRevisioneequalthis , @ApprovataRevisioneequalthis , @SegnaturaSecondaApprovazioneequalthis , @IdUtenteRupequalthis , @Rupequalthis , @IdUtenteIstruttoreequalthis , @Istruttoreequalthis , @ImportoRichiestoequalthis , @ContributoRichiestoequalthis , @ImportoAmmessoequalthis , @ContributoAmmessoequalthis , @InIntegrazioneequalthis , @FirmaPredispostaRupequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, COD_ENTE_BANDO, COD_STATO_PROGETTO, DATA_SCADENZA_BANDO, ID_PROGETTO, STATO, ID_IMPRESA, IMPRESA, ID_DOMANDA_PAGAMENTO, SEGNATURA_DOMANDA_PAGAMENTO, FASE_DOMANDA_PAGAMENTO, ANNULLATA, APPROVATA, SELEZIONATA_X_REVISIONE, APPROVATA_REVISIONE, SEGNATURA_SECONDA_APPROVAZIONE, ID_UTENTE_RUP, RUP, ID_UTENTE_ISTRUTTORE, ISTRUTTORE, IMPORTO_RICHIESTO, CONTRIBUTO_RICHIESTO, IMPORTO_AMMESSO, CONTRIBUTO_AMMESSO, IN_INTEGRAZIONE, FIRMA_PREDISPOSTA_RUP
		FROM VCRUSCOTTO_DOMANDE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@DescrizioneBandoequalthis IS NULL) OR DESCRIZIONE_BANDO = @DescrizioneBandoequalthis) AND 
			((@CodEnteBandoequalthis IS NULL) OR COD_ENTE_BANDO = @CodEnteBandoequalthis) AND 
			((@CodStatoProgettoequalthis IS NULL) OR COD_STATO_PROGETTO = @CodStatoProgettoequalthis) AND 
			((@DataScadenzaBandoequalthis IS NULL) OR DATA_SCADENZA_BANDO = @DataScadenzaBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Statoequalthis IS NULL) OR STATO = @Statoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Impresaequalthis IS NULL) OR IMPRESA = @Impresaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@SegnaturaDomandaPagamentoequalthis IS NULL) OR SEGNATURA_DOMANDA_PAGAMENTO = @SegnaturaDomandaPagamentoequalthis) AND 
			((@FaseDomandaPagamentoequalthis IS NULL) OR FASE_DOMANDA_PAGAMENTO = @FaseDomandaPagamentoequalthis) AND 
			((@Annullataequalthis IS NULL) OR ANNULLATA = @Annullataequalthis) AND 
			((@Approvataequalthis IS NULL) OR APPROVATA = @Approvataequalthis) AND 
			((@SelezionataXRevisioneequalthis IS NULL) OR SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis) AND 
			((@ApprovataRevisioneequalthis IS NULL) OR APPROVATA_REVISIONE = @ApprovataRevisioneequalthis) AND 
			((@SegnaturaSecondaApprovazioneequalthis IS NULL) OR SEGNATURA_SECONDA_APPROVAZIONE = @SegnaturaSecondaApprovazioneequalthis) AND 
			((@IdUtenteRupequalthis IS NULL) OR ID_UTENTE_RUP = @IdUtenteRupequalthis) AND 
			((@Rupequalthis IS NULL) OR RUP = @Rupequalthis) AND 
			((@IdUtenteIstruttoreequalthis IS NULL) OR ID_UTENTE_ISTRUTTORE = @IdUtenteIstruttoreequalthis) AND 
			((@Istruttoreequalthis IS NULL) OR ISTRUTTORE = @Istruttoreequalthis) AND 
			((@ImportoRichiestoequalthis IS NULL) OR IMPORTO_RICHIESTO = @ImportoRichiestoequalthis) AND 
			((@ContributoRichiestoequalthis IS NULL) OR CONTRIBUTO_RICHIESTO = @ContributoRichiestoequalthis) AND 
			((@ImportoAmmessoequalthis IS NULL) OR IMPORTO_AMMESSO = @ImportoAmmessoequalthis) AND 
			((@ContributoAmmessoequalthis IS NULL) OR CONTRIBUTO_AMMESSO = @ContributoAmmessoequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis) AND 
			((@FirmaPredispostaRupequalthis IS NULL) OR FIRMA_PREDISPOSTA_RUP = @FirmaPredispostaRupequalthis)
		

GO