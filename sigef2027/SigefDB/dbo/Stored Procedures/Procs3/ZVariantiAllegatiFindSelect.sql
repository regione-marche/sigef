CREATE PROCEDURE [dbo].[ZVariantiAllegatiFindSelect]
(
	@IdAllegatoequalthis INT, 
	@IdVarianteequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@CodTipoDocumentoequalthis VARCHAR(255), 
	@IdFileequalthis INT, 
	@CodEnteEmettitoreequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@CodEsitoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ALLEGATO, ID_VARIANTE, COD_TIPO_DOCUMENTO, ID_FILE, DESCRIZIONE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, COD_ESITO, NOTE_ISTRUTTORE, ESITO, ESITO_POSITIVO, FORMATO, TIPO_ALLEGATO, TIPOLOGIA_DOCUMENTO, ENTE, DIMENSIONE_FILE FROM vVARIANTI_ALLEGATI WHERE 1=1';
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodTipoDocumentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis)'; set @lensql=@lensql+len(@CodTipoDocumentoequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@CodEnteEmettitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis)'; set @lensql=@lensql+len(@CodEnteEmettitoreequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO = @CodEsitoequalthis)'; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAllegatoequalthis INT, @IdVarianteequalthis INT, @Descrizioneequalthis VARCHAR(255), @CodTipoDocumentoequalthis VARCHAR(255), @IdFileequalthis INT, @CodEnteEmettitoreequalthis VARCHAR(255), @IdComuneequalthis INT, @Numeroequalthis VARCHAR(255), @Dataequalthis DATETIME, @CodEsitoequalthis VARCHAR(255)',@IdAllegatoequalthis , @IdVarianteequalthis , @Descrizioneequalthis , @CodTipoDocumentoequalthis , @IdFileequalthis , @CodEnteEmettitoreequalthis , @IdComuneequalthis , @Numeroequalthis , @Dataequalthis , @CodEsitoequalthis ;
	else
		SELECT ID_ALLEGATO, ID_VARIANTE, COD_TIPO_DOCUMENTO, ID_FILE, DESCRIZIONE, COD_ENTE_EMETTITORE, ID_COMUNE, NUMERO, DATA, COD_ESITO, NOTE_ISTRUTTORE, ESITO, ESITO_POSITIVO, FORMATO, TIPO_ALLEGATO, TIPOLOGIA_DOCUMENTO, ENTE, DIMENSIONE_FILE
		FROM vVARIANTI_ALLEGATI
		WHERE 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodTipoDocumentoequalthis IS NULL) OR COD_TIPO_DOCUMENTO = @CodTipoDocumentoequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@CodEnteEmettitoreequalthis IS NULL) OR COD_ENTE_EMETTITORE = @CodEnteEmettitoreequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZVariantiAllegatiFindSelect]
(
	@IdAllegatoequalthis INT, 
	@IdVarianteequalthis INT, 
	@Descrizioneequalthis VARCHAR(255), 
	@CodEsitoequalthis CHAR(2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ALLEGATO, ID_VARIANTE, DESCRIZIONE, COD_ESITO, NOTE_ISTRUTTORE FROM VARIANTI_ALLEGATI WHERE 1=1'';
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ALLEGATO = @IdAllegatoequalthis)''; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VARIANTE = @IdVarianteequalthis)''; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ESITO = @CodEsitoequalthis)''; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdAllegatoequalthis INT, @IdVarianteequalthis INT, @Descrizioneequalthis VARCHAR(255), @CodEsitoequalthis CHAR(2)'',@IdAllegatoequalthis , @IdVarianteequalthis , @Descrizioneequalthis , @CodEsitoequalthis ;
	else
		SELECT ID_ALLEGATO, ID_VARIANTE, DESCRIZIONE, COD_ESITO, NOTE_ISTRUTTORE
		FROM VARIANTI_ALLEGATI
		WHERE 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiAllegatiFindSelect';

