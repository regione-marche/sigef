CREATE PROCEDURE [dbo].[ZProgettoFindSelect]
(
	@IdProgettoequalthis INT, 
	@IdBandoequalthis INT, 
	@CodAgeaequalthis VARCHAR(255), 
	@SegnaturaAllegatiequalthis VARCHAR(255), 
	@IdProgIntegratoequalthis INT, 
	@FlagPreadesioneequalthis BIT, 
	@FlagDefinitivoequalthis BIT, 
	@IdFascicoloequalthis INT, 
	@ProvinciaDiPresentazioneequalthis VARCHAR(255), 
	@SelezionataXRevisioneequalthis BIT, 
	@IdImpresaequalthis INT, 
	@IdStoricoUltimoequalthis INT, 
	@DataCreazioneequalthis DATETIME, 
	@OperatoreCreazioneequalthis INT, 
	@FirmaPredispostaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO, ID_BANDO, COD_AGEA, SEGNATURA_ALLEGATI, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_IMPRESA, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, NOMINATIVO, ENTE, COD_ENTE, PROVINCIA, COD_TIPO_ENTE, RIAPERTURA_PROVINCIALE, FIRMA_PREDISPOSTA, ID_ATTO FROM vPROGETTO WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodAgeaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_AGEA = @CodAgeaequalthis)'; set @lensql=@lensql+len(@CodAgeaequalthis);end;
	IF (@SegnaturaAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis)'; set @lensql=@lensql+len(@SegnaturaAllegatiequalthis);end;
	IF (@IdProgIntegratoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROG_INTEGRATO = @IdProgIntegratoequalthis)'; set @lensql=@lensql+len(@IdProgIntegratoequalthis);end;
	IF (@FlagPreadesioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_PREADESIONE = @FlagPreadesioneequalthis)'; set @lensql=@lensql+len(@FlagPreadesioneequalthis);end;
	IF (@FlagDefinitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_DEFINITIVO = @FlagDefinitivoequalthis)'; set @lensql=@lensql+len(@FlagDefinitivoequalthis);end;
	IF (@IdFascicoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FASCICOLO = @IdFascicoloequalthis)'; set @lensql=@lensql+len(@IdFascicoloequalthis);end;
	IF (@ProvinciaDiPresentazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazioneequalthis)'; set @lensql=@lensql+len(@ProvinciaDiPresentazioneequalthis);end;
	IF (@SelezionataXRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis)'; set @lensql=@lensql+len(@SelezionataXRevisioneequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)'; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	IF (@DataCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CREAZIONE = @DataCreazioneequalthis)'; set @lensql=@lensql+len(@DataCreazioneequalthis);end;
	IF (@OperatoreCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_CREAZIONE = @OperatoreCreazioneequalthis)'; set @lensql=@lensql+len(@OperatoreCreazioneequalthis);end;
	IF (@FirmaPredispostaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FIRMA_PREDISPOSTA = @FirmaPredispostaequalthis)'; set @lensql=@lensql+len(@FirmaPredispostaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdBandoequalthis INT, @CodAgeaequalthis VARCHAR(255), @SegnaturaAllegatiequalthis VARCHAR(255), @IdProgIntegratoequalthis INT, @FlagPreadesioneequalthis BIT, @FlagDefinitivoequalthis BIT, @IdFascicoloequalthis INT, @ProvinciaDiPresentazioneequalthis VARCHAR(255), @SelezionataXRevisioneequalthis BIT, @IdImpresaequalthis INT, @IdStoricoUltimoequalthis INT, @DataCreazioneequalthis DATETIME, @OperatoreCreazioneequalthis INT, @FirmaPredispostaequalthis BIT',@IdProgettoequalthis , @IdBandoequalthis , @CodAgeaequalthis , @SegnaturaAllegatiequalthis , @IdProgIntegratoequalthis , @FlagPreadesioneequalthis , @FlagDefinitivoequalthis , @IdFascicoloequalthis , @ProvinciaDiPresentazioneequalthis , @SelezionataXRevisioneequalthis , @IdImpresaequalthis , @IdStoricoUltimoequalthis , @DataCreazioneequalthis , @OperatoreCreazioneequalthis , @FirmaPredispostaequalthis ;
	else
		SELECT ID_PROGETTO, ID_BANDO, COD_AGEA, SEGNATURA_ALLEGATI, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_IMPRESA, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, NOMINATIVO, ENTE, COD_ENTE, PROVINCIA, COD_TIPO_ENTE, RIAPERTURA_PROVINCIALE, FIRMA_PREDISPOSTA, ID_ATTO
		FROM vPROGETTO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodAgeaequalthis IS NULL) OR COD_AGEA = @CodAgeaequalthis) AND 
			((@SegnaturaAllegatiequalthis IS NULL) OR SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis) AND 
			((@IdProgIntegratoequalthis IS NULL) OR ID_PROG_INTEGRATO = @IdProgIntegratoequalthis) AND 
			((@FlagPreadesioneequalthis IS NULL) OR FLAG_PREADESIONE = @FlagPreadesioneequalthis) AND 
			((@FlagDefinitivoequalthis IS NULL) OR FLAG_DEFINITIVO = @FlagDefinitivoequalthis) AND 
			((@IdFascicoloequalthis IS NULL) OR ID_FASCICOLO = @IdFascicoloequalthis) AND 
			((@ProvinciaDiPresentazioneequalthis IS NULL) OR PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazioneequalthis) AND 
			((@SelezionataXRevisioneequalthis IS NULL) OR SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdStoricoUltimoequalthis IS NULL) OR ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis) AND 
			((@DataCreazioneequalthis IS NULL) OR DATA_CREAZIONE = @DataCreazioneequalthis) AND 
			((@OperatoreCreazioneequalthis IS NULL) OR OPERATORE_CREAZIONE = @OperatoreCreazioneequalthis) AND 
			((@FirmaPredispostaequalthis IS NULL) OR FIRMA_PREDISPOSTA = @FirmaPredispostaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoFindSelect]
