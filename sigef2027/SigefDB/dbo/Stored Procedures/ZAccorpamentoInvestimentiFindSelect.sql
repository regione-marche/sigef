CREATE PROCEDURE [dbo].[ZAccorpamentoInvestimentiFindSelect]
(
	@IdAccorpamentoInvestimentiequalthis INT, 
	@DataCreazioneequalthis DATETIME, 
	@CfCreazioneequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@IdDomandaPagamentoequalthis INT, 
	@IdInvestimentoXequalthis INT, 
	@IdInvestimentoYequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ACCORPAMENTO_INVESTIMENTI, CF_CREAZIONE, DATA_MODIFICA, CF_MODIFICA, ID_DOMANDA_PAGAMENTO, ID_INVESTIMENTO_X, ID_INVESTIMENTO_Y, ISTANZA_PIANO_INVESTIMENTI, ID_PROGETTO, DATA_CREAZIONE FROM VACCORPAMENTO_INVESTIMENTI WHERE 1=1';
	IF (@IdAccorpamentoInvestimentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ACCORPAMENTO_INVESTIMENTI = @IdAccorpamentoInvestimentiequalthis)'; set @lensql=@lensql+len(@IdAccorpamentoInvestimentiequalthis);end;
	IF (@DataCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CREAZIONE = @DataCreazioneequalthis)'; set @lensql=@lensql+len(@DataCreazioneequalthis);end;
	IF (@CfCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_CREAZIONE = @CfCreazioneequalthis)'; set @lensql=@lensql+len(@CfCreazioneequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdInvestimentoXequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO_X = @IdInvestimentoXequalthis)'; set @lensql=@lensql+len(@IdInvestimentoXequalthis);end;
	IF (@IdInvestimentoYequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO_Y = @IdInvestimentoYequalthis)'; set @lensql=@lensql+len(@IdInvestimentoYequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAccorpamentoInvestimentiequalthis INT, @DataCreazioneequalthis DATETIME, @CfCreazioneequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @IdDomandaPagamentoequalthis INT, @IdInvestimentoXequalthis INT, @IdInvestimentoYequalthis INT',@IdAccorpamentoInvestimentiequalthis , @DataCreazioneequalthis , @CfCreazioneequalthis , @DataModificaequalthis , @CfModificaequalthis , @IdDomandaPagamentoequalthis , @IdInvestimentoXequalthis , @IdInvestimentoYequalthis ;
	else
		SELECT ID_ACCORPAMENTO_INVESTIMENTI, CF_CREAZIONE, DATA_MODIFICA, CF_MODIFICA, ID_DOMANDA_PAGAMENTO, ID_INVESTIMENTO_X, ID_INVESTIMENTO_Y, ISTANZA_PIANO_INVESTIMENTI, ID_PROGETTO, DATA_CREAZIONE
		FROM VACCORPAMENTO_INVESTIMENTI
		WHERE 
			((@IdAccorpamentoInvestimentiequalthis IS NULL) OR ID_ACCORPAMENTO_INVESTIMENTI = @IdAccorpamentoInvestimentiequalthis) AND 
			((@DataCreazioneequalthis IS NULL) OR DATA_CREAZIONE = @DataCreazioneequalthis) AND 
			((@CfCreazioneequalthis IS NULL) OR CF_CREAZIONE = @CfCreazioneequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdInvestimentoXequalthis IS NULL) OR ID_INVESTIMENTO_X = @IdInvestimentoXequalthis) AND 
			((@IdInvestimentoYequalthis IS NULL) OR ID_INVESTIMENTO_Y = @IdInvestimentoYequalthis)
					

GO