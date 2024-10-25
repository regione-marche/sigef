CREATE PROCEDURE [dbo].[ZImpresaCertificazioneAntimafiaFindSelect]
(
	@Idequalthis INT, 
	@IdImpresaequalthis INT, 
	@EsenzioneCertificazioneequalthis BIT, 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@NumeroProtocolloRichiestaequalthis VARCHAR(30), 
	@DataProtocolloRichiestaequalthis DATETIME, 
	@NumeroProtocolloCameraleequalthis VARCHAR(30), 
	@DataCertificatoCameraleequalthis DATETIME, 
	@EsitoCertificatoCameraleequalthis BIT, 
	@NumeroProtocolloPrefettizioequalthis VARCHAR(30), 
	@DataCertificatoPrefettizioequalthis DATETIME, 
	@EsitoCertificatoPrefettizioequalthis BIT, 
	@NumeroProtocolloComunicazioneequalthis VARCHAR(30), 
	@DataProtocolloComunicazioneequalthis DATETIME, 
	@DataAcquisizioneAntimafiaequalthis DATETIME, 
	@NumeroProtocolloAcquisizioneAntimafiaequalthis VARCHAR(30)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_IMPRESA, ESENZIONE_CERTIFICAZIONE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, NUMERO_PROTOCOLLO_RICHIESTA, DATA_PROTOCOLLO_RICHIESTA, NUMERO_PROTOCOLLO_CAMERALE, DATA_CERTIFICATO_CAMERALE, ESITO_CERTIFICATO_CAMERALE, NUMERO_PROTOCOLLO_PREFETTIZIO, DATA_CERTIFICATO_PREFETTIZIO, ESITO_CERTIFICATO_PREFETTIZIO, NUMERO_PROTOCOLLO_COMUNICAZIONE, DATA_PROTOCOLLO_COMUNICAZIONE, DATA_ACQUISIZIONE_ANTIMAFIA, NUMERO_PROTOCOLLO_ACQUISIZIONE_ANTIMAFIA FROM IMPRESA_CERTIFICAZIONE_ANTIMAFIA WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@EsenzioneCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESENZIONE_CERTIFICAZIONE = @EsenzioneCertificazioneequalthis)'; set @lensql=@lensql+len(@EsenzioneCertificazioneequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)'; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@NumeroProtocolloRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_PROTOCOLLO_RICHIESTA = @NumeroProtocolloRichiestaequalthis)'; set @lensql=@lensql+len(@NumeroProtocolloRichiestaequalthis);end;
	IF (@DataProtocolloRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PROTOCOLLO_RICHIESTA = @DataProtocolloRichiestaequalthis)'; set @lensql=@lensql+len(@DataProtocolloRichiestaequalthis);end;
	IF (@NumeroProtocolloCameraleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_PROTOCOLLO_CAMERALE = @NumeroProtocolloCameraleequalthis)'; set @lensql=@lensql+len(@NumeroProtocolloCameraleequalthis);end;
	IF (@DataCertificatoCameraleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CERTIFICATO_CAMERALE = @DataCertificatoCameraleequalthis)'; set @lensql=@lensql+len(@DataCertificatoCameraleequalthis);end;
	IF (@EsitoCertificatoCameraleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESITO_CERTIFICATO_CAMERALE = @EsitoCertificatoCameraleequalthis)'; set @lensql=@lensql+len(@EsitoCertificatoCameraleequalthis);end;
	IF (@NumeroProtocolloPrefettizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_PROTOCOLLO_PREFETTIZIO = @NumeroProtocolloPrefettizioequalthis)'; set @lensql=@lensql+len(@NumeroProtocolloPrefettizioequalthis);end;
	IF (@DataCertificatoPrefettizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CERTIFICATO_PREFETTIZIO = @DataCertificatoPrefettizioequalthis)'; set @lensql=@lensql+len(@DataCertificatoPrefettizioequalthis);end;
	IF (@EsitoCertificatoPrefettizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESITO_CERTIFICATO_PREFETTIZIO = @EsitoCertificatoPrefettizioequalthis)'; set @lensql=@lensql+len(@EsitoCertificatoPrefettizioequalthis);end;
	IF (@NumeroProtocolloComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_PROTOCOLLO_COMUNICAZIONE = @NumeroProtocolloComunicazioneequalthis)'; set @lensql=@lensql+len(@NumeroProtocolloComunicazioneequalthis);end;
	IF (@DataProtocolloComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PROTOCOLLO_COMUNICAZIONE = @DataProtocolloComunicazioneequalthis)'; set @lensql=@lensql+len(@DataProtocolloComunicazioneequalthis);end;
	IF (@DataAcquisizioneAntimafiaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ACQUISIZIONE_ANTIMAFIA = @DataAcquisizioneAntimafiaequalthis)'; set @lensql=@lensql+len(@DataAcquisizioneAntimafiaequalthis);end;
	IF (@NumeroProtocolloAcquisizioneAntimafiaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_PROTOCOLLO_ACQUISIZIONE_ANTIMAFIA = @NumeroProtocolloAcquisizioneAntimafiaequalthis)'; set @lensql=@lensql+len(@NumeroProtocolloAcquisizioneAntimafiaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdImpresaequalthis INT, @EsenzioneCertificazioneequalthis BIT, @DataInizioValiditaequalthis DATETIME, @DataFineValiditaequalthis DATETIME, @NumeroProtocolloRichiestaequalthis VARCHAR(30), @DataProtocolloRichiestaequalthis DATETIME, @NumeroProtocolloCameraleequalthis VARCHAR(30), @DataCertificatoCameraleequalthis DATETIME, @EsitoCertificatoCameraleequalthis BIT, @NumeroProtocolloPrefettizioequalthis VARCHAR(30), @DataCertificatoPrefettizioequalthis DATETIME, @EsitoCertificatoPrefettizioequalthis BIT, @NumeroProtocolloComunicazioneequalthis VARCHAR(30), @DataProtocolloComunicazioneequalthis DATETIME, @DataAcquisizioneAntimafiaequalthis DATETIME, @NumeroProtocolloAcquisizioneAntimafiaequalthis VARCHAR(30)',@Idequalthis , @IdImpresaequalthis , @EsenzioneCertificazioneequalthis , @DataInizioValiditaequalthis , @DataFineValiditaequalthis , @NumeroProtocolloRichiestaequalthis , @DataProtocolloRichiestaequalthis , @NumeroProtocolloCameraleequalthis , @DataCertificatoCameraleequalthis , @EsitoCertificatoCameraleequalthis , @NumeroProtocolloPrefettizioequalthis , @DataCertificatoPrefettizioequalthis , @EsitoCertificatoPrefettizioequalthis , @NumeroProtocolloComunicazioneequalthis , @DataProtocolloComunicazioneequalthis , @DataAcquisizioneAntimafiaequalthis , @NumeroProtocolloAcquisizioneAntimafiaequalthis ;
	else
		SELECT ID, ID_IMPRESA, ESENZIONE_CERTIFICAZIONE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, NUMERO_PROTOCOLLO_RICHIESTA, DATA_PROTOCOLLO_RICHIESTA, NUMERO_PROTOCOLLO_CAMERALE, DATA_CERTIFICATO_CAMERALE, ESITO_CERTIFICATO_CAMERALE, NUMERO_PROTOCOLLO_PREFETTIZIO, DATA_CERTIFICATO_PREFETTIZIO, ESITO_CERTIFICATO_PREFETTIZIO, NUMERO_PROTOCOLLO_COMUNICAZIONE, DATA_PROTOCOLLO_COMUNICAZIONE, DATA_ACQUISIZIONE_ANTIMAFIA, NUMERO_PROTOCOLLO_ACQUISIZIONE_ANTIMAFIA
		FROM IMPRESA_CERTIFICAZIONE_ANTIMAFIA
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@EsenzioneCertificazioneequalthis IS NULL) OR ESENZIONE_CERTIFICAZIONE = @EsenzioneCertificazioneequalthis) AND 
			((@DataInizioValiditaequalthis IS NULL) OR DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@NumeroProtocolloRichiestaequalthis IS NULL) OR NUMERO_PROTOCOLLO_RICHIESTA = @NumeroProtocolloRichiestaequalthis) AND 
			((@DataProtocolloRichiestaequalthis IS NULL) OR DATA_PROTOCOLLO_RICHIESTA = @DataProtocolloRichiestaequalthis) AND 
			((@NumeroProtocolloCameraleequalthis IS NULL) OR NUMERO_PROTOCOLLO_CAMERALE = @NumeroProtocolloCameraleequalthis) AND 
			((@DataCertificatoCameraleequalthis IS NULL) OR DATA_CERTIFICATO_CAMERALE = @DataCertificatoCameraleequalthis) AND 
			((@EsitoCertificatoCameraleequalthis IS NULL) OR ESITO_CERTIFICATO_CAMERALE = @EsitoCertificatoCameraleequalthis) AND 
			((@NumeroProtocolloPrefettizioequalthis IS NULL) OR NUMERO_PROTOCOLLO_PREFETTIZIO = @NumeroProtocolloPrefettizioequalthis) AND 
			((@DataCertificatoPrefettizioequalthis IS NULL) OR DATA_CERTIFICATO_PREFETTIZIO = @DataCertificatoPrefettizioequalthis) AND 
			((@EsitoCertificatoPrefettizioequalthis IS NULL) OR ESITO_CERTIFICATO_PREFETTIZIO = @EsitoCertificatoPrefettizioequalthis) AND 
			((@NumeroProtocolloComunicazioneequalthis IS NULL) OR NUMERO_PROTOCOLLO_COMUNICAZIONE = @NumeroProtocolloComunicazioneequalthis) AND 
			((@DataProtocolloComunicazioneequalthis IS NULL) OR DATA_PROTOCOLLO_COMUNICAZIONE = @DataProtocolloComunicazioneequalthis) AND 
			((@DataAcquisizioneAntimafiaequalthis IS NULL) OR DATA_ACQUISIZIONE_ANTIMAFIA = @DataAcquisizioneAntimafiaequalthis) AND 
			((@NumeroProtocolloAcquisizioneAntimafiaequalthis IS NULL) OR NUMERO_PROTOCOLLO_ACQUISIZIONE_ANTIMAFIA = @NumeroProtocolloAcquisizioneAntimafiaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaCertificazioneAntimafiaFindSelect';

