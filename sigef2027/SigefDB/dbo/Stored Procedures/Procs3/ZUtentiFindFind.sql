CREATE PROCEDURE [dbo].[ZUtentiFindFind]
(
	@CfUtenteequalthis VARCHAR(255), 
	@IdPersonaFisicaequalthis INT, 
	@Nominativolikethis VARCHAR(511), 
	@CodEnteequalthis VARCHAR(255), 
	@IdProfiloequalthis INT, 
	@Provinciaequalthis VARCHAR(255), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_UTENTE, ID_PERSONA_FISICA, COD_TIPO_ENTE, ID_STORICO_ULTIMO, ULTIMO_ACCESSO, CF_UTENTE, PROFILO, ENTE, NOMINATIVO, ID_PROFILO, COD_ENTE, PROVINCIA, EMAIL, ATTIVO, DATA, OPERATORE FROM vUTENTI WHERE 1=1';
	IF (@CfUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_UTENTE = @CfUtenteequalthis)'; set @lensql=@lensql+len(@CfUtenteequalthis);end;
	IF (@IdPersonaFisicaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PERSONA_FISICA = @IdPersonaFisicaequalthis)'; set @lensql=@lensql+len(@IdPersonaFisicaequalthis);end;
	IF (@Nominativolikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOMINATIVO LIKE @Nominativolikethis)'; set @lensql=@lensql+len(@Nominativolikethis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROFILO = @IdProfiloequalthis)'; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY ATTIVO DESC, NOMINATIVO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CfUtenteequalthis VARCHAR(255), @IdPersonaFisicaequalthis INT, @Nominativolikethis VARCHAR(511), @CodEnteequalthis VARCHAR(255), @IdProfiloequalthis INT, @Provinciaequalthis VARCHAR(255), @Attivoequalthis BIT',@CfUtenteequalthis , @IdPersonaFisicaequalthis , @Nominativolikethis , @CodEnteequalthis , @IdProfiloequalthis , @Provinciaequalthis , @Attivoequalthis ;
	else
		SELECT ID_UTENTE, ID_PERSONA_FISICA, COD_TIPO_ENTE, ID_STORICO_ULTIMO, ULTIMO_ACCESSO, CF_UTENTE, PROFILO, ENTE, NOMINATIVO, ID_PROFILO, COD_ENTE, PROVINCIA, EMAIL, ATTIVO, DATA, OPERATORE
		FROM vUTENTI
		WHERE 
			((@CfUtenteequalthis IS NULL) OR CF_UTENTE = @CfUtenteequalthis) AND 
			((@IdPersonaFisicaequalthis IS NULL) OR ID_PERSONA_FISICA = @IdPersonaFisicaequalthis) AND 
			((@Nominativolikethis IS NULL) OR NOMINATIVO LIKE @Nominativolikethis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY ATTIVO DESC, NOMINATIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZUtentiFindFind]
(
	@CfUtenteequalthis VARCHAR(16), 
	@IdPersonaFisicaequalthis INT, 
	@Nominativolikethis VARCHAR(511), 
	@CodEnteequalthis VARCHAR(10), 
	@IdProfiloequalthis INT, 
	@Provinciaequalthis CHAR(2), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_UTENTE, ID_PERSONA_FISICA, COD_TIPO_ENTE, ID_STORICO_ULTIMO, ULTIMO_ACCESSO, CF_UTENTE, PROFILO, ENTE, NOMINATIVO, ID_PROFILO, COD_ENTE, PROVINCIA, ATTIVO, DATA, OPERATORE FROM vUTENTI WHERE 1=1'';
	IF (@CfUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_UTENTE = @CfUtenteequalthis)''; set @lensql=@lensql+len(@CfUtenteequalthis);end;
	IF (@IdPersonaFisicaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PERSONA_FISICA = @IdPersonaFisicaequalthis)''; set @lensql=@lensql+len(@IdPersonaFisicaequalthis);end;
	IF (@Nominativolikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NOMINATIVO LIKE @Nominativolikethis)''; set @lensql=@lensql+len(@Nominativolikethis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE = @CodEnteequalthis)''; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROFILO = @IdProfiloequalthis)''; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROVINCIA = @Provinciaequalthis)''; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + ''ORDER BY ATTIVO DESC, NOMINATIVO'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@CfUtenteequalthis VARCHAR(16), @IdPersonaFisicaequalthis INT, @Nominativolikethis VARCHAR(511), @CodEnteequalthis VARCHAR(10), @IdProfiloequalthis INT, @Provinciaequalthis CHAR(2), @Attivoequalthis BIT'',@CfUtenteequalthis , @IdPersonaFisicaequalthis , @Nominativolikethis , @CodEnteequalthis , @IdProfiloequalthis , @Provinciaequalthis , @Attivoequalthis ;
	else
		SELECT ID_UTENTE, ID_PERSONA_FISICA, COD_TIPO_ENTE, ID_STORICO_ULTIMO, ULTIMO_ACCESSO, CF_UTENTE, PROFILO, ENTE, NOMINATIVO, ID_PROFILO, COD_ENTE, PROVINCIA, ATTIVO, DATA, OPERATORE
		FROM vUTENTI
		WHERE 
			((@CfUtenteequalthis IS NULL) OR CF_UTENTE = @CfUtenteequalthis) AND 
			((@IdPersonaFisicaequalthis IS NULL) OR ID_PERSONA_FISICA = @IdPersonaFisicaequalthis) AND 
			((@Nominativolikethis IS NULL) OR NOMINATIVO LIKE @Nominativolikethis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY ATTIVO DESC, NOMINATIVO
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZUtentiFindFind';

