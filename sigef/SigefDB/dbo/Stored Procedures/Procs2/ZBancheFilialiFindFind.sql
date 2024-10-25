CREATE PROCEDURE [dbo].[ZBancheFilialiFindFind]
(
	@Abiequalthis VARCHAR(255), 
	@Cablikethis VARCHAR(255), 
	@Notelikethis VARCHAR(255), 
	@Provinciaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ABI, CAB, NOTE, INDIRIZZO, ID_COMUNE, COMUNE, PROVINCIA, CAP, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ATTIVO FROM BANCHE_FILIALI WHERE 1=1';
	IF (@Abiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ABI = @Abiequalthis)'; set @lensql=@lensql+len(@Abiequalthis);end;
	IF (@Cablikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CAB LIKE @Cablikethis)'; set @lensql=@lensql+len(@Cablikethis);end;
	IF (@Notelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE LIKE @Notelikethis)'; set @lensql=@lensql+len(@Notelikethis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	set @sql = @sql + 'ORDER BY ID';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Abiequalthis VARCHAR(255), @Cablikethis VARCHAR(255), @Notelikethis VARCHAR(255), @Provinciaequalthis VARCHAR(255)',@Abiequalthis , @Cablikethis , @Notelikethis , @Provinciaequalthis ;
	else
		SELECT ID, ABI, CAB, NOTE, INDIRIZZO, ID_COMUNE, COMUNE, PROVINCIA, CAP, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ATTIVO
		FROM BANCHE_FILIALI
		WHERE 
			((@Abiequalthis IS NULL) OR ABI = @Abiequalthis) AND 
			((@Cablikethis IS NULL) OR CAB LIKE @Cablikethis) AND 
			((@Notelikethis IS NULL) OR NOTE LIKE @Notelikethis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis)
		ORDER BY ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheFilialiFindFind';

