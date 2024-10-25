CREATE PROCEDURE [dbo].[ZDisposizioneFindGetdisposizioniirregolaritaold]
(
	@IdRegistroIrregolaritaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DISPOSIZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_TIPO_DISPOSIZIONE, NUMERO, ANNO, ARTICOLO_PARAGRAFO, DISPOSIZIONE_NAZIONALE, ID_REGISTRO_IRREGOLARITA, ID_IRREGOLARITA, NAZIONALE, REGIONALE FROM VDISPOSIZIONE WHERE 1=1';
	IF (@IdRegistroIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REGISTRO_IRREGOLARITA = @IdRegistroIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdRegistroIrregolaritaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRegistroIrregolaritaequalthis INT',@IdRegistroIrregolaritaequalthis ;
	else
		SELECT ID_DISPOSIZIONE, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_TIPO_DISPOSIZIONE, NUMERO, ANNO, ARTICOLO_PARAGRAFO, DISPOSIZIONE_NAZIONALE, ID_REGISTRO_IRREGOLARITA, ID_IRREGOLARITA, NAZIONALE, REGIONALE
		FROM VDISPOSIZIONE
		WHERE 
			((@IdRegistroIrregolaritaequalthis IS NULL) OR ID_REGISTRO_IRREGOLARITA = @IdRegistroIrregolaritaequalthis)
		

GO