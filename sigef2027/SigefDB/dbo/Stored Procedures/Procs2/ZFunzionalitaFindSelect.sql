CREATE PROCEDURE [dbo].[ZFunzionalitaFindSelect]
(
	@CodFunzioneequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@FlagMenuequalthis BIT, 
	@DescMenuequalthis VARCHAR(255), 
	@Livelloequalthis INT, 
	@Padreequalthis INT, 
	@Linkequalthis VARCHAR(255), 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_FUNZIONE, DESCRIZIONE, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE FROM FUNZIONALITA WHERE 1=1';
	IF (@CodFunzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FUNZIONE = @CodFunzioneequalthis)'; set @lensql=@lensql+len(@CodFunzioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@FlagMenuequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_MENU = @FlagMenuequalthis)'; set @lensql=@lensql+len(@FlagMenuequalthis);end;
	IF (@DescMenuequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESC_MENU = @DescMenuequalthis)'; set @lensql=@lensql+len(@DescMenuequalthis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LIVELLO = @Livelloequalthis)'; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@Padreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PADRE = @Padreequalthis)'; set @lensql=@lensql+len(@Padreequalthis);end;
	IF (@Linkequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LINK = @Linkequalthis)'; set @lensql=@lensql+len(@Linkequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodFunzioneequalthis INT, @Descrizioneequalthis VARCHAR(255), @FlagMenuequalthis BIT, @DescMenuequalthis VARCHAR(255), @Livelloequalthis INT, @Padreequalthis INT, @Linkequalthis VARCHAR(255), @Ordineequalthis INT',@CodFunzioneequalthis , @Descrizioneequalthis , @FlagMenuequalthis , @DescMenuequalthis , @Livelloequalthis , @Padreequalthis , @Linkequalthis , @Ordineequalthis ;
	else
		SELECT COD_FUNZIONE, DESCRIZIONE, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE
		FROM FUNZIONALITA
		WHERE 
			((@CodFunzioneequalthis IS NULL) OR COD_FUNZIONE = @CodFunzioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@FlagMenuequalthis IS NULL) OR FLAG_MENU = @FlagMenuequalthis) AND 
			((@DescMenuequalthis IS NULL) OR DESC_MENU = @DescMenuequalthis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@Padreequalthis IS NULL) OR PADRE = @Padreequalthis) AND 
			((@Linkequalthis IS NULL) OR LINK = @Linkequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'create PROCEDURE [dbo].[ZFunzionalitaFindSelect]
(
	@CodFunzioneequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@FlagMenuequalthis BIT, 
	@DescMenuequalthis VARCHAR(50), 
	@Livelloequalthis INT, 
	@Padreequalthis INT, 
	@Linkequalthis VARCHAR(255), 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT COD_FUNZIONE, DESCRIZIONE, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE FROM FUNZIONALITA WHERE 1=1'';
	IF (@CodFunzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FUNZIONE = @CodFunzioneequalthis)''; set @lensql=@lensql+len(@CodFunzioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@FlagMenuequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_MENU = @FlagMenuequalthis)''; set @lensql=@lensql+len(@FlagMenuequalthis);end;
	IF (@DescMenuequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESC_MENU = @DescMenuequalthis)''; set @lensql=@lensql+len(@DescMenuequalthis);end;
	IF (@Livelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (LIVELLO = @Livelloequalthis)''; set @lensql=@lensql+len(@Livelloequalthis);end;
	IF (@Padreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PADRE = @Padreequalthis)''; set @lensql=@lensql+len(@Padreequalthis);end;
	IF (@Linkequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (LINK = @Linkequalthis)''; set @lensql=@lensql+len(@Linkequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@CodFunzioneequalthis INT, @Descrizioneequalthis VARCHAR(255), @FlagMenuequalthis BIT, @DescMenuequalthis VARCHAR(50), @Livelloequalthis INT, @Padreequalthis INT, @Linkequalthis VARCHAR(255), @Ordineequalthis INT'',@CodFunzioneequalthis , @Descrizioneequalthis , @FlagMenuequalthis , @DescMenuequalthis , @Livelloequalthis , @Padreequalthis , @Linkequalthis , @Ordineequalthis ;
	else
		SELECT COD_FUNZIONE, DESCRIZIONE, FLAG_MENU, DESC_MENU, LIVELLO, PADRE, LINK, ORDINE
		FROM FUNZIONALITA
		WHERE 
			((@CodFunzioneequalthis IS NULL) OR COD_FUNZIONE = @CodFunzioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@FlagMenuequalthis IS NULL) OR FLAG_MENU = @FlagMenuequalthis) AND 
			((@DescMenuequalthis IS NULL) OR DESC_MENU = @DescMenuequalthis) AND 
			((@Livelloequalthis IS NULL) OR LIVELLO = @Livelloequalthis) AND 
			((@Padreequalthis IS NULL) OR PADRE = @Padreequalthis) AND 
			((@Linkequalthis IS NULL) OR LINK = @Linkequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		-- order by ecc.ecc.
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFunzionalitaFindSelect';

