CREATE PROCEDURE [dbo].[ZBilancioAgricoloFindFind]
(
	@IdBilancioAgricoloequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdProgettoequalthis INT, 
	@Annoequalthis INT, 
	@DataBilancioequalthis DATETIME, 
	@Previsionaleequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BILANCIO_AGRICOLO, ID_IMPRESA, ID_PROGETTO, ANNO, DATA_BILANCIO, PREVISIONALE, DATA_MODIFICA, PLV_RICAVI_NETTI, PLV_RICAVI_ATTIVITA, PLV_RIMANENZE_FINALI, PLV_RIMANENZE_INIZIALI, VA_COSTI_MAT_PRIME, VA_COSTI_ATT_CONNESSE, VA_NOLEGGI, VA_MANUTENZIONI, VA_SPESE_GENERALI, VA_AFFITTI, VA_ALTRI_COSTI, PN_AMM_MACCHINE, PN_AMM_FABBRICATI, PN_AMM_PIANTAGIONI, RO_SALARI, RO_ONERI, RN_PAC_RICAVI, RN_PAC_COSTI, RN_PAC_PROVENTI, RN_PAC_PERDITE, RN_PAC_INTERESSI_ATTIVI, RN_PAC_INTERESSI_PASSIVI, RN_PAC_IMPOSTE, RN_PAC_CONTRIBUTI_PAC, MNL_REDDITI_FAM, MNL_RIMBORSO, MNL_PRELIEVI, CF_CF_TERRENI, CF_CF_IMPIANTI, CF_CF_PIANTAGIONI, CF_CF_MIGLIORAMENTI, CF_CA_MACCHINE, CF_CA_BESTIAME, CF_IF_PARTECIPAZIONI, CC_DF_RIMANENZE, CC_DF_ANTICIPAZIONI, CC_LD_CREDITI, CC_LI_BANCA, CC_LI_CASSA, FF_PC_DEBITI_BREVE_TERMINE, FF_PC_FORNITORI, FF_PC_DEBITI, FF_PC_MUTUI, FF_MP_CAPITALE, FF_MP_RISERVE, FF_MP_UTILE FROM BILANCIO_AGRICOLO WHERE 1=1';
	IF (@IdBilancioAgricoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BILANCIO_AGRICOLO = @IdBilancioAgricoloequalthis)'; set @lensql=@lensql+len(@IdBilancioAgricoloequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@DataBilancioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_BILANCIO = @DataBilancioequalthis)'; set @lensql=@lensql+len(@DataBilancioequalthis);end;
	IF (@Previsionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREVISIONALE = @Previsionaleequalthis)'; set @lensql=@lensql+len(@Previsionaleequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBilancioAgricoloequalthis INT, @IdImpresaequalthis INT, @IdProgettoequalthis INT, @Annoequalthis INT, @DataBilancioequalthis DATETIME, @Previsionaleequalthis BIT',@IdBilancioAgricoloequalthis , @IdImpresaequalthis , @IdProgettoequalthis , @Annoequalthis , @DataBilancioequalthis , @Previsionaleequalthis ;
	else
		SELECT ID_BILANCIO_AGRICOLO, ID_IMPRESA, ID_PROGETTO, ANNO, DATA_BILANCIO, PREVISIONALE, DATA_MODIFICA, PLV_RICAVI_NETTI, PLV_RICAVI_ATTIVITA, PLV_RIMANENZE_FINALI, PLV_RIMANENZE_INIZIALI, VA_COSTI_MAT_PRIME, VA_COSTI_ATT_CONNESSE, VA_NOLEGGI, VA_MANUTENZIONI, VA_SPESE_GENERALI, VA_AFFITTI, VA_ALTRI_COSTI, PN_AMM_MACCHINE, PN_AMM_FABBRICATI, PN_AMM_PIANTAGIONI, RO_SALARI, RO_ONERI, RN_PAC_RICAVI, RN_PAC_COSTI, RN_PAC_PROVENTI, RN_PAC_PERDITE, RN_PAC_INTERESSI_ATTIVI, RN_PAC_INTERESSI_PASSIVI, RN_PAC_IMPOSTE, RN_PAC_CONTRIBUTI_PAC, MNL_REDDITI_FAM, MNL_RIMBORSO, MNL_PRELIEVI, CF_CF_TERRENI, CF_CF_IMPIANTI, CF_CF_PIANTAGIONI, CF_CF_MIGLIORAMENTI, CF_CA_MACCHINE, CF_CA_BESTIAME, CF_IF_PARTECIPAZIONI, CC_DF_RIMANENZE, CC_DF_ANTICIPAZIONI, CC_LD_CREDITI, CC_LI_BANCA, CC_LI_CASSA, FF_PC_DEBITI_BREVE_TERMINE, FF_PC_FORNITORI, FF_PC_DEBITI, FF_PC_MUTUI, FF_MP_CAPITALE, FF_MP_RISERVE, FF_MP_UTILE
		FROM BILANCIO_AGRICOLO
		WHERE 
			((@IdBilancioAgricoloequalthis IS NULL) OR ID_BILANCIO_AGRICOLO = @IdBilancioAgricoloequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@DataBilancioequalthis IS NULL) OR DATA_BILANCIO = @DataBilancioequalthis) AND 
			((@Previsionaleequalthis IS NULL) OR PREVISIONALE = @Previsionaleequalthis)
