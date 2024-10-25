CREATE PROCEDURE [dbo].[ZTipoIrregolaritaFindFind]
(
	@Tipoequalthis VARCHAR(max), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_TIPO, TIPO, ATTIVO FROM VTIPO_IRREGOLARITA WHERE 1=1';
	IF (@Tipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO = @Tipoequalthis)'; set @lensql=@lensql+len(@Tipoequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Tipoequalthis VARCHAR(max), @Attivoequalthis BIT',@Tipoequalthis , @Attivoequalthis ;
	else
		SELECT ID_TIPO, TIPO, ATTIVO
		FROM VTIPO_IRREGOLARITA
		WHERE 
			((@Tipoequalthis IS NULL) OR TIPO = @Tipoequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		

GO