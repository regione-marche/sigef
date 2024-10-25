CREATE PROCEDURE [dbo].[ZDisposizioneFindGetdisposizioniirregolarita]
(
	@IdIrregolaritaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DISPOSIZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_TIPO_DISPOSIZIONE, NUMERO, ANNO, ARTICOLO_PARAGRAFO, DISPOSIZIONE_NAZIONALE, ID_REGISTRO_IRREGOLARITA, ID_IRREGOLARITA, NAZIONALE, REGIONALE FROM VDISPOSIZIONE WHERE 1=1';
	IF (@IdIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IRREGOLARITA = @IdIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdIrregolaritaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdIrregolaritaequalthis INT',@IdIrregolaritaequalthis ;
	else
		SELECT ID_DISPOSIZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_TIPO_DISPOSIZIONE, NUMERO, ANNO, ARTICOLO_PARAGRAFO, DISPOSIZIONE_NAZIONALE, ID_REGISTRO_IRREGOLARITA, ID_IRREGOLARITA, NAZIONALE, REGIONALE
		FROM VDISPOSIZIONE
		WHERE 
			((@IdIrregolaritaequalthis IS NULL) OR ID_IRREGOLARITA = @IdIrregolaritaequalthis)
		

GO