CREATE PROCEDURE [dbo].[ZZfocusAreaFindFind]
(
	@Codicelikethis VARCHAR(255), 
	@CodPsrequalthis VARCHAR(255), 
	@Trasversaleequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT CODICE, COD_PSR, DESCRIZIONE, DOT_FINANZIARIA, TRASVERSALE FROM zFOCUS_AREA WHERE 1=1';
	IF (@Codicelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE LIKE @Codicelikethis)'; set @lensql=@lensql+len(@Codicelikethis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Trasversaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TRASVERSALE = @Trasversaleequalthis)'; set @lensql=@lensql+len(@Trasversaleequalthis);end;
	set @sql = @sql + 'ORDER BY CODICE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Codicelikethis VARCHAR(255), @CodPsrequalthis VARCHAR(255), @Trasversaleequalthis BIT',@Codicelikethis , @CodPsrequalthis , @Trasversaleequalthis ;
	else
		SELECT CODICE, COD_PSR, DESCRIZIONE, DOT_FINANZIARIA, TRASVERSALE
		FROM zFOCUS_AREA
		WHERE 
			((@Codicelikethis IS NULL) OR CODICE LIKE @Codicelikethis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Trasversaleequalthis IS NULL) OR TRASVERSALE = @Trasversaleequalthis)
		ORDER BY CODICE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZfocusAreaFindFind]
(
	@Codicelikethis VARCHAR(255), 
	@CodPsrequalthis VARCHAR(255), 
	@Trasversaleequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT CODICE, COD_PSR, DESCRIZIONE, DOT_FINANZIARIA, TRASVERSALE FROM zFOCUS_AREA WHERE 1=1'';
	IF (@Codicelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE LIKE @Codicelikethis)''; set @lensql=@lensql+len(@Codicelikethis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_PSR = @CodPsrequalthis)''; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Trasversaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TRASVERSALE = @Trasversaleequalthis)''; set @lensql=@lensql+len(@Trasversaleequalthis);end;
	set @sql = @sql + ''ORDER BY CODICE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Codicelikethis VARCHAR(255), @CodPsrequalthis VARCHAR(255), @Trasversaleequalthis BIT'',@Codicelikethis , @CodPsrequalthis , @Trasversaleequalthis ;
	else
		SELECT CODICE, COD_PSR, DESCRIZIONE, DOT_FINANZIARIA, TRASVERSALE
		FROM zFOCUS_AREA
		WHERE 
			((@Codicelikethis IS NULL) OR CODICE LIKE @Codicelikethis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Trasversaleequalthis IS NULL) OR TRASVERSALE = @Trasversaleequalthis)
		ORDER BY CODICE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZfocusAreaFindFind';

