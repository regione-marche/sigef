CREATE PROCEDURE [dbo].[ZProgettoFindFind]
(
	@IdBandoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdProgIntegratoequalthis INT, 
	@CodStatoequalthis VARCHAR(255), 
	@CodFaseequalthis VARCHAR(255), 
	@FlagPreadesioneequalthis BIT, 
	@FlagDefinitivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO, ID_BANDO, COD_AGEA, SEGNATURA_ALLEGATI, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_IMPRESA, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, NOMINATIVO, ENTE, COD_ENTE, PROVINCIA, COD_TIPO_ENTE, RIAPERTURA_PROVINCIALE, FIRMA_PREDISPOSTA, ID_ATTO FROM vPROGETTO WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdProgIntegratoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROG_INTEGRATO = @IdProgIntegratoequalthis)'; set @lensql=@lensql+len(@IdProgIntegratoequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@FlagPreadesioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_PREADESIONE = @FlagPreadesioneequalthis)'; set @lensql=@lensql+len(@FlagPreadesioneequalthis);end;
	IF (@FlagDefinitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_DEFINITIVO = @FlagDefinitivoequalthis)'; set @lensql=@lensql+len(@FlagDefinitivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdImpresaequalthis INT, @IdProgIntegratoequalthis INT, @CodStatoequalthis VARCHAR(255), @CodFaseequalthis VARCHAR(255), @FlagPreadesioneequalthis BIT, @FlagDefinitivoequalthis BIT',@IdBandoequalthis , @IdImpresaequalthis , @IdProgIntegratoequalthis , @CodStatoequalthis , @CodFaseequalthis , @FlagPreadesioneequalthis , @FlagDefinitivoequalthis ;
	else
		SELECT ID_PROGETTO, ID_BANDO, COD_AGEA, SEGNATURA_ALLEGATI, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_IMPRESA, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, NOMINATIVO, ENTE, COD_ENTE, PROVINCIA, COD_TIPO_ENTE, RIAPERTURA_PROVINCIALE, FIRMA_PREDISPOSTA, ID_ATTO
		FROM vPROGETTO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdProgIntegratoequalthis IS NULL) OR ID_PROG_INTEGRATO = @IdProgIntegratoequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@FlagPreadesioneequalthis IS NULL) OR FLAG_PREADESIONE = @FlagPreadesioneequalthis) AND 
			((@FlagDefinitivoequalthis IS NULL) OR FLAG_DEFINITIVO = @FlagDefinitivoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoFindFind]
(
	@IdBandoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdProgIntegratoequalthis INT, 
	@CodStatoequalthis VARCHAR(255), 
	@CodFaseequalthis VARCHAR(255), 
	@FlagPreadesioneequalthis BIT, 
	@FlagDefinitivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROGETTO, ID_BANDO, COD_AGEA, SEGNATURA_ALLEGATI, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_IMPRESA, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, NOMINATIVO, ENTE, COD_ENTE, PROVINCIA, COD_TIPO_ENTE, RIAPERTURA_PROVINCIALE, FIRMA_PREDISPOSTA FROM vPROGETTO WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdProgIntegratoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROG_INTEGRATO = @IdProgIntegratoequalthis)''; set @lensql=@lensql+len(@IdProgIntegratoequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_STATO = @CodStatoequalthis)''; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FASE = @CodFaseequalthis)''; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@FlagPreadesioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_PREADESIONE = @FlagPreadesioneequalthis)''; set @lensql=@lensql+len(@FlagPreadesioneequalthis);end;
	IF (@FlagDefinitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_DEFINITIVO = @FlagDefinitivoequalthis)''; set @lensql=@lensql+len(@FlagDefinitivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT, @IdImpresaequalthis INT, @IdProgIntegratoequalthis INT, @CodStatoequalthis VARCHAR(255), @CodFaseequalthis VARCHAR(255), @FlagPreadesioneequalthis BIT, @FlagDefinitivoequalthis BIT'',@IdBandoequalthis , @IdImpresaequalthis , @IdProgIntegratoequalthis , @CodStatoequalthis , @CodFaseequalthis , @FlagPreadesioneequalthis , @FlagDefinitivoequalthis ;
	else
		SELECT ID_PROGETTO, ID_BANDO, COD_AGEA, SEGNATURA_ALLEGATI, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, ID_PROG_INTEGRATO, FLAG_PREADESIONE, FLAG_DEFINITIVO, ID_FASCICOLO, PROVINCIA_DI_PRESENTAZIONE, SELEZIONATA_X_REVISIONE, ID_IMPRESA, ID_STORICO_ULTIMO, DATA_CREAZIONE, OPERATORE_CREAZIONE, NOMINATIVO, ENTE, COD_ENTE, PROVINCIA, COD_TIPO_ENTE, RIAPERTURA_PROVINCIALE, FIRMA_PREDISPOSTA
		FROM vPROGETTO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdProgIntegratoequalthis IS NULL) OR ID_PROG_INTEGRATO = @IdProgIntegratoequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@FlagPreadesioneequalthis IS NULL) OR FLAG_PREADESIONE = @FlagPreadesioneequalthis) AND 
			((@FlagDefinitivoequalthis IS NULL) OR FLAG_DEFINITIVO = @FlagDefinitivoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoFindFind';

