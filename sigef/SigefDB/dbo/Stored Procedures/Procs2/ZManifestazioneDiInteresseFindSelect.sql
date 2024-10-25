CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseFindSelect]
(
	@IdManifestazioneequalthis INT, 
	@IdBandoequalthis INT, 
	@IdFilieraequalthis INT, 
	@Cuaaequalthis VARCHAR(16), 
	@Segnaturaequalthis VARCHAR(100), 
	@SegnaturaAllegatiequalthis VARCHAR(100), 
	@Operatoreequalthis VARCHAR(16), 
	@DataInserimentoequalthis DATETIME, 
	@DataUltimaModificaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_MANIFESTAZIONE, ID_BANDO, ID_FILIERA, CUAA, SEGNATURA, OPERATORE, DATA_INSERIMENTO, DATA_ULTIMA_MODIFICA, DENOMINAZIONE, NOMINATIVO_OPERATORE, COD_TIPO_FILIERA, TIPO_FILIERA, NUM_CERTIFICATO, DATA_CERTIFICATO, IDEA_PROGETTUALE, DICHIARAZIONI, MOTIVAZIONI_ESCLUSIONE, RAGIONE_SOCIALE, VIA, COMUNE, CAP, SIGLA, SEGNATURA_ALLEGATI FROM vMANIFESTAZIONE_DI_INTERESSE WHERE 1=1';
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILIERA = @IdFilieraequalthis)'; set @lensql=@lensql+len(@IdFilieraequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@SegnaturaAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis)'; set @lensql=@lensql+len(@SegnaturaAllegatiequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataUltimaModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ULTIMA_MODIFICA = @DataUltimaModificaequalthis)'; set @lensql=@lensql+len(@DataUltimaModificaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdManifestazioneequalthis INT, @IdBandoequalthis INT, @IdFilieraequalthis INT, @Cuaaequalthis VARCHAR(16), @Segnaturaequalthis VARCHAR(100), @SegnaturaAllegatiequalthis VARCHAR(100), @Operatoreequalthis VARCHAR(16), @DataInserimentoequalthis DATETIME, @DataUltimaModificaequalthis DATETIME',@IdManifestazioneequalthis , @IdBandoequalthis , @IdFilieraequalthis , @Cuaaequalthis , @Segnaturaequalthis , @SegnaturaAllegatiequalthis , @Operatoreequalthis , @DataInserimentoequalthis , @DataUltimaModificaequalthis ;
	else
		SELECT ID_MANIFESTAZIONE, ID_BANDO, ID_FILIERA, CUAA, SEGNATURA, OPERATORE, DATA_INSERIMENTO, DATA_ULTIMA_MODIFICA, DENOMINAZIONE, NOMINATIVO_OPERATORE, COD_TIPO_FILIERA, TIPO_FILIERA, NUM_CERTIFICATO, DATA_CERTIFICATO, IDEA_PROGETTUALE, DICHIARAZIONI, MOTIVAZIONI_ESCLUSIONE, RAGIONE_SOCIALE, VIA, COMUNE, CAP, SIGLA, SEGNATURA_ALLEGATI
		FROM vMANIFESTAZIONE_DI_INTERESSE
		WHERE 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdFilieraequalthis IS NULL) OR ID_FILIERA = @IdFilieraequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@SegnaturaAllegatiequalthis IS NULL) OR SEGNATURA_ALLEGATI = @SegnaturaAllegatiequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataUltimaModificaequalthis IS NULL) OR DATA_ULTIMA_MODIFICA = @DataUltimaModificaequalthis)
