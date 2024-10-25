CREATE PROCEDURE [dbo].[ZModificaDatiGeneraleFindSelect]
(
	@IdModificaequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdDomandaequalthis INT, 
	@IdVarianteequalthis INT, 
	@IdUtenteModificaequalthis INT, 
	@DataModificaequalthis DATETIME, 
	@CodTipoModificaequalthis INT, 
	@Noteequalthis VARCHAR(max)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_MODIFICA, ID_PROGETTO, ID_DOMANDA, ID_VARIANTE, ID_UTENTE_MODIFICA, DATA_MODIFICA, COD_TIPO_MODIFICA, NOTE, ISTANZA_PRECEDENTE, ISTANZA_NUOVO, TARGET, TIPO_MODIFICA, TIPO_MODIFICA_ATTIVO, UTENTE_MODIFICA, CF_UTENTE_MODIFICA FROM VMODIFICA_DATI_GENERALE WHERE 1=1';
	IF (@IdModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MODIFICA = @IdModificaequalthis)'; set @lensql=@lensql+len(@IdModificaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA = @IdDomandaequalthis)'; set @lensql=@lensql+len(@IdDomandaequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@IdUtenteModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_MODIFICA = @IdUtenteModificaequalthis)'; set @lensql=@lensql+len(@IdUtenteModificaequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CodTipoModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_MODIFICA = @CodTipoModificaequalthis)'; set @lensql=@lensql+len(@CodTipoModificaequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdModificaequalthis INT, @IdProgettoequalthis INT, @IdDomandaequalthis INT, @IdVarianteequalthis INT, @IdUtenteModificaequalthis INT, @DataModificaequalthis DATETIME, @CodTipoModificaequalthis INT, @Noteequalthis VARCHAR(max)',@IdModificaequalthis , @IdProgettoequalthis , @IdDomandaequalthis , @IdVarianteequalthis , @IdUtenteModificaequalthis , @DataModificaequalthis , @CodTipoModificaequalthis , @Noteequalthis ;
	else
		SELECT ID_MODIFICA, ID_PROGETTO, ID_DOMANDA, ID_VARIANTE, ID_UTENTE_MODIFICA, DATA_MODIFICA, COD_TIPO_MODIFICA, NOTE, ISTANZA_PRECEDENTE, ISTANZA_NUOVO, TARGET, TIPO_MODIFICA, TIPO_MODIFICA_ATTIVO, UTENTE_MODIFICA, CF_UTENTE_MODIFICA
		FROM VMODIFICA_DATI_GENERALE
		WHERE 
			((@IdModificaequalthis IS NULL) OR ID_MODIFICA = @IdModificaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaequalthis IS NULL) OR ID_DOMANDA = @IdDomandaequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@IdUtenteModificaequalthis IS NULL) OR ID_UTENTE_MODIFICA = @IdUtenteModificaequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CodTipoModificaequalthis IS NULL) OR COD_TIPO_MODIFICA = @CodTipoModificaequalthis) AND 
			((@Noteequalthis IS NULL) OR NOTE = @Noteequalthis)
		

GO