CREATE PROCEDURE [dbo].[ZPianoInvestimentiFindSelect]
(
	@IdInvestimentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@Descrizioneequalthis VARCHAR(2000), 
	@DataVariazioneequalthis DATETIME, 
	@OperatoreVariazioneequalthis VARCHAR(255), 
	@CodTipoInvestimentoequalthis INT, 
	@CodStpequalthis VARCHAR(255), 
	@IdUnitaMisuraequalthis INT, 
	@Quantitaequalthis DECIMAL(10,2), 
	@CostoInvestimentoequalthis DECIMAL(15,2), 
	@SpeseGeneraliequalthis DECIMAL(15,2), 
	@ContributoRichiestoequalthis DECIMAL(15,2), 
	@QuotaContributoRichiestoequalthis DECIMAL(10,2), 
	@ContributoAltreFontiequalthis DECIMAL(15,2), 
	@QuotaContributoAltreFontiequalthis DECIMAL(10,2), 
	@TassoAbbuonoequalthis DECIMAL(10,2), 
	@IdSettoreProduttivoequalthis INT, 
	@IdPrioritaSettorialeequalthis INT, 
	@IdObiettivoMisuraequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@IdDettaglioInvestimentoequalthis INT, 
	@IdSpecificaInvestimentoequalthis INT, 
	@Ammessoequalthis BIT, 
	@Istruttoreequalthis VARCHAR(255), 
	@IdInvestimentoOriginaleequalthis INT, 
	@DataValutazioneequalthis DATETIME, 
	@IdVarianteequalthis INT, 
	@CodVariazioneequalthis VARCHAR(255), 
	@NonCofinanziatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_INVESTIMENTO, ID_PROGETTO, ID_PROGRAMMAZIONE, DESCRIZIONE, DATA_VARIAZIONE, OPERATORE_VARIAZIONE, COD_STP, ID_UNITA_MISURA, QUANTITA, COSTO_INVESTIMENTO, SPESE_GENERALI, CONTRIBUTO_RICHIESTO, QUOTA_CONTRIBUTO_RICHIESTO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, ID_OBIETTIVO_MISURA, AMMESSO, ISTRUTTORE, ID_INVESTIMENTO_ORIGINALE, DATA_VALUTAZIONE, ID_CODIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, ID_SPECIFICA_INVESTIMENTO, COD_TP, CODIFICA_INVESTIMENTO, AIUTO_MINIMO, CODICE, COD_SPECIFICA, SPECIFICA_INVESTIMENTI, DETTAGLIO_INVESTIMENTI, MOBILE, QUOTA_SPESE_GENERALI, SETTORE_PRODUTTIVO, COD_TIPO_INVESTIMENTO, RICHIEDI_PARTICELLA, VALUTAZIONE_INVESTIMENTO, ID_VARIANTE, COD_VARIAZIONE, TASSO_ABBUONO, MISURA, ID_MISURA, NON_COFINANZIATO, IS_MAX, CONTRIBUTO_ALTRE_FONTI, QUOTA_CONTRIBUTO_ALTRE_FONTI FROM vPIANO_INVESTIMENTI WHERE 1=1';
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@DataVariazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VARIAZIONE = @DataVariazioneequalthis)'; set @lensql=@lensql+len(@DataVariazioneequalthis);end;
	IF (@OperatoreVariazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_VARIAZIONE = @OperatoreVariazioneequalthis)'; set @lensql=@lensql+len(@OperatoreVariazioneequalthis);end;
	IF (@CodTipoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis)'; set @lensql=@lensql+len(@CodTipoInvestimentoequalthis);end;
	IF (@CodStpequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STP = @CodStpequalthis)'; set @lensql=@lensql+len(@CodStpequalthis);end;
	IF (@IdUnitaMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UNITA_MISURA = @IdUnitaMisuraequalthis)'; set @lensql=@lensql+len(@IdUnitaMisuraequalthis);end;
	IF (@Quantitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUANTITA = @Quantitaequalthis)'; set @lensql=@lensql+len(@Quantitaequalthis);end;
	IF (@CostoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COSTO_INVESTIMENTO = @CostoInvestimentoequalthis)'; set @lensql=@lensql+len(@CostoInvestimentoequalthis);end;
	IF (@SpeseGeneraliequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESE_GENERALI = @SpeseGeneraliequalthis)'; set @lensql=@lensql+len(@SpeseGeneraliequalthis);end;
	IF (@ContributoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_RICHIESTO = @ContributoRichiestoequalthis)'; set @lensql=@lensql+len(@ContributoRichiestoequalthis);end;
	IF (@QuotaContributoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUOTA_CONTRIBUTO_RICHIESTO = @QuotaContributoRichiestoequalthis)'; set @lensql=@lensql+len(@QuotaContributoRichiestoequalthis);end;
	IF (@ContributoAltreFontiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_ALTRE_FONTI = @ContributoAltreFontiequalthis)'; set @lensql=@lensql+len(@ContributoAltreFontiequalthis);end;
	IF (@QuotaContributoAltreFontiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUOTA_CONTRIBUTO_ALTRE_FONTI = @QuotaContributoAltreFontiequalthis)'; set @lensql=@lensql+len(@QuotaContributoAltreFontiequalthis);end;
	IF (@TassoAbbuonoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TASSO_ABBUONO = @TassoAbbuonoequalthis)'; set @lensql=@lensql+len(@TassoAbbuonoequalthis);end;
	IF (@IdSettoreProduttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis)'; set @lensql=@lensql+len(@IdSettoreProduttivoequalthis);end;
	IF (@IdPrioritaSettorialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA_SETTORIALE = @IdPrioritaSettorialeequalthis)'; set @lensql=@lensql+len(@IdPrioritaSettorialeequalthis);end;
	IF (@IdObiettivoMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OBIETTIVO_MISURA = @IdObiettivoMisuraequalthis)'; set @lensql=@lensql+len(@IdObiettivoMisuraequalthis);end;
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@IdDettaglioInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis)'; set @lensql=@lensql+len(@IdDettaglioInvestimentoequalthis);end;
	IF (@IdSpecificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdSpecificaInvestimentoequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMESSO = @Ammessoequalthis)'; set @lensql=@lensql+len(@Ammessoequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE = @Istruttoreequalthis)'; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	IF (@IdInvestimentoOriginaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO_ORIGINALE = @IdInvestimentoOriginaleequalthis)'; set @lensql=@lensql+len(@IdInvestimentoOriginaleequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)'; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodVariazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_VARIAZIONE = @CodVariazioneequalthis)'; set @lensql=@lensql+len(@CodVariazioneequalthis);end;
	IF (@NonCofinanziatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NON_COFINANZIATO = @NonCofinanziatoequalthis)'; set @lensql=@lensql+len(@NonCofinanziatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdInvestimentoequalthis INT, @IdProgettoequalthis INT, @IdProgrammazioneequalthis INT, @Descrizioneequalthis VARCHAR(2000), @DataVariazioneequalthis DATETIME, @OperatoreVariazioneequalthis VARCHAR(255), @CodTipoInvestimentoequalthis INT, @CodStpequalthis VARCHAR(255), @IdUnitaMisuraequalthis INT, @Quantitaequalthis DECIMAL(10,2), @CostoInvestimentoequalthis DECIMAL(15,2), @SpeseGeneraliequalthis DECIMAL(15,2), @ContributoRichiestoequalthis DECIMAL(15,2), @QuotaContributoRichiestoequalthis DECIMAL(10,2), @ContributoAltreFontiequalthis DECIMAL(15,2), @QuotaContributoAltreFontiequalthis DECIMAL(10,2), @TassoAbbuonoequalthis DECIMAL(10,2), @IdSettoreProduttivoequalthis INT, @IdPrioritaSettorialeequalthis INT, @IdObiettivoMisuraequalthis INT, @IdCodificaInvestimentoequalthis INT, @IdDettaglioInvestimentoequalthis INT, @IdSpecificaInvestimentoequalthis INT, @Ammessoequalthis BIT, @Istruttoreequalthis VARCHAR(255), @IdInvestimentoOriginaleequalthis INT, @DataValutazioneequalthis DATETIME, @IdVarianteequalthis INT, @CodVariazioneequalthis VARCHAR(255), @NonCofinanziatoequalthis BIT',@IdInvestimentoequalthis , @IdProgettoequalthis , @IdProgrammazioneequalthis , @Descrizioneequalthis , @DataVariazioneequalthis , @OperatoreVariazioneequalthis , @CodTipoInvestimentoequalthis , @CodStpequalthis , @IdUnitaMisuraequalthis , @Quantitaequalthis , @CostoInvestimentoequalthis , @SpeseGeneraliequalthis , @ContributoRichiestoequalthis , @QuotaContributoRichiestoequalthis , @ContributoAltreFontiequalthis , @QuotaContributoAltreFontiequalthis , @TassoAbbuonoequalthis , @IdSettoreProduttivoequalthis , @IdPrioritaSettorialeequalthis , @IdObiettivoMisuraequalthis , @IdCodificaInvestimentoequalthis , @IdDettaglioInvestimentoequalthis , @IdSpecificaInvestimentoequalthis , @Ammessoequalthis , @Istruttoreequalthis , @IdInvestimentoOriginaleequalthis , @DataValutazioneequalthis , @IdVarianteequalthis , @CodVariazioneequalthis , @NonCofinanziatoequalthis ;
	else
		SELECT ID_INVESTIMENTO, ID_PROGETTO, ID_PROGRAMMAZIONE, DESCRIZIONE, DATA_VARIAZIONE, OPERATORE_VARIAZIONE, COD_STP, ID_UNITA_MISURA, QUANTITA, COSTO_INVESTIMENTO, SPESE_GENERALI, CONTRIBUTO_RICHIESTO, QUOTA_CONTRIBUTO_RICHIESTO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, ID_OBIETTIVO_MISURA, AMMESSO, ISTRUTTORE, ID_INVESTIMENTO_ORIGINALE, DATA_VALUTAZIONE, ID_CODIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, ID_SPECIFICA_INVESTIMENTO, COD_TP, CODIFICA_INVESTIMENTO, AIUTO_MINIMO, CODICE, COD_SPECIFICA, SPECIFICA_INVESTIMENTI, DETTAGLIO_INVESTIMENTI, MOBILE, QUOTA_SPESE_GENERALI, SETTORE_PRODUTTIVO, COD_TIPO_INVESTIMENTO, RICHIEDI_PARTICELLA, VALUTAZIONE_INVESTIMENTO, ID_VARIANTE, COD_VARIAZIONE, TASSO_ABBUONO, MISURA, ID_MISURA, NON_COFINANZIATO, IS_MAX, CONTRIBUTO_ALTRE_FONTI, QUOTA_CONTRIBUTO_ALTRE_FONTI
		FROM vPIANO_INVESTIMENTI
		WHERE 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@DataVariazioneequalthis IS NULL) OR DATA_VARIAZIONE = @DataVariazioneequalthis) AND 
			((@OperatoreVariazioneequalthis IS NULL) OR OPERATORE_VARIAZIONE = @OperatoreVariazioneequalthis) AND 
			((@CodTipoInvestimentoequalthis IS NULL) OR COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis) AND 
			((@CodStpequalthis IS NULL) OR COD_STP = @CodStpequalthis) AND 
			((@IdUnitaMisuraequalthis IS NULL) OR ID_UNITA_MISURA = @IdUnitaMisuraequalthis) AND 
			((@Quantitaequalthis IS NULL) OR QUANTITA = @Quantitaequalthis) AND 
			((@CostoInvestimentoequalthis IS NULL) OR COSTO_INVESTIMENTO = @CostoInvestimentoequalthis) AND 
			((@SpeseGeneraliequalthis IS NULL) OR SPESE_GENERALI = @SpeseGeneraliequalthis) AND 
			((@ContributoRichiestoequalthis IS NULL) OR CONTRIBUTO_RICHIESTO = @ContributoRichiestoequalthis) AND 
			((@QuotaContributoRichiestoequalthis IS NULL) OR QUOTA_CONTRIBUTO_RICHIESTO = @QuotaContributoRichiestoequalthis) AND 
			((@ContributoAltreFontiequalthis IS NULL) OR CONTRIBUTO_ALTRE_FONTI = @ContributoAltreFontiequalthis) AND 
			((@QuotaContributoAltreFontiequalthis IS NULL) OR QUOTA_CONTRIBUTO_ALTRE_FONTI = @QuotaContributoAltreFontiequalthis) AND 
			((@TassoAbbuonoequalthis IS NULL) OR TASSO_ABBUONO = @TassoAbbuonoequalthis) AND 
			((@IdSettoreProduttivoequalthis IS NULL) OR ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis) AND 
			((@IdPrioritaSettorialeequalthis IS NULL) OR ID_PRIORITA_SETTORIALE = @IdPrioritaSettorialeequalthis) AND 
			((@IdObiettivoMisuraequalthis IS NULL) OR ID_OBIETTIVO_MISURA = @IdObiettivoMisuraequalthis) AND 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@IdDettaglioInvestimentoequalthis IS NULL) OR ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis) AND 
			((@IdSpecificaInvestimentoequalthis IS NULL) OR ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimentoequalthis) AND 
			((@Ammessoequalthis IS NULL) OR AMMESSO = @Ammessoequalthis) AND 
			((@Istruttoreequalthis IS NULL) OR ISTRUTTORE = @Istruttoreequalthis) AND 
			((@IdInvestimentoOriginaleequalthis IS NULL) OR ID_INVESTIMENTO_ORIGINALE = @IdInvestimentoOriginaleequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodVariazioneequalthis IS NULL) OR COD_VARIAZIONE = @CodVariazioneequalthis) AND 
			((@NonCofinanziatoequalthis IS NULL) OR NON_COFINANZIATO = @NonCofinanziatoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPianoInvestimentiFindSelect]
