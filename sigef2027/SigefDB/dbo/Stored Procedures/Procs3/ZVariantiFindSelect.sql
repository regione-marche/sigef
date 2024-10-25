CREATE PROCEDURE [dbo].[ZVariantiFindSelect]
(
	@IdVarianteequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CodEnteequalthis VARCHAR(255), 
	@Operatoreequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@Descrizioneequalthis VARCHAR(1000), 
	@Segnaturaequalthis VARCHAR(255), 
	@SegnaturaAllegatiequalthis VARCHAR(255), 
	@SegnaturaApprovazioneequalthis VARCHAR(255), 
	@Approvataequalthis BIT, 
	@DataApprovazioneequalthis DATETIME, 
	@Istruttoreequalthis VARCHAR(255), 
	@CuaaEntranteequalthis VARCHAR(255), 
	@IdFascicoloEntranteequalthis INT, 
	@CuaaUscenteequalthis VARCHAR(255), 
	@RagsocUscenteequalthis VARCHAR(255), 
	@IdFascicoloUscenteequalthis INT, 
	@Annullataequalthis BIT, 
	@SegnaturaAnnullamentoequalthis VARCHAR(255), 
	@CfOperatoreAnnullamentoequalthis VARCHAR(255), 
	@DataAnnullamentoequalthis DATETIME, 
	@IdAttoApprovazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VARIANTE, ID_PROGETTO, COD_TIPO, DATA_INSERIMENTO, COD_ENTE, OPERATORE, DATA_MODIFICA, SEGNATURA, SEGNATURA_ALLEGATI, SEGNATURA_APPROVAZIONE, APPROVATA, ISTRUTTORE, NOTE_ISTRUTTORE, TIPO_VARIANTE, NOMINATIVO, PROFILO, ENTE, DATA_APPROVAZIONE, PROVINCIA, DESCRIZIONE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, NOMINATIVO_OPERATORE_ANNULLAMENTO, NOMINATIVO_ISTRUTTORE, CUAA_ENTRANTE, ID_FASCICOLO_ENTRANTE, CUAA_USCENTE, ID_FASCICOLO_USCENTE, RAGSOC_USCENTE, ID_ATTO_APPROVAZIONE, AW_DOCNUMBER, COD_DEFINIZIONE, AW_DOCNUMBER_NUOVO FROM vVARIANTI WHERE 1=1';
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@SegnaturaAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis)'; set @lensql=@lensql+len(@SegnaturaAllegatiequalthis);end;
	IF (@SegnaturaApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_APPROVAZIONE = @SegnaturaApprovazioneequalthis)'; set @lensql=@lensql+len(@SegnaturaApprovazioneequalthis);end;
	IF (@Approvataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (APPROVATA = @Approvataequalthis)'; set @lensql=@lensql+len(@Approvataequalthis);end;
	IF (@DataApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_APPROVAZIONE = @DataApprovazioneequalthis)'; set @lensql=@lensql+len(@DataApprovazioneequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE = @Istruttoreequalthis)'; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	IF (@CuaaEntranteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA_ENTRANTE = @CuaaEntranteequalthis)'; set @lensql=@lensql+len(@CuaaEntranteequalthis);end;
	IF (@IdFascicoloEntranteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FASCICOLO_ENTRANTE = @IdFascicoloEntranteequalthis)'; set @lensql=@lensql+len(@IdFascicoloEntranteequalthis);end;
	IF (@CuaaUscenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA_USCENTE = @CuaaUscenteequalthis)'; set @lensql=@lensql+len(@CuaaUscenteequalthis);end;
	IF (@RagsocUscenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGSOC_USCENTE = @RagsocUscenteequalthis)'; set @lensql=@lensql+len(@RagsocUscenteequalthis);end;
	IF (@IdFascicoloUscenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FASCICOLO_USCENTE = @IdFascicoloUscenteequalthis)'; set @lensql=@lensql+len(@IdFascicoloUscenteequalthis);end;
	IF (@Annullataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATA = @Annullataequalthis)'; set @lensql=@lensql+len(@Annullataequalthis);end;
	IF (@SegnaturaAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ANNULLAMENTO = @SegnaturaAnnullamentoequalthis)'; set @lensql=@lensql+len(@SegnaturaAnnullamentoequalthis);end;
	IF (@CfOperatoreAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE_ANNULLAMENTO = @CfOperatoreAnnullamentoequalthis)'; set @lensql=@lensql+len(@CfOperatoreAnnullamentoequalthis);end;
	IF (@DataAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ANNULLAMENTO = @DataAnnullamentoequalthis)'; set @lensql=@lensql+len(@DataAnnullamentoequalthis);end;
	IF (@IdAttoApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO_APPROVAZIONE = @IdAttoApprovazioneequalthis)'; set @lensql=@lensql+len(@IdAttoApprovazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVarianteequalthis INT, @IdProgettoequalthis INT, @CodTipoequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @CodEnteequalthis VARCHAR(255), @Operatoreequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @Descrizioneequalthis VARCHAR(1000), @Segnaturaequalthis VARCHAR(255), @SegnaturaAllegatiequalthis VARCHAR(255), @SegnaturaApprovazioneequalthis VARCHAR(255), @Approvataequalthis BIT, @DataApprovazioneequalthis DATETIME, @Istruttoreequalthis VARCHAR(255), @CuaaEntranteequalthis VARCHAR(255), @IdFascicoloEntranteequalthis INT, @CuaaUscenteequalthis VARCHAR(255), @RagsocUscenteequalthis VARCHAR(255), @IdFascicoloUscenteequalthis INT, @Annullataequalthis BIT, @SegnaturaAnnullamentoequalthis VARCHAR(255), @CfOperatoreAnnullamentoequalthis VARCHAR(255), @DataAnnullamentoequalthis DATETIME, @IdAttoApprovazioneequalthis INT',@IdVarianteequalthis , @IdProgettoequalthis , @CodTipoequalthis , @DataInserimentoequalthis , @CodEnteequalthis , @Operatoreequalthis , @DataModificaequalthis , @Descrizioneequalthis , @Segnaturaequalthis , @SegnaturaAllegatiequalthis , @SegnaturaApprovazioneequalthis , @Approvataequalthis , @DataApprovazioneequalthis , @Istruttoreequalthis , @CuaaEntranteequalthis , @IdFascicoloEntranteequalthis , @CuaaUscenteequalthis , @RagsocUscenteequalthis , @IdFascicoloUscenteequalthis , @Annullataequalthis , @SegnaturaAnnullamentoequalthis , @CfOperatoreAnnullamentoequalthis , @DataAnnullamentoequalthis , @IdAttoApprovazioneequalthis ;
	else
		SELECT ID_VARIANTE, ID_PROGETTO, COD_TIPO, DATA_INSERIMENTO, COD_ENTE, OPERATORE, DATA_MODIFICA, SEGNATURA, SEGNATURA_ALLEGATI, SEGNATURA_APPROVAZIONE, APPROVATA, ISTRUTTORE, NOTE_ISTRUTTORE, TIPO_VARIANTE, NOMINATIVO, PROFILO, ENTE, DATA_APPROVAZIONE, PROVINCIA, DESCRIZIONE, ANNULLATA, SEGNATURA_ANNULLAMENTO, CF_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, NOMINATIVO_OPERATORE_ANNULLAMENTO, NOMINATIVO_ISTRUTTORE, CUAA_ENTRANTE, ID_FASCICOLO_ENTRANTE, CUAA_USCENTE, ID_FASCICOLO_USCENTE, RAGSOC_USCENTE, ID_ATTO_APPROVAZIONE, AW_DOCNUMBER, COD_DEFINIZIONE, AW_DOCNUMBER_NUOVO
		FROM vVARIANTI
		WHERE 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@SegnaturaAllegatiequalthis IS NULL) OR SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis) AND 
			((@SegnaturaApprovazioneequalthis IS NULL) OR SEGNATURA_APPROVAZIONE = @SegnaturaApprovazioneequalthis) AND 
			((@Approvataequalthis IS NULL) OR APPROVATA = @Approvataequalthis) AND 
			((@DataApprovazioneequalthis IS NULL) OR DATA_APPROVAZIONE = @DataApprovazioneequalthis) AND 
			((@Istruttoreequalthis IS NULL) OR ISTRUTTORE = @Istruttoreequalthis) AND 
			((@CuaaEntranteequalthis IS NULL) OR CUAA_ENTRANTE = @CuaaEntranteequalthis) AND 
			((@IdFascicoloEntranteequalthis IS NULL) OR ID_FASCICOLO_ENTRANTE = @IdFascicoloEntranteequalthis) AND 
			((@CuaaUscenteequalthis IS NULL) OR CUAA_USCENTE = @CuaaUscenteequalthis) AND 
			((@RagsocUscenteequalthis IS NULL) OR RAGSOC_USCENTE = @RagsocUscenteequalthis) AND 
			((@IdFascicoloUscenteequalthis IS NULL) OR ID_FASCICOLO_USCENTE = @IdFascicoloUscenteequalthis) AND 
			((@Annullataequalthis IS NULL) OR ANNULLATA = @Annullataequalthis) AND 
			((@SegnaturaAnnullamentoequalthis IS NULL) OR SEGNATURA_ANNULLAMENTO = @SegnaturaAnnullamentoequalthis) AND 
			((@CfOperatoreAnnullamentoequalthis IS NULL) OR CF_OPERATORE_ANNULLAMENTO = @CfOperatoreAnnullamentoequalthis) AND 
			((@DataAnnullamentoequalthis IS NULL) OR DATA_ANNULLAMENTO = @DataAnnullamentoequalthis) AND 
			((@IdAttoApprovazioneequalthis IS NULL) OR ID_ATTO_APPROVAZIONE = @IdAttoApprovazioneequalthis)
