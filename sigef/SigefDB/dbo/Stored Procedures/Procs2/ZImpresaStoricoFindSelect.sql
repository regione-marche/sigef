CREATE PROCEDURE [dbo].[ZImpresaStoricoFindSelect]
(
	@IdStoricoImpresaequalthis INT, 
	@IdImpresaequalthis INT, 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@RagioneSocialeequalthis VARCHAR(255), 
	@CodiceInpsequalthis VARCHAR(255), 
	@CodFormaGiuridicaequalthis VARCHAR(255), 
	@IdDimensioneequalthis INT, 
	@RegistroImpreseNumeroequalthis VARCHAR(255), 
	@ReaNumeroequalthis VARCHAR(255), 
	@ReaAnnoequalthis INT, 
	@CodClassificazioneUmaequalthis VARCHAR(255), 
	@Attivaequalthis BIT, 
	@DataCessazioneequalthis DATETIME, 
	@SegnaturaCessazioneequalthis VARCHAR(255), 
	@CodTipoCessazioneequalthis VARCHAR(255), 
	@CodAteco2007equalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_STORICO_IMPRESA, ID_IMPRESA, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, RAGIONE_SOCIALE, CODICE_INPS, COD_FORMA_GIURIDICA, ID_DIMENSIONE, REGISTRO_IMPRESE_NUMERO, REA_NUMERO, REA_ANNO, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, COD_CLASSIFICAZIONE_UMA, ATTIVA, DATA_CESSAZIONE, SEGNATURA_CESSAZIONE, COD_TIPO_CESSAZIONE, COD_ATECO2007 FROM vIMPRESA_STORICO WHERE 1=1';
	IF (@IdStoricoImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STORICO_IMPRESA = @IdStoricoImpresaequalthis)'; set @lensql=@lensql+len(@IdStoricoImpresaequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)'; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@RagioneSocialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE = @RagioneSocialeequalthis)'; set @lensql=@lensql+len(@RagioneSocialeequalthis);end;
	IF (@CodiceInpsequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_INPS = @CodiceInpsequalthis)'; set @lensql=@lensql+len(@CodiceInpsequalthis);end;
	IF (@CodFormaGiuridicaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FORMA_GIURIDICA = @CodFormaGiuridicaequalthis)'; set @lensql=@lensql+len(@CodFormaGiuridicaequalthis);end;
	IF (@IdDimensioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DIMENSIONE = @IdDimensioneequalthis)'; set @lensql=@lensql+len(@IdDimensioneequalthis);end;
	IF (@RegistroImpreseNumeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REGISTRO_IMPRESE_NUMERO = @RegistroImpreseNumeroequalthis)'; set @lensql=@lensql+len(@RegistroImpreseNumeroequalthis);end;
	IF (@ReaNumeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REA_NUMERO = @ReaNumeroequalthis)'; set @lensql=@lensql+len(@ReaNumeroequalthis);end;
	IF (@ReaAnnoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REA_ANNO = @ReaAnnoequalthis)'; set @lensql=@lensql+len(@ReaAnnoequalthis);end;
	IF (@CodClassificazioneUmaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_CLASSIFICAZIONE_UMA = @CodClassificazioneUmaequalthis)'; set @lensql=@lensql+len(@CodClassificazioneUmaequalthis);end;
	IF (@Attivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVA = @Attivaequalthis)'; set @lensql=@lensql+len(@Attivaequalthis);end;
	IF (@DataCessazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CESSAZIONE = @DataCessazioneequalthis)'; set @lensql=@lensql+len(@DataCessazioneequalthis);end;
	IF (@SegnaturaCessazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_CESSAZIONE = @SegnaturaCessazioneequalthis)'; set @lensql=@lensql+len(@SegnaturaCessazioneequalthis);end;
	IF (@CodTipoCessazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_CESSAZIONE = @CodTipoCessazioneequalthis)'; set @lensql=@lensql+len(@CodTipoCessazioneequalthis);end;
	IF (@CodAteco2007equalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ATECO2007 = @CodAteco2007equalthis)'; set @lensql=@lensql+len(@CodAteco2007equalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdStoricoImpresaequalthis INT, @IdImpresaequalthis INT, @DataInizioValiditaequalthis DATETIME, @DataFineValiditaequalthis DATETIME, @RagioneSocialeequalthis VARCHAR(255), @CodiceInpsequalthis VARCHAR(255), @CodFormaGiuridicaequalthis VARCHAR(255), @IdDimensioneequalthis INT, @RegistroImpreseNumeroequalthis VARCHAR(255), @ReaNumeroequalthis VARCHAR(255), @ReaAnnoequalthis INT, @CodClassificazioneUmaequalthis VARCHAR(255), @Attivaequalthis BIT, @DataCessazioneequalthis DATETIME, @SegnaturaCessazioneequalthis VARCHAR(255), @CodTipoCessazioneequalthis VARCHAR(255), @CodAteco2007equalthis VARCHAR(255)',@IdStoricoImpresaequalthis , @IdImpresaequalthis , @DataInizioValiditaequalthis , @DataFineValiditaequalthis , @RagioneSocialeequalthis , @CodiceInpsequalthis , @CodFormaGiuridicaequalthis , @IdDimensioneequalthis , @RegistroImpreseNumeroequalthis , @ReaNumeroequalthis , @ReaAnnoequalthis , @CodClassificazioneUmaequalthis , @Attivaequalthis , @DataCessazioneequalthis , @SegnaturaCessazioneequalthis , @CodTipoCessazioneequalthis , @CodAteco2007equalthis ;
	else
		SELECT ID_STORICO_IMPRESA, ID_IMPRESA, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, RAGIONE_SOCIALE, CODICE_INPS, COD_FORMA_GIURIDICA, ID_DIMENSIONE, REGISTRO_IMPRESE_NUMERO, REA_NUMERO, REA_ANNO, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, COD_CLASSIFICAZIONE_UMA, ATTIVA, DATA_CESSAZIONE, SEGNATURA_CESSAZIONE, COD_TIPO_CESSAZIONE, COD_ATECO2007
		FROM vIMPRESA_STORICO
		WHERE 
			((@IdStoricoImpresaequalthis IS NULL) OR ID_STORICO_IMPRESA = @IdStoricoImpresaequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@DataInizioValiditaequalthis IS NULL) OR DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@RagioneSocialeequalthis IS NULL) OR RAGIONE_SOCIALE = @RagioneSocialeequalthis) AND 
			((@CodiceInpsequalthis IS NULL) OR CODICE_INPS = @CodiceInpsequalthis) AND 
			((@CodFormaGiuridicaequalthis IS NULL) OR COD_FORMA_GIURIDICA = @CodFormaGiuridicaequalthis) AND 
			((@IdDimensioneequalthis IS NULL) OR ID_DIMENSIONE = @IdDimensioneequalthis) AND 
			((@RegistroImpreseNumeroequalthis IS NULL) OR REGISTRO_IMPRESE_NUMERO = @RegistroImpreseNumeroequalthis) AND 
			((@ReaNumeroequalthis IS NULL) OR REA_NUMERO = @ReaNumeroequalthis) AND 
			((@ReaAnnoequalthis IS NULL) OR REA_ANNO = @ReaAnnoequalthis) AND 
			((@CodClassificazioneUmaequalthis IS NULL) OR COD_CLASSIFICAZIONE_UMA = @CodClassificazioneUmaequalthis) AND 
			((@Attivaequalthis IS NULL) OR ATTIVA = @Attivaequalthis) AND 
			((@DataCessazioneequalthis IS NULL) OR DATA_CESSAZIONE = @DataCessazioneequalthis) AND 
			((@SegnaturaCessazioneequalthis IS NULL) OR SEGNATURA_CESSAZIONE = @SegnaturaCessazioneequalthis) AND 
			((@CodTipoCessazioneequalthis IS NULL) OR COD_TIPO_CESSAZIONE = @CodTipoCessazioneequalthis) AND 
			((@CodAteco2007equalthis IS NULL) OR COD_ATECO2007 = @CodAteco2007equalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaStoricoFindSelect]
