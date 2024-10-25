CREATE PROCEDURE [dbo].[ZPagamentiRichiestiUpdate]
(
	@IdPagamentoRichiesto INT, 
	@IdInvestimento INT, 
	@DataRichiestaPagamento DATETIME, 
	@ContributoRichiesto DECIMAL(18,2), 
	@ContributoAmmesso DECIMAL(18,2), 
	@Ammesso BIT, 
	@Istruttore VARCHAR(255), 
	@DataValutazione DATETIME, 
	@ImportoComputoMetrico DECIMAL(18,2), 
	@ImportoRichiesto DECIMAL(18,2), 
	@ImportoAmmesso DECIMAL(18,2), 
	@IdDomandaPagamento INT, 
	@ImportoComputoMetricoAmmesso DECIMAL(18,2), 
	@ContributoRichiestoRecuperoAnticipo DECIMAL(18,2), 
	@ContributoAmmessoRecuperoAnticipo DECIMAL(18,2), 
	@NoteIstruttore NTEXT, 
	@CodSanzioneVariazioneInvestimenti VARCHAR(255), 
	@ImportoDisavanzoCostiAmmessi DECIMAL(18,2), 
	@ContributoDisavanzoCostiAmmessi DECIMAL(18,2), 
	@ContributoRichiestoAltreFonti DECIMAL(18,2), 
	@ContributoAmmessoAltreFonti DECIMAL(18,2)
)
AS
	UPDATE PAGAMENTI_RICHIESTI
	SET
		ID_INVESTIMENTO = @IdInvestimento, 
		DATA_RICHIESTA_PAGAMENTO = @DataRichiestaPagamento, 
		CONTRIBUTO_RICHIESTO = @ContributoRichiesto, 
		CONTRIBUTO_AMMESSO = @ContributoAmmesso, 
		AMMESSO = @Ammesso, 
		ISTRUTTORE = @Istruttore, 
		DATA_VALUTAZIONE = @DataValutazione, 
		IMPORTO_COMPUTO_METRICO = @ImportoComputoMetrico, 
		IMPORTO_RICHIESTO = @ImportoRichiesto, 
		IMPORTO_AMMESSO = @ImportoAmmesso, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		IMPORTO_COMPUTO_METRICO_AMMESSO = @ImportoComputoMetricoAmmesso, 
		CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO = @ContributoRichiestoRecuperoAnticipo, 
		CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO = @ContributoAmmessoRecuperoAnticipo, 
		NOTE_ISTRUTTORE = @NoteIstruttore, 
		COD_SANZIONE_VARIAZIONE_INVESTIMENTI = @CodSanzioneVariazioneInvestimenti, 
		IMPORTO_DISAVANZO_COSTI_AMMESSI = @ImportoDisavanzoCostiAmmessi, 
		CONTRIBUTO_DISAVANZO_COSTI_AMMESSI = @ContributoDisavanzoCostiAmmessi, 
		CONTRIBUTO_RICHIESTO_ALTRE_FONTI = @ContributoRichiestoAltreFonti, 
		CONTRIBUTO_AMMESSO_ALTRE_FONTI = @ContributoAmmessoAltreFonti
	WHERE 
		(ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiesto)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPagamentiRichiestiUpdate';

