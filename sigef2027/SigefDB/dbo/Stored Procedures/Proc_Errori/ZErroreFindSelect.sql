CREATE PROCEDURE [dbo].[ZErroreFindSelect]
(
	@IdErroreequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@DataRilevazioneequalthis DATETIME, 
	@ImpreseBeneficiariequalthis VARCHAR(max), 
	@SoggettoRilevazioneequalthis VARCHAR(max), 
	@Certificatoequalthis BIT, 
	@IdLottoCertificazioneequalthis INT, 
	@DataInizioCertificazioneequalthis DATETIME, 
	@SpesaAmmessaErroreequalthis DECIMAL(18,2), 
	@ContributoPubblicoErroreequalthis DECIMAL(18,2), 
	@DaRecuperareequalthis BIT, 
	@Recuperatoequalthis BIT, 
	@AzioneCertificazioneequalthis VARCHAR(255), 
	@IdLottoImpattatoequalthis INT, 
	@Noteequalthis VARCHAR(max), 
	@DataFineCertificazioneequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ERRORE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, DATA_RILEVAZIONE, IMPRESE_BENEFICIARI, SOGGETTO_RILEVAZIONE, CERTIFICATO, ID_LOTTO_CERTIFICAZIONE, DATA_INIZIO_CERTIFICAZIONE, SPESA_AMMESSA_ERRORE, CONTRIBUTO_PUBBLICO_ERRORE, DA_RECUPERARE, RECUPERATO, AZIONE_CERTIFICAZIONE, ID_LOTTO_IMPATTATO, NOTE, DATA_FINE_CERTIFICAZIONE, ID_ASSE, ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_STATO_PROGETTO, STATO_PROGETTO FROM VERRORE WHERE 1=1';
	IF (@IdErroreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ERRORE = @IdErroreequalthis)'; set @lensql=@lensql+len(@IdErroreequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@DataRilevazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RILEVAZIONE = @DataRilevazioneequalthis)'; set @lensql=@lensql+len(@DataRilevazioneequalthis);end;
	IF (@ImpreseBeneficiariequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPRESE_BENEFICIARI = @ImpreseBeneficiariequalthis)'; set @lensql=@lensql+len(@ImpreseBeneficiariequalthis);end;
	IF (@SoggettoRilevazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SOGGETTO_RILEVAZIONE = @SoggettoRilevazioneequalthis)'; set @lensql=@lensql+len(@SoggettoRilevazioneequalthis);end;
	IF (@Certificatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CERTIFICATO = @Certificatoequalthis)'; set @lensql=@lensql+len(@Certificatoequalthis);end;
	IF (@IdLottoCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO_CERTIFICAZIONE = @IdLottoCertificazioneequalthis)'; set @lensql=@lensql+len(@IdLottoCertificazioneequalthis);end;
	IF (@DataInizioCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_CERTIFICAZIONE = @DataInizioCertificazioneequalthis)'; set @lensql=@lensql+len(@DataInizioCertificazioneequalthis);end;
	IF (@SpesaAmmessaErroreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESA_AMMESSA_ERRORE = @SpesaAmmessaErroreequalthis)'; set @lensql=@lensql+len(@SpesaAmmessaErroreequalthis);end;
	IF (@ContributoPubblicoErroreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_PUBBLICO_ERRORE = @ContributoPubblicoErroreequalthis)'; set @lensql=@lensql+len(@ContributoPubblicoErroreequalthis);end;
	IF (@DaRecuperareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DA_RECUPERARE = @DaRecuperareequalthis)'; set @lensql=@lensql+len(@DaRecuperareequalthis);end;
	IF (@Recuperatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RECUPERATO = @Recuperatoequalthis)'; set @lensql=@lensql+len(@Recuperatoequalthis);end;
	IF (@AzioneCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AZIONE_CERTIFICAZIONE = @AzioneCertificazioneequalthis)'; set @lensql=@lensql+len(@AzioneCertificazioneequalthis);end;
	IF (@IdLottoImpattatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO_IMPATTATO = @IdLottoImpattatoequalthis)'; set @lensql=@lensql+len(@IdLottoImpattatoequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@DataFineCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_CERTIFICAZIONE = @DataFineCertificazioneequalthis)'; set @lensql=@lensql+len(@DataFineCertificazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdErroreequalthis INT, @IdProgettoequalthis INT, @IdDomandaPagamentoequalthis INT, @CfInserimentoequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @DataRilevazioneequalthis DATETIME, @ImpreseBeneficiariequalthis VARCHAR(max), @SoggettoRilevazioneequalthis VARCHAR(max), @Certificatoequalthis BIT, @IdLottoCertificazioneequalthis INT, @DataInizioCertificazioneequalthis DATETIME, @SpesaAmmessaErroreequalthis DECIMAL(18,2), @ContributoPubblicoErroreequalthis DECIMAL(18,2), @DaRecuperareequalthis BIT, @Recuperatoequalthis BIT, @AzioneCertificazioneequalthis VARCHAR(255), @IdLottoImpattatoequalthis INT, @Noteequalthis VARCHAR(max), @DataFineCertificazioneequalthis DATETIME',@IdErroreequalthis , @IdProgettoequalthis , @IdDomandaPagamentoequalthis , @CfInserimentoequalthis , @DataInserimentoequalthis , @CfModificaequalthis , @DataModificaequalthis , @DataRilevazioneequalthis , @ImpreseBeneficiariequalthis , @SoggettoRilevazioneequalthis , @Certificatoequalthis , @IdLottoCertificazioneequalthis , @DataInizioCertificazioneequalthis , @SpesaAmmessaErroreequalthis , @ContributoPubblicoErroreequalthis , @DaRecuperareequalthis , @Recuperatoequalthis , @AzioneCertificazioneequalthis , @IdLottoImpattatoequalthis , @Noteequalthis , @DataFineCertificazioneequalthis ;
	else
		SELECT ID_ERRORE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, DATA_RILEVAZIONE, IMPRESE_BENEFICIARI, SOGGETTO_RILEVAZIONE, CERTIFICATO, ID_LOTTO_CERTIFICAZIONE, DATA_INIZIO_CERTIFICAZIONE, SPESA_AMMESSA_ERRORE, CONTRIBUTO_PUBBLICO_ERRORE, DA_RECUPERARE, RECUPERATO, AZIONE_CERTIFICAZIONE, ID_LOTTO_IMPATTATO, NOTE, DATA_FINE_CERTIFICAZIONE, ID_ASSE, ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_STATO_PROGETTO, STATO_PROGETTO
		FROM VERRORE
		WHERE 
			((@IdErroreequalthis IS NULL) OR ID_ERRORE = @IdErroreequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@DataRilevazioneequalthis IS NULL) OR DATA_RILEVAZIONE = @DataRilevazioneequalthis) AND 
			((@ImpreseBeneficiariequalthis IS NULL) OR IMPRESE_BENEFICIARI = @ImpreseBeneficiariequalthis) AND 
			((@SoggettoRilevazioneequalthis IS NULL) OR SOGGETTO_RILEVAZIONE = @SoggettoRilevazioneequalthis) AND 
			((@Certificatoequalthis IS NULL) OR CERTIFICATO = @Certificatoequalthis) AND 
			((@IdLottoCertificazioneequalthis IS NULL) OR ID_LOTTO_CERTIFICAZIONE = @IdLottoCertificazioneequalthis) AND 
			((@DataInizioCertificazioneequalthis IS NULL) OR DATA_INIZIO_CERTIFICAZIONE = @DataInizioCertificazioneequalthis) AND 
			((@SpesaAmmessaErroreequalthis IS NULL) OR SPESA_AMMESSA_ERRORE = @SpesaAmmessaErroreequalthis) AND 
			((@ContributoPubblicoErroreequalthis IS NULL) OR CONTRIBUTO_PUBBLICO_ERRORE = @ContributoPubblicoErroreequalthis) AND 
			((@DaRecuperareequalthis IS NULL) OR DA_RECUPERARE = @DaRecuperareequalthis) AND 
			((@Recuperatoequalthis IS NULL) OR RECUPERATO = @Recuperatoequalthis) AND 
			((@AzioneCertificazioneequalthis IS NULL) OR AZIONE_CERTIFICAZIONE = @AzioneCertificazioneequalthis) AND 
			((@IdLottoImpattatoequalthis IS NULL) OR ID_LOTTO_IMPATTATO = @IdLottoImpattatoequalthis) AND 
			((@Noteequalthis IS NULL) OR NOTE = @Noteequalthis) AND 
			((@DataFineCertificazioneequalthis IS NULL) OR DATA_FINE_CERTIFICAZIONE = @DataFineCertificazioneequalthis)
		

GO