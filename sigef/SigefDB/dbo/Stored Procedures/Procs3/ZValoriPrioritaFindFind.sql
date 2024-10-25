CREATE PROCEDURE [dbo].[ZValoriPrioritaFindFind]
(
	@IdValoreequalthis INT, 
	@IdPrioritaequalthis INT, 
	@Codiceequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VALORE, ID_PRIORITA, DESCRIZIONE, CODICE, PUNTEGGIO FROM VALORI_PRIORITA WHERE 1=1';
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VALORE = @IdValoreequalthis)'; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdValoreequalthis INT, @IdPrioritaequalthis INT, @Codiceequalthis VARCHAR(255)',@IdValoreequalthis , @IdPrioritaequalthis , @Codiceequalthis ;
	else
		SELECT ID_VALORE, ID_PRIORITA, DESCRIZIONE, CODICE, PUNTEGGIO
		FROM VALORI_PRIORITA
		WHERE 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZValoriPrioritaFindFind]
(
	@IdValoreequalthis INT, 
	@IdPrioritaequalthis INT, 
	@Codiceequalthis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_VALORE, ID_PRIORITA, DESCRIZIONE, CODICE, PUNTEGGIO FROM VALORI_PRIORITA WHERE 1=1'';
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VALORE = @IdValoreequalthis)''; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE = @Codiceequalthis)''; set @lensql=@lensql+len(@Codiceequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdValoreequalthis INT, @IdPrioritaequalthis INT, @Codiceequalthis VARCHAR(10)'',@IdValoreequalthis , @IdPrioritaequalthis , @Codiceequalthis ;
	else
		SELECT ID_VALORE, ID_PRIORITA, DESCRIZIONE, CODICE, PUNTEGGIO
		FROM VALORI_PRIORITA
		WHERE 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis)
		-- order by ecc.ecc.
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZValoriPrioritaFindFind';

