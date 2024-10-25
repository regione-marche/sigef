CREATE PROCEDURE [dbo].[ZPagamentiRichiestiInsert]
(
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
	SET @Ammesso = ISNULL(@Ammesso,((0)))
	INSERT INTO PAGAMENTI_RICHIESTI
	(
		ID_INVESTIMENTO, 
		DATA_RICHIESTA_PAGAMENTO, 
		CONTRIBUTO_RICHIESTO, 
		CONTRIBUTO_AMMESSO, 
		AMMESSO, 
		ISTRUTTORE, 
		DATA_VALUTAZIONE, 
		IMPORTO_COMPUTO_METRICO, 
		IMPORTO_RICHIESTO, 
		IMPORTO_AMMESSO, 
		ID_DOMANDA_PAGAMENTO, 
		IMPORTO_COMPUTO_METRICO_AMMESSO, 
		CONTRIBUTO_RICHIESTO_RECUPERO_ANTICIPO, 
		CONTRIBUTO_AMMESSO_RECUPERO_ANTICIPO, 
		NOTE_ISTRUTTORE, 
		COD_SANZIONE_VARIAZIONE_INVESTIMENTI, 
		IMPORTO_DISAVANZO_COSTI_AMMESSI, 
		CONTRIBUTO_DISAVANZO_COSTI_AMMESSI, 
		CONTRIBUTO_RICHIESTO_ALTRE_FONTI, 
		CONTRIBUTO_AMMESSO_ALTRE_FONTI
	)
	VALUES
	(
		@IdInvestimento, 
		@DataRichiestaPagamento, 
		@ContributoRichiesto, 
		@ContributoAmmesso, 
		@Ammesso, 
		@Istruttore, 
		@DataValutazione, 
		@ImportoComputoMetrico, 
		@ImportoRichiesto, 
		@ImportoAmmesso, 
		@IdDomandaPagamento, 
		@ImportoComputoMetricoAmmesso, 
		@ContributoRichiestoRecuperoAnticipo, 
		@ContributoAmmessoRecuperoAnticipo, 
		@NoteIstruttore, 
		@CodSanzioneVariazioneInvestimenti, 
		@ImportoDisavanzoCostiAmmessi, 
		@ContributoDisavanzoCostiAmmessi, 
		@ContributoRichiestoAltreFonti, 
		@ContributoAmmessoAltreFonti
	)
	SELECT SCOPE_IDENTITY() AS ID_PAGAMENTO_RICHIESTO, @Ammesso AS AMMESSO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPagamentiRichiestiInsert';

