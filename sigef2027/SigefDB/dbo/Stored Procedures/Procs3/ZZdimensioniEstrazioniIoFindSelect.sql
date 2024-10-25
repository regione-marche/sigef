CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoFindSelect]
(
	@IdEstrazioneIoequalthis INT, 
	@DataEstrazioneequalthis DATETIME, 
	@CodPsrequalthis VARCHAR(255), 
	@IdDimPrioritaequalthis INT, 
	@IdDimIndicatoreequalthis INT, 
	@ValoreRtotequalthis DECIMAL(18,2), 
	@ValorePfequalthis DECIMAL(18,2), 
	@DataPfequalthis DATETIME, 
	@ValoreFequalthis DECIMAL(18,2), 
	@DataFequalthis DATETIME, 
	@IdEstrazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_PSR, ID_DIM_PRIORITA, CodPriorita, DesPriorita, OrdPriorita, ID_DIM_INDICATORE, CodIndicatore, DesIndicatore, OrdIndicatore, VALORE_RTOT, VALORE_PF, DATA_PF, VALORE_F, DATA_F, ID_ESTRAZIONE, DATA_ESTRAZIONE, UM, ID_ESTRAZIONE_IO, BLOCCATO, ANNO FROM vzDIMENSIONI_ESTRAZIONI_IO WHERE 1=1';
	IF (@IdEstrazioneIoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ESTRAZIONE_IO = @IdEstrazioneIoequalthis)'; set @lensql=@lensql+len(@IdEstrazioneIoequalthis);end;
	IF (@DataEstrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ESTRAZIONE = @DataEstrazioneequalthis)'; set @lensql=@lensql+len(@DataEstrazioneequalthis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@IdDimPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DIM_PRIORITA = @IdDimPrioritaequalthis)'; set @lensql=@lensql+len(@IdDimPrioritaequalthis);end;
	IF (@IdDimIndicatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DIM_INDICATORE = @IdDimIndicatoreequalthis)'; set @lensql=@lensql+len(@IdDimIndicatoreequalthis);end;
	IF (@ValoreRtotequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_RTOT = @ValoreRtotequalthis)'; set @lensql=@lensql+len(@ValoreRtotequalthis);end;
	IF (@ValorePfequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_PF = @ValorePfequalthis)'; set @lensql=@lensql+len(@ValorePfequalthis);end;
	IF (@DataPfequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PF = @DataPfequalthis)'; set @lensql=@lensql+len(@DataPfequalthis);end;
	IF (@ValoreFequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE_F = @ValoreFequalthis)'; set @lensql=@lensql+len(@ValoreFequalthis);end;
	IF (@DataFequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_F = @DataFequalthis)'; set @lensql=@lensql+len(@DataFequalthis);end;
	IF (@IdEstrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ESTRAZIONE = @IdEstrazioneequalthis)'; set @lensql=@lensql+len(@IdEstrazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdEstrazioneIoequalthis INT, @DataEstrazioneequalthis DATETIME, @CodPsrequalthis VARCHAR(255), @IdDimPrioritaequalthis INT, @IdDimIndicatoreequalthis INT, @ValoreRtotequalthis DECIMAL(18,2), @ValorePfequalthis DECIMAL(18,2), @DataPfequalthis DATETIME, @ValoreFequalthis DECIMAL(18,2), @DataFequalthis DATETIME, @IdEstrazioneequalthis INT',@IdEstrazioneIoequalthis , @DataEstrazioneequalthis , @CodPsrequalthis , @IdDimPrioritaequalthis , @IdDimIndicatoreequalthis , @ValoreRtotequalthis , @ValorePfequalthis , @DataPfequalthis , @ValoreFequalthis , @DataFequalthis , @IdEstrazioneequalthis ;
	else
		SELECT COD_PSR, ID_DIM_PRIORITA, CodPriorita, DesPriorita, OrdPriorita, ID_DIM_INDICATORE, CodIndicatore, DesIndicatore, OrdIndicatore, VALORE_RTOT, VALORE_PF, DATA_PF, VALORE_F, DATA_F, ID_ESTRAZIONE, DATA_ESTRAZIONE, UM, ID_ESTRAZIONE_IO, BLOCCATO, ANNO
		FROM vzDIMENSIONI_ESTRAZIONI_IO
		WHERE 
			((@IdEstrazioneIoequalthis IS NULL) OR ID_ESTRAZIONE_IO = @IdEstrazioneIoequalthis) AND 
			((@DataEstrazioneequalthis IS NULL) OR DATA_ESTRAZIONE = @DataEstrazioneequalthis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@IdDimPrioritaequalthis IS NULL) OR ID_DIM_PRIORITA = @IdDimPrioritaequalthis) AND 
			((@IdDimIndicatoreequalthis IS NULL) OR ID_DIM_INDICATORE = @IdDimIndicatoreequalthis) AND 
			((@ValoreRtotequalthis IS NULL) OR VALORE_RTOT = @ValoreRtotequalthis) AND 
			((@ValorePfequalthis IS NULL) OR VALORE_PF = @ValorePfequalthis) AND 
			((@DataPfequalthis IS NULL) OR DATA_PF = @DataPfequalthis) AND 
			((@ValoreFequalthis IS NULL) OR VALORE_F = @ValoreFequalthis) AND 
			((@DataFequalthis IS NULL) OR DATA_F = @DataFequalthis) AND 
			((@IdEstrazioneequalthis IS NULL) OR ID_ESTRAZIONE = @IdEstrazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoFindSelect]
