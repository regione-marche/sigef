

CREATE PROCEDURE [dbo].[ZBilancioIndustrialeFindFind]
(
	@IdBilancioIndustrialeequalthis INT, 
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
	SET @sql = 'SELECT ID_BILANCIO_INDUSTRIALE, ID_IMPRESA, ID_PROGETTO, ANNO, DATA_BILANCIO, PREVISIONALE, DATA_MODIFICA, PLV_RICAVI_VENDITA, PLV_ALTRI_RICAVI, CP_MATERIE_PRIME, CP_SERVIZI, CP_BENI_TERZI, CP_PERSONALE, CP_AMM_SVALUTAZIONI, CP_VAR_RIMANENZE, CP_ONERI, POF_ALTRI_PROVENTI, POF_INTERESSI_ONERI, RETT_VAL_ATT_FINANZIARIE, POS_PROVENTI_STRAORD, POS_ONERI_STRAORD, TOT_PRIMA_IMPOSTE, IMPOSTE_REDDITO, TA_CREDITI_SOCI, TA_IMM_IMMATERIALI, TA_IMMOB_MATERIALI, TA_IMM_PARTECIPAZIONI, TA_IMM_CREDITI, TA_AC_RIMANENZE, TA_AC_CREDITI_CLIENTI, TA_AC_CREDITI_ALTRI, TA_AC_DEP_POSTALI, TA_AC_DISPO_LIQUIDE, TA_RATEI_RISCONTI, TP_PN_CAPITALE, TP_PN_SOVRAP_AZIONI, TP_PN_RIS_RIVALUTAZIONE, TP_PN_RIS_LEGALE, TP_PN_AZIONI_PROPRIE, TP_PN_RISERVA_904, TP_PN_RISERVE_STATUTARIE, TP_PN_ALTRE_RISERVE, TP_PN_UTILI_PRECEDENTI, TP_PN_UTILI_ESERCIZIO, TP_FONDI_RISCHI_ONERI, TP_FINE_RAPPORTO, TP_DEBITI_BANCHE, TP_DEBITI_FINANZIATORI, TP_DEBITI_FORNITORI, TP_DEBITI_IST_PREVID, TP_ALTRI_DEBITI, TP_RATEI_RISCONTI, NOTA_INTEGRATIVA FROM BILANCIO_INDUSTRIALE WHERE 1=1';
	IF (@IdBilancioIndustrialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BILANCIO_INDUSTRIALE = @IdBilancioIndustrialeequalthis)'; set @lensql=@lensql+len(@IdBilancioIndustrialeequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@DataBilancioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_BILANCIO = @DataBilancioequalthis)'; set @lensql=@lensql+len(@DataBilancioequalthis);end;
	IF (@Previsionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PREVISIONALE = @Previsionaleequalthis)'; set @lensql=@lensql+len(@Previsionaleequalthis);end;
	set @sql = @sql + 'ORDER BY ANNO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBilancioIndustrialeequalthis INT, @IdImpresaequalthis INT, @IdProgettoequalthis INT, @Annoequalthis INT, @DataBilancioequalthis DATETIME, @Previsionaleequalthis BIT',@IdBilancioIndustrialeequalthis , @IdImpresaequalthis , @IdProgettoequalthis , @Annoequalthis , @DataBilancioequalthis , @Previsionaleequalthis ;
	else
		SELECT ID_BILANCIO_INDUSTRIALE, ID_IMPRESA, ID_PROGETTO, ANNO, DATA_BILANCIO, PREVISIONALE, DATA_MODIFICA, PLV_RICAVI_VENDITA, PLV_ALTRI_RICAVI, CP_MATERIE_PRIME, CP_SERVIZI, CP_BENI_TERZI, CP_PERSONALE, CP_AMM_SVALUTAZIONI, CP_VAR_RIMANENZE, CP_ONERI, POF_ALTRI_PROVENTI, POF_INTERESSI_ONERI, RETT_VAL_ATT_FINANZIARIE, POS_PROVENTI_STRAORD, POS_ONERI_STRAORD, TOT_PRIMA_IMPOSTE, IMPOSTE_REDDITO, TA_CREDITI_SOCI, TA_IMM_IMMATERIALI, TA_IMMOB_MATERIALI, TA_IMM_PARTECIPAZIONI, TA_IMM_CREDITI, TA_AC_RIMANENZE, TA_AC_CREDITI_CLIENTI, TA_AC_CREDITI_ALTRI, TA_AC_DEP_POSTALI, TA_AC_DISPO_LIQUIDE, TA_RATEI_RISCONTI, TP_PN_CAPITALE, TP_PN_SOVRAP_AZIONI, TP_PN_RIS_RIVALUTAZIONE, TP_PN_RIS_LEGALE, TP_PN_AZIONI_PROPRIE, TP_PN_RISERVA_904, TP_PN_RISERVE_STATUTARIE, TP_PN_ALTRE_RISERVE, TP_PN_UTILI_PRECEDENTI, TP_PN_UTILI_ESERCIZIO, TP_FONDI_RISCHI_ONERI, TP_FINE_RAPPORTO, TP_DEBITI_BANCHE, TP_DEBITI_FINANZIATORI, TP_DEBITI_FORNITORI, TP_DEBITI_IST_PREVID, TP_ALTRI_DEBITI, TP_RATEI_RISCONTI, NOTA_INTEGRATIVA
		FROM BILANCIO_INDUSTRIALE
		WHERE 
			((@IdBilancioIndustrialeequalthis IS NULL) OR ID_BILANCIO_INDUSTRIALE = @IdBilancioIndustrialeequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@DataBilancioequalthis IS NULL) OR DATA_BILANCIO = @DataBilancioequalthis) AND 
			((@Previsionaleequalthis IS NULL) OR PREVISIONALE = @Previsionaleequalthis)
		ORDER BY ANNO DESC


