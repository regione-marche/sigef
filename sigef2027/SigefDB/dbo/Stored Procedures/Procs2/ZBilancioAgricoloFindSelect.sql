CREATE PROCEDURE [dbo].[ZBilancioAgricoloFindSelect]
(
	@IdBilancioAgricoloequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdProgettoequalthis INT, 
	@Annoequalthis INT, 
	@DataBilancioequalthis DATETIME, 
	@Previsionaleequalthis BIT, 
	@DataModificaequalthis DATETIME, 
	@PlvRicaviNettiequalthis DECIMAL(15,2), 
	@PlvRicaviAttivitaequalthis DECIMAL(15,2), 
	@PlvRimanenzeFinaliequalthis DECIMAL(15,2), 
	@PlvRimanenzeInizialiequalthis DECIMAL(15,2), 
	@VaCostiMatPrimeequalthis DECIMAL(15,2), 
	@VaCostiAttConnesseequalthis DECIMAL(15,2), 
	@VaNoleggiequalthis DECIMAL(15,2), 
	@VaManutenzioniequalthis DECIMAL(15,2), 
	@VaSpeseGeneraliequalthis DECIMAL(15,2), 
	@VaAffittiequalthis DECIMAL(15,2), 
	@VaAltriCostiequalthis DECIMAL(15,2), 
	@PnAmmMacchineequalthis DECIMAL(15,2), 
	@PnAmmFabbricatiequalthis DECIMAL(15,2), 
	@PnAmmPiantagioniequalthis DECIMAL(15,2), 
	@RoSalariequalthis DECIMAL(15,2), 
	@RoOneriequalthis DECIMAL(15,2), 
	@RnPacRicaviequalthis DECIMAL(15,2), 
	@RnPacCostiequalthis DECIMAL(15,2), 
	@RnPacProventiequalthis DECIMAL(15,2), 
	@RnPacPerditeequalthis DECIMAL(15,2), 
	@RnPacInteressiAttiviequalthis DECIMAL(15,2), 
	@RnPacInteressiPassiviequalthis DECIMAL(15,2), 
	@RnPacImposteequalthis DECIMAL(15,2), 
	@RnPacContributiPacequalthis DECIMAL(15,2), 
	@MnlRedditiFamequalthis DECIMAL(15,2), 
	@MnlRimborsoequalthis DECIMAL(15,2), 
	@MnlPrelieviequalthis DECIMAL(15,2), 
	@CfCfTerreniequalthis DECIMAL(15,2), 
	@CfCfImpiantiequalthis DECIMAL(15,2), 
	@CfCfPiantagioniequalthis DECIMAL(15,2), 
	@CfCfMiglioramentiequalthis DECIMAL(15,2), 
	@CfCaMacchineequalthis DECIMAL(15,2), 
	@CfCaBestiameequalthis DECIMAL(15,2), 
	@CfIfPartecipazioniequalthis DECIMAL(15,2), 
	@CcDfRimanenzeequalthis DECIMAL(15,2), 
	@CcDfAnticipazioniequalthis DECIMAL(15,2), 
	@CcLdCreditiequalthis DECIMAL(15,2), 
	@CcLiBancaequalthis DECIMAL(15,2), 
	@CcLiCassaequalthis DECIMAL(15,2), 
	@FfPcDebitiBreveTermineequalthis DECIMAL(15,2), 
	@FfPcFornitoriequalthis DECIMAL(15,2), 
	@FfPcDebitiequalthis DECIMAL(15,2), 
	@FfPcMutuiequalthis DECIMAL(15,2), 
	@FfMpCapitaleequalthis DECIMAL(15,2), 
	@FfMpRiserveequalthis DECIMAL(15,2), 
	@FfMpUtileequalthis DECIMAL(15,2)
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
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@PlvRicaviNettiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLV_RICAVI_NETTI = @PlvRicaviNettiequalthis)'; set @lensql=@lensql+len(@PlvRicaviNettiequalthis);end;
	IF (@PlvRicaviAttivitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLV_RICAVI_ATTIVITA = @PlvRicaviAttivitaequalthis)'; set @lensql=@lensql+len(@PlvRicaviAttivitaequalthis);end;
	IF (@PlvRimanenzeFinaliequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLV_RIMANENZE_FINALI = @PlvRimanenzeFinaliequalthis)'; set @lensql=@lensql+len(@PlvRimanenzeFinaliequalthis);end;
	IF (@PlvRimanenzeInizialiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLV_RIMANENZE_INIZIALI = @PlvRimanenzeInizialiequalthis)'; set @lensql=@lensql+len(@PlvRimanenzeInizialiequalthis);end;
	IF (@VaCostiMatPrimeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VA_COSTI_MAT_PRIME = @VaCostiMatPrimeequalthis)'; set @lensql=@lensql+len(@VaCostiMatPrimeequalthis);end;
	IF (@VaCostiAttConnesseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VA_COSTI_ATT_CONNESSE = @VaCostiAttConnesseequalthis)'; set @lensql=@lensql+len(@VaCostiAttConnesseequalthis);end;
	IF (@VaNoleggiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VA_NOLEGGI = @VaNoleggiequalthis)'; set @lensql=@lensql+len(@VaNoleggiequalthis);end;
	IF (@VaManutenzioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VA_MANUTENZIONI = @VaManutenzioniequalthis)'; set @lensql=@lensql+len(@VaManutenzioniequalthis);end;
	IF (@VaSpeseGeneraliequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VA_SPESE_GENERALI = @VaSpeseGeneraliequalthis)'; set @lensql=@lensql+len(@VaSpeseGeneraliequalthis);end;
	IF (@VaAffittiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VA_AFFITTI = @VaAffittiequalthis)'; set @lensql=@lensql+len(@VaAffittiequalthis);end;
	IF (@VaAltriCostiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VA_ALTRI_COSTI = @VaAltriCostiequalthis)'; set @lensql=@lensql+len(@VaAltriCostiequalthis);end;
	IF (@PnAmmMacchineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PN_AMM_MACCHINE = @PnAmmMacchineequalthis)'; set @lensql=@lensql+len(@PnAmmMacchineequalthis);end;
	IF (@PnAmmFabbricatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PN_AMM_FABBRICATI = @PnAmmFabbricatiequalthis)'; set @lensql=@lensql+len(@PnAmmFabbricatiequalthis);end;
	IF (@PnAmmPiantagioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PN_AMM_PIANTAGIONI = @PnAmmPiantagioniequalthis)'; set @lensql=@lensql+len(@PnAmmPiantagioniequalthis);end;
	IF (@RoSalariequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RO_SALARI = @RoSalariequalthis)'; set @lensql=@lensql+len(@RoSalariequalthis);end;
	IF (@RoOneriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RO_ONERI = @RoOneriequalthis)'; set @lensql=@lensql+len(@RoOneriequalthis);end;
	IF (@RnPacRicaviequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RN_PAC_RICAVI = @RnPacRicaviequalthis)'; set @lensql=@lensql+len(@RnPacRicaviequalthis);end;
	IF (@RnPacCostiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RN_PAC_COSTI = @RnPacCostiequalthis)'; set @lensql=@lensql+len(@RnPacCostiequalthis);end;
	IF (@RnPacProventiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RN_PAC_PROVENTI = @RnPacProventiequalthis)'; set @lensql=@lensql+len(@RnPacProventiequalthis);end;
	IF (@RnPacPerditeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RN_PAC_PERDITE = @RnPacPerditeequalthis)'; set @lensql=@lensql+len(@RnPacPerditeequalthis);end;
	IF (@RnPacInteressiAttiviequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RN_PAC_INTERESSI_ATTIVI = @RnPacInteressiAttiviequalthis)'; set @lensql=@lensql+len(@RnPacInteressiAttiviequalthis);end;
	IF (@RnPacInteressiPassiviequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RN_PAC_INTERESSI_PASSIVI = @RnPacInteressiPassiviequalthis)'; set @lensql=@lensql+len(@RnPacInteressiPassiviequalthis);end;
	IF (@RnPacImposteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RN_PAC_IMPOSTE = @RnPacImposteequalthis)'; set @lensql=@lensql+len(@RnPacImposteequalthis);end;
	IF (@RnPacContributiPacequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RN_PAC_CONTRIBUTI_PAC = @RnPacContributiPacequalthis)'; set @lensql=@lensql+len(@RnPacContributiPacequalthis);end;
	IF (@MnlRedditiFamequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MNL_REDDITI_FAM = @MnlRedditiFamequalthis)'; set @lensql=@lensql+len(@MnlRedditiFamequalthis);end;
	IF (@MnlRimborsoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MNL_RIMBORSO = @MnlRimborsoequalthis)'; set @lensql=@lensql+len(@MnlRimborsoequalthis);end;
	IF (@MnlPrelieviequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MNL_PRELIEVI = @MnlPrelieviequalthis)'; set @lensql=@lensql+len(@MnlPrelieviequalthis);end;
	IF (@CfCfTerreniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_CF_TERRENI = @CfCfTerreniequalthis)'; set @lensql=@lensql+len(@CfCfTerreniequalthis);end;
	IF (@CfCfImpiantiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_CF_IMPIANTI = @CfCfImpiantiequalthis)'; set @lensql=@lensql+len(@CfCfImpiantiequalthis);end;
	IF (@CfCfPiantagioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_CF_PIANTAGIONI = @CfCfPiantagioniequalthis)'; set @lensql=@lensql+len(@CfCfPiantagioniequalthis);end;
	IF (@CfCfMiglioramentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_CF_MIGLIORAMENTI = @CfCfMiglioramentiequalthis)'; set @lensql=@lensql+len(@CfCfMiglioramentiequalthis);end;
	IF (@CfCaMacchineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_CA_MACCHINE = @CfCaMacchineequalthis)'; set @lensql=@lensql+len(@CfCaMacchineequalthis);end;
	IF (@CfCaBestiameequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_CA_BESTIAME = @CfCaBestiameequalthis)'; set @lensql=@lensql+len(@CfCaBestiameequalthis);end;
	IF (@CfIfPartecipazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_IF_PARTECIPAZIONI = @CfIfPartecipazioniequalthis)'; set @lensql=@lensql+len(@CfIfPartecipazioniequalthis);end;
	IF (@CcDfRimanenzeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CC_DF_RIMANENZE = @CcDfRimanenzeequalthis)'; set @lensql=@lensql+len(@CcDfRimanenzeequalthis);end;
	IF (@CcDfAnticipazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CC_DF_ANTICIPAZIONI = @CcDfAnticipazioniequalthis)'; set @lensql=@lensql+len(@CcDfAnticipazioniequalthis);end;
	IF (@CcLdCreditiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CC_LD_CREDITI = @CcLdCreditiequalthis)'; set @lensql=@lensql+len(@CcLdCreditiequalthis);end;
	IF (@CcLiBancaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CC_LI_BANCA = @CcLiBancaequalthis)'; set @lensql=@lensql+len(@CcLiBancaequalthis);end;
	IF (@CcLiCassaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CC_LI_CASSA = @CcLiCassaequalthis)'; set @lensql=@lensql+len(@CcLiCassaequalthis);end;
	IF (@FfPcDebitiBreveTermineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FF_PC_DEBITI_BREVE_TERMINE = @FfPcDebitiBreveTermineequalthis)'; set @lensql=@lensql+len(@FfPcDebitiBreveTermineequalthis);end;
	IF (@FfPcFornitoriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FF_PC_FORNITORI = @FfPcFornitoriequalthis)'; set @lensql=@lensql+len(@FfPcFornitoriequalthis);end;
	IF (@FfPcDebitiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FF_PC_DEBITI = @FfPcDebitiequalthis)'; set @lensql=@lensql+len(@FfPcDebitiequalthis);end;
	IF (@FfPcMutuiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FF_PC_MUTUI = @FfPcMutuiequalthis)'; set @lensql=@lensql+len(@FfPcMutuiequalthis);end;
	IF (@FfMpCapitaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FF_MP_CAPITALE = @FfMpCapitaleequalthis)'; set @lensql=@lensql+len(@FfMpCapitaleequalthis);end;
	IF (@FfMpRiserveequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FF_MP_RISERVE = @FfMpRiserveequalthis)'; set @lensql=@lensql+len(@FfMpRiserveequalthis);end;
	IF (@FfMpUtileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FF_MP_UTILE = @FfMpUtileequalthis)'; set @lensql=@lensql+len(@FfMpUtileequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBilancioAgricoloequalthis INT, @IdImpresaequalthis INT, @IdProgettoequalthis INT, @Annoequalthis INT, @DataBilancioequalthis DATETIME, @Previsionaleequalthis BIT, @DataModificaequalthis DATETIME, @PlvRicaviNettiequalthis DECIMAL(15,2), @PlvRicaviAttivitaequalthis DECIMAL(15,2), @PlvRimanenzeFinaliequalthis DECIMAL(15,2), @PlvRimanenzeInizialiequalthis DECIMAL(15,2), @VaCostiMatPrimeequalthis DECIMAL(15,2), @VaCostiAttConnesseequalthis DECIMAL(15,2), @VaNoleggiequalthis DECIMAL(15,2), @VaManutenzioniequalthis DECIMAL(15,2), @VaSpeseGeneraliequalthis DECIMAL(15,2), @VaAffittiequalthis DECIMAL(15,2), @VaAltriCostiequalthis DECIMAL(15,2), @PnAmmMacchineequalthis DECIMAL(15,2), @PnAmmFabbricatiequalthis DECIMAL(15,2), @PnAmmPiantagioniequalthis DECIMAL(15,2), @RoSalariequalthis DECIMAL(15,2), @RoOneriequalthis DECIMAL(15,2), @RnPacRicaviequalthis DECIMAL(15,2), @RnPacCostiequalthis DECIMAL(15,2), @RnPacProventiequalthis DECIMAL(15,2), @RnPacPerditeequalthis DECIMAL(15,2), @RnPacInteressiAttiviequalthis DECIMAL(15,2), @RnPacInteressiPassiviequalthis DECIMAL(15,2), @RnPacImposteequalthis DECIMAL(15,2), @RnPacContributiPacequalthis DECIMAL(15,2), @MnlRedditiFamequalthis DECIMAL(15,2), @MnlRimborsoequalthis DECIMAL(15,2), @MnlPrelieviequalthis DECIMAL(15,2), @CfCfTerreniequalthis DECIMAL(15,2), @CfCfImpiantiequalthis DECIMAL(15,2), @CfCfPiantagioniequalthis DECIMAL(15,2), @CfCfMiglioramentiequalthis DECIMAL(15,2), @CfCaMacchineequalthis DECIMAL(15,2), @CfCaBestiameequalthis DECIMAL(15,2), @CfIfPartecipazioniequalthis DECIMAL(15,2), @CcDfRimanenzeequalthis DECIMAL(15,2), @CcDfAnticipazioniequalthis DECIMAL(15,2), @CcLdCreditiequalthis DECIMAL(15,2), @CcLiBancaequalthis DECIMAL(15,2), @CcLiCassaequalthis DECIMAL(15,2), @FfPcDebitiBreveTermineequalthis DECIMAL(15,2), @FfPcFornitoriequalthis DECIMAL(15,2), @FfPcDebitiequalthis DECIMAL(15,2), @FfPcMutuiequalthis DECIMAL(15,2), @FfMpCapitaleequalthis DECIMAL(15,2), @FfMpRiserveequalthis DECIMAL(15,2), @FfMpUtileequalthis DECIMAL(15,2)',@IdBilancioAgricoloequalthis , @IdImpresaequalthis , @IdProgettoequalthis , @Annoequalthis , @DataBilancioequalthis , @Previsionaleequalthis , @DataModificaequalthis , @PlvRicaviNettiequalthis , @PlvRicaviAttivitaequalthis , @PlvRimanenzeFinaliequalthis , @PlvRimanenzeInizialiequalthis , @VaCostiMatPrimeequalthis , @VaCostiAttConnesseequalthis , @VaNoleggiequalthis , @VaManutenzioniequalthis , @VaSpeseGeneraliequalthis , @VaAffittiequalthis , @VaAltriCostiequalthis , @PnAmmMacchineequalthis , @PnAmmFabbricatiequalthis , @PnAmmPiantagioniequalthis , @RoSalariequalthis , @RoOneriequalthis , @RnPacRicaviequalthis , @RnPacCostiequalthis , @RnPacProventiequalthis , @RnPacPerditeequalthis , @RnPacInteressiAttiviequalthis , @RnPacInteressiPassiviequalthis , @RnPacImposteequalthis , @RnPacContributiPacequalthis , @MnlRedditiFamequalthis , @MnlRimborsoequalthis , @MnlPrelieviequalthis , @CfCfTerreniequalthis , @CfCfImpiantiequalthis , @CfCfPiantagioniequalthis , @CfCfMiglioramentiequalthis , @CfCaMacchineequalthis , @CfCaBestiameequalthis , @CfIfPartecipazioniequalthis , @CcDfRimanenzeequalthis , @CcDfAnticipazioniequalthis , @CcLdCreditiequalthis , @CcLiBancaequalthis , @CcLiCassaequalthis , @FfPcDebitiBreveTermineequalthis , @FfPcFornitoriequalthis , @FfPcDebitiequalthis , @FfPcMutuiequalthis , @FfMpCapitaleequalthis , @FfMpRiserveequalthis , @FfMpUtileequalthis ;
	else
		SELECT ID_BILANCIO_AGRICOLO, ID_IMPRESA, ID_PROGETTO, ANNO, DATA_BILANCIO, PREVISIONALE, DATA_MODIFICA, PLV_RICAVI_NETTI, PLV_RICAVI_ATTIVITA, PLV_RIMANENZE_FINALI, PLV_RIMANENZE_INIZIALI, VA_COSTI_MAT_PRIME, VA_COSTI_ATT_CONNESSE, VA_NOLEGGI, VA_MANUTENZIONI, VA_SPESE_GENERALI, VA_AFFITTI, VA_ALTRI_COSTI, PN_AMM_MACCHINE, PN_AMM_FABBRICATI, PN_AMM_PIANTAGIONI, RO_SALARI, RO_ONERI, RN_PAC_RICAVI, RN_PAC_COSTI, RN_PAC_PROVENTI, RN_PAC_PERDITE, RN_PAC_INTERESSI_ATTIVI, RN_PAC_INTERESSI_PASSIVI, RN_PAC_IMPOSTE, RN_PAC_CONTRIBUTI_PAC, MNL_REDDITI_FAM, MNL_RIMBORSO, MNL_PRELIEVI, CF_CF_TERRENI, CF_CF_IMPIANTI, CF_CF_PIANTAGIONI, CF_CF_MIGLIORAMENTI, CF_CA_MACCHINE, CF_CA_BESTIAME, CF_IF_PARTECIPAZIONI, CC_DF_RIMANENZE, CC_DF_ANTICIPAZIONI, CC_LD_CREDITI, CC_LI_BANCA, CC_LI_CASSA, FF_PC_DEBITI_BREVE_TERMINE, FF_PC_FORNITORI, FF_PC_DEBITI, FF_PC_MUTUI, FF_MP_CAPITALE, FF_MP_RISERVE, FF_MP_UTILE
		FROM BILANCIO_AGRICOLO
		WHERE 
			((@IdBilancioAgricoloequalthis IS NULL) OR ID_BILANCIO_AGRICOLO = @IdBilancioAgricoloequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@DataBilancioequalthis IS NULL) OR DATA_BILANCIO = @DataBilancioequalthis) AND 
			((@Previsionaleequalthis IS NULL) OR PREVISIONALE = @Previsionaleequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@PlvRicaviNettiequalthis IS NULL) OR PLV_RICAVI_NETTI = @PlvRicaviNettiequalthis) AND 
			((@PlvRicaviAttivitaequalthis IS NULL) OR PLV_RICAVI_ATTIVITA = @PlvRicaviAttivitaequalthis) AND 
			((@PlvRimanenzeFinaliequalthis IS NULL) OR PLV_RIMANENZE_FINALI = @PlvRimanenzeFinaliequalthis) AND 
			((@PlvRimanenzeInizialiequalthis IS NULL) OR PLV_RIMANENZE_INIZIALI = @PlvRimanenzeInizialiequalthis) AND 
			((@VaCostiMatPrimeequalthis IS NULL) OR VA_COSTI_MAT_PRIME = @VaCostiMatPrimeequalthis) AND 
			((@VaCostiAttConnesseequalthis IS NULL) OR VA_COSTI_ATT_CONNESSE = @VaCostiAttConnesseequalthis) AND 
			((@VaNoleggiequalthis IS NULL) OR VA_NOLEGGI = @VaNoleggiequalthis) AND 
			((@VaManutenzioniequalthis IS NULL) OR VA_MANUTENZIONI = @VaManutenzioniequalthis) AND 
			((@VaSpeseGeneraliequalthis IS NULL) OR VA_SPESE_GENERALI = @VaSpeseGeneraliequalthis) AND 
			((@VaAffittiequalthis IS NULL) OR VA_AFFITTI = @VaAffittiequalthis) AND 
			((@VaAltriCostiequalthis IS NULL) OR VA_ALTRI_COSTI = @VaAltriCostiequalthis) AND 
			((@PnAmmMacchineequalthis IS NULL) OR PN_AMM_MACCHINE = @PnAmmMacchineequalthis) AND 
			((@PnAmmFabbricatiequalthis IS NULL) OR PN_AMM_FABBRICATI = @PnAmmFabbricatiequalthis) AND 
			((@PnAmmPiantagioniequalthis IS NULL) OR PN_AMM_PIANTAGIONI = @PnAmmPiantagioniequalthis) AND 
			((@RoSalariequalthis IS NULL) OR RO_SALARI = @RoSalariequalthis) AND 
			((@RoOneriequalthis IS NULL) OR RO_ONERI = @RoOneriequalthis) AND 
			((@RnPacRicaviequalthis IS NULL) OR RN_PAC_RICAVI = @RnPacRicaviequalthis) AND 
			((@RnPacCostiequalthis IS NULL) OR RN_PAC_COSTI = @RnPacCostiequalthis) AND 
			((@RnPacProventiequalthis IS NULL) OR RN_PAC_PROVENTI = @RnPacProventiequalthis) AND 
			((@RnPacPerditeequalthis IS NULL) OR RN_PAC_PERDITE = @RnPacPerditeequalthis) AND 
			((@RnPacInteressiAttiviequalthis IS NULL) OR RN_PAC_INTERESSI_ATTIVI = @RnPacInteressiAttiviequalthis) AND 
			((@RnPacInteressiPassiviequalthis IS NULL) OR RN_PAC_INTERESSI_PASSIVI = @RnPacInteressiPassiviequalthis) AND 
			((@RnPacImposteequalthis IS NULL) OR RN_PAC_IMPOSTE = @RnPacImposteequalthis) AND 
			((@RnPacContributiPacequalthis IS NULL) OR RN_PAC_CONTRIBUTI_PAC = @RnPacContributiPacequalthis) AND 
			((@MnlRedditiFamequalthis IS NULL) OR MNL_REDDITI_FAM = @MnlRedditiFamequalthis) AND 
			((@MnlRimborsoequalthis IS NULL) OR MNL_RIMBORSO = @MnlRimborsoequalthis) AND 
			((@MnlPrelieviequalthis IS NULL) OR MNL_PRELIEVI = @MnlPrelieviequalthis) AND 
			((@CfCfTerreniequalthis IS NULL) OR CF_CF_TERRENI = @CfCfTerreniequalthis) AND 
			((@CfCfImpiantiequalthis IS NULL) OR CF_CF_IMPIANTI = @CfCfImpiantiequalthis) AND 
			((@CfCfPiantagioniequalthis IS NULL) OR CF_CF_PIANTAGIONI = @CfCfPiantagioniequalthis) AND 
			((@CfCfMiglioramentiequalthis IS NULL) OR CF_CF_MIGLIORAMENTI = @CfCfMiglioramentiequalthis) AND 
			((@CfCaMacchineequalthis IS NULL) OR CF_CA_MACCHINE = @CfCaMacchineequalthis) AND 
			((@CfCaBestiameequalthis IS NULL) OR CF_CA_BESTIAME = @CfCaBestiameequalthis) AND 
			((@CfIfPartecipazioniequalthis IS NULL) OR CF_IF_PARTECIPAZIONI = @CfIfPartecipazioniequalthis) AND 
			((@CcDfRimanenzeequalthis IS NULL) OR CC_DF_RIMANENZE = @CcDfRimanenzeequalthis) AND 
			((@CcDfAnticipazioniequalthis IS NULL) OR CC_DF_ANTICIPAZIONI = @CcDfAnticipazioniequalthis) AND 
			((@CcLdCreditiequalthis IS NULL) OR CC_LD_CREDITI = @CcLdCreditiequalthis) AND 
			((@CcLiBancaequalthis IS NULL) OR CC_LI_BANCA = @CcLiBancaequalthis) AND 
			((@CcLiCassaequalthis IS NULL) OR CC_LI_CASSA = @CcLiCassaequalthis) AND 
			((@FfPcDebitiBreveTermineequalthis IS NULL) OR FF_PC_DEBITI_BREVE_TERMINE = @FfPcDebitiBreveTermineequalthis) AND 
			((@FfPcFornitoriequalthis IS NULL) OR FF_PC_FORNITORI = @FfPcFornitoriequalthis) AND 
			((@FfPcDebitiequalthis IS NULL) OR FF_PC_DEBITI = @FfPcDebitiequalthis) AND 
			((@FfPcMutuiequalthis IS NULL) OR FF_PC_MUTUI = @FfPcMutuiequalthis) AND 
			((@FfMpCapitaleequalthis IS NULL) OR FF_MP_CAPITALE = @FfMpCapitaleequalthis) AND 
			((@FfMpRiserveequalthis IS NULL) OR FF_MP_RISERVE = @FfMpRiserveequalthis) AND 
			((@FfMpUtileequalthis IS NULL) OR FF_MP_UTILE = @FfMpUtileequalthis)
