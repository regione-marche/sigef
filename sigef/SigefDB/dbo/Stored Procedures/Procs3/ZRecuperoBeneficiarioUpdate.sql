CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioUpdate]
(
	@IdRecuperoBeneficiario INT, 
	@IdProgetto INT, 
	@IdImpresa INT, 
	@Origine VARCHAR(255), 
	@IdIrregolarita INT, 
	@IdRevoca INT, 
	@IdErrore INT, 
	@DecretoRecuperoNumero VARCHAR(255), 
	@DecretoRecuperoData DATETIME, 
	@DataAvvioRecupero DATETIME, 
	@SegnaturaPaleoComunicazioneBeneficiario VARCHAR(255), 
	@Contributo DECIMAL(15,2), 
	@Interessi DECIMAL(15,2), 
	@Spese DECIMAL(15,2), 
	@Sanzioni DECIMAL(15,2), 
	@TotaleDaRecuperare DECIMAL(15,2), 
	@Note VARCHAR(max), 
	@Definitivo BIT, 
	@ImportoRecuperato DECIMAL(15,2), 
	@ImportoIrrecuperabile DECIMAL(15,2)
)
AS
	UPDATE RECUPERO_BENEFICIARIO
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_IMPRESA = @IdImpresa, 
		ORIGINE = @Origine, 
		ID_IRREGOLARITA = @IdIrregolarita, 
		ID_REVOCA = @IdRevoca, 
		ID_ERRORE = @IdErrore, 
		DECRETO_RECUPERO_NUMERO = @DecretoRecuperoNumero, 
		DECRETO_RECUPERO_DATA = @DecretoRecuperoData, 
		DATA_AVVIO_RECUPERO = @DataAvvioRecupero, 
		SEGNATURA_PALEO_COMUNICAZIONE_BENEFICIARIO = @SegnaturaPaleoComunicazioneBeneficiario, 
		CONTRIBUTO = @Contributo, 
		INTERESSI = @Interessi, 
		SPESE = @Spese, 
		SANZIONI = @Sanzioni, 
		TOTALE_DA_RECUPERARE = @TotaleDaRecuperare, 
		NOTE = @Note, 
		DEFINITIVO = @Definitivo, 
		IMPORTO_RECUPERATO = @ImportoRecuperato, 
		IMPORTO_IRRECUPERABILE = @ImportoIrrecuperabile
	WHERE 
		(ID_RECUPERO_BENEFICIARIO = @IdRecuperoBeneficiario)
