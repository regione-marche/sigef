CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseFindFind]
(
	@IdManifestazioneequalthis INT, 
	@IdBandoequalthis INT, 
	@IdFilieraequalthis INT, 
	@Cuaaequalthis VARCHAR(16)
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
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdManifestazioneequalthis INT, @IdBandoequalthis INT, @IdFilieraequalthis INT, @Cuaaequalthis VARCHAR(16)',@IdManifestazioneequalthis , @IdBandoequalthis , @IdFilieraequalthis , @Cuaaequalthis ;
	else
		SELECT ID_MANIFESTAZIONE, ID_BANDO, ID_FILIERA, CUAA, SEGNATURA, OPERATORE, DATA_INSERIMENTO, DATA_ULTIMA_MODIFICA, DENOMINAZIONE, NOMINATIVO_OPERATORE, COD_TIPO_FILIERA, TIPO_FILIERA, NUM_CERTIFICATO, DATA_CERTIFICATO, IDEA_PROGETTUALE, DICHIARAZIONI, MOTIVAZIONI_ESCLUSIONE, RAGIONE_SOCIALE, VIA, COMUNE, CAP, SIGLA, SEGNATURA_ALLEGATI
		FROM vMANIFESTAZIONE_DI_INTERESSE
		WHERE 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdFilieraequalthis IS NULL) OR ID_FILIERA = @IdFilieraequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseFindFind]
(
	@IdManifestazioneequalthis INT, 
	@IdBandoequalthis INT, 
	@IdFilieraequalthis INT, 
	@Cuaaequalthis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_MANIFESTAZIONE, ID_BANDO, ID_FILIERA, CUAA, SEGNATURA, OPERATORE, DATA_INSERIMENTO, DATA_ULTIMA_MODIFICA, DENOMINAZIONE, NOMINATIVO_OPERATORE, COD_TIPO_FILIERA, TIPO_FILIERA, NUM_CERTIFICATO, DATA_CERTIFICATO, IDEA_PROGETTUALE, DICHIARAZIONI, MOTIVAZIONI_ESCLUSIONE, RAGIONE_SOCIALE, VIA, COMUNE, CAP, SIGLA, SEGNATURA_ALLEGATI FROM vMANIFESTAZIONE_DI_INTERESSE WHERE 1=1'';
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)''; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdFilieraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILIERA = @IdFilieraequalthis)''; set @lensql=@lensql+len(@IdFilieraequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CUAA = @Cuaaequalthis)''; set @lensql=@lensql+len(@Cuaaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdManifestazioneequalthis INT, @IdBandoequalthis INT, @IdFilieraequalthis INT, @Cuaaequalthis VARCHAR(16)'',@IdManifestazioneequalthis , @IdBandoequalthis , @IdFilieraequalthis , @Cuaaequalthis ;
	else
		SELECT ID_MANIFESTAZIONE, ID_BANDO, ID_FILIERA, CUAA, SEGNATURA, OPERATORE, DATA_INSERIMENTO, DATA_ULTIMA_MODIFICA, DENOMINAZIONE, NOMINATIVO_OPERATORE, COD_TIPO_FILIERA, TIPO_FILIERA, NUM_CERTIFICATO, DATA_CERTIFICATO, IDEA_PROGETTUALE, DICHIARAZIONI, MOTIVAZIONI_ESCLUSIONE, RAGIONE_SOCIALE, VIA, COMUNE, CAP, SIGLA, SEGNATURA_ALLEGATI
		FROM vMANIFESTAZIONE_DI_INTERESSE
		WHERE 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdFilieraequalthis IS NULL) OR ID_FILIERA = @IdFilieraequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneDiInteresseFindFind';

