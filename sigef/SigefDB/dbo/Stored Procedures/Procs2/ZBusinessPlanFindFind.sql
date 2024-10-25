CREATE PROCEDURE [dbo].[ZBusinessPlanFindFind]
(
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_QUADRO, ORDINE, QUADRO, URL, TITOLO, ORDINE_QUADRI, DOMANDA FROM vBUSINESS_PLAN WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @sql = @sql + 'ORDER BY ORDINE, ORDINE_QUADRI';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT',@IdBandoequalthis ;
	else
		SELECT ID_BANDO, ID_QUADRO, ORDINE, QUADRO, URL, TITOLO, ORDINE_QUADRI, DOMANDA
		FROM vBUSINESS_PLAN
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)
		ORDER BY ORDINE, ORDINE_QUADRI

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBusinessPlanFindFind]
(
	@IdBandoequalthis INT, 
	@IdQuadroequalthis INT, 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_BANDO, ID_QUADRO, ORDINE, QUADRO, URL, TITOLO, ORDINE_QUADRI, DOMANDA FROM vBUSINESS_PLAN WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdQuadroequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_QUADRO = @IdQuadroequalthis)''; set @lensql=@lensql+len(@IdQuadroequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	SET @sql = @sql + ''ORDER BY ORDINE_QUADRI'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT, @IdQuadroequalthis INT, @Ordineequalthis INT'',@IdBandoequalthis , @IdQuadroequalthis , @Ordineequalthis ;
	else
		SELECT ID_BANDO, ID_QUADRO, ORDINE, QUADRO, URL, TITOLO, ORDINE_QUADRI, DOMANDA
		FROM vBUSINESS_PLAN
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdQuadroequalthis IS NULL) OR ID_QUADRO = @IdQuadroequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
	ORDER BY ORDINE_QUADRI

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBusinessPlanFindFind';

