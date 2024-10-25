CREATE PROCEDURE [dbo].[ZPageHelpFindSelect]
(
	@Idequalthis INT, 
	@Pageequalthis VARCHAR(255), 
	@Parametriequalthis VARCHAR(255), 
	@IdDocequalthis INT, 
	@IdPdfequalthis INT, 
	@Operatoreequalthis INT, 
	@Dataequalthis DATETIME, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, PAGE, PARAMETRI, ID_DOC, ID_PDF, OPERATORE, DATA, ATTIVO, TIPO, NOME_FILE, DIMENSIONE FROM vPAGE_HELP WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Pageequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PAGE = @Pageequalthis)'; set @lensql=@lensql+len(@Pageequalthis);end;
	IF (@Parametriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PARAMETRI = @Parametriequalthis)'; set @lensql=@lensql+len(@Parametriequalthis);end;
	IF (@IdDocequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOC = @IdDocequalthis)'; set @lensql=@lensql+len(@IdDocequalthis);end;
	IF (@IdPdfequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PDF = @IdPdfequalthis)'; set @lensql=@lensql+len(@IdPdfequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @Pageequalthis VARCHAR(255), @Parametriequalthis VARCHAR(255), @IdDocequalthis INT, @IdPdfequalthis INT, @Operatoreequalthis INT, @Dataequalthis DATETIME, @Attivoequalthis BIT',@Idequalthis , @Pageequalthis , @Parametriequalthis , @IdDocequalthis , @IdPdfequalthis , @Operatoreequalthis , @Dataequalthis , @Attivoequalthis ;
	else
		SELECT ID, PAGE, PARAMETRI, ID_DOC, ID_PDF, OPERATORE, DATA, ATTIVO, TIPO, NOME_FILE, DIMENSIONE
		FROM vPAGE_HELP
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Pageequalthis IS NULL) OR PAGE = @Pageequalthis) AND 
			((@Parametriequalthis IS NULL) OR PARAMETRI = @Parametriequalthis) AND 
			((@IdDocequalthis IS NULL) OR ID_DOC = @IdDocequalthis) AND 
			((@IdPdfequalthis IS NULL) OR ID_PDF = @IdPdfequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPageHelpFindSelect';

