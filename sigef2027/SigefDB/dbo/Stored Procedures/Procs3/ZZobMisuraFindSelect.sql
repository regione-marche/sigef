CREATE PROCEDURE [dbo].[ZZobMisuraFindSelect]
(
	@Idequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@Codiceequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGRAMMAZIONE, CODICE, DESCRIZIONE FROM zOB_MISURA WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdProgrammazioneequalthis INT, @Codiceequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(500)',@Idequalthis , @IdProgrammazioneequalthis , @Codiceequalthis , @Descrizioneequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, CODICE, DESCRIZIONE
		FROM zOB_MISURA
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZobMisuraFindSelect]
(
	@Idequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@Codiceequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGRAMMAZIONE, CODICE, DESCRIZIONE FROM zOB_MISURA WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)''; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE = @Codiceequalthis)''; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdProgrammazioneequalthis INT, @Codiceequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(500)'',@Idequalthis , @IdProgrammazioneequalthis , @Codiceequalthis , @Descrizioneequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, CODICE, DESCRIZIONE
		FROM zOB_MISURA
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZobMisuraFindSelect';

