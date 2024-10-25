CREATE PROCEDURE [dbo].[ZSettoriProduttiviFindSelect]
(
	@IdSettoreProduttivoequalthis INT, 
	@Descrizioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SETTORE_PRODUTTIVO, DESCRIZIONE FROM SETTORI_PRODUTTIVI WHERE 1=1';
	IF (@IdSettoreProduttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis)'; set @lensql=@lensql+len(@IdSettoreProduttivoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSettoreProduttivoequalthis INT, @Descrizioneequalthis VARCHAR(255)',@IdSettoreProduttivoequalthis , @Descrizioneequalthis ;
	else
		SELECT ID_SETTORE_PRODUTTIVO, DESCRIZIONE
		FROM SETTORI_PRODUTTIVI
		WHERE 
			((@IdSettoreProduttivoequalthis IS NULL) OR ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'





CREATE  PROCEDURE [dbo].[ZSettoriProduttiviFindSelect]
(
	@IdSettoreProduttivoequalthis INT, 
	@IdBandoequalthis INT, 
	@Descrizioneequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_SETTORE_PRODUTTIVO, ID_BANDO, DESCRIZIONE FROM SETTORI_PRODUTTIVI WHERE 1=1'';
	IF (@IdSettoreProduttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis)''; set @lensql=@lensql+len(@IdSettoreProduttivoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdSettoreProduttivoequalthis INT, @IdBandoequalthis INT, @Descrizioneequalthis VARCHAR(255)'',@IdSettoreProduttivoequalthis , @IdBandoequalthis , @Descrizioneequalthis ;
	else
		SELECT ID_SETTORE_PRODUTTIVO, ID_BANDO, DESCRIZIONE
		FROM SETTORI_PRODUTTIVI
		WHERE 
			((@IdSettoreProduttivoequalthis IS NULL) OR ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)
		-- order by ecc.ecc.

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSettoriProduttiviFindSelect';

