CREATE PROCEDURE [dbo].[ZZstpFindFind]
(
	@IdProgrammazioneequalthis INT, 
	@Codiceequalthis VARCHAR(255), 
	@Descrizionelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGRAMMAZIONE, CODICE, DESCRIZIONE, PROGRAMMAZIONE, PSR, ANNO_DA, ANNO_A FROM vzSTP WHERE 1=1';
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @sql = @sql + 'ORDER BY ANNO_DA+ANNO_A DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgrammazioneequalthis INT, @Codiceequalthis VARCHAR(255), @Descrizionelikethis VARCHAR(255)',@IdProgrammazioneequalthis , @Codiceequalthis , @Descrizionelikethis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, CODICE, DESCRIZIONE, PROGRAMMAZIONE, PSR, ANNO_DA, ANNO_A
		FROM vzSTP
		WHERE 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis)
		ORDER BY ANNO_DA+ANNO_A DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZstpFindFind';

