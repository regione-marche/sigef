CREATE PROCEDURE [dbo].[ZBandoRelazioneTecnicaFindSelect]
(
	@IdParagrafoequalthis INT, 
	@IdBandoequalthis INT, 
	@Descrizioneequalthis VARCHAR(2000), 
	@Titoloequalthis VARCHAR(255), 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PARAGRAFO, ID_BANDO, DESCRIZIONE, TITOLO, ORDINE FROM BANDO_RELAZIONE_TECNICA WHERE 1=1';
	IF (@IdParagrafoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PARAGRAFO = @IdParagrafoequalthis)'; set @lensql=@lensql+len(@IdParagrafoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Titoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TITOLO = @Titoloequalthis)'; set @lensql=@lensql+len(@Titoloequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdParagrafoequalthis INT, @IdBandoequalthis INT, @Descrizioneequalthis VARCHAR(2000), @Titoloequalthis VARCHAR(255), @Ordineequalthis INT',@IdParagrafoequalthis , @IdBandoequalthis , @Descrizioneequalthis , @Titoloequalthis , @Ordineequalthis ;
	else
		SELECT ID_PARAGRAFO, ID_BANDO, DESCRIZIONE, TITOLO, ORDINE
		FROM BANDO_RELAZIONE_TECNICA
		WHERE 
			((@IdParagrafoequalthis IS NULL) OR ID_PARAGRAFO = @IdParagrafoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Titoloequalthis IS NULL) OR TITOLO = @Titoloequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoRelazioneTecnicaFindSelect]
(
	@IdParagrafoequalthis INT, 
	@IdBandoequalthis INT, 
	@Titoloequalthis VARCHAR(100)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PARAGRAFO, ID_BANDO, DESCRIZIONE, TITOLO FROM BANDO_RELAZIONE_TECNICA WHERE 1=1'';
	IF (@IdParagrafoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PARAGRAFO = @IdParagrafoequalthis)''; set @lensql=@lensql+len(@IdParagrafoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Titoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TITOLO = @Titoloequalthis)''; set @lensql=@lensql+len(@Titoloequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdParagrafoequalthis INT, @IdBandoequalthis INT, @Titoloequalthis VARCHAR(100)'',@IdParagrafoequalthis , @IdBandoequalthis , @Titoloequalthis ;
	else
		SELECT ID_PARAGRAFO, ID_BANDO, DESCRIZIONE, TITOLO
		FROM BANDO_RELAZIONE_TECNICA
		WHERE 
			((@IdParagrafoequalthis IS NULL) OR ID_PARAGRAFO = @IdParagrafoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Titoloequalthis IS NULL) OR TITOLO = @Titoloequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRelazioneTecnicaFindSelect';

