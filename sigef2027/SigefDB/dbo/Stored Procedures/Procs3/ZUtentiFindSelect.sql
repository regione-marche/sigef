CREATE PROCEDURE [dbo].[ZUtentiFindSelect]
(
	@IdUtenteequalthis INT, 
	@IdPersonaFisicaequalthis INT, 
	@IdStoricoUltimoequalthis INT, 
	@UltimoAccessoequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_UTENTE, ID_PERSONA_FISICA, COD_TIPO_ENTE, ID_STORICO_ULTIMO, ULTIMO_ACCESSO, CF_UTENTE, PROFILO, ENTE, NOMINATIVO, ID_PROFILO, COD_ENTE, PROVINCIA, EMAIL, ATTIVO, DATA, OPERATORE FROM vUTENTI WHERE 1=1';
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@IdPersonaFisicaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PERSONA_FISICA = @IdPersonaFisicaequalthis)'; set @lensql=@lensql+len(@IdPersonaFisicaequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)'; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	IF (@UltimoAccessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ULTIMO_ACCESSO = @UltimoAccessoequalthis)'; set @lensql=@lensql+len(@UltimoAccessoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdUtenteequalthis INT, @IdPersonaFisicaequalthis INT, @IdStoricoUltimoequalthis INT, @UltimoAccessoequalthis DATETIME',@IdUtenteequalthis , @IdPersonaFisicaequalthis , @IdStoricoUltimoequalthis , @UltimoAccessoequalthis ;
	else
		SELECT ID_UTENTE, ID_PERSONA_FISICA, COD_TIPO_ENTE, ID_STORICO_ULTIMO, ULTIMO_ACCESSO, CF_UTENTE, PROFILO, ENTE, NOMINATIVO, ID_PROFILO, COD_ENTE, PROVINCIA, EMAIL, ATTIVO, DATA, OPERATORE
		FROM vUTENTI
		WHERE 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@IdPersonaFisicaequalthis IS NULL) OR ID_PERSONA_FISICA = @IdPersonaFisicaequalthis) AND 
			((@IdStoricoUltimoequalthis IS NULL) OR ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis) AND 
			((@UltimoAccessoequalthis IS NULL) OR ULTIMO_ACCESSO = @UltimoAccessoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZUtentiFindSelect]
(
	@IdUtenteequalthis INT, 
	@IdPersonaFisicaequalthis INT, 
	@IdStoricoUltimoequalthis INT, 
	@UltimoAccessoequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_UTENTE, ID_PERSONA_FISICA, COD_TIPO_ENTE, ID_STORICO_ULTIMO, ULTIMO_ACCESSO, CF_UTENTE, PROFILO, ENTE, NOMINATIVO, ID_PROFILO, COD_ENTE, PROVINCIA, ATTIVO, DATA, OPERATORE FROM vUTENTI WHERE 1=1'';
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_UTENTE = @IdUtenteequalthis)''; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@IdPersonaFisicaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PERSONA_FISICA = @IdPersonaFisicaequalthis)''; set @lensql=@lensql+len(@IdPersonaFisicaequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)''; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	IF (@UltimoAccessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ULTIMO_ACCESSO = @UltimoAccessoequalthis)''; set @lensql=@lensql+len(@UltimoAccessoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdUtenteequalthis INT, @IdPersonaFisicaequalthis INT, @IdStoricoUltimoequalthis INT, @UltimoAccessoequalthis DATETIME'',@IdUtenteequalthis , @IdPersonaFisicaequalthis , @IdStoricoUltimoequalthis , @UltimoAccessoequalthis ;
	else
		SELECT ID_UTENTE, ID_PERSONA_FISICA, COD_TIPO_ENTE, ID_STORICO_ULTIMO, ULTIMO_ACCESSO, CF_UTENTE, PROFILO, ENTE, NOMINATIVO, ID_PROFILO, COD_ENTE, PROVINCIA, ATTIVO, DATA, OPERATORE
		FROM vUTENTI
		WHERE 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@IdPersonaFisicaequalthis IS NULL) OR ID_PERSONA_FISICA = @IdPersonaFisicaequalthis) AND 
			((@IdStoricoUltimoequalthis IS NULL) OR ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis) AND 
			((@UltimoAccessoequalthis IS NULL) OR ULTIMO_ACCESSO = @UltimoAccessoequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZUtentiFindSelect';

