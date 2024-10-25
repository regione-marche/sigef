CREATE PROCEDURE [dbo].[ZValoriPrioritaFindSelect]
(
	@IdValoreequalthis INT, 
	@IdPrioritaequalthis INT, 
	@Descrizioneequalthis VARCHAR(500), 
	@Codiceequalthis VARCHAR(255), 
	@Punteggioequalthis DECIMAL(10,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VALORE, ID_PRIORITA, DESCRIZIONE, CODICE, PUNTEGGIO FROM VALORI_PRIORITA WHERE 1=1';
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VALORE = @IdValoreequalthis)'; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Punteggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PUNTEGGIO = @Punteggioequalthis)'; set @lensql=@lensql+len(@Punteggioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdValoreequalthis INT, @IdPrioritaequalthis INT, @Descrizioneequalthis VARCHAR(500), @Codiceequalthis VARCHAR(255), @Punteggioequalthis DECIMAL(10,2)',@IdValoreequalthis , @IdPrioritaequalthis , @Descrizioneequalthis , @Codiceequalthis , @Punteggioequalthis ;
	else
		SELECT ID_VALORE, ID_PRIORITA, DESCRIZIONE, CODICE, PUNTEGGIO
		FROM VALORI_PRIORITA
		WHERE 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Punteggioequalthis IS NULL) OR PUNTEGGIO = @Punteggioequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZValoriPrioritaFindSelect]
(
	@IdValoreequalthis INT, 
	@IdPrioritaequalthis INT, 
	@Descrizioneequalthis VARCHAR(500), 
	@Codiceequalthis VARCHAR(10), 
	@Punteggioequalthis DECIMAL(10,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_VALORE, ID_PRIORITA, DESCRIZIONE, CODICE, PUNTEGGIO FROM VALORI_PRIORITA WHERE 1=1'';
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VALORE = @IdValoreequalthis)''; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE = @Codiceequalthis)''; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Punteggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PUNTEGGIO = @Punteggioequalthis)''; set @lensql=@lensql+len(@Punteggioequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdValoreequalthis INT, @IdPrioritaequalthis INT, @Descrizioneequalthis VARCHAR(500), @Codiceequalthis VARCHAR(10), @Punteggioequalthis DECIMAL(10,5)'',@IdValoreequalthis , @IdPrioritaequalthis , @Descrizioneequalthis , @Codiceequalthis , @Punteggioequalthis ;
	else
		SELECT ID_VALORE, ID_PRIORITA, DESCRIZIONE, CODICE, PUNTEGGIO
		FROM VALORI_PRIORITA
		WHERE 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Punteggioequalthis IS NULL) OR PUNTEGGIO = @Punteggioequalthis)
		-- order by ecc.ecc.
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZValoriPrioritaFindSelect';

