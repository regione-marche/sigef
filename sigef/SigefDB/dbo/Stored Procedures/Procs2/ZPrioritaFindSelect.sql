CREATE PROCEDURE [dbo].[ZPrioritaFindSelect]
(
	@IdPrioritaequalthis INT, 
	@Descrizioneequalthis VARCHAR(1000), 
	@CodLivelloequalthis VARCHAR(255), 
	@PluriValoreequalthis BIT, 
	@Evalequalthis VARCHAR(3000), 
	@FlagManualeequalthis BIT, 
	@InputNumericoequalthis BIT, 
	@Misuraequalthis VARCHAR(255), 
	@Datetimeequalthis BIT, 
	@TestoSempliceequalthis BIT, 
	@TestoAreaequalthis BIT, 
	@PluriValoreSqlequalthis BIT, 
	@QueryPlurivaloreequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PRIORITA, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE FROM PRIORITA WHERE 1=1';
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_LIVELLO = @CodLivelloequalthis)'; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	IF (@PluriValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLURI_VALORE = @PluriValoreequalthis)'; set @lensql=@lensql+len(@PluriValoreequalthis);end;
	IF (@Evalequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (EVAL = @Evalequalthis)'; set @lensql=@lensql+len(@Evalequalthis);end;
	IF (@FlagManualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_MANUALE = @FlagManualeequalthis)'; set @lensql=@lensql+len(@FlagManualeequalthis);end;
	IF (@InputNumericoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INPUT_NUMERICO = @InputNumericoequalthis)'; set @lensql=@lensql+len(@InputNumericoequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA = @Misuraequalthis)'; set @lensql=@lensql+len(@Misuraequalthis);end;
	IF (@Datetimeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATETIME = @Datetimeequalthis)'; set @lensql=@lensql+len(@Datetimeequalthis);end;
	IF (@TestoSempliceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO_SEMPLICE = @TestoSempliceequalthis)'; set @lensql=@lensql+len(@TestoSempliceequalthis);end;
	IF (@TestoAreaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO_AREA = @TestoAreaequalthis)'; set @lensql=@lensql+len(@TestoAreaequalthis);end;
	IF (@PluriValoreSqlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLURI_VALORE_SQL = @PluriValoreSqlequalthis)'; set @lensql=@lensql+len(@PluriValoreSqlequalthis);end;
	IF (@QueryPlurivaloreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_PLURIVALORE = @QueryPlurivaloreequalthis)'; set @lensql=@lensql+len(@QueryPlurivaloreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPrioritaequalthis INT, @Descrizioneequalthis VARCHAR(1000), @CodLivelloequalthis VARCHAR(255), @PluriValoreequalthis BIT, @Evalequalthis VARCHAR(3000), @FlagManualeequalthis BIT, @InputNumericoequalthis BIT, @Misuraequalthis VARCHAR(255), @Datetimeequalthis BIT, @TestoSempliceequalthis BIT, @TestoAreaequalthis BIT, @PluriValoreSqlequalthis BIT, @QueryPlurivaloreequalthis VARCHAR(255)',@IdPrioritaequalthis , @Descrizioneequalthis , @CodLivelloequalthis , @PluriValoreequalthis , @Evalequalthis , @FlagManualeequalthis , @InputNumericoequalthis , @Misuraequalthis , @Datetimeequalthis , @TestoSempliceequalthis , @TestoAreaequalthis , @PluriValoreSqlequalthis , @QueryPlurivaloreequalthis ;
	else
		SELECT ID_PRIORITA, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE
		FROM PRIORITA
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis) AND 
			((@PluriValoreequalthis IS NULL) OR PLURI_VALORE = @PluriValoreequalthis) AND 
			((@Evalequalthis IS NULL) OR EVAL = @Evalequalthis) AND 
			((@FlagManualeequalthis IS NULL) OR FLAG_MANUALE = @FlagManualeequalthis) AND 
			((@InputNumericoequalthis IS NULL) OR INPUT_NUMERICO = @InputNumericoequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis) AND 
			((@Datetimeequalthis IS NULL) OR DATETIME = @Datetimeequalthis) AND 
			((@TestoSempliceequalthis IS NULL) OR TESTO_SEMPLICE = @TestoSempliceequalthis) AND 
			((@TestoAreaequalthis IS NULL) OR TESTO_AREA = @TestoAreaequalthis) AND 
			((@PluriValoreSqlequalthis IS NULL) OR PLURI_VALORE_SQL = @PluriValoreSqlequalthis) AND 
			((@QueryPlurivaloreequalthis IS NULL) OR QUERY_PLURIVALORE = @QueryPlurivaloreequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPrioritaFindSelect]
