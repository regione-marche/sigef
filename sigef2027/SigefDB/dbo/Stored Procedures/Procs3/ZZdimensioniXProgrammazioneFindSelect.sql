
CREATE PROCEDURE [dbo].[ZZdimensioniXProgrammazioneFindSelect]
(
	@IdProgrammazioneequalthis INT, 
	@IdDimensioneequalthis INT, 
	@IdDimXProgrammazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGRAMMAZIONE, ID_DIMENSIONE, ID_DIM_X_PROGRAMMAZIONE, COD_DIM, COD_PROGRAMMAZIONE, DES_PROGRAMMAZIONE, LIVELLO_PROGRAMMAZIONE, COD_DIMENSIONE, DES_DIMENSIONE, UM FROM vzDIMENSIONI_X_PROGRAMMAZIONE WHERE 1=1';
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@IdDimensioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DIMENSIONE = @IdDimensioneequalthis)'; set @lensql=@lensql+len(@IdDimensioneequalthis);end;
	IF (@IdDimXProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DIM_X_PROGRAMMAZIONE = @IdDimXProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdDimXProgrammazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgrammazioneequalthis INT, @IdDimensioneequalthis INT, @IdDimXProgrammazioneequalthis INT',@IdProgrammazioneequalthis , @IdDimensioneequalthis , @IdDimXProgrammazioneequalthis ;
	else
		SELECT ID_PROGRAMMAZIONE, ID_DIMENSIONE, ID_DIM_X_PROGRAMMAZIONE, COD_DIM, COD_PROGRAMMAZIONE, DES_PROGRAMMAZIONE, LIVELLO_PROGRAMMAZIONE, COD_DIMENSIONE, DES_DIMENSIONE, UM
		FROM vzDIMENSIONI_X_PROGRAMMAZIONE
		WHERE 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@IdDimensioneequalthis IS NULL) OR ID_DIMENSIONE = @IdDimensioneequalthis) AND 
			((@IdDimXProgrammazioneequalthis IS NULL) OR ID_DIM_X_PROGRAMMAZIONE = @IdDimXProgrammazioneequalthis)
		

