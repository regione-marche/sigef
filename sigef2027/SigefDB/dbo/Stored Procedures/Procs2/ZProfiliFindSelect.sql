CREATE PROCEDURE [dbo].[ZProfiliFindSelect]
(
	@IdProfiloequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@CodTipoEnteequalthis VARCHAR(10), 
	@Ordineequalthis INT, 
	@AbilitaInserimentoUtentiequalthis BIT, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, ABILITA_INSERIMENTO_UTENTI, ATTIVO FROM PROFILI WHERE 1=1';
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROFILO = @IdProfiloequalthis)'; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodTipoEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_ENTE = @CodTipoEnteequalthis)'; set @lensql=@lensql+len(@CodTipoEnteequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@AbilitaInserimentoUtentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ABILITA_INSERIMENTO_UTENTI = @AbilitaInserimentoUtentiequalthis)'; set @lensql=@lensql+len(@AbilitaInserimentoUtentiequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProfiloequalthis INT, @Descrizioneequalthis VARCHAR(255), @CodTipoEnteequalthis VARCHAR(10), @Ordineequalthis INT, @AbilitaInserimentoUtentiequalthis BIT, @Attivoequalthis BIT',@IdProfiloequalthis , @Descrizioneequalthis , @CodTipoEnteequalthis , @Ordineequalthis , @AbilitaInserimentoUtentiequalthis , @Attivoequalthis ;
	else
		SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, ABILITA_INSERIMENTO_UTENTI, ATTIVO
		FROM PROFILI
		WHERE 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodTipoEnteequalthis IS NULL) OR COD_TIPO_ENTE = @CodTipoEnteequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@AbilitaInserimentoUtentiequalthis IS NULL) OR ABILITA_INSERIMENTO_UTENTI = @AbilitaInserimentoUtentiequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProfiliFindSelect]
(
	@IdProfiloequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@CodTipoEnteequalthis VARCHAR(10), 
	@Ordineequalthis INT, 
	@AbilitaInserimentoUtentiequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, ABILITA_INSERIMENTO_UTENTI FROM PROFILI WHERE 1=1'';
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROFILO = @IdProfiloequalthis)''; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodTipoEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_ENTE = @CodTipoEnteequalthis)''; set @lensql=@lensql+len(@CodTipoEnteequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@AbilitaInserimentoUtentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ABILITA_INSERIMENTO_UTENTI = @AbilitaInserimentoUtentiequalthis)''; set @lensql=@lensql+len(@AbilitaInserimentoUtentiequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProfiloequalthis INT, @Descrizioneequalthis VARCHAR(255), @CodTipoEnteequalthis VARCHAR(10), @Ordineequalthis INT, @AbilitaInserimentoUtentiequalthis BIT'',@IdProfiloequalthis , @Descrizioneequalthis , @CodTipoEnteequalthis , @Ordineequalthis , @AbilitaInserimentoUtentiequalthis ;
	else
		SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, ABILITA_INSERIMENTO_UTENTI
		FROM PROFILI
		WHERE 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodTipoEnteequalthis IS NULL) OR COD_TIPO_ENTE = @CodTipoEnteequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@AbilitaInserimentoUtentiequalthis IS NULL) OR ABILITA_INSERIMENTO_UTENTI = @AbilitaInserimentoUtentiequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProfiliFindSelect';

