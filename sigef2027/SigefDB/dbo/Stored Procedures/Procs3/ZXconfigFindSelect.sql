CREATE PROCEDURE [dbo].[ZXconfigFindSelect]
(
	@TipoConfigurazioneequalthis VARCHAR(255), 
	@Loginequalthis VARCHAR(255), 
	@Pwdequalthis VARCHAR(255), 
	@Dominioequalthis VARCHAR(255), 
	@IpInternoequalthis VARCHAR(255), 
	@DefaultDirectoryequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@Nomeequalthis VARCHAR(255), 
	@Cognomeequalthis VARCHAR(255), 
	@Ruoloequalthis VARCHAR(255), 
	@CodiceUoequalthis VARCHAR(255), 
	@WsBindingequalthis VARCHAR(255), 
	@Dataequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT TIPO_CONFIGURAZIONE, LOGIN, PWD, DOMINIO, IP_INTERNO, DEFAULT_DIRECTORY, ATTIVO, NOME, COGNOME, RUOLO, CODICE_UO, WS_BINDING, DATA FROM XCONFIG WHERE 1=1';
	IF (@TipoConfigurazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_CONFIGURAZIONE = @TipoConfigurazioneequalthis)'; set @lensql=@lensql+len(@TipoConfigurazioneequalthis);end;
	IF (@Loginequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LOGIN = @Loginequalthis)'; set @lensql=@lensql+len(@Loginequalthis);end;
	IF (@Pwdequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PWD = @Pwdequalthis)'; set @lensql=@lensql+len(@Pwdequalthis);end;
	IF (@Dominioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DOMINIO = @Dominioequalthis)'; set @lensql=@lensql+len(@Dominioequalthis);end;
	IF (@IpInternoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IP_INTERNO = @IpInternoequalthis)'; set @lensql=@lensql+len(@IpInternoequalthis);end;
	IF (@DefaultDirectoryequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DEFAULT_DIRECTORY = @DefaultDirectoryequalthis)'; set @lensql=@lensql+len(@DefaultDirectoryequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Nomeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOME = @Nomeequalthis)'; set @lensql=@lensql+len(@Nomeequalthis);end;
	IF (@Cognomeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COGNOME = @Cognomeequalthis)'; set @lensql=@lensql+len(@Cognomeequalthis);end;
	IF (@Ruoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RUOLO = @Ruoloequalthis)'; set @lensql=@lensql+len(@Ruoloequalthis);end;
	IF (@CodiceUoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_UO = @CodiceUoequalthis)'; set @lensql=@lensql+len(@CodiceUoequalthis);end;
	IF (@WsBindingequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (WS_BINDING = @WsBindingequalthis)'; set @lensql=@lensql+len(@WsBindingequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@TipoConfigurazioneequalthis VARCHAR(255), @Loginequalthis VARCHAR(255), @Pwdequalthis VARCHAR(255), @Dominioequalthis VARCHAR(255), @IpInternoequalthis VARCHAR(255), @DefaultDirectoryequalthis VARCHAR(255), @Attivoequalthis BIT, @Nomeequalthis VARCHAR(255), @Cognomeequalthis VARCHAR(255), @Ruoloequalthis VARCHAR(255), @CodiceUoequalthis VARCHAR(255), @WsBindingequalthis VARCHAR(255), @Dataequalthis DATETIME',@TipoConfigurazioneequalthis , @Loginequalthis , @Pwdequalthis , @Dominioequalthis , @IpInternoequalthis , @DefaultDirectoryequalthis , @Attivoequalthis , @Nomeequalthis , @Cognomeequalthis , @Ruoloequalthis , @CodiceUoequalthis , @WsBindingequalthis , @Dataequalthis ;
	else
		SELECT TIPO_CONFIGURAZIONE, LOGIN, PWD, DOMINIO, IP_INTERNO, DEFAULT_DIRECTORY, ATTIVO, NOME, COGNOME, RUOLO, CODICE_UO, WS_BINDING, DATA
		FROM XCONFIG
		WHERE 
			((@TipoConfigurazioneequalthis IS NULL) OR TIPO_CONFIGURAZIONE = @TipoConfigurazioneequalthis) AND 
			((@Loginequalthis IS NULL) OR LOGIN = @Loginequalthis) AND 
			((@Pwdequalthis IS NULL) OR PWD = @Pwdequalthis) AND 
			((@Dominioequalthis IS NULL) OR DOMINIO = @Dominioequalthis) AND 
			((@IpInternoequalthis IS NULL) OR IP_INTERNO = @IpInternoequalthis) AND 
			((@DefaultDirectoryequalthis IS NULL) OR DEFAULT_DIRECTORY = @DefaultDirectoryequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Nomeequalthis IS NULL) OR NOME = @Nomeequalthis) AND 
			((@Cognomeequalthis IS NULL) OR COGNOME = @Cognomeequalthis) AND 
			((@Ruoloequalthis IS NULL) OR RUOLO = @Ruoloequalthis) AND 
			((@CodiceUoequalthis IS NULL) OR CODICE_UO = @CodiceUoequalthis) AND 
			((@WsBindingequalthis IS NULL) OR WS_BINDING = @WsBindingequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis)
