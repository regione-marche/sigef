CREATE PROCEDURE [dbo].[ZIstanzaChecklistGenericaFindFind]
(
	@IdIstanzaGenericaequalthis INT, 
	@IdChecklistGenericaequalthis INT, 
	@CodFaseequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ISTANZA_GENERICA, ID_CHECKLIST_GENERICA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, DESCRIZIONE, FLAG_TEMPLATE, COD_FASE FROM VISTANZA_CHECKLIST_GENERICA WHERE 1=1';
	IF (@IdIstanzaGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTANZA_GENERICA = @IdIstanzaGenericaequalthis)'; set @lensql=@lensql+len(@IdIstanzaGenericaequalthis);end;
	IF (@IdChecklistGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis)'; set @lensql=@lensql+len(@IdChecklistGenericaequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdIstanzaGenericaequalthis INT, @IdChecklistGenericaequalthis INT, @CodFaseequalthis VARCHAR(255)',@IdIstanzaGenericaequalthis , @IdChecklistGenericaequalthis , @CodFaseequalthis ;
	else
		SELECT ID_ISTANZA_GENERICA, ID_CHECKLIST_GENERICA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, DESCRIZIONE, FLAG_TEMPLATE, COD_FASE
		FROM VISTANZA_CHECKLIST_GENERICA
		WHERE 
			((@IdIstanzaGenericaequalthis IS NULL) OR ID_ISTANZA_GENERICA = @IdIstanzaGenericaequalthis) AND 
			((@IdChecklistGenericaequalthis IS NULL) OR ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIstanzaChecklistGenericaFindFind';

