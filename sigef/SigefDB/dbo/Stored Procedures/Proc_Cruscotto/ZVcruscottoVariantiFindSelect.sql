CREATE PROCEDURE [dbo].[ZVcruscottoVariantiFindSelect]
(
	@IdBandoequalthis INT, 
	@DescrizioneBandoequalthis VARCHAR(2000), 
	@DataScadenzaBandoequalthis DATETIME, 
	@IdProgettoequalthis INT, 
	@Statoequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@Impresaequalthis VARCHAR(255), 
	@IdVarianteequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CodEnteequalthis VARCHAR(255), 
	@Segnaturaequalthis VARCHAR(255), 
	@SegnaturaAllegatiequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@SegnaturaApprovazioneequalthis VARCHAR(255), 
	@Approvataequalthis BIT, 
	@IdUtenteIstruttoreequalthis INT, 
	@Istruttoreequalthis VARCHAR(255), 
	@TipoVarianteequalthis VARCHAR(255), 
	@Nominativoequalthis VARCHAR(511), 
	@Profiloequalthis VARCHAR(255), 
	@Enteequalthis VARCHAR(255), 
	@DataApprovazioneequalthis DATETIME, 
	@Provinciaequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(1000), 
	@Annullataequalthis BIT, 
	@SegnaturaAnnullamentoequalthis VARCHAR(255), 
	@CfOperatoreAnnullamentoequalthis VARCHAR(255), 
	@DataAnnullamentoequalthis DATETIME, 
	@NominativoOperatoreAnnullamentoequalthis VARCHAR(511), 
	@NominativoIstruttoreequalthis VARCHAR(511), 
	@CuaaEntranteequalthis VARCHAR(255), 
	@IdFascicoloEntranteequalthis INT, 
	@CuaaUscenteequalthis VARCHAR(255), 
	@IdFascicoloUscenteequalthis INT, 
	@RagsocUscenteequalthis VARCHAR(255), 
	@IdAttoApprovazioneequalthis INT, 
	@CodDefinizioneequalthis VARCHAR(255), 
	@IdProgettoValutazioneequalthis INT, 
	@Ordineequalthis INT, 
	@OrdineFirmaequalthis INT, 
	@IdOperatoreFirmaComitatoequalthis INT, 
	@OperatoreFirmaComitatoequalthis VARCHAR(511)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, ID_PROGETTO, STATO, ID_IMPRESA, IMPRESA, ID_VARIANTE, COD_TIPO, DATA_INSERIMENTO, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, DATA_MODIFICA, SEGNATURA_APPROVAZIONE, APPROVATA, ID_UTENTE_ISTRUTTORE, ISTRUTTORE, NOTE_ISTRUTTORE, TIPO_VARIANTE, NOMINATIVO, PROFILO, ENTE, DATA_APPROVAZIONE, PROVINCIA, DESCRIZIONE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, NOMINATIVO_OPERATORE_ANNULLAMENTO, NOMINATIVO_ISTRUTTORE, CUAA_ENTRANTE, ID_FASCICOLO_ENTRANTE, CUAA_USCENTE, ID_FASCICOLO_USCENTE, RAGSOC_USCENTE, ID_ATTO_APPROVAZIONE, COD_DEFINIZIONE, ID_PROGETTO_VALUTAZIONE, ORDINE, ORDINE_FIRMA, ID_OPERATORE_FIRMA_COMITATO, OPERATORE_FIRMA_COMITATO FROM VCRUSCOTTO_VARIANTI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@DescrizioneBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_BANDO = @DescrizioneBandoequalthis)'; set @lensql=@lensql+len(@DescrizioneBandoequalthis);end;
	IF (@DataScadenzaBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA_BANDO = @DataScadenzaBandoequalthis)'; set @lensql=@lensql+len(@DataScadenzaBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Statoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO = @Statoequalthis)'; set @lensql=@lensql+len(@Statoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Impresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPRESA = @Impresaequalthis)'; set @lensql=@lensql+len(@Impresaequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@SegnaturaAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis)'; set @lensql=@lensql+len(@SegnaturaAllegatiequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@SegnaturaApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_APPROVAZIONE = @SegnaturaApprovazioneequalthis)'; set @lensql=@lensql+len(@SegnaturaApprovazioneequalthis);end;
	IF (@Approvataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (APPROVATA = @Approvataequalthis)'; set @lensql=@lensql+len(@Approvataequalthis);end;
	IF (@IdUtenteIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_ISTRUTTORE = @IdUtenteIstruttoreequalthis)'; set @lensql=@lensql+len(@IdUtenteIstruttoreequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE = @Istruttoreequalthis)'; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	IF (@TipoVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_VARIANTE = @TipoVarianteequalthis)'; set @lensql=@lensql+len(@TipoVarianteequalthis);end;
	IF (@Nominativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOMINATIVO = @Nominativoequalthis)'; set @lensql=@lensql+len(@Nominativoequalthis);end;
	IF (@Profiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROFILO = @Profiloequalthis)'; set @lensql=@lensql+len(@Profiloequalthis);end;
	IF (@Enteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ENTE = @Enteequalthis)'; set @lensql=@lensql+len(@Enteequalthis);end;
	IF (@DataApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_APPROVAZIONE = @DataApprovazioneequalthis)'; set @lensql=@lensql+len(@DataApprovazioneequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Annullataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATA = @Annullataequalthis)'; set @lensql=@lensql+len(@Annullataequalthis);end;
	IF (@SegnaturaAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ANNULLAMENTO = @SegnaturaAnnullamentoequalthis)'; set @lensql=@lensql+len(@SegnaturaAnnullamentoequalthis);end;
	IF (@CfOperatoreAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE_ANNULLAMENTO = @CfOperatoreAnnullamentoequalthis)'; set @lensql=@lensql+len(@CfOperatoreAnnullamentoequalthis);end;
	IF (@DataAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ANNULLAMENTO = @DataAnnullamentoequalthis)'; set @lensql=@lensql+len(@DataAnnullamentoequalthis);end;
	IF (@NominativoOperatoreAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOMINATIVO_OPERATORE_ANNULLAMENTO = @NominativoOperatoreAnnullamentoequalthis)'; set @lensql=@lensql+len(@NominativoOperatoreAnnullamentoequalthis);end;
	IF (@NominativoIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOMINATIVO_ISTRUTTORE = @NominativoIstruttoreequalthis)'; set @lensql=@lensql+len(@NominativoIstruttoreequalthis);end;
	IF (@CuaaEntranteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA_ENTRANTE = @CuaaEntranteequalthis)'; set @lensql=@lensql+len(@CuaaEntranteequalthis);end;
	IF (@IdFascicoloEntranteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FASCICOLO_ENTRANTE = @IdFascicoloEntranteequalthis)'; set @lensql=@lensql+len(@IdFascicoloEntranteequalthis);end;
	IF (@CuaaUscenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA_USCENTE = @CuaaUscenteequalthis)'; set @lensql=@lensql+len(@CuaaUscenteequalthis);end;
	IF (@IdFascicoloUscenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FASCICOLO_USCENTE = @IdFascicoloUscenteequalthis)'; set @lensql=@lensql+len(@IdFascicoloUscenteequalthis);end;
	IF (@RagsocUscenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGSOC_USCENTE = @RagsocUscenteequalthis)'; set @lensql=@lensql+len(@RagsocUscenteequalthis);end;
	IF (@IdAttoApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO_APPROVAZIONE = @IdAttoApprovazioneequalthis)'; set @lensql=@lensql+len(@IdAttoApprovazioneequalthis);end;
	IF (@CodDefinizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_DEFINIZIONE = @CodDefinizioneequalthis)'; set @lensql=@lensql+len(@CodDefinizioneequalthis);end;
	IF (@IdProgettoValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazioneequalthis)'; set @lensql=@lensql+len(@IdProgettoValutazioneequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@OrdineFirmaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE_FIRMA = @OrdineFirmaequalthis)'; set @lensql=@lensql+len(@OrdineFirmaequalthis);end;
	IF (@IdOperatoreFirmaComitatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_FIRMA_COMITATO = @IdOperatoreFirmaComitatoequalthis)'; set @lensql=@lensql+len(@IdOperatoreFirmaComitatoequalthis);end;
	IF (@OperatoreFirmaComitatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_FIRMA_COMITATO = @OperatoreFirmaComitatoequalthis)'; set @lensql=@lensql+len(@OperatoreFirmaComitatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @DescrizioneBandoequalthis VARCHAR(2000), @DataScadenzaBandoequalthis DATETIME, @IdProgettoequalthis INT, @Statoequalthis VARCHAR(255), @IdImpresaequalthis INT, @Impresaequalthis VARCHAR(255), @IdVarianteequalthis INT, @CodTipoequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @CodEnteequalthis VARCHAR(255), @Segnaturaequalthis VARCHAR(255), @SegnaturaAllegatiequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @SegnaturaApprovazioneequalthis VARCHAR(255), @Approvataequalthis BIT, @IdUtenteIstruttoreequalthis INT, @Istruttoreequalthis VARCHAR(255), @TipoVarianteequalthis VARCHAR(255), @Nominativoequalthis VARCHAR(511), @Profiloequalthis VARCHAR(255), @Enteequalthis VARCHAR(255), @DataApprovazioneequalthis DATETIME, @Provinciaequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(1000), @Annullataequalthis BIT, @SegnaturaAnnullamentoequalthis VARCHAR(255), @CfOperatoreAnnullamentoequalthis VARCHAR(255), @DataAnnullamentoequalthis DATETIME, @NominativoOperatoreAnnullamentoequalthis VARCHAR(511), @NominativoIstruttoreequalthis VARCHAR(511), @CuaaEntranteequalthis VARCHAR(255), @IdFascicoloEntranteequalthis INT, @CuaaUscenteequalthis VARCHAR(255), @IdFascicoloUscenteequalthis INT, @RagsocUscenteequalthis VARCHAR(255), @IdAttoApprovazioneequalthis INT, @CodDefinizioneequalthis VARCHAR(255), @IdProgettoValutazioneequalthis INT, @Ordineequalthis INT, @OrdineFirmaequalthis INT, @IdOperatoreFirmaComitatoequalthis INT, @OperatoreFirmaComitatoequalthis VARCHAR(511)',@IdBandoequalthis , @DescrizioneBandoequalthis , @DataScadenzaBandoequalthis , @IdProgettoequalthis , @Statoequalthis , @IdImpresaequalthis , @Impresaequalthis , @IdVarianteequalthis , @CodTipoequalthis , @DataInserimentoequalthis , @CodEnteequalthis , @Segnaturaequalthis , @SegnaturaAllegatiequalthis , @DataModificaequalthis , @SegnaturaApprovazioneequalthis , @Approvataequalthis , @IdUtenteIstruttoreequalthis , @Istruttoreequalthis , @TipoVarianteequalthis , @Nominativoequalthis , @Profiloequalthis , @Enteequalthis , @DataApprovazioneequalthis , @Provinciaequalthis , @Descrizioneequalthis , @Annullataequalthis , @SegnaturaAnnullamentoequalthis , @CfOperatoreAnnullamentoequalthis , @DataAnnullamentoequalthis , @NominativoOperatoreAnnullamentoequalthis , @NominativoIstruttoreequalthis , @CuaaEntranteequalthis , @IdFascicoloEntranteequalthis , @CuaaUscenteequalthis , @IdFascicoloUscenteequalthis , @RagsocUscenteequalthis , @IdAttoApprovazioneequalthis , @CodDefinizioneequalthis , @IdProgettoValutazioneequalthis , @Ordineequalthis , @OrdineFirmaequalthis , @IdOperatoreFirmaComitatoequalthis , @OperatoreFirmaComitatoequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, ID_PROGETTO, STATO, ID_IMPRESA, IMPRESA, ID_VARIANTE, COD_TIPO, DATA_INSERIMENTO, COD_ENTE, SEGNATURA, SEGNATURA_ALLEGATI, DATA_MODIFICA, SEGNATURA_APPROVAZIONE, APPROVATA, ID_UTENTE_ISTRUTTORE, ISTRUTTORE, NOTE_ISTRUTTORE, TIPO_VARIANTE, NOMINATIVO, PROFILO, ENTE, DATA_APPROVAZIONE, PROVINCIA, DESCRIZIONE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, NOMINATIVO_OPERATORE_ANNULLAMENTO, NOMINATIVO_ISTRUTTORE, CUAA_ENTRANTE, ID_FASCICOLO_ENTRANTE, CUAA_USCENTE, ID_FASCICOLO_USCENTE, RAGSOC_USCENTE, ID_ATTO_APPROVAZIONE, COD_DEFINIZIONE, ID_PROGETTO_VALUTAZIONE, ORDINE, ORDINE_FIRMA, ID_OPERATORE_FIRMA_COMITATO, OPERATORE_FIRMA_COMITATO
		FROM VCRUSCOTTO_VARIANTI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@DescrizioneBandoequalthis IS NULL) OR DESCRIZIONE_BANDO = @DescrizioneBandoequalthis) AND 
			((@DataScadenzaBandoequalthis IS NULL) OR DATA_SCADENZA_BANDO = @DataScadenzaBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Statoequalthis IS NULL) OR STATO = @Statoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Impresaequalthis IS NULL) OR IMPRESA = @Impresaequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@SegnaturaAllegatiequalthis IS NULL) OR SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@SegnaturaApprovazioneequalthis IS NULL) OR SEGNATURA_APPROVAZIONE = @SegnaturaApprovazioneequalthis) AND 
			((@Approvataequalthis IS NULL) OR APPROVATA = @Approvataequalthis) AND 
			((@IdUtenteIstruttoreequalthis IS NULL) OR ID_UTENTE_ISTRUTTORE = @IdUtenteIstruttoreequalthis) AND 
			((@Istruttoreequalthis IS NULL) OR ISTRUTTORE = @Istruttoreequalthis) AND 
			((@TipoVarianteequalthis IS NULL) OR TIPO_VARIANTE = @TipoVarianteequalthis) AND 
			((@Nominativoequalthis IS NULL) OR NOMINATIVO = @Nominativoequalthis) AND 
			((@Profiloequalthis IS NULL) OR PROFILO = @Profiloequalthis) AND 
			((@Enteequalthis IS NULL) OR ENTE = @Enteequalthis) AND 
			((@DataApprovazioneequalthis IS NULL) OR DATA_APPROVAZIONE = @DataApprovazioneequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Annullataequalthis IS NULL) OR ANNULLATA = @Annullataequalthis) AND 
			((@SegnaturaAnnullamentoequalthis IS NULL) OR SEGNATURA_ANNULLAMENTO = @SegnaturaAnnullamentoequalthis) AND 
			((@CfOperatoreAnnullamentoequalthis IS NULL) OR CF_OPERATORE_ANNULLAMENTO = @CfOperatoreAnnullamentoequalthis) AND 
			((@DataAnnullamentoequalthis IS NULL) OR DATA_ANNULLAMENTO = @DataAnnullamentoequalthis) AND 
			((@NominativoOperatoreAnnullamentoequalthis IS NULL) OR NOMINATIVO_OPERATORE_ANNULLAMENTO = @NominativoOperatoreAnnullamentoequalthis) AND 
			((@NominativoIstruttoreequalthis IS NULL) OR NOMINATIVO_ISTRUTTORE = @NominativoIstruttoreequalthis) AND 
			((@CuaaEntranteequalthis IS NULL) OR CUAA_ENTRANTE = @CuaaEntranteequalthis) AND 
			((@IdFascicoloEntranteequalthis IS NULL) OR ID_FASCICOLO_ENTRANTE = @IdFascicoloEntranteequalthis) AND 
			((@CuaaUscenteequalthis IS NULL) OR CUAA_USCENTE = @CuaaUscenteequalthis) AND 
			((@IdFascicoloUscenteequalthis IS NULL) OR ID_FASCICOLO_USCENTE = @IdFascicoloUscenteequalthis) AND 
			((@RagsocUscenteequalthis IS NULL) OR RAGSOC_USCENTE = @RagsocUscenteequalthis) AND 
			((@IdAttoApprovazioneequalthis IS NULL) OR ID_ATTO_APPROVAZIONE = @IdAttoApprovazioneequalthis) AND 
			((@CodDefinizioneequalthis IS NULL) OR COD_DEFINIZIONE = @CodDefinizioneequalthis) AND 
			((@IdProgettoValutazioneequalthis IS NULL) OR ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazioneequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@OrdineFirmaequalthis IS NULL) OR ORDINE_FIRMA = @OrdineFirmaequalthis) AND 
			((@IdOperatoreFirmaComitatoequalthis IS NULL) OR ID_OPERATORE_FIRMA_COMITATO = @IdOperatoreFirmaComitatoequalthis) AND 
			((@OperatoreFirmaComitatoequalthis IS NULL) OR OPERATORE_FIRMA_COMITATO = @OperatoreFirmaComitatoequalthis)
		

GO