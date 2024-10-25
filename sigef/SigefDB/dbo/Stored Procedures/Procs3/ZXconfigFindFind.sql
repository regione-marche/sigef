CREATE PROCEDURE [dbo].[ZXconfigFindFind]
(
	@TipoConfigurazioneequalthis VARCHAR(255), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT TIPO_CONFIGURAZIONE, LOGIN, PWD, DOMINIO, IP_INTERNO, DEFAULT_DIRECTORY, ATTIVO, NOME, COGNOME, RUOLO, CODICE_UO, WS_BINDING, DATA FROM XCONFIG WHERE 1=1';
	IF (@TipoConfigurazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_CONFIGURAZIONE = @TipoConfigurazioneequalthis)'; set @lensql=@lensql+len(@TipoConfigurazioneequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@TipoConfigurazioneequalthis VARCHAR(255), @Attivoequalthis BIT',@TipoConfigurazioneequalthis , @Attivoequalthis ;
	else
		SELECT TIPO_CONFIGURAZIONE, LOGIN, PWD, DOMINIO, IP_INTERNO, DEFAULT_DIRECTORY, ATTIVO, NOME, COGNOME, RUOLO, CODICE_UO, WS_BINDING, DATA
		FROM XCONFIG
		WHERE 
			((@TipoConfigurazioneequalthis IS NULL) OR TIPO_CONFIGURAZIONE = @TipoConfigurazioneequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZXconfigFindFind]
(
	@TipoConfigurazioneequalthis VARCHAR(50), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT TIPO_CONFIGURAZIONE, LOGIN, PWD, DOMINIO, IP_INTERNO, DEFAULT_DIRECTORY, ATTIVO, NOME, COGNOME, RUOLO, CODICE_UO FROM XCONFIG WHERE 1=1'';
	IF (@TipoConfigurazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TIPO_CONFIGURAZIONE = @TipoConfigurazioneequalthis)''; set @lensql=@lensql+len(@TipoConfigurazioneequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@TipoConfigurazioneequalthis VARCHAR(50), @Attivoequalthis BIT'',@TipoConfigurazioneequalthis , @Attivoequalthis ;
	else
		SELECT TIPO_CONFIGURAZIONE, LOGIN, PWD, DOMINIO, IP_INTERNO, DEFAULT_DIRECTORY, ATTIVO, NOME, COGNOME, RUOLO, CODICE_UO
		FROM XCONFIG
		WHERE 
			((@TipoConfigurazioneequalthis IS NULL) OR TIPO_CONFIGURAZIONE = @TipoConfigurazioneequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZXconfigFindFind';

