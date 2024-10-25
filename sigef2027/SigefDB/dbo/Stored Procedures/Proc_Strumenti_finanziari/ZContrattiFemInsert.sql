CREATE PROCEDURE [dbo].[ZContrattiFemInsert]
(
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
	INSERT INTO CONTRATTI_FEM
	(
		ID_BANDO, 
		ID_PROGETTO, 
		DATA_STIPULA_CONTRATTO, 
		SEGNATURA, 
		DATA_SEGNATURA, 
		IMPORTO, 
		DATA_CREAZIONE, 
		DATA_AGGIORNAMENTO, 
		OPERATORE_CREAZIONE, 
		OPERATORE_AGGIORNAMENTO, 
		ID_IMPRESA, 
		ID_DOMANDA_PAGAMENTO, 
		NUMERO, 
		ID_FILE, 
		DESCRIZIONE, 
		ID_PROGETTO_RIF
	)
	VALUES
	(
		@IdBando, 
		@IdProgetto, 
		@DataStipulaContratto, 
		@Segnatura, 
		@DataSegnatura, 
		@Importo, 
		@DataCreazione, 
		@DataAggiornamento, 
		@OperatoreCreazione, 
		@OperatoreAggiornamento, 
		@IdImpresa, 
		@IdDomandaPagamento, 
		@Numero, 
		@IdFile, 
		@Descrizione, 
		@IdProgettoRif
	)
	SELECT SCOPE_IDENTITY() AS ID_CONTRATTO_FEM

GO