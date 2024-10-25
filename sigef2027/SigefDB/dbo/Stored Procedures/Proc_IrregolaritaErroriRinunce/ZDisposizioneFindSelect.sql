CREATE PROCEDURE [dbo].[ZDisposizioneFindSelect]
(
	@IdDisposizioneequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@IdTipoDisposizioneequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@Annoequalthis INT, 
	@ArticoloParagrafoequalthis VARCHAR(255), 
	@DisposizioneNazionaleequalthis VARCHAR(2000), 
	@IdRegistroIrregolaritaequalthis INT, 
	@IdIrregolaritaequalthis INT, 
	@Nazionaleequalthis BIT, 
	@Regionaleequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DISPOSIZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_TIPO_DISPOSIZIONE, NUMERO, ANNO, ARTICOLO_PARAGRAFO, DISPOSIZIONE_NAZIONALE, ID_REGISTRO_IRREGOLARITA, ID_IRREGOLARITA, NAZIONALE, REGIONALE FROM VDISPOSIZIONE WHERE 1=1';
	IF (@IdDisposizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DISPOSIZIONE = @IdDisposizioneequalthis)'; set @lensql=@lensql+len(@IdDisposizioneequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@IdTipoDisposizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_DISPOSIZIONE = @IdTipoDisposizioneequalthis)'; set @lensql=@lensql+len(@IdTipoDisposizioneequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@ArticoloParagrafoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ARTICOLO_PARAGRAFO = @ArticoloParagrafoequalthis)'; set @lensql=@lensql+len(@ArticoloParagrafoequalthis);end;
	IF (@DisposizioneNazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DISPOSIZIONE_NAZIONALE = @DisposizioneNazionaleequalthis)'; set @lensql=@lensql+len(@DisposizioneNazionaleequalthis);end;
	IF (@IdRegistroIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REGISTRO_IRREGOLARITA = @IdRegistroIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdRegistroIrregolaritaequalthis);end;
	IF (@IdIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IRREGOLARITA = @IdIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdIrregolaritaequalthis);end;
	IF (@Nazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NAZIONALE = @Nazionaleequalthis)'; set @lensql=@lensql+len(@Nazionaleequalthis);end;
	IF (@Regionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REGIONALE = @Regionaleequalthis)'; set @lensql=@lensql+len(@Regionaleequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDisposizioneequalthis INT, @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @IdTipoDisposizioneequalthis INT, @Numeroequalthis VARCHAR(255), @Annoequalthis INT, @ArticoloParagrafoequalthis VARCHAR(255), @DisposizioneNazionaleequalthis VARCHAR(2000), @IdRegistroIrregolaritaequalthis INT, @IdIrregolaritaequalthis INT, @Nazionaleequalthis BIT, @Regionaleequalthis BIT',@IdDisposizioneequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis , @IdTipoDisposizioneequalthis , @Numeroequalthis , @Annoequalthis , @ArticoloParagrafoequalthis , @DisposizioneNazionaleequalthis , @IdRegistroIrregolaritaequalthis , @IdIrregolaritaequalthis , @Nazionaleequalthis , @Regionaleequalthis ;
	else
		SELECT ID_DISPOSIZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_TIPO_DISPOSIZIONE, NUMERO, ANNO, ARTICOLO_PARAGRAFO, DISPOSIZIONE_NAZIONALE, ID_REGISTRO_IRREGOLARITA, ID_IRREGOLARITA, NAZIONALE, REGIONALE
		FROM VDISPOSIZIONE
		WHERE 
			((@IdDisposizioneequalthis IS NULL) OR ID_DISPOSIZIONE = @IdDisposizioneequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@IdTipoDisposizioneequalthis IS NULL) OR ID_TIPO_DISPOSIZIONE = @IdTipoDisposizioneequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@ArticoloParagrafoequalthis IS NULL) OR ARTICOLO_PARAGRAFO = @ArticoloParagrafoequalthis) AND 
			((@DisposizioneNazionaleequalthis IS NULL) OR DISPOSIZIONE_NAZIONALE = @DisposizioneNazionaleequalthis) AND 
			((@IdRegistroIrregolaritaequalthis IS NULL) OR ID_REGISTRO_IRREGOLARITA = @IdRegistroIrregolaritaequalthis) AND 
			((@IdIrregolaritaequalthis IS NULL) OR ID_IRREGOLARITA = @IdIrregolaritaequalthis) AND 
			((@Nazionaleequalthis IS NULL) OR NAZIONALE = @Nazionaleequalthis) AND 
			((@Regionaleequalthis IS NULL) OR REGIONALE = @Regionaleequalthis)
		

GO