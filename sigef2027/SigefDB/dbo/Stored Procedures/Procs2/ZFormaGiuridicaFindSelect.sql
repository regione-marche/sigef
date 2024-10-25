CREATE PROCEDURE [dbo].[ZFormaGiuridicaFindSelect]
(
	@CodIstatequalthis VARCHAR(10), 
	@Descrizioneequalthis VARCHAR(255), 
	@Fogliaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_ISTAT, DESCRIZIONE, FOGLIA FROM FORMA_GIURIDICA WHERE 1=1';
	IF (@CodIstatequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ISTAT = @CodIstatequalthis)'; set @lensql=@lensql+len(@CodIstatequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Fogliaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FOGLIA = @Fogliaequalthis)'; set @lensql=@lensql+len(@Fogliaequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodIstatequalthis VARCHAR(10), @Descrizioneequalthis VARCHAR(255), @Fogliaequalthis BIT',@CodIstatequalthis , @Descrizioneequalthis , @Fogliaequalthis ;
	else
		SELECT COD_ISTAT, DESCRIZIONE, FOGLIA
		FROM FORMA_GIURIDICA
		WHERE 
			((@CodIstatequalthis IS NULL) OR COD_ISTAT = @CodIstatequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Fogliaequalthis IS NULL) OR FOGLIA = @Fogliaequalthis)
		-- order by ecc.ecc.
