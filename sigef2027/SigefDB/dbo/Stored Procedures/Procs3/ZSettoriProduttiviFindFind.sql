CREATE PROCEDURE [dbo].[ZSettoriProduttiviFindFind]
(
	@IdSettoreProduttivoequalthis INT, 
	@Descrizionelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SETTORE_PRODUTTIVO, DESCRIZIONE FROM SETTORI_PRODUTTIVI WHERE 1=1';
	IF (@IdSettoreProduttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis)'; set @lensql=@lensql+len(@IdSettoreProduttivoequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	set @sql = @sql + 'ORDER BY DESCRIZIONE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSettoreProduttivoequalthis INT, @Descrizionelikethis VARCHAR(255)',@IdSettoreProduttivoequalthis , @Descrizionelikethis ;
	else
		SELECT ID_SETTORE_PRODUTTIVO, DESCRIZIONE
		FROM SETTORI_PRODUTTIVI
		WHERE 
			((@IdSettoreProduttivoequalthis IS NULL) OR ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis)
		ORDER BY DESCRIZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE  PROCEDURE [dbo].[ZSettoriProduttiviFindFind]
(
	@IdSettoreProduttivoequalthis INT, 
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_SETTORE_PRODUTTIVO, ID_BANDO, DESCRIZIONE FROM SETTORI_PRODUTTIVI WHERE 1=1'';
	IF (@IdSettoreProduttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis)''; set @lensql=@lensql+len(@IdSettoreProduttivoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdSettoreProduttivoequalthis INT, @IdBandoequalthis INT'',@IdSettoreProduttivoequalthis , @IdBandoequalthis ;
	else
		SELECT ID_SETTORE_PRODUTTIVO, ID_BANDO, DESCRIZIONE
		FROM SETTORI_PRODUTTIVI
		WHERE 
			((@IdSettoreProduttivoequalthis IS NULL) OR ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)
		-- order by ecc.ecc.

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSettoriProduttiviFindFind';

