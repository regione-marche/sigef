CREATE PROCEDURE [dbo].[ZZprogrammazioneFontiFindSelect]
(
	@Idequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@IdFonteequalthis INT, 
	@Percentualeequalthis DECIMAL(10,2), 
	@DataInizioequalthis DATETIME, 
	@OperatoreInizioequalthis INT, 
	@DataFineequalthis DATETIME, 
	@OperatoreFineequalthis INT, 
	@Attivaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGRAMMAZIONE, ID_FONTE, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, ATTIVA, PERCENTUALE_FONTE, DESCRIZIONE, NOMINATIVO_INIZIO, NOMINATIVO_FINE FROM vzPROGRAMMAZIONE_FONTI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@IdFonteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FONTE = @IdFonteequalthis)'; set @lensql=@lensql+len(@IdFonteequalthis);end;
	IF (@Percentualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PERCENTUALE = @Percentualeequalthis)'; set @lensql=@lensql+len(@Percentualeequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@OperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_INIZIO = @OperatoreInizioequalthis)'; set @lensql=@lensql+len(@OperatoreInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@OperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_FINE = @OperatoreFineequalthis)'; set @lensql=@lensql+len(@OperatoreFineequalthis);end;
	IF (@Attivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVA = @Attivaequalthis)'; set @lensql=@lensql+len(@Attivaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdProgrammazioneequalthis INT, @IdFonteequalthis INT, @Percentualeequalthis DECIMAL(10,2), @DataInizioequalthis DATETIME, @OperatoreInizioequalthis INT, @DataFineequalthis DATETIME, @OperatoreFineequalthis INT, @Attivaequalthis BIT',@Idequalthis , @IdProgrammazioneequalthis , @IdFonteequalthis , @Percentualeequalthis , @DataInizioequalthis , @OperatoreInizioequalthis , @DataFineequalthis , @OperatoreFineequalthis , @Attivaequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, ID_FONTE, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, ATTIVA, PERCENTUALE_FONTE, DESCRIZIONE, NOMINATIVO_INIZIO, NOMINATIVO_FINE
		FROM vzPROGRAMMAZIONE_FONTI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@IdFonteequalthis IS NULL) OR ID_FONTE = @IdFonteequalthis) AND 
			((@Percentualeequalthis IS NULL) OR PERCENTUALE = @Percentualeequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@OperatoreInizioequalthis IS NULL) OR OPERATORE_INIZIO = @OperatoreInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@OperatoreFineequalthis IS NULL) OR OPERATORE_FINE = @OperatoreFineequalthis) AND 
			((@Attivaequalthis IS NULL) OR ATTIVA = @Attivaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneFontiFindSelect';

