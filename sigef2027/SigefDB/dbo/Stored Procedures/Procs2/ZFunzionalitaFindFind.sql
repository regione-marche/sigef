CREATE PROCEDURE [dbo].[ZFunzionalitaFindFind]
(
	@CodFunzioneequalthis INT, 
	@DescMenuequalthis VARCHAR(255), 
	@Livelloequalthis INT, 
	@Padreequalthis INT, 
	@Ordineequalthis INT, 
	@FlagMenuequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_FUNZIONE, DESCRIZIONE, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE FROM FUNZIONALITA WHERE 1=1';
	IF (@CodFunzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FUNZIONE = @CodFunzioneequalthis)'; set @lensql=@lensql+len(@CodFunzioneequalthis);end;
	IF (@DescMenuequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESC_MENU = @DescMenuequalthis)'; set @lensql=@lensql+len(@DescMenuequalthis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LIVELLO = @Livelloequalthis)'; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@Padreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PADRE = @Padreequalthis)'; set @lensql=@lensql+len(@Padreequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@FlagMenuequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_MENU = @FlagMenuequalthis)'; set @lensql=@lensql+len(@FlagMenuequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodFunzioneequalthis INT, @DescMenuequalthis VARCHAR(255), @Livelloequalthis INT, @Padreequalthis INT, @Ordineequalthis INT, @FlagMenuequalthis BIT',@CodFunzioneequalthis , @DescMenuequalthis , @Livelloequalthis , @Padreequalthis , @Ordineequalthis , @FlagMenuequalthis ;
	else
		SELECT COD_FUNZIONE, DESCRIZIONE, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE
		FROM FUNZIONALITA
		WHERE 
			((@CodFunzioneequalthis IS NULL) OR COD_FUNZIONE = @CodFunzioneequalthis) AND 
			((@DescMenuequalthis IS NULL) OR DESC_MENU = @DescMenuequalthis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@Padreequalthis IS NULL) OR PADRE = @Padreequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@FlagMenuequalthis IS NULL) OR FLAG_MENU = @FlagMenuequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZFunzionalitaFindFind]
(
	@CodFunzioneequalthis INT, 
	@DescMenuequalthis VARCHAR(50), 
	@Livelloequalthis INT, 
	@Padreequalthis INT, 
	@Ordineequalthis INT, 
	@FlagMenuequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT COD_FUNZIONE, DESCRIZIONE, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE FROM FUNZIONALITA WHERE 1=1'';
	IF (@CodFunzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FUNZIONE = @CodFunzioneequalthis)''; set @lensql=@lensql+len(@CodFunzioneequalthis);end;
	IF (@DescMenuequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESC_MENU = @DescMenuequalthis)''; set @lensql=@lensql+len(@DescMenuequalthis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (LIVELLO = @Livelloequalthis)''; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@Padreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PADRE = @Padreequalthis)''; set @lensql=@lensql+len(@Padreequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@FlagMenuequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_MENU = @FlagMenuequalthis)''; set @lensql=@lensql+len(@FlagMenuequalthis);end;
	set	@sql = @sql + '' ORDER BY LIVELLO,ORDINE,DESCRIZIONE,PADRE''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@CodFunzioneequalthis INT, @DescMenuequalthis VARCHAR(50), @Livelloequalthis INT, @Padreequalthis INT, @Ordineequalthis INT, @FlagMenuequalthis BIT'',@CodFunzioneequalthis , @DescMenuequalthis , @Livelloequalthis , @Padreequalthis , @Ordineequalthis , @FlagMenuequalthis ;
	else
		SELECT COD_FUNZIONE, DESCRIZIONE, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE
		FROM FUNZIONALITA
		WHERE 
			((@CodFunzioneequalthis IS NULL) OR COD_FUNZIONE = @CodFunzioneequalthis) AND 
			((@DescMenuequalthis IS NULL) OR DESC_MENU = @DescMenuequalthis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@Padreequalthis IS NULL) OR PADRE = @Padreequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@FlagMenuequalthis IS NULL) OR FLAG_MENU = @FlagMenuequalthis)
		ORDER BY LIVELLO,ORDINE,DESCRIZIONE,PADRE
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFunzionalitaFindFind';

