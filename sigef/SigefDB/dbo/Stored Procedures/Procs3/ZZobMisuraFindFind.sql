CREATE PROCEDURE [dbo].[ZZobMisuraFindFind]
(
	@IdProgrammazioneequalthis INT, 
	@Codiceequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGRAMMAZIONE, CODICE, DESCRIZIONE FROM zOB_MISURA WHERE 1=1';
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	set @sql = @sql + 'ORDER BY CODICE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgrammazioneequalthis INT, @Codiceequalthis VARCHAR(255)',@IdProgrammazioneequalthis , @Codiceequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, CODICE, DESCRIZIONE
		FROM zOB_MISURA
		WHERE 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis)
		ORDER BY CODICE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZobMisuraFindFind]
(
	@IdProgrammazioneequalthis INT, 
	@Codiceequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGRAMMAZIONE, CODICE, DESCRIZIONE FROM zOB_MISURA WHERE 1=1'';
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)''; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE = @Codiceequalthis)''; set @lensql=@lensql+len(@Codiceequalthis);end;
	set @sql = @sql + ''ORDER BY CODICE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgrammazioneequalthis INT, @Codiceequalthis VARCHAR(255)'',@IdProgrammazioneequalthis , @Codiceequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, CODICE, DESCRIZIONE
		FROM zOB_MISURA
		WHERE 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis)
		ORDER BY CODICE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZobMisuraFindFind';

