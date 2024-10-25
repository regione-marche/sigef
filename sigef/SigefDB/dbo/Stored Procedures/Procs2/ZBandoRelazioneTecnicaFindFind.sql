CREATE PROCEDURE [dbo].[ZBandoRelazioneTecnicaFindFind]
(
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PARAGRAFO, ID_BANDO, DESCRIZIONE, TITOLO, ORDINE FROM BANDO_RELAZIONE_TECNICA WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @sql = @sql + 'ORDER BY ORDINE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT',@IdBandoequalthis ;
	else
		SELECT ID_PARAGRAFO, ID_BANDO, DESCRIZIONE, TITOLO, ORDINE
		FROM BANDO_RELAZIONE_TECNICA
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)
		ORDER BY ORDINE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoRelazioneTecnicaFindFind]
(
	@IdParagrafoequalthis INT, 
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PARAGRAFO, ID_BANDO, DESCRIZIONE, TITOLO FROM BANDO_RELAZIONE_TECNICA WHERE 1=1'';
	IF (@IdParagrafoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PARAGRAFO = @IdParagrafoequalthis)''; set @lensql=@lensql+len(@IdParagrafoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdParagrafoequalthis INT, @IdBandoequalthis INT'',@IdParagrafoequalthis , @IdBandoequalthis ;
	else
		SELECT ID_PARAGRAFO, ID_BANDO, DESCRIZIONE, TITOLO
		FROM BANDO_RELAZIONE_TECNICA
		WHERE 
			((@IdParagrafoequalthis IS NULL) OR ID_PARAGRAFO = @IdParagrafoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRelazioneTecnicaFindFind';

