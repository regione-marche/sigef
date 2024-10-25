CREATE PROCEDURE [dbo].[ZRevocaInsert]
(
	@IdProgetto INT, 
	@IdImpresa INT, 
	@Origine VARCHAR(255), 
	@Note VARCHAR(max), 
	@ImportoRevoca DECIMAL(15,2), 
	@NumeroAtto VARCHAR(255), 
	@DataAtto DATETIME, 
	@RecuperoBeneficiario BIT, 
	@RevocaContributo BIT, 
	@ImportoDaRecuperare DECIMAL(15,2), 
	@InteressiLegali DECIMAL(15,2), 
	@SpeseNotifica DECIMAL(15,2), 
	@Sanzioni DECIMAL(15,2), 
	@Totale DECIMAL(15,2), 
	@ImportoRecuperato DECIMAL(15,2), 
	@Irrecuperabile BIT, 
	@DataIrrecuperabile DATETIME, 
	@ImportoIrrecuperabile DECIMAL(15,2), 
	@DataModifica DATETIME, 
	@Recuperato BIT, 
	@Stabilita BIT
)
AS
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO REVOCA
	(
		ID_PROGETTO, 
		ID_IMPRESA, 
		ORIGINE, 
		NOTE, 
		IMPORTO_REVOCA, 
		NUMERO_ATTO, 
		DATA_ATTO, 
		RECUPERO_BENEFICIARIO, 
		REVOCA_CONTRIBUTO, 
		IMPORTO_DA_RECUPERARE, 
		INTERESSI_LEGALI, 
		SPESE_NOTIFICA, 
		SANZIONI, 
		TOTALE, 
		IMPORTO_RECUPERATO, 
		IRRECUPERABILE, 
		DATA_IRRECUPERABILE, 
		IMPORTO_IRRECUPERABILE, 
		DATA_MODIFICA, 
		RECUPERATO, 
		STABILITA
	)
	VALUES
	(
		@IdProgetto, 
		@IdImpresa, 
		@Origine, 
		@Note, 
		@ImportoRevoca, 
		@NumeroAtto, 
		@DataAtto, 
		@RecuperoBeneficiario, 
		@RevocaContributo, 
		@ImportoDaRecuperare, 
		@InteressiLegali, 
		@SpeseNotifica, 
		@Sanzioni, 
		@Totale, 
		@ImportoRecuperato, 
		@Irrecuperabile, 
		@DataIrrecuperabile, 
		@ImportoIrrecuperabile, 
		@DataModifica, 
		@Recuperato, 
		@Stabilita
	)
	SELECT SCOPE_IDENTITY() AS ID_REVOCA, @DataModifica AS DATA_MODIFICA