CREATE PROCEDURE [dbo].[ZZprogrammazioneSanzioniFindSelect]
(
	@Idequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@CodSanzioneequalthis VARCHAR(255), 
	@Attivaequalthis BIT, 
	@DataInizioequalthis DATETIME, 
	@OperatoreInizioequalthis INT, 
	@DataFineequalthis DATETIME, 
	@OperatoreFineequalthis INT, 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGRAMMAZIONE, COD_SANZIONE, ATTIVA, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, ORDINE, SANZIONE_TITOLO, SANZIONE_DESCRIZIONE, OPINIZIO_NOMINATIVO, OPFINE_NOMINATIVO FROM vZProgrammazione_Sanzioni WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@CodSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_SANZIONE = @CodSanzioneequalthis)'; set @lensql=@lensql+len(@CodSanzioneequalthis);end;
	IF (@Attivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVA = @Attivaequalthis)'; set @lensql=@lensql+len(@Attivaequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@OperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_INIZIO = @OperatoreInizioequalthis)'; set @lensql=@lensql+len(@OperatoreInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@OperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_FINE = @OperatoreFineequalthis)'; set @lensql=@lensql+len(@OperatoreFineequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdProgrammazioneequalthis INT, @CodSanzioneequalthis VARCHAR(255), @Attivaequalthis BIT, @DataInizioequalthis DATETIME, @OperatoreInizioequalthis INT, @DataFineequalthis DATETIME, @OperatoreFineequalthis INT, @Ordineequalthis INT',@Idequalthis , @IdProgrammazioneequalthis , @CodSanzioneequalthis , @Attivaequalthis , @DataInizioequalthis , @OperatoreInizioequalthis , @DataFineequalthis , @OperatoreFineequalthis , @Ordineequalthis ;
	else
		SELECT ID, ID_PROGRAMMAZIONE, COD_SANZIONE, ATTIVA, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, ORDINE, SANZIONE_TITOLO, SANZIONE_DESCRIZIONE, OPINIZIO_NOMINATIVO, OPFINE_NOMINATIVO
		FROM vZProgrammazione_Sanzioni
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@CodSanzioneequalthis IS NULL) OR COD_SANZIONE = @CodSanzioneequalthis) AND 
			((@Attivaequalthis IS NULL) OR ATTIVA = @Attivaequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@OperatoreInizioequalthis IS NULL) OR OPERATORE_INIZIO = @OperatoreInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@OperatoreFineequalthis IS NULL) OR OPERATORE_FINE = @OperatoreFineequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogrammazioneSanzioniFindSelect';

