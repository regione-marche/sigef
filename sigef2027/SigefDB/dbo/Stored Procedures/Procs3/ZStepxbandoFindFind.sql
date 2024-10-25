CREATE PROCEDURE [dbo].[ZStepxbandoFindFind]
(
	@IdBandoequalthis INT, 
	@IdCheckListequalthis INT, 
	@Ordineequalthis INT, 
	@CodFaseequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_CHECK_LIST, CHECK_LIST, COD_FASE, FASE_PROCEDURALE, ORDINE, FLAG_TEMPLATE FROM vSTEP_X_BANDO WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdCheckListequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECK_LIST = @IdCheckListequalthis)'; set @lensql=@lensql+len(@IdCheckListequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdCheckListequalthis INT, @Ordineequalthis INT, @CodFaseequalthis CHAR(1)',@IdBandoequalthis , @IdCheckListequalthis , @Ordineequalthis , @CodFaseequalthis ;
	else
		SELECT ID_BANDO, ID_CHECK_LIST, CHECK_LIST, COD_FASE, FASE_PROCEDURALE, ORDINE, FLAG_TEMPLATE
		FROM vSTEP_X_BANDO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdCheckListequalthis IS NULL) OR ID_CHECK_LIST = @IdCheckListequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)
		-- order by ecc.ecc.
