CREATE PROCEDURE [dbo].[ZPageHelpFindFind]
(
	@Pageequalthis VARCHAR(255), 
	@Parametrilikethis VARCHAR(255), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, PAGE, PARAMETRI, ID_DOC, ID_PDF, OPERATORE, DATA, ATTIVO, TIPO, NOME_FILE, DIMENSIONE FROM vPAGE_HELP WHERE 1=1';
	IF (@Pageequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PAGE = @Pageequalthis)'; set @lensql=@lensql+len(@Pageequalthis);end;
	IF (@Parametrilikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PARAMETRI LIKE @Parametrilikethis)'; set @lensql=@lensql+len(@Parametrilikethis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY ATTIVO DESC, DATA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Pageequalthis VARCHAR(255), @Parametrilikethis VARCHAR(255), @Attivoequalthis BIT',@Pageequalthis , @Parametrilikethis , @Attivoequalthis ;
	else
		SELECT ID, PAGE, PARAMETRI, ID_DOC, ID_PDF, OPERATORE, DATA, ATTIVO, TIPO, NOME_FILE, DIMENSIONE
		FROM vPAGE_HELP
		WHERE 
			((@Pageequalthis IS NULL) OR PAGE = @Pageequalthis) AND 
			((@Parametrilikethis IS NULL) OR PARAMETRI LIKE @Parametrilikethis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY ATTIVO DESC, DATA DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPageHelpFindFind';

