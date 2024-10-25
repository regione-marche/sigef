CREATE PROCEDURE [dbo].[ZAllegatiFindFind]
(
	@CodTipoequalthis VARCHAR(255), 
	@Descrizionelikethis VARCHAR(1000), 
	@Misuralikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO, DESCRIZIONE, MISURA, COD_TIPO, COD_TIPO_ENTE_EMETTITORE FROM ALLEGATI WHERE 1=1';
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE LIKE @Descrizionelikethis)'; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@Misuralikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA LIKE @Misuralikethis)'; set @lensql=@lensql+len(@Misuralikethis);end;
	set @sql = @sql + 'ORDER BY MISURA';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoequalthis VARCHAR(255), @Descrizionelikethis VARCHAR(1000), @Misuralikethis VARCHAR(255)',@CodTipoequalthis , @Descrizionelikethis , @Misuralikethis ;
	else
		SELECT ID_ALLEGATO, DESCRIZIONE, MISURA, COD_TIPO, COD_TIPO_ENTE_EMETTITORE
		FROM ALLEGATI
		WHERE 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@Misuralikethis IS NULL) OR MISURA LIKE @Misuralikethis)
		ORDER BY MISURA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZAllegatiFindFind]
(
	@CodTipoequalthis VARCHAR(255), 
	@Descrizionelikethis VARCHAR(1000), 
	@Misuralikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ALLEGATO, DESCRIZIONE, MISURA, COD_TIPO FROM ALLEGATI WHERE 1=1'';
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Descrizionelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE LIKE @Descrizionelikethis)''; set @lensql=@lensql+len(@Descrizionelikethis);end;
	IF (@Misuralikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MISURA LIKE @Misuralikethis)''; set @lensql=@lensql+len(@Misuralikethis);end;
	set @sql = @sql + ''ORDER BY MISURA'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@CodTipoequalthis VARCHAR(255), @Descrizionelikethis VARCHAR(1000), @Misuralikethis VARCHAR(255)'',@CodTipoequalthis , @Descrizionelikethis , @Misuralikethis ;
	else
		SELECT ID_ALLEGATO, DESCRIZIONE, MISURA, COD_TIPO
		FROM ALLEGATI
		WHERE 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Descrizionelikethis IS NULL) OR DESCRIZIONE LIKE @Descrizionelikethis) AND 
			((@Misuralikethis IS NULL) OR MISURA LIKE @Misuralikethis)
		ORDER BY MISURA
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiFindFind';

