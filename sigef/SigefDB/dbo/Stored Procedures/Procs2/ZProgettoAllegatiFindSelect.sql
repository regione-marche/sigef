CREATE PROCEDURE [dbo].[ZProgettoAllegatiFindSelect]
(
	@Idequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdAllegatoequalthis INT, 
	@IdFileequalthis INT, 
	@DescrizioneBreveequalthis VARCHAR(255), 
	@CodEnteEmettitoreequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@GiaPresentatoequalthis BIT, 
	@CodEsitoIstruttoriaequalthis VARCHAR(255), 
	@NoteIstruttoriaequalthis VARCHAR(1000)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGETTO, ID_ALLEGATO, ID_FILE, DESCRIZIONE_BREVE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, GIA_PRESENTATO, COD_ESITO_ISTRUTTORIA, NOTE_ISTRUTTORIA, ALLEGATO, MISURA, COD_TIPO_ENTE_EMETTITORE, ESITO, ESITO_POSITIVO, COD_TIPO, TIPO_ALLEGATO, ENTE, DIMENSIONE_FILE FROM vPROGETTO_ALLEGATI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@DescrizioneBreveequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_BREVE = @DescrizioneBreveequalthis)'; set @lensql=@lensql+len(@DescrizioneBreveequalthis);end;
	IF (@CodEnteEmettitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis)'; set @lensql=@lensql+len(@CodEnteEmettitoreequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@GiaPresentatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (GIA_PRESENTATO = @GiaPresentatoequalthis)'; set @lensql=@lensql+len(@GiaPresentatoequalthis);end;
	IF (@CodEsitoIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO_ISTRUTTORIA = @CodEsitoIstruttoriaequalthis)'; set @lensql=@lensql+len(@CodEsitoIstruttoriaequalthis);end;
	IF (@NoteIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE_ISTRUTTORIA = @NoteIstruttoriaequalthis)'; set @lensql=@lensql+len(@NoteIstruttoriaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdProgettoequalthis INT, @IdAllegatoequalthis INT, @IdFileequalthis INT, @DescrizioneBreveequalthis VARCHAR(255), @CodEnteEmettitoreequalthis VARCHAR(255), @IdComuneequalthis INT, @Numeroequalthis VARCHAR(255), @Dataequalthis DATETIME, @GiaPresentatoequalthis BIT, @CodEsitoIstruttoriaequalthis VARCHAR(255), @NoteIstruttoriaequalthis VARCHAR(1000)',@Idequalthis , @IdProgettoequalthis , @IdAllegatoequalthis , @IdFileequalthis , @DescrizioneBreveequalthis , @CodEnteEmettitoreequalthis , @IdComuneequalthis , @Numeroequalthis , @Dataequalthis , @GiaPresentatoequalthis , @CodEsitoIstruttoriaequalthis , @NoteIstruttoriaequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_ALLEGATO, ID_FILE, DESCRIZIONE_BREVE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, GIA_PRESENTATO, COD_ESITO_ISTRUTTORIA, NOTE_ISTRUTTORIA, ALLEGATO, MISURA, COD_TIPO_ENTE_EMETTITORE, ESITO, ESITO_POSITIVO, COD_TIPO, TIPO_ALLEGATO, ENTE, DIMENSIONE_FILE
		FROM vPROGETTO_ALLEGATI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@DescrizioneBreveequalthis IS NULL) OR DESCRIZIONE_BREVE = @DescrizioneBreveequalthis) AND 
			((@CodEnteEmettitoreequalthis IS NULL) OR COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@GiaPresentatoequalthis IS NULL) OR GIA_PRESENTATO = @GiaPresentatoequalthis) AND 
			((@CodEsitoIstruttoriaequalthis IS NULL) OR COD_ESITO_ISTRUTTORIA = @CodEsitoIstruttoriaequalthis) AND 
			((@NoteIstruttoriaequalthis IS NULL) OR NOTE_ISTRUTTORIA = @NoteIstruttoriaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoAllegatiFindSelect]
(
	@Idequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdAllegatoequalthis INT, 
	@IdFileequalthis INT, 
	@DescrizioneBreveequalthis VARCHAR(255), 
	@CodEnteEmettitoreequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@GiaPresentatoequalthis BIT, 
	@CodEsitoIstruttoriaequalthis VARCHAR(255), 
	@NoteIstruttoriaequalthis VARCHAR(1000)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGETTO, ID_ALLEGATO, ID_FILE, DESCRIZIONE_BREVE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, GIA_PRESENTATO, COD_ESITO_ISTRUTTORIA, NOTE_ISTRUTTORIA, ALLEGATO, MISURA, COD_TIPO_ENTE_EMETTITORE, ESITO, ESITO_POSITIVO, COD_TIPO, TIPO_ALLEGATO, ENTE FROM vPROGETTO_ALLEGATI WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ALLEGATO = @IdAllegatoequalthis)''; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILE = @IdFileequalthis)''; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@DescrizioneBreveequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE_BREVE = @DescrizioneBreveequalthis)''; set @lensql=@lensql+len(@DescrizioneBreveequalthis);end;
	IF (@CodEnteEmettitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis)''; set @lensql=@lensql+len(@CodEnteEmettitoreequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_COMUNE = @IdComuneequalthis)''; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO = @Numeroequalthis)''; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@GiaPresentatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (GIA_PRESENTATO = @GiaPresentatoequalthis)''; set @lensql=@lensql+len(@GiaPresentatoequalthis);end;
	IF (@CodEsitoIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ESITO_ISTRUTTORIA = @CodEsitoIstruttoriaequalthis)''; set @lensql=@lensql+len(@CodEsitoIstruttoriaequalthis);end;
	IF (@NoteIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NOTE_ISTRUTTORIA = @NoteIstruttoriaequalthis)''; set @lensql=@lensql+len(@NoteIstruttoriaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdProgettoequalthis INT, @IdAllegatoequalthis INT, @IdFileequalthis INT, @DescrizioneBreveequalthis VARCHAR(255), @CodEnteEmettitoreequalthis VARCHAR(255), @IdComuneequalthis INT, @Numeroequalthis VARCHAR(255), @Dataequalthis DATETIME, @GiaPresentatoequalthis BIT, @CodEsitoIstruttoriaequalthis VARCHAR(255), @NoteIstruttoriaequalthis VARCHAR(1000)'',@Idequalthis , @IdProgettoequalthis , @IdAllegatoequalthis , @IdFileequalthis , @DescrizioneBreveequalthis , @CodEnteEmettitoreequalthis , @IdComuneequalthis , @Numeroequalthis , @Dataequalthis , @GiaPresentatoequalthis , @CodEsitoIstruttoriaequalthis , @NoteIstruttoriaequalthis ;
	else
		SELECT ID, ID_PROGETTO, ID_ALLEGATO, ID_FILE, DESCRIZIONE_BREVE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, GIA_PRESENTATO, COD_ESITO_ISTRUTTORIA, NOTE_ISTRUTTORIA, ALLEGATO, MISURA, COD_TIPO_ENTE_EMETTITORE, ESITO, ESITO_POSITIVO, COD_TIPO, TIPO_ALLEGATO, ENTE
		FROM vPROGETTO_ALLEGATI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdAllegatoequalthis', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoAllegatiFindSelect';

