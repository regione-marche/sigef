CREATE PROCEDURE [dbo].[ZContrattiFemFindSelect]
(
	@IdContrattoFemequalthis INT, 
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@DataStipulaContrattoequalthis DATETIME, 
	@Segnaturaequalthis VARCHAR(255), 
	@DataSegnaturaequalthis DATETIME, 
	@Importoequalthis DECIMAL(15,2), 
	@DataCreazioneequalthis DATETIME, 
	@DataAggiornamentoequalthis DATETIME, 
	@OperatoreCreazioneequalthis INT, 
	@OperatoreAggiornamentoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@Numeroequalthis VARCHAR(max), 
	@IdFileequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@IdProgettoRifequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_CONTRATTO_FEM, ID_BANDO, ID_PROGETTO, DATA_STIPULA_CONTRATTO, SEGNATURA, DATA_SEGNATURA, IMPORTO, DATA_CREAZIONE, DATA_AGGIORNAMENTO, OPERATORE_CREAZIONE, OPERATORE_AGGIORNAMENTO, ID_IMPRESA, ID_DOMANDA_PAGAMENTO, NUMERO, ID_FILE, DESCRIZIONE, ID_PROGETTO_RIF, IMPRESA, CODICE_FISCALE_IMPRESA, CUAA_IMPRESA FROM VCONTRATTI_FEM WHERE 1=1';
	IF (@IdContrattoFemequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTRATTO_FEM = @IdContrattoFemequalthis)'; set @lensql=@lensql+len(@IdContrattoFemequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@DataStipulaContrattoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_STIPULA_CONTRATTO = @DataStipulaContrattoequalthis)'; set @lensql=@lensql+len(@DataStipulaContrattoequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@DataSegnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SEGNATURA = @DataSegnaturaequalthis)'; set @lensql=@lensql+len(@DataSegnaturaequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO = @Importoequalthis)'; set @lensql=@lensql+len(@Importoequalthis);end;
	IF (@DataCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CREAZIONE = @DataCreazioneequalthis)'; set @lensql=@lensql+len(@DataCreazioneequalthis);end;
	IF (@DataAggiornamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_AGGIORNAMENTO = @DataAggiornamentoequalthis)'; set @lensql=@lensql+len(@DataAggiornamentoequalthis);end;
	IF (@OperatoreCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_CREAZIONE = @OperatoreCreazioneequalthis)'; set @lensql=@lensql+len(@OperatoreCreazioneequalthis);end;
	IF (@OperatoreAggiornamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_AGGIORNAMENTO = @OperatoreAggiornamentoequalthis)'; set @lensql=@lensql+len(@OperatoreAggiornamentoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@IdProgettoRifequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_RIF = @IdProgettoRifequalthis)'; set @lensql=@lensql+len(@IdProgettoRifequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdContrattoFemequalthis INT, @IdBandoequalthis INT, @IdProgettoequalthis INT, @DataStipulaContrattoequalthis DATETIME, @Segnaturaequalthis VARCHAR(255), @DataSegnaturaequalthis DATETIME, @Importoequalthis DECIMAL(15,2), @DataCreazioneequalthis DATETIME, @DataAggiornamentoequalthis DATETIME, @OperatoreCreazioneequalthis INT, @OperatoreAggiornamentoequalthis INT, @IdImpresaequalthis INT, @IdDomandaPagamentoequalthis INT, @Numeroequalthis VARCHAR(max), @IdFileequalthis INT, @Descrizioneequalthis VARCHAR(255), @IdProgettoRifequalthis INT',@IdContrattoFemequalthis , @IdBandoequalthis , @IdProgettoequalthis , @DataStipulaContrattoequalthis , @Segnaturaequalthis , @DataSegnaturaequalthis , @Importoequalthis , @DataCreazioneequalthis , @DataAggiornamentoequalthis , @OperatoreCreazioneequalthis , @OperatoreAggiornamentoequalthis , @IdImpresaequalthis , @IdDomandaPagamentoequalthis , @Numeroequalthis , @IdFileequalthis , @Descrizioneequalthis , @IdProgettoRifequalthis ;
	else
		SELECT ID_CONTRATTO_FEM, ID_BANDO, ID_PROGETTO, DATA_STIPULA_CONTRATTO, SEGNATURA, DATA_SEGNATURA, IMPORTO, DATA_CREAZIONE, DATA_AGGIORNAMENTO, OPERATORE_CREAZIONE, OPERATORE_AGGIORNAMENTO, ID_IMPRESA, ID_DOMANDA_PAGAMENTO, NUMERO, ID_FILE, DESCRIZIONE, ID_PROGETTO_RIF, IMPRESA, CODICE_FISCALE_IMPRESA, CUAA_IMPRESA
		FROM VCONTRATTI_FEM
		WHERE 
			((@IdContrattoFemequalthis IS NULL) OR ID_CONTRATTO_FEM = @IdContrattoFemequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@DataStipulaContrattoequalthis IS NULL) OR DATA_STIPULA_CONTRATTO = @DataStipulaContrattoequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@DataSegnaturaequalthis IS NULL) OR DATA_SEGNATURA = @DataSegnaturaequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis) AND 
			((@DataCreazioneequalthis IS NULL) OR DATA_CREAZIONE = @DataCreazioneequalthis) AND 
			((@DataAggiornamentoequalthis IS NULL) OR DATA_AGGIORNAMENTO = @DataAggiornamentoequalthis) AND 
			((@OperatoreCreazioneequalthis IS NULL) OR OPERATORE_CREAZIONE = @OperatoreCreazioneequalthis) AND 
			((@OperatoreAggiornamentoequalthis IS NULL) OR OPERATORE_AGGIORNAMENTO = @OperatoreAggiornamentoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@IdProgettoRifequalthis IS NULL) OR ID_PROGETTO_RIF = @IdProgettoRifequalthis)
		

GO