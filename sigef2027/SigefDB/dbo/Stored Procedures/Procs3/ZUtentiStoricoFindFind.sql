CREATE PROCEDURE [dbo].[ZUtentiStoricoFindFind]
(
	@IdUtenteequalthis INT, 
	@CodEnteequalthis VARCHAR(255), 
	@IdProfiloequalthis INT, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_UTENTE, ID_PROFILO, COD_ENTE, PROVINCIA, EMAIL, ATTIVO, DATA, OPERATORE, COD_TIPO_ENTE, ENTE, PROFILO, OPERATORE_NOMINATIVO FROM vUTENTI_STORICO WHERE 1=1';
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROFILO = @IdProfiloequalthis)'; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY DATA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdUtenteequalthis INT, @CodEnteequalthis VARCHAR(255), @IdProfiloequalthis INT, @Attivoequalthis BIT',@IdUtenteequalthis , @CodEnteequalthis , @IdProfiloequalthis , @Attivoequalthis ;
	else
		SELECT ID, ID_UTENTE, ID_PROFILO, COD_ENTE, PROVINCIA, EMAIL, ATTIVO, DATA, OPERATORE, COD_TIPO_ENTE, ENTE, PROFILO, OPERATORE_NOMINATIVO
		FROM vUTENTI_STORICO
		WHERE 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY DATA DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZUtentiStoricoFindFind]
(
	@IdUtenteequalthis INT, 
	@CodEnteequalthis VARCHAR(10), 
	@IdProfiloequalthis INT, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_UTENTE, ID_PROFILO, COD_ENTE, PROVINCIA, ATTIVO, DATA, OPERATORE, COD_TIPO_ENTE, ENTE, PROFILO, OPERATORE_NOMINATIVO FROM vUTENTI_STORICO WHERE 1=1'';
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_UTENTE = @IdUtenteequalthis)''; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE = @CodEnteequalthis)''; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROFILO = @IdProfiloequalthis)''; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + ''ORDER BY DATA DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdUtenteequalthis INT, @CodEnteequalthis VARCHAR(10), @IdProfiloequalthis INT, @Attivoequalthis BIT'',@IdUtenteequalthis , @CodEnteequalthis , @IdProfiloequalthis , @Attivoequalthis ;
	else
		SELECT ID, ID_UTENTE, ID_PROFILO, COD_ENTE, PROVINCIA, ATTIVO, DATA, OPERATORE, COD_TIPO_ENTE, ENTE, PROFILO, OPERATORE_NOMINATIVO
		FROM vUTENTI_STORICO
		WHERE 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY DATA DESC
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZUtentiStoricoFindFind';

