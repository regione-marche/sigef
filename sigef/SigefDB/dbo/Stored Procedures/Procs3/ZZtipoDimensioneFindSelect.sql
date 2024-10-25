
CREATE PROCEDURE [dbo].[ZZtipoDimensioneFindSelect]
(
	@CodDimequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(255), 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_DIM, DESCRIZIONE, ORDINE FROM zTIPO_DIMENSIONE WHERE 1=1';
	IF (@CodDimequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_DIM = @CodDimequalthis)'; set @lensql=@lensql+len(@CodDimequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodDimequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(255), @Ordineequalthis INT',@CodDimequalthis , @Descrizioneequalthis , @Ordineequalthis ;
	else
		SELECT COD_DIM, DESCRIZIONE, ORDINE
		FROM zTIPO_DIMENSIONE
		WHERE 
			((@CodDimequalthis IS NULL) OR COD_DIM = @CodDimequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		


