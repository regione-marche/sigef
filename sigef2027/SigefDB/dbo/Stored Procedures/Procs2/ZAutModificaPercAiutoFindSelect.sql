CREATE PROCEDURE [dbo].[ZAutModificaPercAiutoFindSelect]
(
	@IdAutorizzazioneequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@IdInvestimentoequalthis INT, 
	@CostoInvestimentoPrecedenteequalthis DECIMAL(18,2), 
	@CostoInvestimentoAutorizzatoequalthis DECIMAL(18,2), 
	@QuantitaPrecedenteequalthis DECIMAL(10,2), 
	@QuantitaAutorizzataequalthis DECIMAL(10,2), 
	@PercPrecedenteequalthis DECIMAL(15,12), 
	@PercAutorizzataequalthis DECIMAL(15,12)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_AUTORIZZAZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_INVESTIMENTO, COSTO_INVESTIMENTO_PRECEDENTE, COSTO_INVESTIMENTO_AUTORIZZATO, QUANTITA_PRECEDENTE, QUANTITA_AUTORIZZATA, PERC_PRECEDENTE, PERC_AUTORIZZATA FROM VAUT_MODIFICA_PERC_AUTO WHERE 1=1';
	IF (@IdAutorizzazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_AUTORIZZAZIONE = @IdAutorizzazioneequalthis)'; set @lensql=@lensql+len(@IdAutorizzazioneequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@CostoInvestimentoPrecedenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COSTO_INVESTIMENTO_PRECEDENTE = @CostoInvestimentoPrecedenteequalthis)'; set @lensql=@lensql+len(@CostoInvestimentoPrecedenteequalthis);end;
	IF (@CostoInvestimentoAutorizzatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COSTO_INVESTIMENTO_AUTORIZZATO = @CostoInvestimentoAutorizzatoequalthis)'; set @lensql=@lensql+len(@CostoInvestimentoAutorizzatoequalthis);end;
	IF (@QuantitaPrecedenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUANTITA_PRECEDENTE = @QuantitaPrecedenteequalthis)'; set @lensql=@lensql+len(@QuantitaPrecedenteequalthis);end;
	IF (@QuantitaAutorizzataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUANTITA_AUTORIZZATA = @QuantitaAutorizzataequalthis)'; set @lensql=@lensql+len(@QuantitaAutorizzataequalthis);end;
	IF (@PercPrecedenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PERC_PRECEDENTE = @PercPrecedenteequalthis)'; set @lensql=@lensql+len(@PercPrecedenteequalthis);end;
	IF (@PercAutorizzataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PERC_AUTORIZZATA = @PercAutorizzataequalthis)'; set @lensql=@lensql+len(@PercAutorizzataequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAutorizzazioneequalthis INT, @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @IdInvestimentoequalthis INT, @CostoInvestimentoPrecedenteequalthis DECIMAL(18,2), @CostoInvestimentoAutorizzatoequalthis DECIMAL(18,2), @QuantitaPrecedenteequalthis DECIMAL(10,2), @QuantitaAutorizzataequalthis DECIMAL(10,2), @PercPrecedenteequalthis DECIMAL(15,12), @PercAutorizzataequalthis DECIMAL(15,12)',@IdAutorizzazioneequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis , @IdInvestimentoequalthis , @CostoInvestimentoPrecedenteequalthis , @CostoInvestimentoAutorizzatoequalthis , @QuantitaPrecedenteequalthis , @QuantitaAutorizzataequalthis , @PercPrecedenteequalthis , @PercAutorizzataequalthis ;
	else
		SELECT ID_AUTORIZZAZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_INVESTIMENTO, COSTO_INVESTIMENTO_PRECEDENTE, COSTO_INVESTIMENTO_AUTORIZZATO, QUANTITA_PRECEDENTE, QUANTITA_AUTORIZZATA, PERC_PRECEDENTE, PERC_AUTORIZZATA
		FROM VAUT_MODIFICA_PERC_AUTO
		WHERE 
			((@IdAutorizzazioneequalthis IS NULL) OR ID_AUTORIZZAZIONE = @IdAutorizzazioneequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@CostoInvestimentoPrecedenteequalthis IS NULL) OR COSTO_INVESTIMENTO_PRECEDENTE = @CostoInvestimentoPrecedenteequalthis) AND 
			((@CostoInvestimentoAutorizzatoequalthis IS NULL) OR COSTO_INVESTIMENTO_AUTORIZZATO = @CostoInvestimentoAutorizzatoequalthis) AND 
			((@QuantitaPrecedenteequalthis IS NULL) OR QUANTITA_PRECEDENTE = @QuantitaPrecedenteequalthis) AND 
			((@QuantitaAutorizzataequalthis IS NULL) OR QUANTITA_AUTORIZZATA = @QuantitaAutorizzataequalthis) AND 
			((@PercPrecedenteequalthis IS NULL) OR PERC_PRECEDENTE = @PercPrecedenteequalthis) AND 
			((@PercAutorizzataequalthis IS NULL) OR PERC_AUTORIZZATA = @PercAutorizzataequalthis)
		

GO