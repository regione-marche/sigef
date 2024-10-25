CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioFindSelect]
(
	@IdRecuperoBeneficiarioequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT, 
	@Origineequalthis VARCHAR(255), 
	@IdIrregolaritaequalthis INT, 
	@IdRevocaequalthis INT, 
	@IdErroreequalthis INT, 
	@DecretoRecuperoNumeroequalthis VARCHAR(255), 
	@DecretoRecuperoDataequalthis DATETIME, 
	@DataAvvioRecuperoequalthis DATETIME, 
	@SegnaturaPaleoComunicazioneBeneficiarioequalthis VARCHAR(255), 
	@Contributoequalthis DECIMAL(15,2), 
	@Interessiequalthis DECIMAL(15,2), 
	@Speseequalthis DECIMAL(15,2), 
	@Sanzioniequalthis DECIMAL(15,2), 
	@TotaleDaRecuperareequalthis DECIMAL(15,2), 
	@Noteequalthis VARCHAR(max), 
	@Definitivoequalthis BIT, 
	@ImportoRecuperatoequalthis DECIMAL(15,2), 
	@ImportoIrrecuperabileequalthis DECIMAL(15,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_RECUPERO_BENEFICIARIO, ID_PROGETTO, ID_IMPRESA, ORIGINE, ID_IRREGOLARITA, ID_REVOCA, ID_ERRORE, DECRETO_RECUPERO_NUMERO, DECRETO_RECUPERO_DATA, DATA_AVVIO_RECUPERO, SEGNATURA_PALEO_COMUNICAZIONE_BENEFICIARIO, CONTRIBUTO, INTERESSI, SPESE, SANZIONI, TOTALE_DA_RECUPERARE, NOTE, DEFINITIVO, IMPORTO_RECUPERATO, IMPORTO_IRRECUPERABILE FROM RECUPERO_BENEFICIARIO WHERE 1=1';
	IF (@IdRecuperoBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RECUPERO_BENEFICIARIO = @IdRecuperoBeneficiarioequalthis)'; set @lensql=@lensql+len(@IdRecuperoBeneficiarioequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Origineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORIGINE = @Origineequalthis)'; set @lensql=@lensql+len(@Origineequalthis);end;
	IF (@IdIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IRREGOLARITA = @IdIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdIrregolaritaequalthis);end;
	IF (@IdRevocaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REVOCA = @IdRevocaequalthis)'; set @lensql=@lensql+len(@IdRevocaequalthis);end;
	IF (@IdErroreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ERRORE = @IdErroreequalthis)'; set @lensql=@lensql+len(@IdErroreequalthis);end;
	IF (@DecretoRecuperoNumeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DECRETO_RECUPERO_NUMERO = @DecretoRecuperoNumeroequalthis)'; set @lensql=@lensql+len(@DecretoRecuperoNumeroequalthis);end;
	IF (@DecretoRecuperoDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DECRETO_RECUPERO_DATA = @DecretoRecuperoDataequalthis)'; set @lensql=@lensql+len(@DecretoRecuperoDataequalthis);end;
	IF (@DataAvvioRecuperoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_AVVIO_RECUPERO = @DataAvvioRecuperoequalthis)'; set @lensql=@lensql+len(@DataAvvioRecuperoequalthis);end;
	IF (@SegnaturaPaleoComunicazioneBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_PALEO_COMUNICAZIONE_BENEFICIARIO = @SegnaturaPaleoComunicazioneBeneficiarioequalthis)'; set @lensql=@lensql+len(@SegnaturaPaleoComunicazioneBeneficiarioequalthis);end;
	IF (@Contributoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO = @Contributoequalthis)'; set @lensql=@lensql+len(@Contributoequalthis);end;
	IF (@Interessiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTERESSI = @Interessiequalthis)'; set @lensql=@lensql+len(@Interessiequalthis);end;
	IF (@Speseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESE = @Speseequalthis)'; set @lensql=@lensql+len(@Speseequalthis);end;
	IF (@Sanzioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SANZIONI = @Sanzioniequalthis)'; set @lensql=@lensql+len(@Sanzioniequalthis);end;
	IF (@TotaleDaRecuperareequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOTALE_DA_RECUPERARE = @TotaleDaRecuperareequalthis)'; set @lensql=@lensql+len(@TotaleDaRecuperareequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@Definitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DEFINITIVO = @Definitivoequalthis)'; set @lensql=@lensql+len(@Definitivoequalthis);end;
	IF (@ImportoRecuperatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RECUPERATO = @ImportoRecuperatoequalthis)'; set @lensql=@lensql+len(@ImportoRecuperatoequalthis);end;
	IF (@ImportoIrrecuperabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_IRRECUPERABILE = @ImportoIrrecuperabileequalthis)'; set @lensql=@lensql+len(@ImportoIrrecuperabileequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRecuperoBeneficiarioequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT, @Origineequalthis VARCHAR(255), @IdIrregolaritaequalthis INT, @IdRevocaequalthis INT, @IdErroreequalthis INT, @DecretoRecuperoNumeroequalthis VARCHAR(255), @DecretoRecuperoDataequalthis DATETIME, @DataAvvioRecuperoequalthis DATETIME, @SegnaturaPaleoComunicazioneBeneficiarioequalthis VARCHAR(255), @Contributoequalthis DECIMAL(15,2), @Interessiequalthis DECIMAL(15,2), @Speseequalthis DECIMAL(15,2), @Sanzioniequalthis DECIMAL(15,2), @TotaleDaRecuperareequalthis DECIMAL(15,2), @Noteequalthis VARCHAR(max), @Definitivoequalthis BIT, @ImportoRecuperatoequalthis DECIMAL(15,2), @ImportoIrrecuperabileequalthis DECIMAL(15,2)',@IdRecuperoBeneficiarioequalthis , @IdProgettoequalthis , @IdImpresaequalthis , @Origineequalthis , @IdIrregolaritaequalthis , @IdRevocaequalthis , @IdErroreequalthis , @DecretoRecuperoNumeroequalthis , @DecretoRecuperoDataequalthis , @DataAvvioRecuperoequalthis , @SegnaturaPaleoComunicazioneBeneficiarioequalthis , @Contributoequalthis , @Interessiequalthis , @Speseequalthis , @Sanzioniequalthis , @TotaleDaRecuperareequalthis , @Noteequalthis , @Definitivoequalthis , @ImportoRecuperatoequalthis , @ImportoIrrecuperabileequalthis ;
	else
		SELECT ID_RECUPERO_BENEFICIARIO, ID_PROGETTO, ID_IMPRESA, ORIGINE, ID_IRREGOLARITA, ID_REVOCA, ID_ERRORE, DECRETO_RECUPERO_NUMERO, DECRETO_RECUPERO_DATA, DATA_AVVIO_RECUPERO, SEGNATURA_PALEO_COMUNICAZIONE_BENEFICIARIO, CONTRIBUTO, INTERESSI, SPESE, SANZIONI, TOTALE_DA_RECUPERARE, NOTE, DEFINITIVO, IMPORTO_RECUPERATO, IMPORTO_IRRECUPERABILE
		FROM RECUPERO_BENEFICIARIO
		WHERE 
			((@IdRecuperoBeneficiarioequalthis IS NULL) OR ID_RECUPERO_BENEFICIARIO = @IdRecuperoBeneficiarioequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Origineequalthis IS NULL) OR ORIGINE = @Origineequalthis) AND 
			((@IdIrregolaritaequalthis IS NULL) OR ID_IRREGOLARITA = @IdIrregolaritaequalthis) AND 
			((@IdRevocaequalthis IS NULL) OR ID_REVOCA = @IdRevocaequalthis) AND 
			((@IdErroreequalthis IS NULL) OR ID_ERRORE = @IdErroreequalthis) AND 
			((@DecretoRecuperoNumeroequalthis IS NULL) OR DECRETO_RECUPERO_NUMERO = @DecretoRecuperoNumeroequalthis) AND 
			((@DecretoRecuperoDataequalthis IS NULL) OR DECRETO_RECUPERO_DATA = @DecretoRecuperoDataequalthis) AND 
			((@DataAvvioRecuperoequalthis IS NULL) OR DATA_AVVIO_RECUPERO = @DataAvvioRecuperoequalthis) AND 
			((@SegnaturaPaleoComunicazioneBeneficiarioequalthis IS NULL) OR SEGNATURA_PALEO_COMUNICAZIONE_BENEFICIARIO = @SegnaturaPaleoComunicazioneBeneficiarioequalthis) AND 
			((@Contributoequalthis IS NULL) OR CONTRIBUTO = @Contributoequalthis) AND 
			((@Interessiequalthis IS NULL) OR INTERESSI = @Interessiequalthis) AND 
			((@Speseequalthis IS NULL) OR SPESE = @Speseequalthis) AND 
			((@Sanzioniequalthis IS NULL) OR SANZIONI = @Sanzioniequalthis) AND 
			((@TotaleDaRecuperareequalthis IS NULL) OR TOTALE_DA_RECUPERARE = @TotaleDaRecuperareequalthis) AND 
			((@Noteequalthis IS NULL) OR NOTE = @Noteequalthis) AND 
			((@Definitivoequalthis IS NULL) OR DEFINITIVO = @Definitivoequalthis) AND 
			((@ImportoRecuperatoequalthis IS NULL) OR IMPORTO_RECUPERATO = @ImportoRecuperatoequalthis) AND 
			((@ImportoIrrecuperabileequalthis IS NULL) OR IMPORTO_IRRECUPERABILE = @ImportoIrrecuperabileequalthis)