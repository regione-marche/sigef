CREATE PROCEDURE [dbo].[ZNewsFindSelect]
(
	@IdNewsequalthis INT, 
	@Titoloequalthis VARCHAR(255), 
	@Testoequalthis NVARCHAR(MAX), 
	@Urlequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@InterruzioneSistemaequalthis BIT, 
	@DataInizioequalthis DATETIME, 
	@DataFineequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_NEWS, TITOLO, TESTO, URL, DATA, OPERATORE, INTERRUZIONE_SISTEMA, DATA_INIZIO, DATA_FINE FROM NEWS WHERE 1=1';
	IF (@IdNewsequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_NEWS = @IdNewsequalthis)'; set @lensql=@lensql+len(@IdNewsequalthis);end;
	IF (@Titoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TITOLO = @Titoloequalthis)'; set @lensql=@lensql+len(@Titoloequalthis);end;
	IF (@Testoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO = @Testoequalthis)'; set @lensql=@lensql+len(@Testoequalthis);end;
	IF (@Urlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (URL = @Urlequalthis)'; set @lensql=@lensql+len(@Urlequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@InterruzioneSistemaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTERRUZIONE_SISTEMA = @InterruzioneSistemaequalthis)'; set @lensql=@lensql+len(@InterruzioneSistemaequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdNewsequalthis INT, @Titoloequalthis VARCHAR(255), @Testoequalthis NVARCHAR, @Urlequalthis VARCHAR(255), @Dataequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @InterruzioneSistemaequalthis BIT, @DataInizioequalthis DATETIME, @DataFineequalthis DATETIME',@IdNewsequalthis , @Titoloequalthis , @Testoequalthis , @Urlequalthis , @Dataequalthis , @Operatoreequalthis , @InterruzioneSistemaequalthis , @DataInizioequalthis , @DataFineequalthis ;
	else
		SELECT ID_NEWS, TITOLO, TESTO, URL, DATA, OPERATORE, INTERRUZIONE_SISTEMA, DATA_INIZIO, DATA_FINE
		FROM NEWS
		WHERE 
			((@IdNewsequalthis IS NULL) OR ID_NEWS = @IdNewsequalthis) AND 
			((@Titoloequalthis IS NULL) OR TITOLO = @Titoloequalthis) AND 
			((@Testoequalthis IS NULL) OR TESTO = @Testoequalthis) AND 
			((@Urlequalthis IS NULL) OR URL = @Urlequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@InterruzioneSistemaequalthis IS NULL) OR INTERRUZIONE_SISTEMA = @InterruzioneSistemaequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZNewsFindSelect]
(
	@IdNewsequalthis INT, 
	@Titoloequalthis VARCHAR(255), 
	@Urlequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@InterruzioneSistemaequalthis BIT, 
	@DataInizioequalthis DATETIME, 
	@DataFineequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_NEWS, TITOLO, TESTO, URL, DATA, OPERATORE, INTERRUZIONE_SISTEMA, DATA_INIZIO, DATA_FINE FROM NEWS WHERE 1=1'';
	IF (@IdNewsequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_NEWS = @IdNewsequalthis)''; set @lensql=@lensql+len(@IdNewsequalthis);end;
	IF (@Titoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TITOLO = @Titoloequalthis)''; set @lensql=@lensql+len(@Titoloequalthis);end;
	IF (@Urlequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (URL = @Urlequalthis)''; set @lensql=@lensql+len(@Urlequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@InterruzioneSistemaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (INTERRUZIONE_SISTEMA = @InterruzioneSistemaequalthis)''; set @lensql=@lensql+len(@InterruzioneSistemaequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INIZIO = @DataInizioequalthis)''; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE = @DataFineequalthis)''; set @lensql=@lensql+len(@DataFineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdNewsequalthis INT, @Titoloequalthis VARCHAR(255), @Urlequalthis VARCHAR(255), @Dataequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @InterruzioneSistemaequalthis BIT, @DataInizioequalthis DATETIME, @DataFineequalthis DATETIME'',@IdNewsequalthis , @Titoloequalthis , @Urlequalthis , @Dataequalthis , @Operatoreequalthis , @InterruzioneSistemaequalthis , @DataInizioequalthis , @DataFineequalthis ;
	else
		SELECT ID_NEWS, TITOLO, TESTO, URL, DATA, OPERATORE, INTERRUZIONE_SISTEMA, DATA_INIZIO, DATA_FINE
		FROM NEWS
		WHERE 
			((@IdNewsequalthis IS NULL) OR ID_NEWS = @IdNewsequalthis) AND 
			((@Titoloequalthis IS NULL) OR TITOLO = @Titoloequalthis) AND 
			((@Urlequalthis IS NULL) OR URL = @Urlequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@InterruzioneSistemaequalthis IS NULL) OR INTERRUZIONE_SISTEMA = @InterruzioneSistemaequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZNewsFindSelect';

