CREATE PROCEDURE [dbo].[ZAttiFindFind]
(
	@Numeroequalthis INT, 
	@Dataequalthis DATETIME, 
	@CodDefinizioneequalthis VARCHAR(255), 
	@Registroequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ATTO, NUMERO, DATA, DESCRIZIONE, SERVIZIO, REGISTRO, COD_TIPO, COD_DEFINIZIONE, COD_ORGANO_ISTITUZIONALE, DATA_BUR, NUMERO_BUR, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO, DEFINIZIONE_ATTO, TIPO_ATTO, ORGANO_ISTITUZIONALE FROM vATTO WHERE 1=1';
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@CodDefinizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_DEFINIZIONE = @CodDefinizioneequalthis)'; set @lensql=@lensql+len(@CodDefinizioneequalthis);end;
	IF (@Registroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REGISTRO = @Registroequalthis)'; set @lensql=@lensql+len(@Registroequalthis);end;
	set @sql = @sql + 'ORDER BY DATA DESC,NUMERO DESC,REGISTRO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Numeroequalthis INT, @Dataequalthis DATETIME, @CodDefinizioneequalthis VARCHAR(255), @Registroequalthis VARCHAR(255)',@Numeroequalthis , @Dataequalthis , @CodDefinizioneequalthis , @Registroequalthis ;
	else
		SELECT ID_ATTO, NUMERO, DATA, DESCRIZIONE, SERVIZIO, REGISTRO, COD_TIPO, COD_DEFINIZIONE, COD_ORGANO_ISTITUZIONALE, DATA_BUR, NUMERO_BUR, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO, DEFINIZIONE_ATTO, TIPO_ATTO, ORGANO_ISTITUZIONALE
		FROM vATTO
		WHERE 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@CodDefinizioneequalthis IS NULL) OR COD_DEFINIZIONE = @CodDefinizioneequalthis) AND 
			((@Registroequalthis IS NULL) OR REGISTRO = @Registroequalthis)
		ORDER BY DATA DESC,NUMERO DESC,REGISTRO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAttiFindFind]
(
	@IdAttoequalthis INT, 
	@NumeroAttoequalthis VARCHAR(30), 
	@DataAttoequalthis DATETIME, 
	@DataPubBurequalthis DATETIME, 
	@IdTipoAttoequalthis INT, 
	@IdDefinizioneAttoequalthis INT, 
	@IdOrganoIstituzionaleequalthis INT, 
	@NumeroBollequalthis INT, 
	@Registroequalthis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ATTO, NUMERO_ATTO, DATA_ATTO, ID_TIPO_ATTO, ID_DEFINIZIONE_ATTO, ID_ORGANO_ISTITUZIONALE, DESCRIZIONE, AW_DOCNUMBER, DATA_PUB_BUR, NUMERO_BOLL, SERVIZIO, TIPO_ATTO, DEFINIZIONE_ATTO, ORGANO_ISTITUZIONALE, REGISTRO FROM vATTO WHERE 1=1'';
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ATTO = @IdAttoequalthis)''; set @lensql=@lensql+len(@IdAttoequalthis);end;
	IF (@NumeroAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO_ATTO = @NumeroAttoequalthis)''; set @lensql=@lensql+len(@NumeroAttoequalthis);end;
	IF (@DataAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_ATTO = @DataAttoequalthis)''; set @lensql=@lensql+len(@DataAttoequalthis);end;
	IF (@DataPubBurequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_PUB_BUR = @DataPubBurequalthis)''; set @lensql=@lensql+len(@DataPubBurequalthis);end;
	IF (@IdTipoAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_TIPO_ATTO = @IdTipoAttoequalthis)''; set @lensql=@lensql+len(@IdTipoAttoequalthis);end;
	IF (@IdDefinizioneAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DEFINIZIONE_ATTO = @IdDefinizioneAttoequalthis)''; set @lensql=@lensql+len(@IdDefinizioneAttoequalthis);end;
	IF (@IdOrganoIstituzionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ORGANO_ISTITUZIONALE = @IdOrganoIstituzionaleequalthis)''; set @lensql=@lensql+len(@IdOrganoIstituzionaleequalthis);end;
	IF (@NumeroBollequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO_BOLL = @NumeroBollequalthis)''; set @lensql=@lensql+len(@NumeroBollequalthis);end;
	IF (@Registroequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (REGISTRO = @Registroequalthis)''; set @lensql=@lensql+len(@Registroequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdAttoequalthis INT, @NumeroAttoequalthis VARCHAR(30), @DataAttoequalthis DATETIME, @DataPubBurequalthis DATETIME, @IdTipoAttoequalthis INT, @IdDefinizioneAttoequalthis INT, @IdOrganoIstituzionaleequalthis INT, @NumeroBollequalthis INT, @Registroequalthis VARCHAR(10)'',@IdAttoequalthis , @NumeroAttoequalthis , @DataAttoequalthis , @DataPubBurequalthis , @IdTipoAttoequalthis , @IdDefinizioneAttoequalthis , @IdOrganoIstituzionaleequalthis , @NumeroBollequalthis , @Registroequalthis ;
	else
		SELECT ID_ATTO, NUMERO_ATTO, DATA_ATTO, ID_TIPO_ATTO, ID_DEFINIZIONE_ATTO, ID_ORGANO_ISTITUZIONALE, DESCRIZIONE, AW_DOCNUMBER, DATA_PUB_BUR, NUMERO_BOLL, SERVIZIO, TIPO_ATTO, DEFINIZIONE_ATTO, ORGANO_ISTITUZIONALE, REGISTRO
		FROM vATTO
		WHERE 
			((@IdAttoequalthis IS NULL) OR ID_ATTO = @IdAttoequalthis) AND 
			((@NumeroAttoequalthis IS NULL) OR NUMERO_ATTO = @NumeroAttoequalthis) AND 
			((@DataAttoequalthis IS NULL) OR DATA_ATTO = @DataAttoequalthis) AND 
			((@DataPubBurequalthis IS NULL) OR DATA_PUB_BUR = @DataPubBurequalthis) AND 
			((@IdTipoAttoequalthis IS NULL) OR ID_TIPO_ATTO = @IdTipoAttoequalthis) AND 
			((@IdDefinizioneAttoequalthis IS NULL) OR ID_DEFINIZIONE_ATTO = @IdDefinizioneAttoequalthis) AND 
			((@IdOrganoIstituzionaleequalthis IS NULL) OR ID_ORGANO_ISTITUZIONALE = @IdOrganoIstituzionaleequalthis) AND 
			((@NumeroBollequalthis IS NULL) OR NUMERO_BOLL = @NumeroBollequalthis) AND 
			((@Registroequalthis IS NULL) OR REGISTRO = @Registroequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAttiFindFind';