(
	@IdPrioritaequalthis INT, 
	@Descrizioneequalthis VARCHAR(1000), 
	@CodLivelloequalthis VARCHAR(255), 
	@PluriValoreequalthis BIT, 
	@Evalequalthis VARCHAR(3000), 
	@FlagManualeequalthis BIT, 
	@InputNumericoequalthis BIT, 
	@Misuraequalthis VARCHAR(255), 
	@Datetimeequalthis BIT, 
	@TestoSempliceequalthis BIT, 
	@TestoAreaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PRIORITA, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA FROM PRIORITA WHERE 1=1'';
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_LIVELLO = @CodLivelloequalthis)''; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	IF (@PluriValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PLURI_VALORE = @PluriValoreequalthis)''; set @lensql=@lensql+len(@PluriValoreequalthis);end;
	IF (@Evalequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (EVAL = @Evalequalthis)''; set @lensql=@lensql+len(@Evalequalthis);end;
	IF (@FlagManualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FLAG_MANUALE = @FlagManualeequalthis)''; set @lensql=@lensql+len(@FlagManualeequalthis);end;
	IF (@InputNumericoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (INPUT_NUMERICO = @InputNumericoequalthis)''; set @lensql=@lensql+len(@InputNumericoequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MISURA = @Misuraequalthis)''; set @lensql=@lensql+len(@Misuraequalthis);end;
	IF (@Datetimeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATETIME = @Datetimeequalthis)''; set @lensql=@lensql+len(@Datetimeequalthis);end;
	IF (@TestoSempliceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TESTO_SEMPLICE = @TestoSempliceequalthis)''; set @lensql=@lensql+len(@TestoSempliceequalthis);end;
	IF (@TestoAreaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TESTO_AREA = @TestoAreaequalthis)''; set @lensql=@lensql+len(@TestoAreaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPrioritaequalthis INT, @Descrizioneequalthis VARCHAR(1000), @CodLivelloequalthis VARCHAR(255), @PluriValoreequalthis BIT, @Evalequalthis VARCHAR(3000), @FlagManualeequalthis BIT, @InputNumericoequalthis BIT, @Misuraequalthis VARCHAR(255), @Datetimeequalthis BIT, @TestoSempliceequalthis BIT, @TestoAreaequalthis BIT'',@IdPrioritaequalthis , @Descrizioneequalthis , @CodLivelloequalthis , @PluriValoreequalthis , @Evalequalthis , @FlagManualeequalthis , @InputNumericoequalthis , @Misuraequalthis , @Datetimeequalthis , @TestoSempliceequalthis , @TestoAreaequalthis ;
	else
		SELECT ID_PRIORITA, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA
		FROM PRIORITA
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis) AND 
			((@PluriValoreequalthis IS NULL) OR PLURI_VALORE = @PluriValoreequalthis) AND 
			((@Evalequalthis IS NULL) OR EVAL = @Evalequalthis) AND 
			((@FlagManualeequalthis IS NULL) OR FLAG_MANUALE = @FlagManualeequalthis) AND 
			((@InputNumericoequalthis IS NULL) OR INPUT_NUMERICO = @InputNumericoequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis) AND 
			((@Datetimeequalthis IS NULL) OR DATETIME = @Datetimeequalthis) AND 
			((@TestoSempliceequalthis IS NULL) OR TESTO_SEMPLICE = @TestoSempliceequ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaFindSelect';