(
	@IdEstrazioneequalthis INT, 
	@DataEstrazioneequalthis DATETIME, 
	@CodPsrequalthis VARCHAR(255), 
	@IdDimPrioritaequalthis INT, 
	@IdDimIndicatoreequalthis INT, 
	@ValoreRtotequalthis DECIMAL(18,2), 
	@ValorePfequalthis DECIMAL(18,2), 
	@DataPfequalthis DATETIME, 
	@ValoreFequalthis DECIMAL(18,2), 
	@DataFequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT COD_PSR, ID_DIM_PRIORITA, CodPriorita, DesPriorita, OrdPriorita, ID_DIM_INDICATORE, CodIndicatore, DesIndicatore, OrdIndicatore, VALORE_RTOT, VALORE_PF, DATA_PF, VALORE_F, DATA_F, ID_ESTRAZIONE, DATA_ESTRAZIONE, UM FROM vzDIMENSIONI_ESTRAZIONI WHERE 1=1'';
	IF (@IdEstrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ESTRAZIONE = @IdEstrazioneequalthis)''; set @lensql=@lensql+len(@IdEstrazioneequalthis);end;
	IF (@DataEstrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_ESTRAZIONE = @DataEstrazioneequalthis)''; set @lensql=@lensql+len(@DataEstrazioneequalthis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_PSR = @CodPsrequalthis)''; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@IdDimPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DIM_PRIORITA = @IdDimPrioritaequalthis)''; set @lensql=@lensql+len(@IdDimPrioritaequalthis);end;
	IF (@IdDimIndicatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DIM_INDICATORE = @IdDimIndicatoreequalthis)''; set @lensql=@lensql+len(@IdDimIndicatoreequalthis);end;
	IF (@ValoreRtotequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE_RTOT = @ValoreRtotequalthis)''; set @lensql=@lensql+len(@ValoreRtotequalthis);end;
	IF (@ValorePfequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE_PF = @ValorePfequalthis)''; set @lensql=@lensql+len(@ValorePfequalthis);end;
	IF (@DataPfequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_PF = @DataPfequalthis)''; set @lensql=@lensql+len(@DataPfequalthis);end;
	IF (@ValoreFequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE_F = @ValoreFequalthis)''; set @lensql=@lensql+len(@ValoreFequalthis);end;
	IF (@DataFequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_F = @DataFequalthis)''; set @lensql=@lensql+len(@DataFequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdEstrazioneequalthis INT, @DataEstrazioneequalthis DATETIME, @CodPsrequalthis VARCHAR(255), @IdDimPrioritaequalthis INT, @IdDimIndicatoreequalthis INT, @ValoreRtotequalthis DECIMAL(18,2), @ValorePfequalthis DECIMAL(18,2), @DataPfequalthis DATETIME, @ValoreFequalthis DECIMAL(18,2), @DataFequalthis DATETIME'',@IdEstrazioneequalthis , @DataEstrazioneequalthis , @CodPsrequalthis , @IdDimPrioritaequalthis , @IdDimIndicatoreequalthis , @ValoreRtotequalthis , @ValorePfequalthis , @DataPfequalthis , @ValoreFequalthis , @DataFequalthis ;
	else
		SELECT COD_PSR, ID_DIM_PRIORITA, CodPriorita, DesPriorita, OrdPriorita, ID_DIM_INDICATORE, CodIndicatore, DesIndicatore, OrdIndicatore, VALORE_RTOT, VALORE_PF, DATA_PF, VALORE_F, DATA_F, ID_ESTRAZIONE, DATA_ESTRAZIONE, UM
		FROM vzDIMENSIONI_ESTRAZIONI
		WHERE 
			((@IdEstrazioneequalthis IS NULL) OR ID_ESTRAZIONE = @IdEstrazioneequalthis) AND 
			((@DataEstrazioneequalthis IS NULL) OR DATA_ESTRAZIONE = @DataEstrazioneequalthis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@IdDimPrioritaequalthis IS NULL) OR ID_DIM_PRIORITA = @IdDimPrioritaequalthis) AND 
			((@IdDimIndicatoreequalthis IS NULL) OR ID_DIM_INDICATORE = @IdDimIndicatoreequalthis) AND 
			((@ValoreRtotequalthis IS NULL) OR VALORE_RTOT = @ValoreRtotequalthis) AND 
			((@ValorePfequalthis IS NULL) OR VALORE_PF = @ValorePfequalthis) AND 
			((@DataPfequalthis IS NULL) OR DATA_PF = @DataPfequalthis) AND 
			((@ValoreFequalthis IS NULL) OR VALORE_F = @ValoreFequalthis) AND 
			((@DataFequalthis IS NULL) OR DATA_F =', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIoFindSelect';

