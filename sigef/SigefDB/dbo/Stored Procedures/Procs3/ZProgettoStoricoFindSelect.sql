CREATE PROCEDURE [dbo].[ZProgettoStoricoFindSelect]
(
	@Idequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodStatoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT, 
	@Segnaturaequalthis VARCHAR(255), 
	@Revisioneequalthis BIT, 
	@Riesameequalthis BIT, 
	@Ricorsoequalthis BIT, 
	@DataRiequalthis DATETIME, 
	@OperatoreRiequalthis INT, 
	@SegnaturaRiequalthis VARCHAR(255), 
	@RiaperturaProvincialeequalthis BIT, 
	@IdAttoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGETTO, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, RIAPERTURA_PROVINCIALE, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, NOMINATIVO, COD_ENTE, PROVINCIA, ID_PROFILO, PROFILO, ENTE, COD_TIPO_ENTE, ID_ATTO FROM vPROGETTO_STORICO WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@Revisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REVISIONE = @Revisioneequalthis)'; set @lensql=@lensql+len(@Revisioneequalthis);end;
	IF (@Riesameequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RIESAME = @Riesameequalthis)'; set @lensql=@lensql+len(@Riesameequalthis);end;
	IF (@Ricorsoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RICORSO = @Ricorsoequalthis)'; set @lensql=@lensql+len(@Ricorsoequalthis);end;
	IF (@DataRiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RI = @DataRiequalthis)'; set @lensql=@lensql+len(@DataRiequalthis);end;
	IF (@OperatoreRiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_RI = @OperatoreRiequalthis)'; set @lensql=@lensql+len(@OperatoreRiequalthis);end;
	IF (@SegnaturaRiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_RI = @SegnaturaRiequalthis)'; set @lensql=@lensql+len(@SegnaturaRiequalthis);end;
	IF (@RiaperturaProvincialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RIAPERTURA_PROVINCIALE = @RiaperturaProvincialeequalthis)'; set @lensql=@lensql+len(@RiaperturaProvincialeequalthis);end;
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO = @IdAttoequalthis)'; set @lensql=@lensql+len(@IdAttoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdProgettoequalthis INT, @CodStatoequalthis VARCHAR(255), @Dataequalthis DATETIME, @Operatoreequalthis INT, @Segnaturaequalthis VARCHAR(255), @Revisioneequalthis BIT, @Riesameequalthis BIT, @Ricorsoequalthis BIT, @DataRiequalthis DATETIME, @OperatoreRiequalthis INT, @SegnaturaRiequalthis VARCHAR(255), @RiaperturaProvincialeequalthis BIT, @IdAttoequalthis INT',@Idequalthis , @IdProgettoequalthis , @CodStatoequalthis , @Dataequalthis , @Operatoreequalthis , @Segnaturaequalthis , @Revisioneequalthis , @Riesameequalthis , @Ricorsoequalthis , @DataRiequalthis , @OperatoreRiequalthis , @SegnaturaRiequalthis , @RiaperturaProvincialeequalthis , @IdAttoequalthis ;
	else
		SELECT ID, ID_PROGETTO, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, RIAPERTURA_PROVINCIALE, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, NOMINATIVO, COD_ENTE, PROVINCIA, ID_PROFILO, PROFILO, ENTE, COD_TIPO_ENTE, ID_ATTO
		FROM vPROGETTO_STORICO
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@Revisioneequalthis IS NULL) OR REVISIONE = @Revisioneequalthis) AND 
			((@Riesameequalthis IS NULL) OR RIESAME = @Riesameequalthis) AND 
			((@Ricorsoequalthis IS NULL) OR RICORSO = @Ricorsoequalthis) AND 
			((@DataRiequalthis IS NULL) OR DATA_RI = @DataRiequalthis) AND 
			((@OperatoreRiequalthis IS NULL) OR OPERATORE_RI = @OperatoreRiequalthis) AND 
			((@SegnaturaRiequalthis IS NULL) OR SEGNATURA_RI = @SegnaturaRiequalthis) AND 
			((@RiaperturaProvincialeequalthis IS NULL) OR RIAPERTURA_PROVINCIALE = @RiaperturaProvincialeequalthis) AND 
			((@IdAttoequalthis IS NULL) OR ID_ATTO = @IdAttoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoStoricoFindSelect]
(
	@Idequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodStatoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT, 
	@Segnaturaequalthis VARCHAR(255), 
	@Revisioneequalthis BIT, 
	@Riesameequalthis BIT, 
	@Ricorsoequalthis BIT, 
	@DataRiequalthis DATETIME, 
	@OperatoreRiequalthis INT, 
	@SegnaturaRiequalthis VARCHAR(255), 
	@RiaperturaProvincialeequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGETTO, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, RIAPERTURA_PROVINCIALE, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, NOMINATIVO, COD_ENTE, PROVINCIA, ID_PROFILO, PROFILO, ENTE, COD_TIPO_ENTE FROM vPROGETTO_STORICO WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_STATO = @CodStatoequalthis)''; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA = @Segnaturaequalthis)''; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@Revisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (REVISIONE = @Revisioneequalthis)''; set @lensql=@lensql+len(@Revisioneequalthis);end;
	IF (@Riesameequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RIESAME = @Riesameequalthis)''; set @lensql=@lensql+len(@Riesameequalthis);end;
	IF (@Ricorsoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RICORSO = @Ricorsoequalthis)''; set @lensql=@lensql+len(@Ricorsoequalthis);end;
	IF (@DataRiequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_RI = @DataRiequalthis)''; set @lensql=@lensql+len(@DataRiequalthis);end;
	IF (@OperatoreRiequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE_RI = @OperatoreRiequalthis)''; set @lensql=@lensql+len(@OperatoreRiequalthis);end;
	IF (@SegnaturaRiequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA_RI = @SegnaturaRiequalthis)''; set @lensql=@lensql+len(@SegnaturaRiequalthis);end;
	IF (@RiaperturaProvincialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RIAPERTURA_PROVINCIALE = @RiaperturaProvincialeequalthis)''; set @lensql=@lensql+len(@RiaperturaProvincialeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdProgettoequalthis INT, @CodStatoequalthis VARCHAR(255), @Dataequalthis DATETIME, @Operatoreequalthis INT, @Segnaturaequalthis VARCHAR(255), @Revisioneequalthis BIT, @Riesameequalthis BIT, @Ricorsoequalthis BIT, @DataRiequalthis DATETIME, @OperatoreRiequalthis INT, @SegnaturaRiequalthis VARCHAR(255), @RiaperturaProvincialeequalthis BIT'',@Idequalthis , @IdProgettoequalthis , @CodStatoequalthis , @Dataequalthis , @Operatoreequalthis , @Segnaturaequalthis , @Revisioneequalthis , @Riesameequalthis , @Ricorsoequalthis , @DataRiequalthis , @OperatoreRiequalthis , @SegnaturaRiequalthis , @RiaperturaProvincialeequalthis ;
	else
		SELECT ID, ID_PROGETTO, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, RIAPERTURA_PROVINCIALE, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, NOMINATIVO, COD_ENTE, PROVINCIA, ID_PROFILO, PROFILO, ENTE, COD_TIPO_ENTE
		FROM vPROGETTO_STORICO
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgettoequalthis IS NULL)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoStoricoFindSelect';

