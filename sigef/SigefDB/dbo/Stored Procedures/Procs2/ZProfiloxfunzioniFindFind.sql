CREATE PROCEDURE [dbo].[ZProfiloxfunzioniFindFind]
(
	@IdProfiloequalthis INT, 
	@CodFunzioneequalthis INT, 
	@FlagMenuequalthis BIT, 
	@DescMenuequalthis VARCHAR(50), 
	@Livelloequalthis INT, 
	@Padreequalthis INT, 
	@Ordineequalthis INT, 
	@CodTipoEnteequalthis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, COD_FUNZIONE, MODIFICA, FUNZIONALITA, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE_FUNZIONALITA, ABILITA_INSERIMENTO_UTENTI FROM vPROFILO_X_FUNZIONI WHERE 1=1';
	IF (@IdProfiloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROFILO = @IdProfiloequalthis)'; set @lensql=@lensql+len(@IdProfiloequalthis);end;
	IF (@CodFunzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FUNZIONE = @CodFunzioneequalthis)'; set @lensql=@lensql+len(@CodFunzioneequalthis);end;
	IF (@FlagMenuequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_MENU = @FlagMenuequalthis)'; set @lensql=@lensql+len(@FlagMenuequalthis);end;
	IF (@DescMenuequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESC_MENU = @DescMenuequalthis)'; set @lensql=@lensql+len(@DescMenuequalthis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LIVELLO = @Livelloequalthis)'; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@Padreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PADRE = @Padreequalthis)'; set @lensql=@lensql+len(@Padreequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@CodTipoEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_ENTE = @CodTipoEnteequalthis)'; set @lensql=@lensql+len(@CodTipoEnteequalthis);end;
	set	@sql = @sql + ' order by LIVELLO,ORDINE_FUNZIONALITA,DESCRIZIONE'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProfiloequalthis INT, @CodFunzioneequalthis INT, @FlagMenuequalthis BIT, @DescMenuequalthis VARCHAR(50), @Livelloequalthis INT, @Padreequalthis INT, @Ordineequalthis INT, @CodTipoEnteequalthis VARCHAR(10)',@IdProfiloequalthis , @CodFunzioneequalthis , @FlagMenuequalthis , @DescMenuequalthis , @Livelloequalthis , @Padreequalthis , @Ordineequalthis , @CodTipoEnteequalthis ;
	else
		SELECT ID_PROFILO, DESCRIZIONE, COD_TIPO_ENTE, ORDINE, COD_FUNZIONE, MODIFICA, FUNZIONALITA, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE_FUNZIONALITA, ABILITA_INSERIMENTO_UTENTI
		FROM vPROFILO_X_FUNZIONI
		WHERE 
			((@IdProfiloequalthis IS NULL) OR ID_PROFILO = @IdProfiloequalthis) AND 
			((@CodFunzioneequalthis IS NULL) OR COD_FUNZIONE = @CodFunzioneequalthis) AND 
			((@FlagMenuequalthis IS NULL) OR FLAG_MENU = @FlagMenuequalthis) AND 
			((@DescMenuequalthis IS NULL) OR DESC_MENU = @DescMenuequalthis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@Padreequalthis IS NULL) OR PADRE = @Padreequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@CodTipoEnteequalthis IS NULL) OR COD_TIPO_ENTE = @CodTipoEnteequalthis)
		order by LIVELLO,ORDINE_FUNZIONALITA,DESCRIZIONE
