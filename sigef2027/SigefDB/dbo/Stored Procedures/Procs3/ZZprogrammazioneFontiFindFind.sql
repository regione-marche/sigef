CREATE PROCEDURE [dbo].[ZZprogrammazioneFontiFindFind]
(
	@IdProgrammazioneequalthis INT, 
	@IdFonteequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGRAMMAZIONE, ID_FONTE, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, ATTIVA, PERCENTUALE_FONTE, DESCRIZIONE, NOMINATIVO_INIZIO, NOMINATIVO_FINE FROM vzPROGRAMMAZIONE_FONTI WHERE 1=1';
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@IdFonteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FONTE = @IdFonteequalthis)'; set @lensql=@lensql+len(@IdFonteequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgrammazioneequalthis INT, @IdFonteequalthis INT',@IdProgrammazioneequalthis , @IdFonteequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, ID_FONTE, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, ATTIVA, PERCENTUALE_FONTE, DESCRIZIONE, NOMINATIVO_INIZIO, NOMINATIVO_FINE
		FROM vzPROGRAMMAZIONE_FONTI
		WHERE 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@IdFonteequalthis IS NULL) OR ID_FONTE = @IdFonteequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneFontiFindFind';

