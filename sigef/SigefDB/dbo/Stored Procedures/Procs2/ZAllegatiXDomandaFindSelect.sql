CREATE PROCEDURE [dbo].[ZAllegatiXDomandaFindSelect]
(
	@IdAllegatoequalthis INT, 
	@IdDomandaequalthis INT, 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO, ID_DOMANDA, ORDINE, DESCRIZIONE, MISURA, COD_TIPO, TIPO_ALLEGATO FROM vALLEGATI_X_DOMANDA WHERE 1=1';
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA = @IdDomandaequalthis)'; set @lensql=@lensql+len(@IdDomandaequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAllegatoequalthis INT, @IdDomandaequalthis INT, @Ordineequalthis INT',@IdAllegatoequalthis , @IdDomandaequalthis , @Ordineequalthis ;
	else
		SELECT ID_ALLEGATO, ID_DOMANDA, ORDINE, DESCRIZIONE, MISURA, COD_TIPO, TIPO_ALLEGATO
		FROM vALLEGATI_X_DOMANDA
		WHERE 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@IdDomandaequalthis IS NULL) OR ID_DOMANDA = @IdDomandaequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAllegatiXDomandaFindSelect]
(
	@IdAllegatoequalthis INT, 
	@IdDomandaequalthis INT, 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ALLEGATO, ID_DOMANDA, ORDINE, DESCRIZIONE, MISURA FROM vALLEGATI WHERE 1=1'';
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ALLEGATO = @IdAllegatoequalthis)''; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA = @IdDomandaequalthis)''; set @lensql=@lensql+len(@IdDomandaequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdAllegatoequalthis INT, @IdDomandaequalthis INT, @Ordineequalthis INT'',@IdAllegatoequalthis , @IdDomandaequalthis , @Ordineequalthis ;
	else
		SELECT ID_ALLEGATO, ID_DOMANDA, ORDINE, DESCRIZIONE, MISURA
		FROM vALLEGATI
		WHERE 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@IdDomandaequalthis IS NULL) OR ID_DOMANDA = @IdDomandaequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiXDomandaFindSelect';

