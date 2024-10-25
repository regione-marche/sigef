CREATE PROCEDURE [dbo].[ZContrattiFemUpdate]
(
	@IdContrattoFem INT, 
	@IdBando INT, 
	@IdProgetto INT, 
	@DataStipulaContratto DATETIME, 
	@Segnatura VARCHAR(255), 
	@DataSegnatura DATETIME, 
	@Importo DECIMAL(15,2), 
	@DataCreazione DATETIME, 
	@DataAggiornamento DATETIME, 
	@OperatoreCreazione INT, 
	@OperatoreAggiornamento INT, 
	@IdImpresa INT, 
	@IdDomandaPagamento INT, 
	@Numero VARCHAR(max), 
	@IdFile INT, 
	@Descrizione VARCHAR(255), 
	@IdProgettoRif INT
)
AS
	UPDATE CONTRATTI_FEM
	SET
		ID_BANDO = @IdBando, 
		ID_PROGETTO = @IdProgetto, 
		DATA_STIPULA_CONTRATTO = @DataStipulaContratto, 
		SEGNATURA = @Segnatura, 
		DATA_SEGNATURA = @DataSegnatura, 
		IMPORTO = @Importo, 
		DATA_CREAZIONE = @DataCreazione, 
		DATA_AGGIORNAMENTO = @DataAggiornamento, 
		OPERATORE_CREAZIONE = @OperatoreCreazione, 
		OPERATORE_AGGIORNAMENTO = @OperatoreAggiornamento, 
		ID_IMPRESA = @IdImpresa, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		NUMERO = @Numero, 
		ID_FILE = @IdFile, 
		DESCRIZIONE = @Descrizione, 
		ID_PROGETTO_RIF = @IdProgettoRif
	WHERE 
		(ID_CONTRATTO_FEM = @IdContrattoFem)

GO