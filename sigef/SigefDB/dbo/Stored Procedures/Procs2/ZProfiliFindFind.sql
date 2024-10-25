CREATE PROCEDURE [dbo].[ZProfiliFindFind]
(
	@IdProfiloequalthis INT, 
	@CodTipoEnteequalthis VARCHAR(10), 
	@Ordineequalthis INT, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, ABILITA_INSERIMENTO_UTENTI, ATTIVO FROM PROFILI WHERE 1=1';
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROFILO = @IdProfiloequalthis)'; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@CodTipoEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_ENTE = @CodTipoEnteequalthis)'; set @lensql=@lensql+len(@CodTipoEnteequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY COD_TIPO_ENTE,ORDINE,DESCRIZIONE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProfiloequalthis INT, @CodTipoEnteequalthis VARCHAR(10), @Ordineequalthis INT, @Attivoequalthis BIT',@IdProfiloequalthis , @CodTipoEnteequalthis , @Ordineequalthis , @Attivoequalthis ;
	else
		SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, ABILITA_INSERIMENTO_UTENTI, ATTIVO
		FROM PROFILI
		WHERE 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@CodTipoEnteequalthis IS NULL) OR COD_TIPO_ENTE = @CodTipoEnteequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY COD_TIPO_ENTE,ORDINE,DESCRIZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProfiliFindFind]
(
	@IdProfiloequalthis INT, 
	@CodTipoEnteequalthis VARCHAR(10), 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, ABILITA_INSERIMENTO_UTENTI FROM PROFILI WHERE 1=1'';
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROFILO = @IdProfiloequalthis)''; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@CodTipoEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_ENTE = @CodTipoEnteequalthis)''; set @lensql=@lensql+len(@CodTipoEnteequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @sql = @sql + ''ORDER BY COD_TIPO_ENTE,ORDINE,DESCRIZIONE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProfiloequalthis INT, @CodTipoEnteequalthis VARCHAR(10), @Ordineequalthis INT'',@IdProfiloequalthis , @CodTipoEnteequalthis , @Ordineequalthis ;
	else
		SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, ABILITA_INSERIMENTO_UTENTI
		FROM PROFILI
		WHERE 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@CodTipoEnteequalthis IS NULL) OR COD_TIPO_ENTE = @CodTipoEnteequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		ORDER BY COD_TIPO_ENTE,ORDINE,DESCRIZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProfiliFindFind';