(
	@IdStoricoImpresaequalthis INT, 
	@IdImpresaequalthis INT, 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@RagioneSocialeequalthis VARCHAR(255), 
	@CodiceInpsequalthis VARCHAR(255), 
	@CodFormaGiuridicaequalthis VARCHAR(255), 
	@IdDimensioneequalthis INT, 
	@RegistroImpreseNumeroequalthis VARCHAR(255), 
	@ReaNumeroequalthis VARCHAR(255), 
	@ReaAnnoequalthis INT, 
	@CodClassificazioneUmaequalthis VARCHAR(255), 
	@Attivaequalthis BIT, 
	@DataCessazioneequalthis DATETIME, 
	@SegnaturaCessazioneequalthis VARCHAR(255), 
	@CodTipoCessazioneequalthis VARCHAR(255), 
	@CodAteco2007equalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_STORICO_IMPRESA, ID_IMPRESA, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, RAGIONE_SOCIALE, CODICE_INPS, COD_FORMA_GIURIDICA, ID_DIMENSIONE, REGISTRO_IMPRESE_NUMERO, REA_NUMERO, REA_ANNO, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, COD_CLASSIFICAZIONE_UMA, ATTIVA, DATA_CESSAZIONE, SEGNATURA_CESSAZIONE, COD_TIPO_CESSAZIONE, COD_ATECO2007 FROM vIMPRESA_STORICO WHERE 1=1'';
	IF (@IdStoricoImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_STORICO_IMPRESA = @IdStoricoImpresaequalthis)''; set @lensql=@lensql+len(@IdStoricoImpresaequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)''; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)''; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@RagioneSocialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RAGIONE_SOCIALE = @RagioneSocialeequalthis)''; set @lensql=@lensql+len(@RagioneSocialeequalthis);end;
	IF (@CodiceInpsequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE_INPS = @CodiceInpsequalthis)''; set @lensql=@lensql+len(@CodiceInpsequalthis);end;
	IF (@CodFormaGiuridicaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FORMA_GIURIDICA = @CodFormaGiuridicaequalthis)''; set @lensql=@lensql+len(@CodFormaGiuridicaequalthis);end;
	IF (@IdDimensioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DIMENSIONE = @IdDimensioneequalthis)''; set @lensql=@lensql+len(@IdDimensioneequalthis);end;
	IF (@RegistroImpreseNumeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (REGISTRO_IMPRESE_NUMERO = @RegistroImpreseNumeroequalthis)''; set @lensql=@lensql+len(@RegistroImpreseNumeroequalthis);end;
	IF (@ReaNumeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (REA_NUMERO = @ReaNumeroequalthis)''; set @lensql=@lensql+len(@ReaNumeroequalthis);end;
	IF (@ReaAnnoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (REA_ANNO = @ReaAnnoequalthis)''; set @lensql=@lensql+len(@ReaAnnoequalthis);end;
	IF (@CodClassificazioneUmaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_CLASSIFICAZIONE_UMA = @CodClassificazioneUmaequalthis)''; set @lensql=@lensql+len(@CodClassificazioneUmaequalthis);end;
	IF (@Attivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVA = @Attivaequalthis)''; set @lensql=@lensql+len(@Attivaequalthis);end;
	IF (@DataCessazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_CESSAZIONE = @DataCessazioneequalthis)''; set @lensql=@lensql+len(@DataCessazioneequalthis);end;
	IF (@SegnaturaCessazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA_CESSAZIONE = @SegnaturaCessazioneequalthis)''; set @lensql=@lensql+len(@SegnaturaCessazioneequalthis);end;
	IF (@CodTipoCessazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_CESSAZIONE = @CodTipoCessazioneequalthis)''; set @lensql=@lensql+len(@CodTipoCessazioneequalthis);en', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaStoricoFindSelect';

