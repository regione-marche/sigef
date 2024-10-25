CREATE PROCEDURE [dbo].[ZDisposizioneFindFind]
(
	@IdDisposizioneequalthis INT, 
	@IdIrregolaritaequalthis INT, 
	@IdTipoDisposizioneequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@Annoequalthis INT, 
	@ArticoloParagrafoequalthis VARCHAR(255), 
	@Nazionaleequalthis BIT, 
	@Regionaleequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DISPOSIZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_TIPO_DISPOSIZIONE, NUMERO, ANNO, ARTICOLO_PARAGRAFO, DISPOSIZIONE_NAZIONALE, ID_REGISTRO_IRREGOLARITA, ID_IRREGOLARITA, NAZIONALE, REGIONALE FROM VDISPOSIZIONE WHERE 1=1';
	IF (@IdDisposizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DISPOSIZIONE = @IdDisposizioneequalthis)'; set @lensql=@lensql+len(@IdDisposizioneequalthis);end;
	IF (@IdIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IRREGOLARITA = @IdIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdIrregolaritaequalthis);end;
	IF (@IdTipoDisposizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TIPO_DISPOSIZIONE = @IdTipoDisposizioneequalthis)'; set @lensql=@lensql+len(@IdTipoDisposizioneequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@ArticoloParagrafoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ARTICOLO_PARAGRAFO = @ArticoloParagrafoequalthis)'; set @lensql=@lensql+len(@ArticoloParagrafoequalthis);end;
	IF (@Nazionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NAZIONALE = @Nazionaleequalthis)'; set @lensql=@lensql+len(@Nazionaleequalthis);end;
	IF (@Regionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REGIONALE = @Regionaleequalthis)'; set @lensql=@lensql+len(@Regionaleequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDisposizioneequalthis INT, @IdIrregolaritaequalthis INT, @IdTipoDisposizioneequalthis INT, @Numeroequalthis VARCHAR(255), @Annoequalthis INT, @ArticoloParagrafoequalthis VARCHAR(255), @Nazionaleequalthis BIT, @Regionaleequalthis BIT',@IdDisposizioneequalthis , @IdIrregolaritaequalthis , @IdTipoDisposizioneequalthis , @Numeroequalthis , @Annoequalthis , @ArticoloParagrafoequalthis , @Nazionaleequalthis , @Regionaleequalthis ;
	else
		SELECT ID_DISPOSIZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_TIPO_DISPOSIZIONE, NUMERO, ANNO, ARTICOLO_PARAGRAFO, DISPOSIZIONE_NAZIONALE, ID_REGISTRO_IRREGOLARITA, ID_IRREGOLARITA, NAZIONALE, REGIONALE
		FROM VDISPOSIZIONE
		WHERE 
			((@IdDisposizioneequalthis IS NULL) OR ID_DISPOSIZIONE = @IdDisposizioneequalthis) AND 
			((@IdIrregolaritaequalthis IS NULL) OR ID_IRREGOLARITA = @IdIrregolaritaequalthis) AND 
			((@IdTipoDisposizioneequalthis IS NULL) OR ID_TIPO_DISPOSIZIONE = @IdTipoDisposizioneequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@ArticoloParagrafoequalthis IS NULL) OR ARTICOLO_PARAGRAFO = @ArticoloParagrafoequalthis) AND 
			((@Nazionaleequalthis IS NULL) OR NAZIONALE = @Nazionaleequalthis) AND 
			((@Regionaleequalthis IS NULL) OR REGIONALE = @Regionaleequalthis)
		

GO