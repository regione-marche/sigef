CREATE PROCEDURE [dbo].[ZVariantiXPrioritaFindFind]
(
	@IdVarianteequalthis INT, 
	@IdPrioritaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VARIANTE, ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, FLAG_DEFINITIVO FROM vVARIANTI_X_PRIORITA WHERE 1=1';
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVarianteequalthis INT, @IdPrioritaequalthis INT',@IdVarianteequalthis , @IdPrioritaequalthis ;
	else
		SELECT ID_VARIANTE, ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA, FLAG_DEFINITIVO
		FROM vVARIANTI_X_PRIORITA
		WHERE 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiXPrioritaFindFind';

