CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioInsert]
(
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
	INSERT INTO RECUPERO_BENEFICIARIO
	(
		ID_PROGETTO, 
		ID_IMPRESA, 
		ORIGINE, 
		ID_IRREGOLARITA, 
		ID_REVOCA, 
		ID_ERRORE, 
		DECRETO_RECUPERO_NUMERO, 
		DECRETO_RECUPERO_DATA, 
		DATA_AVVIO_RECUPERO, 
		SEGNATURA_PALEO_COMUNICAZIONE_BENEFICIARIO, 
		CONTRIBUTO, 
		INTERESSI, 
		SPESE, 
		SANZIONI, 
		TOTALE_DA_RECUPERARE, 
		NOTE, 
		DEFINITIVO, 
		IMPORTO_RECUPERATO, 
		IMPORTO_IRRECUPERABILE
	)
	VALUES
	(
		@IdProgetto, 
		@IdImpresa, 
		@Origine, 
		@IdIrregolarita, 
		@IdRevoca, 
		@IdErrore, 
		@DecretoRecuperoNumero, 
		@DecretoRecuperoData, 
		@DataAvvioRecupero, 
		@SegnaturaPaleoComunicazioneBeneficiario, 
		@Contributo, 
		@Interessi, 
		@Spese, 
		@Sanzioni, 
		@TotaleDaRecuperare, 
		@Note, 
		@Definitivo, 
		@ImportoRecuperato, 
		@ImportoIrrecuperabile
	)
	SELECT SCOPE_IDENTITY() AS ID_RECUPERO_BENEFICIARIO