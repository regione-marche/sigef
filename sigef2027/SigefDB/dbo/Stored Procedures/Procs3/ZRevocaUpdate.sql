CREATE PROCEDURE [dbo].[ZRevocaUpdate]
(
	@IdRevoca INT, 
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
	UPDATE REVOCA
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_IMPRESA = @IdImpresa, 
		ORIGINE = @Origine, 
		NOTE = @Note, 
		IMPORTO_REVOCA = @ImportoRevoca, 
		NUMERO_ATTO = @NumeroAtto, 
		DATA_ATTO = @DataAtto, 
		RECUPERO_BENEFICIARIO = @RecuperoBeneficiario, 
		REVOCA_CONTRIBUTO = @RevocaContributo, 
		IMPORTO_DA_RECUPERARE = @ImportoDaRecuperare, 
		INTERESSI_LEGALI = @InteressiLegali, 
		SPESE_NOTIFICA = @SpeseNotifica, 
		SANZIONI = @Sanzioni, 
		TOTALE = @Totale, 
		IMPORTO_RECUPERATO = @ImportoRecuperato, 
		IRRECUPERABILE = @Irrecuperabile, 
		DATA_IRRECUPERABILE = @DataIrrecuperabile, 
		IMPORTO_IRRECUPERABILE = @ImportoIrrecuperabile, 
		DATA_MODIFICA = @DataModifica, 
		RECUPERATO = @Recuperato, 
		STABILITA = @Stabilita
	WHERE 
		(ID_REVOCA = @IdRevoca)