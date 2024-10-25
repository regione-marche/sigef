CREATE PROCEDURE [dbo].[ZVricercaProgModificabiliFindFindgrande]
(
	@IdBandoequalthis INT, 
	@CodEnteBandoequalthis VARCHAR(255), 
	@EnteBandoequalthis VARCHAR(255), 
	@IdRupequalthis INT, 
	@Rupequalthis VARCHAR(511), 
	@StatoBandoequalthis VARCHAR(255), 
	@IdProgettoequalthis INT, 
	@CodStatoProgettoequalthis VARCHAR(255), 
	@StatoProgettoequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@Impresaequalthis VARCHAR(255), 
	@IdIstruttoreProgettoequalthis INT, 
	@IstruttoreProgettoequalthis VARCHAR(511)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, COD_ENTE_BANDO, ENTE_BANDO, ID_RUP, RUP, CF_RUP, DATA_APERTURA_BANDO, DATA_SCADENZA_BANDO, COD_STATO_BANDO, STATO_BANDO, SEGNATURA_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, SEGNATURA_PROGETTO, ID_IMPRESA, IMPRESA, CF_IMPRESA, CUAA_IMPRESA, ID_ISTRUTTORE_PROGETTO, ISTRUTTORE_PROGETTO FROM VRICERCA_PROG_MODIFICABILI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodEnteBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_BANDO = @CodEnteBandoequalthis)'; set @lensql=@lensql+len(@CodEnteBandoequalthis);end;
	IF (@EnteBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ENTE_BANDO = @EnteBandoequalthis)'; set @lensql=@lensql+len(@EnteBandoequalthis);end;
	IF (@IdRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RUP = @IdRupequalthis)'; set @lensql=@lensql+len(@IdRupequalthis);end;
	IF (@Rupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RUP = @Rupequalthis)'; set @lensql=@lensql+len(@Rupequalthis);end;
	IF (@StatoBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_BANDO = @StatoBandoequalthis)'; set @lensql=@lensql+len(@StatoBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO_PROGETTO = @CodStatoProgettoequalthis)'; set @lensql=@lensql+len(@CodStatoProgettoequalthis);end;
	IF (@StatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_PROGETTO = @StatoProgettoequalthis)'; set @lensql=@lensql+len(@StatoProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Impresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPRESA = @Impresaequalthis)'; set @lensql=@lensql+len(@Impresaequalthis);end;
	IF (@IdIstruttoreProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTRUTTORE_PROGETTO = @IdIstruttoreProgettoequalthis)'; set @lensql=@lensql+len(@IdIstruttoreProgettoequalthis);end;
	IF (@IstruttoreProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTRUTTORE_PROGETTO = @IstruttoreProgettoequalthis)'; set @lensql=@lensql+len(@IstruttoreProgettoequalthis);end;
	set @sql = @sql + 'ORDER BY COD_ENTE_BANDO ASC, DATA_SCADENZA_BANDO ASC, ID_PROGETTO ASC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodEnteBandoequalthis VARCHAR(255), @EnteBandoequalthis VARCHAR(255), @IdRupequalthis INT, @Rupequalthis VARCHAR(511), @StatoBandoequalthis VARCHAR(255), @IdProgettoequalthis INT, @CodStatoProgettoequalthis VARCHAR(255), @StatoProgettoequalthis VARCHAR(255), @IdImpresaequalthis INT, @Impresaequalthis VARCHAR(255), @IdIstruttoreProgettoequalthis INT, @IstruttoreProgettoequalthis VARCHAR(511)',@IdBandoequalthis , @CodEnteBandoequalthis , @EnteBandoequalthis , @IdRupequalthis , @Rupequalthis , @StatoBandoequalthis , @IdProgettoequalthis , @CodStatoProgettoequalthis , @StatoProgettoequalthis , @IdImpresaequalthis , @Impresaequalthis , @IdIstruttoreProgettoequalthis , @IstruttoreProgettoequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, COD_ENTE_BANDO, ENTE_BANDO, ID_RUP, RUP, CF_RUP, DATA_APERTURA_BANDO, DATA_SCADENZA_BANDO, COD_STATO_BANDO, STATO_BANDO, SEGNATURA_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, SEGNATURA_PROGETTO, ID_IMPRESA, IMPRESA, CF_IMPRESA, CUAA_IMPRESA, ID_ISTRUTTORE_PROGETTO, ISTRUTTORE_PROGETTO
		FROM VRICERCA_PROG_MODIFICABILI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodEnteBandoequalthis IS NULL) OR COD_ENTE_BANDO = @CodEnteBandoequalthis) AND 
			((@EnteBandoequalthis IS NULL) OR ENTE_BANDO = @EnteBandoequalthis) AND 
			((@IdRupequalthis IS NULL) OR ID_RUP = @IdRupequalthis) AND 
			((@Rupequalthis IS NULL) OR RUP = @Rupequalthis) AND 
			((@StatoBandoequalthis IS NULL) OR STATO_BANDO = @StatoBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodStatoProgettoequalthis IS NULL) OR COD_STATO_PROGETTO = @CodStatoProgettoequalthis) AND 
			((@StatoProgettoequalthis IS NULL) OR STATO_PROGETTO = @StatoProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Impresaequalthis IS NULL) OR IMPRESA = @Impresaequalthis) AND 
			((@IdIstruttoreProgettoequalthis IS NULL) OR ID_ISTRUTTORE_PROGETTO = @IdIstruttoreProgettoequalthis) AND 
			((@IstruttoreProgettoequalthis IS NULL) OR ISTRUTTORE_PROGETTO = @IstruttoreProgettoequalthis)
		ORDER BY COD_ENTE_BANDO ASC, DATA_SCADENZA_BANDO ASC, ID_PROGETTO ASC

GO