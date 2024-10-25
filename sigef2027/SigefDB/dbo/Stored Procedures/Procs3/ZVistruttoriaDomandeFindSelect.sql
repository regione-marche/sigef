CREATE PROCEDURE [dbo].[ZVistruttoriaDomandeFindSelect]
(
	@IdProgettoequalthis INT, 
	@IdBandoequalthis INT, 
	@IdProgIntegratoequalthis INT, 
	@CodStatoequalthis CHAR(1), 
	@Statoequalthis VARCHAR(80), 
	@Cuaaequalthis VARCHAR(16), 
	@PartitaIvaequalthis VARCHAR(16), 
	@RagioneSocialeequalthis VARCHAR(255), 
	@Comuneequalthis VARCHAR(255), 
	@Siglaequalthis CHAR(2), 
	@Capequalthis VARCHAR(5), 
	@Istruttoreequalthis VARCHAR(255), 
	@ProvinciaAssegnazioneequalthis CHAR(2), 
	@SelezionataXRevisioneequalthis BIT, 
	@ProvinciaDiPresentazioneequalthis CHAR(2), 
	@IdIstruttoreequalthis INT, 
	@Viaequalthis VARCHAR(500), 
	@SegnaturaRiequalthis VARCHAR(100), 
	@FiltroStatoIstruttoriaequalthis CHAR(1), 
	@OrdineStatoequalthis INT, 
	@IdImpresaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO, ID_BANDO, ID_PROG_INTEGRATO, COD_STATO, STATO, CUAA, PARTITA_IVA, RAGIONE_SOCIALE, COMUNE, SIGLA, CAP, ISTRUTTORE, PROVINCIA_ASSEGNAZIONE, SELEZIONATA_X_REVISIONE, PROVINCIA_DI_PRESENTAZIONE, ID_ISTRUTTORE, VIA, SEGNATURA_RI, FILTRO_STATO_ISTRUTTORIA, ORDINE_STATO, ID_IMPRESA FROM vISTRUTTORIA_DOMANDE WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgIntegratoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROG_INTEGRATO = @IdProgIntegratoequalthis)'; set @lensql=@lensql+len(@IdProgIntegratoequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@Statoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO = @Statoequalthis)'; set @lensql=@lensql+len(@Statoequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@PartitaIvaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PARTITA_IVA = @PartitaIvaequalthis)'; set @lensql=@lensql+len(@PartitaIvaequalthis);end;
	IF (@RagioneSocialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE = @RagioneSocialeequalthis)'; set @lensql=@lensql+len(@RagioneSocialeequalthis);end;
	IF (@Comuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COMUNE = @Comuneequalthis)'; set @lensql=@lensql+len(@Comuneequalthis);end;
	IF (@Siglaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SIGLA = @Siglaequalthis)'; set @lensql=@lensql+len(@Siglaequalthis);end;
	IF (@Capequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CAP = @Capequalthis)'; set @lensql=@lensql+len(@Capequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE = @Istruttoreequalthis)'; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	IF (@ProvinciaAssegnazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA_ASSEGNAZIONE = @ProvinciaAssegnazioneequalthis)'; set @lensql=@lensql+len(@ProvinciaAssegnazioneequalthis);end;
	IF (@SelezionataXRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis)'; set @lensql=@lensql+len(@SelezionataXRevisioneequalthis);end;
	IF (@ProvinciaDiPresentazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazioneequalthis)'; set @lensql=@lensql+len(@ProvinciaDiPresentazioneequalthis);end;
	IF (@IdIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTRUTTORE = @IdIstruttoreequalthis)'; set @lensql=@lensql+len(@IdIstruttoreequalthis);end;
	IF (@Viaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VIA = @Viaequalthis)'; set @lensql=@lensql+len(@Viaequalthis);end;
	IF (@SegnaturaRiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_RI = @SegnaturaRiequalthis)'; set @lensql=@lensql+len(@SegnaturaRiequalthis);end;
	IF (@FiltroStatoIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FILTRO_STATO_ISTRUTTORIA = @FiltroStatoIstruttoriaequalthis)'; set @lensql=@lensql+len(@FiltroStatoIstruttoriaequalthis);end;
	IF (@OrdineStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE_STATO = @OrdineStatoequalthis)'; set @lensql=@lensql+len(@OrdineStatoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdBandoequalthis INT, @IdProgIntegratoequalthis INT, @CodStatoequalthis CHAR(1), @Statoequalthis VARCHAR(80), @Cuaaequalthis VARCHAR(16), @PartitaIvaequalthis VARCHAR(16), @RagioneSocialeequalthis VARCHAR(255), @Comuneequalthis VARCHAR(255), @Siglaequalthis CHAR(2), @Capequalthis VARCHAR(5), @Istruttoreequalthis VARCHAR(255), @ProvinciaAssegnazioneequalthis CHAR(2), @SelezionataXRevisioneequalthis BIT, @ProvinciaDiPresentazioneequalthis CHAR(2), @IdIstruttoreequalthis INT, @Viaequalthis VARCHAR(500), @SegnaturaRiequalthis VARCHAR(100), @FiltroStatoIstruttoriaequalthis CHAR(1), @OrdineStatoequalthis INT, @IdImpresaequalthis INT',@IdProgettoequalthis , @IdBandoequalthis , @IdProgIntegratoequalthis , @CodStatoequalthis , @Statoequalthis , @Cuaaequalthis , @PartitaIvaequalthis , @RagioneSocialeequalthis , @Comuneequalthis , @Siglaequalthis , @Capequalthis , @Istruttoreequalthis , @ProvinciaAssegnazioneequalthis , @SelezionataXRevisioneequalthis , @ProvinciaDiPresentazioneequalthis , @IdIstruttoreequalthis , @Viaequalthis , @SegnaturaRiequalthis , @FiltroStatoIstruttoriaequalthis , @OrdineStatoequalthis , @IdImpresaequalthis ;
	else
		SELECT ID_PROGETTO, ID_BANDO, ID_PROG_INTEGRATO, COD_STATO, STATO, CUAA, PARTITA_IVA, RAGIONE_SOCIALE, COMUNE, SIGLA, CAP, ISTRUTTORE, PROVINCIA_ASSEGNAZIONE, SELEZIONATA_X_REVISIONE, PROVINCIA_DI_PRESENTAZIONE, ID_ISTRUTTORE, VIA, SEGNATURA_RI, FILTRO_STATO_ISTRUTTORIA, ORDINE_STATO, ID_IMPRESA
		FROM vISTRUTTORIA_DOMANDE
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgIntegratoequalthis IS NULL) OR ID_PROG_INTEGRATO = @IdProgIntegratoequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@Statoequalthis IS NULL) OR STATO = @Statoequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@PartitaIvaequalthis IS NULL) OR PARTITA_IVA = @PartitaIvaequalthis) AND 
			((@RagioneSocialeequalthis IS NULL) OR RAGIONE_SOCIALE = @RagioneSocialeequalthis) AND 
			((@Comuneequalthis IS NULL) OR COMUNE = @Comuneequalthis) AND 
			((@Siglaequalthis IS NULL) OR SIGLA = @Siglaequalthis) AND 
			((@Capequalthis IS NULL) OR CAP = @Capequalthis) AND 
			((@Istruttoreequalthis IS NULL) OR ISTRUTTORE = @Istruttoreequalthis) AND 
			((@ProvinciaAssegnazioneequalthis IS NULL) OR PROVINCIA_ASSEGNAZIONE = @ProvinciaAssegnazioneequalthis) AND 
			((@SelezionataXRevisioneequalthis IS NULL) OR SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis) AND 
			((@ProvinciaDiPresentazioneequalthis IS NULL) OR PROVINCIA_DI_PRESENTAZIONE = @ProvinciaDiPresentazioneequalthis) AND 
			((@IdIstruttoreequalthis IS NULL) OR ID_ISTRUTTORE = @IdIstruttoreequalthis) AND 
			((@Viaequalthis IS NULL) OR VIA = @Viaequalthis) AND 
			((@SegnaturaRiequalthis IS NULL) OR SEGNATURA_RI = @SegnaturaRiequalthis) AND 
			((@FiltroStatoIstruttoriaequalthis IS NULL) OR FILTRO_STATO_ISTRUTTORIA = @FiltroStatoIstruttoriaequalthis) AND 
			((@OrdineStatoequalthis IS NULL) OR ORDINE_STATO = @OrdineStatoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis)
