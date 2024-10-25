CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneInsert]
(
	@IdDomandaPagamento INT, 
	@Conclusa BIT, 
	@Annullata BIT, 
	@IdUtente INT, 
	@Data DATETIME, 
	@IdNote INT
)
AS
	SET @Conclusa = ISNULL(@Conclusa,((0)))
	SET @Annullata = ISNULL(@Annullata,((0)))
	INSERT INTO CORRETTIVA_RENDICONTAZIONE
	(
		ID_DOMANDA_PAGAMENTO, 
		CONCLUSA, 
		ANNULLATA, 
		ID_UTENTE, 
		DATA, 
		ID_NOTE
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@Conclusa, 
		@Annullata, 
		@IdUtente, 
		@Data, 
		@IdNote
	)
	SELECT SCOPE_IDENTITY() AS ID, @Conclusa AS CONCLUSA, @Annullata AS ANNULLATA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneInsert]
(
	@IdDomandaPagamento INT, 
	@IdInvestimentoDa INT, 
	@IdInvestimentoA INT, 
	@ImportoSpostato DECIMAL(18,2), 
	@Conclusa BIT, 
	@Annullata BIT, 
	@IdUtente INT, 
	@Data DATETIME, 
	@IdNote INT, 
	@IdJsonLog INT
)
AS
	SET @Conclusa = ISNULL(@Conclusa,((0)))
	SET @Annullata = ISNULL(@Annullata,((0)))
	INSERT INTO CORRETTIVA_RENDICONTAZIONE
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_INVESTIMENTO_DA, 
		ID_INVESTIMENTO_A, 
		IMPORTO_SPOSTATO, 
		CONCLUSA, 
		ANNULLATA, 
		ID_UTENTE, 
		DATA, 
		ID_NOTE, 
		ID_JSON_LOG
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdInvestimentoDa, 
		@IdInvestimentoA, 
		@ImportoSpostato, 
		@Conclusa, 
		@Annullata, 
		@IdUtente, 
		@Data, 
		@IdNote, 
		@IdJsonLog
	)
	SELECT SCOPE_IDENTITY() AS ID, @Conclusa AS CONCLUSA, @Annullata AS ANNULLATA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCorrettivaRendicontazioneInsert';

