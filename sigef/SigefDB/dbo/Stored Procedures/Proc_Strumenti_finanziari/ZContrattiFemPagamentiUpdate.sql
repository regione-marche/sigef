CREATE PROCEDURE [dbo].[ZContrattiFemPagamentiUpdate]
(
	@IdContrattoFemPagamenti INT, 
	@IdContrattoFem INT, 
	@IdProgetto INT, 
	@CodTipo VARCHAR(255), 
	@Estremi VARCHAR(255), 
	@Data DATETIME, 
	@Importo DECIMAL(18,2), 
	@IdFile INT, 
	@DataCreazione DATETIME, 
	@OperatoreCreazione INT, 
	@DataAggiornamento DATETIME, 
	@OperatoreAggiornamento INT, 
	@IdImpresa INT, 
	@IdDomandaPagamento INT
)
AS
	UPDATE CONTRATTI_FEM_PAGAMENTI
	SET
		ID_CONTRATTO_FEM = @IdContrattoFem, 
		ID_PROGETTO = @IdProgetto, 
		COD_TIPO = @CodTipo, 
		ESTREMI = @Estremi, 
		DATA = @Data, 
		IMPORTO = @Importo, 
		ID_FILE = @IdFile, 
		DATA_CREAZIONE = @DataCreazione, 
		OPERATORE_CREAZIONE = @OperatoreCreazione, 
		DATA_AGGIORNAMENTO = @DataAggiornamento, 
		OPERATORE_AGGIORNAMENTO = @OperatoreAggiornamento, 
		ID_IMPRESA = @IdImpresa, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento
	WHERE 
		(ID_CONTRATTO_FEM_PAGAMENTI = @IdContrattoFemPagamenti)

GO