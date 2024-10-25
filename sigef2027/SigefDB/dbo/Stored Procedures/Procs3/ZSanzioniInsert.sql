CREATE PROCEDURE [dbo].[ZSanzioniInsert]
(
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
	INSERT INTO SANZIONI
	(
		COD_TIPO, 
		ID_DOMANDA_PAGAMENTO, 
		ID_PROGETTO, 
		DATA_APPLICAZIONE, 
		OPERATORE, 
		AMMONTARE, 
		ID_INVESTIMENTO, 
		DURATA, 
		VALORE_DURATA, 
		GRAVITA, 
		VALORE_GRAVITA, 
		ENTITA, 
		VALORE_ENTITA, 
		MOTIVAZIONE
	)
	VALUES
	(
		@CodTipo, 
		@IdDomandaPagamento, 
		@IdProgetto, 
		@DataApplicazione, 
		@Operatore, 
		@Ammontare, 
		@IdInvestimento, 
		@Durata, 
		@ValoreDurata, 
		@Gravita, 
		@ValoreGravita, 
		@Entita, 
		@ValoreEntita, 
		@Motivazione
	)
	SELECT SCOPE_IDENTITY() AS ID_SANZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZSanzioniInsert]
(
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
	INSERT INTO SANZIONI
	(
		COD_TIPO, 
		ID_DOMANDA_PAGAMENTO, 
		ID_PROGETTO, 
		DATA_APPLICAZIONE, 
		OPERATORE, 
		AMMONTARE, 
		ID_INVESTIMENTO, 
		DURATA, 
		VALORE_DURATA, 
		GRAVITA, 
		VALORE_GRAVITA, 
		ENTITA, 
		VALORE_ENTITA, 
		MOTIVAZIONE
	)
	VALUES
	(
		@CodTipo, 
		@IdDomandaPagamento, 
		@IdProgetto, 
		@DataApplicazione, 
		@Operatore, 
		@Ammontare, 
		@IdInvestimento, 
		@Durata, 
		@ValoreDurata, 
		@Gravita, 
		@ValoreGravita, 
		@Entita, 
		@ValoreEntita, 
		@Motivazione
	)
	SELECT SCOPE_IDENTITY() AS ID_SANZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSanzioniInsert';

