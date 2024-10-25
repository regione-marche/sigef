CREATE PROCEDURE [dbo].[ZRevocaFindSelect]
(
	@IdRevocaequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT, 
	@Origineequalthis VARCHAR(255), 
	@Noteequalthis VARCHAR(max), 
	@ImportoRevocaequalthis DECIMAL(15,2), 
	@NumeroAttoequalthis VARCHAR(255), 
	@DataAttoequalthis DATETIME, 
	@RecuperoBeneficiarioequalthis BIT, 
	@RevocaContributoequalthis BIT, 
	@ImportoDaRecuperareequalthis DECIMAL(15,2), 
	@InteressiLegaliequalthis DECIMAL(15,2), 
	@SpeseNotificaequalthis DECIMAL(15,2), 
	@Sanzioniequalthis DECIMAL(15,2), 
	@Totaleequalthis DECIMAL(15,2), 
	@ImportoRecuperatoequalthis DECIMAL(15,2), 
	@Irrecuperabileequalthis BIT, 
	@DataIrrecuperabileequalthis DATETIME, 
	@ImportoIrrecuperabileequalthis DECIMAL(15,2), 
	@DataModificaequalthis DATETIME, 
	@Recuperatoequalthis BIT, 
	@Stabilitaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_REVOCA, ID_PROGETTO, ID_IMPRESA, ORIGINE, NOTE, IMPORTO_REVOCA, NUMERO_ATTO, DATA_ATTO, RECUPERO_BENEFICIARIO, REVOCA_CONTRIBUTO, IMPORTO_DA_RECUPERARE, INTERESSI_LEGALI, SPESE_NOTIFICA, SANZIONI, TOTALE, IMPORTO_RECUPERATO, IRRECUPERABILE, DATA_IRRECUPERABILE, IMPORTO_IRRECUPERABILE, DATA_MODIFICA, RECUPERATO, STABILITA FROM REVOCA WHERE 1=1';
	IF (@IdRevocaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REVOCA = @IdRevocaequalthis)'; set @lensql=@lensql+len(@IdRevocaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Origineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORIGINE = @Origineequalthis)'; set @lensql=@lensql+len(@Origineequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@ImportoRevocaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_REVOCA = @ImportoRevocaequalthis)'; set @lensql=@lensql+len(@ImportoRevocaequalthis);end;
	IF (@NumeroAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_ATTO = @NumeroAttoequalthis)'; set @lensql=@lensql+len(@NumeroAttoequalthis);end;
	IF (@DataAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ATTO = @DataAttoequalthis)'; set @lensql=@lensql+len(@DataAttoequalthis);end;
	IF (@RecuperoBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RECUPERO_BENEFICIARIO = @RecuperoBeneficiarioequalthis)'; set @lensql=@lensql+len(@RecuperoBeneficiarioequalthis);end;
	IF (@RevocaContributoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REVOCA_CONTRIBUTO = @RevocaContributoequalthis)'; set @lensql=@lensql+len(@RevocaContributoequalthis);end;
	IF (@ImportoDaRecuperareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_DA_RECUPERARE = @ImportoDaRecuperareequalthis)'; set @lensql=@lensql+len(@ImportoDaRecuperareequalthis);end;
	IF (@InteressiLegaliequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTERESSI_LEGALI = @InteressiLegaliequalthis)'; set @lensql=@lensql+len(@InteressiLegaliequalthis);end;
	IF (@SpeseNotificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESE_NOTIFICA = @SpeseNotificaequalthis)'; set @lensql=@lensql+len(@SpeseNotificaequalthis);end;
	IF (@Sanzioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SANZIONI = @Sanzioniequalthis)'; set @lensql=@lensql+len(@Sanzioniequalthis);end;
	IF (@Totaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOTALE = @Totaleequalthis)'; set @lensql=@lensql+len(@Totaleequalthis);end;
	IF (@ImportoRecuperatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RECUPERATO = @ImportoRecuperatoequalthis)'; set @lensql=@lensql+len(@ImportoRecuperatoequalthis);end;
	IF (@Irrecuperabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IRRECUPERABILE = @Irrecuperabileequalthis)'; set @lensql=@lensql+len(@Irrecuperabileequalthis);end;
	IF (@DataIrrecuperabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_IRRECUPERABILE = @DataIrrecuperabileequalthis)'; set @lensql=@lensql+len(@DataIrrecuperabileequalthis);end;
	IF (@ImportoIrrecuperabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRRECUPERABILE = @ImportoIrrecuperabileequalthis)'; set @lensql=@lensql+len(@ImportoIrrecuperabileequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Recuperatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RECUPERATO = @Recuperatoequalthis)'; set @lensql=@lensql+len(@Recuperatoequalthis);end;
	IF (@Stabilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STABILITA = @Stabilitaequalthis)'; set @lensql=@lensql+len(@Stabilitaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRevocaequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT, @Origineequalthis VARCHAR(255), @Noteequalthis VARCHAR(max), @ImportoRevocaequalthis DECIMAL(15,2), @NumeroAttoequalthis VARCHAR(255), @DataAttoequalthis DATETIME, @RecuperoBeneficiarioequalthis BIT, @RevocaContributoequalthis BIT, @ImportoDaRecuperareequalthis DECIMAL(15,2), @InteressiLegaliequalthis DECIMAL(15,2), @SpeseNotificaequalthis DECIMAL(15,2), @Sanzioniequalthis DECIMAL(15,2), @Totaleequalthis DECIMAL(15,2), @ImportoRecuperatoequalthis DECIMAL(15,2), @Irrecuperabileequalthis BIT, @DataIrrecuperabileequalthis DATETIME, @ImportoIrrecuperabileequalthis DECIMAL(15,2), @DataModificaequalthis DATETIME, @Recuperatoequalthis BIT, @Stabilitaequalthis BIT',@IdRevocaequalthis , @IdProgettoequalthis , @IdImpresaequalthis , @Origineequalthis , @Noteequalthis , @ImportoRevocaequalthis , @NumeroAttoequalthis , @DataAttoequalthis , @RecuperoBeneficiarioequalthis , @RevocaContributoequalthis , @ImportoDaRecuperareequalthis , @InteressiLegaliequalthis , @SpeseNotificaequalthis , @Sanzioniequalthis , @Totaleequalthis , @ImportoRecuperatoequalthis , @Irrecuperabileequalthis , @DataIrrecuperabileequalthis , @ImportoIrrecuperabileequalthis , @DataModificaequalthis , @Recuperatoequalthis , @Stabilitaequalthis ;
	else
		SELECT ID_REVOCA, ID_PROGETTO, ID_IMPRESA, ORIGINE, NOTE, IMPORTO_REVOCA, NUMERO_ATTO, DATA_ATTO, RECUPERO_BENEFICIARIO, REVOCA_CONTRIBUTO, IMPORTO_DA_RECUPERARE, INTERESSI_LEGALI, SPESE_NOTIFICA, SANZIONI, TOTALE, IMPORTO_RECUPERATO, IRRECUPERABILE, DATA_IRRECUPERABILE, IMPORTO_IRRECUPERABILE, DATA_MODIFICA, RECUPERATO, STABILITA
		FROM REVOCA
		WHERE 
			((@IdRevocaequalthis IS NULL) OR ID_REVOCA = @IdRevocaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Origineequalthis IS NULL) OR ORIGINE = @Origineequalthis) AND 
			((@Noteequalthis IS NULL) OR NOTE = @Noteequalthis) AND 
			((@ImportoRevocaequalthis IS NULL) OR IMPORTO_REVOCA = @ImportoRevocaequalthis) AND 
			((@NumeroAttoequalthis IS NULL) OR NUMERO_ATTO = @NumeroAttoequalthis) AND 
			((@DataAttoequalthis IS NULL) OR DATA_ATTO = @DataAttoequalthis) AND 
			((@RecuperoBeneficiarioequalthis IS NULL) OR RECUPERO_BENEFICIARIO = @RecuperoBeneficiarioequalthis) AND 
			((@RevocaContributoequalthis IS NULL) OR REVOCA_CONTRIBUTO = @RevocaContributoequalthis) AND 
			((@ImportoDaRecuperareequalthis IS NULL) OR IMPORTO_DA_RECUPERARE = @ImportoDaRecuperareequalthis) AND 
			((@InteressiLegaliequalthis IS NULL) OR INTERESSI_LEGALI = @InteressiLegaliequalthis) AND 
			((@SpeseNotificaequalthis IS NULL) OR SPESE_NOTIFICA = @SpeseNotificaequalthis) AND 
			((@Sanzioniequalthis IS NULL) OR SANZIONI = @Sanzioniequalthis) AND 
			((@Totaleequalthis IS NULL) OR TOTALE = @Totaleequalthis) AND 
			((@ImportoRecuperatoequalthis IS NULL) OR IMPORTO_RECUPERATO = @ImportoRecuperatoequalthis) AND 
			((@Irrecuperabileequalthis IS NULL) OR IRRECUPERABILE = @Irrecuperabileequalthis) AND 
			((@DataIrrecuperabileequalthis IS NULL) OR DATA_IRRECUPERABILE = @DataIrrecuperabileequalthis) AND 
			((@ImportoIrrecuperabileequalthis IS NULL) OR IMPORTO_IRRECUPERABILE = @ImportoIrrecuperabileequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Recuperatoequalthis IS NULL) OR RECUPERATO = @Recuperatoequalthis) AND 
			((@Stabilitaequalthis IS NULL) OR STABILITA = @Stabilitaequalthis)