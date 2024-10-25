CREATE PROCEDURE [dbo].[ZZpsrFindFind]
(
	@Descrizionelikethis VARCHAR(255), 
	@AnnoDaequalthis INT, 
	@AnnoAequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT CODICE, DESCRIZIONE, ANNO_DA, ANNO_A, PROFONDITA_ALBERO, CCI FROM zPSR WHERE 1=1';
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@AnnoDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO_DA = @AnnoDaequalthis)'; set @lensql=@lensql+len(@AnnoDaequalthis);end;
	IF (@AnnoAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO_A = @AnnoAequalthis)'; set @lensql=@lensql+len(@AnnoAequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Descrizionelikethis VARCHAR(255), @AnnoDaequalthis INT, @AnnoAequalthis INT',@Descrizionelikethis , @AnnoDaequalthis , @AnnoAequalthis ;
	else
		SELECT CODICE, DESCRIZIONE, ANNO_DA, ANNO_A, PROFONDITA_ALBERO, CCI
		FROM zPSR
		WHERE 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@AnnoDaequalthis IS NULL) OR ANNO_DA = @AnnoDaequalthis) AND 
			((@AnnoAequalthis IS NULL) OR ANNO_A = @AnnoAequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZpsrFindFind]
(
	@Descrizionelikethis VARCHAR(255), 
	@AnnoDaequalthis INT, 
	@AnnoAequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT CODICE, DESCRIZIONE, ANNO_DA, ANNO_A, PROFONDITA_ALBERO FROM zPSR WHERE 1=1'';
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE LIKE @Descrizionelikethis)''; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@AnnoDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNO_DA = @AnnoDaequalthis)''; set @lensql=@lensql+len(@AnnoDaequalthis);end;
	IF (@AnnoAequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNO_A = @AnnoAequalthis)''; set @lensql=@lensql+len(@AnnoAequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Descrizionelikethis VARCHAR(255), @AnnoDaequalthis INT, @AnnoAequalthis INT'',@Descrizionelikethis , @AnnoDaequalthis , @AnnoAequalthis ;
	else
		SELECT CODICE, DESCRIZIONE, ANNO_DA, ANNO_A, PROFONDITA_ALBERO
		FROM zPSR
		WHERE 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@AnnoDaequalthis IS NULL) OR ANNO_DA = @AnnoDaequalthis) AND 
			((@AnnoAequalthis IS NULL) OR ANNO_A = @AnnoAequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZpsrFindFind';

