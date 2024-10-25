CREATE PROCEDURE ZRnaLogConcessioniFindSelect
(
	@IdRnaLogConcessioneequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdProgettoRnaequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@IdFiscaleImpresaequalthis VARCHAR(255), 
	@IdRichiestaequalthis VARCHAR(255), 
	@DataRichiestaequalthis DATETIME, 
	@IdOperatoreRegAiutoequalthis INT, 
	@Corequalthis VARCHAR(255), 
	@CodiceEsitoequalthis INT, 
	@DescrizioneEsitoequalthis NVARCHAR(max), 
	@CodiceEsitoStatoRichiestaequalthis INT, 
	@DescrizioneEsitoStatoRichiestaequalthis NVARCHAR(max), 
	@IdOperatoreStatoRichiestaequalthis INT, 
	@DataStatoRichiestaequalthis DATETIME, 
	@Erroreequalthis NVARCHAR(max), 
	@DataInserimentoequalthis DATETIME, 
	@DataAggiornamentoequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_RNA_LOG_CONCESSIONE, ID_PROGETTO, ID_PROGETTO_RNA, ID_IMPRESA, ID_FISCALE_IMPRESA, ID_RICHIESTA, DATA_RICHIESTA, ID_OPERATORE_REG_AIUTO, ISTANZA_RICHIESTA, ISTANZA_RISPOSTA, COR, CODICE_ESITO, DESCRIZIONE_ESITO, CODICE_ESITO_STATO_RICHIESTA, DESCRIZIONE_ESITO_STATO_RICHIESTA, ID_OPERATORE_STATO_RICHIESTA, DATA_STATO_RICHIESTA, ERRORE, DATA_INSERIMENTO, DATA_AGGIORNAMENTO FROM RNA_LOG_CONCESSIONI WHERE 1=1';
	IF (@IdRnaLogConcessioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RNA_LOG_CONCESSIONE = @IdRnaLogConcessioneequalthis)'; set @lensql=@lensql+len(@IdRnaLogConcessioneequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdProgettoRnaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_RNA = @IdProgettoRnaequalthis)'; set @lensql=@lensql+len(@IdProgettoRnaequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdFiscaleImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FISCALE_IMPRESA = @IdFiscaleImpresaequalthis)'; set @lensql=@lensql+len(@IdFiscaleImpresaequalthis);end;
	IF (@IdRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RICHIESTA = @IdRichiestaequalthis)'; set @lensql=@lensql+len(@IdRichiestaequalthis);end;
	IF (@DataRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RICHIESTA = @DataRichiestaequalthis)'; set @lensql=@lensql+len(@DataRichiestaequalthis);end;
	IF (@IdOperatoreRegAiutoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_REG_AIUTO = @IdOperatoreRegAiutoequalthis)'; set @lensql=@lensql+len(@IdOperatoreRegAiutoequalthis);end;
	IF (@Corequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COR = @Corequalthis)'; set @lensql=@lensql+len(@Corequalthis);end;
	IF (@CodiceEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_ESITO = @CodiceEsitoequalthis)'; set @lensql=@lensql+len(@CodiceEsitoequalthis);end;
	IF (@DescrizioneEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis)'; set @lensql=@lensql+len(@DescrizioneEsitoequalthis);end;
	IF (@CodiceEsitoStatoRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_ESITO_STATO_RICHIESTA = @CodiceEsitoStatoRichiestaequalthis)'; set @lensql=@lensql+len(@CodiceEsitoStatoRichiestaequalthis);end;
	IF (@DescrizioneEsitoStatoRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_ESITO_STATO_RICHIESTA = @DescrizioneEsitoStatoRichiestaequalthis)'; set @lensql=@lensql+len(@DescrizioneEsitoStatoRichiestaequalthis);end;
	IF (@IdOperatoreStatoRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_STATO_RICHIESTA = @IdOperatoreStatoRichiestaequalthis)'; set @lensql=@lensql+len(@IdOperatoreStatoRichiestaequalthis);end;
	IF (@DataStatoRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_STATO_RICHIESTA = @DataStatoRichiestaequalthis)'; set @lensql=@lensql+len(@DataStatoRichiestaequalthis);end;
	IF (@Erroreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ERRORE = @Erroreequalthis)'; set @lensql=@lensql+len(@Erroreequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataAggiornamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_AGGIORNAMENTO = @DataAggiornamentoequalthis)'; set @lensql=@lensql+len(@DataAggiornamentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRnaLogConcessioneequalthis INT, @IdProgettoequalthis INT, @IdProgettoRnaequalthis VARCHAR(255), @IdImpresaequalthis INT, @IdFiscaleImpresaequalthis VARCHAR(255), @IdRichiestaequalthis VARCHAR(255), @DataRichiestaequalthis DATETIME, @IdOperatoreRegAiutoequalthis INT, @Corequalthis VARCHAR(255), @CodiceEsitoequalthis INT, @DescrizioneEsitoequalthis NVARCHAR(max), @CodiceEsitoStatoRichiestaequalthis INT, @DescrizioneEsitoStatoRichiestaequalthis NVARCHAR(max), @IdOperatoreStatoRichiestaequalthis INT, @DataStatoRichiestaequalthis DATETIME, @Erroreequalthis NVARCHAR(max), @DataInserimentoequalthis DATETIME, @DataAggiornamentoequalthis DATETIME',@IdRnaLogConcessioneequalthis , @IdProgettoequalthis , @IdProgettoRnaequalthis , @IdImpresaequalthis , @IdFiscaleImpresaequalthis , @IdRichiestaequalthis , @DataRichiestaequalthis , @IdOperatoreRegAiutoequalthis , @Corequalthis , @CodiceEsitoequalthis , @DescrizioneEsitoequalthis , @CodiceEsitoStatoRichiestaequalthis , @DescrizioneEsitoStatoRichiestaequalthis , @IdOperatoreStatoRichiestaequalthis , @DataStatoRichiestaequalthis , @Erroreequalthis , @DataInserimentoequalthis , @DataAggiornamentoequalthis ;
	else
		SELECT ID_RNA_LOG_CONCESSIONE, ID_PROGETTO, ID_PROGETTO_RNA, ID_IMPRESA, ID_FISCALE_IMPRESA, ID_RICHIESTA, DATA_RICHIESTA, ID_OPERATORE_REG_AIUTO, ISTANZA_RICHIESTA, ISTANZA_RISPOSTA, COR, CODICE_ESITO, DESCRIZIONE_ESITO, CODICE_ESITO_STATO_RICHIESTA, DESCRIZIONE_ESITO_STATO_RICHIESTA, ID_OPERATORE_STATO_RICHIESTA, DATA_STATO_RICHIESTA, ERRORE, DATA_INSERIMENTO, DATA_AGGIORNAMENTO
		FROM RNA_LOG_CONCESSIONI
		WHERE 
			((@IdRnaLogConcessioneequalthis IS NULL) OR ID_RNA_LOG_CONCESSIONE = @IdRnaLogConcessioneequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdProgettoRnaequalthis IS NULL) OR ID_PROGETTO_RNA = @IdProgettoRnaequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdFiscaleImpresaequalthis IS NULL) OR ID_FISCALE_IMPRESA = @IdFiscaleImpresaequalthis) AND 
			((@IdRichiestaequalthis IS NULL) OR ID_RICHIESTA = @IdRichiestaequalthis) AND 
			((@DataRichiestaequalthis IS NULL) OR DATA_RICHIESTA = @DataRichiestaequalthis) AND 
			((@IdOperatoreRegAiutoequalthis IS NULL) OR ID_OPERATORE_REG_AIUTO = @IdOperatoreRegAiutoequalthis) AND 
			((@Corequalthis IS NULL) OR COR = @Corequalthis) AND 
			((@CodiceEsitoequalthis IS NULL) OR CODICE_ESITO = @CodiceEsitoequalthis) AND 
			((@DescrizioneEsitoequalthis IS NULL) OR DESCRIZIONE_ESITO = @DescrizioneEsitoequalthis) AND 
			((@CodiceEsitoStatoRichiestaequalthis IS NULL) OR CODICE_ESITO_STATO_RICHIESTA = @CodiceEsitoStatoRichiestaequalthis) AND 
			((@DescrizioneEsitoStatoRichiestaequalthis IS NULL) OR DESCRIZIONE_ESITO_STATO_RICHIESTA = @DescrizioneEsitoStatoRichiestaequalthis) AND 
			((@IdOperatoreStatoRichiestaequalthis IS NULL) OR ID_OPERATORE_STATO_RICHIESTA = @IdOperatoreStatoRichiestaequalthis) AND 
			((@DataStatoRichiestaequalthis IS NULL) OR DATA_STATO_RICHIESTA = @DataStatoRichiestaequalthis) AND 
			((@Erroreequalthis IS NULL) OR ERRORE = @Erroreequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataAggiornamentoequalthis IS NULL) OR DATA_AGGIORNAMENTO = @DataAggiornamentoequalthis)
		

GO