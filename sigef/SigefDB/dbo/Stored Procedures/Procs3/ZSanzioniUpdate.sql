CREATE PROCEDURE [dbo].[ZSanzioniUpdate]
(
	@IdSanzione INT, 
	@CodTipo VARCHAR(255), 
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@DataApplicazione DATETIME, 
	@Operatore VARCHAR(255), 
	@Ammontare DECIMAL(18,2), 
	@IdInvestimento INT, 
	@Durata INT, 
	@ValoreDurata DECIMAL(18,2), 
	@Gravita INT, 
	@ValoreGravita DECIMAL(18,2), 
	@Entita INT, 
	@ValoreEntita DECIMAL(18,2), 
	@Motivazione NTEXT
)
AS
	UPDATE SANZIONI
	SET
		COD_TIPO = @CodTipo, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_PROGETTO = @IdProgetto, 
		DATA_APPLICAZIONE = @DataApplicazione, 
		OPERATORE = @Operatore, 
		AMMONTARE = @Ammontare, 
		ID_INVESTIMENTO = @IdInvestimento, 
		DURATA = @Durata, 
		VALORE_DURATA = @ValoreDurata, 
		GRAVITA = @Gravita, 
		VALORE_GRAVITA = @ValoreGravita, 
		ENTITA = @Entita, 
		VALORE_ENTITA = @ValoreEntita, 
		MOTIVAZIONE = @Motivazione
	WHERE 
		(ID_SANZIONE = @IdSanzione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZSanzioniUpdate]
(
	@IdSanzione INT, 
	@CodTipo VARCHAR(10), 
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@DataApplicazione DATETIME, 
	@Operatore VARCHAR(16), 
	@Ammontare DECIMAL(18,2), 
	@IdInvestimento INT, 
	@Durata INT, 
	@ValoreDurata DECIMAL(18,2), 
	@Gravita INT, 
	@ValoreGravita DECIMAL(18,2), 
	@Entita INT, 
	@ValoreEntita DECIMAL(18,2), 
	@Motivazione NTEXT
)
AS
	UPDATE SANZIONI
	SET
		COD_TIPO = @CodTipo, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_PROGETTO = @IdProgetto, 
		DATA_APPLICAZIONE = @DataApplicazione, 
		OPERATORE = @Operatore, 
		AMMONTARE = @Ammontare, 
		ID_INVESTIMENTO = @IdInvestimento, 
		DURATA = @Durata, 
		VALORE_DURATA = @ValoreDurata, 
		GRAVITA = @Gravita, 
		VALORE_GRAVITA = @ValoreGravita, 
		ENTITA = @Entita, 
		VALORE_ENTITA = @ValoreEntita, 
		MOTIVAZIONE = @Motivazione
	WHERE 
		(ID_SANZIONE = @IdSanzione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSanzioniUpdate';

