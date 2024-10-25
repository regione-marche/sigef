CREATE PROCEDURE [dbo].[ZBandoStoricoFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@CodStatoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT, 
	@Segnaturaequalthis VARCHAR(255), 
	@IdAttoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, STATO, ORDINE_STATO, PROFILO, NOMINATIVO, NUMERO_ATTO, DATA_ATTO FROM vBANDO_STORICO WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@IdAttoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO = @IdAttoequalthis)'; set @lensql=@lensql+len(@IdAttoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdBandoequalthis INT, @CodStatoequalthis VARCHAR(255), @Dataequalthis DATETIME, @Operatoreequalthis INT, @Segnaturaequalthis VARCHAR(255), @IdAttoequalthis INT',@Idequalthis , @IdBandoequalthis , @CodStatoequalthis , @Dataequalthis , @Operatoreequalthis , @Segnaturaequalthis , @IdAttoequalthis ;
	else
		SELECT ID, ID_BANDO, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, STATO, ORDINE_STATO, PROFILO, NOMINATIVO, NUMERO_ATTO, DATA_ATTO
		FROM vBANDO_STORICO
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@IdAttoequalthis IS NULL) OR ID_ATTO = @IdAttoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoStoricoFindSelect';