(
	@IdProgettoequalthis INT, 
	@IdBandoequalthis INT, 
	@CodAgeaequalthis VARCHAR(255), 
	@SegnaturaAllegatiequalthis VARCHAR(255), 
	@IdProgIntegratoequalthis INT, 
	@FlagPreadesioneequalthis BIT, 
	@FlagDefinitivoequalthis BIT, 
	@IdFascicoloequalthis INT, 
	@ProvinciaDiPresentazioneequalthis VARCHAR(255), 
	@SelezionataXRevisioneequalthis BIT, 
	@IdImpresaequalthis INT, 
	@IdStoricoUltimoequalthis INT, 
	@DataCreazioneequalthis DATETIME, 
	@OperatoreCreazioneequalthis INT, 
	@FirmaPredispostaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROGETTO, ID_BANDO, COD_AGEA, SEGNATURA_ALLEGATI, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_IMPRESA, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, NOMINATIVO, ENTE, COD_ENTE, PROVINCIA, COD_TIPO_ENTE, RIAPERTURA_PROVINCIALE, FIRMA_PREDISPOSTA FROM vPROGETTO WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodAgeaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_AGEA = @CodAgeaequalthis)''; set @lensql=@lensql+len(@CodAgeaequalthis);end;
	IF (@SegnaturaAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis)''; set @lensql=@lensql+len(@SegnaturaAllegatiequalthis);end;
	IF (@IdProgIntegratoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROG_INTEGRATO = @IdProgIntegratoequalthis)''; set @lensql=@lensql+len(@IdProgIntegratoequalthis);end;
	IF (@FlagPreadesioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_PREADESIONE = @FlagPreadesioneequalthis)''; set @lensql=@lensql+len(@FlagPreadesioneequalthis);end;
	IF (@FlagDefinitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_DEFINITIVO = @FlagDefinitivoequalthis)''; set @lensql=@lensql+len(@FlagDefinitivoequalthis);end;
	IF (@IdFascicoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FASCICOLO = @IdFascicoloequalthis)''; set @lensql=@lensql+len(@IdFascicoloequalthis);end;
	IF (@ProvinciaDiPresentazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazioneequalthis)''; set @lensql=@lensql+len(@ProvinciaDiPresentazioneequalthis);end;
	IF (@SelezionataXRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis)''; set @lensql=@lensql+len(@SelezionataXRevisioneequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)''; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	IF (@DataCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_CREAZIONE = @DataCreazioneequalthis)''; set @lensql=@lensql+len(@DataCreazioneequalthis);end;
	IF (@OperatoreCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE_CREAZIONE = @OperatoreCreazioneequalthis)''; set @lensql=@lensql+len(@OperatoreCreazioneequalthis);end;
	IF (@FirmaPredispostaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FIRMA_PREDISPOSTA = @FirmaPredispostaequalthis)''; set @lensql=@lensql+len(@FirmaPredispostaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @IdBandoequalthis INT, @CodAgeaequalthis VARCHA', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoFindSelect';

