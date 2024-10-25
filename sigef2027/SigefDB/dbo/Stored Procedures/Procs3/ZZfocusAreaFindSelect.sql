CREATE PROCEDURE [dbo].[ZZfocusAreaFindSelect]
(
	@Codiceequalthis VARCHAR(255), 
	@CodPsrequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@DotFinanziariaequalthis DECIMAL(18,2), 
	@Trasversaleequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT CODICE, COD_PSR, DESCRIZIONE, DOT_FINANZIARIA, TRASVERSALE FROM zFOCUS_AREA WHERE 1=1';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@DotFinanziariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DOT_FINANZIARIA = @DotFinanziariaequalthis)'; set @lensql=@lensql+len(@DotFinanziariaequalthis);end;
	IF (@Trasversaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TRASVERSALE = @Trasversaleequalthis)'; set @lensql=@lensql+len(@Trasversaleequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Codiceequalthis VARCHAR(255), @CodPsrequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @DotFinanziariaequalthis DECIMAL(18,2), @Trasversaleequalthis BIT',@Codiceequalthis , @CodPsrequalthis , @Descrizioneequalthis , @DotFinanziariaequalthis , @Trasversaleequalthis ;
	else
		SELECT CODICE, COD_PSR, DESCRIZIONE, DOT_FINANZIARIA, TRASVERSALE
		FROM zFOCUS_AREA
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@DotFinanziariaequalthis IS NULL) OR DOT_FINANZIARIA = @DotFinanziariaequalthis) AND 
			((@Trasversaleequalthis IS NULL) OR TRASVERSALE = @Trasversaleequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZfocusAreaFindSelect]
(
	@Codiceequalthis VARCHAR(255), 
	@CodPsrequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@DotFinanziariaequalthis DECIMAL(18,2), 
	@Trasversaleequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT CODICE, COD_PSR, DESCRIZIONE, DOT_FINANZIARIA, TRASVERSALE FROM zFOCUS_AREA WHERE 1=1'';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE = @Codiceequalthis)''; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_PSR = @CodPsrequalthis)''; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@DotFinanziariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DOT_FINANZIARIA = @DotFinanziariaequalthis)''; set @lensql=@lensql+len(@DotFinanziariaequalthis);end;
	IF (@Trasversaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TRASVERSALE = @Trasversaleequalthis)''; set @lensql=@lensql+len(@Trasversaleequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Codiceequalthis VARCHAR(255), @CodPsrequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @DotFinanziariaequalthis DECIMAL(18,2), @Trasversaleequalthis BIT'',@Codiceequalthis , @CodPsrequalthis , @Descrizioneequalthis , @DotFinanziariaequalthis , @Trasversaleequalthis ;
	else
		SELECT CODICE, COD_PSR, DESCRIZIONE, DOT_FINANZIARIA, TRASVERSALE
		FROM zFOCUS_AREA
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@DotFinanziariaequalthis IS NULL) OR DOT_FINANZIARIA = @DotFinanziariaequalthis) AND 
			((@Trasversaleequalthis IS NULL) OR TRASVERSALE = @Trasversaleequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZfocusAreaFindSelect';

