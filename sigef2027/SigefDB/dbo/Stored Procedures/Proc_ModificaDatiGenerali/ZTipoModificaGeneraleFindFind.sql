CREATE PROCEDURE [dbo].[ZTipoModificaGeneraleFindFind]
(
	@IdTipoModificaequalthis INT, 
	@Descrizioneequalthis VARCHAR(max), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_TIPO_MODIFICA, DESCRIZIONE, ATTIVO FROM VTIPO_MODIFICA_GENERALE WHERE 1=1';
	IF (@IdTipoModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_MODIFICA = @IdTipoModificaequalthis)'; set @lensql=@lensql+len(@IdTipoModificaequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdTipoModificaequalthis INT, @Descrizioneequalthis VARCHAR(max), @Attivoequalthis BIT',@IdTipoModificaequalthis , @Descrizioneequalthis , @Attivoequalthis ;
	else
		SELECT ID_TIPO_MODIFICA, DESCRIZIONE, ATTIVO
		FROM VTIPO_MODIFICA_GENERALE
		WHERE 
			((@IdTipoModificaequalthis IS NULL) OR ID_TIPO_MODIFICA = @IdTipoModificaequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		

GO