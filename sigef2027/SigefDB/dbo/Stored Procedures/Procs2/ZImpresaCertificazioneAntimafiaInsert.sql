CREATE PROCEDURE [dbo].[ZImpresaCertificazioneAntimafiaInsert]
(
	@IdImpresa INT, 
	@EsenzioneCertificazione BIT, 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@NumeroProtocolloRichiesta VARCHAR(30), 
	@DataProtocolloRichiesta DATETIME, 
	@NumeroProtocolloCamerale VARCHAR(30), 
	@DataCertificatoCamerale DATETIME, 
	@EsitoCertificatoCamerale BIT, 
	@NumeroProtocolloPrefettizio VARCHAR(30), 
	@DataCertificatoPrefettizio DATETIME, 
	@EsitoCertificatoPrefettizio BIT, 
	@NumeroProtocolloComunicazione VARCHAR(30), 
	@DataProtocolloComunicazione DATETIME, 
	@DataAcquisizioneAntimafia DATETIME, 
	@NumeroProtocolloAcquisizioneAntimafia VARCHAR(30)
)
AS
	SET @EsenzioneCertificazione = ISNULL(@EsenzioneCertificazione,((0)))
	INSERT INTO IMPRESA_CERTIFICAZIONE_ANTIMAFIA
	(
		ID_IMPRESA, 
		ESENZIONE_CERTIFICAZIONE, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		NUMERO_PROTOCOLLO_RICHIESTA, 
		DATA_PROTOCOLLO_RICHIESTA, 
		NUMERO_PROTOCOLLO_CAMERALE, 
		DATA_CERTIFICATO_CAMERALE, 
		ESITO_CERTIFICATO_CAMERALE, 
		NUMERO_PROTOCOLLO_PREFETTIZIO, 
		DATA_CERTIFICATO_PREFETTIZIO, 
		ESITO_CERTIFICATO_PREFETTIZIO, 
		NUMERO_PROTOCOLLO_COMUNICAZIONE, 
		DATA_PROTOCOLLO_COMUNICAZIONE, 
		DATA_ACQUISIZIONE_ANTIMAFIA, 
		NUMERO_PROTOCOLLO_ACQUISIZIONE_ANTIMAFIA
	)
	VALUES
	(
		@IdImpresa, 
		@EsenzioneCertificazione, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@NumeroProtocolloRichiesta, 
		@DataProtocolloRichiesta, 
		@NumeroProtocolloCamerale, 
		@DataCertificatoCamerale, 
		@EsitoCertificatoCamerale, 
		@NumeroProtocolloPrefettizio, 
		@DataCertificatoPrefettizio, 
		@EsitoCertificatoPrefettizio, 
		@NumeroProtocolloComunicazione, 
		@DataProtocolloComunicazione, 
		@DataAcquisizioneAntimafia, 
		@NumeroProtocolloAcquisizioneAntimafia
	)
	SELECT SCOPE_IDENTITY() AS ID, @EsenzioneCertificazione AS ESENZIONE_CERTIFICAZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaCertificazioneAntimafiaInsert';

