CREATE PROCEDURE [dbo].[ZLottoDiRevisioneFindSelect]
(
	@IdLottoequalthis INT, 
	@IdBandoequalthis INT, 
	@Provinciaequalthis VARCHAR(255), 
	@DataCreazioneequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@NumeroEstrazioniequalthis INT, 
	@RevisioneConclusaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_LOTTO, ID_BANDO, PROVINCIA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, NUMERO_ESTRAZIONI, REVISIONE_CONCLUSA, NUMERO_DOMANDE_ASSEGNATE, NUMERO_DOMANDE_ESTRATTE, OPERATORE FROM vLOTTO_DI_REVISIONE WHERE 1=1';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@DataCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CREAZIONE = @DataCreazioneequalthis)'; set @lensql=@lensql+len(@DataCreazioneequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE = @CfOperatoreequalthis)'; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@NumeroEstrazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_ESTRAZIONI = @NumeroEstrazioniequalthis)'; set @lensql=@lensql+len(@NumeroEstrazioniequalthis);end;
	IF (@RevisioneConclusaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REVISIONE_CONCLUSA = @RevisioneConclusaequalthis)'; set @lensql=@lensql+len(@RevisioneConclusaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLottoequalthis INT, @IdBandoequalthis INT, @Provinciaequalthis VARCHAR(255), @DataCreazioneequalthis DATETIME, @CfOperatoreequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @NumeroEstrazioniequalthis INT, @RevisioneConclusaequalthis BIT',@IdLottoequalthis , @IdBandoequalthis , @Provinciaequalthis , @DataCreazioneequalthis , @CfOperatoreequalthis , @DataModificaequalthis , @NumeroEstrazioniequalthis , @RevisioneConclusaequalthis ;
	else
		SELECT ID_LOTTO, ID_BANDO, PROVINCIA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, NUMERO_ESTRAZIONI, REVISIONE_CONCLUSA, NUMERO_DOMANDE_ASSEGNATE, NUMERO_DOMANDE_ESTRATTE, OPERATORE
		FROM vLOTTO_DI_REVISIONE
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@DataCreazioneequalthis IS NULL) OR DATA_CREAZIONE = @DataCreazioneequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@NumeroEstrazioniequalthis IS NULL) OR NUMERO_ESTRAZIONI = @NumeroEstrazioniequalthis) AND 
			((@RevisioneConclusaequalthis IS NULL) OR REVISIONE_CONCLUSA = @RevisioneConclusaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZLottoDiRevisioneFindSelect]
(
	@IdLottoequalthis INT, 
	@IdBandoequalthis INT, 
	@Provinciaequalthis CHAR(2), 
	@DataCreazioneequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(16), 
	@DataModificaequalthis DATETIME, 
	@NumeroEstrazioniequalthis INT, 
	@RevisioneConclusaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_LOTTO, ID_BANDO, PROVINCIA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, NUMERO_ESTRAZIONI, REVISIONE_CONCLUSA, NUMERO_DOMANDE_ASSEGNATE, NUMERO_DOMANDE_ESTRATTE, OPERATORE FROM vLOTTO_DI_REVISIONE WHERE 1=1'';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_LOTTO = @IdLottoequalthis)''; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROVINCIA = @Provinciaequalthis)''; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@DataCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_CREAZIONE = @DataCreazioneequalthis)''; set @lensql=@lensql+len(@DataCreazioneequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_OPERATORE = @CfOperatoreequalthis)''; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_MODIFICA = @DataModificaequalthis)''; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@NumeroEstrazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO_ESTRAZIONI = @NumeroEstrazioniequalthis)''; set @lensql=@lensql+len(@NumeroEstrazioniequalthis);end;
	IF (@RevisioneConclusaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (REVISIONE_CONCLUSA = @RevisioneConclusaequalthis)''; set @lensql=@lensql+len(@RevisioneConclusaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdLottoequalthis INT, @IdBandoequalthis INT, @Provinciaequalthis CHAR(2), @DataCreazioneequalthis DATETIME, @CfOperatoreequalthis VARCHAR(16), @DataModificaequalthis DATETIME, @NumeroEstrazioniequalthis INT, @RevisioneConclusaequalthis BIT'',@IdLottoequalthis , @IdBandoequalthis , @Provinciaequalthis , @DataCreazioneequalthis , @CfOperatoreequalthis , @DataModificaequalthis , @NumeroEstrazioniequalthis , @RevisioneConclusaequalthis ;
	else
		SELECT ID_LOTTO, ID_BANDO, PROVINCIA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, NUMERO_ESTRAZIONI, REVISIONE_CONCLUSA, NUMERO_DOMANDE_ASSEGNATE, NUMERO_DOMANDE_ESTRATTE, OPERATORE
		FROM vLOTTO_DI_REVISIONE
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@DataCreazioneequalthis IS NULL) OR DATA_CREAZIONE = @DataCreazioneequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@NumeroEstrazioniequalthis IS NULL) OR NUMERO_ESTRAZIONI = @NumeroEstrazioniequalthis) AND 
			((@RevisioneConclusaequalthis IS NULL) OR REVISIONE_CONCLUSA = @RevisioneConclusaequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZLottoDiRevisioneFindSelect';

