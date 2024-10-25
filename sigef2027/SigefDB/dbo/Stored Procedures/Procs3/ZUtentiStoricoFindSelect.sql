CREATE PROCEDURE [dbo].[ZUtentiStoricoFindSelect]
(
	@Idequalthis INT, 
	@IdUtenteequalthis INT, 
	@IdProfiloequalthis INT, 
	@CodEnteequalthis VARCHAR(255), 
	@Provinciaequalthis VARCHAR(255), 
	@Emailequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_UTENTE, ID_PROFILO, COD_ENTE, PROVINCIA, EMAIL, ATTIVO, DATA, OPERATORE, COD_TIPO_ENTE, ENTE, PROFILO, OPERATORE_NOMINATIVO FROM vUTENTI_STORICO WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROFILO = @IdProfiloequalthis)'; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@Emailequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (EMAIL = @Emailequalthis)'; set @lensql=@lensql+len(@Emailequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdUtenteequalthis INT, @IdProfiloequalthis INT, @CodEnteequalthis VARCHAR(255), @Provinciaequalthis VARCHAR(255), @Emailequalthis VARCHAR(255), @Attivoequalthis BIT, @Dataequalthis DATETIME, @Operatoreequalthis INT',@Idequalthis , @IdUtenteequalthis , @IdProfiloequalthis , @CodEnteequalthis , @Provinciaequalthis , @Emailequalthis , @Attivoequalthis , @Dataequalthis , @Operatoreequalthis ;
	else
		SELECT ID, ID_UTENTE, ID_PROFILO, COD_ENTE, PROVINCIA, EMAIL, ATTIVO, DATA, OPERATORE, COD_TIPO_ENTE, ENTE, PROFILO, OPERATORE_NOMINATIVO
		FROM vUTENTI_STORICO
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@Emailequalthis IS NULL) OR EMAIL = @Emailequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZUtentiStoricoFindSelect]
(
	@Idequalthis INT, 
	@IdUtenteequalthis INT, 
	@IdProfiloequalthis INT, 
	@CodEnteequalthis VARCHAR(10), 
	@Provinciaequalthis CHAR(2), 
	@Attivoequalthis BIT, 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_UTENTE, ID_PROFILO, COD_ENTE, PROVINCIA, ATTIVO, DATA, OPERATORE, COD_TIPO_ENTE, ENTE, PROFILO, OPERATORE_NOMINATIVO FROM vUTENTI_STORICO WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_UTENTE = @IdUtenteequalthis)''; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROFILO = @IdProfiloequalthis)''; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE = @CodEnteequalthis)''; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROVINCIA = @Provinciaequalthis)''; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdUtenteequalthis INT, @IdProfiloequalthis INT, @CodEnteequalthis VARCHAR(10), @Provinciaequalthis CHAR(2), @Attivoequalthis BIT, @Dataequalthis DATETIME, @Operatoreequalthis INT'',@Idequalthis , @IdUtenteequalthis , @IdProfiloequalthis , @CodEnteequalthis , @Provinciaequalthis , @Attivoequalthis , @Dataequalthis , @Operatoreequalthis ;
	else
		SELECT ID, ID_UTENTE, ID_PROFILO, COD_ENTE, PROVINCIA, ATTIVO, DATA, OPERATORE, COD_TIPO_ENTE, ENTE, PROFILO, OPERATORE_NOMINATIVO
		FROM vUTENTI_STORICO
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZUtentiStoricoFindSelect';

