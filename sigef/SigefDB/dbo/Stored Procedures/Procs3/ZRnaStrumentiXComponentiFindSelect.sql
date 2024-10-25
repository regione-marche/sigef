CREATE PROCEDURE [dbo].[ZRnaStrumentiXComponentiFindSelect]
(
	@IdStrumentiXComponentiequalthis INT, 
	@IdComponentiXCodificaequalthis INT, 
	@CodTipoStrumentoAiutoequalthis INT, 
	@IntensitaStrumentoequalthis DECIMAL(15,12)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_STRUMENTI_X_COMPONENTI, ID_COMPONENTI_X_CODIFICA, COD_TIPO_STRUMENTO_AIUTO, INTENSITA_STRUMENTO FROM RNA_STRUMENTI_X_COMPONENTI WHERE 1=1';
	IF (@IdStrumentiXComponentiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STRUMENTI_X_COMPONENTI = @IdStrumentiXComponentiequalthis)'; set @lensql=@lensql+len(@IdStrumentiXComponentiequalthis);end;
	IF (@IdComponentiXCodificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodificaequalthis)'; set @lensql=@lensql+len(@IdComponentiXCodificaequalthis);end;
	IF (@CodTipoStrumentoAiutoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_STRUMENTO_AIUTO = @CodTipoStrumentoAiutoequalthis)'; set @lensql=@lensql+len(@CodTipoStrumentoAiutoequalthis);end;
	IF (@IntensitaStrumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INTENSITA_STRUMENTO = @IntensitaStrumentoequalthis)'; set @lensql=@lensql+len(@IntensitaStrumentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdStrumentiXComponentiequalthis INT, @IdComponentiXCodificaequalthis INT, @CodTipoStrumentoAiutoequalthis INT, @IntensitaStrumentoequalthis DECIMAL(15,12)',@IdStrumentiXComponentiequalthis , @IdComponentiXCodificaequalthis , @CodTipoStrumentoAiutoequalthis , @IntensitaStrumentoequalthis ;
	else
		SELECT ID_STRUMENTI_X_COMPONENTI, ID_COMPONENTI_X_CODIFICA, COD_TIPO_STRUMENTO_AIUTO, INTENSITA_STRUMENTO
		FROM RNA_STRUMENTI_X_COMPONENTI
		WHERE 
			((@IdStrumentiXComponentiequalthis IS NULL) OR ID_STRUMENTI_X_COMPONENTI = @IdStrumentiXComponentiequalthis) AND 
			((@IdComponentiXCodificaequalthis IS NULL) OR ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodificaequalthis) AND 
			((@CodTipoStrumentoAiutoequalthis IS NULL) OR COD_TIPO_STRUMENTO_AIUTO = @CodTipoStrumentoAiutoequalthis) AND 
			((@IntensitaStrumentoequalthis IS NULL) OR INTENSITA_STRUMENTO = @IntensitaStrumentoequalthis)