CREATE PROCEDURE [dbo].[ZVcruscottoDomandeRappresentanteLegaleFindSelect]
(
	@IdBandoequalthis INT, 
	@DescrizioneBandoequalthis VARCHAR(2000), 
	@DataScadenzaBandoequalthis DATETIME, 
	@CodEnteBandoequalthis VARCHAR(255), 
	@IdProgrammazioneBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodStatoProgettoequalthis VARCHAR(255), 
	@StatoProgettoequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@Impresaequalthis VARCHAR(255), 
	@IdUtenteRappresentanteLegaleequalthis INT, 
	@RappresentanteLegaleequalthis VARCHAR(511)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_ENTE_BANDO, ID_PROGRAMMAZIONE_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, ID_IMPRESA, IMPRESA, ID_UTENTE_RAPPRESENTANTE_LEGALE, RAPPRESENTANTE_LEGALE FROM VCRUSCOTTO_DOMANDE_RAPPRESENTANTE_LEGALE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@DescrizioneBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_BANDO = @DescrizioneBandoequalthis)'; set @lensql=@lensql+len(@DescrizioneBandoequalthis);end;
	IF (@DataScadenzaBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA_BANDO = @DataScadenzaBandoequalthis)'; set @lensql=@lensql+len(@DataScadenzaBandoequalthis);end;
	IF (@CodEnteBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_BANDO = @CodEnteBandoequalthis)'; set @lensql=@lensql+len(@CodEnteBandoequalthis);end;
	IF (@IdProgrammazioneBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE_BANDO = @IdProgrammazioneBandoequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO_PROGETTO = @CodStatoProgettoequalthis)'; set @lensql=@lensql+len(@CodStatoProgettoequalthis);end;
	IF (@StatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_PROGETTO = @StatoProgettoequalthis)'; set @lensql=@lensql+len(@StatoProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Impresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPRESA = @Impresaequalthis)'; set @lensql=@lensql+len(@Impresaequalthis);end;
	IF (@IdUtenteRappresentanteLegaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_RAPPRESENTANTE_LEGALE = @IdUtenteRappresentanteLegaleequalthis)'; set @lensql=@lensql+len(@IdUtenteRappresentanteLegaleequalthis);end;
	IF (@RappresentanteLegaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAPPRESENTANTE_LEGALE = @RappresentanteLegaleequalthis)'; set @lensql=@lensql+len(@RappresentanteLegaleequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @DescrizioneBandoequalthis VARCHAR(2000), @DataScadenzaBandoequalthis DATETIME, @CodEnteBandoequalthis VARCHAR(255), @IdProgrammazioneBandoequalthis INT, @IdProgettoequalthis INT, @CodStatoProgettoequalthis VARCHAR(255), @StatoProgettoequalthis VARCHAR(255), @IdImpresaequalthis INT, @Impresaequalthis VARCHAR(255), @IdUtenteRappresentanteLegaleequalthis INT, @RappresentanteLegaleequalthis VARCHAR(511)',@IdBandoequalthis , @DescrizioneBandoequalthis , @DataScadenzaBandoequalthis , @CodEnteBandoequalthis , @IdProgrammazioneBandoequalthis , @IdProgettoequalthis , @CodStatoProgettoequalthis , @StatoProgettoequalthis , @IdImpresaequalthis , @Impresaequalthis , @IdUtenteRappresentanteLegaleequalthis , @RappresentanteLegaleequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_ENTE_BANDO, ID_PROGRAMMAZIONE_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, ID_IMPRESA, IMPRESA, ID_UTENTE_RAPPRESENTANTE_LEGALE, RAPPRESENTANTE_LEGALE
		FROM VCRUSCOTTO_DOMANDE_RAPPRESENTANTE_LEGALE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@DescrizioneBandoequalthis IS NULL) OR DESCRIZIONE_BANDO = @DescrizioneBandoequalthis) AND 
			((@DataScadenzaBandoequalthis IS NULL) OR DATA_SCADENZA_BANDO = @DataScadenzaBandoequalthis) AND 
			((@CodEnteBandoequalthis IS NULL) OR COD_ENTE_BANDO = @CodEnteBandoequalthis) AND 
			((@IdProgrammazioneBandoequalthis IS NULL) OR ID_PROGRAMMAZIONE_BANDO = @IdProgrammazioneBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodStatoProgettoequalthis IS NULL) OR COD_STATO_PROGETTO = @CodStatoProgettoequalthis) AND 
			((@StatoProgettoequalthis IS NULL) OR STATO_PROGETTO = @StatoProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Impresaequalthis IS NULL) OR IMPRESA = @Impresaequalthis) AND 
			((@IdUtenteRappresentanteLegaleequalthis IS NULL) OR ID_UTENTE_RAPPRESENTANTE_LEGALE = @IdUtenteRappresentanteLegaleequalthis) AND 
			((@RappresentanteLegaleequalthis IS NULL) OR RAPPRESENTANTE_LEGALE = @RappresentanteLegaleequalthis)
		

GO