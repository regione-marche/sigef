CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneUpdate]
(
	@Id INT, 
	@IdDomandaPagamento INT, 
	@Conclusa BIT, 
	@Annullata BIT, 
	@IdUtente INT, 
	@Data DATETIME, 
	@IdNote INT
)
AS
	UPDATE CORRETTIVA_RENDICONTAZIONE
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		CONCLUSA = @Conclusa, 
		ANNULLATA = @Annullata, 
		ID_UTENTE = @IdUtente, 
		DATA = @Data, 
		ID_NOTE = @IdNote
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneUpdate]
(
	@Id INT, 
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
	UPDATE CORRETTIVA_RENDICONTAZIONE
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_INVESTIMENTO_DA = @IdInvestimentoDa, 
		ID_INVESTIMENTO_A = @IdInvestimentoA, 
		IMPORTO_SPOSTATO = @ImportoSpostato, 
		CONCLUSA = @Conclusa, 
		ANNULLATA = @Annullata, 
		ID_UTENTE = @IdUtente, 
		DATA = @Data, 
		ID_NOTE = @IdNote, 
		ID_JSON_LOG = @IdJsonLog
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCorrettivaRendicontazioneUpdate';

