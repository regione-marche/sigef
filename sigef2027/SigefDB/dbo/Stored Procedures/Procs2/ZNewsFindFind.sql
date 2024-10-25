CREATE PROCEDURE [dbo].[ZNewsFindFind]
(
	@Titololikethis VARCHAR(255), 
	@Testolikethis NVARCHAR(MAX), 
	@InterruzioneSistemaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_NEWS, TITOLO, TESTO, URL, DATA, OPERATORE, INTERRUZIONE_SISTEMA, DATA_INIZIO, DATA_FINE FROM NEWS WHERE 1=1';
	IF (@Titololikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TITOLO LIKE @Titololikethis)'; set @lensql=@lensql+len(@Titololikethis);end;
	IF (@Testolikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO LIKE @Testolikethis)'; set @lensql=@lensql+len(@Testolikethis);end;
	IF (@InterruzioneSistemaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTERRUZIONE_SISTEMA = @InterruzioneSistemaequalthis)'; set @lensql=@lensql+len(@InterruzioneSistemaequalthis);end;
	set @sql = @sql + 'ORDER BY DATA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Titololikethis VARCHAR(255), @Testolikethis NVARCHAR(MAX), @InterruzioneSistemaequalthis BIT',@Titololikethis , @Testolikethis , @InterruzioneSistemaequalthis ;
	else
		SELECT ID_NEWS, TITOLO, TESTO, URL, DATA, OPERATORE, INTERRUZIONE_SISTEMA, DATA_INIZIO, DATA_FINE
		FROM NEWS
		WHERE 
			((@Titololikethis IS NULL) OR TITOLO LIKE @Titololikethis) AND 
			((@Testolikethis IS NULL) OR TESTO LIKE @Testolikethis) AND 
			((@InterruzioneSistemaequalthis IS NULL) OR INTERRUZIONE_SISTEMA = @InterruzioneSistemaequalthis)
		ORDER BY DATA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZNewsFindFind]
(
	@IdNewsequalthis INT, 
	@Titololikethis VARCHAR(255), 
	@Operatoreequalthis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_NEWS, TITOLO, TESTO, URL, DATA, OPERATORE, INTERRUZIONE_SISTEMA, DATA_INIZIO, DATA_FINE FROM NEWS WHERE 1=1'';
	IF (@IdNewsequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_NEWS = @IdNewsequalthis)''; set @lensql=@lensql+len(@IdNewsequalthis);end;
	IF (@Titololikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TITOLO LIKE @Titololikethis)''; set @lensql=@lensql+len(@Titololikethis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @sql = @sql + ''ORDER BY DATA DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdNewsequalthis INT, @Titololikethis VARCHAR(255), @Operatoreequalthis VARCHAR(16)'',@IdNewsequalthis , @Titololikethis , @Operatoreequalthis ;
	else
		SELECT ID_NEWS, TITOLO, TESTO, URL, DATA, OPERATORE, INTERRUZIONE_SISTEMA, DATA_INIZIO, DATA_FINE
		FROM NEWS
		WHERE 
			((@IdNewsequalthis IS NULL) OR ID_NEWS = @IdNewsequalthis) AND 
			((@Titololikethis IS NULL) OR TITOLO LIKE @Titololikethis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)
		ORDER BY DATA DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZNewsFindFind';

