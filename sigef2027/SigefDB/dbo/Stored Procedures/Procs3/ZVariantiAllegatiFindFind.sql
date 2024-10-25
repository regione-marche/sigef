CREATE PROCEDURE [dbo].[ZVariantiAllegatiFindFind]
(
	@IdVarianteequalthis INT, 
	@CodTipoDocumentoequalthis VARCHAR(255), 
	@Formatoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO, ID_VARIANTE, COD_TIPO_DOCUMENTO, ID_FILE, DESCRIZIONE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, COD_ESITO, NOTE_ISTRUTTORE, ESITO, ESITO_POSITIVO, FORMATO, TIPO_ALLEGATO, TIPOLOGIA_DOCUMENTO, ENTE, DIMENSIONE_FILE FROM vVARIANTI_ALLEGATI WHERE 1=1';
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis)'; set @lensql=@lensql+len(@CodTipoDocumentoequalthis);end;
	IF (@Formatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FORMATO = @Formatoequalthis)'; set @lensql=@lensql+len(@Formatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVarianteequalthis INT, @CodTipoDocumentoequalthis VARCHAR(255), @Formatoequalthis VARCHAR(255)',@IdVarianteequalthis , @CodTipoDocumentoequalthis , @Formatoequalthis ;
	else
		SELECT ID_ALLEGATO, ID_VARIANTE, COD_TIPO_DOCUMENTO, ID_FILE, DESCRIZIONE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, COD_ESITO, NOTE_ISTRUTTORE, ESITO, ESITO_POSITIVO, FORMATO, TIPO_ALLEGATO, TIPOLOGIA_DOCUMENTO, ENTE, DIMENSIONE_FILE
		FROM vVARIANTI_ALLEGATI
		WHERE 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodTipoDocumentoequalthis IS NULL) OR COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis) AND 
			((@Formatoequalthis IS NULL) OR FORMATO = @Formatoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZVariantiAllegatiFindFind]
(
	@IdAllegatoequalthis INT, 
	@IdVarianteequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ALLEGATO, ID_VARIANTE, DESCRIZIONE, COD_ESITO, NOTE_ISTRUTTORE FROM VARIANTI_ALLEGATI WHERE 1=1'';
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ALLEGATO = @IdAllegatoequalthis)''; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VARIANTE = @IdVarianteequalthis)''; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdAllegatoequalthis INT, @IdVarianteequalthis INT'',@IdAllegatoequalthis , @IdVarianteequalthis ;
	else
		SELECT ID_ALLEGATO, ID_VARIANTE, DESCRIZIONE, COD_ESITO, NOTE_ISTRUTTORE
		FROM VARIANTI_ALLEGATI
		WHERE 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiAllegatiFindFind';

