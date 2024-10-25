CREATE PROCEDURE [dbo].[ZDichiarazioniXProgettoFindFind]
(
	@IdDichiarazioneequalthis INT, 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DICHIARAZIONE, ID_PROGETTO FROM DICHIARAZIONI_X_PROGETTO WHERE 1=1';
	IF (@IdDichiarazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DICHIARAZIONE = @IdDichiarazioneequalthis)'; set @lensql=@lensql+len(@IdDichiarazioneequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDichiarazioneequalthis INT, @IdProgettoequalthis INT',@IdDichiarazioneequalthis , @IdProgettoequalthis ;
	else
		SELECT ID_DICHIARAZIONE, ID_PROGETTO
		FROM DICHIARAZIONI_X_PROGETTO
		WHERE 
			((@IdDichiarazioneequalthis IS NULL) OR ID_DICHIARAZIONE = @IdDichiarazioneequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis)
		-- order by ecc.ecc.
