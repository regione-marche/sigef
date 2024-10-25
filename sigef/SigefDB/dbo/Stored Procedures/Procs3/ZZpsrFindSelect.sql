CREATE PROCEDURE [dbo].[ZZpsrFindSelect]
(
	@Codiceequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@AnnoDaequalthis INT, 
	@AnnoAequalthis INT, 
	@ProfonditaAlberoequalthis INT, 
	@Cciequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT CODICE, DESCRIZIONE, ANNO_DA, ANNO_A, PROFONDITA_ALBERO, CCI FROM zPSR WHERE 1=1';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@AnnoDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO_DA = @AnnoDaequalthis)'; set @lensql=@lensql+len(@AnnoDaequalthis);end;
	IF (@AnnoAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO_A = @AnnoAequalthis)'; set @lensql=@lensql+len(@AnnoAequalthis);end;
	IF (@ProfonditaAlberoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROFONDITA_ALBERO = @ProfonditaAlberoequalthis)'; set @lensql=@lensql+len(@ProfonditaAlberoequalthis);end;
	IF (@Cciequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CCI = @Cciequalthis)'; set @lensql=@lensql+len(@Cciequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Codiceequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @AnnoDaequalthis INT, @AnnoAequalthis INT, @ProfonditaAlberoequalthis INT, @Cciequalthis VARCHAR(255)',@Codiceequalthis , @Descrizioneequalthis , @AnnoDaequalthis , @AnnoAequalthis , @ProfonditaAlberoequalthis , @Cciequalthis ;
	else
		SELECT CODICE, DESCRIZIONE, ANNO_DA, ANNO_A, PROFONDITA_ALBERO, CCI
		FROM zPSR
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@AnnoDaequalthis IS NULL) OR ANNO_DA = @AnnoDaequalthis) AND 
			((@AnnoAequalthis IS NULL) OR ANNO_A = @AnnoAequalthis) AND 
			((@ProfonditaAlberoequalthis IS NULL) OR PROFONDITA_ALBERO = @ProfonditaAlberoequalthis) AND 
			((@Cciequalthis IS NULL) OR CCI = @Cciequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZpsrFindSelect]
(
	@Codiceequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@AnnoDaequalthis INT, 
	@AnnoAequalthis INT, 
	@ProfonditaAlberoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT CODICE, DESCRIZIONE, ANNO_DA, ANNO_A, PROFONDITA_ALBERO FROM zPSR WHERE 1=1'';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE = @Codiceequalthis)''; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@AnnoDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNO_DA = @AnnoDaequalthis)''; set @lensql=@lensql+len(@AnnoDaequalthis);end;
	IF (@AnnoAequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNO_A = @AnnoAequalthis)''; set @lensql=@lensql+len(@AnnoAequalthis);end;
	IF (@ProfonditaAlberoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROFONDITA_ALBERO = @ProfonditaAlberoequalthis)''; set @lensql=@lensql+len(@ProfonditaAlberoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Codiceequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @AnnoDaequalthis INT, @AnnoAequalthis INT, @ProfonditaAlberoequalthis INT'',@Codiceequalthis , @Descrizioneequalthis , @AnnoDaequalthis , @AnnoAequalthis , @ProfonditaAlberoequalthis ;
	else
		SELECT CODICE, DESCRIZIONE, ANNO_DA, ANNO_A, PROFONDITA_ALBERO
		FROM zPSR
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@AnnoDaequalthis IS NULL) OR ANNO_DA = @AnnoDaequalthis) AND 
			((@AnnoAequalthis IS NULL) OR ANNO_A = @AnnoAequalthis) AND 
			((@ProfonditaAlberoequalthis IS NULL) OR PROFONDITA_ALBERO = @ProfonditaAlberoequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZpsrFindSelect';

