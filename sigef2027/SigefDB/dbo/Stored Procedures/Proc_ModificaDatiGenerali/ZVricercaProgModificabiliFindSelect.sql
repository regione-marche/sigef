CREATE PROCEDURE [dbo].[ZVricercaProgModificabiliFindSelect]
(
	@IdBandoequalthis INT, 
	@DescrizioneBandoequalthis VARCHAR(2000), 
	@CodEnteBandoequalthis VARCHAR(255), 
	@EnteBandoequalthis VARCHAR(255), 
	@IdRupequalthis INT, 
	@Rupequalthis VARCHAR(511), 
	@CfRupequalthis VARCHAR(255), 
	@DataAperturaBandoequalthis DATETIME, 
	@DataScadenzaBandoequalthis DATETIME, 
	@CodStatoBandoequalthis VARCHAR(255), 
	@StatoBandoequalthis VARCHAR(255), 
	@SegnaturaBandoequalthis VARCHAR(255), 
	@IdProgettoequalthis INT, 
	@CodStatoProgettoequalthis VARCHAR(255), 
	@StatoProgettoequalthis VARCHAR(255), 
	@SegnaturaProgettoequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@Impresaequalthis VARCHAR(255), 
	@CfImpresaequalthis VARCHAR(255), 
	@CuaaImpresaequalthis VARCHAR(255), 
	@IdIstruttoreProgettoequalthis INT, 
	@IstruttoreProgettoequalthis VARCHAR(511)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, COD_ENTE_BANDO, ENTE_BANDO, ID_RUP, RUP, CF_RUP, DATA_APERTURA_BANDO, DATA_SCADENZA_BANDO, COD_STATO_BANDO, STATO_BANDO, SEGNATURA_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, SEGNATURA_PROGETTO, ID_IMPRESA, IMPRESA, CF_IMPRESA, CUAA_IMPRESA, ID_ISTRUTTORE_PROGETTO, ISTRUTTORE_PROGETTO FROM VRICERCA_PROG_MODIFICABILI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@DescrizioneBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_BANDO = @DescrizioneBandoequalthis)'; set @lensql=@lensql+len(@DescrizioneBandoequalthis);end;
	IF (@CodEnteBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_BANDO = @CodEnteBandoequalthis)'; set @lensql=@lensql+len(@CodEnteBandoequalthis);end;
	IF (@EnteBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ENTE_BANDO = @EnteBandoequalthis)'; set @lensql=@lensql+len(@EnteBandoequalthis);end;
	IF (@IdRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RUP = @IdRupequalthis)'; set @lensql=@lensql+len(@IdRupequalthis);end;
	IF (@Rupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RUP = @Rupequalthis)'; set @lensql=@lensql+len(@Rupequalthis);end;
	IF (@CfRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_RUP = @CfRupequalthis)'; set @lensql=@lensql+len(@CfRupequalthis);end;
	IF (@DataAperturaBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_APERTURA_BANDO = @DataAperturaBandoequalthis)'; set @lensql=@lensql+len(@DataAperturaBandoequalthis);end;
	IF (@DataScadenzaBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA_BANDO = @DataScadenzaBandoequalthis)'; set @lensql=@lensql+len(@DataScadenzaBandoequalthis);end;
	IF (@CodStatoBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO_BANDO = @CodStatoBandoequalthis)'; set @lensql=@lensql+len(@CodStatoBandoequalthis);end;
	IF (@StatoBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_BANDO = @StatoBandoequalthis)'; set @lensql=@lensql+len(@StatoBandoequalthis);end;
	IF (@SegnaturaBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_BANDO = @SegnaturaBandoequalthis)'; set @lensql=@lensql+len(@SegnaturaBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO_PROGETTO = @CodStatoProgettoequalthis)'; set @lensql=@lensql+len(@CodStatoProgettoequalthis);end;
	IF (@StatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_PROGETTO = @StatoProgettoequalthis)'; set @lensql=@lensql+len(@StatoProgettoequalthis);end;
	IF (@SegnaturaProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_PROGETTO = @SegnaturaProgettoequalthis)'; set @lensql=@lensql+len(@SegnaturaProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Impresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPRESA = @Impresaequalthis)'; set @lensql=@lensql+len(@Impresaequalthis);end;
	IF (@CfImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_IMPRESA = @CfImpresaequalthis)'; set @lensql=@lensql+len(@CfImpresaequalthis);end;
	IF (@CuaaImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA_IMPRESA = @CuaaImpresaequalthis)'; set @lensql=@lensql+len(@CuaaImpresaequalthis);end;
	IF (@IdIstruttoreProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTRUTTORE_PROGETTO = @IdIstruttoreProgettoequalthis)'; set @lensql=@lensql+len(@IdIstruttoreProgettoequalthis);end;
	IF (@IstruttoreProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE_PROGETTO = @IstruttoreProgettoequalthis)'; set @lensql=@lensql+len(@IstruttoreProgettoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @DescrizioneBandoequalthis VARCHAR(2000), @CodEnteBandoequalthis VARCHAR(255), @EnteBandoequalthis VARCHAR(255), @IdRupequalthis INT, @Rupequalthis VARCHAR(511), @CfRupequalthis VARCHAR(255), @DataAperturaBandoequalthis DATETIME, @DataScadenzaBandoequalthis DATETIME, @CodStatoBandoequalthis VARCHAR(255), @StatoBandoequalthis VARCHAR(255), @SegnaturaBandoequalthis VARCHAR(255), @IdProgettoequalthis INT, @CodStatoProgettoequalthis VARCHAR(255), @StatoProgettoequalthis VARCHAR(255), @SegnaturaProgettoequalthis VARCHAR(255), @IdImpresaequalthis INT, @Impresaequalthis VARCHAR(255), @CfImpresaequalthis VARCHAR(255), @CuaaImpresaequalthis VARCHAR(255), @IdIstruttoreProgettoequalthis INT, @IstruttoreProgettoequalthis VARCHAR(511)',@IdBandoequalthis , @DescrizioneBandoequalthis , @CodEnteBandoequalthis , @EnteBandoequalthis , @IdRupequalthis , @Rupequalthis , @CfRupequalthis , @DataAperturaBandoequalthis , @DataScadenzaBandoequalthis , @CodStatoBandoequalthis , @StatoBandoequalthis , @SegnaturaBandoequalthis , @IdProgettoequalthis , @CodStatoProgettoequalthis , @StatoProgettoequalthis , @SegnaturaProgettoequalthis , @IdImpresaequalthis , @Impresaequalthis , @CfImpresaequalthis , @CuaaImpresaequalthis , @IdIstruttoreProgettoequalthis , @IstruttoreProgettoequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, COD_ENTE_BANDO, ENTE_BANDO, ID_RUP, RUP, CF_RUP, DATA_APERTURA_BANDO, DATA_SCADENZA_BANDO, COD_STATO_BANDO, STATO_BANDO, SEGNATURA_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, SEGNATURA_PROGETTO, ID_IMPRESA, IMPRESA, CF_IMPRESA, CUAA_IMPRESA, ID_ISTRUTTORE_PROGETTO, ISTRUTTORE_PROGETTO
		FROM VRICERCA_PROG_MODIFICABILI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@DescrizioneBandoequalthis IS NULL) OR DESCRIZIONE_BANDO = @DescrizioneBandoequalthis) AND 
			((@CodEnteBandoequalthis IS NULL) OR COD_ENTE_BANDO = @CodEnteBandoequalthis) AND 
			((@EnteBandoequalthis IS NULL) OR ENTE_BANDO = @EnteBandoequalthis) AND 
			((@IdRupequalthis IS NULL) OR ID_RUP = @IdRupequalthis) AND 
			((@Rupequalthis IS NULL) OR RUP = @Rupequalthis) AND 
			((@CfRupequalthis IS NULL) OR CF_RUP = @CfRupequalthis) AND 
			((@DataAperturaBandoequalthis IS NULL) OR DATA_APERTURA_BANDO = @DataAperturaBandoequalthis) AND 
			((@DataScadenzaBandoequalthis IS NULL) OR DATA_SCADENZA_BANDO = @DataScadenzaBandoequalthis) AND 
			((@CodStatoBandoequalthis IS NULL) OR COD_STATO_BANDO = @CodStatoBandoequalthis) AND 
			((@StatoBandoequalthis IS NULL) OR STATO_BANDO = @StatoBandoequalthis) AND 
			((@SegnaturaBandoequalthis IS NULL) OR SEGNATURA_BANDO = @SegnaturaBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodStatoProgettoequalthis IS NULL) OR COD_STATO_PROGETTO = @CodStatoProgettoequalthis) AND 
			((@StatoProgettoequalthis IS NULL) OR STATO_PROGETTO = @StatoProgettoequalthis) AND 
			((@SegnaturaProgettoequalthis IS NULL) OR SEGNATURA_PROGETTO = @SegnaturaProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Impresaequalthis IS NULL) OR IMPRESA = @Impresaequalthis) AND 
			((@CfImpresaequalthis IS NULL) OR CF_IMPRESA = @CfImpresaequalthis) AND 
			((@CuaaImpresaequalthis IS NULL) OR CUAA_IMPRESA = @CuaaImpresaequalthis) AND 
			((@IdIstruttoreProgettoequalthis IS NULL) OR ID_ISTRUTTORE_PROGETTO = @IdIstruttoreProgettoequalthis) AND 
			((@IstruttoreProgettoequalthis IS NULL) OR ISTRUTTORE_PROGETTO = @IstruttoreProgettoequalthis)
		

GO