(
	@IdInvestimentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@Descrizioneequalthis VARCHAR(2000), 
	@DataVariazioneequalthis DATETIME, 
	@OperatoreVariazioneequalthis VARCHAR(255), 
	@CodTipoInvestimentoequalthis INT, 
	@CodStpequalthis VARCHAR(255), 
	@IdUnitaMisuraequalthis INT, 
	@Quantitaequalthis DECIMAL(10,2), 
	@CostoInvestimentoequalthis DECIMAL(15,2), 
	@SpeseGeneraliequalthis DECIMAL(15,2), 
	@ContributoRichiestoequalthis DECIMAL(15,2), 
	@QuotaContributoRichiestoequalthis DECIMAL(10,2), 
	@ContributoAltreFontiequalthis DECIMAL(15,2), 
	@QuotaContributoAltreFontiequalthis DECIMAL(10,2), 
	@TassoAbbuonoequalthis DECIMAL(10,2), 
	@IdSettoreProduttivoequalthis INT, 
	@IdPrioritaSettorialeequalthis INT, 
	@IdObiettivoMisuraequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@IdDettaglioInvestimentoequalthis INT, 
	@IdSpecificaInvestimentoequalthis INT, 
	@Ammessoequalthis BIT, 
	@Istruttoreequalthis VARCHAR(255), 
	@IdInvestimentoOriginaleequalthis INT, 
	@DataValutazioneequalthis DATETIME, 
	@IdVarianteequalthis INT, 
	@CodVariazioneequalthis VARCHAR(255), 
	@NonCofinanziatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_INVESTIMENTO, ID_PROGETTO, ID_PROGRAMMAZIONE, DESCRIZIONE, DATA_VARIAZIONE, OPERATORE_VARIAZIONE, COD_STP, ID_UNITA_MISURA, QUANTITA, COSTO_INVESTIMENTO, SPESE_GENERALI, CONTRIBUTO_RICHIESTO, QUOTA_CONTRIBUTO_RICHIESTO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, ID_OBIETTIVO_MISURA, AMMESSO, ISTRUTTORE, ID_INVESTIMENTO_ORIGINALE, DATA_VALUTAZIONE, ID_CODIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, ID_SPECIFICA_INVESTIMENTO, COD_TP, CODIFICA_INVESTIMENTO, AIUTO_MINIMO, CODICE, COD_SPECIFICA, SPECIFICA_INVESTIMENTI, DETTAGLIO_INVESTIMENTI, MOBILE, QUOTA_SPESE_GENERALI, SETTORE_PRODUTTIVO, COD_TIPO_INVESTIMENTO, RICHIEDI_PARTICELLA, VALUTAZIONE_INVESTIMENTO, ID_VARIANTE, COD_VARIAZIONE, TASSO_ABBUONO, MISURA, ID_MISURA, NON_COFINANZIATO, IS_MAX, CONTRIBUTO_ALTRE_FONTI, QUOTA_CONTRIBUTO_ALTRE_FONTI FROM vPIANO_INVESTIMENTI WHERE 1=1'';
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)''; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)''; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@DataVariazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_VARIAZIONE = @DataVariazioneequalthis)''; set @lensql=@lensql+len(@DataVariazioneequalthis);end;
	IF (@OperatoreVariazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE_VARIAZIONE = @OperatoreVariazioneequalthis)''; set @lensql=@lensql+len(@OperatoreVariazioneequalthis);end;
	IF (@CodTipoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_INVESTIMENTO = @CodTipoInvestimentoequalthis)''; set @lensql=@lensql+len(@CodTipoInvestimentoequalthis);end;
	IF (@CodStpequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_STP = @CodStpequalthis)''; set @lensql=@lensql+len(@CodStpequalthis);end;
	IF (@IdUnitaMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_UNITA_MISURA = @IdUnitaMisuraequalthis)''; set @lensql=@lensql+len(@IdUnitaMisuraequalthis);end;
	IF (@Quantitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUANTITA = @Quantitaequalthis)''; set @lensql=@lensql+len(@Quantitaequalthis);end;
	IF (@CostoInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COSTO_INVESTI', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoInvestimentiFindSelect';

