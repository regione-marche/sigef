CREATE PROCEDURE [dbo].[ZContrattiFemPagamentiFindSelect]
(
	@IdContrattoFemPagamentiequalthis INT, 
	@IdContrattoFemequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Estremiequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Importoequalthis DECIMAL(18,2), 
	@IdFileequalthis INT, 
	@DataCreazioneequalthis DATETIME, 
	@OperatoreCreazioneequalthis INT, 
	@DataAggiornamentoequalthis DATETIME, 
	@OperatoreAggiornamentoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdDomandaPagamentoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_PROGETTO_CONTRATTO, DATA_STIPULA_CONTRATTO, SEGNATURA_CONTRATTO, IMPORTO_CONTRATTO, ID_IMPRESA_CONTRATTO, ID_CONTRATTO_FEM_PAGAMENTI, ID_CONTRATTO_FEM, ID_PROGETTO, COD_TIPO, ESTREMI, DATA, IMPORTO, ID_FILE, DATA_CREAZIONE, OPERATORE_CREAZIONE, DATA_AGGIORNAMENTO, OPERATORE_AGGIORNAMENTO, ID_IMPRESA, ID_DOMANDA_PAGAMENTO, IMPRESA_PAGAMENTO, CODICE_FISCALE_IMPRESA_PAGAMENTO, CUAA_IMPRESA_PAGAMENTO, TIPO_PAGAMENTO FROM VCONTRATTI_FEM_PAGAMENTI WHERE 1=1';
	IF (@IdContrattoFemPagamentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTRATTO_FEM_PAGAMENTI = @IdContrattoFemPagamentiequalthis)'; set @lensql=@lensql+len(@IdContrattoFemPagamentiequalthis);end;
	IF (@IdContrattoFemequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTRATTO_FEM = @IdContrattoFemequalthis)'; set @lensql=@lensql+len(@IdContrattoFemequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Estremiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESTREMI = @Estremiequalthis)'; set @lensql=@lensql+len(@Estremiequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO = @Importoequalthis)'; set @lensql=@lensql+len(@Importoequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@DataCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CREAZIONE = @DataCreazioneequalthis)'; set @lensql=@lensql+len(@DataCreazioneequalthis);end;
	IF (@OperatoreCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_CREAZIONE = @OperatoreCreazioneequalthis)'; set @lensql=@lensql+len(@OperatoreCreazioneequalthis);end;
	IF (@DataAggiornamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_AGGIORNAMENTO = @DataAggiornamentoequalthis)'; set @lensql=@lensql+len(@DataAggiornamentoequalthis);end;
	IF (@OperatoreAggiornamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_AGGIORNAMENTO = @OperatoreAggiornamentoequalthis)'; set @lensql=@lensql+len(@OperatoreAggiornamentoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdContrattoFemPagamentiequalthis INT, @IdContrattoFemequalthis INT, @IdProgettoequalthis INT, @CodTipoequalthis VARCHAR(255), @Estremiequalthis VARCHAR(255), @Dataequalthis DATETIME, @Importoequalthis DECIMAL(18,2), @IdFileequalthis INT, @DataCreazioneequalthis DATETIME, @OperatoreCreazioneequalthis INT, @DataAggiornamentoequalthis DATETIME, @OperatoreAggiornamentoequalthis INT, @IdImpresaequalthis INT, @IdDomandaPagamentoequalthis INT',@IdContrattoFemPagamentiequalthis , @IdContrattoFemequalthis , @IdProgettoequalthis , @CodTipoequalthis , @Estremiequalthis , @Dataequalthis , @Importoequalthis , @IdFileequalthis , @DataCreazioneequalthis , @OperatoreCreazioneequalthis , @DataAggiornamentoequalthis , @OperatoreAggiornamentoequalthis , @IdImpresaequalthis , @IdDomandaPagamentoequalthis ;
	else
		SELECT ID_BANDO, ID_PROGETTO_CONTRATTO, DATA_STIPULA_CONTRATTO, SEGNATURA_CONTRATTO, IMPORTO_CONTRATTO, ID_IMPRESA_CONTRATTO, ID_CONTRATTO_FEM_PAGAMENTI, ID_CONTRATTO_FEM, ID_PROGETTO, COD_TIPO, ESTREMI, DATA, IMPORTO, ID_FILE, DATA_CREAZIONE, OPERATORE_CREAZIONE, DATA_AGGIORNAMENTO, OPERATORE_AGGIORNAMENTO, ID_IMPRESA, ID_DOMANDA_PAGAMENTO, IMPRESA_PAGAMENTO, CODICE_FISCALE_IMPRESA_PAGAMENTO, CUAA_IMPRESA_PAGAMENTO, TIPO_PAGAMENTO
		FROM VCONTRATTI_FEM_PAGAMENTI
		WHERE 
			((@IdContrattoFemPagamentiequalthis IS NULL) OR ID_CONTRATTO_FEM_PAGAMENTI = @IdContrattoFemPagamentiequalthis) AND 
			((@IdContrattoFemequalthis IS NULL) OR ID_CONTRATTO_FEM = @IdContrattoFemequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Estremiequalthis IS NULL) OR ESTREMI = @Estremiequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@DataCreazioneequalthis IS NULL) OR DATA_CREAZIONE = @DataCreazioneequalthis) AND 
			((@OperatoreCreazioneequalthis IS NULL) OR OPERATORE_CREAZIONE = @OperatoreCreazioneequalthis) AND 
			((@DataAggiornamentoequalthis IS NULL) OR DATA_AGGIORNAMENTO = @DataAggiornamentoequalthis) AND 
			((@OperatoreAggiornamentoequalthis IS NULL) OR OPERATORE_AGGIORNAMENTO = @OperatoreAggiornamentoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)
		

GO