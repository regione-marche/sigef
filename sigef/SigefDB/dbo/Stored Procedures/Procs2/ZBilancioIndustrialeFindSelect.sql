
CREATE PROCEDURE [dbo].[ZBilancioIndustrialeFindSelect]
(
	@IdBilancioIndustrialeequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdProgettoequalthis INT, 
	@Annoequalthis INT, 
	@DataBilancioequalthis DATETIME, 
	@Previsionaleequalthis BIT, 
	@DataModificaequalthis DATETIME, 
	@PlvRicaviVenditaequalthis DECIMAL(15,2), 
	@PlvAltriRicaviequalthis DECIMAL(15,2), 
	@CpMateriePrimeequalthis DECIMAL(15,2), 
	@CpServiziequalthis DECIMAL(15,2), 
	@CpBeniTerziequalthis DECIMAL(15,2), 
	@CpPersonaleequalthis DECIMAL(15,2), 
	@CpAmmSvalutazioniequalthis DECIMAL(15,2), 
	@CpVarRimanenzeequalthis DECIMAL(15,2), 
	@CpOneriequalthis DECIMAL(15,2), 
	@PofAltriProventiequalthis DECIMAL(15,2), 
	@PofInteressiOneriequalthis DECIMAL(15,2), 
	@RettValAttFinanziarieequalthis DECIMAL(15,2), 
	@PosProventiStraordequalthis DECIMAL(15,2), 
	@PosOneriStraordequalthis DECIMAL(15,2), 
	@TotPrimaImposteequalthis DECIMAL(15,2), 
	@ImposteRedditoequalthis DECIMAL(15,2), 
	@TaCreditiSociequalthis DECIMAL(15,2), 
	@TaImmImmaterialiequalthis DECIMAL(15,2), 
	@TaImmobMaterialiequalthis DECIMAL(15,2), 
	@TaImmPartecipazioniequalthis DECIMAL(15,2), 
	@TaImmCreditiequalthis DECIMAL(15,2), 
	@TaAcRimanenzeequalthis DECIMAL(15,2), 
	@TaAcCreditiClientiequalthis DECIMAL(15,2), 
	@TaAcCreditiAltriequalthis DECIMAL(15,2), 
	@TaAcDepPostaliequalthis DECIMAL(15,2), 
	@TaAcDispoLiquideequalthis DECIMAL(15,2), 
	@TaRateiRiscontiequalthis DECIMAL(15,2), 
	@TpPnCapitaleequalthis DECIMAL(15,2), 
	@TpPnSovrapAzioniequalthis DECIMAL(15,2), 
	@TpPnRisRivalutazioneequalthis DECIMAL(15,2), 
	@TpPnRisLegaleequalthis DECIMAL(15,2), 
	@TpPnAzioniProprieequalthis DECIMAL(15,2), 
	@TpPnRiserva904equalthis DECIMAL(15,2), 
	@TpPnRiserveStatutarieequalthis DECIMAL(15,2), 
	@TpPnAltreRiserveequalthis DECIMAL(15,2), 
	@TpPnUtiliPrecedentiequalthis DECIMAL(15,2), 
	@TpPnUtiliEsercizioequalthis DECIMAL(15,2), 
	@TpFondiRischiOneriequalthis DECIMAL(15,2), 
	@TpFineRapportoequalthis DECIMAL(15,2), 
	@TpDebitiBancheequalthis DECIMAL(15,2), 
	@TpDebitiFinanziatoriequalthis DECIMAL(15,2), 
	@TpDebitiFornitoriequalthis DECIMAL(15,2), 
	@TpDebitiIstPrevidequalthis DECIMAL(15,2), 
	@TpAltriDebitiequalthis DECIMAL(15,2), 
	@TpRateiRiscontiequalthis DECIMAL(15,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BILANCIO_INDUSTRIALE, ID_IMPRESA, ID_PROGETTO, ANNO, DATA_BILANCIO, PREVISIONALE, DATA_MODIFICA, PLV_RICAVI_VENDITA, PLV_ALTRI_RICAVI, CP_MATERIE_PRIME, CP_SERVIZI, CP_BENI_TERZI, CP_PERSONALE, CP_AMM_SVALUTAZIONI, CP_VAR_RIMANENZE, CP_ONERI, POF_ALTRI_PROVENTI, POF_INTERESSI_ONERI, RETT_VAL_ATT_FINANZIARIE, POS_PROVENTI_STRAORD, POS_ONERI_STRAORD, TOT_PRIMA_IMPOSTE, IMPOSTE_REDDITO, TA_CREDITI_SOCI, TA_IMM_IMMATERIALI, TA_IMMOB_MATERIALI, TA_IMM_PARTECIPAZIONI, TA_IMM_CREDITI, TA_AC_RIMANENZE, TA_AC_CREDITI_CLIENTI, TA_AC_CREDITI_ALTRI, TA_AC_DEP_POSTALI, TA_AC_DISPO_LIQUIDE, TA_RATEI_RISCONTI, TP_PN_CAPITALE, TP_PN_SOVRAP_AZIONI, TP_PN_RIS_RIVALUTAZIONE, TP_PN_RIS_LEGALE, TP_PN_AZIONI_PROPRIE, TP_PN_RISERVA_904, TP_PN_RISERVE_STATUTARIE, TP_PN_ALTRE_RISERVE, TP_PN_UTILI_PRECEDENTI, TP_PN_UTILI_ESERCIZIO, TP_FONDI_RISCHI_ONERI, TP_FINE_RAPPORTO, TP_DEBITI_BANCHE, TP_DEBITI_FINANZIATORI, TP_DEBITI_FORNITORI, TP_DEBITI_IST_PREVID, TP_ALTRI_DEBITI, TP_RATEI_RISCONTI, NOTA_INTEGRATIVA FROM BILANCIO_INDUSTRIALE WHERE 1=1';
	IF (@IdBilancioIndustrialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BILANCIO_INDUSTRIALE = @IdBilancioIndustrialeequalthis)'; set @lensql=@lensql+len(@IdBilancioIndustrialeequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@DataBilancioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_BILANCIO = @DataBilancioequalthis)'; set @lensql=@lensql+len(@DataBilancioequalthis);end;
	IF (@Previsionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREVISIONALE = @Previsionaleequalthis)'; set @lensql=@lensql+len(@Previsionaleequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@PlvRicaviVenditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLV_RICAVI_VENDITA = @PlvRicaviVenditaequalthis)'; set @lensql=@lensql+len(@PlvRicaviVenditaequalthis);end;
	IF (@PlvAltriRicaviequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLV_ALTRI_RICAVI = @PlvAltriRicaviequalthis)'; set @lensql=@lensql+len(@PlvAltriRicaviequalthis);end;
	IF (@CpMateriePrimeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CP_MATERIE_PRIME = @CpMateriePrimeequalthis)'; set @lensql=@lensql+len(@CpMateriePrimeequalthis);end;
	IF (@CpServiziequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CP_SERVIZI = @CpServiziequalthis)'; set @lensql=@lensql+len(@CpServiziequalthis);end;
	IF (@CpBeniTerziequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CP_BENI_TERZI = @CpBeniTerziequalthis)'; set @lensql=@lensql+len(@CpBeniTerziequalthis);end;
	IF (@CpPersonaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CP_PERSONALE = @CpPersonaleequalthis)'; set @lensql=@lensql+len(@CpPersonaleequalthis);end;
	IF (@CpAmmSvalutazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CP_AMM_SVALUTAZIONI = @CpAmmSvalutazioniequalthis)'; set @lensql=@lensql+len(@CpAmmSvalutazioniequalthis);end;
	IF (@CpVarRimanenzeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CP_VAR_RIMANENZE = @CpVarRimanenzeequalthis)'; set @lensql=@lensql+len(@CpVarRimanenzeequalthis);end;
	IF (@CpOneriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CP_ONERI = @CpOneriequalthis)'; set @lensql=@lensql+len(@CpOneriequalthis);end;
	IF (@PofAltriProventiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (POF_ALTRI_PROVENTI = @PofAltriProventiequalthis)'; set @lensql=@lensql+len(@PofAltriProventiequalthis);end;
	IF (@PofInteressiOneriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (POF_INTERESSI_ONERI = @PofInteressiOneriequalthis)'; set @lensql=@lensql+len(@PofInteressiOneriequalthis);end;
	IF (@RettValAttFinanziarieequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RETT_VAL_ATT_FINANZIARIE = @RettValAttFinanziarieequalthis)'; set @lensql=@lensql+len(@RettValAttFinanziarieequalthis);end;
	IF (@PosProventiStraordequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (POS_PROVENTI_STRAORD = @PosProventiStraordequalthis)'; set @lensql=@lensql+len(@PosProventiStraordequalthis);end;
	IF (@PosOneriStraordequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (POS_ONERI_STRAORD = @PosOneriStraordequalthis)'; set @lensql=@lensql+len(@PosOneriStraordequalthis);end;
	IF (@TotPrimaImposteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOT_PRIMA_IMPOSTE = @TotPrimaImposteequalthis)'; set @lensql=@lensql+len(@TotPrimaImposteequalthis);end;
	IF (@ImposteRedditoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPOSTE_REDDITO = @ImposteRedditoequalthis)'; set @lensql=@lensql+len(@ImposteRedditoequalthis);end;
	IF (@TaCreditiSociequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_CREDITI_SOCI = @TaCreditiSociequalthis)'; set @lensql=@lensql+len(@TaCreditiSociequalthis);end;
	IF (@TaImmImmaterialiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_IMM_IMMATERIALI = @TaImmImmaterialiequalthis)'; set @lensql=@lensql+len(@TaImmImmaterialiequalthis);end;
	IF (@TaImmobMaterialiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_IMMOB_MATERIALI = @TaImmobMaterialiequalthis)'; set @lensql=@lensql+len(@TaImmobMaterialiequalthis);end;
	IF (@TaImmPartecipazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_IMM_PARTECIPAZIONI = @TaImmPartecipazioniequalthis)'; set @lensql=@lensql+len(@TaImmPartecipazioniequalthis);end;
	IF (@TaImmCreditiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_IMM_CREDITI = @TaImmCreditiequalthis)'; set @lensql=@lensql+len(@TaImmCreditiequalthis);end;
	IF (@TaAcRimanenzeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_AC_RIMANENZE = @TaAcRimanenzeequalthis)'; set @lensql=@lensql+len(@TaAcRimanenzeequalthis);end;
	IF (@TaAcCreditiClientiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_AC_CREDITI_CLIENTI = @TaAcCreditiClientiequalthis)'; set @lensql=@lensql+len(@TaAcCreditiClientiequalthis);end;
	IF (@TaAcCreditiAltriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_AC_CREDITI_ALTRI = @TaAcCreditiAltriequalthis)'; set @lensql=@lensql+len(@TaAcCreditiAltriequalthis);end;
	IF (@TaAcDepPostaliequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_AC_DEP_POSTALI = @TaAcDepPostaliequalthis)'; set @lensql=@lensql+len(@TaAcDepPostaliequalthis);end;
	IF (@TaAcDispoLiquideequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_AC_DISPO_LIQUIDE = @TaAcDispoLiquideequalthis)'; set @lensql=@lensql+len(@TaAcDispoLiquideequalthis);end;
	IF (@TaRateiRiscontiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TA_RATEI_RISCONTI = @TaRateiRiscontiequalthis)'; set @lensql=@lensql+len(@TaRateiRiscontiequalthis);end;
	IF (@TpPnCapitaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_PN_CAPITALE = @TpPnCapitaleequalthis)'; set @lensql=@lensql+len(@TpPnCapitaleequalthis);end;
	IF (@TpPnSovrapAzioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_PN_SOVRAP_AZIONI = @TpPnSovrapAzioniequalthis)'; set @lensql=@lensql+len(@TpPnSovrapAzioniequalthis);end;
	IF (@TpPnRisRivalutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_PN_RIS_RIVALUTAZIONE = @TpPnRisRivalutazioneequalthis)'; set @lensql=@lensql+len(@TpPnRisRivalutazioneequalthis);end;
	IF (@TpPnRisLegaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_PN_RIS_LEGALE = @TpPnRisLegaleequalthis)'; set @lensql=@lensql+len(@TpPnRisLegaleequalthis);end;
	IF (@TpPnAzioniProprieequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_PN_AZIONI_PROPRIE = @TpPnAzioniProprieequalthis)'; set @lensql=@lensql+len(@TpPnAzioniProprieequalthis);end;
	IF (@TpPnRiserva904equalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_PN_RISERVA_904 = @TpPnRiserva904equalthis)'; set @lensql=@lensql+len(@TpPnRiserva904equalthis);end;
	IF (@TpPnRiserveStatutarieequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_PN_RISERVE_STATUTARIE = @TpPnRiserveStatutarieequalthis)'; set @lensql=@lensql+len(@TpPnRiserveStatutarieequalthis);end;
	IF (@TpPnAltreRiserveequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_PN_ALTRE_RISERVE = @TpPnAltreRiserveequalthis)'; set @lensql=@lensql+len(@TpPnAltreRiserveequalthis);end;
	IF (@TpPnUtiliPrecedentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_PN_UTILI_PRECEDENTI = @TpPnUtiliPrecedentiequalthis)'; set @lensql=@lensql+len(@TpPnUtiliPrecedentiequalthis);end;
	IF (@TpPnUtiliEsercizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_PN_UTILI_ESERCIZIO = @TpPnUtiliEsercizioequalthis)'; set @lensql=@lensql+len(@TpPnUtiliEsercizioequalthis);end;
	IF (@TpFondiRischiOneriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_FONDI_RISCHI_ONERI = @TpFondiRischiOneriequalthis)'; set @lensql=@lensql+len(@TpFondiRischiOneriequalthis);end;
	IF (@TpFineRapportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_FINE_RAPPORTO = @TpFineRapportoequalthis)'; set @lensql=@lensql+len(@TpFineRapportoequalthis);end;
	IF (@TpDebitiBancheequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_DEBITI_BANCHE = @TpDebitiBancheequalthis)'; set @lensql=@lensql+len(@TpDebitiBancheequalthis);end;
	IF (@TpDebitiFinanziatoriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_DEBITI_FINANZIATORI = @TpDebitiFinanziatoriequalthis)'; set @lensql=@lensql+len(@TpDebitiFinanziatoriequalthis);end;
	IF (@TpDebitiFornitoriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_DEBITI_FORNITORI = @TpDebitiFornitoriequalthis)'; set @lensql=@lensql+len(@TpDebitiFornitoriequalthis);end;
	IF (@TpDebitiIstPrevidequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_DEBITI_IST_PREVID = @TpDebitiIstPrevidequalthis)'; set @lensql=@lensql+len(@TpDebitiIstPrevidequalthis);end;
	IF (@TpAltriDebitiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_ALTRI_DEBITI = @TpAltriDebitiequalthis)'; set @lensql=@lensql+len(@TpAltriDebitiequalthis);end;
	IF (@TpRateiRiscontiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TP_RATEI_RISCONTI = @TpRateiRiscontiequalthis)'; set @lensql=@lensql+len(@TpRateiRiscontiequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBilancioIndustrialeequalthis INT, @IdImpresaequalthis INT, @IdProgettoequalthis INT, @Annoequalthis INT, @DataBilancioequalthis DATETIME, @Previsionaleequalthis BIT, @DataModificaequalthis DATETIME, @PlvRicaviVenditaequalthis DECIMAL(15,2), @PlvAltriRicaviequalthis DECIMAL(15,2), @CpMateriePrimeequalthis DECIMAL(15,2), @CpServiziequalthis DECIMAL(15,2), @CpBeniTerziequalthis DECIMAL(15,2), @CpPersonaleequalthis DECIMAL(15,2), @CpAmmSvalutazioniequalthis DECIMAL(15,2), @CpVarRimanenzeequalthis DECIMAL(15,2), @CpOneriequalthis DECIMAL(15,2), @PofAltriProventiequalthis DECIMAL(15,2), @PofInteressiOneriequalthis DECIMAL(15,2), @RettValAttFinanziarieequalthis DECIMAL(15,2), @PosProventiStraordequalthis DECIMAL(15,2), @PosOneriStraordequalthis DECIMAL(15,2), @TotPrimaImposteequalthis DECIMAL(15,2), @ImposteRedditoequalthis DECIMAL(15,2), @TaCreditiSociequalthis DECIMAL(15,2), @TaImmImmaterialiequalthis DECIMAL(15,2), @TaImmobMaterialiequalthis DECIMAL(15,2), @TaImmPartecipazioniequalthis DECIMAL(15,2), @TaImmCreditiequalthis DECIMAL(15,2), @TaAcRimanenzeequalthis DECIMAL(15,2), @TaAcCreditiClientiequalthis DECIMAL(15,2), @TaAcCreditiAltriequalthis DECIMAL(15,2), @TaAcDepPostaliequalthis DECIMAL(15,2), @TaAcDispoLiquideequalthis DECIMAL(15,2), @TaRateiRiscontiequalthis DECIMAL(15,2), @TpPnCapitaleequalthis DECIMAL(15,2), @TpPnSovrapAzioniequalthis DECIMAL(15,2), @TpPnRisRivalutazioneequalthis DECIMAL(15,2), @TpPnRisLegaleequalthis DECIMAL(15,2), @TpPnAzioniProprieequalthis DECIMAL(15,2), @TpPnRiserva904equalthis DECIMAL(15,2), @TpPnRiserveStatutarieequalthis DECIMAL(15,2), @TpPnAltreRiserveequalthis DECIMAL(15,2), @TpPnUtiliPrecedentiequalthis DECIMAL(15,2), @TpPnUtiliEsercizioequalthis DECIMAL(15,2), @TpFondiRischiOneriequalthis DECIMAL(15,2), @TpFineRapportoequalthis DECIMAL(15,2), @TpDebitiBancheequalthis DECIMAL(15,2), @TpDebitiFinanziatoriequalthis DECIMAL(15,2), @TpDebitiFornitoriequalthis DECIMAL(15,2), @TpDebitiIstPrevidequalthis DECIMAL(15,2), @TpAltriDebitiequalthis DECIMAL(15,2), @TpRateiRiscontiequalthis DECIMAL(15,2)',@IdBilancioIndustrialeequalthis , @IdImpresaequalthis , @IdProgettoequalthis , @Annoequalthis , @DataBilancioequalthis , @Previsionaleequalthis , @DataModificaequalthis , @PlvRicaviVenditaequalthis , @PlvAltriRicaviequalthis , @CpMateriePrimeequalthis , @CpServiziequalthis , @CpBeniTerziequalthis , @CpPersonaleequalthis , @CpAmmSvalutazioniequalthis , @CpVarRimanenzeequalthis , @CpOneriequalthis , @PofAltriProventiequalthis , @PofInteressiOneriequalthis , @RettValAttFinanziarieequalthis , @PosProventiStraordequalthis , @PosOneriStraordequalthis , @TotPrimaImposteequalthis , @ImposteRedditoequalthis , @TaCreditiSociequalthis , @TaImmImmaterialiequalthis , @TaImmobMaterialiequalthis , @TaImmPartecipazioniequalthis , @TaImmCreditiequalthis , @TaAcRimanenzeequalthis , @TaAcCreditiClientiequalthis , @TaAcCreditiAltriequalthis , @TaAcDepPostaliequalthis , @TaAcDispoLiquideequalthis , @TaRateiRiscontiequalthis , @TpPnCapitaleequalthis , @TpPnSovrapAzioniequalthis , @TpPnRisRivalutazioneequalthis , @TpPnRisLegaleequalthis , @TpPnAzioniProprieequalthis , @TpPnRiserva904equalthis , @TpPnRiserveStatutarieequalthis , @TpPnAltreRiserveequalthis , @TpPnUtiliPrecedentiequalthis , @TpPnUtiliEsercizioequalthis , @TpFondiRischiOneriequalthis , @TpFineRapportoequalthis , @TpDebitiBancheequalthis , @TpDebitiFinanziatoriequalthis , @TpDebitiFornitoriequalthis , @TpDebitiIstPrevidequalthis , @TpAltriDebitiequalthis , @TpRateiRiscontiequalthis ;
	else
		SELECT ID_BILANCIO_INDUSTRIALE, ID_IMPRESA, ID_PROGETTO, ANNO, DATA_BILANCIO, PREVISIONALE, DATA_MODIFICA, PLV_RICAVI_VENDITA, PLV_ALTRI_RICAVI, CP_MATERIE_PRIME, CP_SERVIZI, CP_BENI_TERZI, CP_PERSONALE, CP_AMM_SVALUTAZIONI, CP_VAR_RIMANENZE, CP_ONERI, POF_ALTRI_PROVENTI, POF_INTERESSI_ONERI, RETT_VAL_ATT_FINANZIARIE, POS_PROVENTI_STRAORD, POS_ONERI_STRAORD, TOT_PRIMA_IMPOSTE, IMPOSTE_REDDITO, TA_CREDITI_SOCI, TA_IMM_IMMATERIALI, TA_IMMOB_MATERIALI, TA_IMM_PARTECIPAZIONI, TA_IMM_CREDITI, TA_AC_RIMANENZE, TA_AC_CREDITI_CLIENTI, TA_AC_CREDITI_ALTRI, TA_AC_DEP_POSTALI, TA_AC_DISPO_LIQUIDE, TA_RATEI_RISCONTI, TP_PN_CAPITALE, TP_PN_SOVRAP_AZIONI, TP_PN_RIS_RIVALUTAZIONE, TP_PN_RIS_LEGALE, TP_PN_AZIONI_PROPRIE, TP_PN_RISERVA_904, TP_PN_RISERVE_STATUTARIE, TP_PN_ALTRE_RISERVE, TP_PN_UTILI_PRECEDENTI, TP_PN_UTILI_ESERCIZIO, TP_FONDI_RISCHI_ONERI, TP_FINE_RAPPORTO, TP_DEBITI_BANCHE, TP_DEBITI_FINANZIATORI, TP_DEBITI_FORNITORI, TP_DEBITI_IST_PREVID, TP_ALTRI_DEBITI, TP_RATEI_RISCONTI, NOTA_INTEGRATIVA
		FROM BILANCIO_INDUSTRIALE
		WHERE 
			((@IdBilancioIndustrialeequalthis IS NULL) OR ID_BILANCIO_INDUSTRIALE = @IdBilancioIndustrialeequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@DataBilancioequalthis IS NULL) OR DATA_BILANCIO = @DataBilancioequalthis) AND 
			((@Previsionaleequalthis IS NULL) OR PREVISIONALE = @Previsionaleequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@PlvRicaviVenditaequalthis IS NULL) OR PLV_RICAVI_VENDITA = @PlvRicaviVenditaequalthis) AND 
			((@PlvAltriRicaviequalthis IS NULL) OR PLV_ALTRI_RICAVI = @PlvAltriRicaviequalthis) AND 
			((@CpMateriePrimeequalthis IS NULL) OR CP_MATERIE_PRIME = @CpMateriePrimeequalthis) AND 
			((@CpServiziequalthis IS NULL) OR CP_SERVIZI = @CpServiziequalthis) AND 
			((@CpBeniTerziequalthis IS NULL) OR CP_BENI_TERZI = @CpBeniTerziequalthis) AND 
			((@CpPersonaleequalthis IS NULL) OR CP_PERSONALE = @CpPersonaleequalthis) AND 
			((@CpAmmSvalutazioniequalthis IS NULL) OR CP_AMM_SVALUTAZIONI = @CpAmmSvalutazioniequalthis) AND 
			((@CpVarRimanenzeequalthis IS NULL) OR CP_VAR_RIMANENZE = @CpVarRimanenzeequalthis) AND 
			((@CpOneriequalthis IS NULL) OR CP_ONERI = @CpOneriequalthis) AND 
			((@PofAltriProventiequalthis IS NULL) OR POF_ALTRI_PROVENTI = @PofAltriProventiequalthis) AND 
			((@PofInteressiOneriequalthis IS NULL) OR POF_INTERESSI_ONERI = @PofInteressiOneriequalthis) AND 
			((@RettValAttFinanziarieequalthis IS NULL) OR RETT_VAL_ATT_FINANZIARIE = @RettValAttFinanziarieequalthis) AND 
			((@PosProventiStraordequalthis IS NULL) OR POS_PROVENTI_STRAORD = @PosProventiStraordequalthis) AND 
			((@PosOneriStraordequalthis IS NULL) OR POS_ONERI_STRAORD = @PosOneriStraordequalthis) AND 
			((@TotPrimaImposteequalthis IS NULL) OR TOT_PRIMA_IMPOSTE = @TotPrimaImposteequalthis) AND 
			((@ImposteRedditoequalthis IS NULL) OR IMPOSTE_REDDITO = @ImposteRedditoequalthis) AND 
			((@TaCreditiSociequalthis IS NULL) OR TA_CREDITI_SOCI = @TaCreditiSociequalthis) AND 
			((@TaImmImmaterialiequalthis IS NULL) OR TA_IMM_IMMATERIALI = @TaImmImmaterialiequalthis) AND 
			((@TaImmobMaterialiequalthis IS NULL) OR TA_IMMOB_MATERIALI = @TaImmobMaterialiequalthis) AND 
			((@TaImmPartecipazioniequalthis IS NULL) OR TA_IMM_PARTECIPAZIONI = @TaImmPartecipazioniequalthis) AND 
			((@TaImmCreditiequalthis IS NULL) OR TA_IMM_CREDITI = @TaImmCreditiequalthis) AND 
			((@TaAcRimanenzeequalthis IS NULL) OR TA_AC_RIMANENZE = @TaAcRimanenzeequalthis) AND 
			((@TaAcCreditiClientiequalthis IS NULL) OR TA_AC_CREDITI_CLIENTI = @TaAcCreditiClientiequalthis) AND 
			((@TaAcCreditiAltriequalthis IS NULL) OR TA_AC_CREDITI_ALTRI = @TaAcCreditiAltriequalthis) AND 
			((@TaAcDepPostaliequalthis IS NULL) OR TA_AC_DEP_POSTALI = @TaAcDepPostaliequalthis) AND 
			((@TaAcDispoLiquideequalthis IS NULL) OR TA_AC_DISPO_LIQUIDE = @TaAcDispoLiquideequalthis) AND 
			((@TaRateiRiscontiequalthis IS NULL) OR TA_RATEI_RISCONTI = @TaRateiRiscontiequalthis) AND 
			((@TpPnCapitaleequalthis IS NULL) OR TP_PN_CAPITALE = @TpPnCapitaleequalthis) AND 
			((@TpPnSovrapAzioniequalthis IS NULL) OR TP_PN_SOVRAP_AZIONI = @TpPnSovrapAzioniequalthis) AND 
			((@TpPnRisRivalutazioneequalthis IS NULL) OR TP_PN_RIS_RIVALUTAZIONE = @TpPnRisRivalutazioneequalthis) AND 
			((@TpPnRisLegaleequalthis IS NULL) OR TP_PN_RIS_LEGALE = @TpPnRisLegaleequalthis) AND 
			((@TpPnAzioniProprieequalthis IS NULL) OR TP_PN_AZIONI_PROPRIE = @TpPnAzioniProprieequalthis) AND 
			((@TpPnRiserva904equalthis IS NULL) OR TP_PN_RISERVA_904 = @TpPnRiserva904equalthis) AND 
			((@TpPnRiserveStatutarieequalthis IS NULL) OR TP_PN_RISERVE_STATUTARIE = @TpPnRiserveStatutarieequalthis) AND 
			((@TpPnAltreRiserveequalthis IS NULL) OR TP_PN_ALTRE_RISERVE = @TpPnAltreRiserveequalthis) AND 
			((@TpPnUtiliPrecedentiequalthis IS NULL) OR TP_PN_UTILI_PRECEDENTI = @TpPnUtiliPrecedentiequalthis) AND 
			((@TpPnUtiliEsercizioequalthis IS NULL) OR TP_PN_UTILI_ESERCIZIO = @TpPnUtiliEsercizioequalthis) AND 
			((@TpFondiRischiOneriequalthis IS NULL) OR TP_FONDI_RISCHI_ONERI = @TpFondiRischiOneriequalthis) AND 
			((@TpFineRapportoequalthis IS NULL) OR TP_FINE_RAPPORTO = @TpFineRapportoequalthis) AND 
			((@TpDebitiBancheequalthis IS NULL) OR TP_DEBITI_BANCHE = @TpDebitiBancheequalthis) AND 
			((@TpDebitiFinanziatoriequalthis IS NULL) OR TP_DEBITI_FINANZIATORI = @TpDebitiFinanziatoriequalthis) AND 
			((@TpDebitiFornitoriequalthis IS NULL) OR TP_DEBITI_FORNITORI = @TpDebitiFornitoriequalthis) AND 
			((@TpDebitiIstPrevidequalthis IS NULL) OR TP_DEBITI_IST_PREVID = @TpDebitiIstPrevidequalthis) AND 
			((@TpAltriDebitiequalthis IS NULL) OR TP_ALTRI_DEBITI = @TpAltriDebitiequalthis) AND 
			((@TpRateiRiscontiequalthis IS NULL) OR TP_RATEI_RISCONTI = @TpRateiRiscontiequalthis)

