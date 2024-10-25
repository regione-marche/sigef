CREATE PROCEDURE [dbo].[ZFormaGiuridicaFindFind]
(
	@CodIstatequalthis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_ISTAT, DESCRIZIONE, FOGLIA FROM FORMA_GIURIDICA WHERE 1=1';
	IF (@CodIstatequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ISTAT = @CodIstatequalthis)'; set @lensql=@lensql+len(@CodIstatequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodIstatequalthis VARCHAR(10)',@CodIstatequalthis ;
	else
		SELECT COD_ISTAT, DESCRIZIONE, FOGLIA
		FROM FORMA_GIURIDICA
		WHERE 
			((@CodIstatequalthis IS NULL) OR COD_ISTAT = @CodIstatequalthis)
		-- order by ecc.ecc.
