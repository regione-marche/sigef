CREATE PROCEDURE [dbo].[ZImpresaCertificazioneAntimafiaUpdate]
(
	@Id INT, 
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
	UPDATE IMPRESA_CERTIFICAZIONE_ANTIMAFIA
	SET
		ID_IMPRESA = @IdImpresa, 
		ESENZIONE_CERTIFICAZIONE = @EsenzioneCertificazione, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		NUMERO_PROTOCOLLO_RICHIESTA = @NumeroProtocolloRichiesta, 
		DATA_PROTOCOLLO_RICHIESTA = @DataProtocolloRichiesta, 
		NUMERO_PROTOCOLLO_CAMERALE = @NumeroProtocolloCamerale, 
		DATA_CERTIFICATO_CAMERALE = @DataCertificatoCamerale, 
		ESITO_CERTIFICATO_CAMERALE = @EsitoCertificatoCamerale, 
		NUMERO_PROTOCOLLO_PREFETTIZIO = @NumeroProtocolloPrefettizio, 
		DATA_CERTIFICATO_PREFETTIZIO = @DataCertificatoPrefettizio, 
		ESITO_CERTIFICATO_PREFETTIZIO = @EsitoCertificatoPrefettizio, 
		NUMERO_PROTOCOLLO_COMUNICAZIONE = @NumeroProtocolloComunicazione, 
		DATA_PROTOCOLLO_COMUNICAZIONE = @DataProtocolloComunicazione, 
		DATA_ACQUISIZIONE_ANTIMAFIA = @DataAcquisizioneAntimafia, 
		NUMERO_PROTOCOLLO_ACQUISIZIONE_ANTIMAFIA = @NumeroProtocolloAcquisizioneAntimafia
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaCertificazioneAntimafiaUpdate';

