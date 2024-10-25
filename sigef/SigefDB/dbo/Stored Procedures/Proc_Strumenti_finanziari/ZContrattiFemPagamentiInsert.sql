CREATE PROCEDURE [dbo].[ZContrattiFemPagamentiInsert]
(
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
	INSERT INTO CONTRATTI_FEM_PAGAMENTI
	(
		ID_CONTRATTO_FEM, 
		ID_PROGETTO, 
		COD_TIPO, 
		ESTREMI, 
		DATA, 
		IMPORTO, 
		ID_FILE, 
		DATA_CREAZIONE, 
		OPERATORE_CREAZIONE, 
		DATA_AGGIORNAMENTO, 
		OPERATORE_AGGIORNAMENTO, 
		ID_IMPRESA, 
		ID_DOMANDA_PAGAMENTO
	)
	VALUES
	(
		@IdContrattoFem, 
		@IdProgetto, 
		@CodTipo, 
		@Estremi, 
		@Data, 
		@Importo, 
		@IdFile, 
		@DataCreazione, 
		@OperatoreCreazione, 
		@DataAggiornamento, 
		@OperatoreAggiornamento, 
		@IdImpresa, 
		@IdDomandaPagamento
	)
	SELECT SCOPE_IDENTITY() AS ID_CONTRATTO_FEM_PAGAMENTI

GO