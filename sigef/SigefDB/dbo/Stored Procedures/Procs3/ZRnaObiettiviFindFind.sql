CREATE PROCEDURE [dbo].[ZRnaObiettiviFindFind]
(
	@CodiceRegolamentoequalthis VARCHAR(255), 
	@IdObiettivoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_OBIETTIVO, CODICE_REGOLAMENTO, REGOLAMENTO, COD_OBIETTIVO, MACRO_OBIETTIVO, OBIETTIVO FROM RNA_OBIETTIVI WHERE 1=1';
	IF (@CodiceRegolamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_REGOLAMENTO = @CodiceRegolamentoequalthis)'; set @lensql=@lensql+len(@CodiceRegolamentoequalthis);end;
	IF (@IdObiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OBIETTIVO = @IdObiettivoequalthis)'; set @lensql=@lensql+len(@IdObiettivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodiceRegolamentoequalthis VARCHAR(255), @IdObiettivoequalthis INT',@CodiceRegolamentoequalthis , @IdObiettivoequalthis ;
	else
		SELECT ID_OBIETTIVO, CODICE_REGOLAMENTO, REGOLAMENTO, COD_OBIETTIVO, MACRO_OBIETTIVO, OBIETTIVO
		FROM RNA_OBIETTIVI
		WHERE 
			((@CodiceRegolamentoequalthis IS NULL) OR CODICE_REGOLAMENTO = @CodiceRegolamentoequalthis) AND 
			((@IdObiettivoequalthis IS NULL) OR ID_OBIETTIVO = @IdObiettivoequalthis)