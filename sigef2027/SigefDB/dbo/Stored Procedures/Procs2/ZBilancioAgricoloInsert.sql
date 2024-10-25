﻿CREATE PROCEDURE [dbo].[ZBilancioAgricoloInsert]
(
	@IdImpresa INT, 
	@IdProgetto INT, 
	@Anno INT, 
	@DataBilancio DATETIME, 
	@Previsionale BIT, 
	@DataModifica DATETIME, 
	@PlvRicaviNetti DECIMAL(15,2), 
	@PlvRicaviAttivita DECIMAL(15,2), 
	@PlvRimanenzeFinali DECIMAL(15,2), 
	@PlvRimanenzeIniziali DECIMAL(15,2), 
	@VaCostiMatPrime DECIMAL(15,2), 
	@VaCostiAttConnesse DECIMAL(15,2), 
	@VaNoleggi DECIMAL(15,2), 
	@VaManutenzioni DECIMAL(15,2), 
	@VaSpeseGenerali DECIMAL(15,2), 
	@VaAffitti DECIMAL(15,2), 
	@VaAltriCosti DECIMAL(15,2), 
	@PnAmmMacchine DECIMAL(15,2), 
	@PnAmmFabbricati DECIMAL(15,2), 
	@PnAmmPiantagioni DECIMAL(15,2), 
	@RoSalari DECIMAL(15,2), 
	@RoOneri DECIMAL(15,2), 
	@RnPacRicavi DECIMAL(15,2), 
	@RnPacCosti DECIMAL(15,2), 
	@RnPacProventi DECIMAL(15,2), 
	@RnPacPerdite DECIMAL(15,2), 
	@RnPacInteressiAttivi DECIMAL(15,2), 
	@RnPacInteressiPassivi DECIMAL(15,2), 
	@RnPacImposte DECIMAL(15,2), 
	@RnPacContributiPac DECIMAL(15,2), 
	@MnlRedditiFam DECIMAL(15,2), 
	@MnlRimborso DECIMAL(15,2), 
	@MnlPrelievi DECIMAL(15,2), 
	@CfCfTerreni DECIMAL(15,2), 
	@CfCfImpianti DECIMAL(15,2), 
	@CfCfPiantagioni DECIMAL(15,2), 
	@CfCfMiglioramenti DECIMAL(15,2), 
	@CfCaMacchine DECIMAL(15,2), 
	@CfCaBestiame DECIMAL(15,2), 
	@CfIfPartecipazioni DECIMAL(15,2), 
	@CcDfRimanenze DECIMAL(15,2), 
	@CcDfAnticipazioni DECIMAL(15,2), 
	@CcLdCrediti DECIMAL(15,2), 
	@CcLiBanca DECIMAL(15,2), 
	@CcLiCassa DECIMAL(15,2), 
	@FfPcDebitiBreveTermine DECIMAL(15,2), 
	@FfPcFornitori DECIMAL(15,2), 
	@FfPcDebiti DECIMAL(15,2), 
	@FfPcMutui DECIMAL(15,2), 
	@FfMpCapitale DECIMAL(15,2), 
	@FfMpRiserve DECIMAL(15,2), 
	@FfMpUtile DECIMAL(15,2)
)
AS
	INSERT INTO BILANCIO_AGRICOLO
	(
		ID_IMPRESA, 
		ID_PROGETTO, 
		ANNO, 
		DATA_BILANCIO, 
		PREVISIONALE, 
		DATA_MODIFICA, 
		PLV_RICAVI_NETTI, 
		PLV_RICAVI_ATTIVITA, 
		PLV_RIMANENZE_FINALI, 
		PLV_RIMANENZE_INIZIALI, 
		VA_COSTI_MAT_PRIME, 
		VA_COSTI_ATT_CONNESSE, 
		VA_NOLEGGI, 
		VA_MANUTENZIONI, 
		VA_SPESE_GENERALI, 
		VA_AFFITTI, 
		VA_ALTRI_COSTI, 
		PN_AMM_MACCHINE, 
		PN_AMM_FABBRICATI, 
		PN_AMM_PIANTAGIONI, 
		RO_SALARI, 
		RO_ONERI, 
		RN_PAC_RICAVI, 
		RN_PAC_COSTI, 
		RN_PAC_PROVENTI, 
		RN_PAC_PERDITE, 
		RN_PAC_INTERESSI_ATTIVI, 
		RN_PAC_INTERESSI_PASSIVI, 
		RN_PAC_IMPOSTE, 
		RN_PAC_CONTRIBUTI_PAC, 
		MNL_REDDITI_FAM, 
		MNL_RIMBORSO, 
		MNL_PRELIEVI, 
		CF_CF_TERRENI, 
		CF_CF_IMPIANTI, 
		CF_CF_PIANTAGIONI, 
		CF_CF_MIGLIORAMENTI, 
		CF_CA_MACCHINE, 
		CF_CA_BESTIAME, 
		CF_IF_PARTECIPAZIONI, 
		CC_DF_RIMANENZE, 
		CC_DF_ANTICIPAZIONI, 
		CC_LD_CREDITI, 
		CC_LI_BANCA, 
		CC_LI_CASSA, 
		FF_PC_DEBITI_BREVE_TERMINE, 
		FF_PC_FORNITORI, 
		FF_PC_DEBITI, 
		FF_PC_MUTUI, 
		FF_MP_CAPITALE, 
		FF_MP_RISERVE, 
		FF_MP_UTILE
	)
	VALUES
	(
		@IdImpresa, 
		@IdProgetto, 
		@Anno, 
		@DataBilancio, 
		@Previsionale, 
		@DataModifica, 
		@PlvRicaviNetti, 
		@PlvRicaviAttivita, 
		@PlvRimanenzeFinali, 
		@PlvRimanenzeIniziali, 
		@VaCostiMatPrime, 
		@VaCostiAttConnesse, 
		@VaNoleggi, 
		@VaManutenzioni, 
		@VaSpeseGenerali, 
		@VaAffitti, 
		@VaAltriCosti, 
		@PnAmmMacchine, 
		@PnAmmFabbricati, 
		@PnAmmPiantagioni, 
		@RoSalari, 
		@RoOneri, 
		@RnPacRicavi, 
		@RnPacCosti, 
		@RnPacProventi, 
		@RnPacPerdite, 
		@RnPacInteressiAttivi, 
		@RnPacInteressiPassivi, 
		@RnPacImposte, 
		@RnPacContributiPac, 
		@MnlRedditiFam, 
		@MnlRimborso, 
		@MnlPrelievi, 
		@CfCfTerreni, 
		@CfCfImpianti, 
		@CfCfPiantagioni, 
		@CfCfMiglioramenti, 
		@CfCaMacchine, 
		@CfCaBestiame, 
		@CfIfPartecipazioni, 
		@CcDfRimanenze, 
		@CcDfAnticipazioni, 
		@CcLdCrediti, 
		@CcLiBanca, 
		@CcLiCassa, 
		@FfPcDebitiBreveTermine, 
		@FfPcFornitori, 
		@FfPcDebiti, 
		@FfPcMutui, 
		@FfMpCapitale, 
		@FfMpRiserve, 
		@FfMpUtile
	)
	SELECT SCOPE_IDENTITY() AS ID_BILANCIO_AGRICOLO
