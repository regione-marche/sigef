CREATE PROCEDURE [dbo].[ZProgettoRelazioneTecnicaFindFind]
(
	@IdProgettoequalthis INT, 
	@IdBandoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PARAGRAFO, ID_PROGETTO, TESTO, ID_BANDO, DESCRIZIONE, TITOLO, ORDINE FROM vPROGETTO_RELAZIONE_TECNICA WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	set @sql = @sql + 'ORDER BY ORDINE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdBandoequalthis INT',@IdProgettoequalthis , @IdBandoequalthis ;
	else
		SELECT ID_PARAGRAFO, ID_PROGETTO, TESTO, ID_BANDO, DESCRIZIONE, TITOLO, ORDINE
		FROM vPROGETTO_RELAZIONE_TECNICA
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis)
		ORDER BY ORDINE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProgettoRelazioneTecnicaFindFind]
(
	@IdParagrafoequalthis INT, 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PARAGRAFO, ID_PROGETTO, TESTO FROM PROGETTO_RELAZIONE_TECNICA WHERE 1=1'';
	IF (@IdParagrafoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PARAGRAFO = @IdParagrafoequalthis)''; set @lensql=@lensql+len(@IdParagrafoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdParagrafoequalthis INT, @IdProgettoequalthis INT'',@IdParagrafoequalthis , @IdProgettoequalthis ;
	else
		SELECT ID_PARAGRAFO, ID_PROGETTO, TESTO
		FROM PROGETTO_RELAZIONE_TECNICA
		WHERE 
			((@IdParagrafoequalthis IS NULL) OR ID_PARAGRAFO = @IdParagrafoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoRelazioneTecnicaFindFind';

