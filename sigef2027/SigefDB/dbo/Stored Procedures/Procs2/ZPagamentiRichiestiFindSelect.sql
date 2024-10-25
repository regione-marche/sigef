CREATE PROCEDURE [dbo].[ZPagamentiRichiestiFindSelect]
(
	@IdPagamentoRichiestoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@DataRichiestaPagamentoequalthis DATETIME, 
	@ImportoComputoMetricoequalthis DECIMAL(18,2), 
	@ImportoRichiestoequalthis DECIMAL(18,2), 
	@ContributoRichiestoequalthis DECIMAL(18,2), 
	@ContributoRichiestoAltreFontiequalthis DECIMAL(18,2), 
	@ImportoDisavanzoCostiAmmessiequalthis DECIMAL(18,2), 
	@ContributoDisavanzoCostiAmmessiequalthis DECIMAL(18,2), 
	@ContributoRichiestoRecuperoAnticipoequalthis DECIMAL(18,2), 
	@ImportoComputoMetricoAmmessoequalthis DECIMAL(18,2), 
	@ImportoAmmessoequalthis DECIMAL(18,2), 
	@ContributoAmmessoequalthis DECIMAL(18,2), 
	@ContributoAmmessoAltreFontiequalthis DECIMAL(18,2), 
	@ContributoAmmessoRecuperoAnticipoequalthis DECIMAL(18,2), 
	@Ammessoequalthis BIT, 
	@Istruttoreequalthis VARCHAR(255), 
	@DataValutazioneequalthis DATETIME, 
	@CodSanzioneVariazioneInvestimentiequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PAGAMENTO_RICHIESTO, ID_INVESTIMENTO, DATA_RICHIESTA_PAGAMENTO, CONTRIBUTO_RICHIESTO, CONTRIBUTO_AMMESSO, AMMESSO, ISTRUTTORE, DATA_VALUTAZIONE, IMPORTO_COMPUTO_METRICO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_PROGRAMMAZIONE, DESCRIZIONE, DATA_VARIAZIONE, OPERATORE_VARIAZIONE, COD_TIPO_INVESTIMENTO, COD_STP, ID_UNITA_MISURA, QUANTITA, COSTO_INVESTIMENTO, SPESE_GENERALI, CONTRIBUTO_RICHIESTO_INVESTIMENTO, QUOTA_CONTRIBUTO_RICHIESTO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, ID_OBIETTIVO_MISURA, ID_CODIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, ID_SPECIFICA_INVESTIMENTO, INVESTIMENTO_AMMESSO, ISTRUTTORE_INVESTIMENTO, ID_INVESTIMENTO_ORIGINALE, DATA_VALUTAZIONE_INVESTIMENTO, VALUTAZIONE_INVESTIMENTO, ID_VARIANTE, IMPORTO_COMPUTO_METRICO_AMMESSO, CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO, CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO, NOTE_ISTRUTTORE, COD_SANZIONE_VARIAZIONE_INVESTIMENTI, IMPORTO_DISAVANZO_COSTI_AMMESSI, CONTRIBUTO_DISAVANZO_COSTI_AMMESSI, CONTRIBUTO_RICHIESTO_ALTRE_FONTI, CONTRIBUTO_AMMESSO_ALTRE_FONTI FROM vPAGAMENTI_RICHIESTI WHERE 1=1';
	IF (@IdPagamentoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiestoequalthis)'; set @lensql=@lensql+len(@IdPagamentoRichiestoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@DataRichiestaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RICHIESTA_PAGAMENTO = @DataRichiestaPagamentoequalthis)'; set @lensql=@lensql+len(@DataRichiestaPagamentoequalthis);end;
	IF (@ImportoComputoMetricoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_COMPUTO_METRICO = @ImportoComputoMetricoequalthis)'; set @lensql=@lensql+len(@ImportoComputoMetricoequalthis);end;
	IF (@ImportoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RICHIESTO = @ImportoRichiestoequalthis)'; set @lensql=@lensql+len(@ImportoRichiestoequalthis);end;
	IF (@ContributoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_RICHIESTO = @ContributoRichiestoequalthis)'; set @lensql=@lensql+len(@ContributoRichiestoequalthis);end;
	IF (@ContributoRichiestoAltreFontiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_RICHIESTO_ALTRE_FONTI = @ContributoRichiestoAltreFontiequalthis)'; set @lensql=@lensql+len(@ContributoRichiestoAltreFontiequalthis);end;
	IF (@ImportoDisavanzoCostiAmmessiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DISAVANZO_COSTI_AMMESSI = @ImportoDisavanzoCostiAmmessiequalthis)'; set @lensql=@lensql+len(@ImportoDisavanzoCostiAmmessiequalthis);end;
	IF (@ContributoDisavanzoCostiAmmessiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_DISAVANZO_COSTI_AMMESSI = @ContributoDisavanzoCostiAmmessiequalthis)'; set @lensql=@lensql+len(@ContributoDisavanzoCostiAmmessiequalthis);end;
	IF (@ContributoRichiestoRecuperoAnticipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO = @ContributoRichiestoRecuperoAnticipoequalthis)'; set @lensql=@lensql+len(@ContributoRichiestoRecuperoAnticipoequalthis);end;
	IF (@ImportoComputoMetricoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_COMPUTO_METRICO_AMMESSO = @ImportoComputoMetricoAmmessoequalthis)'; set @lensql=@lensql+len(@ImportoComputoMetricoAmmessoequalthis);end;
	IF (@ImportoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_AMMESSO = @ImportoAmmessoequalthis)'; set @lensql=@lensql+len(@ImportoAmmessoequalthis);end;
	IF (@ContributoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_AMMESSO = @ContributoAmmessoequalthis)'; set @lensql=@lensql+len(@ContributoAmmessoequalthis);end;
	IF (@ContributoAmmessoAltreFontiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_AMMESSO_ALTRE_FONTI = @ContributoAmmessoAltreFontiequalthis)'; set @lensql=@lensql+len(@ContributoAmmessoAltreFontiequalthis);end;
	IF (@ContributoAmmessoRecuperoAnticipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO = @ContributoAmmessoRecuperoAnticipoequalthis)'; set @lensql=@lensql+len(@ContributoAmmessoRecuperoAnticipoequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMESSO = @Ammessoequalthis)'; set @lensql=@lensql+len(@Ammessoequalthis);end;
	IF (@Istruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE = @Istruttoreequalthis)'; set @lensql=@lensql+len(@Istruttoreequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)'; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@CodSanzioneVariazioneInvestimentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_SANZIONE_VARIAZIONE_INVESTIMENTI = @CodSanzioneVariazioneInvestimentiequalthis)'; set @lensql=@lensql+len(@CodSanzioneVariazioneInvestimentiequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPagamentoRichiestoequalthis INT, @IdDomandaPagamentoequalthis INT, @IdInvestimentoequalthis INT, @DataRichiestaPagamentoequalthis DATETIME, @ImportoComputoMetricoequalthis DECIMAL(18,2), @ImportoRichiestoequalthis DECIMAL(18,2), @ContributoRichiestoequalthis DECIMAL(18,2), @ContributoRichiestoAltreFontiequalthis DECIMAL(18,2), @ImportoDisavanzoCostiAmmessiequalthis DECIMAL(18,2), @ContributoDisavanzoCostiAmmessiequalthis DECIMAL(18,2), @ContributoRichiestoRecuperoAnticipoequalthis DECIMAL(18,2), @ImportoComputoMetricoAmmessoequalthis DECIMAL(18,2), @ImportoAmmessoequalthis DECIMAL(18,2), @ContributoAmmessoequalthis DECIMAL(18,2), @ContributoAmmessoAltreFontiequalthis DECIMAL(18,2), @ContributoAmmessoRecuperoAnticipoequalthis DECIMAL(18,2), @Ammessoequalthis BIT, @Istruttoreequalthis VARCHAR(255), @DataValutazioneequalthis DATETIME, @CodSanzioneVariazioneInvestimentiequalthis VARCHAR(255)',@IdPagamentoRichiestoequalthis , @IdDomandaPagamentoequalthis , @IdInvestimentoequalthis , @DataRichiestaPagamentoequalthis , @ImportoComputoMetricoequalthis , @ImportoRichiestoequalthis , @ContributoRichiestoequalthis , @ContributoRichiestoAltreFontiequalthis , @ImportoDisavanzoCostiAmmessiequalthis , @ContributoDisavanzoCostiAmmessiequalthis , @ContributoRichiestoRecuperoAnticipoequalthis , @ImportoComputoMetricoAmmessoequalthis , @ImportoAmmessoequalthis , @ContributoAmmessoequalthis , @ContributoAmmessoAltreFontiequalthis , @ContributoAmmessoRecuperoAnticipoequalthis , @Ammessoequalthis , @Istruttoreequalthis , @DataValutazioneequalthis , @CodSanzioneVariazioneInvestimentiequalthis ;
	else
		SELECT ID_PAGAMENTO_RICHIESTO, ID_INVESTIMENTO, DATA_RICHIESTA_PAGAMENTO, CONTRIBUTO_RICHIESTO, CONTRIBUTO_AMMESSO, AMMESSO, ISTRUTTORE, DATA_VALUTAZIONE, IMPORTO_COMPUTO_METRICO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_PROGRAMMAZIONE, DESCRIZIONE, DATA_VARIAZIONE, OPERATORE_VARIAZIONE, COD_TIPO_INVESTIMENTO, COD_STP, ID_UNITA_MISURA, QUANTITA, COSTO_INVESTIMENTO, SPESE_GENERALI, CONTRIBUTO_RICHIESTO_INVESTIMENTO, QUOTA_CONTRIBUTO_RICHIESTO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, ID_OBIETTIVO_MISURA, ID_CODIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, ID_SPECIFICA_INVESTIMENTO, INVESTIMENTO_AMMESSO, ISTRUTTORE_INVESTIMENTO, ID_INVESTIMENTO_ORIGINALE, DATA_VALUTAZIONE_INVESTIMENTO, VALUTAZIONE_INVESTIMENTO, ID_VARIANTE, IMPORTO_COMPUTO_METRICO_AMMESSO, CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO, CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO, NOTE_ISTRUTTORE, COD_SANZIONE_VARIAZIONE_INVESTIMENTI, IMPORTO_DISAVANZO_COSTI_AMMESSI, CONTRIBUTO_DISAVANZO_COSTI_AMMESSI, CONTRIBUTO_RICHIESTO_ALTRE_FONTI, CONTRIBUTO_AMMESSO_ALTRE_FONTI
		FROM vPAGAMENTI_RICHIESTI
		WHERE 
			((@IdPagamentoRichiestoequalthis IS NULL) OR ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiestoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@DataRichiestaPagamentoequalthis IS NULL) OR DATA_RICHIESTA_PAGAMENTO = @DataRichiestaPagamentoequalthis) AND 
			((@ImportoComputoMetricoequalthis IS NULL) OR IMPORTO_COMPUTO_METRICO = @ImportoComputoMetricoequalthis) AND 
			((@ImportoRichiestoequalthis IS NULL) OR IMPORTO_RICHIESTO = @ImportoRichiestoequalthis) AND 
			((@ContributoRichiestoequalthis IS NULL) OR CONTRIBUTO_RICHIESTO = @ContributoRichiestoequalthis) AND 
			((@ContributoRichiestoAltreFontiequalthis IS NULL) OR CONTRIBUTO_RICHIESTO_ALTRE_FONTI = @ContributoRichiestoAltreFontiequalthis) AND 
			((@ImportoDisavanzoCostiAmmessiequalthis IS NULL) OR IMPORTO_DISAVANZO_COSTI_AMMESSI = @ImportoDisavanzoCostiAmmessiequalthis) AND 
			((@ContributoDisavanzoCostiAmmessiequalthis IS NULL) OR CONTRIBUTO_DISAVANZO_COSTI_AMMESSI = @ContributoDisavanzoCostiAmmessiequalthis) AND 
			((@ContributoRichiestoRecuperoAnticipoequalthis IS NULL) OR CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO = @ContributoRichiestoRecuperoAnticipoequalthis) AND 
			((@ImportoComputoMetricoAmmessoequalthis IS NULL) OR IMPORTO_COMPUTO_METRICO_AMMESSO = @ImportoComputoMetricoAmmessoequalthis) AND 
			((@ImportoAmmessoequalthis IS NULL) OR IMPORTO_AMMESSO = @ImportoAmmessoequalthis) AND 
			((@ContributoAmmessoequalthis IS NULL) OR CONTRIBUTO_AMMESSO = @ContributoAmmessoequalthis) AND 
			((@ContributoAmmessoAltreFontiequalthis IS NULL) OR CONTRIBUTO_AMMESSO_ALTRE_FONTI = @ContributoAmmessoAltreFontiequalthis) AND 
			((@ContributoAmmessoRecuperoAnticipoequalthis IS NULL) OR CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO = @ContributoAmmessoRecuperoAnticipoequalthis) AND 
			((@Ammessoequalthis IS NULL) OR AMMESSO = @Ammessoequalthis) AND 
			((@Istruttoreequalthis IS NULL) OR ISTRUTTORE = @Istruttoreequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@CodSanzioneVariazioneInvestimentiequalthis IS NULL) OR COD_SANZIONE_VARIAZIONE_INVESTIMENTI = @CodSanzioneVariazioneInvestimentiequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPagamentiRichiestiFindSelect';

