CREATE PROCEDURE [dbo].[ZAttiFindSelect]
(
	@IdAttoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@CodDefinizioneequalthis VARCHAR(255), 
	@CodOrganoIstituzionaleequalthis VARCHAR(255), 
	@Numeroequalthis INT, 
	@Dataequalthis DATETIME, 
	@Descrizioneequalthis VARCHAR(3000), 
	@DataBurequalthis DATETIME, 
	@NumeroBurequalthis INT, 
	@Servizioequalthis VARCHAR(255), 
	@Registroequalthis VARCHAR(255), 
	@AwDocnumberequalthis VARCHAR(255), 
	@AwDocnumberNuovoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ATTO, NUMERO, DATA, DESCRIZIONE, SERVIZIO, REGISTRO, COD_TIPO, COD_DEFINIZIONE, COD_ORGANO_ISTITUZIONALE, DATA_BUR, NUMERO_BUR, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO, DEFINIZIONE_ATTO, TIPO_ATTO, ORGANO_ISTITUZIONALE FROM vATTO WHERE 1=1';
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO = @IdAttoequalthis)'; set @lensql=@lensql+len(@IdAttoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@CodDefinizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_DEFINIZIONE = @CodDefinizioneequalthis)'; set @lensql=@lensql+len(@CodDefinizioneequalthis);end;
	IF (@CodOrganoIstituzionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ORGANO_ISTITUZIONALE = @CodOrganoIstituzionaleequalthis)'; set @lensql=@lensql+len(@CodOrganoIstituzionaleequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@DataBurequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_BUR = @DataBurequalthis)'; set @lensql=@lensql+len(@DataBurequalthis);end;
	IF (@NumeroBurequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_BUR = @NumeroBurequalthis)'; set @lensql=@lensql+len(@NumeroBurequalthis);end;
	IF (@Servizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SERVIZIO = @Servizioequalthis)'; set @lensql=@lensql+len(@Servizioequalthis);end;
	IF (@Registroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REGISTRO = @Registroequalthis)'; set @lensql=@lensql+len(@Registroequalthis);end;
	IF (@AwDocnumberequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AW_DOCNUMBER = @AwDocnumberequalthis)'; set @lensql=@lensql+len(@AwDocnumberequalthis);end;
	IF (@AwDocnumberNuovoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AW_DOCNUMBER_NUOVO = @AwDocnumberNuovoequalthis)'; set @lensql=@lensql+len(@AwDocnumberNuovoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAttoequalthis INT, @CodTipoequalthis VARCHAR(255), @CodDefinizioneequalthis VARCHAR(255), @CodOrganoIstituzionaleequalthis VARCHAR(255), @Numeroequalthis INT, @Dataequalthis DATETIME, @Descrizioneequalthis VARCHAR(3000), @DataBurequalthis DATETIME, @NumeroBurequalthis INT, @Servizioequalthis VARCHAR(255), @Registroequalthis VARCHAR(255), @AwDocnumberequalthis VARCHAR(255), @AwDocnumberNuovoequalthis INT',@IdAttoequalthis , @CodTipoequalthis , @CodDefinizioneequalthis , @CodOrganoIstituzionaleequalthis , @Numeroequalthis , @Dataequalthis , @Descrizioneequalthis , @DataBurequalthis , @NumeroBurequalthis , @Servizioequalthis , @Registroequalthis , @AwDocnumberequalthis , @AwDocnumberNuovoequalthis ;
	else
		SELECT ID_ATTO, NUMERO, DATA, DESCRIZIONE, SERVIZIO, REGISTRO, COD_TIPO, COD_DEFINIZIONE, COD_ORGANO_ISTITUZIONALE, DATA_BUR, NUMERO_BUR, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO, DEFINIZIONE_ATTO, TIPO_ATTO, ORGANO_ISTITUZIONALE
		FROM vATTO
		WHERE 
			((@IdAttoequalthis IS NULL) OR ID_ATTO = @IdAttoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@CodDefinizioneequalthis IS NULL) OR COD_DEFINIZIONE = @CodDefinizioneequalthis) AND 
			((@CodOrganoIstituzionaleequalthis IS NULL) OR COD_ORGANO_ISTITUZIONALE = @CodOrganoIstituzionaleequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@DataBurequalthis IS NULL) OR DATA_BUR = @DataBurequalthis) AND 
			((@NumeroBurequalthis IS NULL) OR NUMERO_BUR = @NumeroBurequalthis) AND 
			((@Servizioequalthis IS NULL) OR SERVIZIO = @Servizioequalthis) AND 
			((@Registroequalthis IS NULL) OR REGISTRO = @Registroequalthis) AND 
			((@AwDocnumberequalthis IS NULL) OR AW_DOCNUMBER = @AwDocnumberequalthis) AND 
			((@AwDocnumberNuovoequalthis IS NULL) OR AW_DOCNUMBER_NUOVO = @AwDocnumberNuovoequalthis)
