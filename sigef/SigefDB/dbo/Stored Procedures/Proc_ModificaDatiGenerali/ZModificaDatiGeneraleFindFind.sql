CREATE PROCEDURE [dbo].[ZModificaDatiGeneraleFindFind]
(
	@IdProgettoequalthis INT, 
	@IdDomandaequalthis INT, 
	@IdVarianteequalthis INT, 
	@CodTipoModificaequalthis INT, 
	@TipoModificaequalthis VARCHAR(max), 
	@TipoModificaAttivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_MODIFICA, ID_PROGETTO, ID_DOMANDA, ID_VARIANTE, ID_UTENTE_MODIFICA, DATA_MODIFICA, COD_TIPO_MODIFICA, NOTE, ISTANZA_PRECEDENTE, ISTANZA_NUOVO, TARGET, TIPO_MODIFICA, TIPO_MODIFICA_ATTIVO, UTENTE_MODIFICA, CF_UTENTE_MODIFICA FROM VMODIFICA_DATI_GENERALE WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA = @IdDomandaequalthis)'; set @lensql=@lensql+len(@IdDomandaequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_MODIFICA = @CodTipoModificaequalthis)'; set @lensql=@lensql+len(@CodTipoModificaequalthis);end;
	IF (@TipoModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_MODIFICA = @TipoModificaequalthis)'; set @lensql=@lensql+len(@TipoModificaequalthis);end;
	IF (@TipoModificaAttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_MODIFICA_ATTIVO = @TipoModificaAttivoequalthis)'; set @lensql=@lensql+len(@TipoModificaAttivoequalthis);end;
	set @sql = @sql + 'ORDER BY DATA_MODIFICA ASC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdDomandaequalthis INT, @IdVarianteequalthis INT, @CodTipoModificaequalthis INT, @TipoModificaequalthis VARCHAR(max), @TipoModificaAttivoequalthis BIT',@IdProgettoequalthis , @IdDomandaequalthis , @IdVarianteequalthis , @CodTipoModificaequalthis , @TipoModificaequalthis , @TipoModificaAttivoequalthis ;
	else
		SELECT ID_MODIFICA, ID_PROGETTO, ID_DOMANDA, ID_VARIANTE, ID_UTENTE_MODIFICA, DATA_MODIFICA, COD_TIPO_MODIFICA, NOTE, ISTANZA_PRECEDENTE, ISTANZA_NUOVO, TARGET, TIPO_MODIFICA, TIPO_MODIFICA_ATTIVO, UTENTE_MODIFICA, CF_UTENTE_MODIFICA
		FROM VMODIFICA_DATI_GENERALE
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaequalthis IS NULL) OR ID_DOMANDA = @IdDomandaequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodTipoModificaequalthis IS NULL) OR COD_TIPO_MODIFICA = @CodTipoModificaequalthis) AND 
			((@TipoModificaequalthis IS NULL) OR TIPO_MODIFICA = @TipoModificaequalthis) AND 
			((@TipoModificaAttivoequalthis IS NULL) OR TIPO_MODIFICA_ATTIVO = @TipoModificaAttivoequalthis)
		ORDER BY DATA_MODIFICA ASC

GO