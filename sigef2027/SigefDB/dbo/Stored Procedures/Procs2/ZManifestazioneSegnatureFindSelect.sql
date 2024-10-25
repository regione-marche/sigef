CREATE PROCEDURE [dbo].[ZManifestazioneSegnatureFindSelect]
(
	@IdManifestazioneequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@Segnaturaequalthis VARCHAR(100)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_MANIFESTAZIONE, COD_TIPO, TIPO_SEGNATURA, DATA, OPERATORE, PROFILO, ENTE, NOMINATIVO, COD_ENTE, SEGNATURA, MOTIVAZIONE FROM vMANIFESTAZIONE_SEGNATURE WHERE 1=1';
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdManifestazioneequalthis INT, @CodTipoequalthis CHAR(3), @Dataequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @Segnaturaequalthis VARCHAR(100)',@IdManifestazioneequalthis , @CodTipoequalthis , @Dataequalthis , @Operatoreequalthis , @Segnaturaequalthis ;
	else
		SELECT ID_MANIFESTAZIONE, COD_TIPO, TIPO_SEGNATURA, DATA, OPERATORE, PROFILO, ENTE, NOMINATIVO, COD_ENTE, SEGNATURA, MOTIVAZIONE
		FROM vMANIFESTAZIONE_SEGNATURE
		WHERE 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneSegnatureFindSelect';

