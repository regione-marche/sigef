CREATE PROCEDURE [dbo].[ZAllegatiFindSelect]
(
	@IdAllegatoequalthis INT, 
	@Descrizioneequalthis VARCHAR(1000), 
	@Misuraequalthis VARCHAR(255), 
	@CodTipoequalthis VARCHAR(255), 
	@CodTipoEnteEmettitoreequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO, DESCRIZIONE, MISURA, COD_TIPO, COD_TIPO_ENTE_EMETTITORE FROM ALLEGATI WHERE 1=1';
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA = @Misuraequalthis)'; set @lensql=@lensql+len(@Misuraequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@CodTipoEnteEmettitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_ENTE_EMETTITORE = @CodTipoEnteEmettitoreequalthis)'; set @lensql=@lensql+len(@CodTipoEnteEmettitoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAllegatoequalthis INT, @Descrizioneequalthis VARCHAR(1000), @Misuraequalthis VARCHAR(255), @CodTipoequalthis VARCHAR(255), @CodTipoEnteEmettitoreequalthis VARCHAR(255)',@IdAllegatoequalthis , @Descrizioneequalthis , @Misuraequalthis , @CodTipoequalthis , @CodTipoEnteEmettitoreequalthis ;
	else
		SELECT ID_ALLEGATO, DESCRIZIONE, MISURA, COD_TIPO, COD_TIPO_ENTE_EMETTITORE
		FROM ALLEGATI
		WHERE 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@CodTipoEnteEmettitoreequalthis IS NULL) OR COD_TIPO_ENTE_EMETTITORE = @CodTipoEnteEmettitoreequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZAllegatiFindSelect]
(
	@IdAllegatoequalthis INT, 
	@Descrizioneequalthis VARCHAR(1000), 
	@Misuraequalthis VARCHAR(255), 
	@CodTipoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ALLEGATO, DESCRIZIONE, MISURA, COD_TIPO FROM ALLEGATI WHERE 1=1'';
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ALLEGATO = @IdAllegatoequalthis)''; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MISURA = @Misuraequalthis)''; set @lensql=@lensql+len(@Misuraequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdAllegatoequalthis INT, @Descrizioneequalthis VARCHAR(1000), @Misuraequalthis VARCHAR(255), @CodTipoequalthis VARCHAR(255)'',@IdAllegatoequalthis , @Descrizioneequalthis , @Misuraequalthis , @CodTipoequalthis ;
	else
		SELECT ID_ALLEGATO, DESCRIZIONE, MISURA, COD_TIPO
		FROM ALLEGATI
		WHERE 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiFindSelect';

