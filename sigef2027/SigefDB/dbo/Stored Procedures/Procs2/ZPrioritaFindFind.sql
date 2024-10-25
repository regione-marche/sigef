CREATE PROCEDURE [dbo].[ZPrioritaFindFind]
(
	@IdPrioritaequalthis INT, 
	@CodLivelloequalthis VARCHAR(255), 
	@PluriValoreequalthis BIT, 
	@Datetimeequalthis BIT, 
	@TestoSempliceequalthis BIT, 
	@TestoAreaequalthis BIT, 
	@PluriValoreSqlequalthis BIT, 
	@Descrizionelikethis VARCHAR(1000), 
	@Misuralikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PRIORITA, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE FROM PRIORITA WHERE 1=1';
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_LIVELLO = @CodLivelloequalthis)'; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	IF (@PluriValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLURI_VALORE = @PluriValoreequalthis)'; set @lensql=@lensql+len(@PluriValoreequalthis);end;
	IF (@Datetimeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATETIME = @Datetimeequalthis)'; set @lensql=@lensql+len(@Datetimeequalthis);end;
	IF (@TestoSempliceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO_SEMPLICE = @TestoSempliceequalthis)'; set @lensql=@lensql+len(@TestoSempliceequalthis);end;
	IF (@TestoAreaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO_AREA = @TestoAreaequalthis)'; set @lensql=@lensql+len(@TestoAreaequalthis);end;
	IF (@PluriValoreSqlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLURI_VALORE_SQL = @PluriValoreSqlequalthis)'; set @lensql=@lensql+len(@PluriValoreSqlequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@Misuralikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA LIKE @Misuralikethis)'; set @lensql=@lensql+len(@Misuralikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPrioritaequalthis INT, @CodLivelloequalthis VARCHAR(255), @PluriValoreequalthis BIT, @Datetimeequalthis BIT, @TestoSempliceequalthis BIT, @TestoAreaequalthis BIT, @PluriValoreSqlequalthis BIT, @Descrizionelikethis VARCHAR(1000), @Misuralikethis VARCHAR(255)',@IdPrioritaequalthis , @CodLivelloequalthis , @PluriValoreequalthis , @Datetimeequalthis , @TestoSempliceequalthis , @TestoAreaequalthis , @PluriValoreSqlequalthis , @Descrizionelikethis , @Misuralikethis ;
	else
		SELECT ID_PRIORITA, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE
		FROM PRIORITA
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis) AND 
			((@PluriValoreequalthis IS NULL) OR PLURI_VALORE = @PluriValoreequalthis) AND 
			((@Datetimeequalthis IS NULL) OR DATETIME = @Datetimeequalthis) AND 
			((@TestoSempliceequalthis IS NULL) OR TESTO_SEMPLICE = @TestoSempliceequalthis) AND 
			((@TestoAreaequalthis IS NULL) OR TESTO_AREA = @TestoAreaequalthis) AND 
			((@PluriValoreSqlequalthis IS NULL) OR PLURI_VALORE_SQL = @PluriValoreSqlequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@Misuralikethis IS NULL) OR MISURA LIKE @Misuralikethis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPrioritaFindFind]
(
	@IdPrioritaequalthis INT, 
	@CodLivelloequalthis VARCHAR(255), 
	@PluriValoreequalthis BIT, 
	@Datetimeequalthis BIT, 
	@TestoSempliceequalthis BIT, 
	@TestoAreaequalthis BIT, 
	@Descrizionelikethis VARCHAR(1000), 
	@Misuralikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PRIORITA, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA FROM PRIORITA WHERE 1=1'';
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_LIVELLO = @CodLivelloequalthis)''; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	IF (@PluriValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PLURI_VALORE = @PluriValoreequalthis)''; set @lensql=@lensql+len(@PluriValoreequalthis);end;
	IF (@Datetimeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATETIME = @Datetimeequalthis)''; set @lensql=@lensql+len(@Datetimeequalthis);end;
	IF (@TestoSempliceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TESTO_SEMPLICE = @TestoSempliceequalthis)''; set @lensql=@lensql+len(@TestoSempliceequalthis);end;
	IF (@TestoAreaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TESTO_AREA = @TestoAreaequalthis)''; set @lensql=@lensql+len(@TestoAreaequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE LIKE @Descrizionelikethis)''; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@Misuralikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MISURA LIKE @Misuralikethis)''; set @lensql=@lensql+len(@Misuralikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPrioritaequalthis INT, @CodLivelloequalthis VARCHAR(255), @PluriValoreequalthis BIT, @Datetimeequalthis BIT, @TestoSempliceequalthis BIT, @TestoAreaequalthis BIT, @Descrizionelikethis VARCHAR(1000), @Misuralikethis VARCHAR(255)'',@IdPrioritaequalthis , @CodLivelloequalthis , @PluriValoreequalthis , @Datetimeequalthis , @TestoSempliceequalthis , @TestoAreaequalthis , @Descrizionelikethis , @Misuralikethis ;
	else
		SELECT ID_PRIORITA, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA
		FROM PRIORITA
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis) AND 
			((@PluriValoreequalthis IS NULL) OR PLURI_VALORE = @PluriValoreequalthis) AND 
			((@Datetimeequalthis IS NULL) OR DATETIME = @Datetimeequalthis) AND 
			((@TestoSempliceequalthis IS NULL) OR TESTO_SEMPLICE = @TestoSempliceequalthis) AND 
			((@TestoAreaequalthis IS NULL) OR TESTO_AREA = @TestoAreaequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@Misuralikethis IS NULL) OR MISURA LIKE @Misuralikethis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaFindFind';

