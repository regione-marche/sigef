
CREATE PROCEDURE [dbo].ZLocalizzazioneProgettofindselect
(
	@IdLocalizzazioneequalthis INT, 
	@IdProgettoequalthis INT, 
	@Idmpresaqualthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT * FROM vLOCALIZZAZIONE_PROGETTO WHERE 1=1';
	IF (@IdLocalizzazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOCALIZZAZIONE = @IdLocalizzazioneequalthis)'; set @lensql=@lensql+len(@IdLocalizzazioneequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Idmpresaqualthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @Idmpresaqualthis)'; set @lensql=@lensql+len(@Idmpresaqualthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLocalizzazioneequalthis INT, @IdProgettoequalthis INT, @Idmpresaqualthis INT',@IdLocalizzazioneequalthis , @IdProgettoequalthis, @Idmpresaqualthis;
	else
		SELECT *
		FROM vLOCALIZZAZIONE_PROGETTO
		WHERE 
			((@IdLocalizzazioneequalthis IS NULL) OR ID_LOCALIZZAZIONE = @IdLocalizzazioneequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Idmpresaqualthis IS NULL) OR ID_IMPRESA = @Idmpresaqualthis)
		-- order by ecc.ecc.

