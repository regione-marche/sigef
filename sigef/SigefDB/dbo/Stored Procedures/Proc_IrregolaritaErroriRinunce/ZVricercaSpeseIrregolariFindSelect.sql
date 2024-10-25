CREATE PROCEDURE [dbo].[ZVricercaSpeseIrregolariFindSelect]
(
	@IdSpesaequalthis INT, 
	@IdGiustificativoequalthis INT, 
	@CodTipoSpesaequalthis VARCHAR(255), 
	@EstremiSpesaequalthis VARCHAR(255), 
	@DataSpesaequalthis DATETIME, 
	@ImportoSpesaequalthis DECIMAL(18,2), 
	@NettoSpesaequalthis DECIMAL(18,2), 
	@TipoSpesaequalthis VARCHAR(255), 
	@IdDomandaPagamentoequalthis INT, 
	@CodTipoDomandaequalthis VARCHAR(255), 
	@TipoDomandaequalthis VARCHAR(255), 
	@IdProgettoequalthis INT, 
	@NumeroGiustificativoequalthis VARCHAR(255), 
	@CodTipoGiustificativoequalthis VARCHAR(255), 
	@DataGiustificativoequalthis DATETIME, 
	@NumeroDoctrasportoGiustificativoequalthis VARCHAR(255), 
	@ImponibileGiustificativoequalthis DECIMAL(18,2), 
	@IvaGiustificativoequalthis DECIMAL(18,2), 
	@IvaNonRecuperabileGiustificativoequalthis BIT, 
	@DescrizioneGiustificativoequalthis VARCHAR(255), 
	@CfFornitoreGiustificativoequalthis VARCHAR(255), 
	@DescrizioneFornitoreGiustificativoequalthis VARCHAR(255), 
	@TipoGiustificativoequalthis VARCHAR(255), 
	@IdLottoCertificazioneequalthis INT, 
	@CodPsrCertificazioneequalthis VARCHAR(255), 
	@DataInizioLottoCertificazioneequalthis DATETIME, 
	@DataFineLottoCertificazioneequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SPESA, ID_GIUSTIFICATIVO, COD_TIPO_SPESA, ESTREMI_SPESA, DATA_SPESA, IMPORTO_SPESA, NETTO_SPESA, TIPO_SPESA, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOMANDA, TIPO_DOMANDA, ID_PROGETTO, NUMERO_GIUSTIFICATIVO, COD_TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, NUMERO_DOCTRASPORTO_GIUSTIFICATIVO, IMPONIBILE_GIUSTIFICATIVO, IVA_GIUSTIFICATIVO, IVA_NON_RECUPERABILE_GIUSTIFICATIVO, DESCRIZIONE_GIUSTIFICATIVO, CF_FORNITORE_GIUSTIFICATIVO, DESCRIZIONE_FORNITORE_GIUSTIFICATIVO, TIPO_GIUSTIFICATIVO, ID_LOTTO_CERTIFICAZIONE, COD_PSR_CERTIFICAZIONE, DATA_INIZIO_LOTTO_CERTIFICAZIONE, DATA_FINE_LOTTO_CERTIFICAZIONE FROM VRICERCA_SPESE_IRREGOLARI WHERE 1=1';
	IF (@IdSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPESA = @IdSpesaequalthis)'; set @lensql=@lensql+len(@IdSpesaequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@CodTipoSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_SPESA = @CodTipoSpesaequalthis)'; set @lensql=@lensql+len(@CodTipoSpesaequalthis);end;
	IF (@EstremiSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESTREMI_SPESA = @EstremiSpesaequalthis)'; set @lensql=@lensql+len(@EstremiSpesaequalthis);end;
	IF (@DataSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SPESA = @DataSpesaequalthis)'; set @lensql=@lensql+len(@DataSpesaequalthis);end;
	IF (@ImportoSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SPESA = @ImportoSpesaequalthis)'; set @lensql=@lensql+len(@ImportoSpesaequalthis);end;
	IF (@NettoSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NETTO_SPESA = @NettoSpesaequalthis)'; set @lensql=@lensql+len(@NettoSpesaequalthis);end;
	IF (@TipoSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_SPESA = @TipoSpesaequalthis)'; set @lensql=@lensql+len(@TipoSpesaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@CodTipoDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_DOMANDA = @CodTipoDomandaequalthis)'; set @lensql=@lensql+len(@CodTipoDomandaequalthis);end;
	IF (@TipoDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_DOMANDA = @TipoDomandaequalthis)'; set @lensql=@lensql+len(@TipoDomandaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@NumeroGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_GIUSTIFICATIVO = @NumeroGiustificativoequalthis)'; set @lensql=@lensql+len(@NumeroGiustificativoequalthis);end;
	IF (@CodTipoGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_GIUSTIFICATIVO = @CodTipoGiustificativoequalthis)'; set @lensql=@lensql+len(@CodTipoGiustificativoequalthis);end;
	IF (@DataGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_GIUSTIFICATIVO = @DataGiustificativoequalthis)'; set @lensql=@lensql+len(@DataGiustificativoequalthis);end;
	IF (@NumeroDoctrasportoGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_DOCTRASPORTO_GIUSTIFICATIVO = @NumeroDoctrasportoGiustificativoequalthis)'; set @lensql=@lensql+len(@NumeroDoctrasportoGiustificativoequalthis);end;
	IF (@ImponibileGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPONIBILE_GIUSTIFICATIVO = @ImponibileGiustificativoequalthis)'; set @lensql=@lensql+len(@ImponibileGiustificativoequalthis);end;
	IF (@IvaGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IVA_GIUSTIFICATIVO = @IvaGiustificativoequalthis)'; set @lensql=@lensql+len(@IvaGiustificativoequalthis);end;
	IF (@IvaNonRecuperabileGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IVA_NON_RECUPERABILE_GIUSTIFICATIVO = @IvaNonRecuperabileGiustificativoequalthis)'; set @lensql=@lensql+len(@IvaNonRecuperabileGiustificativoequalthis);end;
	IF (@DescrizioneGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_GIUSTIFICATIVO = @DescrizioneGiustificativoequalthis)'; set @lensql=@lensql+len(@DescrizioneGiustificativoequalthis);end;
	IF (@CfFornitoreGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_FORNITORE_GIUSTIFICATIVO = @CfFornitoreGiustificativoequalthis)'; set @lensql=@lensql+len(@CfFornitoreGiustificativoequalthis);end;
	IF (@DescrizioneFornitoreGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_FORNITORE_GIUSTIFICATIVO = @DescrizioneFornitoreGiustificativoequalthis)'; set @lensql=@lensql+len(@DescrizioneFornitoreGiustificativoequalthis);end;
	IF (@TipoGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_GIUSTIFICATIVO = @TipoGiustificativoequalthis)'; set @lensql=@lensql+len(@TipoGiustificativoequalthis);end;
	IF (@IdLottoCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO_CERTIFICAZIONE = @IdLottoCertificazioneequalthis)'; set @lensql=@lensql+len(@IdLottoCertificazioneequalthis);end;
	IF (@CodPsrCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR_CERTIFICAZIONE = @CodPsrCertificazioneequalthis)'; set @lensql=@lensql+len(@CodPsrCertificazioneequalthis);end;
	IF (@DataInizioLottoCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_LOTTO_CERTIFICAZIONE = @DataInizioLottoCertificazioneequalthis)'; set @lensql=@lensql+len(@DataInizioLottoCertificazioneequalthis);end;
	IF (@DataFineLottoCertificazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_LOTTO_CERTIFICAZIONE = @DataFineLottoCertificazioneequalthis)'; set @lensql=@lensql+len(@DataFineLottoCertificazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSpesaequalthis INT, @IdGiustificativoequalthis INT, @CodTipoSpesaequalthis VARCHAR(255), @EstremiSpesaequalthis VARCHAR(255), @DataSpesaequalthis DATETIME, @ImportoSpesaequalthis DECIMAL(18,2), @NettoSpesaequalthis DECIMAL(18,2), @TipoSpesaequalthis VARCHAR(255), @IdDomandaPagamentoequalthis INT, @CodTipoDomandaequalthis VARCHAR(255), @TipoDomandaequalthis VARCHAR(255), @IdProgettoequalthis INT, @NumeroGiustificativoequalthis VARCHAR(255), @CodTipoGiustificativoequalthis VARCHAR(255), @DataGiustificativoequalthis DATETIME, @NumeroDoctrasportoGiustificativoequalthis VARCHAR(255), @ImponibileGiustificativoequalthis DECIMAL(18,2), @IvaGiustificativoequalthis DECIMAL(18,2), @IvaNonRecuperabileGiustificativoequalthis BIT, @DescrizioneGiustificativoequalthis VARCHAR(255), @CfFornitoreGiustificativoequalthis VARCHAR(255), @DescrizioneFornitoreGiustificativoequalthis VARCHAR(255), @TipoGiustificativoequalthis VARCHAR(255), @IdLottoCertificazioneequalthis INT, @CodPsrCertificazioneequalthis VARCHAR(255), @DataInizioLottoCertificazioneequalthis DATETIME, @DataFineLottoCertificazioneequalthis DATETIME',@IdSpesaequalthis , @IdGiustificativoequalthis , @CodTipoSpesaequalthis , @EstremiSpesaequalthis , @DataSpesaequalthis , @ImportoSpesaequalthis , @NettoSpesaequalthis , @TipoSpesaequalthis , @IdDomandaPagamentoequalthis , @CodTipoDomandaequalthis , @TipoDomandaequalthis , @IdProgettoequalthis , @NumeroGiustificativoequalthis , @CodTipoGiustificativoequalthis , @DataGiustificativoequalthis , @NumeroDoctrasportoGiustificativoequalthis , @ImponibileGiustificativoequalthis , @IvaGiustificativoequalthis , @IvaNonRecuperabileGiustificativoequalthis , @DescrizioneGiustificativoequalthis , @CfFornitoreGiustificativoequalthis , @DescrizioneFornitoreGiustificativoequalthis , @TipoGiustificativoequalthis , @IdLottoCertificazioneequalthis , @CodPsrCertificazioneequalthis , @DataInizioLottoCertificazioneequalthis , @DataFineLottoCertificazioneequalthis ;
	else
		SELECT ID_SPESA, ID_GIUSTIFICATIVO, COD_TIPO_SPESA, ESTREMI_SPESA, DATA_SPESA, IMPORTO_SPESA, NETTO_SPESA, TIPO_SPESA, ID_DOMANDA_PAGAMENTO, COD_TIPO_DOMANDA, TIPO_DOMANDA, ID_PROGETTO, NUMERO_GIUSTIFICATIVO, COD_TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, NUMERO_DOCTRASPORTO_GIUSTIFICATIVO, IMPONIBILE_GIUSTIFICATIVO, IVA_GIUSTIFICATIVO, IVA_NON_RECUPERABILE_GIUSTIFICATIVO, DESCRIZIONE_GIUSTIFICATIVO, CF_FORNITORE_GIUSTIFICATIVO, DESCRIZIONE_FORNITORE_GIUSTIFICATIVO, TIPO_GIUSTIFICATIVO, ID_LOTTO_CERTIFICAZIONE, COD_PSR_CERTIFICAZIONE, DATA_INIZIO_LOTTO_CERTIFICAZIONE, DATA_FINE_LOTTO_CERTIFICAZIONE
		FROM VRICERCA_SPESE_IRREGOLARI
		WHERE 
			((@IdSpesaequalthis IS NULL) OR ID_SPESA = @IdSpesaequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis) AND 
			((@CodTipoSpesaequalthis IS NULL) OR COD_TIPO_SPESA = @CodTipoSpesaequalthis) AND 
			((@EstremiSpesaequalthis IS NULL) OR ESTREMI_SPESA = @EstremiSpesaequalthis) AND 
			((@DataSpesaequalthis IS NULL) OR DATA_SPESA = @DataSpesaequalthis) AND 
			((@ImportoSpesaequalthis IS NULL) OR IMPORTO_SPESA = @ImportoSpesaequalthis) AND 
			((@NettoSpesaequalthis IS NULL) OR NETTO_SPESA = @NettoSpesaequalthis) AND 
			((@TipoSpesaequalthis IS NULL) OR TIPO_SPESA = @TipoSpesaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@CodTipoDomandaequalthis IS NULL) OR COD_TIPO_DOMANDA = @CodTipoDomandaequalthis) AND 
			((@TipoDomandaequalthis IS NULL) OR TIPO_DOMANDA = @TipoDomandaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@NumeroGiustificativoequalthis IS NULL) OR NUMERO_GIUSTIFICATIVO = @NumeroGiustificativoequalthis) AND 
			((@CodTipoGiustificativoequalthis IS NULL) OR COD_TIPO_GIUSTIFICATIVO = @CodTipoGiustificativoequalthis) AND 
			((@DataGiustificativoequalthis IS NULL) OR DATA_GIUSTIFICATIVO = @DataGiustificativoequalthis) AND 
			((@NumeroDoctrasportoGiustificativoequalthis IS NULL) OR NUMERO_DOCTRASPORTO_GIUSTIFICATIVO = @NumeroDoctrasportoGiustificativoequalthis) AND 
			((@ImponibileGiustificativoequalthis IS NULL) OR IMPONIBILE_GIUSTIFICATIVO = @ImponibileGiustificativoequalthis) AND 
			((@IvaGiustificativoequalthis IS NULL) OR IVA_GIUSTIFICATIVO = @IvaGiustificativoequalthis) AND 
			((@IvaNonRecuperabileGiustificativoequalthis IS NULL) OR IVA_NON_RECUPERABILE_GIUSTIFICATIVO = @IvaNonRecuperabileGiustificativoequalthis) AND 
			((@DescrizioneGiustificativoequalthis IS NULL) OR DESCRIZIONE_GIUSTIFICATIVO = @DescrizioneGiustificativoequalthis) AND 
			((@CfFornitoreGiustificativoequalthis IS NULL) OR CF_FORNITORE_GIUSTIFICATIVO = @CfFornitoreGiustificativoequalthis) AND 
			((@DescrizioneFornitoreGiustificativoequalthis IS NULL) OR DESCRIZIONE_FORNITORE_GIUSTIFICATIVO = @DescrizioneFornitoreGiustificativoequalthis) AND 
			((@TipoGiustificativoequalthis IS NULL) OR TIPO_GIUSTIFICATIVO = @TipoGiustificativoequalthis) AND 
			((@IdLottoCertificazioneequalthis IS NULL) OR ID_LOTTO_CERTIFICAZIONE = @IdLottoCertificazioneequalthis) AND 
			((@CodPsrCertificazioneequalthis IS NULL) OR COD_PSR_CERTIFICAZIONE = @CodPsrCertificazioneequalthis) AND 
			((@DataInizioLottoCertificazioneequalthis IS NULL) OR DATA_INIZIO_LOTTO_CERTIFICAZIONE = @DataInizioLottoCertificazioneequalthis) AND 
			((@DataFineLottoCertificazioneequalthis IS NULL) OR DATA_FINE_LOTTO_CERTIFICAZIONE = @DataFineLottoCertificazioneequalthis)
		

GO