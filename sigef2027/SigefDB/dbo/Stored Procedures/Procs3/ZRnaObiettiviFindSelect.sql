CREATE PROCEDURE [dbo].[ZRnaObiettiviFindSelect]
(
	@IdObiettivoequalthis INT, 
	@CodiceRegolamentoequalthis VARCHAR(255), 
	@Regolamentoequalthis VARCHAR(max), 
	@CodObiettivoequalthis VARCHAR(255), 
	@MacroObiettivoequalthis VARCHAR(500), 
	@Obiettivoequalthis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_OBIETTIVO, CODICE_REGOLAMENTO, REGOLAMENTO, COD_OBIETTIVO, MACRO_OBIETTIVO, OBIETTIVO FROM RNA_OBIETTIVI WHERE 1=1';
	IF (@IdObiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OBIETTIVO = @IdObiettivoequalthis)'; set @lensql=@lensql+len(@IdObiettivoequalthis);end;
	IF (@CodiceRegolamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_REGOLAMENTO = @CodiceRegolamentoequalthis)'; set @lensql=@lensql+len(@CodiceRegolamentoequalthis);end;
	IF (@Regolamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REGOLAMENTO = @Regolamentoequalthis)'; set @lensql=@lensql+len(@Regolamentoequalthis);end;
	IF (@CodObiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_OBIETTIVO = @CodObiettivoequalthis)'; set @lensql=@lensql+len(@CodObiettivoequalthis);end;
	IF (@MacroObiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MACRO_OBIETTIVO = @MacroObiettivoequalthis)'; set @lensql=@lensql+len(@MacroObiettivoequalthis);end;
	IF (@Obiettivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OBIETTIVO = @Obiettivoequalthis)'; set @lensql=@lensql+len(@Obiettivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdObiettivoequalthis INT, @CodiceRegolamentoequalthis VARCHAR(255), @Regolamentoequalthis VARCHAR(max), @CodObiettivoequalthis VARCHAR(255), @MacroObiettivoequalthis VARCHAR(500), @Obiettivoequalthis VARCHAR(500)',@IdObiettivoequalthis , @CodiceRegolamentoequalthis , @Regolamentoequalthis , @CodObiettivoequalthis , @MacroObiettivoequalthis , @Obiettivoequalthis ;
	else
		SELECT ID_OBIETTIVO, CODICE_REGOLAMENTO, REGOLAMENTO, COD_OBIETTIVO, MACRO_OBIETTIVO, OBIETTIVO
		FROM RNA_OBIETTIVI
		WHERE 
			((@IdObiettivoequalthis IS NULL) OR ID_OBIETTIVO = @IdObiettivoequalthis) AND 
			((@CodiceRegolamentoequalthis IS NULL) OR CODICE_REGOLAMENTO = @CodiceRegolamentoequalthis) AND 
			((@Regolamentoequalthis IS NULL) OR REGOLAMENTO = @Regolamentoequalthis) AND 
			((@CodObiettivoequalthis IS NULL) OR COD_OBIETTIVO = @CodObiettivoequalthis) AND 
			((@MacroObiettivoequalthis IS NULL) OR MACRO_OBIETTIVO = @MacroObiettivoequalthis) AND 
			((@Obiettivoequalthis IS NULL) OR OBIETTIVO = @Obiettivoequalthis)